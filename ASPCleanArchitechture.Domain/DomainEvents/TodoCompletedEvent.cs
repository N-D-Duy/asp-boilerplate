namespace ASPCleanArchitechture.Domain.DomainEvents
{
    using System;

    public class TodoCompletedEvent
    {
        public int TodoId { get; private set; }
        public DateTime CompletedDate { get; private set; }

        public TodoCompletedEvent(int todoId, DateTime completedDate)
        {
            TodoId = todoId;
            CompletedDate = completedDate;
        }
    }
}
