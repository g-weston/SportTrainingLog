using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SportTrainingLog
{
    public class Session
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public DateTimeOffset SessionDateTimeOffset { get; set; }
        public string SessionDateTimeOffsetString { get; set; }
        public string SessionTitle { get; set; }
        public string SessionDetails { get; set; }
        //public List<string> SessionTags { get; set; }
        //public List<string> SessionVideos { get; set; }
    }
}
