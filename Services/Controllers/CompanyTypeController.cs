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



        // POST api/companytype
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        public string Post([FromBody] MyModel mdl)
        {
            using (var context = new LaborExchange2Entities1())
            {
                if (mdl == null || mdl.NewName == "")
                    return null;

                if (Enumerable.Any(context.CompanyType, companyType => companyType.Type == mdl.NewName))
                {
                    return "Already exists";
                }

                CompanyType ct = new CompanyType
                {
                    Type = mdl.NewName
                };
                context.CompanyType.Add(ct);
                try
                {
                    context.SaveChanges();
                    return "OK";
                }
                catch (Exception exception)
                {
                    return exception.Message;
                }
            }
        }

        // PUT api/companytype/5
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPut]
        public void Put(int id, [FromBody] MyModel mdl)
        {

        }

        // DELETE api/companytype/5
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpDelete]
        public void Delete(int id)
        {

        }
    }
}
