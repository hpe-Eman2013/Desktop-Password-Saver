using System.Collections.Generic;
using System.Windows.Forms;
using PasswordCore.Model;
using PasswordCore.Interfaces;
using PasswordCore.Repositories;
using RevisedPWApp.Models;

namespace RevisedPWApp.Interfaces
{
    public interface IDisplayProps
    {
        int AccountUserId { get; set; }
        int LoginUser(string user, string password);
        void LogoutUser(DataGridView grid);
        AccountUser GetLoggedInUser(int currentUser);
        void ClearFormData(Form form, DataGridView grid);
        void LoadDataGrid(DataGridView dataGrid, bool isLoggedOut, List<Passwords> pList = null);
        void DeletePassword(DataGridView dataGrid);
        void EditPassword(int userId, DataGridView dataGrid, Passwords pwValues);
        int CreateNewUserAccount(LoginUser userData);
        void AddNewPassword(int userId, DataGridView dataGrid, Passwords pw);
        int EditUserAccountData(LoginUser credentials);
        string PushPasswordsToFile(Display display, ITextFile text);
        string GetPasswordFromFile(Display display, ITextFile text, DataGridView grid);
        string GetPhotoLocationFromFile(IEmailAccountRepository emailAccount, int userId);
        void SetPictureBoxImage(PictureBox picture, string imageFile);
    }
}
