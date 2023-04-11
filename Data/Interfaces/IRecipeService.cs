using System;
using ProjectJunior.Models;
using ProjectJunior.Services.Response;

namespace ProjectJunior.Data.Interfaces
{
	public interface IRecipeService
	{
        Task<IBaseResponse<IEnumerable<Recipe>>> GetAll();
        Task<IBaseResponse<Recipe>> Get(int id);
        IBaseResponse<Recipe> Delete(int id);
        IBaseResponse<Recipe> Delete(Recipe obj);
        IBaseResponse<Recipe> Add(Recipe obj);
    }
}

