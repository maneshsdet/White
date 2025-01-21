using System;
using System.Collections.Generic;
using System.Text;

namespace CommonComponents
{
    public static class EditProfileQueries
    {
        public static string FirstName(string email) => "Select FirstName from webuser where Email = '" + email + "'";

        public static string Email => "Select Top 1 Email from  cgiweb.dbo.webuser where Email like '%nraregression%' order by DateCreated desc";
    }
}
