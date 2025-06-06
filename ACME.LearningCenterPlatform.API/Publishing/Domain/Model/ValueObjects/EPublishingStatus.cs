namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;
/// <summary>
/// Represents the publishing status of a content item in the Learning Center Platform.
/// </summary>
public enum EPublishingStatus
{
    Draft,
    ReadyToEdit,
    ReadyToApproval,
    ApprovedAndLocked,
}