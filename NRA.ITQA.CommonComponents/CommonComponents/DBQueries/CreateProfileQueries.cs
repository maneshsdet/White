using System;
using System.Collections.Generic;
using System.Text;

namespace CommonComponents
{
    public static class CreateProfileQueries
    {
        public static string CGIWebUserCount(string email) => "Select count(*) from webuser where Email = '" + email + "'";
        public static string NRAEFUserCount(string email) => "Select count(*) from NRAEF.dbo.Users where USERID in (Select LinkID from cgiweb.dbo.webuser where Email = '" + email + "')";

    }
}
