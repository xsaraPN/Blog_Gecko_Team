using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;


namespace Blog.Unit.Tests.Models
{
    public class AccessExcelData
    {

        public static string fileName;
        public static string TestDataFileConnection()
        {
            //var path = @"C:\Users\Djordjiii\Desktop\Blog-master\Blog-Skeleton\Blog.Unit.Tests\DataDrivenTests\";
            var path = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["TestDataSheetPath"];
           
             
            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0};Extended Properties=Excel 12.0 Xml;HDR=YES;IMEX=1;", path + fileName);
            return con;
        }

        public static RegistrationUser GetRegistrationTestData(string keyName)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [DataSet$] where key = '{0}'", keyName);
                var value = connection.Query<RegistrationUser>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }

        public static LogInUser GetLoginTestData(string keyName)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [DataSet$] where key = '{0}'", keyName);
                var value = connection.Query<LogInUser>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }
    }
}