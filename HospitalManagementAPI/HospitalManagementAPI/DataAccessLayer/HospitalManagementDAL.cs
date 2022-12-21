using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using static HospitalManagementAPI.Entity.HospitalManagementEntity;

namespace HospitalManagementAPI.DataAccessLayer
{
    public class HospitalManagementDAL
    {
        private IConfiguration _configuration;
        private SqlConnection mydb;

        public HospitalManagementDAL(IConfiguration configuration)
        {
            _configuration = configuration;
            mydb = new SqlConnection(_configuration["ConnectionStrings:mydb"]);
        }
        public List<HospitalManagementRequest> GetHospitalManagement(string Type)
        {
            List<HospitalManagementRequest> lstRequest = new List<HospitalManagementRequest>();
            try
            {
                mydb.Open();
                SqlCommand cmd = new SqlCommand("Proc_HospitalManagementAPI", mydb);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", Type);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        HospitalManagementRequest hospitalManagementRequest = new HospitalManagementRequest();
                        hospitalManagementRequest.ID = Convert.ToInt32(sdr["ID"].ToString());
                        hospitalManagementRequest.FirstName = sdr["FirstName"].ToString();
                        hospitalManagementRequest.LastName = sdr["LastName"].ToString();
                        hospitalManagementRequest.MobileNumber = Convert.ToInt64(sdr["MobileNumber"].ToString());
                        hospitalManagementRequest.Disease = sdr["Disease"].ToString();
                        lstRequest.Add(hospitalManagementRequest);
                    }
                }
                mydb.Close();
                return lstRequest;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<HospitalManagementRequest> GetUserIDHospitalManagement(string Type, int ID)
        {
            List<HospitalManagementRequest> lstRequest = new List<HospitalManagementRequest>();
            try
            {
                mydb.Open();
                SqlCommand cmd = new SqlCommand("Proc_HospitalManagementAPI", mydb);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", Type);
                cmd.Parameters.AddWithValue("@ID", ID);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        HospitalManagementRequest hospitalManagementRequest = new HospitalManagementRequest();
                        hospitalManagementRequest.ID = Convert.ToInt32(sdr["ID"].ToString());
                        hospitalManagementRequest.FirstName = sdr["FirstName"].ToString();
                        hospitalManagementRequest.LastName = sdr["LastName"].ToString();
                        hospitalManagementRequest.MobileNumber = Convert.ToInt64(sdr["MobileNumber"].ToString());
                        hospitalManagementRequest.Disease = sdr["Disease"].ToString();
                        lstRequest.Add(hospitalManagementRequest);
                    }
                }
                mydb.Close();
                return lstRequest;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public HospitalManagementResponse HospitalManagement(HospitalManagementRequest hospitalManagementRequest, HospitalManagementResponse hospitalManagementResponse, string Type)
        {
            try
            {
                mydb.Open();
                SqlCommand sqlCommand = new SqlCommand("Proc_HospitalManagementAPI", mydb);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Type", Type);
                sqlCommand.Parameters.AddWithValue("@ID", hospitalManagementRequest.ID);
                sqlCommand.Parameters.AddWithValue("@FirstName", hospitalManagementRequest.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", hospitalManagementRequest.LastName);
                sqlCommand.Parameters.AddWithValue("@MobileNumber", hospitalManagementRequest.MobileNumber);
                sqlCommand.Parameters.AddWithValue("@Disease", hospitalManagementRequest.Disease);
                SqlDataReader sdr = sqlCommand.ExecuteReader();
                    if (sdr.Read())
                {
                    hospitalManagementResponse.isSucess = true;
                    hospitalManagementResponse.isMessage = sdr.GetValue(0).ToString();
                }
                mydb.Close();
            }
            catch (Exception ex)
            {
                hospitalManagementResponse.isMessage = ex.Message.ToString();
            }
            return hospitalManagementResponse;
        }
        public HospitalManagementResponse DeleteHospitalManagement(HospitalManagementResponse hospitalManagementResponse, int ID, string Type)
        {
            try
            {
                mydb.Open();
                SqlCommand sqlCommand  = new SqlCommand("Proc_HospitalManagementAPI", mydb);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Type",Type);
                sqlCommand.Parameters.AddWithValue("@ID", ID);
                SqlDataReader sdr = sqlCommand.ExecuteReader();
                if (sdr.Read())
                {
                    hospitalManagementResponse.isSucess = true;
                    hospitalManagementResponse.isMessage = sdr.GetValue(0).ToString();
                }
                mydb.Close();
            }
            catch (Exception ex)
            {
                hospitalManagementResponse.isMessage = ex.Message.ToString();
            }
            return hospitalManagementResponse;
        }
        //public async Task<IEnumerable<string>> Get(HospitalManagementRequest hospitalManagementRequest, HospitalManagementResponse hospitalManagementResponse)
        //{
        //    try
        //    {
        //        hospitalManagementRequest.Address = "http://api.worldbank.org/countries?format=json";
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return Get();
        //}
    }
}
