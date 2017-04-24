using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace FelohWatchDogService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
            if (!System.Diagnostics.EventLog.SourceExists("WatchDogSource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "WatchDogSource", "WatchDogLog");
            }
            eventLog1.Source = "WatchDogSource";
            eventLog1.Log = "WatchDogLog";
        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("In OnStart");
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("In onStop.");
        }

        protected override void OnContinue()
        {
            //eventLog1.WriteEntry("In OnContinue.");
        }
    }
}
