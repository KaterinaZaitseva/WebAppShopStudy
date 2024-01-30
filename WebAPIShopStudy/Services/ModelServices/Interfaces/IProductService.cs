﻿using WebAPIShopStudy.Models.Entities;
using WebAPIShopStudy.Services.CrudServices.Interfaces;

namespace WebAPIShopStudy.Services.ModelServices.Interfaces;

public interface IProductService : ICachedCrudService<ProductModel>
{
}