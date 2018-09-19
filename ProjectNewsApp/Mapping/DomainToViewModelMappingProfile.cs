using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PattuSaree.Entity;
using PattuSaree.ViewModel;

namespace ProjectNewsApp.Mapping
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName => "DomainToViewModelMappings";

        public DomainToViewModelMappingProfile()
        {
            Configure();
        }

        private void Configure()
        {
            CreateMap<UserMaster, UserMasterViewModel>().ReverseMap();
            CreateMap<UserMaster, UserMasterViewModel>();

        }
    }
}