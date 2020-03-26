using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SprintAthleteArgs:EventArgs
{
    private int lessonId = 0;
    public int LessonId
    {
        get { return lessonId; }
        set { lessonId = value; }
    }
    public SprintAthleteArgs(int Id)
    {
        lessonId = Id;
    }
}
//public class EditPersonEventArgs : EventArgs
//{
//    private int personId = 0;
//    public int PersonId
//    {
//        get { return personId; }
//        set { personId = value; }
//    }
//    public EditPersonEventArgs(int Id)
//    {
//        personId = Id;
//    }
//}