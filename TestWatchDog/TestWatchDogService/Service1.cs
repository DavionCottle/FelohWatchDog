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
        public static string watchpath = ConfigurationManager.AppSettings["WatchPath1"];
        string WatchPath2 = ConfigurationManager.AppSettings["WatchPath2"];

        public static DateTime lastfilefound = DateTime.Now;
        
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
           
            DateTime fileread = DateTime.Parse(File.ReadAllText(ConfigurationManager.AppSettings["InOutReadFile"]));
            
            if (DateTime.Now - fileread > TimeSpan.FromMinutes(Double.Parse( ConfigurationManager.AppSettings["FelohDownTime"])))
            {
                lastfilefound = DateTime.Now;
                checkforfilesTimer.Stop();
                FileStream filepath = new FileStream(ConfigurationManager.AppSettings["InOutReadFile"], FileMode.OpenOrCreate);
                filepath.Close();

                Process[] procToKill = Process.GetProcessesByName(ConfigurationManager.AppSettings["Felohproc"]);

                foreach (Process p in procToKill)
                {
                    p.Kill();
                }

                Process.Start(ConfigurationManager.AppSettings["Felohexe"]);
                checkforfilesTimer.Start();
            }
        }

        public void startmethod ()
        {
            eventLog1.WriteEntry("Watch Dog test start 4/26 #1");

            using (System.IO.StreamWriter filepath = new StreamWriter(ConfigurationManager.AppSettings["InOutReadFile"]))
            {
                filepath.WriteLine(lastfilefound.ToString());
            }

            fileSystemWatcher1.Path = watchpath;
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
                using (System.IO.StreamWriter filepath = new StreamWriter(ConfigurationManager.AppSettings["InOutReadFile"]))
                {
                    filepath.WriteLine(lastfilefound.ToString());
                }
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
