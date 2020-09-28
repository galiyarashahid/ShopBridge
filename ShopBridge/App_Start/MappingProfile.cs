using AutoMapper;
using ShopBridge.Dtos;
using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBridge.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Items, ItemDto>();
            Mapper.CreateMap<ItemDto, Items>();
        }
    }
}