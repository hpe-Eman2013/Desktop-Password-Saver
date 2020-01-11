using System;
using System.Linq;
using System.Windows.Forms;
using RevisedPWApp.Interfaces;
using Model.Lib;
using EncryptDecryptPassword;
using FileZipperAndExtractor;

namespace RevisedPWApp
{
    public partial class Display : Form
    {
        private readonly Login _loginForm;
        private int recordId;
        private readonly IDisplayProps _props;
        private readonly IModelAdapter<PasswordTracker> _pwTracker;
        private readonly IModelAdapter<EmailAccount> _email;
        private readonly IModelAdapter<UserAccount> _userAccount;
        private IPasswordEncryption _encryptDecrypt;
        private IZipEncrypt _zipper;
        private ITextFileReadWriter _readerWriter;
        private ISubscriberTracker _subscriber;
        public Display()
        {
            InitializeComponent();
        }

        public Display(IDisplayProps props, IPasswordEncryption encryption, 
           IZipEncrypt zipper, IModelAdapter<EmailAccount> email, 
           IModelAdapter<UserAccount> userAccount, 
           IModelAdapter<PasswordTracker> pwTracker, 
           ITextFileReadWriter readerWriter, ISubscriberTracker tracker) : this()
        {
            _props = props;
            _pwTracker = pwTracker;
            _email = email;
            _userAccount = userAccount;
            _zipper = zipper;
            _encryptDecrypt = encryption;
            _readerWriter = readerWriter;
            _subscriber = tracker;
            _loginForm = new Login(_props, userAccount);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _subscriber.Subscribe(_props);
            _loginForm.ShowDialog();
            if (_loginForm.UserAccountId == 0) return;//user is not present
            _props.LoadDataGrid(dv, false);
            var imageLocation = _email.GetRecordById(_loginForm.UserAccountId);
            if (string.IsNullOrEmpty(imageLocation.PhotoLocation)) return;
            _props.SetPictureBoxImage(pbAvatar, imageLocation.PhotoLocation);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            _props.ClearFormData(this, dv);
            _userAccount.Id = 0;
            _props.SetPictureBoxImage(pbAvatar, "");
            _props.LoadDataGrid(dv, true);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _props.ClearFormData(this, dv);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPushFile_Click(object sender, EventArgs e)
        {
            txtPushFile.Text = _props.PushPasswordsToFile(this, _readerWriter);
        }

        private void btnGetFile_Click(object sender, EventArgs e)
        {
            txtRetrieveFile.Text = _props.GetPasswordFromFile(this, _readerWriter, dv);
        }

        private void chkUnmask_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkUnmask.Checked ? '\0' : '*';
        }

        private PasswordTracker GetPasswordValues()
        {
            var pw = new PasswordTracker()
            {
                ID = recordId,
                Name = txtName.Text,
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                Description = txtDesc.Text,
                ApplicationPath = txtAppPath.Text,
                SpecialNotes = txtSpecialNotes.Text,
                DateCreated = txtDateCreated.Text == string.Empty ?
                    DateTime.Now : Convert.ToDateTime(txtDateCreated.Text),
                DateModified = txtDateModified.Text == string.Empty ?
                    DateTime.Now : Convert.ToDateTime(txtDateModified.Text),
                UserId = _props.AccountUserId
            };
            return pw;
        }


        private void gpEight_Click(object sender, EventArgs e)
        {
            txtPassword.Text = _encryptDecrypt.GetRandomAsciiString(PasswordStrength.Normal);
        }

        private void gpTen_Click(object sender, EventArgs e)
        {
            txtPassword.Text = _encryptDecrypt.GetRandomAsciiString(PasswordStrength.Strong);
        }

        private void gpFifteen_Click(object sender, EventArgs e)
        {
            txtPassword.Text = _encryptDecrypt.GetRandomAsciiString(PasswordStrength.VeryStrong);
        }

        private void cboSelectAction_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (cboSelectAction.SelectedIndex)
            {
                case 0: // add new
                    if (_loginForm.UserAccountId < 1)
                        throw new Exception("Login is required!");
                    else
                    {
                        _pwTracker.InsertNewRecord(GetPasswordValues());
                        break;
                    }
                case 1: // edit
                    _pwTracker.EditEntry(GetPasswordValues());
                    break;
                case 2: // delete
                    var id = (int)dv.Rows[dv.CurrentCell.RowIndex].Cells["Id"].Value;
                    _pwTracker.DeleteEntry(id);
                    break;
            }
            ClearSelection();
        }

        private void ClearSelection()
        {
            _props.ClearFormData(this, dv);
            cboSelectAction.SelectedIndex = -1;
        }

        private void dv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dv.CurrentCell.RowIndex == -1) return;
            var currentRow = dv.CurrentCell.RowIndex;
            recordId = (int) dv.Rows[currentRow].Cells["ID"].Value;
            txtName.Text = dv.Rows[currentRow].Cells["Name"].Value.ToString();
            txtUsername.Text = dv.Rows[currentRow].Cells["Username"].Value.ToString();
            txtPassword.Text = dv.Rows[currentRow].Cells["Password"].Value.ToString();
            txtDesc.Text = dv.Rows[currentRow].Cells["Description"].Value.ToString();
            txtAppPath.Text = dv.Rows[currentRow].Cells["ApplicationPath"].Value.ToString();
            txtSpecialNotes.Text = dv.Rows[currentRow].Cells["SpecialNotes"].Value.ToString();
            txtDateCreated.Text = dv.Rows[currentRow].Cells["DateCreated"].Value.ToString();
            txtDateModified.Text = dv.Rows[currentRow].Cells["DateModified"].Value.ToString();
            _props.AccountUserId = Convert.ToInt32(dv.Rows[currentRow].Cells["UserId"].Value.ToString());
        }

        private void txtSearchList_TextChanged(object sender, EventArgs e)
        {
            if (_loginForm.UserAccountId <= 0) return;
            //getting data from a datagridview
            //var result = dv.Rows.OfType<DataGridViewRow>().Select(
            //    r => r.Cells.OfType<DataGridViewCell>().Select(c => c.Value).ToArray()).ToList();
            var result = _pwTracker.GetRecords();
            var selection = result.Where(x => x.Name.ToUpper().StartsWith(txtSearchList.Text.ToUpper()))
                .ToList();
            _props.LoadDataGrid(dv, false, selection);
        }

        private void btnPhoto_Click(object sender, EventArgs e)
        {
            var filename = _props.GetPhotoLocationFromFile(_email, _props.AccountUserId);
            _props.SetPictureBoxImage(pbAvatar, filename);
        }
    }
}
