using GAPTechTest.Models;
using GAPTechTest.Services;
using GoIn.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace GAPTechTest.Tests.Controllers.API
{
    //[Authorize]
    [RoutePrefix("api/policy")]
    public class PolicyControllerAPI : ApiController
    {
        public PolicyService PolicyService { get; set; }

        public PolicyControllerAPI()
        {
            UnitOfWork unitOfWork = new UnitOfWork(); 
            PolicyService = new PolicyService(unitOfWork);
        }

        [HttpGet]
        [Route("getAll")]
        public IEnumerable<Policy> GetAll()
        {
            try
            {
                return PolicyService.GetAll();
            }
            catch(Exception ex)
            {
                return null; 
            }
        }

        [HttpGet]
        [Route("getById")]
        public Policy GetById(int policyId)
        {
            try
            {
                return PolicyService.GetById(policyId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        public IHttpActionResult CreatePolicy(Policy policy)
        {
            try
            {
                var policyId = PolicyService.Create(policy);
                return Ok(policyId);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult UpdatePolicy(Policy policy)
        {
            try
            {
                var policyId = PolicyService.Update(policy);
                return Ok(policyId);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeletePolicy(int policyId)
        {
            try
            {
                PolicyService.Delete(policyId);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}