using System;
using System.Collections.Generic;
using System.Text;

namespace CommonComponents
{
    public static class LoginQueries
    {
        public static string FirstName(string email) => "Select FirstName from webuser where Email = '" + email + "'";
    }
}
