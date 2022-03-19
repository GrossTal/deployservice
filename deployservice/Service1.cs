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
        //int ScheduleTime = Convert.ToInt32(ConfigurationSettings.AppSettings["ThreadTime"]);
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Thread Worker = null;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //ThreadStart start = new ThreadStart(Working);
            //Worker = new Thread(start);
            //Worker.Start();
            this.Working();
        }
        public void Working()
        {

            ServiceController[] scServices;
            scServices = ServiceController.GetServices();

            // Display the list of services currently running on this computer.
           // string path = "C:\\sample1.txt";
              //using (StreamWriter writer = new StreamWriter(path, true))
             // {
            Console.WriteLine("Services running on the local computer:");
                foreach (ServiceController scTemp in scServices)
                {
                    //if (scTemp.Status == ServiceControllerStatus.)
                  //  {
                        // Write the service name and the display name
                        // for each running service.
                       // writer.WriteLine();
                       
                        log.InfoFormat("  Service :        {0}", scTemp.ServiceName);
                        log.InfoFormat("    Display name:    {0}", scTemp.DisplayName);

                        // Query WMI for additional information about this service.
                        // Display the start name (LocalSystem, etc) and the service
                        // description.
                        ManagementObject wmiService;
                        wmiService = new ManagementObject("Win32_Service.Name='" + scTemp.ServiceName + "'");
                        wmiService.Get();
                        log.InfoFormat("    Start name:      {0}", wmiService["StartName"]);
                        log.InfoFormat("    Description:     {0}", wmiService["Description"]);
                    //}
                }
            //}
            //int Counter= 0;
            //while (true)
            //{
            //    string path = "C:\\sample.txt";
            //    using (StreamWriter writer = new StreamWriter(path, true))
            //    {
            //        writer.WriteLine(string.Format("hello num " + Counter.ToString()));
            //        writer.Close();
            //        Counter++;
            //    }
            //    Thread.Sleep(ScheduleTime*60*1000);
            //}
        }
        protected override void OnStop()
        {
      
            //if((Worker!=null) & Worker.IsAlive)
            //{
            //    Worker.Abort();
            //}
        }

        public void onDebug()
        {
            OnStart(null);
        }
    }
}
