using System;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Data.IRepositories;
using ProjectJunior.Models;
using ProjectJunior.Services.Response;

namespace ProjectJunior.Data.Implementations
{
	public class DrugService : IDrugService
	{
        private readonly IDrugRepository _drugRepository;



        public DrugService(IDrugRepository drugRepository)
        {
            _drugRepository = drugRepository;
        }



        public IBaseResponse<Drug> Add(Drug drug)
        {
            _drugRepository.Add(drug);
            var baseResponse = new BaseResponse<Drug>("Success", StatusCode.OK, drug);
            return baseResponse;
        }



        public IBaseResponse<Drug> Delete(int id)
        {
            Drug drug = new Drug() { Id = id };
            _drugRepository.Delete(drug);
            var baseResponse = new BaseResponse<Drug>("Success", StatusCode.OK, drug);
            return baseResponse;
        }

        public IBaseResponse<Drug> Delete(Drug drug)
        {
            _drugRepository.Delete(drug);
            var baseResponse = new BaseResponse<Drug>("Success", StatusCode.OK, drug);
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
        public async Task<IBaseResponse<Drug>> Update(Drug obj)
        {
            var baseResponse = new BaseResponse<Drug>();
            try
            {
                if (obj == null)
                {
                    baseResponse.Description = "Объект не найден";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }


                await _drugRepository.Update(obj);

                baseResponse.Data = obj;
                baseResponse.Description = "успешно";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Drug>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }
    }
}

