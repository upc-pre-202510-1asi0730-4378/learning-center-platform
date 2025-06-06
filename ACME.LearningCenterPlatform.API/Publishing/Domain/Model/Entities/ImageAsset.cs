using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;

public class ImageAsset : Asset
{
    public Uri? ImageUri { get; }
 
    public ImageAsset() : base(EAssetType.Image)
    {
        
    }

    public ImageAsset(string imageUrl) : base(EAssetType.Image)
    {
        ImageUri = new Uri(imageUrl);
    }
    
}

