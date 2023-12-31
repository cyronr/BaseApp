﻿using BaseApp.Domain.Entities.ProfileEntities;

namespace BaseApp.Application.Features.AuthenticationFeatures.Common;

public record ProfileDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public ProfileType ProfileType { get; set; }
}   
