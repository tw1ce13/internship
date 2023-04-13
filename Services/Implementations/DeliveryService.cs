﻿using System;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Data.IRepositories;
using ProjectJunior.Models;
using ProjectJunior.Services.Response;

namespace ProjectJunior.Data.Implementations
{
	public class DeliveryService : IDeliveryService
	{
        private readonly IDeliveryRepository _deliveryRepository;



        public DeliveryService(IDeliveryRepository deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }



        public IBaseResponse<Delivery> Add(Delivery delivery)
        {
            _deliveryRepository.Add(delivery);
            var baseResponse = new BaseResponse<Delivery>("Success", StatusCode.OK, delivery);
            return baseResponse;
        }



        public IBaseResponse<Delivery> Delete(int id)
        {
            Delivery delivery = new Delivery() { Id = id };
            _deliveryRepository.Delete(delivery);
            var baseResponse = new BaseResponse<Delivery>("Success", StatusCode.OK, delivery);
            return baseResponse;
        }

        public IBaseResponse<Delivery> Delete(Delivery delivery)
        {
            _deliveryRepository.Delete(delivery);
            var baseResponse = new BaseResponse<Delivery>("Success", StatusCode.OK, delivery);
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

        public async Task<IBaseResponse<Delivery>> Update(Delivery obj)
        {
            var baseResponse = new BaseResponse<Delivery>();
            try
            {
                if (obj == null)
                {
                    baseResponse.Description = "Объект не найден";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }


                await _deliveryRepository.Update(obj);

                baseResponse.Data = obj;
                baseResponse.Description = "успешно";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Delivery>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }
    }
}

