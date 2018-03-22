using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;
using System.Configuration;
using Microsoft.SharePoint.Client;
using System.IO;
using System.Threading;
using System.Xml;

namespace Quizzed
{
    public partial class Upload_RC : System.Windows.Forms.Form
    {
        private DataTable quizresults;
        public string spSite;
        public string O365UserName;
        public SecureString O365Password;
        public string quizListName;
        public string docLibraryName;
        public string jobName;
        public string candidate_name;
        private string CDOB;
        private int no_of_passes;
        private string pos_category;
        private string remaining_test;
        private XmlDocument xmldoc;
        private XmlNode CNode;
        private string hireStatus;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private Microsoft.SharePoint.Client.ClientContext ctx;
        private Microsoft.SharePoint.Client.List documentList;
        private Microsoft.SharePoint.Client.Folder docFolder;
        private Microsoft.SharePoint.Client.List CandList;
        private string CandID;
        private string CandName;
        private DataTable CandTable;
        private string msg;
        private DataSet databank;
        public Upload_RC(DataTable dt, string job, string name, string candidateID, string message, string DOB,DataSet dBank)
        {
            InitializeComponent();
            databank = dBank;
            msg = message;
            //await Upload();
            backgroundWorker = new BackgroundWorker();
            CandID = candidateID;
            CandTable = dt;
            CandName = name;
            jobName = job;
            remaining_test = "";
            no_of_passes = 0;
            CDOB = DOB;
            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToString(row["Status"]) == "Pass")
                {

                    no_of_passes++;
                }
                else
                {
                    remaining_test = remaining_test + "QuizNo " + Convert.ToString(row["QuizNumber"]) + ":" + Convert.ToString(row["QuizName"]) + ";";

                }
            }
            //Thread.Sleep(5000);
            if (remaining_test.Length > 0)
                remaining_test = remaining_test.Substring(0, remaining_test.LastIndexOf(';'));
            remaining_test = remaining_test + ";";
            double percent = Convert.ToDouble(no_of_passes) / Convert.ToDouble(dt.Rows.Count);

            if (percent >= 0.7 && percent < 1.0)
            {

                hireStatus = "Conditional Hire";
            }
            else
            {

                hireStatus = "Hired";
            }
            candidate_name = name;
            lblStatus.Text = progressBar1.Value.ToString();
            quizresults = dt;
            try
            {
                string local_path = local_store_path() + job + "\\History.xml";
                xmldoc = new XmlDocument();
                //fs = new FileStream(local_path, FileMode.Open, FileAccess.ReadWrite);
                xmldoc.Load(local_path);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            CNode = read_local_data_store(xmldoc);
            if (CNode == null)
            {
                MessageBox.Show("Error could not find candidate in local data store");


            }
            //remaining_test = "";
            progressBar1.Maximum = 4;
            pos_category = Convert.ToString(dt.Rows[0]["Category"]);
            progressBar1.Step = 1;
            progressBar1.Value = 0;
            //backgroundWorker.RunWorkerAsync();
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            spSite = Convert.ToString(config.AppSettings.Settings["SharePointSafetySite"].Value);
            O365UserName = Convert.ToString(config.AppSettings.Settings["O365UserName"].Value);
            string tempString = config.AppSettings.Settings["O365Password"].Value;
            O365Password = new SecureString();
            foreach (char c in tempString)
            {
                O365Password.AppendChar(c);
            }

            quizListName = Convert.ToString(config.AppSettings.Settings["quizListName"].Value);
            docLibraryName = Convert.ToString(config.AppSettings.Settings["QuizDocLibrary"].Value);
            //lblStatus.Text = "Connectig to SharePoint";
            //progressBar1.Step = 1;
            //progressBar1.PerformStep();
            ////Thread.Sleep(5000);
            //try
            //{
            //    using (Microsoft.SharePoint.Client.ClientContext context = new Microsoft.SharePoint.Client.ClientContext(spSite))
            //    {
            //        if (message == "Pass")
            //        {
            //            // context.Credentials = new Microsoft.SharePoint.Client.SharePointOnlineCredentials(O365UserName, O365Password);
            //            context.Credentials = new SharePointOnlineCredentials(O365UserName, O365Password);
            //            context.Load(context.Web, w => w.Title);
            //            context.ExecuteQuery();
            //            List doclist = context.Web.Lists.GetByTitle(docLibraryName);
            //            context.Load(doclist);
            //            context.ExecuteQuery();
            //            lblStatus.Text = "Creating Folders";
            //            progressBar1.PerformStep();
            //            Folder folder = CreateFolderInternal(context.Web, doclist.RootFolder, candidateID + "_" + candidate_name + "/" + job);
            //            //UploadFile(context, spSite, folder.ServerRelativeUrl, dt);
            //            //Thread.Sleep(5000);

            //            lblStatus.Text = "Uploading Files";
            //            //progressBar1.Step = 2;
            //            progressBar1.PerformStep();
            //            foreach (DataRow row in dt.Rows)
            //            {
            //                if (Convert.ToString(row["Status"]) == "Pass")
            //                {
            //                    using (var fs = new FileStream(Convert.ToString(row["filePath"]), FileMode.Open))
            //                    {
            //                        var fi = new FileInfo(Convert.ToString(row["filePath"]));
            //                        //var list = clientContext.Web.Lists.GetByTitle(listTitle);
            //                        Folder targetFolder = context.Web.GetFolderByServerRelativeUrl(folder.ServerRelativeUrl);
            //                        context.Load(targetFolder);
            //                        context.ExecuteQuery();
            //                        var fileUrl = String.Format("{0}/{1}", targetFolder.ServerRelativeUrl, fi.Name);

            //                        Microsoft.SharePoint.Client.File.SaveBinaryDirect(context, fileUrl, fs, true);
            //                    }
            //                    no_of_passes++;

            //                }
            //                else
            //                {
            //                    remaining_test = remaining_test + "QuizNo " + Convert.ToString(row["QuizNumber"]) + ":" + Convert.ToString(row["QuizName"]) + ";";

            //                }




            //            }
            //            //Thread.Sleep(5000);
            //            if (remaining_test.Length > 0)
            //                remaining_test = remaining_test.Substring(0, remaining_test.LastIndexOf(';'));
            //            remaining_test = remaining_test + ";";
            //            Microsoft.SharePoint.Client.List list = context.Web.Lists.GetByTitle(quizListName);
            //            context.Load(list);
            //            //CamlQuery camlQuery = new CamlQuery();

            //            //camlQuery.ViewXml= "<View><Query><Where><Geq><FieldRef Name='CandidateID'/>" +
            //            //"<Value Type='Text'>"+candidateID+"</Value></Geq></Where></Query><RowLimit>100</RowLimit></View>";
            //            Microsoft.SharePoint.Client.ListItemCollection listitems = list.GetItems(CreateCandidateQuery(candidateID, name.Split('_')[0]));
            //            context.Load(listitems);
            //            context.ExecuteQuery();
            //            lblStatus.Text = "Uploading Results";

            //            foreach (ListItem oListItem in listitems)
            //            {



            //                oListItem["Job"] = jobName;
            //                //double percent = Convert.ToDouble(no_of_passes) / Convert.ToDouble(dt.Rows.Count);
            //                //if (percent >= 0.7 && percent < 1.0)
            //                //    oListItem["Hire_Status"] = "Conditional Hire";
            //                //else
            //                //    oListItem["Hire_Status"] = "Hired";
            //                oListItem["Hire_Status"] = hireStatus;
            //                string tempFolderurl = folder.ServerRelativeUrl;
            //                FieldUrlValue _url = new FieldUrlValue();
            //                _url.Url = tempFolderurl.Substring(0, tempFolderurl.LastIndexOf('/')); ;
            //                _url.Description = "View Tests";
            //                oListItem["FolderUrl"] = _url;
            //                oListItem["Remaining_Test"] = remaining_test;
            //                oListItem["Category"] = pos_category;
            //                //newItem["FolderUrl"] = folder.ServerRelativeUrl;

            //                oListItem.Update();
            //                context.Load(oListItem);
            //                context.ExecuteQuery();


            //            }
            //            try
            //            {

            //                context.Credentials = new SharePointOnlineCredentials(O365UserName, O365Password);
            //                context.ExecuteQuery();


            //            }
            //            catch (Exception ex)
            //            {

            //            }

            //            progressBar1.PerformStep();

            //            //Thread.Sleep(5000);
            //            lblStatus.Text = "Done.Results uploaded, kindly check Sharepoint";
            //            XmlNode Pass_Status = CNode.SelectSingleNode("//Pass_Status");
            //            XmlNode Upload_Status = CNode.SelectSingleNode("//Upload_Status");
            //            XmlNode Remaining_Test = CNode.SelectSingleNode("//Remaining_Test");
            //            Pass_Status.InnerText = hireStatus;
            //            Upload_Status.InnerText = "Success";
            //            Remaining_Test.InnerText = remaining_test;
            //            xmldoc.Save(local_store_path() + job + "\\History.xml");
            //            //Thread.Sleep(2000);

            //            // Application.Exit();





            //        }
            //        else
            //        {
            //            context.Credentials = new Microsoft.SharePoint.Client.SharePointOnlineCredentials(O365UserName, O365Password);
            //            context.Load(context.Web, w => w.Title);
            //            context.ExecuteQuery();
            //            Microsoft.SharePoint.Client.List list = context.Web.Lists.GetByTitle(quizListName);
            //            context.Load(list);
            //            context.ExecuteQuery();
            //            //CamlQuery camlQuery = new CamlQuery();

            //            //camlQuery.ViewXml= "<View><Query><Where><Geq><FieldRef Name='CandidateID'/>" +
            //            //"<Value Type='Text'>"+candidateID+"</Value></Geq></Where></Query><RowLimit>100</RowLimit></View>";
            //            Microsoft.SharePoint.Client.ListItemCollection listitems = list.GetItems(CreateCandidateQuery(candidateID, name.Split('_')[0]));
            //            context.Load(listitems);
            //            context.ExecuteQuery();
            //            lblStatus.Text = "Uploading Results";
            //            foreach (ListItem oListItem in listitems)
            //            {




            //                oListItem["Hire_Status"] = "Failed";
            //                oListItem["Remaining_Test"] = "";
            //                //newItem["FolderUrl"] = folder.ServerRelativeUrl;
            //                oListItem.Update();
            //                //context.Load(list);



            //            }
            //            context.ExecuteQuery();
            //            progressBar1.PerformStep();

            //            //Thread.Sleep(5000);
            //            lblStatus.Text = "Done.Results uploaded, kindly check Sharepoint";
            //            //Thread.Sleep(2000);
            //            XmlNode Pass_Status = CNode.SelectSingleNode("//Pass_Status");
            //            XmlNode Upload_Status = CNode.SelectSingleNode("//Upload_Status");
            //            XmlNode Remaining_Test = CNode.SelectSingleNode("//Remaining_Test");
            //            Pass_Status.InnerText = "Failed";
            //            Upload_Status.InnerText = "Success";
            //            Remaining_Test.InnerText = remaining_test;
            //            xmldoc.Save(local_store_path() + job + "\\History.xml");



            //        }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    MessageBox.Show("Results could not be uploaded to SharePoint.\n Candidate data will be stored locally, kindly use sync function to uplaod candidate data");
            //    XmlNode Pass_Status = CNode.SelectSingleNode("//Pass_Status");
            //    XmlNode Upload_Status = CNode.SelectSingleNode("//Upload_Status");
            //    XmlNode Remaining_Test = CNode.SelectSingleNode("//Remaining_Test");
            //    Pass_Status.InnerText = hireStatus;
            //    Upload_Status.InnerText = "Failed";
            //    Remaining_Test.InnerText = remaining_test;
            //    xmldoc.Save(local_store_path() + job + "\\History.xml");
            //    throw ex;

            //}




        }
        public CamlQuery CreateCandidateQuery(string candidateID, string fname)
        {
            var qry = new CamlQuery();
            qry.ViewXml = "<View><Query><Where><And><Eq><FieldRef Name='CandidateID' /><Value Type='Text'>" + candidateID + "</Value></Eq><Eq><FieldRef Name='First_name' /><Value Type='Text'>" + fname + "</Value></Eq></And></Where></Query></View>";
            return qry;
        }
        private void Calculate(int i)
        {
            double pow = Math.Pow(i, i);
        }
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;

            for (int j = 0; j < 10000; j++)
            {
                Calculate(j);
                backgroundWorker.ReportProgress((j * 100) / 100000);
                progressBar1.PerformStep();
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // TODO: do something with final calculation.
        }
        private int get_nextCandidateID(ListItemCollection listItems)
        {
            int candidateID;
            int largest = 0;
            foreach (ListItem item in listItems)
            {
                candidateID = Convert.ToInt32(item["CandidateID"]);
                if (candidateID > largest)
                    largest = candidateID;



            }
            return largest;
        }


        private Folder CreateFolderInternal(Web web, Folder parentFolder, string fullFolderUrl)
        {
            var folderUrls = fullFolderUrl.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            string folderUrl = folderUrls[0];
            var curFolder = parentFolder.Folders.Add(folderUrl);
            web.Context.Load(curFolder);
            web.Context.ExecuteQuery();

            if (folderUrls.Length > 1)
            {
                var subFolderUrl = string.Join("/", folderUrls, 1, folderUrls.Length - 1);
                return CreateFolderInternal(web, curFolder, subFolderUrl);
            }
            return curFolder;
        }

        private void UploadFile(ClientContext context, string url, string uploadFolderUrl, DataTable dt)
        {
            using (var clientContext = new ClientContext(url))
            {



            }
        }

        private void performOperation(DataTable dt, string job, string name)
        {



        }
        private XmlNode read_local_data_store(XmlDocument xmlDoc)
        {
            XmlElement root = xmlDoc.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("//Candidate");
            XmlNode searchNode = null;
            foreach (XmlNode node in nodes)
            {
                XmlNode First_Name = node.SelectSingleNode("//First_Name");
                XmlNode Last_Name = node.SelectSingleNode("//Last_Name");
                XmlNode Job = node.SelectSingleNode("//Job");
                XmlNode DOB = node.SelectSingleNode("//DOB");
                XmlNode Test_Date = node.SelectSingleNode("//TestDate");
                string f_name = First_Name.InnerText;
                string l_name = Last_Name.InnerText;
                string _job = Job.InnerText;
                string _dob = DOB.InnerText;
                string cName = f_name + "_" + l_name;
                string test_date = Test_Date.InnerText;
                if (cName == candidate_name && _job == jobName && _dob == CDOB && test_date == DateTime.Now.ToShortDateString())
                {
                    searchNode = node;
                    return searchNode;
                }

            }
            return searchNode;

        }
        private string local_store_path()
        {
            try
            {
                // Get the current directory.
                //string path = Directory.GetCurrentDirectory();
                string path = Application.StartupPath;
                string full_path = @path + "\\" + "Local_Data\\";
                // Change the current directory.
                //Environment.CurrentDirectory = (target);
                return full_path;

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
                return "";
            }
        }
        private async void start_upload(string message,DataSet dBank)
        {
            try
            {
                lblStatus.Text = "Connectig to SharePoint";
                await Connect_SharePoint();
                lblStatus.Text = "";
                progressBar1.PerformStep();
                if (message == "Pass")
                {
                    
                    lblStatus.Text = "Creating Folders";
                    await CreateFolders(ctx, jobName);
                    lblStatus.Text = "";
                    progressBar1.PerformStep();
                    lblStatus.Text = "Uploading Files";
                    await Upload_Files(ctx, docFolder, CandTable);
                    lblStatus.Text = "";
                    progressBar1.PerformStep();
                    lblStatus.Text = "Updating List";
                    await Update_List(CandID);
                    lblStatus.Text = "";
                    progressBar1.PerformStep();


                }
                else
                {
                    await Update_List_failed(CandID);
                    lblStatus.Text = "";
                    hireStatus = "Failed";
                    progressBar1.PerformStep();
                }
               
                XmlNode Pass_Status = CNode.SelectSingleNode("//Pass_Status");
                XmlNode Upload_Status = CNode.SelectSingleNode("//Upload_Status");
                XmlNode Remaining_Test = CNode.SelectSingleNode("//Remaining_Test");
                Pass_Status.InnerText = hireStatus;
                Upload_Status.InnerText = "Success";
                Remaining_Test.InnerText = remaining_test;
                xmldoc.Save(local_store_path() + jobName + "\\History.xml");
                pictureBox1.Image = Properties.Resources.success;
                lblStatus.Text = "Success";
                DialogResult dr = MessageBox.Show("Results uploaded on SharePoint.\n\n Click Yes to Retest or No to exit application", "Upload Status", MessageBoxButtons.YesNo);
                if(dr==DialogResult.Yes)
                {
                    this.Hide();
                    DataStoreRefresh obj = new DataStoreRefresh();
                    DataTable dt = obj.refresh_Candidate_Store();
                    if (dt != null)
                    {
                        dt.TableName = "CandidateInfo";
                        dBank.Tables.Remove(dBank.Tables["CandidateInfo"]);
                        dBank.Tables.Add(dt);
                    }
                    new Login_offline(dBank).Show();

                }
                else
                {
                    Application.Exit();

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Results could not be uploaded to SharePoint.\n Candidate data will be stored locally, kindly use sync function to uplaod candidate data");
                XmlNode Pass_Status = CNode.SelectSingleNode("//Pass_Status");
                XmlNode Upload_Status = CNode.SelectSingleNode("//Upload_Status");
                XmlNode Remaining_Test = CNode.SelectSingleNode("//Remaining_Test");
                Pass_Status.InnerText = hireStatus;
                Upload_Status.InnerText = "Failed";
                Remaining_Test.InnerText = remaining_test;
                xmldoc.Save(local_store_path() + jobName + "\\History.xml");
                throw ex;

            }
            
        }

        private async Task Connect_SharePoint()
        {
            try
            {
                using (ctx = new Microsoft.SharePoint.Client.ClientContext(spSite))
                {
                    ctx.Credentials = new SharePointOnlineCredentials(O365UserName, O365Password);
                    ctx.Load(ctx.Web, w => w.Title);
                    ctx.ExecuteQuery();
                    documentList = ctx.Web.Lists.GetByTitle(docLibraryName);
                    ctx.Load(documentList);
                    ctx.ExecuteQuery();
                    await Task.Delay(1000);

                }

            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        private async Task CreateFolders(Microsoft.SharePoint.Client.ClientContext context, string job)
        {
            docFolder = CreateFolderInternal(context.Web, documentList.RootFolder, CandID + "_" + candidate_name + "/" + job);
            await Task.Delay(1000);
        }

        private async Task Upload_Files(Microsoft.SharePoint.Client.ClientContext context, Microsoft.SharePoint.Client.Folder folder, DataTable dt)
        {
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (Convert.ToString(row["Status"]) == "Pass")
                    {
                        using (var fs = new FileStream(Convert.ToString(row["filePath"]), FileMode.Open))
                        {
                            var fi = new FileInfo(Convert.ToString(row["filePath"]));
                            //var list = clientContext.Web.Lists.GetByTitle(listTitle);
                            Folder targetFolder = context.Web.GetFolderByServerRelativeUrl(folder.ServerRelativeUrl);
                            context.Load(targetFolder);
                            context.ExecuteQuery();
                            var fileUrl = String.Format("{0}/{1}", targetFolder.ServerRelativeUrl, fi.Name);

                            Microsoft.SharePoint.Client.File.SaveBinaryDirect(context, fileUrl, fs, true);
                        }
                        no_of_passes++;

                    }
                    else
                    {
                        remaining_test = remaining_test + "QuizNo " + Convert.ToString(row["QuizNumber"]) + ":" + Convert.ToString(row["QuizName"]) + ";";

                    }




                }
                await Task.Delay(1000);
                if (remaining_test.Length > 0)
                    remaining_test = remaining_test.Substring(0, remaining_test.LastIndexOf(';'));
                remaining_test = remaining_test + ";";

            }
            catch (Exception ex)
            {
                throw ex;
            }



        }

        private async Task Update_List(string candidateID)
        {
            try
            {
                Microsoft.SharePoint.Client.List list = ctx.Web.Lists.GetByTitle(quizListName);
                ctx.Load(list);
                //CamlQuery camlQuery = new CamlQuery();

                //camlQuery.ViewXml= "<View><Query><Where><Geq><FieldRef Name='CandidateID'/>" +
                //"<Value Type='Text'>"+candidateID+"</Value></Geq></Where></Query><RowLimit>100</RowLimit></View>";
                Microsoft.SharePoint.Client.ListItemCollection listitems = list.GetItems(CreateCandidateQuery(CandID, CandName.Split('_')[0]));
                ctx.Load(listitems);
                ctx.ExecuteQuery();
                FieldLookupValue lval = await GetLookupValue(ctx, jobName, "Job", "JobFullName", "Text", false);
                foreach (ListItem oListItem in listitems)
                {


                    //oListItem["JobSite"] = lval.LookupValue;
                    oListItem["JobSite"] = lval;
                    oListItem["Job"] = jobName;
                    //double percent = Convert.ToDouble(no_of_passes) / Convert.ToDouble(dt.Rows.Count);
                    //if (percent >= 0.7 && percent < 1.0)
                    //    oListItem["Hire_Status"] = "Conditional Hire";
                    //else
                    //    oListItem["Hire_Status"] = "Hired";
                    oListItem["Hire_Status"] = hireStatus;
                    string tempFolderurl = docFolder.ServerRelativeUrl;
                    FieldUrlValue _url = new FieldUrlValue();
                    _url.Url = tempFolderurl.Substring(0, tempFolderurl.LastIndexOf('/')); ;
                    _url.Description = "View Tests";
                    oListItem["FolderUrl"] = _url;
                    oListItem["Remaining_Test"] = remaining_test;
                    oListItem["Category"] = pos_category;
                    //newItem["FolderUrl"] = folder.ServerRelativeUrl;

                    oListItem.Update();
                    ctx.Load(oListItem);
                    ctx.ExecuteQuery();

                }
                await Task.Delay(1000);

            }
            catch( Exception ex)
            {
                throw ex;

            }
           
        }
        private async Task Update_List_failed(string candidateID)
        {
            try
            {
                Microsoft.SharePoint.Client.List list = ctx.Web.Lists.GetByTitle(quizListName);
                ctx.Load(list);
                //CamlQuery camlQuery = new CamlQuery();

                //camlQuery.ViewXml= "<View><Query><Where><Geq><FieldRef Name='CandidateID'/>" +
                //"<Value Type='Text'>"+candidateID+"</Value></Geq></Where></Query><RowLimit>100</RowLimit></View>";
                Microsoft.SharePoint.Client.ListItemCollection listitems = list.GetItems(CreateCandidateQuery(CandID, CandName.Split('_')[0]));
                ctx.Load(listitems);
                ctx.ExecuteQuery();

                foreach (ListItem oListItem in listitems)
                {



                    oListItem["Hire_Status"] = "Failed";
                    oListItem["Remaining_Test"] = "";
                    //newItem["FolderUrl"] = folder.ServerRelativeUrl;
                    oListItem.Update();

                }
                await Task.Delay(1000);

            }
            catch(Exception ex)
            {
                throw ex;

            }
            
        }

        private  void Upload_RC_Load(object sender, EventArgs e)
        {
            start_upload(msg, databank);

        }
        public async Task<FieldLookupValue> GetLookupValue(ClientContext clientContext, string value, string lookupListName, string lookupFieldName, string lookupFieldType, bool onRootWeb)
        {
            List list = null;
            FieldLookupValue lookupValue = null;

            if (onRootWeb)
            {
                list = clientContext.Site.RootWeb.Lists.GetByTitle(lookupListName);
            }
            else
            {
                list = clientContext.Web.Lists.GetByTitle(lookupListName);
            }

            if (list != null)
            {
                CamlQuery camlQueryForItem = new CamlQuery();
                camlQueryForItem.ViewXml = string.Format(@"<View>
                  <Query>
                      <Where>
                         <Eq>
                             <FieldRef Name='{0}'/>
                             <Value Type='{1}'>{2}</Value>
                         </Eq>
                       </Where>
                   </Query>
            </View>", lookupFieldName, lookupFieldType, value);
                ListItemCollection listItems = list.GetItems(camlQueryForItem);
                clientContext.Load(listItems, items => items.Include
                                                  (listItem => listItem["ID"],
                                                   listItem => listItem[lookupFieldName]));
                clientContext.ExecuteQuery();
                clientContext.ExecuteQuery();
                if (listItems != null)
                {
                    ListItem item = listItems[0];
                    lookupValue = new FieldLookupValue() {LookupId= (int)item["ID"] };
                    
                    //lookupValue.LookupId = int.Parse(item["ID"].ToString());
                    
                    //lookupValue.LookupValue = Convert.ToString(item[lookupFieldName]);
                }
                
            }
            await Task.Delay(1000);
            return lookupValue;
        }
    }
}
