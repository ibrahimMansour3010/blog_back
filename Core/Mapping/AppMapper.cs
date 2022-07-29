using AutoMapper;
using Core.DTOs;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping
{
    public class AppMapper:Profile
    {
        public AppMapper()
        {
            CreateMap<BlogItem, Blog>().ReverseMap();
            CreateMap<Blog,BlogDTO> ().ForMember(i=>i.creationDate , opt=>opt.MapFrom(s=>s.CreationDate.ToString("MM/dd/yyyy"))).ReverseMap();
        }
    }
}
