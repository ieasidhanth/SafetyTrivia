using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Quizzed
{
    class DSL_offline
    {
        private SqlConnection sqlConn;
        private DataTable qbank;
        private DataTable candidate_info;
        private DataTable jobSiteInfo;
        private DataTable category;
        private DataTable quiz_video;
        private DataTable quizList;
        private DataTable quiz_cat_relatn;
        private string filename_candidateInfo;
        private string filename_jobSiteInfo;
        private string filename_category;
        private string filename_quizVideo;
        private string filename_quizList;
        private string filename_qbank;
        private string filename_quiz_cat_reln;
        private string local_data_path;

        public DSL_offline()
        {
           local_data_path= Application.StartupPath+"\\"+"Local_Data";
           filename_candidateInfo = local_data_path + "\\" + "candidateInfo.xml";
            filename_jobSiteInfo = local_data_path + "\\" + "jobInfo.xml";
            filename_category = local_data_path + "\\" + "Category.xml";
            filename_quizVideo = local_data_path + "\\" + "Quiz_Video.xml";
            filename_quizList = local_data_path + "\\" + "QuizList$.xml";
            filename_qbank = local_data_path + "\\" + "qBank_V2.xml";
            filename_quiz_cat_reln = local_data_path + "\\" + "Quiz_Category_Relation.xml";

            //try
            //{


            //    Connection conn = new Connection();
            //    sqlConn = conn.initiateConnection();
            //    if (sqlConn == null)
            //    {
            //        throw new NullReferenceException();

            //    }
                    
            //}
            //catch(SqlException ex)
            //{
            //    throw ex;
            //}
            
            


        }

        public DataTable getallQuestions()
        {
            SqlDataAdapter adap = new SqlDataAdapter("Select * from qBank;", sqlConn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            return dt;

        }
        public DataTable getallQuestionsByCategory(string category)
        {
            //SqlDataAdapter adap = new SqlDataAdapter("Select * from qBank_v2 where category_ID="+category+";", sqlConn);
            //DataTable dt = new DataTable();
            //adap.Fill(dt);
            //return dt;
            try
            {
                DataTable dt = new DataTable();
                dt.ReadXml(filename_qbank);
                DataRow[] rows = dt.Select("category_ID =" + category);
                qbank = new DataTable();
                qbank=dt.Clone();
                foreach(DataRow row in rows)
                {
                    qbank.ImportRow(row);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return qbank;

        }

        public DataTable getallQuestions(List<int> QuizIds, string cat)
        {
            //string qids = "";
            //foreach(int ids in QuizIds)
            //{
            //    qids = qids + ids + ",";

            //}
            //qids = qids.Substring(0, qids.LastIndexOf(','));
            //string query = "Select * from qBank where QuizNumber in (" + qids + ")";
            //SqlDataAdapter adap = new SqlDataAdapter(query, sqlConn);
            //DataTable dt = new DataTable();
            //adap.Fill(dt);
            ////foreach(DataRow row in dt.Rows)
            ////{
            ////    row["AllowedAttempts"] = 1;
            ////}
            //return dt;
            DataTable category = getCategories();
            int catid = -1;
            foreach(DataRow row in category.Rows)
            {
                if (Convert.ToString(row["CategoryName"]) == cat)
                {
                    catid = Convert.ToInt32(row["CategoryID"]);
                    break;

                }
                    

            }
            DataTable dt = new DataTable();
            try
            {
                DataTable tempTable = new DataTable();
                tempTable.ReadXml(filename_qbank);
                
                dt = tempTable.Clone();
                foreach (int ids in QuizIds)
                {
                    DataRow[] rows = tempTable.Select("QuizNumber = "+ids+" AND Category_ID = "+catid );
                    foreach(DataRow row in rows )
                    {
                        dt.ImportRow(row);
                    }
                    

                }


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            return dt;

        }

        public int getQuizCount()
        {
            SqlCommand cmd = new SqlCommand("Select count(distinct(QuizNumber)) from QuestionBank;", sqlConn);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }
        public int getQuizCount_ByCategory(string category)
        {
            //SqlCommand cmd = new SqlCommand("Select count(distinct(QuizNumber)) from qBank_v2 where category_ID="+category+";", sqlConn);
            //int result = Convert.ToInt32(cmd.ExecuteScalar());
            //return result;
            List<DataRow> rowCollection=new List<DataRow>();
            try
            {
                DataTable dt = new DataTable();
                dt.ReadXml(filename_qbank);
                DataRow[] rows = dt.Select("category_ID =" + category);
                DataTable dt1 = new DataTable();
                dt1 = dt.Clone();
                foreach (DataRow row in rows)
                {
                    dt1.ImportRow(row);
                }
                rowCollection=dt1.Select("QuizNumber").Distinct().ToList();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return rowCollection.Count();
        }

        public DataTable getCategories()
        {
            //string query = "Select * from Category";
            //SqlDataAdapter adap = new SqlDataAdapter(query, sqlConn);
            //DataTable dt = new DataTable();
            //adap.Fill(dt);

            try
            {
                category = new DataTable();
                category.ReadXml(filename_category);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return category;
        }
        public DataTable get_all_quizes()
        {
            //string query = "Select * from  QuizList$";
            //SqlDataAdapter adap = new SqlDataAdapter(query, sqlConn);
            //DataTable dt = new DataTable();
            //adap.Fill(dt);
            //return dt;
            try
            {
                quizList = new DataTable();
                quizList.ReadXml(filename_quizList);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return quizList;
        }
        public string get_quiz_List(int catID)
        {
            //string query = "Select * From Quiz_Category_Relation where Category_ID="+catID;
            //SqlDataAdapter adap = new SqlDataAdapter(query, sqlConn);
            //DataTable dt = new DataTable();
            //adap.Fill(dt);
            //string quizList = "";
            //foreach(DataRow row in dt.Rows)
            //{
            //    quizList = quizList + Convert.ToString(row["Quiz_ID"]) + "#";

            //}
            //return (quizList.Substring(0, quizList.LastIndexOf('#')));
            string qList = "";
            try
            {
                quiz_cat_relatn = new DataTable();
                quiz_cat_relatn.ReadXml(filename_quiz_cat_reln);
                DataRow[] rows = quiz_cat_relatn.Select("Category_ID =" + catID);
                
                foreach (DataRow row in rows)
                {
                    qList = qList + Convert.ToString(row["Quiz_ID"]) + "#";

                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return (qList.Substring(0, qList.LastIndexOf('#')));

        }

        public DataTable get_QuizLinks()
        {
            //string query = "Select * From Quiz_Video";
            //SqlDataAdapter adap = new SqlDataAdapter(query, sqlConn);
            //DataTable dt = new DataTable();
            //adap.Fill(dt);
            //return dt;
            try
            {
                quiz_video = new DataTable();
                quiz_video.ReadXml(filename_quizVideo);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return quiz_video;
        }
        public DataTable get_jobList()
        {
            DataTable dt = new DataTable();
            try
            {
                dt.ReadXml(filename_jobSiteInfo);
                return dt;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        
    }
}
