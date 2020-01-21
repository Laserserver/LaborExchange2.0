using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
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

        // GET api/companytype
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Get(int id)
        {
            var resp = Request.CreateResponse(HttpStatusCode.OK, GetRes(id), Configuration.Formatters.JsonFormatter);
            resp.Headers.Add("X-Custom-Header", "hello");
            return resp;
        }

        private PagedResult<CompanyTypeModel> GetRes(int id = -1)
        {
            using (var c = new LaborExchange2Entities1())
            {
                var rr = new PagedResult<CompanyTypeModel>();
                var tt = c.CompanyType;
                int cc = tt.Count();

                List<CompanyTypeModel> res;
                res = id == -1 ? 
                    tt.Select(companyType => new CompanyTypeModel
                    {
                        ID = companyType.ID,
                        Company = companyType.Type
                    }).ToList() :
                    (from companyType in tt where companyType.ID == id select new CompanyTypeModel
                    {
                        ID = companyType.ID, 
                        Company = companyType.Type
                    }).ToList();
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
                catch (DbException dbex)
                {
                    return 
                        dbex.ToString();

                    
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
        public HttpResponseMessage Put(int id, [FromBody] MyModel mdl)
        {
            if(id == -1 || mdl?.NewName == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            try
            {
                using (var context = new LaborExchange2Entities1())
                {
                    var o = (from c in context.CompanyType where c.ID == id select c).FirstOrDefault();
                    if (o == null)
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    }
                    o.Type = mdl.NewName;
                    context.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (DbUpdateException dbex)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict,
                    dbex.ToString()

                );
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    ex.ToString()
                );
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE api/companytype/5
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {

            try
            {
                using (var context = new LaborExchange2Entities1())
                {
                    var o = (from c in context.CompanyType where c.ID == id select c).FirstOrDefault();
                    if (o == null)
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    }
                    context.CompanyType.Remove(o);
                    context.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (DbUpdateException dbex)
            {
                return Request.CreateResponse(HttpStatusCode.Conflict,
                    dbex.ToString()

                );
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    ex.ToString()
                );
            }
        }
    }
}
