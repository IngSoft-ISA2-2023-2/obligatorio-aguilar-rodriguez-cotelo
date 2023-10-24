using ExportationModel.ExportDomain;
using PharmaGo.Domain.Entities;
using PharmaGo.Domain.SearchCriterias;

namespace PharmaGo.IBusinessLogic
{
    public interface IProductManager
    {
        Product Create(Product product, string token);
        Product Update(int id, Product product);
        void Delete(int id);
        IEnumerable<Product> GetAllByUser(string token);
        IEnumerable<Product> GetAll(ProductSearchCriteria productSearchCriteria);
        Product GetById(int id);
    }
}
