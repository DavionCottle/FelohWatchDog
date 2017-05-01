
using System.Configuration;
namespace TestWatchDogService
{
    partial class TestWatchDogService
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            // 
            // TestWatchDogService
            // 
            this.ServiceName = "TestWatchDogService";
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
          
            checkforfilesTimer = new System.Timers.Timer(double.Parse(ConfigurationManager.AppSettings["FelohCheckTime"]));
            checkforfilesTimer.Elapsed += new System.Timers.ElapsedEventHandler(checkFiles);
            checkforfilesTimer.Enabled = true;
        }




        #endregion
        private static System.Timers.Timer checkforfilesTimer;
        private System.Diagnostics.EventLog eventLog1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}
