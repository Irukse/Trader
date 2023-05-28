using HelpTrader.Models;

namespace HelpTrader.Services.Story.ShareService;

/// <summary>
/// Response for <inheritdoc cref="ShareAnalysisFairPriseStoryContext"/>
/// </summary>
public class ShareAnalysisFairPriseResponse
{
   public List<DataAnalysisShare> FairPrise { get; set; }
}