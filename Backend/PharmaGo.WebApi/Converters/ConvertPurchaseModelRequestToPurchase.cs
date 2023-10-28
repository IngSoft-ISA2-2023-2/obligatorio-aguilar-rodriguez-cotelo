using PharmaGo.Domain.Entities;
using PharmaGo.WebApi.Models.In;

namespace PharmaGo.WebApi.Converters
{
    public class PurchaseModelRequestToPurchaseConverter
    {

        public Purchase Convert(PurchaseModelRequest model)
        {

            var purchase = new Purchase();
            purchase.PurchaseDate = model.PurchaseDate;
            purchase.BuyerEmail = model.BuyerEmail;
            purchase.details = new List<PurchaseDetail>();
            purchase.ProductDetails = new List<PurchaseDetailProduct>();
            foreach (var detail in model.Details)
            {
                if (detail.Code.Length == 3)
                {
                    purchase.details
                        .Add(new PurchaseDetail
                        {
                            Quantity = detail.Quantity, 
                            Drug = new Drug { Code = detail.Code },
                            Pharmacy = new()
                            {
                                Id = detail.PharmacyId
                            }
                        });
                }
                else
                {
                    purchase.ProductDetails.Add( new PurchaseDetailProduct
                    {
                        Quantity = detail.Quantity, 
                        Product = new Product { Code = detail.Code },
                        Pharmacy = new()
                        {
                            Id = detail.PharmacyId
                        }
                    });
                }
            }

            return purchase;
        }

    }
}
