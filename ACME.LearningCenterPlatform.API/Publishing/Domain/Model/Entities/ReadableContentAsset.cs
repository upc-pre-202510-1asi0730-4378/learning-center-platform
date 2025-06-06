using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;

public class ReadableContentAsset : Asset
{
    public string ReadableContent { get; set; }
    public override bool Readable => true;
    public override bool Viewable => false;
    public ReadableContentAsset() : base(EAssetType.ReadableContentItem)
    {
        ReadableContent = string.Empty;
    }
    
    public ReadableContentAsset(string readableContent) : base(EAssetType.ReadableContentItem)
    {
        ReadableContent = readableContent;
    }
    
    public override string GetContent()
    {
        return ReadableContent;
    }
}