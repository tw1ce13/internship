using System;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Models;
using ProjectJunior.Services.Response;

namespace ProjectJunior.Data.Implementations
{
	public class PharmacyService : IPharmacyService
	{
        private readonly IGeneralRepository<Pharmacy> _pharmacyRepository;



        public PharmacyService(IGeneralRepository<Pharmacy> pharmacyRepository)
        {
            _pharmacyRepository = pharmacyRepository;
        }



        public IBaseResponse<Pharmacy> Add(Pharmacy pharmacy)
        {
            var baseResponse = new BaseResponse<Pharmacy>();
            _pharmacyRepository.Add(pharmacy);
            baseResponse.Description = "Успешно добавлено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = pharmacy;
            return baseResponse;
        }



        public IBaseResponse<Pharmacy> Delete(int id)
        {
            var baseResponse = new BaseResponse<Pharmacy>();
            Pharmacy pharmacy = new Pharmacy() { Id = id };
            _pharmacyRepository.Delete(pharmacy);
            baseResponse.Description = "Успешно удалено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = pharmacy;
            return baseResponse;
        }

        public IBaseResponse<Pharmacy> Delete(Pharmacy pharmacy)
        {
            var baseResponse = new BaseResponse<Pharmacy>();
            _pharmacyRepository.Delete(pharmacy);
            baseResponse.Description = "Успешно удалено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = pharmacy;
            return baseResponse;
        }

        public async Task<IBaseResponse<Pharmacy>> Get(int id)
        {
            var baseResponse = new BaseResponse<Pharmacy>();
            try
            {
                var pharmacy = await _pharmacyRepository.Get(id);
                if (pharmacy == null)
                {
                    baseResponse.Description = "Не найдено";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = pharmacy;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Pharmacy>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.Error
                };
            }
        }


        public async Task<IBaseResponse<IEnumerable<Pharmacy>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<Pharmacy>>();
            try
            {
                var pharmacy = await _pharmacyRepository.GetAll();
                if (pharmacy == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = pharmacy;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Pharmacy>>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }
    }
}

