using System;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Models;
using ProjectJunior.Services.Response;

namespace ProjectJunior.Data.Implementations
{
	public class DiscountService : IDiscountService
	{
        private readonly IGeneralRepository<Discount> _discountRepository;



        public DiscountService(IGeneralRepository<Discount> discountRepository)
        {
            _discountRepository = discountRepository;
        }



        public IBaseResponse<Discount> Add(Discount discount)
        {
            var baseResponse = new BaseResponse<Discount>();
            _discountRepository.Add(discount);
            baseResponse.Description = "Успешно добавлено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = discount;
            return baseResponse;
        }



        public IBaseResponse<Discount> Delete(int id)
        {
            var baseResponse = new BaseResponse<Discount>();
            Discount discount = new Discount() { Id = id };
            _discountRepository.Delete(discount);
            baseResponse.Description = "Успешно удалено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = discount;
            return baseResponse;
        }

        public IBaseResponse<Discount> Delete(Discount discount)
        {
            var baseResponse = new BaseResponse<Discount>();
            _discountRepository.Delete(discount);
            baseResponse.Description = "Успешно удалено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = discount;
            return baseResponse;
        }

        public async Task<IBaseResponse<Discount>> Get(int id)
        {
            var baseResponse = new BaseResponse<Discount>();
            try
            {
                var discount = await _discountRepository.Get(id);
                if (discount == null)
                {
                    baseResponse.Description = "Не найдено";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = discount;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Discount>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.Error
                };
            }
        }


        public async Task<IBaseResponse<IEnumerable<Discount>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<Discount>>();
            try
            {
                var discount = await _discountRepository.GetAll();
                if (discount == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = discount;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Discount>>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }
    }
}

