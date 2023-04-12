using System;
namespace ProjectJunior.Data.Interfaces
{
	public interface IGeneralRepository<T>
	{
		void Add(T data);
		void Delete(T data);
		void Delete(int id);
		Task<IEnumerable<T>> GetAll();
		Task<T> Get(int id);
		Task<T> Update(T data);
	}
}

