using BLINterfaces;
using DBLibrary;
using ModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealServices
{
    public class RealService : BLINterfaces.ICTService
    {
        public PagedResult<CompanyTypeModel> GetCTs(int id = -1)
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
                    (from companyType in tt
                     where companyType.ID == id
                     select new CompanyTypeModel
                     {
                         ID = companyType.ID,
                         Company = companyType.Type
                     }).ToList();
                rr.Page = res.ToArray();
                rr.PageCount = 1;
                return rr;
            }
        }

        public PagedResult<CompanyTypeModel> GetPagedCTs(int page, int pagecount)
        {
            using (var c = new LaborExchange2Entities1())
            {
                var rr = new PagedResult<CompanyTypeModel>();
                var tt = (from o in c.CompanyType select o).OrderBy(o => o.ID);
                int cc = tt.Count();
                var ttx = tt.Skip((page - 1) * pagecount).Take(pagecount).ToArray();

                List<CompanyTypeModel> res = new List<CompanyTypeModel>();
                foreach (var item in ttx)
                {
                    res.Add(new CompanyTypeModel { ID = item.ID, Company = item.Type });
                }
                rr.Page = res.ToArray();
                var tc = tt.Count();
                if(tc % pagecount == 0)
                    rr.PageCount = tc / pagecount;
                else
                    rr.PageCount = tc / pagecount + 1;
                return rr;
            }
        }
    }
}
