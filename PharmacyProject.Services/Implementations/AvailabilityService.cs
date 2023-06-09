﻿using System;
using PharmacyProject.DAL.Interfaces;
using PharmacyProject.DAL.Repositories;
using PharmacyProject.Domain.Enum;
using PharmacyProject.Domain.Models;
using PharmacyProject.Domain.Response;
using PharmacyProject.Services.Interfaces;

namespace PharmacyProject.Services.Implementations
{
    public class AvailabilityService : IAvailabilityService
    {
        private readonly IAvailabilityRepository _availabilityRepository;



        public AvailabilityService(IAvailabilityRepository availabilityRepository)
        {
            _availabilityRepository = availabilityRepository;
        }



        public IBaseResponse<Availability> Add(Availability availability)
        {
            _availabilityRepository.Add(availability);
            var baseResponse = new BaseResponse<Availability>("Success", StatusCode.OK, availability);
            return baseResponse;
        }

        public IBaseResponse<Availability> Delete(int id)
        {

            Availability availability = new Availability() { Id = id };
            _availabilityRepository.Delete(availability);
            var baseResponse = new BaseResponse<Availability>("Success", StatusCode.OK, availability);
            return baseResponse;
        }

        public IBaseResponse<Availability> Delete(Availability availability)
        {
            _availabilityRepository.Delete(availability);
            var baseResponse = new BaseResponse<Availability>("Success", StatusCode.OK, availability);

            return baseResponse;
        }

        public async Task<IBaseResponse<Availability>> Get(int id)
        {
            var baseResponse = new BaseResponse<Availability>();
            try
            {
                var availability = await _availabilityRepository.GetById(id);

                if (availability == null)
                {
                    baseResponse.Description = "Не найдено";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }

                baseResponse.Data = availability;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Availability>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.Error
                };
            }
        }


        public async Task<IBaseResponse<IEnumerable<Availability>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<Availability>>();
            try
            {
                var availabilities = await _availabilityRepository.GetAll();
                if (availabilities == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = availabilities;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Availability>>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Availability>>> GetAvailabilitiesByPharmacyId(int pharmacyId)
        {
            var baseResponse = new BaseResponse<IEnumerable<Availability>>();
            try
            {
                var list = await _availabilityRepository.GetAvailabilitiesByPharmacyId(pharmacyId);
                if (list == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.ObjectNotFound;
                    return baseResponse;
                }
                baseResponse.Data = list;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch(Exception ex)
            {
                return new BaseResponse<IEnumerable<Availability>>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Availability>>> GetAvailabilityByDelivery(IEnumerable<Delivery> deliveries)
        {
            var baseResponse = new BaseResponse<IEnumerable<Availability>>();
            try
            {
                var list = await _availabilityRepository.GetAvailabilityByDelivery(deliveries);
                if (list == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.ObjectNotFound;
                }
                baseResponse.Data = list;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch(Exception ex)
            {
                return new BaseResponse<IEnumerable<Availability>>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }

        public IBaseResponse<Availability> Update(Availability obj)
        {
            var baseResponse = new BaseResponse<Availability>();
            try
            {
                if (obj == null)
                {
                    baseResponse.Description = "Объект не найден";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }

                _availabilityRepository.Update(obj);

                baseResponse.Data = obj;
                baseResponse.Description = "успешно";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Availability>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }
    }
}


