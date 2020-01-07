using RevisedPWApp.Interfaces;
using System;
using System.Windows.Forms;
using Model.Lib;

namespace RevisedPWApp
{
    public partial class Login : Form
    {
        private readonly IDisplayProps _props;
        private string choice;
        private IModelAdapter<UserAccount> userAccount;
        public int UserAccountId { get; set; }
        public Login()
        {
            InitializeComponent();
        }

        public Login(IDisplayProps props, IModelAdapter<UserAccount> userAdapter) : this()
        {
            _props = props;
            userAccount = userAdapter;
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
                switch (choice)
                {
                    case "Add":
                        UserAccountId = userAccount.InsertNewRecord(CredentialsInitializer());
                        if (UserAccountId == 0) throw new Exception("Error creating user!");
                        break;
                    case "Edit":
                        UserAccountId = userAccount.EditEntry(CredentialsInitializer()).UserId;
                        if (UserAccountId == 0) throw new Exception("Error editing user!");
                        break;
                    default:
                        var user = userAccount.GetRecordByCredentials(txtUsername.Text, txtPassword.Text);
                        if (user == null) throw new Exception("Invalid login!");
                        UserAccountId = user.UserId;
                        break;
                }
                Close();
            }
            catch (Exception exception)
            {
                //ClearLogin();
                MessageBox.Show(exception.Message, @"Invalid Entry Detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private UserAccount CredentialsInitializer()
        {
            if (txtPin.TextLength < 4)
                throw new Exception("The Pin must be greater than 4 digits");
            if (!System.Text.RegularExpressions
                .Regex.IsMatch(txtPin.Text, "^[0-9]+$"))
                throw new Exception("Only digits [0 - 9] may be used!");
            var accUser = new UserAccount
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                FirstName = txtFirstname.Text,
                LastName = txtLastname.Text,
                Pin = txtPin.Text
            };
            return accUser;
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
                LoginTitle.Text = "Login User";
                btnLogin.Text = "Login";
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
            LoginTitle.Text = "Edit User";
            btnLogin.Text = "Edit";
        }

        private void CreateNewUser()
        {
            LoginTitle.Text = "Add User";
            btnLogin.Text = "Add";
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
            choice = "Add";
        }

        private void lnkEditUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormSetup(true, false);
            choice = "Edit";
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
