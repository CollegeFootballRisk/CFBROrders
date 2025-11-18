using CFBROrders.SDK.Data_Models;
using CFBROrders.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFBROrders.SDK.Interfaces.Services
{
    public interface IOrderAllocationService
    {
        public IOperationResult InsertOrderAllocation(OrderAllocation orderAllocation);
        
        public void InsertOrderAllocationWithoutTransaction(OrderAllocation orderAllocation);
        
        public IOperationResult InsertOrderAllocations(List<OrderAllocation> orderAllocations);
    }
}
