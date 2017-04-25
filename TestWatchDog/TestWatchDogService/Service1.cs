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
using System.IO;
using System.Reflection;
using System.Timers;
using System.Threading;

namespace TestWatchDogService
{
    public partial class TestWatchDogService : ServiceBase
    {
        string WatchPath1 = ConfigurationManager.AppSettings["WatchPath1"];
        string WatchPath2 = ConfigurationManager.AppSettings["WatchPath2"];

        private static DateTime lastfilefound = DateTime.Now;
        private static System.Timers.Timer checkFileTimer;
        public TestWatchDogService()
        {
            InitializeComponent();

            checkFileTimer = new System.Timers.Timer(30000);

            if (!System.Diagnostics.EventLog.SourceExists("TestSource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "TestSource", "TestLog");
            }
            eventLog1.Source = "TestSource";
            eventLog1.Log = "TestLog";

            //fileSystemWatcher1.Created += fileSystemWatcher1_Created;
            fileSystemWatcher1.Changed += fileSystemWatcher1_Changed;
            fileSystemWatcher1.Created += fileSystemWatcher1_Changed;
            fileSystemWatcher1.Deleted += fileSystemWatcher1_Changed;
            fileSystemWatcher1.Renamed += fileSystemWatcher1_Renamed;

            checkFileTimer.Elapsed += new ElapsedEventHandler(checkFiles);
        }

        private static void checkFiles(object source, ElapsedEventArgs e)
        {
            System.IO.File.Create("C:\\test\\checkfiles.txt");
            if (DateTime.Now - lastfilefound > TimeSpan.FromMinutes(1) )
            {
                System.IO.File.Create("C:\\test\\test.txt");
            }
        }
        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("Watch Dog test start 4/25 #1");
            try
            {
                fileSystemWatcher1.Path = WatchPath1;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("Watch Dog test OnStop");
        }

        protected override void OnContinue()
        {
            eventLog1.WriteEntry("watch dog In OnContinue.");
        }


        void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            try
            {
                eventLog1.WriteEntry("File system has changed");
                lastfilefound = DateTime.Now;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        void fileSystemWatcher1_Renamed(object sender, System.IO.RenamedEventArgs e)
        {
            try
            {
                eventLog1.WriteEntry("File name has changed");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
