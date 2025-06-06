using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;

/// <summary>
/// Represents an asset in the publishing bounded context.
/// </summary>
/// <param name="type">
/// The <see cref="EAssetType"/> type of the asset.
/// </param>
public partial class Asset(EAssetType type) : IPublishable
{
    public int Id { get; }
    public AcmeAssetIdentifier AssetIdentifier { get; private set; } = new();
    public EPublishingStatus Status { get; private set; } = EPublishingStatus.Draft;
    public EAssetType Type { get; private set; } = type;
    public virtual bool Readable => false;
    public virtual bool Viewable => false;
    
    /// <summary>
    /// Sends the asset to the editing stage in the publishing workflow.
    /// </summary>
    public void SendToEdit()
    {
        Status = EPublishingStatus.ReadyToEdit;
    }

    /// <summary>
    /// Sends the asset to the approval stage in the publishing workflow.
    /// </summary>
    public void SendToApproval()
    {
        Status = EPublishingStatus.ReadyToApproval;
    }

    /// <summary>
    /// Approves the asset and locks it in the publishing workflow.
    /// </summary>
    public void ApproveAndLock()
    {
        Status = EPublishingStatus.ApprovedAndLocked;
    }

    /// <summary>
    /// Rejects the asset and returns it to the draft status in the publishing workflow.
    /// </summary>
    public void Reject()
    {
        Status = EPublishingStatus.Draft;
    }

    /// <summary>
    /// Returns the asset to the editing stage in the publishing workflow.
    /// </summary>
    public void ReturnToEdit()
    {
        Status = EPublishingStatus.ReadyToEdit;
    }

    /// <summary>
    /// Returns the content of the asset.
    /// </summary>
    /// <returns>
    /// An object representing the content of the asset.
    /// </returns>
    public virtual object GetContent()
    {
        return string.Empty;
    }
}