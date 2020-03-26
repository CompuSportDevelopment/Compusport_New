using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using SwingModel.Data;
using SwingModel.Entities;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Web.Security;

namespace CompuSportDAL
{
    class TrackLogNdLogOutTime
    {
        Guid MemGuid;
        Customer customer;
        Teacher teacher;
        CompuSportDAL.SprintAthleteEdit _sprintAthleteEdit = new CompuSportDAL.SprintAthleteEdit();

        public void LoginNdLogOutTime()
        {
            //MembershipUser member = Membership.GetUser(Login1.UserName);

        }
    }
}
