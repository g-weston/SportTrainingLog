﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SportTrainingLog
{
    class Session
    {
        public DateTime SessionDate { get; set; }
        public string SessionTitle { get; set; }
        public string SessionDetails { get; set; }
        public List<string> SessionTags { get; set; }
        public List<string> SessionVideos { get; set; }

        public Session(DateTime sessionDate, string sessionTitle, string sessionDetails)
        {
            SessionDate = sessionDate;
            SessionTitle = sessionTitle;
            SessionDetails = sessionDetails;

            SessionTags = null;
            SessionVideos = null;
        }
    }
}