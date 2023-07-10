using Mercadona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadona.DataAccess.Repository.IRepository
{
    public interface IDiscountRepository : IRepository<Discount>
    {
        void Update(Discount discount);
    }
}
