using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _05_01
{
    [Serializable]
    public sealed class FileChangeInfo
    {
        public string Name { get; set; }
        public string OldFullPath { get; set; }
        public string FullPath { get; set; }
        public DateTime DateTimeChange { get; set; }
        public WatcherChangeTypes ChangeFileMode { get; set; }
        public string Content { get; set; }
        public string OldContent { get; set; }
        public FileChangeInfo(string name, string fullPath, string oldFullPath, DateTime dtChange, WatcherChangeTypes cfMode, string content, string oldContent)
        {
            Name = name;
            FullPath = fullPath;
            OldFullPath = oldFullPath;
            DateTimeChange = dtChange;
            ChangeFileMode = cfMode;
            Content = content;
            OldContent = oldContent;
        }
    }
}
