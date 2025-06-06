using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;

public class VideoAsset : Asset
{
    public Uri? VideoUri { get; private set; }
    
    public VideoAsset() : base(EAssetType.Video)
    {
        VideoUri = null;    
    }
    
    public VideoAsset(string videoUrl) : base(EAssetType.Video)
    {
        if (string.IsNullOrWhiteSpace(videoUrl))
        {
            throw new ArgumentException("Video URL cannot be null or empty.", nameof(videoUrl));
        }

        VideoUri = new Uri(videoUrl);
    }

    public override bool Readable => false;

    public override bool Viewable => true;
}