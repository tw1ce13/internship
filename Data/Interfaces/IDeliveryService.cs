using System;
using ProjectJunior.Models;
using ProjectJunior.Services.Response;

namespace ProjectJunior.Data.Interfaces
{
	public interface IDeliveryService
	{
        Task<IBaseResponse<IEnumerable<Delivery>>> GetAll();
        Task<IBaseResponse<Delivery>> Get(int id);
        IBaseResponse<Delivery> Delete(int id);
        IBaseResponse<Delivery> Delete(Delivery delivery);
        IBaseResponse<Delivery> Add(Delivery delivery);
    }
}

