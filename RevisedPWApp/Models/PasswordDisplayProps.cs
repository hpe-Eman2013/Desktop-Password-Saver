using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using RevisedPWApp.Interfaces;
using FileZipperAndExtractor;
using Model.Lib;

namespace RevisedPWApp.Models
{
    public class PasswordDisplayProps : IDisplayProps
    {
        private const string DefaultFile = @"Resources\avatar.png";
        private IZipEncrypt _zipper;
        private IModelAdapter<UserAccount> _userAccount;
        private IModelAdapter<PasswordTracker> _pwTracker;
        private string _password;
        public PasswordDisplayProps(IModelAdapter<UserAccount> userAccount,
            IModelAdapter<PasswordTracker> pwTracker, 
            IZipEncrypt zipEncrypt)
        {
            _userAccount = userAccount;
            _pwTracker = pwTracker;
            _zipper = zipEncrypt;
        }

        public int AccountUserId { get; set; }
        
        public int LoginUser(string user, string password)
        {
            //check if user is in the database
            if (user == string.Empty || password == string.Empty) return 0;//invalid entry
            var accountUser = _userAccount.GetRecordByCredentials(user, password);
            if (accountUser == null) return 0;//user is not in database
            AccountUserId = accountUser.UserId;
            _password = password;
            return AccountUserId;//user found
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

        public void LoadDataGrid(DataGridView dataGrid, bool isLoggedOut, List<PasswordTracker> pList = null)
        {
            try
            {
                if (isLoggedOut)
                {
                    dataGrid.DataSource = null;
                }
                else
                {
                    _pwTracker.Id = AccountUserId;
                    dataGrid.DataSource = pList ??_pwTracker.GetRecords();
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
                var id = GetPasswordValues(dataGrid).ID;
                _pwTracker.DeleteEntry(id);
                MessageBox.Show(@"Record successfully deleted!", @"Record Deleted");
                LoadDataGrid(dataGrid, false);
            }
            catch (Exception)
            {
                throw new Exception("Record not delete due to application error!");
            }
        }

        private PasswordTracker GetPasswordValues(DataGridView dataGrid)
        {
            try
            {
                return _pwTracker.GetRecords().FirstOrDefault(
                        p => p.ID == (int)dataGrid.Rows[dataGrid.CurrentCell.RowIndex].Cells["Id"].Value);
            }
            catch (Exception)
            {
                throw new Exception("No row was selected!");
            }
        }

        public void EditPassword(int userId, DataGridView dataGrid, PasswordTracker pwValues)
        {
            try
            {
                var id = GetPasswordValues(dataGrid).ID; //the ID of the modified row
                _pwTracker.EditEntry(pwValues);
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

        public UserAccount GetLoggedInUser(int currentUser)
        {
            return _userAccount.GetRecords().FirstOrDefault(p => p.UserId == currentUser);
        }

        private void SetCurrentCell(DataGridView dataGrid, int rowId)
        {
            int index = (dataGrid.Rows.Cast<DataGridViewRow>()
                .Where(r => r.Cells[0].Value.ToString() == rowId.ToString())
                .Select(r => r.Index)).FirstOrDefault();
            dataGrid.CurrentCell = dataGrid.Rows[index].Cells["Name"];
        }

        public int CreateNewUserAccount(LoginUser userData)
        {
            //check if user is in the database
            var accRec = GetAccountUser(userData);
            AccountUserId = _userAccount.InsertNewRecord(accRec);
            _password = userData.Password;
            return AccountUserId;
        }

        private static UserAccount GetAccountUser(LoginUser userData)
        {
            var accRec = new UserAccount
            {
                Username = userData.Username,
                Password = userData.Password,
                FirstName = userData.FirstName,
                LastName = userData.LastName,
                Pin = userData.Pin.ToString()
            };
            return accRec;
        }

        public void AddNewPassword(int userId, DataGridView dataGrid, PasswordTracker pw)
        {
            if (string.IsNullOrEmpty(pw.Name) ||
                string.IsNullOrEmpty(pw.Username) ||
                string.IsNullOrEmpty(pw.Password)) throw new Exception("Required field(s) not filled out!");
            _pwTracker.InsertNewRecord(pw);
            MessageBox.Show(@"Record successfully added!", @"Record Added");
            //_entry.ResetEntryForm();
            LoadDataGrid(dataGrid, false);
        }

        public int EditUserAccountData(LoginUser credentials)
        {
            var accRec = GetAccountUser(credentials);
            AccountUserId = _userAccount.EditEntry(accRec).UserId;
            _password = credentials.Password;
            return AccountUserId;
        }

        public string PushPasswordsToFile(Display display, ITextFileReadWriter textFile)
        {
            var filename = SaveTextFile();
            return textFile.ZipPasswordsAndPlaceInFile(this.AccountUserId, filename);
        }

        private string SaveTextFile()
        {
            SaveFileDialog fileDialog = new SaveFileDialog { Title = @"Save Text File" };
            return fileDialog.ShowDialog() == DialogResult.OK ? fileDialog.FileName : string.Empty;
        }

        public void SetPictureBoxImage(PictureBox picture, string imageFile)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                picture.Image = string.IsNullOrEmpty(imageFile) 
                ? Properties.Resources.avatar 
                : Image.FromFile(@imageFile);
            }
            catch (Exception)
            {
                MessageBox.Show("Your image was not found. Try a different file " +Environment.NewLine +
                "location using the Select Image button.", "Image Not Found", 
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                picture.Image = Properties.Resources.avatar;
            }
            finally
            {
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
                Cursor.Current = Cursors.Default;
            }
        }

        public void SetEmailAccount(string emailAddress, IModelAdapter<EmailAccount> emailAccount)
        {
            var email = emailAccount.GetRecordById(emailAccount.Id);
            if (email == null)
            {
                email = new EmailAccount()
                {
                    Email = emailAddress,
                    UserId = emailAccount.Id
                };
                emailAccount.InsertNewRecord(email);
            }
            else
            {
                emailAccount.EditEntry(email);
            }   
        }

        public string GetPhotoLocationFromFile(IModelAdapter<EmailAccount> emailAccount, int userId)
        {
            try
            {
                var fileName = GetTextFile();
                if (!File.Exists(fileName)) return DefaultFile;
                var email = emailAccount.GetRecordById(userId);
                email.PhotoLocation = fileName;
                emailAccount.EditEntry(email);
                return fileName;
            }
            catch (Exception)
            {
                MessageBox.Show("Help!");
                return null;
            }
            
        }

        public void GetPasswordFromFile(Display display, ITextFileReadWriter text, DataGridView dvGrid)
        {
            var filename = GetTextFile();
            if (!File.Exists(filename)) return;
            text.AddPasswordFileToRepository(filename, AccountUserId);
            LoadDataGrid(dvGrid, false);
        }

        private string GetTextFile()
        {
            OpenFileDialog fileDialog = new OpenFileDialog { Title = @"Open Text File" };
            return fileDialog.ShowDialog() == DialogResult.OK ? fileDialog.FileName : string.Empty;
        }
    }
}
