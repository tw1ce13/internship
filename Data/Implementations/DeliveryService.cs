using System;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Models;
using ProjectJunior.Services.Response;

namespace ProjectJunior.Data.Implementations
{
	public class DeliveryService : IDeliveryService
	{
        private readonly IGeneralRepository<Delivery> _deliveryRepository;



        public DeliveryService(IGeneralRepository<Delivery> deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }



        public IBaseResponse<Delivery> Add(Delivery delivery)
        {
            var baseResponse = new BaseResponse<Delivery>();
            _deliveryRepository.Add(delivery);
            baseResponse.Description = "Успешно добавлено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = delivery;
            return baseResponse;
        }



        public IBaseResponse<Delivery> Delete(int id)
        {
            var baseResponse = new BaseResponse<Delivery>();
            Delivery delivery = new Delivery() { Id = id };
            _deliveryRepository.Delete(delivery);
            baseResponse.Description = "Успешно удалено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = delivery;
            return baseResponse;
        }

        public IBaseResponse<Delivery> Delete(Delivery delivery)
        {
            var baseResponse = new BaseResponse<Delivery>();
            _deliveryRepository.Delete(delivery);
            baseResponse.Description = "Успешно удалено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = delivery;
            return baseResponse;
        }

        public async Task<IBaseResponse<Delivery>> Get(int id)
        {
            var baseResponse = new BaseResponse<Delivery>();
            try
            {
                var delivery = await _deliveryRepository.Get(id);
                if (delivery == null)
                {
                    baseResponse.Description = "Не найдено";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = delivery;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Delivery>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.Error
                };
            }
        }


        public async Task<IBaseResponse<IEnumerable<Delivery>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<Delivery>>();
            try
            {
                var delivery = await _deliveryRepository.GetAll();
                if (delivery == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = delivery;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Delivery>>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }
    }
}

