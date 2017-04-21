namespace FelohWatchDog
{
    partial class FelohWatchDog
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
            this.fileSystemWatcher1.IncludeSubdirectories = true;
            this.fileSystemWatcher1.NotifyFilter = ((System.IO.NotifyFilters)((((((((System.IO.NotifyFilters.FileName | System.IO.NotifyFilters.DirectoryName)
                | System.IO.NotifyFilters.Attributes)
                | System.IO.NotifyFilters.Size)
                | System.IO.NotifyFilters.LastWrite)
                | System.IO.NotifyFilters.LastAccess)
                | System.IO.NotifyFilters.CreationTime)
                | System.IO.NotifyFilters.Security)));
           
            // 
            // FelohWatchDog
            // 
            this.ServiceName = "FelohWatchDog";
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();

        }

        #endregion
        
        /* DEFINE WATCHER EVENTS... */
   
     
        /// <summary>
        /// Event occurs when the a File or Directory is created
        /// </summary>
        private void fileSystemWatcher1_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            eventLog1.Log = "file created";
        }
     
        /// <summary>
        /// Event occurs when the a File or Directory is deleted
        /// </summary>
        private void fileSystemWatcher1_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {
            //code here for newly deleted file or directory            
        }
     
        /// <summary>
        /// Event occurs when the a File or Directory is renamed
        /// </summary>
        private void fileSystemWatcher1_Renamed(object sender, System.IO.RenamedEventArgs e)
        {
            //code here for newly renamed file or directory
        }
        
        private System.Diagnostics.EventLog eventLog1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}
