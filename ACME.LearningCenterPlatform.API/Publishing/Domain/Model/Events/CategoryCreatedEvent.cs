using ACME.LearningCenterPlatform.API.Shared.Domain.Model.Events;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Events;

public class CategoryCreatedEvent(string name) : IEvent
{
    public string Name { get; } = name;
}