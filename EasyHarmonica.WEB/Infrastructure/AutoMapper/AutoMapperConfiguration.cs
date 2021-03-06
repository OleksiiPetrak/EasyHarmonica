﻿using AutoMapper;
using EasyHarmonica.BLL.Infrastructure.AutoMapper;

namespace EasyHarmonica.WEB.Infrastructure.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                MapperProfilesBllInitializator.Initialize(x);
            });
        }
    }
}