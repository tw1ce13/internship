using System;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Models;
using ProjectJunior.Services.Response;

namespace ProjectJunior.Data.Implementations
{
	public class DrugService : IDrugService
	{
        private readonly IGeneralRepository<Drug> _drugRepository;



        public DrugService(IGeneralRepository<Drug> drugRepository)
        {
            _drugRepository = drugRepository;
        }



        public IBaseResponse<Drug> Add(Drug drug)
        {
            var baseResponse = new BaseResponse<Drug>();
            _drugRepository.Add(drug);
            baseResponse.Description = "Успешно добавлено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = drug;
            return baseResponse;
        }



        public IBaseResponse<Drug> Delete(int id)
        {
            var baseResponse = new BaseResponse<Drug>();
            Drug drug = new Drug() { Id = id };
            _drugRepository.Delete(drug);
            baseResponse.Description = "Успешно удалено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = drug;
            return baseResponse;
        }

        public IBaseResponse<Drug> Delete(Drug drug)
        {
            var baseResponse = new BaseResponse<Drug>();
            _drugRepository.Delete(drug);
            baseResponse.Description = "Успешно удалено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = drug;
            return baseResponse;
        }

        public async Task<IBaseResponse<Drug>> Get(int id)
        {
            var baseResponse = new BaseResponse<Drug>();
            try
            {
                var drug = await _drugRepository.Get(id);
                if (drug == null)
                {
                    baseResponse.Description = "Не найдено";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = drug;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Drug>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.Error
                };
            }
        }


        public async Task<IBaseResponse<IEnumerable<Drug>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<Drug>>();
            try
            {
                var drug = await _drugRepository.GetAll();
                if (drug == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = drug;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Drug>>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }
    }
}

