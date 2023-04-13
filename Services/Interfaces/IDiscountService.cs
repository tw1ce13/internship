using System;
using ProjectJunior.Models;
using ProjectJunior.Services.Response;

namespace ProjectJunior.Data.Interfaces
{
	public interface IDiscountService
	{
        Task<IBaseResponse<IEnumerable<Discount>>> GetAll();
        Task<IBaseResponse<Discount>> Get(int id);
        IBaseResponse<Discount> Delete(int id);
        IBaseResponse<Discount> Delete(Discount obj);
        IBaseResponse<Discount> Add(Discount obj);
        Task<IBaseResponse<Discount>> Update(Discount obj);

    }
}

