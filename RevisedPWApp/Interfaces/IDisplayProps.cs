using System.Collections.Generic;
using System.Windows.Forms;
using RevisedPWApp.Models;
using Model.Lib;

namespace RevisedPWApp.Interfaces
{
    public interface IDisplayProps
    {
        int AccountUserId { get; set; }
        int LoginUser(string user, string password);
        void LogoutUser(DataGridView grid);
        UserAccount GetLoggedInUser(int currentUser);
        void ClearFormData(Form form, DataGridView grid);
        void LoadDataGrid(DataGridView dataGrid, bool isLoggedOut, List<PasswordTracker> pList = null);
        void DeletePassword(DataGridView dataGrid);
        void EditPassword(int userId, DataGridView dataGrid, PasswordTracker pwValues);
        int CreateNewUserAccount(LoginUser userData);
        void AddNewPassword(int userId, DataGridView dataGrid, PasswordTracker pw);
        int EditUserAccountData(LoginUser credentials);
        string PushPasswordsToFile(Display display, ITextFileReadWriter textFile);
        string GetPasswordFromFile(Display display, ITextFileReadWriter text, DataGridView grid);
        string GetPhotoLocationFromFile(IModelAdapter<EmailAccount> emailAccount, int userId);
        void SetPictureBoxImage(PictureBox picture, string imageFile);
    }
}
