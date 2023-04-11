using System;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Models;
using ProjectJunior.Services.Response;

namespace ProjectJunior.Data.Implementations
{
	public class ClassService : IClassService
	{
        private readonly IGeneralRepository<Class> _classRepository;



        public ClassService(IGeneralRepository<Class> classRepository)
        {
            _classRepository = classRepository;
        }



        public IBaseResponse<Class> Add(Class obj)
        {
            var baseResponse = new BaseResponse<Class>();
            _classRepository.Add(obj);
            baseResponse.Description = "Успешно добавлено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = obj;
            return baseResponse;
        }



        public IBaseResponse<Class> Delete(int id)
        {
            var baseResponse = new BaseResponse<Class>();
            Class obj = new Class()
            {
                ClassId = id
            };
            _classRepository.Delete(obj);
            baseResponse.Description = "Успешно удалено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = obj;
            return baseResponse;
        }

        public IBaseResponse<Class> Delete(Class obj)
        {
            var baseResponse = new BaseResponse<Class>();
            _classRepository.Delete(obj);
            baseResponse.Description = "Успешно удалено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = obj;
            return baseResponse;
        }

        public async Task<IBaseResponse<Class>> Get(int id)
        {
            var baseResponse = new BaseResponse<Class>();
            try
            {
                var obj = await _classRepository.Get(id);
                if (obj == null)
                {
                    baseResponse.Description = "Не найдено";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = obj;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Class>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.Error
                };
            }
        }


        public async Task<IBaseResponse<IEnumerable<Class>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<Class>>();
            try
            {
                var obj = await _classRepository.GetAll();
                if (obj == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = obj;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Class>>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }
    }
}

