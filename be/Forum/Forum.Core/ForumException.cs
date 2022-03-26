using System;
using Forum.Core.Enums;

namespace Forum.Core
{
    public class ForumException : Exception
    {
        public ForumException() { }

        public ForumException(ForumErrorCode code)
        {
            ForumErrorCode = code;
        }

        public ForumException(ForumErrorCode code, string message) : base(message)
        {
            ForumErrorCode = code;
        }

        public ForumException(ForumErrorCode code, string message, Exception inner) : base(message,
            inner)
        {
            ForumErrorCode = code;
        }

        public ForumErrorCode ForumErrorCode { get; }
    }
}
