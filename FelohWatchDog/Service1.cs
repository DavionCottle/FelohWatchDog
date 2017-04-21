using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace FelohWatchDog
{
    public partial class FelohWatchDog : ServiceBase
    {
        public FelohWatchDog()
        {
            InitializeComponent();
            
            if (!System.Diagnostics.EventLog.SourceExists("FelohWatchDogService"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "FelohWatchDogService", "FelohWatchDogOutputLog");
            }
            eventLog1.Source = "FelohWatchDogService";
            eventLog1.Log = "FelohWatchDogOutputLog";

        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("In OnStart");

            fileSystemWatcher1.Path = "C:\test";
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("In onStop.");
        }
    }
}
