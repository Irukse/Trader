using HelpTrader.Domain.Dto;

namespace HelpTrader.Services.Story.ShareService;

/// <summary>
/// Response for <inheritdoc cref="SharePriceInformationStoryContext"/>
/// </summary>
public class SharePriceInformationResponse
{
    public List<SharePrice> Prices { get; set; }
}