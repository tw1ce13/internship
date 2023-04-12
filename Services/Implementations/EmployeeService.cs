using System;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Models;
using ProjectJunior.Services.Response;

namespace ProjectJunior.Data.Implementations
{
	public class EmployeeService : IEmployeeService
	{
        private readonly IGeneralRepository<Employee> _employeeRepository;



        public EmployeeService(IGeneralRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        public IBaseResponse<Employee> Add(Employee employee)
        {
            var baseResponse = new BaseResponse<Employee>();
            _employeeRepository.Add(employee);
            baseResponse.Description = "Успешно добавлено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = employee;
            return baseResponse;
        }



        public IBaseResponse<Employee> Delete(int id)
        {
            var baseResponse = new BaseResponse<Employee>();
            Employee employee = new Employee() { Id = id };
            _employeeRepository.Delete(employee);
            baseResponse.Description = "Успешно удалено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = employee;
            return baseResponse;
        }

        public IBaseResponse<Employee> Delete(Employee employee)
        {
            var baseResponse = new BaseResponse<Employee>();
            _employeeRepository.Delete(employee);
            baseResponse.Description = "Успешно удалено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = employee;
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

        public async Task<IBaseResponse<Employee>> Update(int id, Employee obj)
        {
            var baseResponse = new BaseResponse<Employee>();
            try
            {
                var employee = await _employeeRepository.Get(id);
                if (employee == null)
                {
                    baseResponse.Description = "Объект не найден";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                employee.Name = obj.Name;
                employee.Surname = obj.Surname;
                employee.Post = obj.Post;
                employee.PharmacyId = obj.PharmacyId;
                employee.Pharmacy = obj.Pharmacy;


                await _employeeRepository.Update(employee);

                baseResponse.Data = employee;
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

