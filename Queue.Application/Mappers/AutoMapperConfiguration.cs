﻿using AutoMapper;
using Microsoft.AspNetCore.Routing.Constraints;
using Queue.Application.RequestModels.ClientRequestModels;
using Queue.Application.ResponseModels.ClientResponseModel;
using Queue.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Application.Mappers
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration() 
        {
            CreateMap<Client, ClientResponseModel>();
                
            CreateMap<CreateClientRequestModel, Client>();
        }
    }
}
