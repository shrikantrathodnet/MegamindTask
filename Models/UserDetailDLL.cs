using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmpTask.Models
{
    public class UserDetailDLL
    {
        public List<UserDetail> userDetails()
        {
            List<UserDetail> userDetails = new List<UserDetail>();

            string cs = ConfigurationManager.ConnectionStrings["Employee"].ConnectionString;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("UserDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        UserDetail p = new UserDetail();
                        p.Id = (int)reader["Id"];
                        p.Name = reader["Name"].ToString();
                        p.Phone = reader["Phone"].ToString();
                        p.Email = reader["Email"].ToString();
                        p.Address = reader["Address"].ToString();
                      
                       
                        userDetails.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {

                return null;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

            return userDetails;
        }
        public bool Create(UserDetail userDetail)
        {

            string cs = ConfigurationManager.ConnectionStrings["Employee"].ConnectionString;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("CreateUserDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", userDetail.Name);
                cmd.Parameters.AddWithValue("@Phone", userDetail.Phone);
                cmd.Parameters.AddWithValue("@Address", userDetail.Address);
                cmd.Parameters.AddWithValue("@Email", userDetail.Email);
                cmd.Parameters.AddWithValue("@StateId", userDetail.StateId);
                cmd.Parameters.AddWithValue("@CityId", userDetail.CityId);

                SqlParameter status = new SqlParameter();
                status.ParameterName = "@Status";
                status.Direction = ParameterDirection.Output;
                status.SqlDbType = SqlDbType.Bit;
                cmd.Parameters.Add(status);

                con.Open();
                cmd.ExecuteNonQuery();
                return (bool)status.Value;
            }
            catch (Exception ex)
            {

                return false;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public bool Update(UserDetail userDetail)
        {

            string cs = ConfigurationManager.ConnectionStrings["Employee"].ConnectionString;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("EditUserDetails ", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", userDetail.Id);
                cmd.Parameters.AddWithValue("@Name", userDetail.Name);
                cmd.Parameters.AddWithValue("@Phone", userDetail.Phone);
                cmd.Parameters.AddWithValue("@Address", userDetail.Address);
                cmd.Parameters.AddWithValue("@Email", userDetail.Email);
                cmd.Parameters.AddWithValue("@StateId", userDetail.StateId);
                cmd.Parameters.AddWithValue("@CityId", userDetail.CityId);

                SqlParameter status = new SqlParameter();
                status.ParameterName = "@Status";
                status.Direction = ParameterDirection.Output;
                status.SqlDbType = SqlDbType.Bit;
                cmd.Parameters.Add(status);

                con.Open();
                cmd.ExecuteNonQuery();
                return (bool)status.Value;
            }
            catch (Exception ex)
            {

                return false;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        public bool Delete(int id)
        {

            string cs = ConfigurationManager.ConnectionStrings["Employee"].ConnectionString;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("DeleteUserDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);


                SqlParameter status = new SqlParameter();
                status.ParameterName = "@Status";
                status.Direction = ParameterDirection.Output;
                status.SqlDbType = SqlDbType.Bit;
                cmd.Parameters.Add(status);

                con.Open();
                cmd.ExecuteNonQuery();
                return (bool)status.Value;
            }
            catch (Exception ex)
            {

                return false;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }
        public UserDetail DetailsById(int id)
        {


            string cs = ConfigurationManager.ConnectionStrings["Employee"].ConnectionString;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("UserDetailsById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UserDetail p = new UserDetail();
                        p.Id = (int)reader["Id"];
                        p.Name = reader["Name"].ToString();
                        p.Email = reader["Email"].ToString();
                        p.Phone = reader["Phone"].ToString();
                        p.Address = reader["Address"].ToString();
                        p.StateId = (int)reader["StateId"];
                        p.CityId = (int)reader["CityId"];

                        return p;
                    }
                }
            }
            catch (Exception ex)
            {

                return null;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

            return null;
        }

    }
}