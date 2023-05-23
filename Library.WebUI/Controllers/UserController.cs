using Library.Application.Common.Exceptions;
using Library.Application.Users.Commands.Register;
using Library.Application.Users.Queries.Login;
using Library.Application.Users.Queries.Profile;
using Library.Contracts.UserContracts;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebUI.Controllers;

[Route("[controller]")]
public class UserController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public UserController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [Route("Login")]
    public IActionResult Login() => View();


    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        try
        {
           LoginQueryResponse response = await _mediator.Send(query);

           await HttpContext.SignInAsync("Cookie", response.Principal);
        }
        catch (UserNotFoundException)
        {
            return View(request);
        }

        return Redirect("/");
    }

    [Route("Logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();

        return Redirect("/");
    }

    [Route("Register")]
    public IActionResult Register() => View();

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterRequest request) 
    {
        var command = _mapper.Map<RegisterCommand>(request);

        try
        {
            await _mediator.Send(command);
        }
        catch (UserAlreadyExistsException)
        {
            return View(request);
        }

        return Redirect("/");
    }
    
    [Route("")]
    [Authorize]
    public async Task<IActionResult> Profile()
    {
        var query = new ProfileQuery()
        {
            Login = User.Identity!.Name!
        }; 

        var response = await _mediator.Send(query);

        return View(response);
    }
}
