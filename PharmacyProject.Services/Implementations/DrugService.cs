﻿using System;
using System.Collections.Generic;
using PharmacyProject.DAL.Interfaces;
using PharmacyProject.DAL.Repositories;
using PharmacyProject.Domain.Enum;
using PharmacyProject.Domain.Models;
using PharmacyProject.Domain.Response;
using PharmacyProject.Services.Interfaces;

namespace PharmacyProject.Services.Implementations
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
                var drug = await _drugRepository.GetById(id);
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


        public async Task<IBaseResponse<IEnumerable<Drug>>> GetAll(CancellationToken cancellationToken)
        {
            var baseResponse = new BaseResponse<IEnumerable<Drug>>();
            try
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    return new BaseResponse<IEnumerable<Drug>>()
                    {
                        StatusCode = StatusCode.Cancelled,
                        Description = "Операция была отменена."
                    };
                }

                var drug = await _drugRepository.GetAll();

                if (cancellationToken.IsCancellationRequested)
                {
                    return new BaseResponse<IEnumerable<Drug>>()
                    {
                        StatusCode = StatusCode.Cancelled,
                        Description = "Операция была отменена после выполнения."
                    };
                }

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

        public async Task<BaseResponse<IEnumerable<DrugInOrder>>> GetDrugInOrders(IEnumerable<Order> orders, IEnumerable<OrdDrug> ordDrugs, int userId)
        {
            var baseResponse = new BaseResponse<IEnumerable<DrugInOrder>>();
            try
            {
                var list = await _drugRepository.GetDrugInOrders(orders, ordDrugs, userId);

                if (list == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = list;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<DrugInOrder>>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }


        public async Task<BaseResponse<IEnumerable<DrugResult>>> GetDrugs(IEnumerable<Availability> availabilities, IEnumerable<Class> classes, IEnumerable<Delivery> deliveries)
        {
            var baseResponse = new BaseResponse<IEnumerable<DrugResult>>();
            try
            {
                var list = await _drugRepository.GetDrugs(availabilities, classes, deliveries);
                if (list == null)
                {
                    baseResponse.Description = "Не найдено объектов";
                    baseResponse.StatusCode = StatusCode.ObjectNotFound;
                }
                baseResponse.Data = list;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<DrugResult>>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }

        public IBaseResponse<Drug> Update(Drug obj)
        {
            var baseResponse = new BaseResponse<Drug>();
            if (obj == null)
            {
                baseResponse.Description = "Объект не найден";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }


            _drugRepository.Update(obj);

            baseResponse.Data = obj;
            baseResponse.Description = "успешно";
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
    }
}


