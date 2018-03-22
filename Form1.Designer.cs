namespace Quizzed
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtmDOB = new System.Windows.Forms.DateTimePicker();
            this.lblDOB = new System.Windows.Forms.Label();
            this.pnl_configureTest = new System.Windows.Forms.Panel();
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblCopyright = new System.Windows.Forms.Label();
            this.QRCode_Panel = new System.Windows.Forms.Panel();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl_configureTest.SuspendLayout();
            this.panel_test_Status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.AllowDrop = true;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.panel1.ForeColor = System.Drawing.Color.SteelBlue;
            this.panel1.Name = "panel1";
            // 
            // dtmDOB
            // 
            this.dtmDOB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.dtmDOB, "dtmDOB");
            this.dtmDOB.Name = "dtmDOB";
            this.dtmDOB.Value = new System.DateTime(2017, 5, 31, 14, 6, 18, 0);
            // 
            // lblDOB
            // 
            resources.ApplyResources(this.lblDOB, "lblDOB");
            this.lblDOB.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblDOB.Name = "lblDOB";
            // 
            // pnl_configureTest
            // 
            this.pnl_configureTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_configureTest.Controls.Add(this.lblOR);
            this.pnl_configureTest.Controls.Add(this.lblLoadFlwingQuiz);
            this.pnl_configureTest.Controls.Add(this.pnl_QuizList);
            this.pnl_configureTest.Controls.Add(this.cmbxPositionRC);
            this.pnl_configureTest.Controls.Add(this.lblPosition);
            this.pnl_configureTest.Controls.Add(this.lblConfigureTest);
            resources.ApplyResources(this.pnl_configureTest, "pnl_configureTest");
            this.pnl_configureTest.Name = "pnl_configureTest";
            // 
            // lblOR
            // 
            resources.ApplyResources(this.lblOR, "lblOR");
            this.lblOR.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblOR.Name = "lblOR";
            // 
            // lblLoadFlwingQuiz
            // 
            resources.ApplyResources(this.lblLoadFlwingQuiz, "lblLoadFlwingQuiz");
            this.lblLoadFlwingQuiz.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblLoadFlwingQuiz.Name = "lblLoadFlwingQuiz";
            // 
            // pnl_QuizList
            // 
            resources.ApplyResources(this.pnl_QuizList, "pnl_QuizList");
            this.pnl_QuizList.Name = "pnl_QuizList";
            // 
            // cmbxPositionRC
            // 
            this.cmbxPositionRC.FormattingEnabled = true;
            resources.ApplyResources(this.cmbxPositionRC, "cmbxPositionRC");
            this.cmbxPositionRC.Name = "cmbxPositionRC";
            this.cmbxPositionRC.SelectedIndexChanged += new System.EventHandler(this.cmbxPositionRC_SelectedIndexChanged);
            this.cmbxPositionRC.SelectionChangeCommitted += new System.EventHandler(this.cmbxPositionRC_SelectionChangeCommitted);
            // 
            // lblPosition
            // 
            resources.ApplyResources(this.lblPosition, "lblPosition");
            this.lblPosition.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblPosition.Name = "lblPosition";
            // 
            // lblConfigureTest
            // 
            resources.ApplyResources(this.lblConfigureTest, "lblConfigureTest");
            this.lblConfigureTest.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblConfigureTest.Name = "lblConfigureTest";
            // 
            // cmxCategory
            // 
            this.cmxCategory.FormattingEnabled = true;
            resources.ApplyResources(this.cmxCategory, "cmxCategory");
            this.cmxCategory.Name = "cmxCategory";
            // 
            // lblTestDetails
            // 
            resources.ApplyResources(this.lblTestDetails, "lblTestDetails");
            this.lblTestDetails.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTestDetails.Name = "lblTestDetails";
            // 
            // panel_test_Status
            // 
            this.panel_test_Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_test_Status.Controls.Add(this.QRCode_Panel);
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
            this.lblLastDateTime.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblLastDateTime.Name = "lblLastDateTime";
            // 
            // lblLastTestDateTime
            // 
            resources.ApplyResources(this.lblLastTestDateTime, "lblLastTestDateTime");
            this.lblLastTestDateTime.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblLastTestDateTime.Name = "lblLastTestDateTime";
            // 
            // lblLastJob
            // 
            resources.ApplyResources(this.lblLastJob, "lblLastJob");
            this.lblLastJob.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblLastJob.Name = "lblLastJob";
            // 
            // lblPreviousJob
            // 
            resources.ApplyResources(this.lblPreviousJob, "lblPreviousJob");
            this.lblPreviousJob.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblPreviousJob.Name = "lblPreviousJob";
            // 
            // lblTestCountPlcHldr
            // 
            resources.ApplyResources(this.lblTestCountPlcHldr, "lblTestCountPlcHldr");
            this.lblTestCountPlcHldr.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTestCountPlcHldr.Name = "lblTestCountPlcHldr";
            // 
            // lblRemaingTestCount
            // 
            resources.ApplyResources(this.lblRemaingTestCount, "lblRemaingTestCount");
            this.lblRemaingTestCount.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblRemaingTestCount.Name = "lblRemaingTestCount";
            // 
            // txtBox_remaining_tst
            // 
            resources.ApplyResources(this.txtBox_remaining_tst, "txtBox_remaining_tst");
            this.txtBox_remaining_tst.Name = "txtBox_remaining_tst";
            this.txtBox_remaining_tst.ReadOnly = true;
            // 
            // lblPositionPlcHlder
            // 
            resources.ApplyResources(this.lblPositionPlcHlder, "lblPositionPlcHlder");
            this.lblPositionPlcHlder.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblPositionPlcHlder.Name = "lblPositionPlcHlder";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Name = "label1";
            // 
            // lblRemainingTests
            // 
            resources.ApplyResources(this.lblRemainingTests, "lblRemainingTests");
            this.lblRemainingTests.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblRemainingTests.Name = "lblRemainingTests";
            // 
            // lblHireStatus
            // 
            resources.ApplyResources(this.lblHireStatus, "lblHireStatus");
            this.lblHireStatus.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblHireStatus.Name = "lblHireStatus";
            // 
            // lblHireStatusPlcHolder
            // 
            resources.ApplyResources(this.lblHireStatusPlcHolder, "lblHireStatusPlcHolder");
            this.lblHireStatusPlcHolder.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblHireStatusPlcHolder.Name = "lblHireStatusPlcHolder";
            // 
            // lbllName
            // 
            resources.ApplyResources(this.lbllName, "lbllName");
            this.lbllName.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbllName.Name = "lbllName";
            // 
            // lblfName
            // 
            resources.ApplyResources(this.lblfName, "lblfName");
            this.lblfName.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblfName.Name = "lblfName";
            // 
            // rdBtnRCYes
            // 
            resources.ApplyResources(this.rdBtnRCYes, "rdBtnRCYes");
            this.rdBtnRCYes.Name = "rdBtnRCYes";
            this.rdBtnRCYes.UseVisualStyleBackColor = true;
            this.rdBtnRCYes.CheckedChanged += new System.EventHandler(this.rdBtnRCYes_CheckedChanged);
            // 
            // rdBtnRCNo
            // 
            resources.ApplyResources(this.rdBtnRCNo, "rdBtnRCNo");
            this.rdBtnRCNo.Checked = true;
            this.rdBtnRCNo.Name = "rdBtnRCNo";
            this.rdBtnRCNo.TabStop = true;
            this.rdBtnRCNo.UseVisualStyleBackColor = true;
            this.rdBtnRCNo.CheckedChanged += new System.EventHandler(this.rdBtnRCNo_CheckedChanged);
            // 
            // lblSelectCandidate
            // 
            resources.ApplyResources(this.lblSelectCandidate, "lblSelectCandidate");
            this.lblSelectCandidate.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblSelectCandidate.Name = "lblSelectCandidate";
            // 
            // lblReturningCandidate
            // 
            resources.ApplyResources(this.lblReturningCandidate, "lblReturningCandidate");
            this.lblReturningCandidate.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblReturningCandidate.Name = "lblReturningCandidate";
            this.lblReturningCandidate.Click += new System.EventHandler(this.lblReturningCandidate_Click);
            // 
            // btnInitialisze
            // 
            this.btnInitialisze.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnInitialisze.BackgroundImage = global::Quizzed.Properties.Resources.Quizzed;
            resources.ApplyResources(this.btnInitialisze, "btnInitialisze");
            this.btnInitialisze.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnInitialisze.Name = "btnInitialisze";
            this.btnInitialisze.UseVisualStyleBackColor = false;
            this.btnInitialisze.Click += new System.EventHandler(this.btnInitialisze_Click);
            // 
            // lblHeading
            // 
            resources.ApplyResources(this.lblHeading, "lblHeading");
            this.lblHeading.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblHeading.Name = "lblHeading";
            // 
            // cmxJobList
            // 
            this.cmxJobList.FormattingEnabled = true;
            resources.ApplyResources(this.cmxJobList, "cmxJobList");
            this.cmxJobList.Name = "cmxJobList";
            this.cmxJobList.DropDown += new System.EventHandler(this.AdjustWidthComboBox_DropDown);
            this.cmxJobList.SelectedIndexChanged += new System.EventHandler(this.cmxJobList_SelectedIndexChanged);
            this.cmxJobList.SelectionChangeCommitted += new System.EventHandler(this.cmxJobList_SelectionChangeCommitted);
            // 
            // txtBxLastName
            // 
            resources.ApplyResources(this.txtBxLastName, "txtBxLastName");
            this.txtBxLastName.Name = "txtBxLastName";
            this.txtBxLastName.Validating += new System.ComponentModel.CancelEventHandler(this.txtBxLastName_Validating);
            // 
            // lblSelectJob
            // 
            resources.ApplyResources(this.lblSelectJob, "lblSelectJob");
            this.lblSelectJob.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblSelectJob.Name = "lblSelectJob";
            // 
            // lblSupervisor
            // 
            resources.ApplyResources(this.lblSupervisor, "lblSupervisor");
            this.lblSupervisor.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblSupervisor.Name = "lblSupervisor";
            // 
            // lblLastName
            // 
            resources.ApplyResources(this.lblLastName, "lblLastName");
            this.lblLastName.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblLastName.Name = "lblLastName";
            // 
            // lblFirstName
            // 
            resources.ApplyResources(this.lblFirstName, "lblFirstName");
            this.lblFirstName.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblFirstName.Name = "lblFirstName";
            // 
            // cmbxCandidateList
            // 
            this.cmbxCandidateList.FormattingEnabled = true;
            resources.ApplyResources(this.cmbxCandidateList, "cmbxCandidateList");
            this.cmbxCandidateList.Name = "cmbxCandidateList";
            this.cmbxCandidateList.SelectionChangeCommitted += new System.EventHandler(this.cmbxCandidateList_SelectionChangeCommitted);
            // 
            // txtBxFName
            // 
            resources.ApplyResources(this.txtBxFName, "txtBxFName");
            this.txtBxFName.Name = "txtBxFName";
            this.txtBxFName.Validating += new System.ComponentModel.CancelEventHandler(this.txtBxFName_Validating);
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
            this.lblCopyright.Name = "lblCopyright";
            // 
            // QRCode_Panel
            // 
            resources.ApplyResources(this.QRCode_Panel, "QRCode_Panel");
            this.QRCode_Panel.Name = "QRCode_Panel";
            // 
            // Login
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.Name = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            this.Shown += new System.EventHandler(this.Login_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_configureTest.ResumeLayout(false);
            this.pnl_configureTest.PerformLayout();
            this.panel_test_Status.ResumeLayout(false);
            this.panel_test_Status.PerformLayout();
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
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel QRCode_Panel;
    }
}

