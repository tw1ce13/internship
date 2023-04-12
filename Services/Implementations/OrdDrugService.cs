using System;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Models;
using ProjectJunior.Services.Response;

namespace ProjectJunior.Data.Implementations
{
	public class OrdDrugService : IOrdDrugService
	{
        private readonly IGeneralRepository<OrdDrug> _ordDrugRepository;



        public OrdDrugService(IGeneralRepository<OrdDrug> ordDrugRepository)
        {
            _ordDrugRepository = ordDrugRepository;
        }



        public IBaseResponse<OrdDrug> Add(OrdDrug ordDrug)
        {
            var baseResponse = new BaseResponse<OrdDrug>();
            _ordDrugRepository.Add(ordDrug);
            baseResponse.Description = "Успешно добавлено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = ordDrug;
            return baseResponse;
        }



        public IBaseResponse<OrdDrug> Delete(int id)
        {
            var baseResponse = new BaseResponse<OrdDrug>();
            OrdDrug ordDrug = new OrdDrug() { Id = id };
            _ordDrugRepository.Delete(ordDrug);
            baseResponse.Description = "Успешно удалено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = ordDrug;
            return baseResponse;
        }

        public IBaseResponse<OrdDrug> Delete(OrdDrug ordDrug)
        {
            var baseResponse = new BaseResponse<OrdDrug>();
            _ordDrugRepository.Delete(ordDrug);
            baseResponse.Description = "Успешно удалено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = ordDrug;
            return baseResponse;
        }

        public async Task<IBaseResponse<OrdDrug>> Get(int id)
        {
            var baseResponse = new BaseResponse<OrdDrug>();
            try
            {
                var ordDrug = await _ordDrugRepository.Get(id);
                if (ordDrug == null)
                {
                    baseResponse.Description = "Не найдено";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = ordDrug;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<OrdDrug>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.Error
                };
            }
        }


        public async Task<IBaseResponse<IEnumerable<OrdDrug>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<OrdDrug>>();
            try
            {
                var ordDrug = await _ordDrugRepository.GetAll();
                if (ordDrug == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = ordDrug;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<OrdDrug>>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<OrdDrug>> Update(int id, OrdDrug obj)
        {
            var baseResponse = new BaseResponse<OrdDrug>();
            try
            {
                var ordDrug = await _ordDrugRepository.Get(id);
                if (ordDrug == null)
                {
                    baseResponse.Description = "Объект не найден";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                ordDrug.Count = obj.Count;
                ordDrug.Ord = obj.Ord;
                ordDrug.OrdId = obj.OrdId;
                ordDrug.Price = obj.Price;
                ordDrug.Discount = obj.Discount;
                ordDrug.DiscountId = obj.DiscountId;
                ordDrug.Drug = obj.Drug;
                ordDrug.DrugId = obj.DrugId;


                await _ordDrugRepository.Update(ordDrug);

                baseResponse.Data = ordDrug;
                baseResponse.Description = "успешно";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<OrdDrug>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }
    }
}

