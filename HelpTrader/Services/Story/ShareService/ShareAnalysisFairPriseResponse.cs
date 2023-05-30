using HelpTrader.Domain.Dto;

namespace HelpTrader.Services.Story.ShareService;

/// <summary>
/// Response for <inheritdoc cref="ShareAnalysisFairPriseStoryContext"/>
/// </summary>
public class ShareAnalysisFairPriseResponse
{
   public List<DataAnalysisShare> FairPrises { get; set; }
}