using ModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLINterfaces
{
    public interface ICTService
    {
        PagedResult<CompanyTypeModel> GetCTs(int id = -1);

        PagedResult<CompanyTypeModel> GetPagedCTs(int page, int pagecount);
    }
}
