using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Quizzed
{
    public partial class upload_results : System.Windows.Forms.Form
    {
        private DataTable jobList;
        private DataTable candidateList;
        public string spSite;
        public string O365UserName;
        public SecureString O365Password;
        public string quizListName;
        public string docLibraryName;
        private Microsoft.SharePoint.Client.ClientContext ctx;
        private XmlDocument xmlDoc;
        private Loader wait_form;
        private int Login_formYPos;
        private int Login_formXPos;
        private int Login_formHeight;
        private int Login_formWidth;
        public upload_results()
        {
            
            InitializeComponent();
            //Login_formHeight = height;
            //Login_formWidth = width;
            //Login_formXPos = left;
            //Login_formYPos = top;
            lblNocandiates.Visible = false;
            panel1.Visible = false;
            pnl_bottom.Visible = false;
            candidateList = new DataTable();
            candidateList.Columns.Add("First_Name", typeof(string));
            candidateList.Columns.Add("Last_Name", typeof(string));
            candidateList.Columns.Add("DOB", typeof(string));
            candidateList.Columns.Add("Position", typeof(string));
            candidateList.Columns.Add("Job", typeof(string));
            candidateList.Columns.Add("Folder_path", typeof(string));
            candidateList.Columns.Add("Pass_Status", typeof(string));
            candidateList.Columns.Add("Upload_Status", typeof(string));
            candidateList.Columns.Add("Remaining_Test", typeof(string));
            candidateList.Columns.Add("TestDate", typeof(string));

            candidateList.Columns.Add("IsReturningCandidate", typeof(string));
            candidateList.Columns.Add("candidateID", typeof(string));
            candidateList.Columns.Add("Current_Upload_Status", typeof(string));
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


        }

        private async void upload_results_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            label5.Visible = false;
            progressBarUpload.Visible = false;
            try
            {
                wait_form = new Loader();
               // wait_form.MdiParent = this;
                //wait_form.StartPosition = FormStartPosition.Manual;
                //wait_form.Top = (Login_formYPos + Login_formHeight) / 2;
                //wait_form.Left = (Login_formXPos + Login_formWidth) / 2;
                wait_form.Show();
                Application.DoEvents();
                
                DSL obj = new DSL();
                jobList =await obj.getAllJobs();
                
                if(jobList==null)
                {
                    DSL_offline obj_ = new DSL_offline();
                    jobList = obj_.get_jobList();

                }
                DataRow row = jobList.NewRow();
                row["Name"] = "--Select--";
                jobList.Rows.InsertAt(row, 0);
                cmbxJobList.DataSource = jobList;
                cmbxJobList.DisplayMember = jobList.Columns["Name"].ToString();
                cmbxJobList.ValueMember = jobList.Columns["Name"].ToString();

            }
            catch(Exception ex)
            {

               // MessageBox.Show(ex.Message);
                //throw;
                if (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible"))
                {
                    MessageBox.Show("This feature requires stable internet connection, Kindly check internet connection and try again!");
                    this.Close();
                    wait_form.Close();
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private  void cmbxJobList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(cmbxJobList.SelectedIndex>0)
            {
               // MessageBox.Show(cmbxJobList.SelectedValue.ToString());
                if (Directory.Exists(get_local_data_path() + cmbxJobList.SelectedValue.ToString()))
                {
                    if(System.IO.File.Exists(get_local_data_path()+cmbxJobList.SelectedValue+"\\"+"History.xml"))
                    {
                        if(candidateList.Rows.Count>0)
                        {
                            candidateList.Rows.Clear();
                        }
                        using (FileStream fs = new FileStream(get_local_data_path() + cmbxJobList.SelectedValue + "\\" + "History.xml", FileMode.Open, FileAccess.Read))
                        {
                            panel1.Visible = true;
                            lblNocandiates.Visible = false;
                            dgvCandidates.Visible = true;
                            pnl_bottom.Visible = true;
                            xmlDoc = new XmlDocument();
                            xmlDoc.Load(fs);
                            XmlNodeList Candidates = xmlDoc.SelectNodes("//CandidateInfo//Candidate");
                            foreach(XmlNode cNode in Candidates)
                            {
                                if(Convert.ToString(cNode.ChildNodes[7].InnerText)=="Failed")
                                {
                                    DataRow row = candidateList.NewRow();
                                    row["First_Name"] = cNode.ChildNodes[0].InnerText;
                                    row["Last_Name"] = cNode.ChildNodes[1].InnerText;
                                    row["DOB"] = cNode.ChildNodes[2].InnerText;
                                    row["Position"] = cNode.ChildNodes[3].InnerText;
                                    row["Job"] = cNode.ChildNodes[4].InnerText;
                                    row["Folder_path"] = cNode.ChildNodes[5].InnerText;
                                    row["Pass_Status"] = cNode.ChildNodes[6].InnerText;
                                    row["Upload_Status"] = cNode.ChildNodes[7].InnerText;
                                    row["Remaining_Test"] = cNode.ChildNodes[8].InnerText;
                                    row["TestDate"] = cNode.ChildNodes[9].InnerText;

                                    row["IsReturningCandidate"] = cNode.ChildNodes[10].InnerText;
                                    if (cNode.ChildNodes[11].InnerText == "")
                                    {
                                        row["CandidateID"] = "";


                                    }
                                    else
                                    {
                                        row["CandidateID"] = cNode.ChildNodes[11].InnerText;

                                    }
                                    row["Current_Upload_Status"] = cNode.ChildNodes[7].InnerText;

                                    candidateList.Rows.Add(row);

                                }
                                

                            }

                        }
                        if (candidateList.Rows.Count != 0)
                        {
                            bindingSource1.DataSource = candidateList;
                            bindingNavigator1.BindingSource = bindingSource1;
                            dgvCandidates.AutoGenerateColumns = true;
                            dgvCandidates.DataSource = bindingSource1;
                            dgvCandidates.Columns[4].Visible = false;
                            dgvCandidates.Columns[5].Visible = false;
                            dgvCandidates.Columns[6].Visible = false;
                            dgvCandidates.Columns[7].Visible = false;
                            dgvCandidates.Columns[8].Visible = false;
                            dgvCandidates.Columns[9].Visible = false;
                            dgvCandidates.Columns[10].Visible = false;
                            lblRC.DataBindings.Clear();
                            lblHireStatus.DataBindings.Clear();
                            lblRemainingTest.DataBindings.Clear();
                            lblTestDate.DataBindings.Clear();
                            lblClickHere.DataBindings.Clear();

                            lblRC.DataBindings.Add(new Binding("Text", bindingSource1, "IsReturningCandidate", true));
                            lblHireStatus.DataBindings.Add(new Binding("Text", bindingSource1, "Pass_Status", true));
                            lblRemainingTest.DataBindings.Add(new Binding("Text", bindingSource1, "Remaining_Test", true));
                            lblTestDate.DataBindings.Add(new Binding("Text", bindingSource1, "TestDate", true));

                            lblClickHere.DataBindings.Add(new Binding("Tag", bindingSource1, "Folder_path", true));
                            progressBarUpload.Maximum = candidateList.Rows.Count;
                            progressBarUpload.Minimum = 0;
                            progressBarUpload.Step = 1;
                            label5.Text = "Status";
                        }
                        else
                        {
                            panel1.Visible = false;
                            dgvCandidates.Visible = false;
                            lblNocandiates.Visible = true;
                        }

                    }
                    else
                    {
                        MessageBox.Show("No History found for thuis job in local datastore");
                    }

                }
                else
                {
                    MessageBox.Show("No Job directory found in the local datastore");
                }
            }
            
        }
        private string get_local_data_path()
        {
            string path = Application.StartupPath;
            string target = path + "\\Local_Data\\";
            return target;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(e.Link.Tag as string);
           // Process.Start(e.Link.Tag as string);

        }

        private void cmbxJobList_KeyPress(object sender, KeyPressEventArgs e)
        {
            cmbxJobList.DroppedDown = false;
        }

        private void label4_MouseClick(object sender, MouseEventArgs e)
        {
            var obj = sender as Label;
            Process.Start(obj.Tag as string);

        }

        private void lblClickHere_Click(object sender, EventArgs e)
        {
            var obj = sender as Label;
            Process.Start(obj.Tag as string);

        }

        private async void btn_Upload_Click(object sender, EventArgs e)
        {
            try
            {
                ctx = connect_Sharepoint();
                if(ctx!=null)
                {
                    try {

                        List doclist = ctx.Web.Lists.GetByTitle(docLibraryName);
                        ctx.Load(doclist);
                        ctx.ExecuteQuery();
                        Microsoft.SharePoint.Client.List list = ctx.Web.Lists.GetByTitle(quizListName);
                        ctx.Load(list);
                        ctx.ExecuteQuery();
                        label5.Visible = true;
                        progressBarUpload.Visible = true;
                        foreach (DataRow row in candidateList.Rows)
                        {
                            label5.Text = "Processing : " + row["First_Name"]+row["Last_Name"];
                            if (Convert.ToString(row["Upload_Status"])== "Failed")
                            {
                                if(Convert.ToString(row["IsReturningCandidate"])=="No")
                                {
                                    await upload_new_Candidates(row, ctx, doclist, list);
                                    row["Current_Upload_Status"] = "Uploaded";
                                    progressBarUpload.PerformStep();
                                   

                                }
                                else
                                {
                                    await upload_RC_Candidates(row, ctx, doclist, list);
                                    row["Current_Upload_Status"] = "Uploaded";
                                    progressBarUpload.PerformStep();


                                }

                            }
                        }
                        label5.Text = "Upload Complete";


                    }
                    catch (Exception ex)
                    {

                    }

                }
                else
                {
                    MessageBox.Show("Error connecting to Sharepoint. Kindly check internet connectivity");
                }


            }
            catch(Exception ex)
            {

            }
        }
        private Microsoft.SharePoint.Client.ClientContext connect_Sharepoint()
        {
            try
            {
                using (Microsoft.SharePoint.Client.ClientContext context = new Microsoft.SharePoint.Client.ClientContext(spSite))
                {
                    context.Credentials = new Microsoft.SharePoint.Client.SharePointOnlineCredentials(O365UserName, O365Password);
                    context.Load(context.Web, w => w.Title);
                    context.ExecuteQuery();
                    return context;

                }

            }
            catch(Exception ex)
            {

                return null;
            }
            
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

        private async Task upload_new_Candidates(DataRow row, Microsoft.SharePoint.Client.ClientContext context, Microsoft.SharePoint.Client.List doclist, Microsoft.SharePoint.Client.List list)
        {
            
            try
            {
                Microsoft.SharePoint.Client.ListItemCollection listitems = list.GetItems(Microsoft.SharePoint.Client.CamlQuery.CreateAllItemsQuery());
                context.Load(listitems);
                context.ExecuteQuery();
                string candID;
                if (listitems.Count > 0)
                    candID = Convert.ToString(get_nextCandidateID(listitems) + 1);
                else
                    candID = "1000";
               // row["Current_Status"] = "Creating Folders";
                Folder folder = CreateFolderInternal(context.Web, doclist.RootFolder, candID + "_" + row["First_Name"]+"_"+ row["Last_Name"] + "/" + row["Job"]);
                //row["Current_Status"] = "Uploading Files";
                string[] files = Directory.GetFiles(Convert.ToString(row["Folder_path"]));
                await Task.Delay(1000);
                foreach (string filename in files)
                {
                    using (var fs = new FileStream(filename, FileMode.Open))
                    {
                        var fi = new FileInfo(filename);
                        //var list = clientContext.Web.Lists.GetByTitle(listTitle);
                        Folder targetFolder = context.Web.GetFolderByServerRelativeUrl(folder.ServerRelativeUrl);
                        context.Load(targetFolder);
                        context.ExecuteQuery();
                        var fileUrl = String.Format("{0}/{1}", targetFolder.ServerRelativeUrl, fi.Name);

                        Microsoft.SharePoint.Client.File.SaveBinaryDirect(context, fileUrl, fs, true);
                    }


                }
                
              //  row["Current_Status"] = "Adding Item";
                ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
                ListItem newItem = list.AddItem(itemCreateInfo);
                FieldLookupValue lval = await GetLookupValue(ctx, Convert.ToString(row["Job"]), "Job", "JobFullName", "Text", false);
                newItem["CandidateID"] = candID;
                newItem["First_name"] = Convert.ToString(row["First_Name"]);
                newItem["Last_name"] = Convert.ToString(row["Last_Name"]);
                newItem["JobSite"] = lval;
                newItem["Job"] = Convert.ToString(row["Job"]);
                newItem["DOB"] = Convert.ToString(row["DOB"]);
                // double percent = Convert.ToDouble(no_of_passes) / Convert.ToDouble(dt.Rows.Count);
                // string hireStatus = "";
                newItem["Hire_Status"] = Convert.ToString(row["Pass_Status"]);
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
                string tempFolderurl = folder.ServerRelativeUrl;
                FieldUrlValue _url = new FieldUrlValue();
                _url.Url = tempFolderurl.Substring(0, tempFolderurl.LastIndexOf('/')); ;
                _url.Description = "View Tests";
                newItem["FolderUrl"] = _url;
                newItem["Remaining_Test"] = Convert.ToString(row["Remaining_Test"]);
                newItem["Category"] = Convert.ToString(row["Position"]); ;
                //newItem["FolderUrl"] = folder.ServerRelativeUrl;
                newItem.Update();
                context.Load(list);
                context.ExecuteQuery();
                await Task.Delay(1000);
                // row["Current_Status"] = "Uploaded";
                
                XmlNode deleteNode = read_local_data_store(xmlDoc, row);
                if(deleteNode!=null)
                {
                    deleteNode.ParentNode.RemoveChild(deleteNode);

                }

                await Task.Delay(1000);
                xmlDoc.Save(get_local_data_path() + cmbxJobList.SelectedValue + "\\" + "History.xml");
               

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                

            }

        }


        private async Task upload_RC_Candidates(DataRow row, Microsoft.SharePoint.Client.ClientContext context, Microsoft.SharePoint.Client.List doclist, Microsoft.SharePoint.Client.List list)
        {
            try
            {
                Folder folder = CreateFolderInternal(context.Web, doclist.RootFolder, row["CandidateID"] + "_" + row["First_Name"] + "_" + row["Last_Name"] + "/" + row["Job"]);
                string[] files = Directory.GetFiles(Convert.ToString(row["Folder_path"]));
                await Task.Delay(1000);
                foreach (string filename in files)
                {
                    using (var fs = new FileStream(filename, FileMode.Open))
                    {
                        var fi = new FileInfo(filename);
                        //var list = clientContext.Web.Lists.GetByTitle(listTitle);
                        Folder targetFolder = context.Web.GetFolderByServerRelativeUrl(folder.ServerRelativeUrl);
                        context.Load(targetFolder);
                        context.ExecuteQuery();
                        var fileUrl = String.Format("{0}/{1}", targetFolder.ServerRelativeUrl, fi.Name);

                        Microsoft.SharePoint.Client.File.SaveBinaryDirect(context, fileUrl, fs, true);
                    }


                }
                Microsoft.SharePoint.Client.ListItemCollection listitems = list.GetItems(CreateCandidateQuery(Convert.ToString(row["CandidateID"]), Convert.ToString(row["First_Name"])));
                context.Load(listitems);
                context.ExecuteQuery();
                FieldLookupValue lval = await GetLookupValue(ctx, Convert.ToString(row["Job"]), "Job", "JobFullName", "Text", false);
                foreach (ListItem oListItem in listitems)
                {



                    oListItem["JobSite"] = lval;
                    oListItem["Job"] = Convert.ToString(row["Job"]);
                    //double percent = Convert.ToDouble(no_of_passes) / Convert.ToDouble(dt.Rows.Count);
                    //if (percent >= 0.7 && percent < 1.0)
                    //    oListItem["Hire_Status"] = "Conditional Hire";
                    //else
                    //    oListItem["Hire_Status"] = "Hired";
                    oListItem["Hire_Status"] = Convert.ToString(row["Pass_Status"]);
                    string tempFolderurl = folder.ServerRelativeUrl;
                    FieldUrlValue _url = new FieldUrlValue();
                    _url.Url = tempFolderurl.Substring(0, tempFolderurl.LastIndexOf('/')); ;
                    _url.Description = "View Tests";
                    oListItem["FolderUrl"] = _url;
                    oListItem["Remaining_Test"] = Convert.ToString(row["Remaining_Test"]);
                    oListItem["Category"] = Convert.ToString(row["Position"]);
                    //newItem["FolderUrl"] = folder.ServerRelativeUrl;

                    oListItem.Update();
                    context.Load(oListItem);
                    context.ExecuteQuery();


                }
                await Task.Delay(1000);
                XmlNode deleteNode = read_local_data_store(xmlDoc, row);
                if (deleteNode != null)
                {
                    deleteNode.ParentNode.RemoveChild(deleteNode);

                }
                await Task.Delay(1000);
                xmlDoc.Save(get_local_data_path() + cmbxJobList.SelectedValue + "\\" + "History.xml");


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }

        private XmlNode read_local_data_store(XmlDocument xmlDoc, DataRow row)
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
                XmlNode Upload_Status = node.SelectSingleNode("//Upload_Status");
                string f_name = First_Name.InnerText;
                string l_name = Last_Name.InnerText;
                string _job = Job.InnerText;
                string _dob = DOB.InnerText;
                string cName = f_name + "_" + l_name;
                string test_date = Test_Date.InnerText;
                string upload_status = Upload_Status.InnerText;
                if (cName == row["First_Name"] + "_" + row["Last_Name"] && _job == Convert.ToString(row["Job"]) && _dob == Convert.ToString(row["DOB"]) && test_date == Convert.ToString(row["TestDate"]) && upload_status==Convert.ToString(row["Upload_Status"]))
                {
                    searchNode = node;
                   
                    return searchNode;
                }
              

            }
            
            return searchNode;
           

        }

        private void lbl_Pass_Status_plcHolder_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        public CamlQuery CreateCandidateQuery(string candidateID, string fname)
        {
            var qry = new CamlQuery();
            qry.ViewXml = "<View><Query><Where><And><Eq><FieldRef Name='CandidateID' /><Value Type='Text'>" + candidateID + "</Value></Eq><Eq><FieldRef Name='First_name' /><Value Type='Text'>" + fname + "</Value></Eq></And></Where></Query></View>";
            return qry;
        }

        private void upload_results_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void upload_results_Shown(object sender, EventArgs e)
        {
            wait_form.Hide();
            wait_form.Close();
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
