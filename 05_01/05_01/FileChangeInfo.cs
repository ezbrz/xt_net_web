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
        public string FullPath { get; set; }
        public DateTime DateTimeChange { get; set; }
        public WatcherChangeTypes ChangeFileMode { get; set; }
        public string Content { get; set; }
        public FileChangeInfo(string name, string fullPath, DateTime dtChange, WatcherChangeTypes cfMode, string content)
        {
            Name = name;
            FullPath = fullPath;
            DateTimeChange = dtChange;
            ChangeFileMode = cfMode;
            Content = content;
        }
    }
}
