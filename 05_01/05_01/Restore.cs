using System;
using System.IO;
using System.Linq;
using System.Text;

namespace _05_01
{
    static class Restore
    {
        public static void RestoreFiles(DateTime date, string path)
        {
            foreach (var item in Watcher.BackupList.Reverse())
            {
                if (date <= item.Key)
                {
                    RollbackChanges(item.Value);
                    Watcher.BackupList.Remove(item.Key);
                }
            }
            DataProvider.Serialized(path);
        }
        static void RollbackChanges(FileChangeInfo fileInfo)
        {
            switch(fileInfo.ChangeFileMode)
            {
                case WatcherChangeTypes.Renamed:
                    File.Move(fileInfo.FullPath, fileInfo.OldFullPath);
                    break;
                case WatcherChangeTypes.Changed:
                    using (StreamWriter sw = new StreamWriter(fileInfo.FullPath, false, Encoding.Default))
                    {
                        sw.Write(fileInfo.OldContent);
                    }
                    break;
                case WatcherChangeTypes.Deleted:
                    using (StreamWriter sw = new StreamWriter(fileInfo.FullPath, false, Encoding.Default))
                    {
                        sw.Write(fileInfo.OldContent);
                    }
                    break;
                case WatcherChangeTypes.Created:
                    File.Delete(fileInfo.FullPath);
                    break;
            }
        }
    }
}
