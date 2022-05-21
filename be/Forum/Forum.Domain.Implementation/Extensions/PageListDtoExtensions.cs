using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Transfer.Shared;
using Microsoft.EntityFrameworkCore;

namespace Forum.Domain.Implementation.Extensions
{
    public static class PageListDtoExtensions
    {
        public static PageListDto<T> ToPagedList<T>(this IQueryable<T> queryable, ListQuery query)
        {
            var count = queryable.Count();

            var results = queryable
                .Skip(query.PageSize * query.Page)
                .Take(query.PageSize)
                .ToList();

            return new PageListDto<T>
            {
                Page = query.Page,
                PageSize = query.PageSize,
                Count = results.Count,
                Total = count,
                Items = results
            };
        }

        public static async Task<PageListDto<T>> ToPagedListAsync<T>(this IQueryable<T> queryable, ListQuery query)
        {
            var count = await queryable.CountAsync();

            var results = await queryable
                .Skip(query.PageSize * query.Page)
                .Take(query.PageSize)
                .ToListAsync();

            return new PageListDto<T>
            {
                Page = query.Page,
                PageSize = query.PageSize,
                Count = results.Count,
                Total = count,
                Items = results
            };
        }

        public static PageListDto<T> ToPagedList<T>(this IEnumerable<T> enumerable, ListQuery query)
        {
            var collection = enumerable.ToList();

            var count = collection.Count();

            var results = collection
                .Skip(query.PageSize * query.Page)
                .Take(query.PageSize)
                .ToList();

            return new PageListDto<T>
            {
                Page = query.Page,
                PageSize = query.PageSize,
                Count = results.Count,
                Total = count,
                Items = results
            };
        }

    }
}
