using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PasswordCore.Enums;
using PasswordCore.Interfaces;
using PasswordCore.Model;
using PasswordCore.Repositories;
using RevisedPWApp.Interfaces;
using System.Reflection;

namespace RevisedPWApp.Models
{
    public class PasswordDisplayProps : IDisplayProps
    {
        private readonly IAccountRepository _acc;
        private readonly IPasswordRepository _pwRepository;
        private const string DefaultFile = @"Resources\avatar.png";

        public PasswordDisplayProps(IPasswordRepository pwRepository, IAccountRepository accRepository)
        {
            _acc = accRepository;
            _pwRepository = pwRepository;
        }

        public int AccountUserId { get; set; }

        public int LoginUser(string user, string password)
        {

            //check if user is in the database
            if (user == string.Empty || password == string.Empty) return 0;
            var accountUser = _acc.GetRecordByCredentials(user, password);
            if (accountUser == null) return 0;

            //_appInitializer.PassRepo = new PasswordRepository(_appInitializer.Connector, accountUser.UserId);
            //_appInitializer.AccRepo.AccountUsers.Clear();
            //_appInitializer.AccRepo.AccountUsers.Add(accountUser);
            AccountUserId = accountUser.UserId;
            return AccountUserId;
        }

        public void LogoutUser(DataGridView grid)
        {
            LoadDataGrid(grid, true);
        }

        public void ClearFormData(Form form, DataGridView grid)
        {
            foreach (var displayControl in form.Controls.OfType<TextBox>())
            {
                displayControl.Text = string.Empty;
            }
            LoadDataGrid(grid, false);
        }

        public void LoadDataGrid(DataGridView dataGrid, bool isLoggedOut, List<Passwords> pList = null)
        {
            try
            {
                if (isLoggedOut)
                {
                    dataGrid.DataSource = null;
                }
                else
                {
                    _pwRepository.UserId = AccountUserId;
                    dataGrid.DataSource = pList ?? _pwRepository.GetRecords();
                    FillGrid(dataGrid);
                }
            }
            catch (Exception)
            {
                FillGrid(dataGrid);
            }
        }

        private static void FillGrid(DataGridView dataGrid)
        {
            foreach (DataGridViewColumn column in dataGrid.Columns)
            {
                if (column.Name == "Name") continue;
                column.Visible = false;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dataGrid.Font = new Font("Arial", 11);
        }

        public void DeletePassword(DataGridView dataGrid)
        {
            var result = MessageBox.Show(@"Are you sure you want to delete the selection?", @"Deleting?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result != DialogResult.Yes) return;
            try
            {
                var id = GetPasswordValues(dataGrid).Id;
                _pwRepository.DeleteEntry(id);
                MessageBox.Show(@"Record successfully deleted!", @"Record Deleted");
                LoadDataGrid(dataGrid, false);
            }
            catch (Exception)
            {
                throw new Exception("Record not delete due to application error!");
            }
        }

        private Passwords GetPasswordValues(DataGridView dataGrid)
        {
            try
            {
                return _pwRepository.GetRecords().FirstOrDefault(
                        p => p.Id == (int)dataGrid.Rows[dataGrid.CurrentCell.RowIndex].Cells["Id"].Value);
            }
            catch (Exception)
            {
                throw new Exception("No row was selected!");
            }
        }

        public void EditPassword(int userId, DataGridView dataGrid, Passwords pwValues)
        {
            try
            {
                var id = GetPasswordValues(dataGrid).Id; //the ID of the modified row
                _pwRepository.EditEntry(id, pwValues);
                MessageBox.Show(@"Record successfully updated!", @"Record Edited");
                //_entry.ResetEntryForm();
                LoadDataGrid(dataGrid, false);
                SetCurrentCell(dataGrid, id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Record Not Edited");
            }
        }

        public AccountUser GetLoggedInUser(int currentUser)
        {
            return _acc.GetRecords().FirstOrDefault(p => p.UserId == currentUser);
        }

        private void SetCurrentCell(DataGridView dataGrid, int rowId)
        {
            int index = (dataGrid.Rows.Cast<DataGridViewRow>()
                .Where(r => r.Cells[0].Value.ToString() == rowId.ToString())
                .Select(r => r.Index)).FirstOrDefault();
            dataGrid.CurrentCell = dataGrid.Rows[index].Cells["Name"];
        }

        public int CreateNewUserAccount(List<string> userData)
        {
            //check if user is in the database
            var accRec = GetAccountUser(userData);
            AccountUserId = _acc.InsertNewRecord(accRec);
            return AccountUserId;
        }

        private static AccountUser GetAccountUser(List<string> userData)
        {
            var accRec = new AccountUser()
            {
                Username = userData[0],
                Password = userData[1],
                FirstName = userData[2],
                LastName = userData[3],
                Pin = userData[4]
            };
            return accRec;
        }

        public void AddNewPassword(int userId, DataGridView dataGrid, Passwords pw)
        {
            if (string.IsNullOrEmpty(pw.Name) ||
                string.IsNullOrEmpty(pw.Username) ||
                string.IsNullOrEmpty(pw.Password)) throw new Exception("Required field(s) not filled out!");
            _pwRepository.InsertNewRecord(pw);
            MessageBox.Show(@"Record successfully added!", @"Record Added");
            //_entry.ResetEntryForm();
            LoadDataGrid(dataGrid, false);
        }

        public int EditUserAccountData(List<string> credentials)
        {
            var accRec = GetAccountUser(credentials);
            AccountUserId = _acc.EditEntry(accRec);
            return AccountUserId;
        }

        public string PushPasswordsToFile(Display display, ITextFile textFile)
        {
            var filename = SaveTextFile();
            display.Controls["txtPushFile"].Text = filename;
            textFile.DestinationFolder = $@"{Path.GetDirectoryName(filename)}\";
            textFile.DestinationFile = Path.GetFileName(filename);
            var pin = GetLoggedInUser(AccountUserId).Pin;
            textFile.PlacePasswordRecordsInFile(pin, ShiftDirection.ShiftNone);
            return filename;
        }

        private string SaveTextFile()
        {
            SaveFileDialog fileDialog = new SaveFileDialog { Title = @"Save Text File" };
            return fileDialog.ShowDialog() == DialogResult.OK ? fileDialog.FileName : string.Empty;
        }

        public void SetPictureBoxImage(PictureBox picture, string imageFile)
        {
            var dir = Assembly.GetExecutingAssembly();
            var location = string.Concat(dir.Location.Substring(0, dir.Location.IndexOf("bin", StringComparison.Ordinal)),
                DefaultFile);
            imageFile = string.IsNullOrEmpty(imageFile) ? location : imageFile;
            picture.Image = Image.FromFile(@imageFile);
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public string GetPhotoLocationFromFile(IEmailAccountRepository emailAccount, int userId)
        {
            
            var fileName = GetTextFile();
            if (!File.Exists(fileName)) return DefaultFile;
            var email = emailAccount.GetRecordById(userId);
            email.PhotoLocation = fileName;
            emailAccount.EditEntry(userId, email);
            return fileName;
        }

        public string GetPasswordFromFile(Display display, ITextFile text, DataGridView dvGrid)
        {
            var filename = GetTextFile();
            if (!File.Exists(filename)) return string.Empty;
            display.Controls["txtRetrieveFile"].Text = filename;
            text.SourceFolder = Path.GetDirectoryName(filename);
            text.AddPasswordListToDb();
            LoadDataGrid(dvGrid, false);
            return filename;
        }

        private string GetTextFile()
        {
            OpenFileDialog fileDialog = new OpenFileDialog { Title = @"Open Text File" };
            return fileDialog.ShowDialog() == DialogResult.OK ? fileDialog.FileName : string.Empty;
        }
    }
}
