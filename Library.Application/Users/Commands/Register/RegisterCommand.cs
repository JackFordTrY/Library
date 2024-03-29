﻿using MediatR;

namespace Library.Application.Users.Commands.Register;

public class RegisterCommand: IRequest
{
    public string Login { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}
