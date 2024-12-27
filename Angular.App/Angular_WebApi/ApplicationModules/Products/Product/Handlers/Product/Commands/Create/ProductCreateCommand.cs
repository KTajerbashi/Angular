﻿using Angular_WebApi.ApplicationBases.Models;

namespace Angular_WebApi.ApplicationModules.Products.Product.Handlers.Product.Commands.Create;
public class ProductCreateCommand : Command
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool Status { get; set; }
}
