using caseStudy;
using System;
using System.Data.SqlClient;
using caseStudy.util;
using casestudy.util;
using caseStudyArt.Util;



namespace caseStudy.util
{


    public static class DBPropertyUtil
    {
        public static class DBConnection
        {

            private static SqlConnection connection;

            public static SqlConnection GetConnection()
            {
                // Get the connection string
                string connectionString = PropertyUtil.GetPropertyString();

                // Create a SqlConnection object
                SqlConnection connection = new SqlConnection(connectionString);

                return connection;
            }

        }
    }
}
