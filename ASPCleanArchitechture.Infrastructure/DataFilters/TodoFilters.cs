namespace ASPCleanArchitechture.Infrastructure.DataFilters
{
    public class TodoFilters
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public bool? IsCompleted { get; set; }
    }
}