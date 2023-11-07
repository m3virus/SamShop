using SamShop.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamShop.Domain.Core.Interfaces.Services
{
    public interface IProductServices
    {
        Task ConfirmProduct(int ProductId, CancellationToken cancellation);
        Task DeleteProduct(int ProductId, CancellationToken cancellation);
        IEnumerable<Product> GetProductsByIsAccepted();
    }
}
