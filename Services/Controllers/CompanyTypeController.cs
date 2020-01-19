using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BLINterfaces;
using DBLibrary;
using ModelsLibrary;

namespace Services.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CompanyTypeController : ApiController
    {
        private ICTService _service;

        public CompanyTypeController()
        {

        }
        public CompanyTypeController(ICTService service)
        {
            _service = service;

        }

        // GET api/companytype
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Get()
        {

            var resp = Request.CreateResponse(HttpStatusCode.OK, GetRes(), Configuration.Formatters.JsonFormatter);
            resp.Headers.Add("X-Custom-Header", "hello");
            return resp;
        }

        private PagedResult<CompanyTypeModel> GetRes()
        {
            using (var c = new LaborExchange2Entities1())
            {
                var rr = new PagedResult<CompanyTypeModel>();
                var tt = c.CompanyType;
                int cc = tt.Count();
                var res = tt.Select(companyType => new CompanyTypeModel {ID = companyType.ID, Company = companyType.Type}).ToList();
                rr.Page = res.ToArray();
                rr.PageCount = 1;
                return rr;
            }
        }



        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
