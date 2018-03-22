using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Security;
using System.Configuration;
using System.IO;
using System.Xml.Serialization;
using Microsoft.SharePoint.Client;

namespace Quizzed
{
    public partial class SplashForm : System.Windows.Forms.Form
    {
        public string spJobsite;
        public string spCandidateSite;
        public string docLibraryName;
        private string joblistName;
        private string quizListName;
        public string O365UserName;
        public SecureString O365Password;
        public BackgroundWorker bw;
        public BackgroundWorker bw_sharepoint;
        public BackgroundWorker bw_sharepoint_safety_site;
        public BackgroundWorker bw_sharepoint_safety_site_lib;
        public BackgroundWorker bw_sharepoint_safety_site_list;
        private DataTable jobSiteInfo;
        private DataTable qBank;
        private LogWriter logger;
        private DataSet dataBank;
        private DataTable candidateInfo;
        public SplashForm()
        {
            InitializeComponent();
            logger = new LogWriter("Log File Created");
            dataBank = new DataSet("LocalData");
            bw = new BackgroundWorker();
            bw_sharepoint = new BackgroundWorker();
            bw_sharepoint_safety_site = new BackgroundWorker();
            bw_sharepoint_safety_site_lib = new BackgroundWorker();
            bw_sharepoint_safety_site_list = new BackgroundWorker();
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            spJobsite = Convert.ToString(config.AppSettings.Settings["SharePointJobSite"].Value);
            spCandidateSite= Convert.ToString(config.AppSettings.Settings["SharePointSafetySite"].Value);
            docLibraryName= Convert.ToString(config.AppSettings.Settings["QuizDocLibrary"].Value);
            quizListName = Convert.ToString(config.AppSettings.Settings["quizListName"].Value);
            O365UserName = Convert.ToString(config.AppSettings.Settings["O365UserName"].Value);
            joblistName= Convert.ToString(config.AppSettings.Settings["jobListName"].Value);
            string tempString = config.AppSettings.Settings["O365Password"].Value;
            O365Password = new SecureString();
            foreach (char c in tempString)
            {
                O365Password.AppendChar(c);
            }
            toolStripProgressBar1.Maximum = 5;
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
           // timeLeft = 40;
           // splshTimer.Start();

        }

        public int timeLeft { get; set; }

        private void splshTimer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;

            }
            else
            {
                splshTimer.Stop();
                new Login().Show();
                this.Hide();
            }

        }

        private void SplashForm_Shown(object sender, EventArgs ex)
        {
            

            bw.RunWorkerAsync();
            
            
            bw.DoWork += (sender1, e) =>
            {
                toolStripStatusLabel1.Text = "Connecting to Database";
               






                DataTable dt_allQuestions = new DataTable();
                dt_allQuestions.TableName = "qBank_V2";
                DataTable dt_allCategory = new DataTable();
                dt_allCategory.TableName = "Category";

                DataTable dt_allQuiz = new DataTable();
                dt_allQuiz.TableName = "QuizList$";
                DataTable dt_VideoLinks = new DataTable();
                dt_VideoLinks.TableName = "Quiz_Video";
                DataTable dt_QuizCategory_relation = new DataTable();
                dt_QuizCategory_relation.TableName = "Quiz_Category_Relation";
                
                string local_data_path = Create_Directory();
                qBank = new DataTable();
                string filename_Qbank = local_data_path + "\\" + "qBank_V2.xml";
                string filename_Category = local_data_path + "\\" + "Category.xml";
                string filename_QuizList = local_data_path + "\\" + "QuizList$.xml";
                string filename_Vid_Links = local_data_path + "\\" + "Quiz_Video.xml";
                string filename_quiz_cat_reltn = local_data_path + "\\" + "Quiz_Category_Relation.xml";
                try
                {
                    DSL obj = new DSL();
                    e.Result = obj;
                    dt_allQuestions = obj.getallQuestions_offline();
                    dt_allCategory = obj.getCategories_offline();
                    dt_allQuiz = obj.get_all_quizes_offline();
                    dt_VideoLinks = obj.get_QuizLinks_offline();
                    dt_QuizCategory_relation = obj.get_QuizCategory_offline();
                    SerializeDataSet(dt_allQuestions, "qBank_V2.xml");
                    SerializeDataSet(dt_allCategory, "Category.xml");
                    SerializeDataSet(dt_allQuiz, "QuizList$.xml");
                    SerializeDataSet(dt_VideoLinks, "Quiz_Video.xml");
                    SerializeDataSet(dt_QuizCategory_relation, "Quiz_Category_Relation.xml");
                    dataBank.Tables.Add(dt_allQuestions);
                    dataBank.Tables.Add(dt_allCategory);
                    dataBank.Tables.Add(dt_allQuiz);
                    dataBank.Tables.Add(dt_VideoLinks);
                    dataBank.Tables.Add(dt_QuizCategory_relation);

                }
                catch(Exception exception)
                {
                   
                    if(!checkLocalDataStore_DB())
                    {
                        MessageBox.Show("Could not load Local Data.");

                    }
                    else
                    {
                        dt_allQuestions.ReadXml(filename_Qbank);
                        dt_allCategory.ReadXml(filename_Category);
                        dt_allQuiz.ReadXml(filename_QuizList);
                        dt_VideoLinks.ReadXml(filename_Vid_Links);
                        dt_QuizCategory_relation.ReadXml(filename_quiz_cat_reltn);
                        dataBank.Tables.Add(dt_allQuestions);
                        dataBank.Tables.Add(dt_allCategory);
                        dataBank.Tables.Add(dt_allQuiz);
                        dataBank.Tables.Add(dt_VideoLinks);
                        dataBank.Tables.Add(dt_QuizCategory_relation);


                    }

                }
                

                

                //Boolean localdataLoaded = false;
                               
                //    if (readXmls(dt_allQuestions, filename_Qbank) && readXmls(dt_allQuiz, filename_QuizList) && readXmls(dt_allCategory, filename_Category) && readXmls(dt_VideoLinks, filename_Vid_Links))
                //        localdataLoaded = true;
                //    else
                //        localdataLoaded = false;

               
                //if (localdataLoaded)
                //{
                //    toolStripStatusLabel1.Text = "Connecting to Local Database";

                //}
                //else
                //{
                    
                //    DSL obj = new DSL();
                    
                //    e.Result = obj;
                //    dt_allQuestions = obj.getallQuestions_offline();
                //    dt_allCategory = obj.getCategories_offline();
                //    dt_allQuiz = obj.get_all_quizes_offline();
                //    dt_VideoLinks = obj.get_QuizLinks_offline();
                //    SerializeDataSet(dt_allQuestions, "qBank_V2.xml");
                //    SerializeDataSet(dt_allCategory, "Category.xml");
                //    SerializeDataSet(dt_allQuiz, "QuizList$.xml");
                //    SerializeDataSet(dt_VideoLinks, "Quiz_Video.xml");

                //}


            };
            bw_sharepoint.DoWork += Bw_sharepoint_DoWork;

            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;

            bw_sharepoint.RunWorkerCompleted += Bw_sharepoint_RunWorkerCompleted;

            bw_sharepoint_safety_site.DoWork += Bw_sharepoint_safety_site_DoWork;
            bw_sharepoint_safety_site.RunWorkerCompleted += Bw_sharepoint_safety_site_RunWorkerCompleted;

            bw_sharepoint_safety_site_lib.DoWork += Bw_sharepoint_safety_site_lib_DoWork;
            bw_sharepoint_safety_site_lib.RunWorkerCompleted += Bw_sharepoint_safety_site_lib_RunWorkerCompleted;

            bw_sharepoint_safety_site_list.DoWork += Bw_sharepoint_safety_site_list_DoWork;
            bw_sharepoint_safety_site_list.RunWorkerCompleted += Bw_sharepoint_safety_site_list_RunWorkerCompleted;
            
        }

        private void Bw_sharepoint_safety_site_list_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // throw new NotImplementedException();
            if (e.Error != null)
            {// if an exception occurred during DoWork,
                MessageBox.Show("Failed to connected to Safety List");  // do your error handling here
                logger.LogWrite("Failed to connected to Safety List");
                logger.LogWrite(e.Error.ToString());
            }
            else
            {
                var web = e.Result;
                toolStripStatusLabel1.Text = "Successfully connected to Lists";
                toolStripProgressBar1.Step = 5;
                logger.LogWrite("SSuccessfully connected to Lists");
                toolStripProgressBar1.PerformStep();

                Thread.Sleep(20);
                new Login_offline(dataBank).Show();
                this.Hide();

                // do something with your connector
            }
        }

        private void Bw_sharepoint_safety_site_list_DoWork(object sender, DoWorkEventArgs e)
        {
            //throw new NotImplementedException();
            toolStripStatusLabel1.Text = "Connecting to Safety Libraries";
            string local_data_path = Create_Directory();
            candidateInfo = new DataTable();
            string filename = local_data_path + "\\" + "candidateInfo.xml";
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
                        // enable when deploying througout organization
                        //row["Job"] = ((FieldLookupValue)item["JobSite"]).LookupValue;
                        row["Job"] = item["Job"];
                        row["Hire_Status"] = item["Hire_Status"];
                        row["Remaining_Test"] = item["Remaining_Test"];
                        row["Category"] = item["Category"];
                        row["DOB"] = item["DOB"];
                        Microsoft.SharePoint.Client.FieldUrlValue _url = (Microsoft.SharePoint.Client.FieldUrlValue)item["FolderUrl"];
                        row["FolderUrl"] = _url.Url;
                        row["Date"] = item["Modified"];
                       // row["DisplayCombobox"] = item["CandidateID"] + " - " + item["First_name"] + "_" + item["Last_name"];
                        row["DisplayCombobox"] = item["First_name"] + "_" + item["Last_name"]+" - "+ item["CandidateID"];
                        dt.Rows.Add(row);

                    }
                    dt.TableName = "CandidateInfo";
                    SerializeDataSet(dt, "candidateInfo.xml");
                    candidateInfo = dt.Copy();
                    candidateInfo.TableName = "CandidateInfo";
                    dataBank.Tables.Add(candidateInfo);
                    //toolStripStatusLabel1.Text = "Connecting to Lists..";
                    //Microsoft.SharePoint.Client.List list = context.Web.Lists.GetByTitle(quizListName);
                    //context.Load(list);
                    e.Result = list;
                }
               
                catch (Exception ex)
                {
                    e.Result = ex;
                    if (checkLocalDataStore_candidate())
                    {
                        candidateInfo.ReadXml(filename);
                        candidateInfo.TableName = "CandidateInfo";
                        dataBank.Tables.Add(candidateInfo);

                    }
                    else
                    {
                        MessageBox.Show("Could not find candiateInfo.xml");

                    }

                }
            }

        }

        private void Bw_sharepoint_safety_site_lib_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.Error != null)
            {// if an exception occurred during DoWork,
                MessageBox.Show("Failed to connect to Safety Site Library");  // do your error handling here
                logger.LogWrite("Failed to connect to Safety Site Library");
                logger.LogWrite(e.Error.ToString());
            }
            else
            {
                var web = e.Result;
                toolStripProgressBar1.Step = 4;

                toolStripProgressBar1.PerformStep();
                toolStripStatusLabel1.Text = "Successfully connected Libraries";
                logger.LogWrite("Successfully connected Libraries");
                bw_sharepoint_safety_site_list.RunWorkerAsync();
                // do something with your connector
            }
        }

        private void Bw_sharepoint_safety_site_lib_DoWork(object sender, DoWorkEventArgs e)
        {
            //throw new NotImplementedException();
            toolStripStatusLabel1.Text = "Connecting to Safety Libraries";
            using (Microsoft.SharePoint.Client.ClientContext context = new Microsoft.SharePoint.Client.ClientContext(spCandidateSite))
            {
                try
                {
                    context.Credentials = new Microsoft.SharePoint.Client.SharePointOnlineCredentials(O365UserName, O365Password);
                    context.Load(context.Web, w => w.Title);
                    context.ExecuteQuery();
                    //toolStripStatusLabel1.Text = "Connecting to Libraries..";
                    Microsoft.SharePoint.Client.List doclist = context.Web.Lists.GetByTitle(docLibraryName);
                    context.Load(doclist);
                    context.ExecuteQuery();
                    //toolStripStatusLabel1.Text = "Connecting to Lists..";
                    //Microsoft.SharePoint.Client.List list = context.Web.Lists.GetByTitle(quizListName);
                    //context.Load(list);
                    e.Result = doclist;
                }
                catch (Microsoft.SharePoint.Client.ServerException ex)
                {
                    e.Result = ex;

                }
                catch (Exception ex)
                {
                    e.Result = ex;

                }
            }
        }

        private void Bw_sharepoint_safety_site_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)  // if an exception occurred during DoWork,
                MessageBox.Show(e.Error.ToString());  // do your error handling here
            else
            {
                var web = e.Result;
                toolStripProgressBar1.Step = 3;

                toolStripProgressBar1.PerformStep();
                bw_sharepoint_safety_site_lib.RunWorkerAsync();
               // toolStripStatusLabel1.Text = "All Connections succeeded..";

                // do something with your connector
            }

            // throw new NotImplementedException();
        }

        private void Bw_sharepoint_safety_site_DoWork(object sender, DoWorkEventArgs e)
        {
            //throw new NotImplementedException();
            toolStripStatusLabel1.Text = "Connecting to Safety Sharepoint site";
            using (Microsoft.SharePoint.Client.ClientContext context = new Microsoft.SharePoint.Client.ClientContext(spCandidateSite))
            {
                try
                {
                    context.Credentials = new Microsoft.SharePoint.Client.SharePointOnlineCredentials(O365UserName, O365Password);
                    context.Load(context.Web, w => w.Title);
                    context.ExecuteQuery();
                    
                    e.Result = context.Web;
                }
                catch (Microsoft.SharePoint.Client.ServerException ex)
                {
                    e.Result = ex;

                }
                catch (Exception ex)
                {
                    e.Result = ex;

                }
            }
        }

        private void Bw_sharepoint_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                // if an exception occurred during DoWork,
                //MessageBox.Show(e.Error.ToString());  // do your error handling here
                MessageBox.Show("Error Connecting to Operations Site");
                logger.LogWrite("Error Connecting to Operations Site");
                logger.LogWrite(e.Error.ToString());
            }
            else
            {
                var web = e.Result;
                toolStripProgressBar1.Step = 2;

                toolStripProgressBar1.PerformStep();
                toolStripStatusLabel1.Text = "Data Successfully Loaded for Jobs";
                logger.LogWrite("Data Successfully Loaded for Jobs");
                bw_sharepoint_safety_site.RunWorkerAsync();
                // do something with your connector
            }

            //throw new NotImplementedException();
        }

        private void Bw_sharepoint_DoWork(object sender, DoWorkEventArgs e)
        {
            string local_data_path = Create_Directory();
            jobSiteInfo = new DataTable();
            string filename = local_data_path + "\\" + "JobInfo.xml";
            toolStripStatusLabel1.Text = "Connecting to Operations Sharepoint site";
            using (Microsoft.SharePoint.Client.ClientContext context = new Microsoft.SharePoint.Client.ClientContext(spJobsite))
            {
                try
                {
                    context.Credentials = new Microsoft.SharePoint.Client.SharePointOnlineCredentials(O365UserName, O365Password);
                    context.Load(context.Web, w => w.Title);
                    context.ExecuteQuery();
                    e.Result = context.Web;
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
                        //un comment for new release
                        //row["Name"] = item["JobNumber"] + " - " + item["Title"];
                        row["Name"] = item["JobFullName"];
                        row["JobNumber"] = item["Title"];
                        Microsoft.SharePoint.Client.FieldUrlValue _url = (Microsoft.SharePoint.Client.FieldUrlValue)item["Site_x0020_Url"];
                        row["SiteUrl"] = _url.Url;
                        row["ProjectType"] = item["Project_x0020_Category"];
                        dt.Rows.Add(row);

                    }
                    dt.TableName = "JobSiteInfo";
                    SerializeDataSet(dt, "JobInfo.xml");
                    jobSiteInfo = dt.Copy();
                    jobSiteInfo.TableName="JobSiteInfo";
                    dataBank.Tables.Add(jobSiteInfo);
                }
                
                catch (Exception ex)
                {
                    e.Result = ex;
                    toolStripStatusLabel1.Text = "Connecting to Local Datastore for Job Info";
                    if (checkLocalDataStore_Operations())
                    {
                        jobSiteInfo.ReadXml(filename);
                        jobSiteInfo.TableName = "JobSiteInfo";
                        dataBank.Tables.Add(jobSiteInfo);

                    }
                    else
                    {
                        MessageBox.Show("Could not find jobsiteInfo.xml");
                    }

                }


            }
           


           

        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                // if an exception occurred during DoWork,
                //MessageBox.Show(e.Error.ToString());  // do your error handling here
                MessageBox.Show("Error Connecting to Database");
                logger.LogWrite("Error Connecting to Database");
                logger.LogWrite(e.Error.ToString());
            }
            else
            {
                var connector = e.Result;
                toolStripProgressBar1.Step = 1;

                toolStripProgressBar1.PerformStep();
                logger.LogWrite("Connection to Database successful");
                toolStripStatusLabel1.Text = "Connection to Database successful";
                bw_sharepoint.RunWorkerAsync();

                // do something with your connector
            }

            //throw new NotImplementedException();
        }
        private void SerializeDataSet(DataTable dt,string filename)
        {


            dt.TableName = filename.Split('.')[0];
            string full_fileName= Application.StartupPath+"\\Local_Data\\"+filename;
            dt.WriteXml(full_fileName, XmlWriteMode.WriteSchema,true);
            //DataTable dt1 = new DataTable();
            //dt1.ReadXml(filename);
            //ser.Serialize(writer, ds);


        }

        public string Create_Directory()
        {
            try
            {
                // Get the current directory.
                //string path = Directory.GetCurrentDirectory();
                string path = Application.StartupPath;
                string full_path = @path + "\\" +"Local_Data";
                if (!Directory.Exists(full_path))
                {
                    Directory.CreateDirectory(full_path);
                }
                            // Change the current directory.
                //Environment.CurrentDirectory = (target);
                return full_path;

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
                return "-1";
            }

        }


        private Boolean readXmls(DataTable dt, string fileName)
        {
            try
            {
                dt.ReadXml(fileName);
                return true;

            }
            catch(Exception ex)
           {
                return false;
            }
            
        }

        private Boolean checkLocalDataStore_DB()
        {
            string local_data_store_Path = Application.StartupPath + "\\" + "Local_Data";
            string filename_Qbank = local_data_store_Path + "\\" + "qBank_V2.xml";
            string filename_Category = local_data_store_Path + "\\" + "Category.xml";
            string filename_QuizList = local_data_store_Path + "\\" + "QuizList$.xml";
            string filename_Vid_Links = local_data_store_Path + "\\" + "Quiz_Video.xml";
            if(System.IO.File.Exists(filename_Qbank) && System.IO.File.Exists(filename_Category) && System.IO.File.Exists(filename_QuizList) && System.IO.File.Exists(filename_Vid_Links))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private Boolean checkLocalDataStore_Operations()
        {
            string local_data_store_Path = Application.StartupPath + "\\" + "Local_Data";
            string filename_jobInfo = local_data_store_Path + "\\" + "jobInfo.xml";
            
            if (System.IO.File.Exists(filename_jobInfo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean checkLocalDataStore_candidate()
        {
            string local_data_store_Path = Application.StartupPath + "\\" + "Local_Data";
            string filename_candInfo = local_data_store_Path + "\\" + "candidateInfo.xml";

            if (System.IO.File.Exists(filename_candInfo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

}
