namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;

public record AddReadableContentAssetToTutorialCommand(string Content, int TutorialId);