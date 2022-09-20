using AutoMapper;
using Swift.BBS.Model.Models;
using Swift.BBS.Model.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swift.BBS.Extension
{
    public class ImagesProfile : Profile
    {
        public ImagesProfile()
        {
            CreateMap<Images, ImagesDto>();
            CreateMap<ImagesDto, Images>();

        }
    }
}
