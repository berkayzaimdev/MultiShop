using MultiShop.Order.Application.Features.OrderDetails.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.OrderDetails.Queries.Common
{
    public class OrderDetailResponse : OrderDetailModel
    {
        public int Id { get; set; }
    }
}
