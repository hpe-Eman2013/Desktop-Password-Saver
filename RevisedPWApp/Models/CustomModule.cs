﻿using Ninject.Modules;
using RevisedPWApp.Interfaces;
using Model.Lib;
using FileZipperAndExtractor;
using EncryptDecryptPassword;

namespace RevisedPWApp.Models
{
    public class CustomModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IZipEncrypt>().To<ZipEncrypt>();
            Bind<ISubscriberTracker>().To<SubscriberTracker>();
            Bind<IModelAdapter<EmailAccount>>().To<SQLServerEmailAccount>();
            Bind<IModelAdapter<UserAccount>>().To<SQLServerUserAccount>();
            Bind<IModelAdapter<PasswordTracker>>().To<SQLServerPasswordAccount>();
            Bind<IPasswordEncryption>().To<PasswordEncryption>();
            Bind<ITextFileReadWriter>().To<SQLServerPasswordStorage>();
            Bind<IDisplayProps>().To<PasswordDisplayProps>();
        }
    }
}
