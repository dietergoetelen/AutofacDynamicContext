using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacDynamicContext.Domain.Contracts
{
    public interface IBaseRepository<T> where T: class, new()
    {
        IQueryable<T> Get();
    }
}
