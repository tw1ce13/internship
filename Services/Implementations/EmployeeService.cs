using System;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Data.IRepositories;
using ProjectJunior.Models;
using ProjectJunior.Services.Response;

namespace ProjectJunior.Data.Implementations
{
	public class EmployeeService : IEmployeeService
	{
        private readonly IEmployeeRepository _employeeRepository;



        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        public IBaseResponse<Employee> Add(Employee employee)
        {
            _employeeRepository.Add(employee);
            var baseResponse = new BaseResponse<Employee>("Success", StatusCode.OK, employee);
            return baseResponse;
        }



        public IBaseResponse<Employee> Delete(int id)
        {
            Employee employee = new Employee() { Id = id };
            _employeeRepository.Delete(employee);
            var baseResponse = new BaseResponse<Employee>("Success", StatusCode.OK, employee);
            return baseResponse;
        }

        public IBaseResponse<Employee> Delete(Employee employee)
        {
            _employeeRepository.Delete(employee);
            var baseResponse = new BaseResponse<Employee>("Success", StatusCode.OK, employee);
            return baseResponse;
        }

        public async Task<IBaseResponse<Employee>> Get(int id)
        {
            var baseResponse = new BaseResponse<Employee>();
            try
            {
                var employee = await _employeeRepository.Get(id);
                if (employee == null)
                {
                    baseResponse.Description = "Не найдено";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = employee;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Employee>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.Error
                };
            }
        }


        public async Task<IBaseResponse<IEnumerable<Employee>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<Employee>>();
            try
            {
                var employee = await _employeeRepository.GetAll();
                if (employee == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = employee;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Employee>>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Employee>> Update(Employee obj)
        {
            var baseResponse = new BaseResponse<Employee>();
            try
            {
                if (obj == null)
                {
                    baseResponse.Description = "Объект не найден";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }


                await _employeeRepository.Update(obj);

                baseResponse.Data = obj;
                baseResponse.Description = "успешно";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Employee>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }
    }
}

