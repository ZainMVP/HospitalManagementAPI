using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using static HospitalManagementAPI.Entity.HospitalManagementEntity;
using HospitalManagementAPI.BusinessAccessLayer;
using System.Net.Http;
using System.Net;

namespace HospitalManagementAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalManagementController : ControllerBase
    {
        private IConfiguration Configuration;
        public HospitalManagementController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        [Route("GetHospitalManagement")]
        public List<HospitalManagementRequest> GetHospitalManagement()
        {
            List<HospitalManagementRequest> hospitalManagementRequest = new List<HospitalManagementRequest>();
            try
            {
                HospitalManagementBAL hospitalManagementBAL = new HospitalManagementBAL(Configuration);
                hospitalManagementRequest = hospitalManagementBAL.GetHospitalManagement("SelectAll");
                return hospitalManagementRequest;
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        [Route("GetUserIDHospitalManagement/{ID}")]
        public List<HospitalManagementRequest> GetUserIDHospitalManagement(int ID)
        {
            List<HospitalManagementRequest> hospitalManagementRequests = new List<HospitalManagementRequest>();
            try
            {
                HospitalManagementBAL hospitalManagementBAL = new HospitalManagementBAL(Configuration);
                hospitalManagementRequests = hospitalManagementBAL.GetUserIDHospitalManagement("SelectByUserID", ID);
                return hospitalManagementRequests;
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("PostHospitalManagement")]
        public HospitalManagementResponse HospitalManagement(HospitalManagementRequest hospitalManagementRequest)
        {
            HospitalManagementResponse hospitalManagementResponse = new HospitalManagementResponse();
            try
            {
                HospitalManagementBAL hospitalManagementBAL = new HospitalManagementBAL(Configuration);
                hospitalManagementBAL.HospitalManagement(hospitalManagementRequest, hospitalManagementResponse, "Insert");
                return hospitalManagementResponse;
            }
            catch (Exception ex)
            {
                hospitalManagementResponse.isMessage = ex.Message.ToString();
            }
            return hospitalManagementResponse;
        }
        [HttpPut]
        [Route("PutHospitalManagement/{ID}")]
        public HospitalManagementResponse HospitalManagement(HospitalManagementRequest hospitalManagementRequest, int ID)
        {
            HospitalManagementResponse hospitalManagementResponse = new HospitalManagementResponse();
            try
            {
                HospitalManagementBAL hospitalManagementBAL = new HospitalManagementBAL(Configuration);
                hospitalManagementRequest.ID = ID;
                hospitalManagementBAL.HospitalManagement(hospitalManagementRequest, hospitalManagementResponse, "Update");
                return hospitalManagementResponse;
            }
            catch (Exception ex)
            {
                hospitalManagementResponse.isMessage = ex.Message.ToString();
            }
            return hospitalManagementResponse;
        }
        [HttpDelete]
        [Route("DeleteHospitalManagement/{ID}")]
        public HospitalManagementResponse DeleteHospitalManagement(int ID) 
        {
            HospitalManagementResponse hospitalManagementResponse = new HospitalManagementResponse();
            try
            {
                HospitalManagementBAL hospitalManagementBAL = new HospitalManagementBAL(Configuration);
                hospitalManagementBAL.DeleteHospitalManagement(hospitalManagementResponse, ID, "Delete");
            }
            catch (Exception ex)
            {
                hospitalManagementResponse.isMessage = ex.Message.ToString();
            }
            return hospitalManagementResponse;
        }




        //---------------------------------------External-Link-Example-------------------------------------------------//

        [HttpGet]
        [Route("GetExternalResponse")]
        public async Task<IEnumerable<string>> GetExternalResponse()
        {
            try
            {
                string xyz = "http://api.worldbank.org/countries?format=json";
                var client = new HttpClient();
                /*WebRequest webrequest = WebRequest.Create(xyz);
                webrequest.Credentials = new NetworkCredential("Username", "abc");*/

                HttpResponseMessage response = await client.GetAsync(xyz);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                return new string[] { result };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
