﻿using API.Requests.AuthenticationRequests;
using API.Requests.AuthenticationResponses;
using BaseApp.Application.Features.AuthenticationFeatures.Commands.CreateAdminProfile;
using BaseApp.Application.Features.AuthenticationFeatures.Common;
using BaseApp.Application.Features.AuthenticationFeatures.Queries.Login;
using BaseApp.WebAPI.Requests.AuthenticationRequests;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController(ILogger<AuthenticationController> _logger, IMediator _mediator) : ControllerBase
{
    #region DI
    private readonly ILogger<AuthenticationController> _logger = _logger;
    private readonly IMediator _mediator = _mediator;
    #endregion

    [HttpPost("login")]
    public async Task<ActionResult<AuthenticationResponse>> Login(LoginRequest request)
    {
        _logger.LogInformation($"Logging {request.Email}.");

        var query = new LoginQuery(request.Email, request.Password);
        var response = await _mediator.Send(query);

        _logger.LogInformation($"{request.Email} logged with token {response}.");

        return Ok(response.Adapt<AuthenticationResponse>());
    }

    [HttpPost("register/admin")]
    public async Task<ActionResult<AuthenticationResponse>> CreateAdminProfile(CreateAdminProfileRequest request)
    {
        _logger.LogInformation("Creating admin profile. Request: {Request}", request.ToString());

        CreateAdminProfileCommand command = request.Adapt<CreateAdminProfileCommand>();
        AuthenticationResult response = await _mediator.Send(command);

        _logger.LogInformation("Successfully created new profile for request: {Request}", request.ToString());
        return Ok(response.Adapt<AuthenticationResponse>());
    }
}
