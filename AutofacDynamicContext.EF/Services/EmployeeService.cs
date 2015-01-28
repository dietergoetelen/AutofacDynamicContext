using AutofacDynamicContext.Domain;
using AutofacDynamicContext.Domain.Contracts;
using AutofacDynamicContext.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace AutofacDynamicContext.EF.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IBaseRepository<Employee> _employeeRepository;

        public EmployeeService(IBaseRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Domain.Employee>> GetEmployeesAsync()
        {
            return await _employeeRepository.Get().ToListAsync();
        }
    }
}
