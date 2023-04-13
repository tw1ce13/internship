using System;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Data.IRepositories;
using ProjectJunior.Models;
using ProjectJunior.Services.Response;

namespace ProjectJunior.Data.Implementations
{
	public class OrdService : IOrdService
	{
        private readonly IOrdRepository _ordRepository;



        public OrdService(IOrdRepository ordRepository)
        {
            _ordRepository = ordRepository;
        }



        public IBaseResponse<Ord> Add(Ord ord)
        {
            _ordRepository.Add(ord);
            var baseResponse = new BaseResponse<Ord>("Success", StatusCode.OK, ord);
            return baseResponse;
        }



        public IBaseResponse<Ord> Delete(int id)
        {
            Ord ord = new Ord() { Id = id };
            _ordRepository.Delete(ord);
            var baseResponse = new BaseResponse<Ord>("Success", StatusCode.OK, ord);
            return baseResponse;
        }

        public IBaseResponse<Ord> Delete(Ord ord)
        {
            _ordRepository.Delete(ord);
            var baseResponse = new BaseResponse<Ord>("Success", StatusCode.OK, ord);
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


        public async Task<IBaseResponse<Ord>> Update(Ord obj)
        {
            var baseResponse = new BaseResponse<Ord>();
            try
            {
                if (obj == null)
                {
                    baseResponse.Description = "Объект не найден";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }


                await _ordRepository.Update(obj);

                baseResponse.Data = obj;
                baseResponse.Description = "успешно";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Ord>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }
    }
}

