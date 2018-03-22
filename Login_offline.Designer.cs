namespace Quizzed
{
    partial class Login_offline
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login_offline));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkBoxUploadJobsite = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dtmDOB = new System.Windows.Forms.DateTimePicker();
            this.lblDOB = new System.Windows.Forms.Label();
            this.pnl_configureTest = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblOR = new System.Windows.Forms.Label();
            this.lblLoadFlwingQuiz = new System.Windows.Forms.Label();
            this.pnl_QuizList = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbxPositionRC = new System.Windows.Forms.ComboBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblConfigureTest = new System.Windows.Forms.Label();
            this.cmxCategory = new System.Windows.Forms.ComboBox();
            this.lblTestDetails = new System.Windows.Forms.Label();
            this.panel_test_Status = new System.Windows.Forms.Panel();
            this.llViewHistory = new System.Windows.Forms.LinkLabel();
            this.lblLastDateTime = new System.Windows.Forms.Label();
            this.lblLastTestDateTime = new System.Windows.Forms.Label();
            this.lblLastJob = new System.Windows.Forms.Label();
            this.lblPreviousJob = new System.Windows.Forms.Label();
            this.lblTestCountPlcHldr = new System.Windows.Forms.Label();
            this.lblRemaingTestCount = new System.Windows.Forms.Label();
            this.txtBox_remaining_tst = new System.Windows.Forms.RichTextBox();
            this.lblPositionPlcHlder = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRemainingTests = new System.Windows.Forms.Label();
            this.lblHireStatus = new System.Windows.Forms.Label();
            this.lblHireStatusPlcHolder = new System.Windows.Forms.Label();
            this.lbllName = new System.Windows.Forms.Label();
            this.lblfName = new System.Windows.Forms.Label();
            this.rdBtnRCYes = new System.Windows.Forms.RadioButton();
            this.rdBtnRCNo = new System.Windows.Forms.RadioButton();
            this.lblSelectCandidate = new System.Windows.Forms.Label();
            this.lblReturningCandidate = new System.Windows.Forms.Label();
            this.btnInitialisze = new System.Windows.Forms.Button();
            this.lblHeading = new System.Windows.Forms.Label();
            this.cmxJobList = new System.Windows.Forms.ComboBox();
            this.txtBxLastName = new System.Windows.Forms.TextBox();
            this.lblSelectJob = new System.Windows.Forms.Label();
            this.lblSupervisor = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.cmbxCandidateList = new System.Windows.Forms.ComboBox();
            this.txtBxFName = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.refreshDataStoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadPendingCandidatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewLocalFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblCopyright = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnl_configureTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel_test_Status.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.AllowDrop = true;
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))));
            this.panel1.Controls.Add(this.chkBoxUploadJobsite);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.dtmDOB);
            this.panel1.Controls.Add(this.lblDOB);
            this.panel1.Controls.Add(this.pnl_configureTest);
            this.panel1.Controls.Add(this.cmxCategory);
            this.panel1.Controls.Add(this.lblTestDetails);
            this.panel1.Controls.Add(this.panel_test_Status);
            this.panel1.Controls.Add(this.lbllName);
            this.panel1.Controls.Add(this.lblfName);
            this.panel1.Controls.Add(this.rdBtnRCYes);
            this.panel1.Controls.Add(this.rdBtnRCNo);
            this.panel1.Controls.Add(this.lblSelectCandidate);
            this.panel1.Controls.Add(this.lblReturningCandidate);
            this.panel1.Controls.Add(this.btnInitialisze);
            this.panel1.Controls.Add(this.lblHeading);
            this.panel1.Controls.Add(this.cmxJobList);
            this.panel1.Controls.Add(this.txtBxLastName);
            this.panel1.Controls.Add(this.lblSelectJob);
            this.panel1.Controls.Add(this.lblSupervisor);
            this.panel1.Controls.Add(this.lblLastName);
            this.panel1.Controls.Add(this.lblFirstName);
            this.panel1.Controls.Add(this.cmbxCandidateList);
            this.panel1.Controls.Add(this.txtBxFName);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.ForeColor = System.Drawing.Color.SteelBlue;
            this.panel1.Name = "panel1";
            // 
            // chkBoxUploadJobsite
            // 
            resources.ApplyResources(this.chkBoxUploadJobsite, "chkBoxUploadJobsite");
            this.chkBoxUploadJobsite.Checked = true;
            this.chkBoxUploadJobsite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxUploadJobsite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.chkBoxUploadJobsite.Name = "chkBoxUploadJobsite";
            this.chkBoxUploadJobsite.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Quizzed.Properties.Resources.if_file_309072;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Quizzed.Properties.Resources.if_icon_person_211874__1_;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // dtmDOB
            // 
            resources.ApplyResources(this.dtmDOB, "dtmDOB");
            this.dtmDOB.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.dtmDOB.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(236)))));
            this.dtmDOB.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.dtmDOB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtmDOB.Name = "dtmDOB";
            this.dtmDOB.Value = new System.DateTime(2017, 5, 31, 14, 6, 18, 0);
            // 
            // lblDOB
            // 
            resources.ApplyResources(this.lblDOB, "lblDOB");
            this.lblDOB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.lblDOB.Name = "lblDOB";
            // 
            // pnl_configureTest
            // 
            resources.ApplyResources(this.pnl_configureTest, "pnl_configureTest");
            this.pnl_configureTest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_configureTest.Controls.Add(this.pictureBox3);
            this.pnl_configureTest.Controls.Add(this.lblOR);
            this.pnl_configureTest.Controls.Add(this.lblLoadFlwingQuiz);
            this.pnl_configureTest.Controls.Add(this.pnl_QuizList);
            this.pnl_configureTest.Controls.Add(this.cmbxPositionRC);
            this.pnl_configureTest.Controls.Add(this.lblPosition);
            this.pnl_configureTest.Controls.Add(this.lblConfigureTest);
            this.pnl_configureTest.Name = "pnl_configureTest";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Quizzed.Properties.Resources.if_54_111138;
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // lblOR
            // 
            resources.ApplyResources(this.lblOR, "lblOR");
            this.lblOR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.lblOR.Name = "lblOR";
            // 
            // lblLoadFlwingQuiz
            // 
            resources.ApplyResources(this.lblLoadFlwingQuiz, "lblLoadFlwingQuiz");
            this.lblLoadFlwingQuiz.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.lblLoadFlwingQuiz.Name = "lblLoadFlwingQuiz";
            // 
            // pnl_QuizList
            // 
            resources.ApplyResources(this.pnl_QuizList, "pnl_QuizList");
            this.pnl_QuizList.Name = "pnl_QuizList";
            // 
            // cmbxPositionRC
            // 
            this.cmbxPositionRC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(236)))));
            resources.ApplyResources(this.cmbxPositionRC, "cmbxPositionRC");
            this.cmbxPositionRC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.cmbxPositionRC.FormattingEnabled = true;
            this.cmbxPositionRC.Name = "cmbxPositionRC";
            this.cmbxPositionRC.SelectedIndexChanged += new System.EventHandler(this.cmbxPositionRC_SelectedIndexChanged);
            this.cmbxPositionRC.SelectionChangeCommitted += new System.EventHandler(this.cmbxPositionRC_SelectionChangeCommitted);
            // 
            // lblPosition
            // 
            resources.ApplyResources(this.lblPosition, "lblPosition");
            this.lblPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.lblPosition.Name = "lblPosition";
            // 
            // lblConfigureTest
            // 
            resources.ApplyResources(this.lblConfigureTest, "lblConfigureTest");
            this.lblConfigureTest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.lblConfigureTest.Name = "lblConfigureTest";
            // 
            // cmxCategory
            // 
            this.cmxCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(236)))));
            resources.ApplyResources(this.cmxCategory, "cmxCategory");
            this.cmxCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.cmxCategory.FormattingEnabled = true;
            this.cmxCategory.Name = "cmxCategory";
            // 
            // lblTestDetails
            // 
            resources.ApplyResources(this.lblTestDetails, "lblTestDetails");
            this.lblTestDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.lblTestDetails.Name = "lblTestDetails";
            // 
            // panel_test_Status
            // 
            this.panel_test_Status.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_test_Status.Controls.Add(this.llViewHistory);
            this.panel_test_Status.Controls.Add(this.lblLastDateTime);
            this.panel_test_Status.Controls.Add(this.lblLastTestDateTime);
            this.panel_test_Status.Controls.Add(this.lblLastJob);
            this.panel_test_Status.Controls.Add(this.lblPreviousJob);
            this.panel_test_Status.Controls.Add(this.lblTestCountPlcHldr);
            this.panel_test_Status.Controls.Add(this.lblRemaingTestCount);
            this.panel_test_Status.Controls.Add(this.txtBox_remaining_tst);
            this.panel_test_Status.Controls.Add(this.lblPositionPlcHlder);
            this.panel_test_Status.Controls.Add(this.label1);
            this.panel_test_Status.Controls.Add(this.lblRemainingTests);
            this.panel_test_Status.Controls.Add(this.lblHireStatus);
            this.panel_test_Status.Controls.Add(this.lblHireStatusPlcHolder);
            resources.ApplyResources(this.panel_test_Status, "panel_test_Status");
            this.panel_test_Status.Name = "panel_test_Status";
            // 
            // llViewHistory
            // 
            resources.ApplyResources(this.llViewHistory, "llViewHistory");
            this.llViewHistory.Name = "llViewHistory";
            this.llViewHistory.TabStop = true;
            this.llViewHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llViewHistory_LinkClicked);
            // 
            // lblLastDateTime
            // 
            resources.ApplyResources(this.lblLastDateTime, "lblLastDateTime");
            this.lblLastDateTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.lblLastDateTime.Name = "lblLastDateTime";
            // 
            // lblLastTestDateTime
            // 
            resources.ApplyResources(this.lblLastTestDateTime, "lblLastTestDateTime");
            this.lblLastTestDateTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.lblLastTestDateTime.Name = "lblLastTestDateTime";
            // 
            // lblLastJob
            // 
            resources.ApplyResources(this.lblLastJob, "lblLastJob");
            this.lblLastJob.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.lblLastJob.Name = "lblLastJob";
            // 
            // lblPreviousJob
            // 
            resources.ApplyResources(this.lblPreviousJob, "lblPreviousJob");
            this.lblPreviousJob.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.lblPreviousJob.Name = "lblPreviousJob";
            // 
            // lblTestCountPlcHldr
            // 
            resources.ApplyResources(this.lblTestCountPlcHldr, "lblTestCountPlcHldr");
            this.lblTestCountPlcHldr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.lblTestCountPlcHldr.Name = "lblTestCountPlcHldr";
            // 
            // lblRemaingTestCount
            // 
            resources.ApplyResources(this.lblRemaingTestCount, "lblRemaingTestCount");
            this.lblRemaingTestCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.lblRemaingTestCount.Name = "lblRemaingTestCount";
            // 
            // txtBox_remaining_tst
            // 
            this.txtBox_remaining_tst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(236)))));
            resources.ApplyResources(this.txtBox_remaining_tst, "txtBox_remaining_tst");
            this.txtBox_remaining_tst.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.txtBox_remaining_tst.Name = "txtBox_remaining_tst";
            this.txtBox_remaining_tst.ReadOnly = true;
            // 
            // lblPositionPlcHlder
            // 
            resources.ApplyResources(this.lblPositionPlcHlder, "lblPositionPlcHlder");
            this.lblPositionPlcHlder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.lblPositionPlcHlder.Name = "lblPositionPlcHlder";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.label1.Name = "label1";
            // 
            // lblRemainingTests
            // 
            resources.ApplyResources(this.lblRemainingTests, "lblRemainingTests");
            this.lblRemainingTests.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.lblRemainingTests.Name = "lblRemainingTests";
            // 
            // lblHireStatus
            // 
            resources.ApplyResources(this.lblHireStatus, "lblHireStatus");
            this.lblHireStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.lblHireStatus.Name = "lblHireStatus";
            // 
            // lblHireStatusPlcHolder
            // 
            resources.ApplyResources(this.lblHireStatusPlcHolder, "lblHireStatusPlcHolder");
            this.lblHireStatusPlcHolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.lblHireStatusPlcHolder.Name = "lblHireStatusPlcHolder";
            // 
            // lbllName
            // 
            resources.ApplyResources(this.lbllName, "lbllName");
            this.lbllName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbllName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.lbllName.Name = "lbllName";
            // 
            // lblfName
            // 
            resources.ApplyResources(this.lblfName, "lblfName");
            this.lblfName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.lblfName.Name = "lblfName";
            // 
            // rdBtnRCYes
            // 
            resources.ApplyResources(this.rdBtnRCYes, "rdBtnRCYes");
            this.rdBtnRCYes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.rdBtnRCYes.Name = "rdBtnRCYes";
            this.rdBtnRCYes.UseVisualStyleBackColor = true;
            this.rdBtnRCYes.CheckedChanged += new System.EventHandler(this.rdBtnRCYes_CheckedChanged);
            // 
            // rdBtnRCNo
            // 
            resources.ApplyResources(this.rdBtnRCNo, "rdBtnRCNo");
            this.rdBtnRCNo.Checked = true;
            this.rdBtnRCNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.rdBtnRCNo.Name = "rdBtnRCNo";
            this.rdBtnRCNo.TabStop = true;
            this.rdBtnRCNo.UseVisualStyleBackColor = true;
            this.rdBtnRCNo.CheckedChanged += new System.EventHandler(this.rdBtnRCNo_CheckedChanged);
            // 
            // lblSelectCandidate
            // 
            resources.ApplyResources(this.lblSelectCandidate, "lblSelectCandidate");
            this.lblSelectCandidate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.lblSelectCandidate.Name = "lblSelectCandidate";
            // 
            // lblReturningCandidate
            // 
            resources.ApplyResources(this.lblReturningCandidate, "lblReturningCandidate");
            this.lblReturningCandidate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.lblReturningCandidate.Name = "lblReturningCandidate";
            this.lblReturningCandidate.Click += new System.EventHandler(this.lblReturningCandidate_Click);
            // 
            // btnInitialisze
            // 
            resources.ApplyResources(this.btnInitialisze, "btnInitialisze");
            this.btnInitialisze.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(236)))));
            this.btnInitialisze.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.btnInitialisze.Image = global::Quizzed.Properties.Resources.if_23_Play_106223;
            this.btnInitialisze.Name = "btnInitialisze";
            this.btnInitialisze.UseVisualStyleBackColor = false;
            this.btnInitialisze.Click += new System.EventHandler(this.btnInitialisze_Click);
            // 
            // lblHeading
            // 
            resources.ApplyResources(this.lblHeading, "lblHeading");
            this.lblHeading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.lblHeading.Name = "lblHeading";
            // 
            // cmxJobList
            // 
            this.cmxJobList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmxJobList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmxJobList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(236)))));
            resources.ApplyResources(this.cmxJobList, "cmxJobList");
            this.cmxJobList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.cmxJobList.FormattingEnabled = true;
            this.cmxJobList.Name = "cmxJobList";
            this.cmxJobList.DropDown += new System.EventHandler(this.AdjustWidthComboBox_DropDown);
            this.cmxJobList.SelectedIndexChanged += new System.EventHandler(this.cmxJobList_SelectedIndexChanged);
            this.cmxJobList.SelectionChangeCommitted += new System.EventHandler(this.cmxJobList_SelectionChangeCommitted);
            // 
            // txtBxLastName
            // 
            this.txtBxLastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(236)))));
            resources.ApplyResources(this.txtBxLastName, "txtBxLastName");
            this.txtBxLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.txtBxLastName.Name = "txtBxLastName";
            this.txtBxLastName.Validating += new System.ComponentModel.CancelEventHandler(this.txtBxLastName_Validating);
            // 
            // lblSelectJob
            // 
            resources.ApplyResources(this.lblSelectJob, "lblSelectJob");
            this.lblSelectJob.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.lblSelectJob.Name = "lblSelectJob";
            // 
            // lblSupervisor
            // 
            resources.ApplyResources(this.lblSupervisor, "lblSupervisor");
            this.lblSupervisor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.lblSupervisor.Name = "lblSupervisor";
            // 
            // lblLastName
            // 
            resources.ApplyResources(this.lblLastName, "lblLastName");
            this.lblLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.lblLastName.Name = "lblLastName";
            // 
            // lblFirstName
            // 
            resources.ApplyResources(this.lblFirstName, "lblFirstName");
            this.lblFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.lblFirstName.Name = "lblFirstName";
            // 
            // cmbxCandidateList
            // 
            this.cmbxCandidateList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbxCandidateList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbxCandidateList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(236)))));
            resources.ApplyResources(this.cmbxCandidateList, "cmbxCandidateList");
            this.cmbxCandidateList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.cmbxCandidateList.FormattingEnabled = true;
            this.cmbxCandidateList.Name = "cmbxCandidateList";
            this.cmbxCandidateList.SelectionChangeCommitted += new System.EventHandler(this.cmbxCandidateList_SelectionChangeCommitted);
            this.cmbxCandidateList.TextUpdate += new System.EventHandler(this.cmbxCandidateList_TextUpdate);
            this.cmbxCandidateList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbxCandidateList_KeyPress);
            // 
            // txtBxFName
            // 
            this.txtBxFName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(236)))));
            this.txtBxFName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtBxFName, "txtBxFName");
            this.txtBxFName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.txtBxFName.Name = "txtBxFName";
            this.txtBxFName.Validating += new System.ComponentModel.CancelEventHandler(this.txtBxFName_Validating);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(231)))), ((int)(((byte)(240)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshDataStoreToolStripMenuItem,
            this.uploadPendingCandidatesToolStripMenuItem,
            this.viewLocalFilesToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // refreshDataStoreToolStripMenuItem
            // 
            resources.ApplyResources(this.refreshDataStoreToolStripMenuItem, "refreshDataStoreToolStripMenuItem");
            this.refreshDataStoreToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(111)))), ((int)(((byte)(129)))));
            this.refreshDataStoreToolStripMenuItem.Image = global::Quizzed.Properties.Resources.if_sync_126579__1_;
            this.refreshDataStoreToolStripMenuItem.Name = "refreshDataStoreToolStripMenuItem";
            this.refreshDataStoreToolStripMenuItem.Click += new System.EventHandler(this.refreshDataStoreToolStripMenuItem_Click);
            // 
            // uploadPendingCandidatesToolStripMenuItem
            // 
            resources.ApplyResources(this.uploadPendingCandidatesToolStripMenuItem, "uploadPendingCandidatesToolStripMenuItem");
            this.uploadPendingCandidatesToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(111)))), ((int)(((byte)(129)))));
            this.uploadPendingCandidatesToolStripMenuItem.Image = global::Quizzed.Properties.Resources.if_cloud_upload_322433;
            this.uploadPendingCandidatesToolStripMenuItem.Name = "uploadPendingCandidatesToolStripMenuItem";
            this.uploadPendingCandidatesToolStripMenuItem.Click += new System.EventHandler(this.uploadPendingCandidatesToolStripMenuItem_Click);
            // 
            // viewLocalFilesToolStripMenuItem
            // 
            resources.ApplyResources(this.viewLocalFilesToolStripMenuItem, "viewLocalFilesToolStripMenuItem");
            this.viewLocalFilesToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(111)))), ((int)(((byte)(129)))));
            this.viewLocalFilesToolStripMenuItem.Image = global::Quizzed.Properties.Resources.if_magnifying_glass_226571;
            this.viewLocalFilesToolStripMenuItem.Name = "viewLocalFilesToolStripMenuItem";
            this.viewLocalFilesToolStripMenuItem.Click += new System.EventHandler(this.viewLocalFilesToolStripMenuItem_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // lblCopyright
            // 
            resources.ApplyResources(this.lblCopyright, "lblCopyright");
            this.lblCopyright.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))));
            this.lblCopyright.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.lblCopyright.Name = "lblCopyright";
            // 
            // Login_offline
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Login_offline";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            this.Load += new System.EventHandler(this.Login_offline_Load);
            this.Shown += new System.EventHandler(this.Login_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnl_configureTest.ResumeLayout(false);
            this.pnl_configureTest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel_test_Status.ResumeLayout(false);
            this.panel_test_Status.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Button btnInitialisze;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.ComboBox cmxJobList;
        private System.Windows.Forms.TextBox txtBxLastName;
        private System.Windows.Forms.TextBox txtBxFName;
        private System.Windows.Forms.Label lblSelectJob;
        private System.Windows.Forms.Label lblSupervisor;
        private System.Windows.Forms.ComboBox cmbxCandidateList;
        private System.Windows.Forms.Label lblSelectCandidate;
        private System.Windows.Forms.Label lblReturningCandidate;
        private System.Windows.Forms.RadioButton rdBtnRCYes;
        private System.Windows.Forms.RadioButton rdBtnRCNo;
        private System.Windows.Forms.Label lbllName;
        private System.Windows.Forms.Label lblfName;
        private System.Windows.Forms.Label lblTestDetails;
        private System.Windows.Forms.Panel panel_test_Status;
        private System.Windows.Forms.Label lblRemainingTests;
        private System.Windows.Forms.Label lblHireStatusPlcHolder;
        private System.Windows.Forms.Label lblHireStatus;
        private System.Windows.Forms.ComboBox cmxCategory;
        private System.Windows.Forms.Label lblPositionPlcHlder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtBox_remaining_tst;
        private System.Windows.Forms.Label lblTestCountPlcHldr;
        private System.Windows.Forms.Label lblRemaingTestCount;
        private System.Windows.Forms.Panel pnl_configureTest;
        private System.Windows.Forms.ComboBox cmbxPositionRC;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblConfigureTest;
        private System.Windows.Forms.FlowLayoutPanel pnl_QuizList;
        private System.Windows.Forms.Label lblLoadFlwingQuiz;
        private System.Windows.Forms.Label lblOR;
        private System.Windows.Forms.Label lblLastTestDateTime;
        private System.Windows.Forms.Label lblLastJob;
        private System.Windows.Forms.Label lblPreviousJob;
        private System.Windows.Forms.LinkLabel llViewHistory;
        private System.Windows.Forms.Label lblLastDateTime;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.DateTimePicker dtmDOB;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshDataStoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadPendingCandidatesToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.CheckBox chkBoxUploadJobsite;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem viewLocalFilesToolStripMenuItem;
    }
}

