using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;
using System.IO;
using System.ServiceProcess;
using System.Management;

namespace deployservice
{
    [RunInstaller(true)]
    public partial class Service1 : ServiceBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Thread Worker = null;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            this.Working();
        }
        public void Working()
        {

            ServiceController[] scServices;
            scServices = ServiceController.GetServices();
            Console.WriteLine("Services running on the local computer:");
                foreach (ServiceController scTemp in scServices)
                {

                       
                        log.InfoFormat("  Service :        {0}", scTemp.ServiceName);
                        log.InfoFormat("    Display name:    {0}", scTemp.DisplayName);

                        ManagementObject wmiService;
                        wmiService = new ManagementObject("Win32_Service.Name='" + scTemp.ServiceName + "'");
                        wmiService.Get();
                        log.InfoFormat("    Start name:      {0}", wmiService["StartName"]);
                        log.InfoFormat("    Description:     {0}", wmiService["Description"]);
                }
        }
        protected override void OnStop()
        {
      
        }

        public void onDebug()
        {
            OnStart(null);
        }
    }
}
