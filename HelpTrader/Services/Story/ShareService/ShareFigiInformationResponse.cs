using HelpTrader.Models;

namespace HelpTrader.Services.Story.ShareService;

/// <summary>
/// Response for <inheritdoc cref="ShareFigiInformationStoryContext"/>
/// </summary>
public class ShareFigiInformationResponse
{
    public List<ShareData> Shares { get; set; }
}