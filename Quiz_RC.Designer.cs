namespace Quizzed
{
    partial class Quiz_RC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Quiz_RC));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftpanel = new System.Windows.Forms.Panel();
            this.lblLinks = new System.Windows.Forms.Label();
            this.flwPanl_links = new System.Windows.Forms.FlowLayoutPanel();
            this.tbControlVidLinks = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.off_flwPnl = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.onl_flw_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPositionPlcHldr = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblJobName = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.tbcontrolQuizzes = new System.Windows.Forms.TabControl();
            this.Quiz1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPreviousQues = new System.Windows.Forms.Button();
            this.tab1_answer_option_panel = new System.Windows.Forms.Panel();
            this.btnNext = new System.Windows.Forms.Button();
            this.labl_tab1_QNo = new System.Windows.Forms.Label();
            this.tab1_QuizHeading = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.questionBankBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quizzedDataSet = new Quizzed.QuizzedDataSet();
            this.questionBankTableAdapter = new Quizzed.QuizzedDataSetTableAdapters.QuestionBankTableAdapter();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.leftpanel.SuspendLayout();
            this.flwPanl_links.SuspendLayout();
            this.tbControlVidLinks.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.tbcontrolQuizzes.SuspendLayout();
            this.Quiz1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.questionBankBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quizzedDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(2512, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // leftpanel
            // 
            this.leftpanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.leftpanel.Controls.Add(this.lblLinks);
            this.leftpanel.Controls.Add(this.flwPanl_links);
            this.leftpanel.Controls.Add(this.lblPositionPlcHldr);
            this.leftpanel.Controls.Add(this.lblCategory);
            this.leftpanel.Controls.Add(this.lblJobName);
            this.leftpanel.Controls.Add(this.lblName);
            this.leftpanel.Controls.Add(this.label5);
            this.leftpanel.Controls.Add(this.label4);
            this.leftpanel.Controls.Add(this.label2);
            this.leftpanel.Location = new System.Drawing.Point(33, 16);
            this.leftpanel.Name = "leftpanel";
            this.leftpanel.Size = new System.Drawing.Size(284, 761);
            this.leftpanel.TabIndex = 2;
            // 
            // lblLinks
            // 
            this.lblLinks.AutoSize = true;
            this.lblLinks.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblLinks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.lblLinks.Location = new System.Drawing.Point(17, 228);
            this.lblLinks.Name = "lblLinks";
            this.lblLinks.Size = new System.Drawing.Size(81, 13);
            this.lblLinks.TabIndex = 11;
            this.lblLinks.Text = "Video Links";
            // 
            // flwPanl_links
            // 
            this.flwPanl_links.AutoSize = true;
            this.flwPanl_links.Controls.Add(this.tbControlVidLinks);
            this.flwPanl_links.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flwPanl_links.Location = new System.Drawing.Point(22, 258);
            this.flwPanl_links.Name = "flwPanl_links";
            this.flwPanl_links.Size = new System.Drawing.Size(241, 493);
            this.flwPanl_links.TabIndex = 10;
            // 
            // tbControlVidLinks
            // 
            this.tbControlVidLinks.Controls.Add(this.tabPage1);
            this.tbControlVidLinks.Controls.Add(this.tabPage3);
            this.tbControlVidLinks.Font = new System.Drawing.Font("Verdana", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbControlVidLinks.Location = new System.Drawing.Point(3, 3);
            this.tbControlVidLinks.Name = "tbControlVidLinks";
            this.tbControlVidLinks.SelectedIndex = 0;
            this.tbControlVidLinks.Size = new System.Drawing.Size(235, 487);
            this.tbControlVidLinks.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(236)))));
            this.tabPage1.Controls.Add(this.off_flwPnl);
            this.tabPage1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(227, 461);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Offline Links";
            // 
            // off_flwPnl
            // 
            this.off_flwPnl.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.off_flwPnl.Location = new System.Drawing.Point(8, 18);
            this.off_flwPnl.Name = "off_flwPnl";
            this.off_flwPnl.Size = new System.Drawing.Size(203, 437);
            this.off_flwPnl.TabIndex = 7;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(236)))));
            this.tabPage3.Controls.Add(this.onl_flw_panel);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(305, 461);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Online Links";
            // 
            // onl_flw_panel
            // 
            this.onl_flw_panel.Location = new System.Drawing.Point(8, 22);
            this.onl_flw_panel.Name = "onl_flw_panel";
            this.onl_flw_panel.Size = new System.Drawing.Size(278, 421);
            this.onl_flw_panel.TabIndex = 7;
            // 
            // lblPositionPlcHldr
            // 
            this.lblPositionPlcHldr.AutoSize = true;
            this.lblPositionPlcHldr.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPositionPlcHldr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.lblPositionPlcHldr.Location = new System.Drawing.Point(128, 158);
            this.lblPositionPlcHldr.MaximumSize = new System.Drawing.Size(134, 0);
            this.lblPositionPlcHldr.Name = "lblPositionPlcHldr";
            this.lblPositionPlcHldr.Size = new System.Drawing.Size(75, 13);
            this.lblPositionPlcHldr.TabIndex = 9;
            this.lblPositionPlcHldr.Text = "lblPosition";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.lblCategory.Location = new System.Drawing.Point(17, 158);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(63, 13);
            this.lblCategory.TabIndex = 8;
            this.lblCategory.Text = "Position:";
            // 
            // lblJobName
            // 
            this.lblJobName.AutoSize = true;
            this.lblJobName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblJobName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.lblJobName.Location = new System.Drawing.Point(128, 96);
            this.lblJobName.MaximumSize = new System.Drawing.Size(134, 0);
            this.lblJobName.Name = "lblJobName";
            this.lblJobName.Size = new System.Drawing.Size(82, 13);
            this.lblJobName.TabIndex = 6;
            this.lblJobName.Text = "lblJobName";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.lblName.Location = new System.Drawing.Point(128, 54);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(60, 13);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "lblName";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.label5.Location = new System.Drawing.Point(17, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Job: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.label4.Location = new System.Drawing.Point(17, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Name: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.label2.Location = new System.Drawing.Point(17, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Candidate Details";
            // 
            // rightPanel
            // 
            this.rightPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rightPanel.Controls.Add(this.tbcontrolQuizzes);
            this.rightPanel.Location = new System.Drawing.Point(317, 16);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(2512, 761);
            this.rightPanel.TabIndex = 3;
            // 
            // tbcontrolQuizzes
            // 
            this.tbcontrolQuizzes.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tbcontrolQuizzes.Controls.Add(this.Quiz1);
            this.tbcontrolQuizzes.Controls.Add(this.tabPage2);
            this.tbcontrolQuizzes.Location = new System.Drawing.Point(18, 14);
            this.tbcontrolQuizzes.Name = "tbcontrolQuizzes";
            this.tbcontrolQuizzes.SelectedIndex = 0;
            this.tbcontrolQuizzes.Size = new System.Drawing.Size(1476, 745);
            this.tbcontrolQuizzes.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tbcontrolQuizzes.TabIndex = 0;
            this.tbcontrolQuizzes.SelectedIndexChanged += new System.EventHandler(this.tbcontrolQuizzes_SelectedIndexChanged);
            // 
            // Quiz1
            // 
            this.Quiz1.AutoScroll = true;
            this.Quiz1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))));
            this.Quiz1.Controls.Add(this.label1);
            this.Quiz1.Controls.Add(this.btnPreviousQues);
            this.Quiz1.Controls.Add(this.tab1_answer_option_panel);
            this.Quiz1.Controls.Add(this.btnNext);
            this.Quiz1.Controls.Add(this.labl_tab1_QNo);
            this.Quiz1.Controls.Add(this.tab1_QuizHeading);
            this.Quiz1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quiz1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.Quiz1.Location = new System.Drawing.Point(4, 25);
            this.Quiz1.Name = "Quiz1";
            this.Quiz1.Padding = new System.Windows.Forms.Padding(3);
            this.Quiz1.Size = new System.Drawing.Size(1468, 716);
            this.Quiz1.TabIndex = 0;
            this.Quiz1.Text = "Quiz1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.label1.Location = new System.Drawing.Point(74, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "label";
            // 
            // btnPreviousQues
            // 
            this.btnPreviousQues.Location = new System.Drawing.Point(19, 353);
            this.btnPreviousQues.Name = "btnPreviousQues";
            this.btnPreviousQues.Size = new System.Drawing.Size(146, 23);
            this.btnPreviousQues.TabIndex = 5;
            this.btnPreviousQues.Text = "Previous Question";
            this.btnPreviousQues.UseVisualStyleBackColor = true;
            this.btnPreviousQues.TabIndexChanged += new System.EventHandler(this.btnPreviousQues_TabIndexChanged);
            // 
            // tab1_answer_option_panel
            // 
            this.tab1_answer_option_panel.Location = new System.Drawing.Point(19, 133);
            this.tab1_answer_option_panel.Name = "tab1_answer_option_panel";
            this.tab1_answer_option_panel.Size = new System.Drawing.Size(528, 150);
            this.tab1_answer_option_panel.TabIndex = 4;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(215, 353);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(146, 23);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next Question";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // labl_tab1_QNo
            // 
            this.labl_tab1_QNo.AutoSize = true;
            this.labl_tab1_QNo.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.labl_tab1_QNo.Location = new System.Drawing.Point(16, 79);
            this.labl_tab1_QNo.Name = "labl_tab1_QNo";
            this.labl_tab1_QNo.Size = new System.Drawing.Size(38, 16);
            this.labl_tab1_QNo.TabIndex = 1;
            this.labl_tab1_QNo.Text = "label";
            // 
            // tab1_QuizHeading
            // 
            this.tab1_QuizHeading.AutoSize = true;
            this.tab1_QuizHeading.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold);
            this.tab1_QuizHeading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tab1_QuizHeading.Location = new System.Drawing.Point(9, 16);
            this.tab1_QuizHeading.Name = "tab1_QuizHeading";
            this.tab1_QuizHeading.Size = new System.Drawing.Size(478, 29);
            this.tab1_QuizHeading.TabIndex = 0;
            this.tab1_QuizHeading.Text = "Trenching and Shoring Safety Quiz";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1468, 716);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Quiz2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // questionBankBindingSource
            // 
            this.questionBankBindingSource.DataMember = "QuestionBank";
            this.questionBankBindingSource.DataSource = this.quizzedDataSet;
            // 
            // quizzedDataSet
            // 
            this.quizzedDataSet.DataSetName = "QuizzedDataSet";
            this.quizzedDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // questionBankTableAdapter
            // 
            this.questionBankTableAdapter.ClearBeforeFill = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 792);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 18, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1884, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "Safety Trivia v2.0";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))));
            this.panel1.Controls.Add(this.leftpanel);
            this.panel1.Controls.Add(this.rightPanel);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1884, 792);
            this.panel1.TabIndex = 6;
            // 
            // Quiz_RC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(237)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1884, 814);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(52)))), ((int)(((byte)(60)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Quiz_RC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quiz";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Quiz_RC_FormClosing);
            this.Load += new System.EventHandler(this.Quiz_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.leftpanel.ResumeLayout(false);
            this.leftpanel.PerformLayout();
            this.flwPanl_links.ResumeLayout(false);
            this.tbControlVidLinks.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
            this.tbcontrolQuizzes.ResumeLayout(false);
            this.Quiz1.ResumeLayout(false);
            this.Quiz1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.questionBankBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quizzedDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Panel leftpanel;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.TabControl tbcontrolQuizzes;
        private System.Windows.Forms.TabPage Quiz1;
        private System.Windows.Forms.Label labl_tab1_QNo;
        private System.Windows.Forms.Label tab1_QuizHeading;
        private System.Windows.Forms.TabPage tabPage2;
        private QuizzedDataSet quizzedDataSet;
        private System.Windows.Forms.BindingSource questionBankBindingSource;
        private QuizzedDataSetTableAdapters.QuestionBankTableAdapter questionBankTableAdapter;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel tab1_answer_option_panel;
        private System.Windows.Forms.Button btnPreviousQues;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblJobName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPositionPlcHldr;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.FlowLayoutPanel flwPanl_links;
        private System.Windows.Forms.Label lblLinks;
        private System.Windows.Forms.TabControl tbControlVidLinks;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel off_flwPnl;
        private System.Windows.Forms.FlowLayoutPanel onl_flw_panel;
    }
}