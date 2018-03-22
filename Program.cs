using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Quizzed
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new Login());
            //Application.Run(new Quiz("Sidhanth","Sharma","10006 - Kelly Creek"));
            DataTable dt = new DataTable();
            
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("LastName", typeof(string));
            dt.Columns.Add("Job", typeof(string));
            dt.Columns.Add("QuizNumber", typeof(string));
            dt.Columns.Add("QuizName", typeof(string));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("filePath", typeof(string));
            DataRow row1 = dt.NewRow();
            row1["FirstName"] = "Sidhanth";
            row1["LastName"] = "Sharma";
            row1["Job"] = "10006 - Kelly Creek";
            row1["QuizNumber"] = "1";
            row1["QuizName"] = "Trenching and Shoring Safety Quiz";
            row1["Status"] = "Pass";
            row1["filePath"] = @"C:\Users\ssharma\documents\visual studio 2015\Projects\Quizzed\Quizzed\bin\Debug\Sidhanth_Sharma\Trenching and Shoring Safety Quiz.pdf";
            dt.Rows.Add(row1);
            DataRow row2 = dt.NewRow();
            row2["FirstName"] = "Sidhanth";
            row2["LastName"] = "Sharma";
            row2["Job"] = "10006 - Kelly Creek";
            row2["QuizNumber"] = "2";
            row2["QuizName"] = "Lockout/Tagout";
            row2["Status"] = "Pass";
            row2["filePath"] = @"C:\Users\ssharma\documents\visual studio 2015\Projects\Quizzed\Quizzed\bin\Debug\Sidhanth_Sharma\Lockout_Tagout.pdf";
            dt.Rows.Add(row2);
            DataRow row3 = dt.NewRow();
            row3["FirstName"] = "Sidhanth";
            row3["LastName"] = "Sharma";
            row3["Job"] = "10006 - Kelly Creek";
            row3["QuizNumber"] = "3";
            row3["QuizName"] = "Cranes Safety Quiz";
            row3["Status"] = "Pass";
            row3["filePath"] = @"C:\Users\ssharma\documents\visual studio 2015\Projects\Quizzed\Quizzed\bin\Debug\Sidhanth_Sharma\Cranes Safety Quiz.pdf";
            dt.Rows.Add(row3);
            DataRow row4 = dt.NewRow();
            row4["FirstName"] = "Sidhanth";
            row4["LastName"] = "Sharma";
            row4["Job"] = "10006 - Kelly Creek";
            row4["QuizNumber"] = "4";
            row4["QuizName"] = "Bloodborne Pathogens";
            row4["Status"] = "Fail";
            row4["filePath"] = "";
            dt.Rows.Add(row4);
            DataRow row5 = dt.NewRow();
            row5["FirstName"] = "Sidhanth";
            row5["LastName"] = "Sharma";
            row5["Job"] = "10006 - Kelly Creek";
            row5["QuizNumber"] = "5";
            row5["QuizName"] = "Fall Protection Quiz";
            row5["Status"] = "Pass";
            row5["filePath"] = @"C:\Users\ssharma\documents\visual studio 2015\Projects\Quizzed\Quizzed\bin\Debug\Sidhanth_Sharma\Fall Protection Quiz.pdf";
            dt.Rows.Add(row5);
            //Application.Run(new Upload(dt, "10006 - Kelly Creek", "Sidhanth_Sharma"));
            DataTable dt1 = new DataTable();

            dt1.Columns.Add("FirstName", typeof(string));
            dt1.Columns.Add("LastName", typeof(string));
            dt1.Columns.Add("Job", typeof(string));
            dt1.Columns.Add("QuizNumber", typeof(string));
            dt1.Columns.Add("QuizName", typeof(string));
            dt1.Columns.Add("Status", typeof(string));
            dt1.Columns.Add("filePath", typeof(string));
            dt1.Columns.Add("Category", typeof(string));
            DataRow row_RC = dt1.NewRow();
            row_RC["FirstName"] = "Ned";
            row_RC["LastName"] = "Stark";
            row_RC["Job"] = "10034-110 - Beebe 1b";
            row_RC["QuizNumber"] = "1";
            row_RC["QuizName"] = "General Safety Orientation";
            row_RC["Status"] = "Pass";
            row_RC["filePath"] = @"C:\Users\ssharma\Documents\Visual Studio 2015\Projects\Quizzed\Quizzed\bin\Debug\Ned_Stark\General Safety Orientation.pdf";
            row_RC["Category"] = "Subcontactor";
            dt1.Rows.Add(row_RC);
           //Application.Run(new Upload_RC(dt1, "10034-110 - Beebe 1b", "Ned_Stark", "1022", "Pass"));

         Application.Run(new SplashForm());
           // Application.Run(new SignupPage());
        }
    }
}
