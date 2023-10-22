using PharmaGo.Domain.Entities;

namespace PharmaGo.WebApi.Models.In;

public class ProductModel
{
    public int Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }

    public Product ToEntity()
    {
        return new Product()
        {
            Code = this.Code,
            Name = this.Name,
            Description = this.Description,
            Price = this.Price
        };
    }
}