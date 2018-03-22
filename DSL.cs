using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security;

namespace Quizzed
{
    class DSL
    {
        private SqlConnection sqlConn;
        public string spJobsite;
        public string spCandidateSite;
        public string docLibraryName;
        private string joblistName;
        private string quizListName;
        public string O365UserName;
        public SecureString O365Password;
        public DSL()
        {
            try
            {


                Connection conn = new Connection();
                sqlConn = conn.initiateConnection();
                if (sqlConn == null)
                {
                    //throw new NullReferenceException();

                }
                    
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            
            


        }

        public DataTable getallQuestions()
        {
            SqlDataAdapter adap = new SqlDataAdapter("Select * from qBank;", sqlConn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            return dt;

        }
        public DataTable getallQuestionsByCategory(string category)
        {
            SqlDataAdapter adap = new SqlDataAdapter("Select * from qBank_v2 where category_ID="+category+";", sqlConn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            return dt;

        }

        public DataTable getallQuestions(List<int> QuizIds)
        {
            string qids = "";
            foreach(int ids in QuizIds)
            {
                qids = qids + ids + ",";

            }
            qids = qids.Substring(0, qids.LastIndexOf(','));
            string query = "Select * from qBank where QuizNumber in (" + qids + ")";
            SqlDataAdapter adap = new SqlDataAdapter(query, sqlConn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            //foreach(DataRow row in dt.Rows)
            //{
            //    row["AllowedAttempts"] = 1;
            //}
            return dt;

        }

        public int getQuizCount()
        {
            SqlCommand cmd = new SqlCommand("Select count(distinct(QuizNumber)) from QuestionBank;", sqlConn);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }
        public int getQuizCount_ByCategory(string category)
        {
            SqlCommand cmd = new SqlCommand("Select count(distinct(QuizNumber)) from qBank_v2 where category_ID="+category+";", sqlConn);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }

        public DataTable getCategories()
        {
            string query = "Select * from Category";
            SqlDataAdapter adap = new SqlDataAdapter(query, sqlConn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            return dt;
        }
        public DataTable get_all_quizes()
        {
            string query = "Select * from  QuizList$";
            SqlDataAdapter adap = new SqlDataAdapter(query, sqlConn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            return dt;
        }
        public string get_quiz_List(int catID)
        {
            string query = "Select * From Quiz_Category_Relation where Category_ID="+catID;
            SqlDataAdapter adap = new SqlDataAdapter(query, sqlConn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            string quizList = "";
            foreach(DataRow row in dt.Rows)
            {
                quizList = quizList + Convert.ToString(row["Quiz_ID"]) + "#";

            }
            return (quizList.Substring(0, quizList.LastIndexOf('#')));
        }

        public DataTable get_QuizLinks()
        {
            string query = "Select * From Quiz_Video";
            SqlDataAdapter adap = new SqlDataAdapter(query, sqlConn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            return dt;
        }



        public DataTable getallQuestions_offline()
        {
            SqlDataAdapter adap = new SqlDataAdapter("Select * from qBank_v2;", sqlConn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            return dt;

        }
        public DataTable getCategories_offline()
        {
            string query = "Select * from Category";
            SqlDataAdapter adap = new SqlDataAdapter(query, sqlConn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            return dt;
        }
        public DataTable get_all_quizes_offline()
        {
            string query = "Select * from  QuizList$";
            SqlDataAdapter adap = new SqlDataAdapter(query, sqlConn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            return dt;
        }
        public DataTable get_QuizLinks_offline()
        {
            string query = "Select * From Quiz_Video";
            SqlDataAdapter adap = new SqlDataAdapter(query, sqlConn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            return dt;
        }
        public DataTable get_QuizCategory_offline()
        {
            string query = "Select * From Quiz_Category_Relation";
            SqlDataAdapter adap = new SqlDataAdapter(query, sqlConn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            return dt;
        }
        public async Task<DataTable> getAllJobs()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(System.Windows.Forms.Application.ExecutablePath);
            spJobsite = Convert.ToString(config.AppSettings.Settings["SharePointJobSite"].Value);
            O365UserName = Convert.ToString(config.AppSettings.Settings["O365UserName"].Value);
            joblistName = Convert.ToString(config.AppSettings.Settings["jobListName"].Value);
            string tempString = config.AppSettings.Settings["O365Password"].Value;
            O365Password = new SecureString();
            foreach (char c in tempString)
            {
                O365Password.AppendChar(c);
            }
            using (Microsoft.SharePoint.Client.ClientContext context = new Microsoft.SharePoint.Client.ClientContext(spJobsite))
            {
                try
                {
                    context.Credentials = new Microsoft.SharePoint.Client.SharePointOnlineCredentials(O365UserName, O365Password);
                    context.Load(context.Web, w => w.Title);
                    context.ExecuteQuery();
                    Microsoft.SharePoint.Client.List list = context.Web.Lists.GetByTitle(joblistName);
                    context.Load(list);

                    Microsoft.SharePoint.Client.ListItemCollection listitems = list.GetItems(Microsoft.SharePoint.Client.CamlQuery.CreateAllItemsQuery());
                    context.Load(listitems);
                    context.ExecuteQuery();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Name", typeof(string));
                    dt.Columns.Add("JobNumber", typeof(string));
                    dt.Columns.Add("SiteUrl", typeof(string));
                    dt.Columns.Add("ProjectType", typeof(string));
                    foreach (Microsoft.SharePoint.Client.ListItem item in listitems)
                    {
                        DataRow row = dt.NewRow();
                        row["Name"] = item["JobNumber"] + " - " + item["Title"];
                        row["JobNumber"] = item["JobNumber"];
                        Microsoft.SharePoint.Client.FieldUrlValue _url = (Microsoft.SharePoint.Client.FieldUrlValue)item["JobSiteUrl"];
                        row["SiteUrl"] = _url.Url;
                        row["ProjectType"] = item["ProjectCategory"];
                        dt.Rows.Add(row);

                    }
                    dt.TableName = "JobSiteInfo";
                    await Task.Delay(1000);
                    return dt;
                }

                catch (Exception ex)
                {
                    return null;

                }


            }

        }

    }
}
