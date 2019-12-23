using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Permissions;
using Newtonsoft.Json;



namespace _05_01
{
    class Watcher
    {

        static public Dictionary<DateTime, FileChangeInfo> BackupList = new Dictionary<DateTime, FileChangeInfo>();

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public static void Run(object pathStart)
        {
            string path = (string)pathStart;
            if (path == null || path == "")
            {
                Console.WriteLine("Use correct directory");
                return;
            }

            // Create a new FileSystemWatcher and set its properties.
            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = path;
                watcher.IncludeSubdirectories = true;

                watcher.NotifyFilter = NotifyFilters.LastAccess
                                     | NotifyFilters.LastWrite
                                     | NotifyFilters.FileName
                                     | NotifyFilters.DirectoryName;

                watcher.Filter = "*.txt";

                watcher.Changed += OnChanged;
                watcher.Created += OnChanged;
                watcher.Deleted += OnChanged;
                watcher.Renamed += OnRenamed;

                watcher.EnableRaisingEvents = true;


                while (true) ;
            }
        }

        // Define the event handlers.
        private static void OnChanged(object source, FileSystemEventArgs e) 
        {
            string content;
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
            if (e.ChangeType!= WatcherChangeTypes.Deleted)
            {
                content = DataProvider.GetFileContent(e.FullPath);
            }
            else
            {
                content = "";
            }
            FileChangeInfo FileLog = new FileChangeInfo(e.Name, e.FullPath, DateTime.Now, e.ChangeType, content);
            BackupList.Add(DateTime.Now, FileLog);
            DataProvider.Serialized();
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            Console.WriteLine($"File: {e.OldFullPath} renamed to {e.FullPath}");
            FileChangeInfo FileLog = new FileChangeInfo(e.Name, e.FullPath, DateTime.Now, e.ChangeType, "");
            BackupList.Add(DateTime.Now, FileLog);
            DataProvider.Serialized();
        }
            

    }
}
