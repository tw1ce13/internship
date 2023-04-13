using System;
using ProjectJunior.Models;
using ProjectJunior.Services.Response;

namespace ProjectJunior.Data.Interfaces
{
	public interface IClassService
	{
        Task<IBaseResponse<IEnumerable<Class>>> GetAll();
        Task<IBaseResponse<Class>> Get(int id);
        IBaseResponse<Class> Delete(int id);
        IBaseResponse<Class> Delete(Class obj);
        IBaseResponse<Class> Add(Class obj);
        Task<IBaseResponse<Class>> Update(Class obj);

    }
}

