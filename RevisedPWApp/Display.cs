using System;
using System.Linq;
using System.Windows.Forms;
using PasswordCore.Enums;
using PasswordCore.Interfaces;
using PasswordCore.Model;
using PasswordCore.Repositories;
using RevisedPWApp.Interfaces;

namespace RevisedPWApp
{
    public partial class Display : Form
    {
        private readonly Login _loginForm;
        private readonly IDisplayProps _props;
        private readonly IPasswordRepository _passwordRepository;
        private readonly ITextFile _text;
        private readonly IEmailAccountRepository _email;
        public Display()
        {
            InitializeComponent();
        }

        public Display(IDisplayProps props, IDbConnector connect,
            IPasswordRepository repository, ITextFile textFile,
            IEmailAccountRepository email) : this()
        {
            _props = props;
            _passwordRepository = repository;
            _text = textFile;
            _email = email;
            _loginForm = new Login(_props, connect);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _loginForm.ShowDialog();
            if (_props.AccountUserId == 0) return;
            _props.LoadDataGrid(dv, false);
            var imageLocation = _email.GetRecordById(_props.AccountUserId);
            if (string.IsNullOrEmpty(imageLocation.PhotoLocation)) return;
            _props.SetPictureBoxImage(pbAvatar, imageLocation.PhotoLocation);
        }

        

        private void btnLogout_Click(object sender, EventArgs e)
        {
            _props.ClearFormData(this, dv);
            _props.AccountUserId = 0;
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
            txtPushFile.Text = _props.PushPasswordsToFile(this, _text);
        }

        private void btnGetFile_Click(object sender, EventArgs e)
        {
            txtRetrieveFile.Text = _props.GetPasswordFromFile(this, _text, dv);
        }

        private void chkUnmask_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkUnmask.Checked ? '\0' : '*';
        }

        private Passwords GetPasswordValues()
        {
            var pw = new Passwords()
            {
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
            txtPassword.Text = _passwordRepository.GetRandomPassword(PasswordStrength.Normal);
        }

        private void gpTen_Click(object sender, EventArgs e)
        {
            txtPassword.Text = _passwordRepository.GetRandomPassword(PasswordStrength.Strong);
        }

        private void gpFifteen_Click(object sender, EventArgs e)
        {
            txtPassword.Text = _passwordRepository.GetRandomPassword(PasswordStrength.VeryStrong);
        }

        private void cboSelectAction_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (cboSelectAction.SelectedIndex)
            {
                case 0: // add new
                    if (_props.AccountUserId < 1)
                        throw new Exception("Login is required!");
                    else
                    {
                        _props.AddNewPassword(_props.AccountUserId, dv, GetPasswordValues());
                        break;
                    }
                case 1: // edit
                    _props.EditPassword(_props.AccountUserId, dv, GetPasswordValues());
                    break;
                case 2: // delete
                    _props.DeletePassword(dv);
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
            if (_props.AccountUserId <= 0) return;
            //getting data from a datagridview
            //var result = dv.Rows.OfType<DataGridViewRow>().Select(
            //    r => r.Cells.OfType<DataGridViewCell>().Select(c => c.Value).ToArray()).ToList();
            _passwordRepository.UserId = _props.AccountUserId;
            var result = _passwordRepository.GetRecords();
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
