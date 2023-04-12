using System;
using ProjectJunior.Models;
using ProjectJunior.Services.Response;

namespace ProjectJunior.Data.Interfaces
{
	public interface IEmployeeService
	{
        Task<IBaseResponse<IEnumerable<Employee>>> GetAll();
        Task<IBaseResponse<Employee>> Get(int id);
        IBaseResponse<Employee> Delete(int id);
        IBaseResponse<Employee> Delete(Employee obj);
        IBaseResponse<Employee> Add(Employee obj);
        Task<IBaseResponse<Employee>> Update(int id, Employee obj);

    }
}

