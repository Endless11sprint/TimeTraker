using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;
//using System.Data;
using System.Data.SqlClient;

namespace TimeTraker
{
    public static class IdDateBase
    {
        static private readonly SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);



        static public List<int> Id()
        {
            sqlConnection.Open();

            List<int> id = new List<int>();
            SqlCommand sqlCom = new SqlCommand("SELECT Id FROM Tasks", sqlConnection);
            SqlDataReader Reader;
            Reader = sqlCom.ExecuteReader();
            while (Reader.Read())
            {
                id.Add(int.Parse(Reader.GetValue(0).ToString()));
            }
            sqlConnection.Close();
            return id;
        }


        static public List<int> IdActive()
        {
            sqlConnection.Open();

            List<int> id = new List<int>();
            SqlCommand sqlCom = new SqlCommand("SELECT Id FROM TasksActive", sqlConnection);
            SqlDataReader Reader;
            Reader = sqlCom.ExecuteReader();
            while (Reader.Read())
            {
                id.Add(int.Parse(Reader.GetValue(0).ToString()));
            }
            sqlConnection.Close();
            return id;
        }

        static public List<int> IdOver()
        {
            sqlConnection.Open();

            List<int> id = new List<int>();
            SqlCommand sqlCom = new SqlCommand("SELECT Id FROM TasksOver", sqlConnection);
            SqlDataReader Reader;
            Reader = sqlCom.ExecuteReader();
            while (Reader.Read())
            {
                id.Add(int.Parse(Reader.GetValue(0).ToString()));
            }
            sqlConnection.Close();
            return id;
        }

        static public string GetName(int id)
        {
            string result;
           
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCom = new SqlCommand($"SELECT Name FROM Tasks WHERE Id = {id} and DateStart IS null", sqlConnection);
                result = sqlCom.ExecuteScalar().ToString();
            }
            catch
            {
                sqlConnection.Close();
                result = "Ничего не поулчил";
            }
            sqlConnection.Close();
            return result;
        }

        static public string GetNameActive(int id)
        {
            string result;

            try
            {
                sqlConnection.Open();
                SqlCommand sqlCom = new SqlCommand($"SELECT Name FROM TasksActive WHERE Id = {id} and DateFinish IS null", sqlConnection);
                result = sqlCom.ExecuteScalar().ToString();
            }
            catch
            {
                sqlConnection.Close();
                result = "Ничего не поулчил";
            }
            sqlConnection.Close();
            return result;
        }

        static public string GetNameOver(int id)
        {
            string result;

            try
            {
                sqlConnection.Open();
                SqlCommand sqlCom = new SqlCommand($"SELECT Name FROM TasksOver WHERE Id = {id}", sqlConnection);
                result = sqlCom.ExecuteScalar().ToString();
            }
            catch
            {
                sqlConnection.Close();
                result = "Ничего не поулчил";
            }
            sqlConnection.Close();
            return result;
        }

        static public string GetDescription(int id)
        {
            string result;

            try
            {
                sqlConnection.Open();
                SqlCommand sqlCom = new SqlCommand($"SELECT Description FROM Tasks WHERE Id = {id} and DateStart IS null", sqlConnection);
                result = sqlCom.ExecuteScalar().ToString();
            }
            catch
            {
                sqlConnection.Close();
                result = "Ничего не поулчил";
            }
            sqlConnection.Close();
            return result;
        }

        static public string GetDescriptionActive(int id)
        {
            string result;

            try
            {
                sqlConnection.Open();
                SqlCommand sqlCom = new SqlCommand($"SELECT Description FROM TasksActive WHERE Id = {id} and DateFinish IS null", sqlConnection);
                result = sqlCom.ExecuteScalar().ToString();
            }
            catch
            {
                sqlConnection.Close();
                result = "Ничего не поулчил";
            }
            sqlConnection.Close();
            return result;
        }

        static public string GetDescriptionOver(int id)
        {
            string result;

            try
            {
                sqlConnection.Open();
                SqlCommand sqlCom = new SqlCommand($"SELECT Description FROM TasksOver WHERE Id = {id}", sqlConnection);
                result = sqlCom.ExecuteScalar().ToString();
            }
            catch
            {
                sqlConnection.Close();
                result = "Ничего не поулчил";
            }
            sqlConnection.Close();
            return result;
        }

        static public string GetDateStartActive(int id)
        {
            string result;
            
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCom = new SqlCommand($"SELECT DateStart FROM TasksActive WHERE Id = {id}", sqlConnection);
                result = sqlCom.ExecuteScalar().ToString();
            }
            catch
            {
                sqlConnection.Close();
                result = "Ничего не поулчил";
            }
            sqlConnection.Close();
            return result;
        }

        static public string GetDateStartOver(int id)
        {
            string result;

            try
            {
                sqlConnection.Open();
                SqlCommand sqlCom = new SqlCommand($"SELECT DateStart FROM TasksOver WHERE Id = {id}", sqlConnection);
                result = sqlCom.ExecuteScalar().ToString();
            }
            catch
            {
                sqlConnection.Close();
                result = "Ничего не поулчил";
            }
            sqlConnection.Close();
            return result;
        }

        static public string GetDateFinishOver(int id)
        {
            string result;

            try
            {
                sqlConnection.Open();
                SqlCommand sqlCom = new SqlCommand($"SELECT DateFinish FROM TasksOver WHERE Id = {id}", sqlConnection);
                result = sqlCom.ExecuteScalar().ToString();
            }
            catch
            {
                sqlConnection.Close();
                result = "Ничего не поулчил";
            }
            sqlConnection.Close();
            return result;
        }
    }
}
