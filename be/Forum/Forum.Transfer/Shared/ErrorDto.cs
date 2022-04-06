using Forum.Core.Enums;

namespace Forum.Transfer.Shared
{
    public class ErrorDto
    {
        public ForumErrorCode ForumErrorCode { get; set; }
        
        public string Message { get; set; }

        public ErrorDto()
        {

        }

        public ErrorDto(ForumErrorCode forumErrorCode)
        {
            ForumErrorCode = forumErrorCode;
        }

        public ErrorDto(ForumErrorCode forumErrorCode, string message)
        {
            ForumErrorCode = forumErrorCode;
            Message = message;
        }
    }
}
