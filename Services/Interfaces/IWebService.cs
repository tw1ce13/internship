using System;
using ProjectJunior.Models;
using ProjectJunior.Services.Response;
namespace ProjectJunior.Services.Interfaces
{
	public interface IWebService
	{
		Task<IBaseResponse<IEnumerable<Web>>> GetAll();
		Task<IBaseResponse<Web>> Get(int id);
        IBaseResponse<Web> Delete(int id);
        IBaseResponse<Web> Delete(Web web);
		IBaseResponse<Web> Add(Web web);
        Task<IBaseResponse<Web>> Update(Web obj);

    }
}

