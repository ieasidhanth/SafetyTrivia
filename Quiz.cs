using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Security.AccessControl;
using System.Resources;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;
using System.Xml;

namespace Quizzed
{
    public partial class Quiz : Form
    {
        //private DSL dslObj;
        private DSL_offline dslObj;
        private DataTable qBank;
        private int QuizNo;
        private DataTable tabQuestionBank;
        private int tabAttemptCount;
        private int currentQuestionIndex;
        private Boolean currentQuestionAnswered;
        private DataTable tabResponses;
        private int maxQuizResponse;
        private string name;
        private string jobName;
        private bool previous_quiz_Comleted;
        private List<int> lockedQuiz;
        private DataTable quizResults;
        private int count_failed_quiz;
        private int total_quiz;
        private int max_fail_quiz;
        private string pos_category;
        private string pos_category_name;
        private List<int> testIds;
        private DataTable VideoLinks;
        private string DOB;
        private DataSet dBank;
        private string siteURL;
        private int max_progress_bar;
        private ProgressBar bar;
        public Quiz(string fname,string lname, string job, string category,string dob, DataSet DataBank,string sURL)
        {
            InitializeComponent();
            dBank = DataBank;
            pos_category = category;
            siteURL = sURL;
            



            testIds = new List<int>();
            
            count_failed_quiz = 0;
            currentQuestionIndex = 0;
            currentQuestionAnswered = false;
            tabAttemptCount = 1;
            lblName.Text = fname + " " + lname;
            lblJobName.Text = job;
            name = fname + "_" + lname;
            jobName = job;
            DOB = dob;
            previous_quiz_Comleted = false;
            lockedQuiz = new List<int>();
            quizResults = new DataTable();
            quizResults.Columns.Add("FirstName", typeof(string));
            quizResults.Columns.Add("LastName", typeof(string));
            quizResults.Columns.Add("Job", typeof(string));
            quizResults.Columns.Add("QuizNumber", typeof(string));
            quizResults.Columns.Add("QuizName", typeof(string));
            quizResults.Columns.Add("Status", typeof(string));
            quizResults.Columns.Add("filePath", typeof(string));
            if(category=="1")
            {
                pos_category_name = "Standard";

            }
            else if(category=="2")
            {
                pos_category_name = "Subcontractor";


            }
            else
            {
                pos_category_name = "Superitendent";

            }
            lblPositionPlcHldr.Text = pos_category_name;

        }

        private void Quiz_Load(object sender, EventArgs e)
        {
            tbcontrolQuizzes.TabPages.Clear();
            
            // TODO: This line of code loads data into the 'quizzedDataSet.QuestionBank' table. You can move, or remove it, as needed.
           // this.questionBankTableAdapter.Fill(this.quizzedDataSet.QuestionBank);
            //dslObj = new DSL();
            dslObj = new DSL_offline();
            // qBank = dslObj.getallQuestions();
            // int quizCount = dslObj.getQuizCount();
            qBank = dslObj.getallQuestionsByCategory(pos_category);
            //get video links
            VideoLinks = dslObj.get_QuizLinks();
            TabControl tb_Videos = (TabControl)flwPanl_links.Controls["tbControlVidLinks"];
            FlowLayoutPanel flwoffline = (FlowLayoutPanel)tb_Videos.TabPages[0].Controls[0];
            FlowLayoutPanel flwonline = (FlowLayoutPanel)tb_Videos.TabPages[1].Controls[0];
            string VideoPath = AppDomain.CurrentDomain.BaseDirectory+"Videos\\";
            int QuizIndex = 1;
            panel1.AutoScrollPosition = new Point(0, 0);
            foreach (DataRow video in VideoLinks.Rows)
            {
                
                LinkLabel lbl = new LinkLabel();
                LinkLabel lbl2 = new LinkLabel();
                lbl2.Text= Convert.ToString(video["Link_text"]) + Environment.NewLine;
                lbl2.Links.Add(0, lbl2.Text.Length, VideoPath+Convert.ToString("Quiz"+QuizIndex)+".mp4");
                lbl2.LinkClicked += Lbl_LinkClicked;
                lbl.Text = Convert.ToString(video["Link_text"])+ Environment.NewLine;
                lbl.LinkClicked += Lbl_LinkClicked;
                lbl.Links.Add(0,lbl.Text.Length,Convert.ToString(video["Vid_Link"]));
                //flwPanl_links.Controls.Add(lbl)
                flwoffline.Controls.Add(lbl2);
                flwonline.Controls.Add(lbl);
                QuizIndex++;

            }
           // max_fail_quiz = Convert.ToInt32(Math.Floor(.30 * total_quiz));
            //max_fail_quiz = Convert.ToInt32((.30 * total_quiz));
            foreach (DataRow qrow in qBank.Rows)
            {
                if(!testIds.Contains(Convert.ToInt32(qrow["QuizNumber"])))
                {
                    testIds.Add(Convert.ToInt32(qrow["QuizNumber"]));

                }
            }
            QuizNo = testIds[0];
            int quizCount = testIds.Count();
            total_quiz = quizCount;
            max_fail_quiz = Convert.ToInt32(Math.Floor(.30 * total_quiz));
            TabPage[] tabarray = new TabPage[quizCount+1];
            
            int i = 0;
            foreach(int test in testIds)
                {
                    tabarray[i] = new TabPage("Quiz" + Convert.ToString(test));
                    Panel qpanel = new Panel();
                qpanel.BorderStyle = BorderStyle.None;
                    tabarray[i].Name = "Quiz " + test;
                tabarray[i].ForeColor = Color.FromArgb(28, 52, 60);
                tabarray[i].BorderStyle = BorderStyle.None;
                tabarray[i].BackColor = Color.FromArgb(224, 237, 241);
                qpanel.Name = "pnl_tab_Quiz_Questions" + Convert.ToString(i + 1);
                    qpanel.Location = new System.Drawing.Point(10, 0);
                    //qpanel.BackColor = Color.CadetBlue;
                    qpanel.Width = 1468;
                    qpanel.Height = 150;
                    qpanel.BackColor = Color.FromArgb(224, 237, 241);
                    //qpanel.Anchor = AnchorStyles.Bottom;
                    //qpanel.Anchor = AnchorStyles.Top;
                qpanel.Controls.Add(new Label() { Name = "pnl_tab_Quiz_Questions_lbl_QHeading" + Convert.ToString(i + 1), Text = "QHeading", Location = new System.Drawing.Point(7, 16), Margin = new Padding(3, 0, 3, 0), Font = new System.Drawing.Font("Verdana", 28, FontStyle.Bold, GraphicsUnit.Pixel), AutoSize = true,ForeColor= Color.FromArgb(28, 52, 60) });
                    qpanel.Controls.Add(new Label() { Name = "pnl_tab_Quiz_Questions_lbl_QNo" + Convert.ToString(i + 1), Text = "QNo", Location = new System.Drawing.Point(12, 70), Margin = new Padding(3, 0, 3, 0), Font = new System.Drawing.Font("Verdana", 15,FontStyle.Bold, GraphicsUnit.Pixel), AutoSize = true });
                    qpanel.Controls.Add(new Label() { Name = "pnl_tab_Quiz_Questions_lbl_Q" + Convert.ToString(i + 1), Text = "Questions", Location = new System.Drawing.Point(80, 70), Margin = new Padding(10, 0, 3, 0), Font = new System.Drawing.Font("Verdana", 16, FontStyle.Bold, GraphicsUnit.Pixel), AutoSize = true, MaximumSize = new Size(100, 150) });
                    qpanel.Controls.Add(new Label() { Name = "pnl_tab_Quiz_Questions_QID" + Convert.ToString(i + 1), Text = "ID", Location = new System.Drawing.Point(750, 70), Margin = new Padding(3, 0, 3, 0),Visible=false, Font = new System.Drawing.Font("Verdana", 10, GraphicsUnit.Pixel), AutoSize = true, MaximumSize = new Size(100, 100) });
                    tabarray[i].Controls.Add(qpanel);
                    tabarray[i].Controls.Add(new Panel() { Name = "pnl_tab_Quiz_Answers" + Convert.ToString(i + 1), Location = new System.Drawing.Point(10, 150), Width = 1472, Height = 300,BackColor= Color.FromArgb(224, 237, 241) });

                    Panel navPanel = new Panel();
                    navPanel.Name = "pnl_tab_Quiz_Navigation" + Convert.ToString(i + 1);
                    navPanel.Location = new System.Drawing.Point(10, 400);
                    //navPanel.BackColor = Color.GreenYellow;
                    navPanel.Width = 1472;
                    navPanel.Height = 300;
                    navPanel.Margin = new Padding(50);
                    navPanel.BackColor = Color.FromArgb(224, 237, 241);
                    Button prev_button = new Button();
                    prev_button.Name = "btn_pnl_" + Convert.ToString(i + 1) + "_prev";
                    prev_button.Text = "Previous Question";
                    prev_button.AutoSize = true;
                    prev_button.Location = new Point(150, 100);
                    prev_button.Size = new Size(100, 25);
                    prev_button.Hide();
                    // prev_button.ForeColor = Color.Black;
                    //prev_button.BackColor = Color.White;
                    //next_button.Margin = new Padding(3, 3, 3, 3);
                    prev_button.Visible = true;
                    prev_button.Show();
                    prev_button.Click += new EventHandler(previous_Click);
                    Button next_button = new Button();
                    next_button.Name = "btn_pnl_" + Convert.ToString(i + 1) + "_next";
                    next_button.Text = "Next Question";
                    next_button.AutoSize = true;
                    next_button.Location = new Point(10, 100);
                    next_button.Size = new Size(150, 40);
                    next_button.Font= new System.Drawing.Font("Verdana", 12, FontStyle.Bold, GraphicsUnit.Pixel);
                    next_button.ForeColor = Color.FromArgb(28, 52, 60);
                next_button.BackColor = Color.FromArgb(255, 246, 236);
                    //next_button.Margin = new Padding(3, 3, 3, 3);
                    next_button.Visible = true;
                    next_button.Show();
                    next_button.Click += new EventHandler(NextButton_Click);
                    Button proceed = new Button();
                    proceed.Name = "btn_pnl_" + Convert.ToString(i + 1) + "_proceed";
                    proceed.Text = "Submit";
                    proceed.AutoSize = true;
                    proceed.Location = new Point(450, 100);
                    proceed.Size = new Size(150, 40);
                    proceed.Font = new System.Drawing.Font("Verdana", 12, FontStyle.Bold, GraphicsUnit.Pixel);
                    proceed.ForeColor = Color.FromArgb(28, 52, 60);
                proceed.BackColor = Color.FromArgb(255, 246, 236);
                //next_button.Margin = new Padding(3, 3, 3, 3);
                proceed.Visible = true;
                    proceed.Hide();
                    proceed.Click += new EventHandler(proceed_Click);
                    //navPanel.Controls.Add(new Label() { Name = "Q" + Convert.ToString(i + 1), Text = "Questions", Location = new System.Drawing.Point(60, 60), Margin = new Padding(3, 0, 3, 0), Font = new System.Drawing.Font("Verdana", 12, GraphicsUnit.Pixel), AutoSize = false });
                    navPanel.Controls.Add(next_button);
                    //navPanel.Controls.Add(prev_button);
                    navPanel.Controls.Add(proceed);
                navPanel.Controls.Add(new Label() { Name = "Quiz_Progress", Text = "Quiz Progress", Location = new System.Drawing.Point(10,150), Margin = new Padding(3, 0, 3, 0), Font = new System.Drawing.Font("Verdana", 15, FontStyle.Bold, GraphicsUnit.Pixel), AutoSize = true });
                ProgressBar prgBar = new ProgressBar();
                    prgBar.Name = "Progress_bar_quiz";
                    prgBar.Height = 30;
                    prgBar.Width = 1300;
                    prgBar.Style = ProgressBarStyle.Blocks;
                    prgBar.Location = new Point(10, 180);
                    navPanel.Controls.Add(prgBar);
                    tabarray[i].Controls.Add(navPanel);

                    tabarray[i].Controls.Add(new Panel() { Name = "pnl_tab_Quiz_Navigation" + Convert.ToString(i + 1), Location = new System.Drawing.Point(10, 300),  Width = 1000, Height = 100, BackColor = Color.FromArgb(224, 237, 241) });





                    tbcontrolQuizzes.Controls.Add(tabarray[i]);
                i++;

                }
                
                
            
            tbcontrolQuizzes.Selecting += TbcontrolQuizzes_Selecting;
            //tbcontrolQuizzes.TabPages[0].Text="Disclaimer";
            tbcontrolQuizzes.SelectedIndex = 0;
           populateQuestionsTableTab(QuizNo);
           displayQuestion(0,tbcontrolQuizzes.SelectedIndex);
            
            




        }

        private void Lbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sinfo = new ProcessStartInfo(e.Link.LinkData.ToString());
            Process.Start(sinfo);
        }

        private void TbcontrolQuizzes_Selecting(object sender, TabControlCancelEventArgs e)
        {
            //System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            //messageBoxCS.AppendFormat("{0} = {1}", "TabPage", e.TabPage);
            //messageBoxCS.AppendLine();
            //messageBoxCS.AppendFormat("{0} = {1}", "TabPageIndex", e.TabPageIndex);
            //messageBoxCS.AppendLine();
            //messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action);
            //messageBoxCS.AppendLine();
            //messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel);
            //messageBoxCS.AppendLine();
            //MessageBox.Show(messageBoxCS.ToString(), "Selecting Event");
            if(tbcontrolQuizzes.SelectedIndex>=0)
            {
                if(previous_quiz_Comleted==false)
                {
                    e.Cancel = true;
                    MessageBox.Show("Please complete the quiz");
                }
                else if(lockedQuiz.Contains(e.TabPageIndex))
                {
                    e.Cancel = true;
                    
                    MessageBox.Show("This quiz is locked!");
                }
                else
                {
                    e.Cancel = false;
                }
            }
            else if(tbcontrolQuizzes.SelectedIndex==1)
            {
                if (lockedQuiz.Contains(e.TabPageIndex))
                {
                    e.Cancel = true;

                    MessageBox.Show("This quiz is locked!");
                }
               
            }
        }

        private void NextButton_Click(object sender,EventArgs e)
        {
            if (currentQuestionAnswered)
            {
                

                if (currentQuestionIndex < (tabQuestionBank.Rows.Count - 1))
                {
                    
                    displayQuestion(currentQuestionIndex + 1, tbcontrolQuizzes.SelectedIndex);
                    currentQuestionIndex++;
                    currentQuestionAnswered = false;
                    progressbar_initialize(currentQuestionIndex + 1, tbcontrolQuizzes.SelectedIndex);
                    bar.PerformStep();

                }
                else
                {

                }
            }
            else
            {
                MessageBox.Show("Please select your answer");
            }

        }
        private void tab_changed(object sender, EventArgs e)
        {
            if(tbcontrolQuizzes.SelectedIndex>0)
            {
                if(previous_quiz_Comleted!=true)
                {
                    MessageBox.Show("Complete the quiz");
                    return;
                }
                
            }
        }
        private void proceed_Click(object sender, EventArgs e)
        {
            DataTable dt = tabResponses;
            Boolean passStatus=false;
            int correctAnswer = 0;
            int userAttemptNo = 0;
            int maximumAllowedAttempts = 0;
            foreach(DataRow row in tabResponses.Rows)
            {
                userAttemptNo = Convert.ToInt32(row["AttemptNumber"]);
                maximumAllowedAttempts = Convert.ToInt32(row["AllowedAttempts"]);
                if(Convert.ToString(row["CorrectAnswer"]).Trim(' ')==Convert.ToString(row["UserResponse"]).Trim(' '))
                {
                    correctAnswer++;
                    if(correctAnswer>=Convert.ToInt32(row["PassIf_Correct"]))
                    {
                        passStatus = true;
                        break;

                    }

                }

            }
            if(!passStatus)
            {
                MessageBox.Show("Unfortunately!! you have failed this quiz");
                if(userAttemptNo<maximumAllowedAttempts)
                {
                    //populateQuestionsTableTab(QuizNo);
                    currentQuestionAnswered = false;
                    currentQuestionIndex = 0;
                    displayQuestion(0, tbcontrolQuizzes.SelectedIndex);
                    tabAttemptCount++;
                    tabResponses.Rows.Clear();

                }
                else
                {
                    MessageBox.Show("You have exhausted your limit for this quiz!\nYou will be advanced to next quiz.");
                    count_failed_quiz++;
                    if (count_failed_quiz <= max_fail_quiz)
                    {

                        //Application.Exit();
                        DataRow row = dt.Rows[0];
                        addTestDetails(name.Split('_')[0], name.Split('_')[1], tbcontrolQuizzes.SelectedTab.Name.Split(' ')[1], Convert.ToString(row["QuizName"]), "Fail", "");
                        previous_quiz_Comleted = true;
                        lockedQuiz.Add(tbcontrolQuizzes.SelectedIndex);
                        if (tbcontrolQuizzes.SelectedIndex != tbcontrolQuizzes.TabCount - 1)
                        {
                            tbcontrolQuizzes.SelectedIndex++;

                            currentQuestionAnswered = false;
                            displayQuestion(0, tbcontrolQuizzes.SelectedIndex);
                            populateQuestionsTableTab(Convert.ToInt32(tbcontrolQuizzes.SelectedTab.Name.Split(' ')[1]));
                            tabAttemptCount = 1;
                        }
                        else
                        {
                            //store_local_history(jobName);
                            store_local_history(quizResults, jobName, name, pos_category_name, DOB);
                            MessageBox.Show("End of Orientation, Kindly contact safety manager");
                            this.Hide();
                            try
                            {
                                Upload formnew = new Upload(quizResults, jobName, name, pos_category_name, DOB,dBank,siteURL);
                                formnew.Show();
                                //this.Hide();
                                //MessageBox.Show("Upload Complete.Check Sharepoint Site");
                                //MessageBox.Show("Upload Complete.Check Sharepoint Site\n\n\nContact the administrator.\nClick Ok to continue", "Continue");
                                ////formnew.Hide();
                                //formnew.Hide();
                                //new Login_offline(dBank).Show();

                            }
                            catch(Exception ex)
                            {
                                new Login_offline(dBank).Show();

                            }
                            


                        }
                    }
                    else
                    {
                        MessageBox.Show("You have failed more than 70% of the entire quiz.\n Hence you will have to take the entire test again\n Thank You!");
                        Application.Exit();
                    }

                }
                

            }
            else
            {
                MessageBox.Show("Congratulations!! you have passed this quiz");
                //Create_Directory(jobName);
               
                string path=Create_Directory(name);
                path =createPDFV2(dt, path);
                DataRow row = dt.Rows[0];
                addTestDetails(name.Split('_')[0],name.Split('_')[1], tbcontrolQuizzes.SelectedTab.Name.Split(' ')[1], Convert.ToString(row["QuizName"]), "Pass",path);
                previous_quiz_Comleted = true;
                lockedQuiz.Add(tbcontrolQuizzes.SelectedIndex);
                if (tbcontrolQuizzes.SelectedIndex != tbcontrolQuizzes.TabCount - 1)
                {
                    tbcontrolQuizzes.SelectedIndex++;

                    currentQuestionAnswered = false;
                    displayQuestion(0, tbcontrolQuizzes.SelectedIndex);
                    populateQuestionsTableTab(Convert.ToInt32(tbcontrolQuizzes.SelectedTab.Name.Split(' ')[1]));
                    tabAttemptCount = 1;
                }
                else
                {
                    store_local_history(quizResults,jobName, name, pos_category_name, DOB);
                    MessageBox.Show("End of Orientation, Kindly contact safety manager");
                    this.Hide();
                    try
                    {
                        Upload formnew = new Upload(quizResults, jobName, name, pos_category_name, DOB,dBank,siteURL);
                        formnew.Show();
                        //this.Hide();
                        //MessageBox.Show("Upload Complete.Check Sharepoint Site\n\n\nContact the administrator.\n Click Ok to continue", "Continue");
                        //formnew.Hide();
                        //new Login_offline(dBank).Show();

                    }
                    catch(Exception ex)
                    {
                        new Login_offline(dBank).Show();

                    }
                    
                }
                
            }

        }


        private void previous_Click(object sender, EventArgs e)
        {
            if (currentQuestionIndex > 0)
            {
                currentQuestionIndex--;
                displayQuestion(currentQuestionIndex, tbcontrolQuizzes.SelectedIndex);

            }

        }




        public void populateQuestionsTableTab(int quizNumber)
        {
            if(tbcontrolQuizzes.SelectedIndex>=0)
            {
                DataRow[] quizrows = qBank.Select("QuizNumber=" + quizNumber);
                tabQuestionBank = new DataTable();
                tabQuestionBank = qBank.Clone();
                tabResponses = qBank.Clone();
                foreach (DataRow row in quizrows)
                {
                    maxQuizResponse =Convert.ToInt32(row["AllowedAttempts"]);
                    tabQuestionBank.ImportRow(row);
                }
                DataColumnCollection columns = tabQuestionBank.Columns;
                DataColumn[] keys = new DataColumn[1];
                keys[0] = columns["QuestionID"];
                tabQuestionBank.PrimaryKey = keys;
               // tabResponses.PrimaryKey = keys;
                tabResponses.Columns.Add("UserResponse", typeof(string));
                tabResponses.Columns.Add("AttemptNumber", typeof(int));

                //for tab responses adding primary key
                DataColumnCollection collumns1 = tabResponses.Columns;
                DataColumn[] keys_responses_table = new DataColumn[1];
                keys_responses_table[0] = collumns1["QuestionID"];
                tabResponses.PrimaryKey = keys_responses_table;
                previous_quiz_Comleted = false;
                max_progress_bar = tabQuestionBank.Rows.Count;


            }
            

        }
        public void progressbar_initialize(int rowIndex, int selectedTabIndex)
        {
            Panel navPanel = (Panel)tbcontrolQuizzes.SelectedTab.Controls["pnl_tab_Quiz_Navigation" + Convert.ToString(selectedTabIndex + 1)];
            bar= (ProgressBar)navPanel.Controls["Progress_bar_quiz"];
            bar.Maximum = max_progress_bar;
            bar.Minimum = 1;
            bar.Step = 1;

        }
        public void displayQuestion(int rowIndex,int selectedTabIndex)
        {
            if(tbcontrolQuizzes.SelectedIndex>=0)
            {
                // Panel qPanel = (Panel)tbcontrolQuizzes.SelectedTab.Controls["pnl_tab_Quiz_Questions"+ tab_index + 1];
                //Panel aPanel = (Panel)tbcontrolQuizzes.SelectedTab.Controls["pnl_tab_Quiz_Answers" + tab_index + 1];
                //qPanel.Controls.Add(new Label() {Text="lbl_"+"Qz_"+tab_index+"Questions })
                //labl_tab1_Question.Text = Convert.ToString(tabQuestionBank.Rows[rowIndex]["Question"]);
                Panel Qpanel = (Panel)tbcontrolQuizzes.SelectedTab.Controls["pnl_tab_Quiz_Questions" + Convert.ToString(tbcontrolQuizzes.SelectedIndex + 1)];
                Label QuizHeading= (Label)Qpanel.Controls["pnl_tab_Quiz_Questions_lbl_QHeading" + Convert.ToString(tbcontrolQuizzes.SelectedIndex + 1)];
                Label QuestionID = (Label)Qpanel.Controls["pnl_tab_Quiz_Questions_QID" + Convert.ToString(tbcontrolQuizzes.SelectedIndex + 1)];
                Label Question = (Label)Qpanel.Controls["pnl_tab_Quiz_Questions_lbl_Q" + Convert.ToString(tbcontrolQuizzes.SelectedIndex + 1)];
                Label QuestionNo = (Label)Qpanel.Controls["pnl_tab_Quiz_Questions_lbl_QNo" + Convert.ToString(tbcontrolQuizzes.SelectedIndex + 1)];
                Panel aPanel = (Panel)tbcontrolQuizzes.SelectedTab.Controls["pnl_tab_Quiz_Answers" + Convert.ToString(selectedTabIndex+1)];
                Panel navPanel = (Panel)tbcontrolQuizzes.SelectedTab.Controls["pnl_tab_Quiz_Navigation" + Convert.ToString(selectedTabIndex + 1)];
                Button nextButton = (Button)navPanel.Controls["btn_pnl_" + Convert.ToString(tbcontrolQuizzes.SelectedIndex + 1) + "_next"];
                Button proceedButton = (Button)navPanel.Controls["btn_pnl_" + Convert.ToString(tbcontrolQuizzes.SelectedIndex + 1) + "_proceed"];
                Question.Text = Convert.ToString(tabQuestionBank.Rows[rowIndex]["Question"]);
                Question.MaximumSize = new Size(700, 60);
                Question.Font = new System.Drawing.Font("Verdana", 15,FontStyle.Bold, GraphicsUnit.Pixel);
                
                Question.AutoSize = true;
                QuizHeading.Text = Convert.ToString(tabQuestionBank.Rows[rowIndex]["QuizName"]);
                QuestionNo.Text = Convert.ToString("Q.No"+Convert.ToString(rowIndex+1));
                QuestionID.Text = Convert.ToString(tabQuestionBank.Rows[rowIndex]["QuestionID"]);
                DataRow row = tabQuestionBank.Rows[rowIndex];
                int j = 0;
                System.Windows.Forms.RadioButton[] radioButtons = new System.Windows.Forms.RadioButton[4];
                string[] bullet_text = { "A)", "B)", "C)", "D)" };
                aPanel.Controls.Clear();
                for (int i = 1; i <= 4; i++)
                {
                    if (Convert.ToString(row["QuestionOption" + i]) != "")
                    {

                        radioButtons[j] = new RadioButton();
                        radioButtons[j].Name = Convert.ToString("Question:" + tabQuestionBank.Rows[rowIndex]["QuestionID"]);
                        // radioButtons[j].Name = "tab" + QuizNo + "answerno" + Convert.ToString((rowIndex + i));
                        radioButtons[j].Text = Convert.ToString(row["QuestionOption" + i]);
                        radioButtons[j].Font = new System.Drawing.Font("Verdana", 15, FontStyle.Bold, GraphicsUnit.Pixel);

                        radioButtons[j].Location = new System.Drawing.Point(
                            40, 10 + i * 20);
                        radioButtons[j].Width = 1000;
                        radioButtons[j].AutoSize = true;
                        radioButtons[j].MaximumSize = new System.Drawing.Size(1460, 50);
                        radioButtons[j].CheckedChanged += new EventHandler(checkedChanged);
                        Label bullet=new Label();
                        bullet.Location= new System.Drawing.Point(
                            10,10+ i*20);
                        bullet.Width = 30;
                        bullet.AutoSize = true;
                        bullet.Font= new System.Drawing.Font("Verdana", 15, FontStyle.Bold, GraphicsUnit.Pixel);
                        bullet.Text = bullet_text[i-1];
                        bullet.TextAlign = ContentAlignment.MiddleCenter;
                        aPanel.Controls.Add(bullet);
                        aPanel.Controls.Add(radioButtons[j]);
                       
                        j++;
                    }

                }
                if(currentQuestionIndex== tabQuestionBank.Rows.Count - 2)
                {
                    nextButton.Hide();
                    proceedButton.Show();

                }
                else
                {
                    nextButton.Show();
                    proceedButton.Hide();

                }

            }
            
            
            

        }

        private void checkedChanged(object sender, EventArgs e)
        {
            RadioButton radiobtn = (RadioButton)sender;
            if(radiobtn!=null)
            {
                if(radiobtn.Checked)
                {
                    currentQuestionAnswered = true;
                    //MessageBox.Show("You selected: " + radiobtn.Text);
                    //MessageBox.Show(radiobtn.Name);
                    DataTable temp = new DataTable();
                    temp = tabQuestionBank.Clone();

                    DataRow foundRow = tabQuestionBank.Rows.Find(radiobtn.Name.Split(':')[1]);

                    temp.ImportRow(foundRow);
                    DataRow alreadyanswered = tabResponses.Rows.Find(radiobtn.Name.Split(':')[1]);
                    if (alreadyanswered!=null)
                    {
                        tabResponses.Rows.Remove(alreadyanswered);

                    }
                    DataRow response = tabResponses.NewRow();
                    response["QuestionID"] = radiobtn.Name.Split(':')[1];
                    response["QuizNumber"] = foundRow["QuizNumber"];
                    response["QuestionNo"] = foundRow["QuestionNo"];
                    response["QuizName"] = foundRow["QuizName"];
                    response["Question"] = foundRow["Question"];
                    response["CorrectAnswer"] = foundRow["CorrectAnswer"];
                    response["AllowedAttempts"] = foundRow["AllowedAttempts"];
                    response["PassIf_Correct"] = foundRow["PassIf_Correct"];
                    response["UserResponse"] = radiobtn.Text;
                    response["AttemptNumber"] = tabAttemptCount;
                    tabResponses.Rows.Add(response);
                   // MessageBox.Show(Convert.ToString(temp.Rows[0]["CorrectAnswer"]));

                }
                

            }
            
            

        }



        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

      

        private void btnPreviousQues_TabIndexChanged(object sender, EventArgs e)
        {
            QuizNo = tbcontrolQuizzes.SelectedIndex - 1;
            currentQuestionIndex = 0;
            
            
        }

        private void tbcontrolQuizzes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tbcontrolQuizzes.SelectedIndex>=0)
            {
                populateQuestionsTableTab(Convert.ToInt32(tbcontrolQuizzes.SelectedTab.Name.Split(' ')[1]));
                progressbar_initialize(0, tbcontrolQuizzes.SelectedIndex);
                displayQuestion(0, tbcontrolQuizzes.SelectedIndex);
                currentQuestionIndex = 0;

            }
            
            
            
        }
        public string createPDF(DataTable dataTable, string destinationPath)
        {
            DataTable dt = new DataTable();
            dt = dataTable.Copy();
            DirectoryInfo info = new DirectoryInfo(destinationPath);
            DirectorySecurity security = info.GetAccessControl();
            //Regex.Replace(destinationPath.Trim(), "[^A-Za-z0-9_. \\]+", "");
            DataRow row = dt.Rows[0];

            destinationPath = destinationPath + "\\"+Convert.ToString(row["QuizName"])+".pdf";
            destinationPath=Path.Combine(destinationPath);
            destinationPath=destinationPath.Replace('/', '_');
            Path.GetInvalidFileNameChars().Aggregate(destinationPath, (current, c) => current.Replace(c.ToString(), string.Empty));
            Document document = new Document(PageSize.A4,1,1,1,1);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(destinationPath, FileMode.Create,FileAccess.ReadWrite,FileShare.ReadWrite));
            document.Open();

            PdfPTable table = new PdfPTable(dt.Columns.Count);
            table.WidthPercentage = 100;
            

            //Set columns names in the pdf file
            for (int k = 0; k < dt.Columns.Count; k++)
            {
                PdfPCell cell = new PdfPCell(new Phrase(dataTable.Columns[k].ColumnName));

                cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                //cell.Width = 500;
                cell.BackgroundColor = new iTextSharp.text.BaseColor(51, 102, 102);
                //cell.Width = 100f;
                table.AddCell(cell);
            }

            //Add values of DataTable in pdf file
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(dataTable.Rows[i][j].ToString()));

                    //Align the cell in the center
                    cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;

                    table.AddCell(cell);
                }
            }

            document.Add(table);
            document.Close();
            return destinationPath;
        }
        public string createPDFV2(DataTable dataTable, string destinationPath)
        {
            DataTable dt = new DataTable();
            dt = dataTable.Copy();
           // DirectoryInfo info = new DirectoryInfo(destinationPath);
            //DirectorySecurity security = info.GetAccessControl();
            //Regex.Replace(destinationPath.Trim(), "[^A-Za-z0-9_. \\]+", "");
            DataRow row = dt.Rows[0];

            destinationPath = destinationPath + "\\" + Convert.ToString(row["QuizName"]) + ".pdf";
            destinationPath = Path.Combine(destinationPath);
            destinationPath = destinationPath.Replace('/', '_');
            Path.GetInvalidFileNameChars().Aggregate(destinationPath, (current, c) => current.Replace(c.ToString(), string.Empty));
            Document document = new Document(PageSize.A4, 30, 30, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(destinationPath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite));
            document.AddSubject(Convert.ToString(row["QuizName"])+" Results");
            document.AddTitle(Convert.ToString(row["QuizName"]));
            document.Open();
            document.AddHeader("Develpoed", "Developed by IEA Dev team.All rights Reserved");
            PdfContentByte cb = writer.DirectContent;
            cb.SetLineWidth(2.0f);   // Make a bit thicker than 1.0 default
            cb.SetGrayStroke(0.95f); // 1 = black, 0 = white
            cb.MoveTo(20, 30);
            cb.LineTo(400, 30);

            iTextSharp.text.Rectangle pageRect = document.PageSize;
            Bitmap bmp = new Bitmap(Quizzed.Properties.Resources.IEA_Logo);
                   
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance((System.Drawing.Image)bmp,BaseColor.WHITE);
            document.Add(img);
            //img.ScaleToFit(pageRect);
            //BaseFont bf = new BaseFont("");
            document.Add(new Paragraph(Convert.ToString(row["QuizName"]), new iTextSharp.text.Font(BaseFont.CreateFont(BaseFont.TIMES_ROMAN,BaseFont.WINANSI,BaseFont.EMBEDDED),(float)26)));
            //document.Add(new Paragraph(Convert.ToString(row["QuizName"])));
            Chunk lb= new Chunk(new iTextSharp.text.pdf.draw.LineSeparator());
            document.Add(lb);
            DataRow testrow = dt.Rows[0];
            document.Add(new Paragraph(""));
            document.Add(new Paragraph(""));
            document.Add(new Paragraph(""));
            document.Add(new Paragraph("Test Summary", new iTextSharp.text.Font(BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.WINANSI, BaseFont.EMBEDDED), (float)20)));
            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("Candidate Name: " + name));
            document.Add(new Paragraph("Jobsite: " + jobName));
            document.Add(new Paragraph("Total Questions: " + dt.Rows.Count));
            int count_correctAnswers = 0;
            foreach (DataRow row1 in dt.Rows)
            {
                if(Convert.ToString(row1["UserResponse"]).Trim(' ')== Convert.ToString(row1["CorrectAnswer"]).Trim(' '))
                {
                    count_correctAnswers++;

                }

                

            }
            document.Add(new Paragraph("Correct Answers: " + count_correctAnswers));
            document.Add(new Paragraph("Passed in Attempt No: " + Convert.ToString(testrow["AttemptNumber"])));
            document.Add(new Paragraph("Timestamp: " + DateTime.Now));
            document.Add(lb);
            document.Add(new Paragraph("Test Details", new iTextSharp.text.Font(BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.WINANSI, BaseFont.EMBEDDED), (float)20)));
            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("\n"));
            

            int i = 1;
            //Add values of DataTable in pdf file
            foreach(DataRow row1 in dt.Rows)
            {
                document.Add(new Paragraph("QNo " + i + ". "+Convert.ToString(row1["Question"])));
                document.Add(new Paragraph(""));

                document.Add(new Paragraph("User response: " + Convert.ToString(row1["UserResponse"])));
                document.Add(new Paragraph(""));
                document.Add(new Paragraph("Correct Answer: " + Convert.ToString(row1["CorrectAnswer"])));
                document.Add(new Paragraph(""));
               // document.Add(new Paragraph("Passed in Attempt No: " + Convert.ToString(row1["AttemptNumber"])));
                //cb.Stroke();
                Chunk linebreak = new Chunk(new iTextSharp.text.pdf.draw.DottedLineSeparator());
                document.Add(linebreak);

                document.Add(new Paragraph(""));
                i++;

            }

            //document.Add(table);
            
            document.Close();
            return destinationPath;
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
                string target = @date_path+"\\"+folder;
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
                return "-1" ;
            }

        }
        public string Create_Directory_Job(string folder)
        {
            try
            {
                // Get the current directory.
                //string path = Directory.GetCurrentDirectory();
                string path = Application.StartupPath;
                string target = path + "\\Local_Data\\" + folder;
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
        public void addTestDetails(string fname,string lastName, string quizNumber,string quizname, string status, string filepath)
        {
            DataRow row = quizResults.NewRow();
            row["FirstName"] =fname;
            row["LastName"] =lastName;
            row["Job"] =jobName;
            row["QuizNumber"] =quizNumber;
            row["QuizName"] =quizname;
            row["Status"] =status;
            row["filePath"] = filepath;
            quizResults.Rows.Add(row);
            

        }

        private void Quiz_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult dialogresult = MessageBox.Show("Are you sure you want to exit the application?\nOnce you click ok all progess will be lost.", "Close Quizzed", MessageBoxButtons.OKCancel);
                if (dialogresult == DialogResult.OK)
                {
                    //do something
                    Application.Exit();
                }
                else
                {
                    //do something else
                    e.Cancel = true;
                }
            }

        }
        public string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }


        public Boolean store_local_history(DataTable qresults,string jobName,string name,string pos_category_name,string cand_DOB)
        {

            DataRow candRow = qresults.Rows[0];
            string folder_path_candidatedoc = Convert.ToString(candRow["filePath"]);
            folder_path_candidatedoc = folder_path_candidatedoc.Substring(0, folder_path_candidatedoc.LastIndexOf('\\') + 1);
            string remaining_test = "";
            
            string local_history_path=Create_Directory_Job(jobName);
            
            if (!File.Exists(local_history_path + "\\History.xml"))
            {
                XmlDocument doc = new XmlDocument();

                // Write down the XML declaration
                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "utf-8", null);

                // Create the root element
                XmlElement rootNode = doc.CreateElement("CandidateInfo");
                doc.InsertBefore(xmlDeclaration, doc.DocumentElement);
                doc.AppendChild(rootNode);
                //XmlNode CandidatesInfoNode = doc.CreateElement("CandidateInfo");
                //doc.AppendChild(CandidatesInfoNode);
                //sdoc.Save(local_history_path + "\\History.xml");
                XmlNode cNode = doc.CreateElement("Candidate");
                XmlNode First_Name = doc.CreateElement("First_Name");
                First_Name.InnerText = name.Split('_')[0];
                XmlNode Last_Name = doc.CreateElement("Last_Name");
                Last_Name.InnerText= name.Split('_')[1];
                XmlNode DOB = doc.CreateElement("DOB");
                DOB.InnerText = cand_DOB;
                XmlNode position = doc.CreateElement("Position");
                position.InnerText = pos_category_name;
                XmlNode job = doc.CreateElement("Job");
                job.InnerText = jobName;
                XmlNode Folder_path = doc.CreateElement("Folder_path");
                Folder_path.InnerText = folder_path_candidatedoc;
                XmlNode Pass_Status = doc.CreateElement("Pass_Status");
                XmlNode Upload_Status = doc.CreateElement("Upload_Status");
                XmlNode Pending_Test = doc.CreateElement("Remaining_Test");
                XmlNode TestDate = doc.CreateElement("TestDate");
                TestDate.InnerText = DateTime.Now.ToShortDateString();
                XmlNode ReturningCandidate = doc.CreateElement("IsReturningCandidate");
                ReturningCandidate.InnerText = "No";
                XmlNode CandidateID = doc.CreateElement("candidateID");
                CandidateID.InnerText = "";
                cNode.AppendChild(First_Name);
                cNode.AppendChild(Last_Name);
                cNode.AppendChild(DOB);
                cNode.AppendChild(position);
                cNode.AppendChild(job);
                cNode.AppendChild(Folder_path);
                cNode.AppendChild(Pass_Status);
                cNode.AppendChild(Upload_Status);
                cNode.AppendChild(Pending_Test);
                cNode.AppendChild(TestDate);
                cNode.AppendChild(ReturningCandidate);
                cNode.AppendChild(CandidateID);
                doc.DocumentElement.PrependChild(cNode);
                doc.Save(local_history_path + "\\History.xml");
                
                //FileStream fs1 = new FileStream(local_history_path + "\\History.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                //using (StreamWriter s = new StreamWriter(fs1))
                //{
                //    s.WriteLine("<CandidateInfo>");
                //    s.WriteLine("</CandidateInfo>");

                //}
                //fs1.Close();
            }
            else
            {
                XmlDocument xmldoc = new XmlDocument();
                
                XmlNode rootNode;
                FileStream fs = new FileStream(local_history_path + "\\History.xml", FileMode.Open, FileAccess.ReadWrite);
                xmldoc.Load(fs);


                rootNode = xmldoc.SelectSingleNode("CandidateInfo");
              
                     XmlNode cNode = xmldoc.CreateElement("Candidate");
                XmlNode First_Name = xmldoc.CreateElement("First_Name");
                First_Name.InnerText = name.Split('_')[0];
                XmlNode Last_Name = xmldoc.CreateElement("Last_Name");
                Last_Name.InnerText= name.Split('_')[1];
                XmlNode DOB = xmldoc.CreateElement("DOB");
                DOB.InnerText = cand_DOB;
                XmlNode position = xmldoc.CreateElement("Position");
                position.InnerText = pos_category_name;
                XmlNode job = xmldoc.CreateElement("Job");
                job.InnerText = jobName;
                XmlNode Folder_path = xmldoc.CreateElement("Folder_path");
                Folder_path.InnerText = folder_path_candidatedoc;
                XmlNode Pass_Status = xmldoc.CreateElement("Pass_Status");
                XmlNode Upload_Status = xmldoc.CreateElement("Upload_Status");
                XmlNode Pending_Test = xmldoc.CreateElement("Remaining_Test");
                XmlNode TestDate = xmldoc.CreateElement("TestDate");
                XmlNode ReturningCandidate = xmldoc.CreateElement("IsReturningCandidate");
                ReturningCandidate.InnerText = "No";
                TestDate.InnerText = DateTime.Now.ToShortDateString();
                XmlNode CandidateID = xmldoc.CreateElement("candidateID");
                CandidateID.InnerText = "";
                cNode.AppendChild(First_Name);
                cNode.AppendChild(Last_Name);
                cNode.AppendChild(DOB);
                cNode.AppendChild(position);
                cNode.AppendChild(job);
                cNode.AppendChild(Folder_path);
                cNode.AppendChild(Pass_Status);
                cNode.AppendChild(Upload_Status);
                cNode.AppendChild(Pending_Test);
                cNode.AppendChild(TestDate);
                cNode.AppendChild(ReturningCandidate);
                cNode.AppendChild(CandidateID);
                xmldoc.DocumentElement.PrependChild(cNode);
                    xmldoc.Save(local_history_path + "\\History_U.xml");
                    fs.Dispose();
                    File.Delete(local_history_path + "\\History.xml");
                    File.Move(local_history_path + "\\History_U.xml", local_history_path + "\\History.xml");
                    
                
                
                //xmldoc.Save(fs);

            }
                //xmldoc.Load(fs);
               


           
                
            return true;
        }
    }
    
}
