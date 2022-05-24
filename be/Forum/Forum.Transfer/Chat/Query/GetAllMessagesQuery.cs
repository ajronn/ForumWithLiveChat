using Forum.Transfer.Chat.Data;
using Forum.Transfer.Shared;
using MediatR;

namespace Forum.Transfer.Chat.Query
{
    public class GetAllMessagesQuery : ListQuery, IRequest<PageListDto<MessageDto>>
    {
        public GetAllMessagesQuery(GetAllMessagesQuery query)
        {
            Page = query.Page;
            PageSize = query.PageSize;
            SearchBy = query.SearchBy;
        }

        public GetAllMessagesQuery()
        {
        }
    }
}
