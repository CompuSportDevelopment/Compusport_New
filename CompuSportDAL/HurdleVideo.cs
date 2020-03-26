using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CompuSportDataAccess
{
 public class HurdleVideo
    {
        public int _HurdleVideoId;
        public int _LessonId;
        public string _HurdleVideoPath;

        public int HurdleVideoId
        {
            get { return _HurdleVideoId; }
            set { _HurdleVideoId = value; }
        }
        public int LessonId
        {
            get { return _LessonId; }
            set { _LessonId = value; }
        }
        public string HurdleVideoPath
        {
            get { return _HurdleVideoPath; }
            set { _HurdleVideoPath = value; }
        }
        //  [HurdleVideoId]
        //,[LessonId]
        //,[HurdleVideoPath]
    }
}
