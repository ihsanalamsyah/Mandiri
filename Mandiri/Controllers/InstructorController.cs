using JIWA.DataAccess;
using Mandiri.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.Json;
using System.Configuration;
using System.Configuration.Assemblies;

namespace Mandiri.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        #region Global variables

        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DbMandiriAccess"].ConnectionString;

        #endregion


        [HttpGet, Route("api/sylabus/instructor/get")]
        public List<Ayo> GetInstructor()
        {

            List<Ayo> ls_ayo = new List<Ayo>();
            try
            {
      
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    var query = string.Format("SELECT * FROM Ayo");

                    using (SqlCommand cmd = new SqlCommand(query, con) )
                    {

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Ayo ayo = new Ayo();
                                ayo.Id = reader[0].ToString() == null || string.IsNullOrEmpty(reader[0].ToString()) ? Guid.Empty : Guid.Parse(reader[0].ToString());
                                ayo.Name = reader[1].ToString();
                                ayo.Email = reader[2].ToString();


                                ls_ayo.Add(ayo);
                            }
                        }
                    }
                                  
                }             
            }
            catch(Exception err) 
            {
                return ls_ayo;
            }

            var response = string.Format("0: SUCCESS");
            return ls_ayo;
        }

        [HttpPost, Route("api/sylabus/instructor/create")]
        public string CreateInstructor(Ayo input)
        {
          

            List<Pengunjung> ls_pengunjung = new List<Pengunjung>();
            try
            {
                              
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    var query = string.Format("INSERT INTO Ayo VALUES (CONVERT(uniqueidentifier, @param1), @param2, @param3)");

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Clear();
                        input.Id = Guid.NewGuid();
                        cmd.Parameters.Add("@param1", SqlDbType.UniqueIdentifier).Value = input.Id;
                        cmd.Parameters.Add("@param2", SqlDbType.VarChar).Value = input.Name;
                        cmd.Parameters.Add("@param3", SqlDbType.VarChar).Value = input.Email;
                        
                        cmd.ExecuteNonQuery();
                      
                    }

                }
            }
            catch (Exception err)
            {
                return string.Format("1: ISSUER_DECLINED");
            }

            var response = string.Format("0: SUCCESS");
            return response;
        }

        [HttpDelete, Route("api/sylabus/instructor/delete")]
        public string DeleteInstructor(Ayo input)
        {
          
            List<Pengunjung> ls_pengunjung = new List<Pengunjung>();
            try
            {
               
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    var query = string.Format("DELETE FROM Ayo WHERE Id = @param1");

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {                
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@param1", SqlDbType.UniqueIdentifier).Value = input.Id;
                        cmd.ExecuteNonQuery();

                    }

                }
            }
            catch (Exception err)
            {
                return string.Format("1: ISSUER_DECLINED");
            }

            var response = string.Format("0: SUCCESS");
            return response;
        }

        [HttpPost, Route("api/sylabus/instructor/update")]
        public string UpdateInstructor(Ayo input)
        {


            List<Ayo> ls_ayo = new List<Ayo>();
            try
            {
                    
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    var query = string.Format("UPDATE Ayo SET Name = @param2, Email = @param3 WHERE Id = @param1");

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@param1", SqlDbType.UniqueIdentifier).Value = input.Id;
                        cmd.Parameters.Add("@param2", SqlDbType.VarChar).Value = input.Name;
                        cmd.Parameters.Add("@param3", SqlDbType.VarChar).Value = input.Email;
                        cmd.ExecuteNonQuery();

                    }

                }
            }
            catch (Exception err)
            {
                return string.Format("1: ISSUER_DECLINED");
            }

            var response = string.Format("0: SUCCESS");
            return response;
        }
    }
}
