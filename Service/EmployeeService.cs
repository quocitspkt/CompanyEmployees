using AutoMapper;
using Contracts;
using Entities;
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
        public IEnumerable<EmployeeDto> GetAllEmployees(bool trackChanges)
        {
            try
            {
                var employees = _repository.Employee.GetAllEmployees(trackChanges);
                var employeeDto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
                return employeeDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the { nameof(GetAllEmployees)} service method { ex} ");
                throw;
            }
        }
    }
}

