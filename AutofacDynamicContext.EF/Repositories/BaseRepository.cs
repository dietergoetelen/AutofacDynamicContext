using Autofac.Features.Indexed;
using AutofacDynamicContext.Domain;
using AutofacDynamicContext.Domain.Contracts;
using AutofacDynamicContext.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacDynamicContext.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T: class,new()
    {
        private readonly IIndex<CurrentEnvironment, SampleContext> _environments;
        private readonly EnvironmentContext _currentEnvironment;

        public BaseRepository(IIndex<CurrentEnvironment, SampleContext> environments, EnvironmentContext currentEnvironment)
        {
            _environments = environments;
            _currentEnvironment = currentEnvironment;
        }

        public IQueryable<T> Get()
        {
            return _environments[_currentEnvironment.Environment].Set<T>();
        }
    }
}
