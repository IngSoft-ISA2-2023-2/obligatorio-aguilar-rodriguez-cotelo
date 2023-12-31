using Microsoft.AspNetCore.Mvc;
using PharmaGo.Domain.Entities;
using PharmaGo.Domain.SearchCriterias;
using PharmaGo.IBusinessLogic;
using PharmaGo.WebApi.Enums;
using PharmaGo.WebApi.Filters;
using PharmaGo.WebApi.Models.In;
using PharmaGo.WebApi.Models.Out;

namespace PharmaGo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionFilter))]
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;

        public ProductController(IProductManager manager)
        {
            _productManager = manager;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] ProductSearchCriteria productSearchCriteria)
        {
            IEnumerable<Product> products = _productManager.GetAll(productSearchCriteria);
            IEnumerable<ProductBasicModel> productBasicModels = products.Select(d => new ProductBasicModel(d));
            return Ok(productBasicModels);
        }
        
        [HttpGet("{id}")]

        public IActionResult GetById([FromRoute] int id)
        {
            Product product = _productManager.GetById(id);
            return Ok(new ProductDetailModel(product));
        }
        
        [HttpPost]
        [AuthorizationFilter(new string[] { nameof(RoleType.Employee) })]
        public IActionResult Create([FromBody] ProductModel productModel)
        {
            string token = HttpContext.Request.Headers["Authorization"];
            Product productCreated = _productManager.Create(productModel.ToEntity(), token);
            ProductDetailModel productResponse = new ProductDetailModel(productCreated);
            return Ok(productResponse);
        }
        
        [HttpGet]
        [Route("[action]")]
        [AuthorizationFilter(new string[] { nameof(RoleType.Employee) })]
        public IActionResult User()
        {
            string token = HttpContext.Request.Headers["Authorization"];
            IEnumerable<Product> products = _productManager.GetAllByUser(token);
            IEnumerable<ProductBasicModel> productToReturn = products.Select(p => new ProductBasicModel(p));
            return Ok(productToReturn);
        }
        
        [HttpDelete("{id}")]
        [AuthorizationFilter(new string[] { nameof(RoleType.Employee) })]
        public IActionResult Delete([FromRoute] int id)
        {
            _productManager.Delete(id);
            return Ok(true);
        }

        [HttpPut("{id}")]
        [AuthorizationFilter(new string[] { nameof(RoleType.Employee) })]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateProductModel updatedProduct)
        {
            Product product = _productManager.Update(id, updatedProduct.ToEntity());
            return Ok(new ProductDetailModel(product));
        }
    }
}