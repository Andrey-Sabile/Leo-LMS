namespace LeoLMS.Domain.Events;

public class ClassroomCreatedEvent : BaseEvent
{
    public ClassroomCreatedEvent(Classroom classroom)
    {
        Classroom = classroom;
    }

    public Classroom Classroom { get; }
}
