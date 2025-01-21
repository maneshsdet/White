using System;
using System.Collections.Generic;
using System.Text;

namespace CommonComponents.DBQueries
{
    public static class DinerQueries
    {
        public static String PingUser => "select Top 1 Email from CGIWeb..webuser where Email like 'nraregression+%' ORDER BY NEWID()";
        public static String CgiUser => "Select UserID from (" +
            "select ROW_NUMBER() OVER(ORDER BY DateCreated Desc) " +
            "AS Row#, UserID from CGIWeb..WebUser " +
            "where UserId like 'AT%' and Email in " +
            "('bamin@restaurant.org','nasundaram@restaurant.org') and Email not like 'nra%') " +
            "as temp where Row# = " + Constants.rand.Next(1, 20);
        public static String PortalUser => "select Top 1 Email from CGIWeb..webuser where Email like 'nraportals+%' ORDER BY NEWID()";
        public static String UnverifiedEmail => "Select  Top 1 Email from CGIWeb..webuser where ????";
    }
}
