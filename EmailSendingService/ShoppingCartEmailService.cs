using System;
using System.Collections.Generic;

using System.Text;
using System.ComponentModel;
using System.ServiceProcess;
using System.Configuration.Install;


namespace EmailSendingService
{

    [RunInstaller(true)]
    class ShoppingCartEmailService : Installer
    {
        private ServiceProcessInstaller  processInstaller;
        private ServiceInstaller serviceInstaller;
        
        public ShoppingCartEmailService()
        {
            processInstaller = new ServiceProcessInstaller();
            serviceInstaller = new ServiceInstaller();
            processInstaller.Account = ServiceAccount.LocalSystem;
            serviceInstaller.StartType = ServiceStartMode.Manual;
            serviceInstaller.ServiceName = "ShoppingCartEmailService";

            Installers.Add(serviceInstaller);
            Installers.Add(processInstaller);
        }
    }
}
