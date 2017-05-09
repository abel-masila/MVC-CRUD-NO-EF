using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace webCRUD_MVC.Models
{
    public class StudentDBHandle
    {
        private SqlConnection con;
        private void connection()
        {
            string connstring = ConfigurationManager.ConnectionStrings["StudentConn"].ToString();
            con = new SqlConnection(connstring);
        }
        /// <summary>
        /// Add New student Function
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddNewStudent(StudentModel Smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", Smodel.Name);
            cmd.Parameters.AddWithValue("@City", Smodel.City);
            cmd.Parameters.AddWithValue("@Address", Smodel.Address);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Get Student Details
        /// </summary>
        /// <returns></returns>
        public List<StudentModel> GetStudent()
        {
            connection();
            List<StudentModel> StudentList = new List<StudentModel>();
            SqlCommand cmd = new SqlCommand("GetStudentDetails",con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            foreach(DataRow dr in dt.Rows)
            {
                StudentList.Add(new StudentModel {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = Convert.ToString(dr["Name"]),
                    City=Convert.ToString(dr["City"]),
                    Address= Convert.ToString(dr["Address"]),
                });
            }
            return StudentList;
        }
        /// <summary>
        /// Update student Details
        /// </summary>
        /// <param name="sModel"></param>
        /// <returns></returns>
        public bool UpdateStudentDetails(StudentModel sModel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateStudentDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StdId", sModel.Id);
            cmd.Parameters.AddWithValue("@Name",sModel.Name);
            cmd.Parameters.AddWithValue("@City",sModel.City);
            cmd.Parameters.AddWithValue("@Address", sModel.Address);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Delete Student Details
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteStudent(int Id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteStudent",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StdId",Id);
            con.Open();
            int i=cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}