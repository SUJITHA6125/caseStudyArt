using System;
using System.Data.SqlClient;
using caseStudy.util;
using System.IO;


namespace casestudy.util
{
    public class PropertyUtil
    {
        private static SqlConnection Getconnection;

        public static string GetPropertyString()
        {
            string propertyFilePath = "D:\\Virtual_Art_Gal\\Art_gall\\Art_gall\\appsettings.json";

            string server = "DESKTOP-CN4H436";
            string dbname = "VirtualartGallery";
            string username = "sujitha";
            string password = "suji12345";
            string trustedconnection = "true";



            string connectionString = $"Server={server};Database={dbname};User Id={username};Password={password}; TrustServerCertificate ={trustedconnection}";

            return connectionString;
        }




    }
}

