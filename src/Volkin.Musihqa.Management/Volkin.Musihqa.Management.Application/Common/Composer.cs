﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Volkin.Musihqa.Management.Application.Common;

public static class Composer
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(Composer));
        return services;
    }
}