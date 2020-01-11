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
                    _pwTracker.Id = _pwTracker.Id == 0 ? AccountUserId : _pwTracker.Id;
                    dataGrid.DataSource = pList ?? _pwTracker.GetRecords();
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
        
        private static UserAccount GetAccountUser(UserAccount userData)
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

        public string GetPasswordFromFile(Display display, ITextFileReadWriter text, DataGridView dvGrid)
        {
            var filename = GetTextFile();
            if (!File.Exists(filename)) return string.Empty;
            text.AddPasswordFileToRepository(filename);
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
