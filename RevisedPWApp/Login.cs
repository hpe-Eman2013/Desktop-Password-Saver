using RevisedPWApp.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PasswordCore.Interfaces;

namespace RevisedPWApp
{
    public partial class Login : Form
    {
        private readonly IDisplayProps _props;
        private readonly IDbConnector _connect;
        public Login()
        {
            InitializeComponent();
        }

        public Login(IDisplayProps props, IDbConnector connector) : this()
        {
            _props = props;
            _connect = connector;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //LoggingOut = false;
            LoginUserFromForm();
            Cursor.Current = Cursors.Default;
        }
        private void LoginUserFromForm()
        {
            try
            {
                switch (_connect.ConfigDictionary.Where(v => v.Value == btnLogin.Text).Select(x => x.Value).FirstOrDefault())
                {
                    case "Add User":
                        _props.CreateNewUserAccount(CredentialsInitializer());
                        if (_props.AccountUserId == 0) throw new Exception("Error creating user!");
                        break;
                    case "Edit User":
                        _props.EditUserAccountData(CredentialsInitializer());
                        if (_props.AccountUserId == 0) throw new Exception("Error editing user!");
                        break;
                    case "Login":
                        _props.LoginUser(txtUsername.Text, txtPassword.Text);
                        if (_props.AccountUserId == 0) throw new Exception("Invalid login!");
                        break;
                    default:
                        throw new Exception("Error in LoginUserFromForm");
                }
                Close();
            }
            catch (Exception exception)
            {
                //ClearLogin();
                MessageBox.Show(exception.Message, @"Invalid Entry Detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private List<string> CredentialsInitializer()
        {
            if (txtPin.TextLength < 4)
                throw new Exception("The Pin must be greater than 4 digits");
            if (!System.Text.RegularExpressions
                .Regex.IsMatch(txtPin.Text, "^[0-9]+$"))
                throw new Exception("Only digits [0 - 9] may be used!");
            var accList = new List<string> { txtUsername.Text,txtPassword.Text,
                txtFirstname.Text, txtLastname.Text, txtPin.Text
            };
            var credentials = accList.Any(string.IsNullOrEmpty) ? null : accList;
            if (credentials == null) throw new IOException("Error in CredentialsInitializer");
            return credentials;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            FormSetup(false, false);
        }

        private void FormSetup(bool isEditing, bool isAdding)
        {
            MakeControlsVisible();
            if (isAdding)
            {
                CreateNewUser();
            }
            else if (isEditing)
            {
                EditExistingUser();
            }
            else
            {
                HideControls();
                LoginTitle.Text = _connect.ConfigDictionary.FirstOrDefault(x => x.Key.Contains("loginUserTitle")).Value;
                btnLogin.Text = _connect.ConfigDictionary.FirstOrDefault(x => x.Key.Contains("loginUser")).Value;
            }
            txtUsername.Select();
        }

        private void HideControls()
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox || control is Label)
                {
                    if (control.Name.Contains("User") || control.Name.Contains("Password") || control.Name.Contains("Title"))
                    {
                        control.Visible = true;
                    }
                    else
                    {
                        control.Visible = false;
                    }
                }
            }
        }
        private void EditExistingUser()
        {
            LoginTitle.Text = _connect.ConfigDictionary.FirstOrDefault(x => x.Key.Contains("editUserTitle")).Value;
            btnLogin.Text = _connect.ConfigDictionary.FirstOrDefault(x => x.Key.Contains("editUser")).Value;
        }

        private void CreateNewUser()
        {
            LoginTitle.Text = _connect.ConfigDictionary.FirstOrDefault(x => x.Key.Contains("addUserTitle")).Value;
            btnLogin.Text = _connect.ConfigDictionary.FirstOrDefault(x => x.Key.Contains("addUser")).Value;
        }

        private void MakeControlsVisible()
        {
            foreach (Control control in Controls)
            {
                control.Visible = true;
                if (control is TextBox) control.Text = "";
            }
        }

        private void lnkCreateUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormSetup(false, true);
        }

        private void lnkEditUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormSetup(true, false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            txtPassword.Text = txtPassword.Text.Replace("\r\n", "");
            btnLogin_Click(sender, e);
        }

        private void btnLogin_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
    }
}
