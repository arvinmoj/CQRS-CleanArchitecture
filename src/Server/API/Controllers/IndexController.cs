using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route(template: Infrastructure.Constant.Router.Controller)]
public class IndexController : Infrastructure.ControllerBase
{
    #region Constructor
    public IndexController(MediatR.IMediator mediator) : base(mediator: mediator)
    {
    }
    #endregion / Constructor

    #region Get (Get Test Controller)
    [HttpGet(Name = "Get")]
    public IActionResult Get()
    {
        return Ok(value: "Index Controller - Action Get");
    }
    #endregion / Get (Get Test Controller)

    #region Post (Create User)
    [HttpPost]
    [ProducesResponseType
        (type: typeof(FluentResults.Result<System.Guid>),
        statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]

    [Microsoft.AspNetCore.Mvc.ProducesResponseType
        (type: typeof(FluentResults.Result),
        statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]
    public async Task <IActionResult> Post([FromBody]
                Application.Users.Commands.CreateUserCommand request)
    {
        var result =
            await Mediator.Send(request).ConfigureAwait(true);

        return FluentResult(result: result);
    }
    #endregion /Post (Create User)

    #region Get (Get Some User)
    [HttpGet(template: "{count?}")]
    [ProducesResponseType
        (type: typeof(FluentResults.Result<IList<Persistence.Users.ViewModels.GetUsersQueryResponseViewModel>>),
        statusCode: StatusCodes.Status200OK)]

    [ProducesResponseType
        (type: typeof(FluentResults.Result),
        statusCode: Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get([FromRoute] int? count)
    {
        var request =
            new Application.Users.Queries.GetUsersQuery
            {
                Count = count,
            };

        var result =
            await Mediator.Send(request).ConfigureAwait(true);

        return FluentResult(result: result);
    }
    #endregion /Get (Get Some User)
}
