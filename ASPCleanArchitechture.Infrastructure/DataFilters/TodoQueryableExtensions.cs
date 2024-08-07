using ASPCleanArchitechture.Domain.Entities;
namespace ASPCleanArchitechture.Infrastructure.DataFilters
{
    public static class TodoQueryableExtensions
    {
        public static IQueryable<Todo> ApplyFilters(this IQueryable<Todo> query, TodoFilters filters)
        {
            if (filters == null)
            {
                return query;
            }

            if (!string.IsNullOrEmpty(filters.Title))
            {
                query = query.Where(x => x.Title.Contains(filters.Title));
            }

            if (!string.IsNullOrEmpty(filters.Description))
            {
                query = query.Where(x => x.Description.Contains(filters.Description));
            }

            if (filters.IsCompleted.HasValue)
            {
                query = query.Where(x => x.IsCompleted == filters.IsCompleted);
            }

            return query;
        }
    }
}