using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Drawing;
using mvcBolierplate.Models;
using System.Collections;

namespace mvcBolierplate
{
    public class Helper
    {
        string con = @"Data Source = 10.50.18.16; Initial Catalog = training_db; User ID = SVC_TRANING; Password = Gemini@123; TrustServerCertificate=True";

        public DataTable show()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();
                string query = "Select * from City";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                sda.Fill(dt);
            }
            return dt;
        }
        public void addnew(cityModel CityModel)
        {
            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();
                string query = "Insert Into City Values(@CityName)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CityName", CityModel.CityName);
                cmd.ExecuteNonQuery();
            }

        }
        public DataTable Edit(int id)
        {
            cityModel CityModel = new cityModel();
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();
                string query = "Select * from City where CityID = @CityId";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                sda.SelectCommand.Parameters.AddWithValue("@CityId", id);
                sda.Fill(dt);
            }
            return dt;
        }
        public void Edit(cityModel CityModel)
        {
            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();
                string query = "Update  City Set CityName = @CityName where CityId = @CityId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CityId", CityModel.CityId);
                cmd.Parameters.AddWithValue("@CityName", CityModel.CityName);
                cmd.ExecuteNonQuery();
            }
        }
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();
                string query = "Delete from City where CityId = @CityId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CityId", id);
                //  cmd.Parameters.AddWithValue("@CityName", CityModel.CityName);
                cmd.ExecuteNonQuery();
            }
        }
    }
}