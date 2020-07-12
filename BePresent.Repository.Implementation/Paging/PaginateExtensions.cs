using BePresent.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BePresent.Repository.Implementation.Paging
{
    public static class PaginateExtensions
    {
        public static IPaginate<T> ToPaginate<T>(this IQueryable<T> source, int page, int size)
        {
            return new Paginate<T>(source, page, size);
        }

        public static async Task<IPaginate<T>> ToPaginateAsync<T>(this IQueryable<T> source,
            int page,
            int size,
            CancellationToken cancellationToken = default(CancellationToken))
        {

            if (page <= 0)
            {
                throw new ArgumentException("Page must be greather than 1");
            }

            if (size <= 0)
            {
                throw new ArgumentException("Size must be greather than 1");
            }

            var count = await source.CountAsync(cancellationToken).ConfigureAwait(false);

            var items = await source.Skip((page - 1) * size)
                .Take(size).ToListAsync(cancellationToken).ConfigureAwait(false);

            var totalPages = (int)Math.Ceiling(count / (double)size);

            var pagedList = new Paginate<T>()
            {
                Page = page,
                Size = size,
                TotalCount = count,
                Items = items,
                Pages = (int)Math.Ceiling(count / (double)size),
                HasPrevios = page == 1 ? false : true,
                HasNext = page < totalPages ? true : false
            };

            return pagedList;
        }
    }
}
