using System;
using System.Windows.Forms;
using Ninject;
using PasswordCore.Interfaces;
using PasswordCore.Repositories;
using RevisedPWApp.Interfaces;
using RevisedPWApp.Models;

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
            IDisplayProps props = kernel.Get<IDisplayProps>();
            IDbConnector connector = kernel.Get<IDbConnector>();
            IPasswordRepository repo = kernel.Get<IPasswordRepository>();
            ITextFile textFile = kernel.Get<ITextFile>();
            IEmailAccountRepository emailAccount = kernel.Get<IEmailAccountRepository>();
            Application.Run(new Display(props, connector, repo, textFile, emailAccount));
        }
    }
}
