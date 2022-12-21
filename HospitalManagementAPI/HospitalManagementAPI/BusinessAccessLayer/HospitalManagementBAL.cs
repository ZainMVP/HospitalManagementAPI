using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalManagementAPI.DataAccessLayer;
using Microsoft.Extensions.Configuration;
using static HospitalManagementAPI.Entity.HospitalManagementEntity;

namespace HospitalManagementAPI.BusinessAccessLayer
{
    public class HospitalManagementBAL
    {
        private IConfiguration Configuration;

        public HospitalManagementBAL(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public List<HospitalManagementRequest> GetHospitalManagement(string Type)
        {
            List<HospitalManagementRequest> lstRequest = new List<HospitalManagementRequest>();
            try
            {
                HospitalManagementDAL hospitalManagementDAL = new HospitalManagementDAL(Configuration);
                lstRequest = hospitalManagementDAL.GetHospitalManagement(Type);
                return lstRequest;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<HospitalManagementRequest> GetUserIDHospitalManagement(string Type, int ID)
        {
            List<HospitalManagementRequest> hospitalManagementRequests = new List<HospitalManagementRequest>();
            try
            {
                HospitalManagementDAL hospitalManagementDAL = new HospitalManagementDAL(Configuration);
                hospitalManagementRequests = hospitalManagementDAL.GetUserIDHospitalManagement(Type, ID);
                return hospitalManagementRequests;
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
                HospitalManagementDAL hospitalManagementDAL = new HospitalManagementDAL(Configuration);
                hospitalManagementDAL.HospitalManagement(hospitalManagementRequest, hospitalManagementResponse, Type);
                return hospitalManagementResponse;
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
                HospitalManagementDAL hospitalManagementDAL = new HospitalManagementDAL(Configuration);
                hospitalManagementDAL.DeleteHospitalManagement(hospitalManagementResponse, ID, Type);
            }
            catch (Exception ex)
            {
                hospitalManagementResponse.isMessage = ex.Message.ToString();
            }
            return hospitalManagementResponse;
        }
    }
}
