using System;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Models;
using ProjectJunior.Services.Interfaces;
using ProjectJunior.Services.Response;

namespace ProjectJunior.Services.Implementations
{
	public class WebService : IWebService
	{
        private readonly IGeneralRepository<Web> _webRepository;



        public WebService(IGeneralRepository<Web> webRepository)
        {
            _webRepository = webRepository;
        }



        public IBaseResponse<Web> Add(Web web)
        {
            var baseResponse = new BaseResponse<Web>();
            _webRepository.Add(web);
            baseResponse.Description = "Успешно добавлено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = web;
            return baseResponse;
        }



        public IBaseResponse<Web> Delete(int id)
        {
            var baseResponse = new BaseResponse<Web>();
            Web web = new Web() { Id = id };
            _webRepository.Delete(web);
            baseResponse.Description = "Успешно удалено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = web;
            return baseResponse;
        }

        public IBaseResponse<Web> Delete(Web web)
        {
            var baseResponse = new BaseResponse<Web>();
            _webRepository.Delete(web);
            baseResponse.Description = "Успешно удалено";
            baseResponse.StatusCode = StatusCode.OK;
            baseResponse.Data = web;
            return baseResponse;
        }

        public async Task<IBaseResponse<Web>> Get(int id)
        {
            var baseResponse = new BaseResponse<Web>();
            try
            {
                var web = await _webRepository.Get(id);
                if (web == null)
                {
                    baseResponse.Description = "Не найдено";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = web;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Web>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.Error
                };
            }
        }


        public async Task<IBaseResponse<IEnumerable<Web>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<Web>>();
            try
            {
                var webs = await _webRepository.GetAll();
                if (webs == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = webs;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Web>>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Web>> Update(int id, Web obj)
        {
            var baseResponse = new BaseResponse<Web>();
            try
            {
                var web = await _webRepository.Get(id);
                if (web == null)
                {
                    baseResponse.Description = "Объект не найден";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                web.Name = obj.Name;


                await _webRepository.Update(web);

                baseResponse.Data = web;
                baseResponse.Description = "успешно";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Web>()
                {
                    StatusCode = StatusCode.Error,
                    Description = ex.Message
                };
            }
        }
    }
}

