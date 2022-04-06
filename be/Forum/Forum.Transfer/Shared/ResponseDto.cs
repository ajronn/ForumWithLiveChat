namespace Forum.Transfer.Shared
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }

        public ErrorDto Error { get; set; }
    }

    public static class ResponseDtoExtensions
    {
        public static ResponseDto<T> ToResponseDto<T>(this T data)
        {
            return new ResponseDto<T>
            {
                Data = data
            };
        }
    }
}
