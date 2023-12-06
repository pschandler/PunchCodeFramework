namespace PunchodeStudios.Admin.Services.Base
{
    public class BaseHttpService
    {
        protected IClient _client;
        public BaseHttpService(IClient client)
        {
            _client = client;
        }

        protected ApiResponse<Guid> ConvertApiExceptions<Guid>(ApiException ex)
        {
            if (ex.StatusCode == 400)
            {
                return new ApiResponse<Guid>()
                {
                    Message = "Invalid data was submitted.",
                    ValidationErrors = ex.Response,
                    Success = false
                }; 
            }
            else if (ex.StatusCode == 404)
            {
                return new ApiResponse<Guid>()
                {
                    Message = "Object was not found.",
                    Success = false
                };
            }
            else
            {
                return new ApiResponse<Guid>()
                {
                    Message = "An internal error has occurred. Pleas try again later.",
                    Success = false
                };
            }
        }
    }
}
