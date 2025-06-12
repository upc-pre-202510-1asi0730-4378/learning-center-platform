using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregates;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Services;

public interface ITutorialCommandService
{
    Task<Tutorial?> Handle(AddVideoAssetToTutorialCommand command);
    Task<Tutorial?> Handle(AddImageAssetToTutorialCommand command);
    Task<Tutorial?> Handle(AddReadableContentAssetToTutorialCommand command);
    Task<Tutorial?> Handle(CreateTutorialCommand command);
}