using System;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Models;
using ProjectJunior.Services.Response;

namespace ProjectJunior.Data.Implementations
{
	public class OrdService : IOrdService
	{
        private readonly IGeneralRepository<Ord> _ordRepository;



        public OrdService(IGeneralRepository<Ord> ordRepository)
        {
            _ordRepository = ordRepository;
        }



        public IBaseResponse<Ord> Add(Ord ord)
        {
            var baseResponse = new BaseResponse<Ord>();
            _ordRepository.Add(ord);
            baseResponse.Description = "Успешно добавлено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = ord;
            return baseResponse;
        }



        public IBaseResponse<Ord> Delete(int id)
        {
            var baseResponse = new BaseResponse<Ord>();
            Ord ord = new Ord() { Id = id };
            _ordRepository.Delete(ord);
            baseResponse.Description = "Успешно удалено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = ord;
            return baseResponse;
        }

        public IBaseResponse<Ord> Delete(Ord ord)
        {
            var baseResponse = new BaseResponse<Ord>();
            _ordRepository.Delete(ord);
            baseResponse.Description = "Успешно удалено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = ord;
            return baseResponse;
        }

        public async Task<IBaseResponse<Ord>> Get(int id)
        {
            var baseResponse = new BaseResponse<Ord>();
            try
            {
                var ord = await _ordRepository.Get(id);
                if (ord == null)
                {
                    baseResponse.Description = "Не найдено";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = ord;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Ord>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.Error
                };
            }
        }


        public async Task<IBaseResponse<IEnumerable<Ord>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<Ord>>();
            try
            {
                var ord = await _ordRepository.GetAll();
                if (ord == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = ord;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Ord>>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }
    }
}

