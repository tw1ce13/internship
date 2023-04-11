using System;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Models;
using ProjectJunior.Services.Response;

namespace ProjectJunior.Data.Implementations
{
	public class RecipeService : IRecipeService
	{
        private readonly IGeneralRepository<Recipe> _recipeRepository;



        public RecipeService(IGeneralRepository<Recipe> recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }



        public IBaseResponse<Recipe> Add(Recipe recipe)
        {
            var baseResponse = new BaseResponse<Recipe>();
            _recipeRepository.Add(recipe);
            baseResponse.Description = "Успешно добавлено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = recipe;
            return baseResponse;
        }



        public IBaseResponse<Recipe> Delete(int id)
        {
            var baseResponse = new BaseResponse<Recipe>();
            Recipe recipe = new Recipe() { Id = id };
            _recipeRepository.Delete(recipe);
            baseResponse.Description = "Успешно удалено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = recipe;
            return baseResponse;
        }

        public IBaseResponse<Recipe> Delete(Recipe recipe)
        {
            var baseResponse = new BaseResponse<Recipe>();
            _recipeRepository.Delete(recipe);
            baseResponse.Description = "Успешно удалено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = recipe;
            return baseResponse;
        }

        public async Task<IBaseResponse<Recipe>> Get(int id)
        {
            var baseResponse = new BaseResponse<Recipe>();
            try
            {
                var recipe = await _recipeRepository.Get(id);
                if (recipe == null)
                {
                    baseResponse.Description = "Не найдено";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = recipe;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Recipe>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.Error
                };
            }
        }


        public async Task<IBaseResponse<IEnumerable<Recipe>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<Recipe>>();
            try
            {
                var recipe = await _recipeRepository.GetAll();
                if (recipe == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = recipe;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Recipe>>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }
    }
}

