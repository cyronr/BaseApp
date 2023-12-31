﻿using BaseApp.Domain.Entities.ProfileEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseApp.Infrastructure.Configuration;

public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.Property(p => p.Email).HasMaxLength(150);
        builder.Property(p => p.PhoneNumber).HasMaxLength(20);
    }
}
