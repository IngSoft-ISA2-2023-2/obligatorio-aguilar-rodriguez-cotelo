using ExportationModel.ExportDomain;
using PharmaGo.Domain.Entities;
using PharmaGo.Domain.SearchCriterias;
using PharmaGo.Exceptions;
using PharmaGo.IBusinessLogic;
using PharmaGo.IDataAccess;

namespace PharmaGo.BusinessLogic
{
    public class ProductManager: IProductManager
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Pharmacy> _pharmacyRepository;
        private readonly IRepository<Session> _sessionRepository;
        private readonly IRepository<User> _userRepository;

        public ProductManager(IRepository<Product> productRepo,
                           IRepository<Pharmacy> pharmacyRepository,                        
                           IRepository<Session> sessionRespository,
                           IRepository<User> userRespository)
        {
            _productRepository = productRepo;
            _pharmacyRepository = pharmacyRepository;
            _sessionRepository = sessionRespository;
            _userRepository = userRespository;
        }

        public Product Create(Product product, string token)
        {
            if (product == null)
            {
                throw new ResourceNotFoundException("Please create a product before inserting it.");
            }
            product.ValidOrFail();

            var guidToken = new Guid(token);
            Session session = _sessionRepository.GetOneByExpression(s => s.Token == guidToken);
            var userId = session.UserId;
            User user = _userRepository.GetOneDetailByExpression(u => u.Id == userId);

            Pharmacy pharmacyOfProduct = _pharmacyRepository.GetOneByExpression(p => p.Name == user.Pharmacy.Name);
            if (pharmacyOfProduct == null)
            {
                throw new ResourceNotFoundException("The pharmacy of the product does not exist.");
            }

            if (_productRepository.Exists(d => d.Code == product.Code && d.Pharmacy.Name == pharmacyOfProduct.Name))
            {
                throw new InvalidResourceException("The product already exists in that pharmacy.");
            }
            
            product.Pharmacy.Id = pharmacyOfProduct.Id;
            _productRepository.InsertOne(product);
            _productRepository.Save();
            return product;
        }

        public void Delete(int id)
        {
            var productToDelete = _productRepository.GetOneByExpression(p => p.Id == id);
            _productRepository.DeleteOne(productToDelete);
            _productRepository.Save();
        }

        public IEnumerable<Product> GetAllByUser(string token)
        {
            var guidToken = new Guid(token);
            Session session = _sessionRepository.GetOneByExpression(s => s.Token == guidToken);
            var userId = session.UserId;
            User user = _userRepository.GetOneDetailByExpression(u => u.Id == userId);
            Pharmacy pharmacyOfProducts = _pharmacyRepository.GetOneByExpression(p => p.Name == user.Pharmacy.Name);
            if (pharmacyOfProducts == null)
            {
                throw new ResourceNotFoundException("The pharmacy of the products does not exist.");
            }

            return _productRepository.GetAllByExpression(p => p.Pharmacy.Name == pharmacyOfProducts.Name);
        }
    }
}
