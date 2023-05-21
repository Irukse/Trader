using System.Net.Mime;
using bgTeam;
using HelpTrader.Services.Story;
using HelpTrader.Services.Story.ShareService;
using Microsoft.AspNetCore.Mvc;

namespace HelpTrader.WebApp.Controllers;

//[ApiController]
//[Route("[controller]")]
[ApiController]
[Route("[controller]")]
public class ShareController : ControllerBase
{
    private readonly IStoryBuilder _storyBuilder;


    /// <summary>
    /// Initializes a new instance of the <see cref="BlacklistedEmailsController"/> class.
    /// </summary>
    /// <param name="languageService"></param>
    /// <param name="storyBuilder"></param>
    /// <param name="queryBuilder"></param>
    public ShareController(IStoryBuilder storyBuilder)
    {
        _storyBuilder = storyBuilder;
    }

    // [HttpGet("[action]")]
    //
  //  [Consumes(MediaTypeNames.Application.Json)]
    // [HttpGet("[action]")]
    // [Consumes(MediaTypeNames.Application.Json)]
    // public async Task<ShareFigiInformationResponse> GetListFigiInformation(List<string> shares)
    // {
    //     var context = new ShareFigiInformationStoryContext()
    //     {
    //         Shares = shares
    //     };
    //    // return await _storyBuilder.Build(context).ReturnAsync<ShareFigiInformationResponse>();
    //     return await _storyBuilder.ReturnAsync<ShareFigiInformationStoryContext, ShareFigiInformationResponse>(context);
    // }
    
    
[HttpGet("logs")]
[Consumes(MediaTypeNames.Application.Json)]
    public async Task<ShareFigiInformationResponse> GetListFigiInformationk([FromQuery]List<string> shares)
    {
        var context = new ShareFigiInformationStoryContext()
        {
            Shares = shares
        };
        return await _storyBuilder.ReturnAsync<ShareFigiInformationStoryContext, ShareFigiInformationResponse>(context);
    }
}

