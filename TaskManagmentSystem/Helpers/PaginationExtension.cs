using Microsoft.EntityFrameworkCore;

namespace TaskManagmentSystem.Helpers
{
    public static class PaginationExtension
    {
        public static async Task<PaginatedResult<T>> ToPaginatedListAsync<T>(
            this IQueryable<T> query,
            int pageNumber,
            int pageSize)
        {
            pageNumber = pageNumber < 1 ? 1 : pageNumber;

            var count = await query.CountAsync();

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedResult<T>(items, count, pageNumber, pageSize);
        }
    }
}
