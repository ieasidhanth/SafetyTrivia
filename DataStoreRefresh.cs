using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizzed
{
    class DataStoreRefresh
    {
        public string spJobsite;
        public string spCandidateSite;
        public string docLibraryName;
        private string joblistName;
        private string quizListName;
        public string O365UserName;
        public SecureString O365Password;
        private SqlConnection sqlConn;
        private DataTable qbank;
        private DataTable candidate_info;
        private DataTable jobSiteInfo;
        private DataTable category;
        private DataTable quiz_video;
        private DataTable quizList;
        private DataTable quiz_cat_relatn;
        private string filename_candidateInfo;
        private string filename_jobSiteInfo;
        private string filename_category;
        private string filename_quizVideo;
        private string filename_quizList;
        private string filename_qbank;
        private string filename_quiz_cat_reln;
        private string local_data_path;
        public DataStoreRefresh()
        {
            local_data_path = System.Windows.Forms.Application.StartupPath + "\\" + "Local_Data";
            filename_candidateInfo = local_data_path + "\\" + "candidateInfo.xml";
            filename_jobSiteInfo = local_data_path + "\\" + "jobInfo.xml";
            filename_category = local_data_path + "\\" + "Category.xml";
            filename_quizVideo = local_data_path + "\\" + "Quiz_Video.xml";
            filename_quizList = local_data_path + "\\" + "QuizList$.xml";
            filename_qbank = local_data_path + "\\" + "qBank_V2.xml";
            filename_quiz_cat_reln = local_data_path + "\\" + "Quiz_Category_Relation.xml";
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            spJobsite = Convert.ToString(config.AppSettings.Settings["SharePointJobSite"].Value);
            spCandidateSite = Convert.ToString(config.AppSettings.Settings["SharePointSafetySite"].Value);
            docLibraryName = Convert.ToString(config.AppSettings.Settings["QuizDocLibrary"].Value);
            quizListName = Convert.ToString(config.AppSettings.Settings["quizListName"].Value);
            O365UserName = Convert.ToString(config.AppSettings.Settings["O365UserName"].Value);
            joblistName = Convert.ToString(config.AppSettings.Settings["jobListName"].Value);
            string tempString = config.AppSettings.Settings["O365Password"].Value;
            O365Password = new SecureString();
            foreach (char c in tempString)
            {
                O365Password.AppendChar(c);
            }
        }
        public DataTable refresh_Candidate_Store()
        {
            using (Microsoft.SharePoint.Client.ClientContext context = new Microsoft.SharePoint.Client.ClientContext(spCandidateSite))
            {
                try
                {
                    context.Credentials = new Microsoft.SharePoint.Client.SharePointOnlineCredentials(O365UserName, O365Password);
                    context.Load(context.Web, w => w.Title);
                    context.ExecuteQuery();
                    //toolStripStatusLabel1.Text = "Connecting to Libraries..";
                    Microsoft.SharePoint.Client.List list = context.Web.Lists.GetByTitle(quizListName);
                    context.Load(list);
                    context.ExecuteQuery();
                    Microsoft.SharePoint.Client.ListItemCollection listitems = list.GetItems(Microsoft.SharePoint.Client.CamlQuery.CreateAllItemsQuery());
                    context.Load(listitems);
                    context.ExecuteQuery();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("CandidateID", typeof(string));
                    dt.Columns.Add("First_name", typeof(string));
                    dt.Columns.Add("Last_name", typeof(string));
                    dt.Columns.Add("Job", typeof(string));
                    dt.Columns.Add("Hire_Status", typeof(string));
                    dt.Columns.Add("FolderUrl", typeof(string));
                    dt.Columns.Add("Remaining_Test", typeof(string));
                    dt.Columns.Add("Category", typeof(string));
                    dt.Columns.Add("DOB", typeof(string));
                    dt.Columns.Add("Date", typeof(string));
                    dt.Columns.Add("DisplayCombobox", typeof(string));
                    foreach (Microsoft.SharePoint.Client.ListItem item in listitems)
                    {
                        DataRow row = dt.NewRow();
                        row["CandidateID"] = item["CandidateID"];
                        row["First_Name"] = item["First_name"];
                        row["Last_name"] = item["Last_name"];
                        //change before full deployment
                        //row["Job"] = ((FieldLookupValue)item["JobSite"]).LookupValue; ;
                        row["Job"] = Convert.ToString(item["Job"]); 
                        row["Hire_Status"] = item["Hire_Status"];
                        row["Remaining_Test"] = item["Remaining_Test"];
                        row["Category"] = item["Category"];
                        row["DOB"] = item["DOB"];
                        Microsoft.SharePoint.Client.FieldUrlValue _url = (Microsoft.SharePoint.Client.FieldUrlValue)item["FolderUrl"];
                        row["FolderUrl"] = _url.Url;
                        row["Date"] = item["Modified"];
                        row["DisplayCombobox"] = item["First_name"] + "_" + item["Last_name"] + " - " + item["CandidateID"];
                        dt.Rows.Add(row);

                    }
                    dt.TableName = "CandidateInfo";
                    SerializeDataSet(dt, "candidateInfo.xml");
                    return dt;
                    //toolStripStatusLabel1.Text = "Connecting to Lists..";
                    //Microsoft.SharePoint.Client.List list = context.Web.Lists.GetByTitle(quizListName);
                    //context.Load(list);

                }

                catch (Exception ex)
                {

                    return null;

                }
            }

        }
        private void SerializeDataSet(DataTable dt, string filename)
        {

            try
            {
                dt.TableName = filename.Split('.')[0];
                string full_fileName = System.Windows.Forms.Application.StartupPath + "\\Local_Data\\" + filename;
                dt.WriteXml(full_fileName, XmlWriteMode.WriteSchema, true);

            }
            catch(Exception ex)
            {
                throw ex;
            }
            
            //DataTable dt1 = new DataTable();
            //dt1.ReadXml(filename);
            //ser.Serialize(writer, ds);


        }   
    }
}
