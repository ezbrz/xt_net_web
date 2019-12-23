using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Security.Permissions;


namespace _05_01
{
    static class Watcher
    {
        static string path;
        static public Dictionary<DateTime, FileChangeInfo> BackupList = new Dictionary<DateTime, FileChangeInfo>();

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public static void Run(object pathStart)
        {
            path = (string)pathStart;
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
                if (!File.Exists(path + "log.dat")||File.ReadAllText(path+"log.dat")=="")
                {
                    DataProvider.FirstStart(path);
                }
                DataProvider.DeSerialized(path);
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
            string oldContent;
            oldContent = BackupList.LastOrDefault(n => n.Key < DateTime.Now && n.Value.FullPath == e.FullPath).Value.Content;
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
            if (e.ChangeType!= WatcherChangeTypes.Deleted)
            {
                content = DataProvider.GetFileContent(e.FullPath);
            }
            else
            {
                content = "";
            }
            FileChangeInfo FileLog = new FileChangeInfo(e.Name, e.FullPath, "", DateTime.Now, e.ChangeType, content, oldContent);
            BackupList.Add(DateTime.Now, FileLog);
            DataProvider.Serialized(path);
            DataProvider.DeSerialized(path);
        }

        
        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            Console.WriteLine($"File: {e.OldFullPath} renamed to {e.FullPath}");
            FileChangeInfo FileLog = new FileChangeInfo(e.Name, e.FullPath, e.OldFullPath, DateTime.Now, e.ChangeType, "", "");
            BackupList.Add(DateTime.Now, FileLog);
            DataProvider.Serialized(path);
            DataProvider.DeSerialized(path);
        }
            

    }

}
