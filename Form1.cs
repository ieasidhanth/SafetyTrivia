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
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Globalization;

using OnBarcode.Barcode.WinForms;
using System.Drawing.Imaging;
namespace Quizzed
{
    public partial class Login : Form
    {
        public string spJobsite;
        public string O365UserName;
        public SecureString O365Password;
        public string JobListName;
        public string CandidateList;
        public string spCandidateSite;
        public DataTable candidates;
        private DataRow selected_candidate_row;
        private BackgroundWorker worker;
        private LogWriter logger;
        private QRCodeWinForm qrcode;

        public Login()
        {
            InitializeComponent();
            logger = new LogWriter("Login Form Opened");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es");
            DSL obj = new DSL();
            DataTable category= obj.getCategories();
            DataRow cat_row = category.NewRow();
            cat_row["CategoryID"] = -1;
            cat_row["CategoryName"] = "--Select--";
            category.Rows.InsertAt(cat_row, 0);
            cmxCategory.DataSource = category;
            cmxCategory.DisplayMember = "CategoryName";
            cmxCategory.ValueMember = "CategoryID";
            DataTable categoryRC = obj.getCategories();
            DataRow categoryRC_row = categoryRC.NewRow();
            categoryRC_row["CategoryID"] = -1;
            categoryRC_row["CategoryName"] = "--Select--";
            categoryRC.Rows.InsertAt(categoryRC_row, 0);
            cmbxPositionRC.DataSource = categoryRC;
            cmbxPositionRC.DisplayMember = "CategoryName";
            cmbxPositionRC.ValueMember = "CategoryID";
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            // worker.RunWorkerAsync();
            qrcode = new QRCodeWinForm();
            QRCode_Panel.Controls.Add(qrcode);
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            spJobsite = Convert.ToString(config.AppSettings.Settings["SharePointJobSite"].Value);
            spCandidateSite= Convert.ToString(config.AppSettings.Settings["SharePointSafetySite"].Value);
            CandidateList= Convert.ToString(config.AppSettings.Settings["quizListName"].Value);
            O365UserName = Convert.ToString(config.AppSettings.Settings["O365UserName"].Value);
            string tempString = config.AppSettings.Settings["O365Password"].Value;
            O365Password = new SecureString();
            candidates = new DataTable();
            candidates.Columns.Add("CandidateID", typeof(string));
            candidates.Columns.Add("First_name", typeof(string));
            candidates.Columns.Add("Last_name", typeof(string));
            candidates.Columns.Add("Job", typeof(string));
            candidates.Columns.Add("Hire_Status", typeof(string));
            candidates.Columns.Add("FolderURL", typeof(string));
            candidates.Columns.Add("Remaining_Test", typeof(string));
            candidates.Columns.Add("DisplayCombobox", typeof(string));
            candidates.Columns.Add("Category", typeof(string));
            candidates.Columns.Add("Date", typeof(string));
            candidates.Columns.Add("DOB", typeof(string));
            foreach (char c in tempString)
            {
                O365Password.AppendChar(c);
            }
            
            JobListName= Convert.ToString(config.AppSettings.Settings["jobListName"].Value);
            using (Microsoft.SharePoint.Client.ClientContext context = new Microsoft.SharePoint.Client.ClientContext(spJobsite))
            {
                try
                {
                    context.Credentials = new Microsoft.SharePoint.Client.SharePointOnlineCredentials(O365UserName, O365Password);
                    context.Load(context.Web, w => w.Title);
                    context.ExecuteQuery();
                    Microsoft.SharePoint.Client.List list = context.Web.Lists.GetByTitle(JobListName);
                    context.Load(list);

                    Microsoft.SharePoint.Client.ListItemCollection listitems = list.GetItems(Microsoft.SharePoint.Client.CamlQuery.CreateAllItemsQuery());
                    context.Load(listitems);
                    context.ExecuteQuery();
                    foreach (Microsoft.SharePoint.Client.ListItem item in listitems)
                    {
                        cmxJobList.Items.Add(item["JobNumber"] + " - " + item["Title"]);

                    }
                    cmxJobList.Items.Insert(0, "--Select--");
                    logger.LogWrite("JobComboBox Populated");

                }
                catch (Exception ex)
                {
                    logger.LogWrite("JobComboBox Population Failed");
                    logger.LogWrite(ex.StackTrace);

                }
                
                

            }
            using (Microsoft.SharePoint.Client.ClientContext context = new Microsoft.SharePoint.Client.ClientContext(spCandidateSite))
            {
                context.Credentials = new Microsoft.SharePoint.Client.SharePointOnlineCredentials(O365UserName, O365Password);
                context.Load(context.Web, w => w.Title);
                context.ExecuteQuery();
                Microsoft.SharePoint.Client.List list = context.Web.Lists.GetByTitle(CandidateList);
                context.Load(list);

                Microsoft.SharePoint.Client.ListItemCollection listitems = list.GetItems(Microsoft.SharePoint.Client.CamlQuery.CreateAllItemsQuery());
                context.Load(listitems);
                context.ExecuteQuery();
                DataRow row_select = candidates.NewRow();
                row_select["DisplayCombobox"] = "--Select--";
                row_select["CandidateID"] = -1;
                candidates.Rows.Add(row_select);
                foreach (Microsoft.SharePoint.Client.ListItem item in listitems)
                {
                    // cmbxCandidateList.Items.Add(item["CandidateID"] + " - " + item["First_name"]+"_"+item["Last_name"]);
                    DataRow row = candidates.NewRow();
                    row["CandidateID"] = item["CandidateID"];
                    row["First_name"] = item["First_name"];
                    row["Last_name"] = item["Last_name"];
                    row["Job"] = item["Job"];
                    row["Hire_Status"] = item["Hire_Status"];
                    Microsoft.SharePoint.Client.FieldUrlValue _url = (Microsoft.SharePoint.Client.FieldUrlValue)item["FolderUrl"];
                    row["FolderUrl"] = _url.Url;
                    row["Remaining_Test"] = item["Remaining_Test"];
                    row["DisplayCombobox"] = item["CandidateID"] + " - " + item["First_name"] + "_" + item["Last_name"];
                    row["Category"] = item["Category"];
                    row["Date"] = item["Modified"];
                    row["DOB"] = item["DOB"];
                    candidates.Rows.Add(row);

                }
                cmbxCandidateList.DataSource = candidates;
                //cmbxCandidateList.Items.Add(new { Text = "---Select---", Value = -1 });
                cmbxCandidateList.DisplayMember = "DisplayCombobox";
                cmbxCandidateList.ValueMember = "CandidateID";
                cmxJobList.SelectedIndex = 0;

            }
            
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //throw new NotImplementedException();
            if((bool)e.UserState==true)
            {
                //this.toolStripStatusLabel1.Text = "Connected";
            }
            else
            {
                //this.toolStripStatusLabel1.Text = "Offline";

            }
           
            //System.Diagnostics.Debug.WriteLine(e.UserState.ToString());

        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //throw new NotImplementedException();
            BackgroundWorker worker = sender as BackgroundWorker;

            bool connected = false;
            string url = "https://www.google.com/";

            while (!worker.CancellationPending)
            {
                //try
                //{
                    HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                    request.Timeout = 15000;
                    request.Credentials = CredentialCache.DefaultNetworkCredentials;
                    HttpWebResponse response1 = request.GetResponse() as HttpWebResponse;

                    connected = (response1.StatusCode == HttpStatusCode.OK);
                    worker.ReportProgress(10, connected);
                    Thread.Sleep(1000);

                //}
                //catch (Exception ex)
                //{
                //    System.Diagnostics.Debug.WriteLine(ex.ToString());
                //   // e.Cancel = true;
                //    //e.Result = "cancelled";
                //    //connected = false;
                //    //worker.ReportProgress(10, connected);

                //    //return false;
                //}
            }
            e.Result = connected;
        }

        private void AdjustWidthComboBox_DropDown(object sender, System.EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            int width = senderComboBox.DropDownWidth;
            Graphics g = senderComboBox.CreateGraphics();
            Font font = senderComboBox.Font;
            int vertScrollBarWidth =
                (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
                ? SystemInformation.VerticalScrollBarWidth : 0;

            int newWidth;
            foreach (string s in ((ComboBox)sender).Items)
            {
                newWidth = (int)g.MeasureString(s, font).Width
                    + vertScrollBarWidth;
                if (width < newWidth)
                {
                    width = newWidth;
                }
            }
            senderComboBox.DropDownWidth = width;
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnInitialisze_Click(object sender, EventArgs e)
        {
            
            DataTable dt;
            
            if (!rdBtnRCYes.Checked)
            {
                if (errorProvider1.GetError(txtBxFName) == "" && errorProvider2.GetError(txtBxLastName) == "")
                {
                    if (cmxCategory.SelectedIndex > 0)
                    {
                        if(cmxJobList.SelectedIndex>0)
                        {
                            this.Hide();
                            //Quiz newQuiz = new Quiz(txtBxFName.Text, txtBxLastName.Text, cmxJobList.SelectedItem.ToString(), cmxCategory.SelectedValue.ToString(),dtmDOB.Value.ToShortDateString());
                            //newQuiz.ShowDialog();

                        }
                        else
                        {
                            MessageBox.Show("Please select a Job");

                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Please select Applying For");
                    }

                }
                
            }
            else
            {
                if (Convert.ToInt32(cmbxCandidateList.SelectedValue) > 0)
                {
                    
                    dt = candidates.Copy();
                    dt.Rows.Clear();
                   // cmbxCandidateList.SelectedItem[""];
                    DataRowView rowView= (DataRowView)cmbxCandidateList.SelectedItem;
                    DataRow row = rowView.Row;
                    dt.ImportRow(row);
                    // dt.ImportRow((DataRowView)cmbxCandidateList.SelectedItem);
                    // dt = rowview.DataView.ToTable();
                    //MessageBox.Show(cmbxCandidateList.SelectedItem.ToString());
                    
                     Panel qListPanel= (Panel)this.Controls.Find("pnl_QuizList", true).FirstOrDefault();
                    //check if not conditional hire make list of remaining test
                    if(Convert.ToString(selected_candidate_row["Hire_Status"])!="Conditional Hire")
                    {
                        foreach (Control control in qListPanel.Controls)
                        {
                            CheckBox box = control as CheckBox;
                            if (box.CheckState == CheckState.Checked)
                            {
                                string temp_quizName = "QuizNo " + box.Name;
                                DataRow crow = dt.Rows[0];
                                if (!Convert.ToString(crow["Remaining_Test"]).Contains(temp_quizName))
                                {
                                    crow["Remaining_Test"] = Convert.ToString(crow["Remaining_Test"]) + temp_quizName + ":" + box.Tag + ";";
                                }



                            }

                            //if(test!="")
                            //{
                            //    string temp = test.Split(':')[0];
                            //    if(temp!="")
                            //    {
                            //        string checkBoxName = temp.Split(' ')[1];
                            //        CheckBox quizNo=(CheckBox)qListPanel.Controls[checkBoxName];
                            //        quizNo.Checked = true;
                            //    }

                            //}



                        }

                    }
                    
                    if(Convert.ToString(dt.Rows[0]["Remaining_Test"])!="" & Convert.ToString(dt.Rows[0]["Remaining_Test"])!=";")
                    {
                        this.Hide();
                       // Quiz_RC newQuizRC = new Quiz_RC(dt,dBa);
                       // newQuizRC.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Please select Quiz Set for Candidate " + dt.Rows[0]["CandidateID"] + " - " + dt.Rows[0]["First_name"] + "_" + dt.Rows[0]["Last_name"]);
                    }
                    

                }
                else
                {
                    MessageBox.Show("Please select a candidate.");

                }
            }

        }

        private void rdBtnRCNo_CheckedChanged(object sender, EventArgs e)
        {
            
                if (rdBtnRCNo.Checked)
                {
                    lblReturningCandidate.Visible = true;
                    cmbxCandidateList.Visible = false;
                    lblSelectCandidate.Visible = false;
                    lblFirstName.Visible = true;
                    txtBxFName.Visible = true;
                    lblLastName.Visible = true;
                    txtBxLastName.Visible = true;
                    lblSupervisor.Visible = true;
                    cmxCategory.Visible = true;
                    lblSelectJob.Visible = true;
                    cmxJobList.Visible = true;
                    lblfName.Visible = false;
                    lbllName.Visible = false;
                    cmxJobList.SelectedIndex = -1;
                    lblTestDetails.Visible = false;
                    panel_test_Status.Visible = false;
                    lblHireStatusPlcHolder.Visible = false;
                    lblHireStatus.Visible = false;
                    pnl_configureTest.Visible = false;
                    lblDOB.Visible = true;
                    dtmDOB.Visible = true;
                    dtmDOB.Text = DateTime.Now.ToShortDateString();





            }
           
          


        }

        private void rdBtnRCYes_CheckedChanged(object sender, EventArgs e)
        {
            if(rdBtnRCYes.Checked)
            {
                lblReturningCandidate.Visible = true;
                lblSelectCandidate.Visible = true;
                cmbxCandidateList.Visible = true;
                lblReturningCandidate.Visible = true;
                lblFirstName.Visible = false;
                txtBxFName.Visible = false;
                lblLastName.Visible = false;
                txtBxLastName.Visible = false;
                lblSupervisor.Visible = false;
                cmxCategory.Visible = false;
                lblSelectJob.Visible = false;
                lblDOB.Visible = false;
                dtmDOB.Visible = false;
                cmxJobList.Visible = false;
                lblHireStatus.Visible = false;
                lblHireStatusPlcHolder.Visible = false;
                cmxJobList.SelectedIndex = -1;
                cmbxCandidateList.SelectedIndex = 0;

            }
        }
        public Microsoft.SharePoint.Client.CamlQuery CreateCandidateQuery()
        {
            var qry = new Microsoft.SharePoint.Client.CamlQuery();
            qry.ViewXml =
               @"<View>
         <Query>
          <Where>
            <BeginsWith>
              <FieldRef Name='Hire_Status' />
              <Value Type='Text'>" + "Conditional Hire" + @"</Value>
            </BeginsWith>
          </Where>
        </Query>
       </View>";
            return qry;
        }

        private void lblReturningCandidate_Click(object sender, EventArgs e)
        {

        }
        protected void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox bx = sender as CheckBox;
            
           // if(Convert.ToString(selected_candidate_row["Hire_Status"])=="Conditional Hire")
        }

        private void cmbxCandidateList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(cmbxCandidateList.SelectedIndex>0)
            //{
                
            //    this.llViewHistory.Links.RemoveAt(0);
            //    cmbxPositionRC.SelectedIndex = 0;
            //    pnl_QuizList.Controls.Clear();
            //    pnl_configureTest.Visible = true;
            //    txtBox_remaining_tst.Text = "";
            //    lblTestCountPlcHldr.Text = "";
            //    lblFirstName.Visible = true;
            //    lblLastName.Visible = true;
            //    lblfName.Visible = true;
            //    lbllName.Visible = true;
            //    lblSelectJob.Visible = true;
            //    cmxJobList.Visible = true;
            //    lblTestDetails.Visible = true;
            //    panel_test_Status.Visible = true;
            //    lblHireStatusPlcHolder.Visible = true;
            //    lblHireStatus.Visible = true;
            //    DataRowView rowView = (DataRowView)cmbxCandidateList.SelectedItem;
            //    selected_candidate_row = rowView.Row;
            //    lblfName.Text = Convert.ToString(selected_candidate_row["First_name"]);
            //    lbllName.Text = Convert.ToString(selected_candidate_row["Last_name"]);
            //    string job= Convert.ToString(selected_candidate_row["Job"]);
            //    lblLastDateTime.Text = Convert.ToString(selected_candidate_row["Date"]);
            //    lblHireStatusPlcHolder.Text= Convert.ToString(selected_candidate_row["Hire_Status"]);
            //    foreach (var item in cmxJobList.Items)
            //    {
                    
            //        if (Convert.ToString(item) == job)
            //        {
            //            cmxJobList.SelectedItem = item;
            //            break;

            //        }
                        

            //    }
            //    lblLastJob.Text= Convert.ToString(selected_candidate_row["Job"]);
            //    llViewHistory.Links.Add(0, llViewHistory.Text.Length, Convert.ToString(selected_candidate_row["FolderURL"]));
            //    lblPositionPlcHlder.Text = Convert.ToString(selected_candidate_row["Category"]);
            //    string[] remaining_test = Convert.ToString(selected_candidate_row["Remaining_Test"]).Split(';');
            //    int count_remaining_test = 0;
            //    if(remaining_test.Count()>0)
            //    {
            //        foreach(string test in remaining_test)
            //        {
            //            if(test!="")
            //            {
            //                txtBox_remaining_tst.AppendText(test + "\n");
            //                count_remaining_test++;

            //            }
                        
            //        }
            //        lblTestCountPlcHldr.Text = Convert.ToString(count_remaining_test);

            //    }
            //    else
            //    {
            //        txtBox_remaining_tst.AppendText("No Remaining Test");
            //        lblTestCountPlcHldr.Text = "0";
            //    }
            //    string previous_pos = lblPositionPlcHlder.Text;
            //    if (Convert.ToString(selected_candidate_row["Hire_Status"]) == "Conditional Hire")
            //    {
            //        cmbxPositionRC.Enabled = false;

            //    }
            //    else
            //    {
            //        cmbxPositionRC.Enabled = true;

            //    }
            //    DSL obj = new DSL();
            //    DataTable Quiz = obj.get_all_quizes();
            //    CheckBox box;
            //    int i = 1;
                
            //    foreach(DataRow Quizrow in Quiz.Rows)
            //    {
            //        box = new CheckBox();
            //        box.Tag = Convert.ToString(Quizrow["QuizDescription"]);
            //        box.Name= Convert.ToString(Quizrow["Quiz"]);
                    
            //        box.Text = "Quiz"+i;
            //        box.AutoSize = true;
            //        pnl_QuizList.Controls.Add(box);
            //        i++;
            //        ToolTip toolTip1 = new ToolTip();
            //        box.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            //        // Set up the delays for the ToolTip.
            //        toolTip1.AutoPopDelay = 5000;
            //        toolTip1.InitialDelay = 1000;
            //        toolTip1.ReshowDelay = 500;
            //        // Force the ToolTip text to be displayed whether or not the form is active.
            //        toolTip1.ShowAlways = true;

            //        // Set up the ToolTip text for the Button and Checkbox.
            //        toolTip1.SetToolTip(box, Convert.ToString(Quizrow["QuizDescription"]));
            //        if (Convert.ToString(selected_candidate_row["Hire_Status"]) == "Conditional Hire")
            //            box.Enabled = false;
                    



            //    }
            //    if(count_remaining_test>0)
            //    {
                    
            //        Panel qListPanel= (Panel)this.Controls.Find("pnl_QuizList", true).FirstOrDefault();
            //        //qListPanel.Controls.Clear();
            //        foreach(Control control in qListPanel.Controls)
            //        {
                        
            //            foreach(string test in remaining_test)
            //            {
            //                if(test!="")
            //                {
            //                    string temp = test.Split(':')[0];
            //                    if(temp!="")
            //                    {
            //                        string checkBoxName = temp.Split(' ')[1];
            //                        CheckBox quizNo=(CheckBox)qListPanel.Controls[checkBoxName];
            //                        quizNo.Checked = true;
            //                    }

            //                }
            //            }

            //        }

            //    }


            //}
        }

        private void cmbxPositionRC_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(cmbxPositionRC.SelectedIndex>0)
            //{
            //    DSL obj = new DSL();
            //    string[] qList= obj.get_quiz_List(Convert.ToInt32(cmbxPositionRC.SelectedValue)).Split('#');

            //    int i = 1;//quiz_id_starting no
            //    foreach(Control control in pnl_QuizList.Controls)
            //    {
            //        CheckBox quizNo = (CheckBox)pnl_QuizList.Controls.Find(i.ToString(),true).FirstOrDefault();
            //        quizNo.Checked = false;
            //        i++;

            //    }
            //    foreach(string quiz in qList)
            //    {
            //        CheckBox quizNo = (CheckBox)pnl_QuizList.Controls[quiz];
            //        quizNo.Checked = true;

            //    }
            //    switch(Convert.ToString(cmbxPositionRC.SelectedValue))
            //    {
            //        case "1":
            //            selected_candidate_row["Category"] = "Standard";
            //            break;
            //        case "2":
            //            selected_candidate_row["Category"] = "Subcontactor";
            //            break;
            //        case "3":
            //            selected_candidate_row["Category"] = "Superitendent";
            //            break;

            //    }
                

            //}
        }

        private void llViewHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sinfo = new ProcessStartInfo(e.Link.LinkData.ToString());
            Process.Start(sinfo);
        }

        private void cmxJobList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
        }

        private void cmxJobList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmxJobList.SelectedIndex > 0 && rdBtnRCYes.Checked)
            {
                selected_candidate_row["Job"] = cmxJobList.SelectedItem;
            }

        }

        private void cmbxCandidateList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbxCandidateList.SelectedIndex > 0)
            {
                
                this.llViewHistory.Links.RemoveAt(0);
                cmbxPositionRC.SelectedIndex = 0;
                pnl_QuizList.Controls.Clear();
                pnl_configureTest.Visible = true;
                txtBox_remaining_tst.Text = "";
                lblTestCountPlcHldr.Text = "";
                lblFirstName.Visible = true;
                lblLastName.Visible = true;
                lblfName.Visible = true;
                lbllName.Visible = true;
                lblDOB.Visible = true;
                dtmDOB.Visible = true;
                
                dtmDOB.Text = "";
                lblSelectJob.Visible = true;
                cmxJobList.Visible = true;
                lblTestDetails.Visible = true;
                panel_test_Status.Visible = true;
                lblHireStatusPlcHolder.Visible = true;
                lblHireStatus.Visible = true;
                DataRowView rowView = (DataRowView)cmbxCandidateList.SelectedItem;
                selected_candidate_row = rowView.Row;
                lblfName.Text = Convert.ToString(selected_candidate_row["First_name"]);
                lbllName.Text = Convert.ToString(selected_candidate_row["Last_name"]);
                string job = Convert.ToString(selected_candidate_row["Job"]);
                lblLastDateTime.Text = Convert.ToString(selected_candidate_row["Date"]);
                lblHireStatusPlcHolder.Text = Convert.ToString(selected_candidate_row["Hire_Status"]);
                dtmDOB.Format =DateTimePickerFormat.Short;
                if(Convert.ToString(selected_candidate_row["DOB"])=="")
                {
                    dtmDOB.CustomFormat = " ";
                    dtmDOB.Format = DateTimePickerFormat.Custom;

                }
                else
                {
                    dtmDOB.Text = Convert.ToString(selected_candidate_row["DOB"]);

                }
                
                foreach (var item in cmxJobList.Items)
                {

                    if (Convert.ToString(item) == job)
                    {
                        cmxJobList.SelectedItem = item;
                        break;

                    }


                }
                lblLastJob.Text = Convert.ToString(selected_candidate_row["Job"]);
                llViewHistory.Links.Add(0, llViewHistory.Text.Length, Convert.ToString(selected_candidate_row["FolderURL"]));
                qrcode.Data = Convert.ToString(selected_candidate_row["FolderURL"]);
                qrcode.DataMode = OnBarcode.Barcode.QRCodeDataMode.Auto;
                qrcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                qrcode.drawBarcode();

                
                
                Size s = new Size(75, 75);
                qrcode.Size = s;
                QRCode_Panel.Controls.Add(qrcode);
                
                
                lblPositionPlcHlder.Text = Convert.ToString(selected_candidate_row["Category"]);
                string[] remaining_test = Convert.ToString(selected_candidate_row["Remaining_Test"]).Split(';');
                int count_remaining_test = 0;
                if (remaining_test.Count() > 0)
                {
                    foreach (string test in remaining_test)
                    {
                        if (test != "")
                        {
                            txtBox_remaining_tst.AppendText(test + "\n");
                            count_remaining_test++;

                        }

                    }
                    lblTestCountPlcHldr.Text = Convert.ToString(count_remaining_test);

                }
                else
                {
                    txtBox_remaining_tst.AppendText("No Remaining Test");
                    lblTestCountPlcHldr.Text = "0";
                }
                string previous_pos = lblPositionPlcHlder.Text;
                if (Convert.ToString(selected_candidate_row["Hire_Status"]) == "Conditional Hire")
                {
                    cmbxPositionRC.Enabled = false;
                    cmxJobList.Enabled = false;

                }
                else
                {
                    cmbxPositionRC.Enabled = true;
                    cmxJobList.Enabled = true;

                }
                DSL obj = new DSL();
                DataTable Quiz = obj.get_all_quizes();
                CheckBox box;
                int i = 1;

                foreach (DataRow Quizrow in Quiz.Rows)
                {
                    box = new CheckBox();
                    box.Tag = Convert.ToString(Quizrow["QuizDescription"]);
                    box.Name = Convert.ToString(Quizrow["Quiz"]);

                    box.Text = "Quiz" + i;
                    box.AutoSize = true;
                    pnl_QuizList.Controls.Add(box);
                    i++;
                    ToolTip toolTip1 = new ToolTip();
                    box.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
                    // Set up the delays for the ToolTip.
                    toolTip1.AutoPopDelay = 5000;
                    toolTip1.InitialDelay = 1000;
                    toolTip1.ReshowDelay = 500;
                    // Force the ToolTip text to be displayed whether or not the form is active.
                    toolTip1.ShowAlways = true;

                    // Set up the ToolTip text for the Button and Checkbox.
                    toolTip1.SetToolTip(box, Convert.ToString(Quizrow["QuizDescription"]));
                    if (Convert.ToString(selected_candidate_row["Hire_Status"]) == "Conditional Hire")
                        box.Enabled = false;




                }
                if (count_remaining_test > 0)
                {

                    Panel qListPanel = (Panel)this.Controls.Find("pnl_QuizList", true).FirstOrDefault();
                    //qListPanel.Controls.Clear();
                    foreach (Control control in qListPanel.Controls)
                    {

                        foreach (string test in remaining_test)
                        {
                            if (test != "")
                            {
                                string temp = test.Split(':')[0];
                                if (temp != "")
                                {
                                    string checkBoxName = temp.Split(' ')[1];
                                    CheckBox quizNo = (CheckBox)qListPanel.Controls[checkBoxName];
                                    quizNo.Checked = true;
                                }

                            }
                        }

                    }

                }


            }

        }

        private void cmbxPositionRC_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbxPositionRC.SelectedIndex > 0)
            {
                DSL obj = new DSL();
                string[] qList = obj.get_quiz_List(Convert.ToInt32(cmbxPositionRC.SelectedValue)).Split('#');

                int i = 1;//quiz_id_starting no
                foreach (Control control in pnl_QuizList.Controls)
                {
                    CheckBox quizNo = (CheckBox)pnl_QuizList.Controls.Find(i.ToString(), true).FirstOrDefault();
                    quizNo.Checked = false;
                    i++;

                }
                foreach (string quiz in qList)
                {
                    CheckBox quizNo = (CheckBox)pnl_QuizList.Controls[quiz];
                    quizNo.Checked = true;

                }
                switch (Convert.ToString(cmbxPositionRC.SelectedValue))
                {
                    case "1":
                        selected_candidate_row["Category"] = "Standard";
                        break;
                    case "2":
                        selected_candidate_row["Category"] = "Subcontactor";
                        break;
                    case "3":
                        selected_candidate_row["Category"] = "Superitendent";
                        break;

                }


            }

        }

        private void txtBxFName_Validating(object sender, CancelEventArgs e)
        {
            TextBox tbx = sender as TextBox;
            try
            {
                if(tbx.Text=="")
                {
                    errorProvider1.SetError(tbx, "Please enter First name");

                }
                else
                {
                    errorProvider1.SetError(tbx, "");

                }
                
            }
            catch (Exception ex)
            {
                //errorProvider1.SetError(textBox1, "Not an integer value.");
            }


        }
        

        private void txtBxLastName_Validating(object sender, CancelEventArgs e)
        {
            TextBox tbx = sender as TextBox;
            try
            {
                if (tbx.Text == "")
                {
                    errorProvider2.SetError(tbx, "Please enter Last name");

                }
                else
                {
                    errorProvider2.SetError(tbx, "");

                }

            }
            catch (Exception ex)
            {
                //errorProvider1.SetError(textBox1, "Not an integer value.");
            }

        }

        private void Login_Shown(object sender, EventArgs e)
        {
           
            
        }
    }
}
