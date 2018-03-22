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
    public partial class Upload : System.Windows.Forms.Form
    {
        private DataTable quizresults;
        public string spSite;
        public string O365UserName;
        public SecureString O365Password;
        public string quizListName;
        public string docLibraryName;
        public string jobName;
        public string candidate_name;
        private int no_of_passes;
        private string CDOB;
        private string remaining_test;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private string pos_category;
        private XmlDocument xmldoc;
        private XmlNode CNode;
        private string hireStatus;
        private FileStream fs;
        private Microsoft.SharePoint.Client.ClientContext ctx;
        private Microsoft.SharePoint.Client.List documentList;
        private Microsoft.SharePoint.Client.List CandList;
        private Microsoft.SharePoint.Client.Folder docFolder;
        private string CandID;
        private string CandName;
        private DataTable CandTable;
        private DataSet dBank;
        private string siteURL;
        public Upload(DataTable dt,string job,string name,string position, string dob, DataSet dataBank,string sURL)
        {
            dBank = dataBank;
            InitializeComponent();
            CandName = name;
            CandTable = dt;
            pos_category = position;
            backgroundWorker = new BackgroundWorker();
            jobName = job;
            remaining_test = "";
            no_of_passes = 0;
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
           //string hireStatus = "";
            if (percent >= 0.7 && percent < 1.0)
            {
               
                hireStatus = "Conditional Hire";
            }
            else
            {
               
                hireStatus = "Hired";
            }
            candidate_name = name;
            CDOB = dob;
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
            //performOperation(quizresults, jobName, candidate_name);
            progressBar1.Maximum = 4;
             
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
            //try
            //{

            //    quizListName = Convert.ToString(config.AppSettings.Settings["quizListName"].Value);
            //    docLibraryName = Convert.ToString(config.AppSettings.Settings["QuizDocLibrary"].Value);
            //    lblStatus.Text = "Connectig to SharePoint";
            //    progressBar1.Step = 1;
            //    progressBar1.PerformStep();
            //    //Thread.Sleep(5000);
            //    using (Microsoft.SharePoint.Client.ClientContext context = new Microsoft.SharePoint.Client.ClientContext(spSite))
            //    {
            //        context.Credentials = new Microsoft.SharePoint.Client.SharePointOnlineCredentials(O365UserName, O365Password);
            //        context.Load(context.Web, w => w.Title);
            //        context.ExecuteQuery();
            //        List doclist = context.Web.Lists.GetByTitle(docLibraryName);
            //        context.Load(doclist);
            //        context.ExecuteQuery();
            //        Microsoft.SharePoint.Client.List list = context.Web.Lists.GetByTitle(quizListName);
            //        context.Load(list);

            //        Microsoft.SharePoint.Client.ListItemCollection listitems = list.GetItems(Microsoft.SharePoint.Client.CamlQuery.CreateAllItemsQuery());
            //        context.Load(listitems);
            //        context.ExecuteQuery();
            //        string candID;
            //        if (listitems.Count > 0)
            //            candID = Convert.ToString(get_nextCandidateID(listitems) + 1);
            //        else
            //            candID = "1000";
            //        lblStatus.Text = "Creating Folders";
            //        progressBar1.PerformStep();
            //        Folder folder = CreateFolderInternal(context.Web, doclist.RootFolder, candID + "_" + candidate_name + "/" + job);
            //        //UploadFile(context, spSite, folder.ServerRelativeUrl, dt);
            //        //Thread.Sleep(5000);

            //        lblStatus.Text = "Uploading Files";
            //        //progressBar1.Step = 2;
            //        progressBar1.PerformStep();
            //        foreach (DataRow row in dt.Rows)
            //        {
            //            if (Convert.ToString(row["Status"]) == "Pass")
            //            {
            //                using (var fs = new FileStream(Convert.ToString(row["filePath"]), FileMode.Open))
            //                {
            //                    var fi = new FileInfo(Convert.ToString(row["filePath"]));
            //                    //var list = clientContext.Web.Lists.GetByTitle(listTitle);
            //                    Folder targetFolder = context.Web.GetFolderByServerRelativeUrl(folder.ServerRelativeUrl);
            //                    context.Load(targetFolder);
            //                    context.ExecuteQuery();
            //                    var fileUrl = String.Format("{0}/{1}", targetFolder.ServerRelativeUrl, fi.Name);

            //                    Microsoft.SharePoint.Client.File.SaveBinaryDirect(context, fileUrl, fs, true);
            //                }
            //               // no_of_passes++;
            //            }
            //            else
            //            {
            //               // remaining_test = remaining_test + "QuizNo " + Convert.ToString(row["QuizNumber"]) + ":" + Convert.ToString(row["QuizName"]) + ";";

            //            }
            //        }
            //        //Thread.Sleep(5000);
            //        ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
            //        ListItem newItem = list.AddItem(itemCreateInfo);
            //        lblStatus.Text = "Uploading Results";
            //        progressBar1.PerformStep();
            //        newItem["CandidateID"] = candID;
            //        newItem["First_name"] = candidate_name.Split('_')[0];
            //        newItem["Last_name"] = candidate_name.Split('_')[1];
            //        newItem["Job"] = jobName;
            //        newItem["DOB"] = dob;
            //        // double percent = Convert.ToDouble(no_of_passes) / Convert.ToDouble(dt.Rows.Count);
            //        // string hireStatus = "";
            //        newItem["Hire_Status"] = hireStatus;
            //        //if (percent >= 0.7 && percent < 1.0)
            //        //{
            //        //    newItem["Hire_Status"] = hireStatus;
            //        //   // hireStatus = "Conditional Hire";
            //        //}
            //        //else
            //        //{
            //        //    newItem["Hire_Status"] = "Hired";
            //        //    hireStatus = "Hired";
            //        //}
            //        string tempFolderurl = folder.ServerRelativeUrl;
            //        FieldUrlValue _url = new FieldUrlValue();
            //        _url.Url = tempFolderurl.Substring(0, tempFolderurl.LastIndexOf('/')); ;
            //        _url.Description = "View Tests";
            //        newItem["FolderUrl"] = _url;
            //        newItem["Remaining_Test"] = remaining_test;
            //        newItem["Category"] = pos_category;
            //        //newItem["FolderUrl"] = folder.ServerRelativeUrl;
            //        newItem.Update();
            //        context.Load(list);
            //        context.ExecuteQuery();
            //        //Thread.Sleep(5000);
            //        lblStatus.Text = "Done.Results uploaded, kindly check Sharepoint";
            //        //Thread.Sleep(2000);
            //        XmlNode Pass_Status = CNode.SelectSingleNode("//Pass_Status");
            //        XmlNode Upload_Status = CNode.SelectSingleNode("//Upload_Status");
            //        XmlNode Remaining_Test = CNode.SelectSingleNode("//Remaining_Test");
            //        Pass_Status.InnerText = hireStatus;
            //        Upload_Status.InnerText = "Success";
            //        Remaining_Test.InnerText = remaining_test;
            //        xmldoc.Save(local_store_path() + job + "\\History.xml");
            //        // Application.Exit();





            //    }
            //}
            //catch(Exception ex)
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
    
        private int get_nextCandidateID(ListItemCollection listItems)
        {
            int candidateID;
            int largest = 0;
            foreach(ListItem item in listItems)
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


       
        private XmlNode read_local_data_store(XmlDocument xmlDoc)
        {
            XmlElement root = xmlDoc.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("//Candidate");
            XmlNode searchNode=null;
            foreach(XmlNode node in nodes)
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
                if (cName==candidate_name && _job==jobName && _dob== CDOB && test_date == DateTime.Now.ToShortDateString())
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
                    CandList = ctx.Web.Lists.GetByTitle(quizListName);
                    ctx.Load(CandList);
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
            Microsoft.SharePoint.Client.ListItemCollection listitems = CandList.GetItems(Microsoft.SharePoint.Client.CamlQuery.CreateAllItemsQuery());
            context.Load(listitems);
            context.ExecuteQuery();
            CandID = "";
            if (listitems.Count > 0)
                CandID = Convert.ToString(get_nextCandidateID(listitems) + 1);
            else
                CandID = "1000";
            docFolder = CreateFolderInternal(context.Web, documentList.RootFolder, CandID + "_" + candidate_name + "/" + job);
            await Task.Delay(1000);
        }

        private async Task Upload_Files(Microsoft.SharePoint.Client.ClientContext context, Microsoft.SharePoint.Client.Folder folder, DataTable dt)
        {
            try
            {
               
                DataRow row_agreement = dt.NewRow();
                row_agreement["FirstName"] =candidate_name.Split('_')[0];
                row_agreement["LastName"] = candidate_name.Split('_')[1];
                row_agreement["Job"] = jobName;
                row_agreement["QuizNumber"] = "0";
                row_agreement["QuizName"] = "Agreement";
                row_agreement["Status"] = "Pass";
                row_agreement["filePath"] = Create_Directory(candidate_name)+ "\\" + "Agreement_" + candidate_name.Split('_')[0]+" "+ candidate_name.Split('_')[1] + ".pdf";
               // row_agreement["Category"] = pos_category;
                dt.Rows.Add(row_agreement);
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
                        

                    }
                    




                }
                await Task.Delay(1000);
                

            }
            catch (Exception ex)
            {
                throw ex;
            }



        }

        private async Task Update_List(string candidateID, string dob)
        {
            try
            {
                
                ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
                ListItem newItem = CandList.AddItem(itemCreateInfo);
                lblStatus.Text = "Uploading Results";
                progressBar1.PerformStep();
                FieldLookupValue lval = await GetLookupValue(ctx, jobName, "Job", "JobFullName", "Text", false);

                newItem["CandidateID"] = CandID;
                newItem["First_name"] = candidate_name.Split('_')[0];
                newItem["Last_name"] = candidate_name.Split('_')[1];
                newItem["JobSite"] = lval;
                newItem["DOB"] = dob;
                newItem["Job"] = jobName;
                // double percent = Convert.ToDouble(no_of_passes) / Convert.ToDouble(dt.Rows.Count);
                // string hireStatus = "";
                newItem["Hire_Status"] = hireStatus;
                //if (percent >= 0.7 && percent < 1.0)
                //{
                //    newItem["Hire_Status"] = hireStatus;
                //   // hireStatus = "Conditional Hire";
                //}
                //else
                //{
                //    newItem["Hire_Status"] = "Hired";
                //    hireStatus = "Hired";
                //}
                string tempFolderurl = docFolder.ServerRelativeUrl;
                FieldUrlValue _url = new FieldUrlValue();
                _url.Url = tempFolderurl.Substring(0, tempFolderurl.LastIndexOf('/')); ;
                _url.Description = "View Tests";
                newItem["FolderUrl"] = _url;
                newItem["Remaining_Test"] = remaining_test;
                newItem["Category"] = pos_category;
                //newItem["FolderUrl"] = folder.ServerRelativeUrl;
                newItem.Update();
                ctx.Load(CandList);
                ctx.ExecuteQuery();
            
                await Task.Delay(1000);

            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        private void Upload_Load(object sender, EventArgs e)
        {
            try
            {
                start_upload(dBank);

            }
            catch (Exception ex)
            {

            }
            
        }
        private async void start_upload(DataSet dBank)
        {
            try
            {
                lblStatus.Text = "Connectig to SharePoint";
                await Connect_SharePoint();
                lblStatus.Text = "";
                progressBar1.PerformStep();
                lblStatus.Text = "Creating Folders";
                await CreateFolders(ctx, jobName);
                lblStatus.Text = "";
                progressBar1.PerformStep();
                lblStatus.Text = "Uploading Files";
                await Upload_Files(ctx, docFolder, CandTable);
                lblStatus.Text = "";
                progressBar1.PerformStep();
                lblStatus.Text = "Updating List";
                await Update_List(CandID,CDOB);
                lblStatus.Text = "";
                progressBar1.PerformStep();
                lblStatus.Text = "Success";
                XmlNode Pass_Status = CNode.SelectSingleNode("//Pass_Status");
                XmlNode Upload_Status = CNode.SelectSingleNode("//Upload_Status");
                XmlNode Remaining_Test = CNode.SelectSingleNode("//Remaining_Test");
                Pass_Status.InnerText = hireStatus;
              
                Remaining_Test.InnerText = remaining_test;
                xmldoc.Save(local_store_path() + jobName + "\\History.xml");
                pictureBox1.Image = Properties.Resources.success;
                Upload_Status.InnerText = "Success";
                DialogResult dr = MessageBox.Show("Results uploaded on SharePoint.\n\n Click Yes to Retest or No to exit application", "Upload Status", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    this.Hide();
                    this.Close();
                    DataStoreRefresh obj = new DataStoreRefresh();
                    DataTable dt = obj.refresh_Candidate_Store();
                    if(dt!=null)
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
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.Message);
                if(ex.Message.Contains("The remote name could not be resolved"))
                {
                    MessageBox.Show(" IEA SharePoint site in unreachable, Kindly check your internet connection");

                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
                //MessageBox.Show("Results could not be uploaded to SharePoint.\n Candidate data will be stored locally, kindly use sync function to uplaod candidate data");

                XmlNode Pass_Status = CNode.SelectSingleNode("//Pass_Status");
                XmlNode Upload_Status = CNode.SelectSingleNode("//Upload_Status");
                XmlNode Remaining_Test = CNode.SelectSingleNode("//Remaining_Test");
                Pass_Status.InnerText = hireStatus;
                Upload_Status.InnerText = "Failed";
                Remaining_Test.InnerText = remaining_test;
                xmldoc.Save(local_store_path() + jobName + "\\History.xml");
                //throw ex;
                DialogResult dr = MessageBox.Show("Results could not be uploaded to SharePoint.\n Candidate data will be stored locally, kindly use sync function to uplaod candidate data.\n\n Click Yes to retest or No to exit application.", "Upload Status", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    this.Hide();
                    this.Close();
                    new Login_offline(dBank).Show();

                }
                else
                {
                    Application.Exit();

                }


            }

        }
        public string Create_Directory(string folder)
        {
            try
            {
                // Get the current directory.
                //string path = Directory.GetCurrentDirectory();
                string path = Application.StartupPath;
                string date_path = @path + "\\" + DateTime.Now.ToShortDateString().Replace('/', '_');
                if (!Directory.Exists(date_path))
                {
                    Directory.CreateDirectory(date_path);
                }
                string target = @date_path + "\\" + folder;
                Console.WriteLine("The current directory is {0}", path);
                if (!Directory.Exists(target))
                {
                    Directory.CreateDirectory(target);
                }

                // Change the current directory.
                //Environment.CurrentDirectory = (target);
                return target;

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
                return "-1";
            }

        }

        public async Task<FieldLookupValue> GetLookupValue(ClientContext clientContext, string value,string lookupListName, string lookupFieldName, string lookupFieldType, bool onRootWeb)
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

                if (listItems != null)
                {
                    ListItem item = listItems[0];
                    lookupValue = new FieldLookupValue();
                    lookupValue.LookupId = int.Parse(item["ID"].ToString());
                }
            }
            await Task.Delay(1000);
            return lookupValue;
        }
    }
}
