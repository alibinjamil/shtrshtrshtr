using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace EmailService
{
    [RunInstaller(true)]
    public class EmailServiceInstaller : Installer
    {
        /// <summary>

        /// Public Constructor for WindowsServiceInstaller.

        /// - Put all of your Initialization code here.

        /// </summary>

        public EmailServiceInstaller()
        {
            ServiceProcessInstaller serviceProcessInstaller =
                               new ServiceProcessInstaller();
            ServiceInstaller serviceInstaller = new ServiceInstaller();

            //# Service Account Information

            serviceProcessInstaller.Account = ServiceAccount.LocalSystem;
            serviceProcessInstaller.Username = null;
            serviceProcessInstaller.Password = null;

            //# Service Information

            serviceInstaller.DisplayName = "Email Service";
            serviceInstaller.StartType = ServiceStartMode.Automatic;

            //# This must be identical to the WindowsService.ServiceBase name

            //# set in the constructor of WindowsService.cs

            serviceInstaller.ServiceName = "Email Service";

            this.Installers.Add(serviceProcessInstaller);
            this.Installers.Add(serviceInstaller);
        }
    }
}