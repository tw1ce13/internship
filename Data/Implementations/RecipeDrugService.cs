using System;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Models;
using ProjectJunior.Services.Response;

namespace ProjectJunior.Data.Implementations
{
	public class RecipeDrugService : IRecipeDrugService
	{
        private readonly IGeneralRepository<RecipeDrug> _recipeDrugRepository;



        public RecipeDrugService(IGeneralRepository<RecipeDrug> recipeDrugRepository)
        {
            _recipeDrugRepository = recipeDrugRepository;
        }



        public IBaseResponse<RecipeDrug> Add(RecipeDrug recipeDrug)
        {
            var baseResponse = new BaseResponse<RecipeDrug>();
            _recipeDrugRepository.Add(recipeDrug);
            baseResponse.Description = "Успешно добавлено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = recipeDrug;
            return baseResponse;
        }



        public IBaseResponse<RecipeDrug> Delete(int id)
        {
            var baseResponse = new BaseResponse<RecipeDrug>();
            RecipeDrug recipeDrug = new RecipeDrug() { Id = id };
            _recipeDrugRepository.Delete(recipeDrug);
            baseResponse.Description = "Успешно удалено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = recipeDrug;
            return baseResponse;
        }

        public IBaseResponse<RecipeDrug> Delete(RecipeDrug recipeDrug)
        {
            var baseResponse = new BaseResponse<RecipeDrug>();
            _recipeDrugRepository.Delete(recipeDrug);
            baseResponse.Description = "Успешно удалено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = recipeDrug;
            return baseResponse;
        }

        public async Task<IBaseResponse<RecipeDrug>> Get(int id)
        {
            var baseResponse = new BaseResponse<RecipeDrug>();
            try
            {
                var recipeDrug = await _recipeDrugRepository.Get(id);
                if (recipeDrug == null)
                {
                    baseResponse.Description = "Не найдено";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = recipeDrug;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<RecipeDrug>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.Error
                };
            }
        }


        public async Task<IBaseResponse<IEnumerable<RecipeDrug>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<RecipeDrug>>();
            try
            {
                var recipeDrug = await _recipeDrugRepository.GetAll();
                if (recipeDrug == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = recipeDrug;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<RecipeDrug>>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }
    }
}

