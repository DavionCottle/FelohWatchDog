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
        
        public TestWatchDogService()
        {
            InitializeComponent();

            

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

            
        }

        private static void checkFiles(object source, ElapsedEventArgs e)
        {
            
            if (DateTime.Now - lastfilefound > TimeSpan.FromMinutes(.5) )
            {
                lastfilefound = DateTime.Now;
                checkforfilesTimer.Stop();
                FileStream filepath = new FileStream("C:\\test\\checkfilesTimer.txt", FileMode.OpenOrCreate);
                filepath.Close();

                Process[] procToKill = Process.GetProcessesByName("WINWORD");

                foreach (Process p in procToKill)
                {
                    p.Kill();
                }

                Process.Start(@"C:\Program Files (x86)\Microsoft Office\root\Office16\WINWORD.EXE");
                checkforfilesTimer.Start();
            }
        }

        public void startmethod ()
        {
            eventLog1.WriteEntry("Watch Dog test start 4/26 #1");
            fileSystemWatcher1.Path = WatchPath1;
            System.Diagnostics.Debugger.Launch();

        }
        protected override void OnStart(string[] args)
        {
            try
            {
                startmethod();
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
