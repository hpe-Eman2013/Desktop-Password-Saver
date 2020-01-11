using System;
using System.Windows.Forms;
using Ninject;
using RevisedPWApp.Interfaces;
using RevisedPWApp.Models;
using EncryptDecryptPassword;
using FileZipperAndExtractor;
using Model.Lib;

namespace RevisedPWApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            NinjectConfig.CreateKernel();
            var kernel = NinjectConfig.Kernel;
            
            IPasswordEncryption encryption = kernel.Get<IPasswordEncryption>();
            IZipEncrypt zipper = kernel.Get<IZipEncrypt>();
            IModelAdapter<EmailAccount> email = kernel.Get<IModelAdapter<EmailAccount>>();
            IModelAdapter<UserAccount> userAccount = 
                kernel.Get<IModelAdapter<UserAccount>>();
            IModelAdapter<PasswordTracker> pwTracker =
                kernel.Get<IModelAdapter<PasswordTracker>>();
            ITextFileReadWriter reader = kernel.Get<ITextFileReadWriter>();
            IDisplayProps props = kernel.Get<IDisplayProps>();
            ISubscriberTracker tracker = kernel.Get<ISubscriberTracker>();
            tracker.Subscribe(email);
            tracker.Subscribe(pwTracker);
            Application.Run(new Display(props, encryption, zipper, email, userAccount, pwTracker, reader, tracker));
        }
    }
}
