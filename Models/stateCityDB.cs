using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmpTask.Models
{
    public class stateCityDB
    {
        string cs = ConfigurationManager.ConnectionStrings["Employee"].ConnectionString;

        public DataSet GetState()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("select *from tblState", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet GetCity(string stateId)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("select *from tblCity where StateId=@catId", con);
            cmd.Parameters.AddWithValue("@catId",stateId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }



    }
}