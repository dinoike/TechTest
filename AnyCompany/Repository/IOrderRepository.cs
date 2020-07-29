using AnyCompany.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Core.Repository
{
    public interface IOrderRepository
    {
        void Save(Order order);
    }
}
