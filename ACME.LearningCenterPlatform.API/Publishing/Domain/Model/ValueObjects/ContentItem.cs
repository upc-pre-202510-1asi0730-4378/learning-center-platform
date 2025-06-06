namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

/// <summary>
/// Represents a content item in the Learning Center Platform.
/// </summary>
/// <param name="Type">
/// The type of content item, such as "ReadableContentItem", "Image", or "Video".
/// </param>
/// <param name="Content">
/// The content of the item, which can be a string representation of the content.
/// </param>
public record ContentItem(string Type, string Content);