using System;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Data.IRepositories;
using ProjectJunior.Models;
using ProjectJunior.Services.Interfaces;
using ProjectJunior.Services.Response;

namespace ProjectJunior.Services.Implementations
{
	public class WebService : IWebService
	{
        private readonly IWebRepository _webRepository;



        public WebService(IWebRepository webRepository)
        {
            _webRepository = webRepository;
        }



        public IBaseResponse<Web> Add(Web web)
        {
            _webRepository.Add(web);
            var baseResponse = new BaseResponse<Web>("Success", StatusCode.OK, web);

            return baseResponse;
        }



        public IBaseResponse<Web> Delete(int id)
        {
            Web web = new Web() { Id = id };
            _webRepository.Delete(web);
            var baseResponse = new BaseResponse<Web>("Success", StatusCode.OK, web);

            return baseResponse;
        }

        public IBaseResponse<Web> Delete(Web web)
        {
            _webRepository.Delete(web);
            var baseResponse = new BaseResponse<Web>("Success", StatusCode.OK, web);

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

        public async Task<IBaseResponse<Web>> Update(Web obj)
        {
            var baseResponse = new BaseResponse<Web>();
            try
            {
                if (obj == null)
                {
                    baseResponse.Description = "Объект не найден";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }


                await _webRepository.Update(obj);

                baseResponse.Data = obj;
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

