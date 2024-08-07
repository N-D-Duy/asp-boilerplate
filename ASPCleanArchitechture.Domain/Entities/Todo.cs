namespace ASPCleanArchitechture.Domain.Entities
{
    public class Todo(string title, string description)
    {
        public int Id { get; private set; }
        public string Title { get; private set; } = title;
        public string Description { get; private set; } = description;
        public bool IsCompleted { get; private set; } = false;


        public void MarkAsCompleted()
        {
            IsCompleted = true;
        }

        public void UpdateTitle(string title)
        {
            Title = title;
        }
    }

}

