namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

/// <summary>
/// Represents a publishable content item in the Learning Center Platform.
/// </summary>
public interface IPublishable
{
    void SendToEdit();
    void SendToApproval();
    void ApproveAndLock();
    void Reject();
    void ReturnToEdit();
}