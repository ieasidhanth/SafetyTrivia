using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizzed
{
    public partial class SignupPage : Form
    {
        private string first_name;
        private string last_name;
        private string job_Name;
        private string cat;
        private string CDob;
        private DataSet dBank;
        private string full_name;
        private string sURL;
        public SignupPage(string fname, string lname, string job, string category, string dob, DataSet DataBank, string siteURL)
        {
            InitializeComponent();
            first_name = fname;
            last_name = lname;
            job_Name = job;
            cat = category;
            CDob = dob;
            dBank = DataBank;
            full_name = fname + " " + lname;
            sURL = siteURL;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(chk_condition.Checked)
            {
                try
                {
                    createPDFV2(Create_Directory(first_name+"_"+last_name));
                    this.Hide();
                    Quiz newQuiz = new Quiz(first_name, last_name, job_Name, cat, CDob, dBank,sURL);
                    newQuiz.Show();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                

            }
            else
            {
                MessageBox.Show("Kindly accept the terms and condition before proceeding to the quiz");
            }
        }
        public string createPDFV2(string destinationPath)
        {
            string name = lbl_Name.Text;
            
            string agreement_line1 = @"I,  " + full_name + " hereby acknowledge that I have read and fully understand the rules that were brought forth during my orientation, and agree to comply with the information stated at all times on this construction site.";
            string agreement_line2 = @"I also understand that disregard for these rules can result in disciplinary action up to and including immediate termination. If I do not understand these or any rules, policies, or procedures covered during this orientation, it is then my responsibility to ask. ";
            string agreement_line3 = @"I understand that this orientation is to be used in addition to IEA’s Corporate Health and Safety Program as well as any other Site-Safety rules. ";
            string agreement_line4 = @"A copy of these Policies and Procedures may be found in the Site Safety Manager’s Office. I also have been given the minimum PPE required per the site policy.";
            string agreement_line5 = @"It is also understood, that all IEA employees/sub-contractors shall comply with the Site-Specific Safety Plan which is located in the Site Safety Manager’s Office.";
            string signed_by = "Signed by \n"+full_name+"\n"+DateTime.Now.ToShortDateString();
            
            DirectoryInfo info = new DirectoryInfo(destinationPath);
            DirectorySecurity security = info.GetAccessControl();
            //Regex.Replace(destinationPath.Trim(), "[^A-Za-z0-9_. \\]+", "");
            destinationPath = destinationPath + "\\" + "Agreement_"+full_name + ".pdf";
            destinationPath = Path.Combine(destinationPath);
            destinationPath = destinationPath.Replace('/', '_');
            Path.GetInvalidFileNameChars().Aggregate(destinationPath, (current, c) => current.Replace(c.ToString(), string.Empty));
            Document document = new Document(PageSize.A4, 30, 30, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(destinationPath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite));
            document.AddSubject("Agreement");
            document.AddTitle("Agreement");
            document.Open();
            document.AddHeader("Develpoed", "Developed by IEA Dev team.All rights Reserved");
            PdfContentByte cb = writer.DirectContent;
            cb.SetLineWidth(2.0f);   // Make a bit thicker than 1.0 default
            cb.SetGrayStroke(0.95f); // 1 = black, 0 = white
            cb.MoveTo(20, 30);
            cb.LineTo(400, 30);

            iTextSharp.text.Rectangle pageRect = document.PageSize;
            Bitmap bmp = new Bitmap(Quizzed.Properties.Resources.IEA_Logo);

            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance((System.Drawing.Image)bmp, BaseColor.WHITE);
            document.Add(img);
            
            Chunk lb = new Chunk(new iTextSharp.text.pdf.draw.LineSeparator());
            document.Add(lb);
            document.Add(new Paragraph(""));
            document.Add(new Paragraph(""));
            document.Add(new Paragraph(""));
            document.Add(new Paragraph("Agreement", new iTextSharp.text.Font(BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.WINANSI, BaseFont.EMBEDDED), (float)20)));
            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("Candidate Name: " + full_name));
            document.Add(new Paragraph("Jobsite: " + job_Name));
            document.Add(new Paragraph("Timestamp: " + DateTime.Now));
            document.Add(lb);
           
            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph("\n"));


                document.Add(new Paragraph(agreement_line1));
            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph(agreement_line2));
            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph(agreement_line3));
            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph(agreement_line4));
            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph(agreement_line5));
            document.Add(new Paragraph("\n"));
            document.Add(new Paragraph(signed_by));
            document.Add(new Paragraph("\n"));

            //cb.Stroke();
            Chunk linebreak = new Chunk(new iTextSharp.text.pdf.draw.DottedLineSeparator());
                document.Add(linebreak);

                document.Add(new Paragraph(""));
              

           

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

        private void SignupPage_Load(object sender, EventArgs e)
        {
            lbl_Name.Text = full_name;
        }
    }

}
