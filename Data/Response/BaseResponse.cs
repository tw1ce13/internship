using System;
namespace ProjectJunior.Services.Response
{
	public class BaseResponse<T> : IBaseResponse<T>
	{
		public string Description { get; set; }
		public StatusCode StatusCode { get; set; }
		public T Data { get; set; }

		public BaseResponse()
		{
		}

        public BaseResponse(string description, StatusCode statusCode, T data)
        {
			Description = description;
			StatusCode = statusCode;
			Data = data;
        }
    } 

	public interface IBaseResponse<T>
	{
		T Data { get; set; }
	}
}

