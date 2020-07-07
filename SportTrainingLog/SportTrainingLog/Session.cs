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
        public int SessionLength { get; set; }
        public bool IsCricketSession { get; set; }
        public bool IsFitnessSession { get; set; }
        public bool IsBattingSession { get; set; }
        public bool IsBowlingSession { get; set; }
        public bool IsFieldingSession { get; set; }
        public string BattingSessionSkillsWorked { get; set; }
        public string BattingSessionSkillsToWorkOn { get; set; }
        public int BattingSessionBallsFaced { get; set; }
        public string BowlingSessionSkillsWorked { get; set; }
        public string BowlingSessionSkillsToWorkOn { get; set; }
        public int BowlingSessionBallsBowled { get; set; }
        public string FieldingSessionSkillsWorked { get; set; }
        public string FieldingSessionSkillsToWorkOn { get; set; }
        public int FieldingSessionBallsFielded { get; set; }
        public string FitnessSessionDetails { get; set; }
        //public List<string> SessionTags { get; set; }
        //public List<string> SessionVideos { get; set; }
    }
}
