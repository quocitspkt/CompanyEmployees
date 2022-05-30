using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public EmployeeService(IRepositoryManager repository, ILoggerManager
        logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public EmployeeDto GetEmployee(Guid compayId, Guid employeeId, bool trackChanges)
        {
            var company = _repository.Company.GetCompany(compayId, trackChanges);
            if(company is null)
            {
                throw new CompanyNotFoundException(compayId);
            }
            var employeeDb = _repository.Employee.GetEmployee(compayId, employeeId, trackChanges);
            if(employeeDb is null)
            {
                throw new EmployeeNotFoundException(employeeId);
            }    
            var employee = _mapper.Map<EmployeeDto>(employeeDb);
            return employee;
        }

        public IEnumerable<EmployeeDto> GetEmployees(Guid companyId,bool trackChanges)
        {
            var company = _repository.Company.GetCompany(companyId, trackChanges);
            if(company is null)
            { throw new CompanyNotFoundException(companyId); }

            var employeeFromDb = _repository.Employee.GetEmployees(companyId, trackChanges); 
            var employeeDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeeFromDb);
            return employeeDto;
        }
    }
}

