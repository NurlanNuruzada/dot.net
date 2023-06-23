using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pronia.Areas.Admin.ProductViewModel;
using Pronia.Core.Entities;

namespace Pronia.Areas.Admin.AutoMapper;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<Product, ProductView>();
		CreateMap<ProductView, Product>();
	}
}
