using AutoMapper;
using CRUD_Reponsive_Web_API.Entities;
using CRUD_Reponsive_Web_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Reponsive_Web_API.Mapping
{
    public class EntityToDTO : Profile
    {
        public EntityToDTO()
        {
            CreateMap<Document, DocumentModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            //    .AfterMap((src,dest)=>
            //{
              
            //}).ReverseMap();
        }
    }
}
