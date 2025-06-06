namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;

public record AddImageAssetToTutorialCommand(string ImageUrl, int TutorialId);