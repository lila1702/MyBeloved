using MyBeloved.API.Models;

namespace MyBeloved.API.Validation
{
    public class ValidationEmptyOrNull<T>
    {
        public Response<T> CheckIfNullOrEmpty(T data)
        {
            if (data == null)
            {
                return new Response<T>
                {
                    Data = default(T),
                    Message = "Not found or null",
                    Success = false
                };
            }
            else
            {
                return new Response<T> { };
            }
        }

        public Response<List<T>> MultipleCheckIfNullOrEmpty(T data)
        {
            Response<List<T>> listResponse = new Response<List<T>>();

            if (data == null)
            {
                Response<T> response = new Response<T>
                {
                    Data = default(T),
                    Message = "Not found or null",
                    Success = false
                };
            }
            else
            {
                listResponse = new Response<List<T>> { };
            }
            return listResponse;
        }
    }
}
