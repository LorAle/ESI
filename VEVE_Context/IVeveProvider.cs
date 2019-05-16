﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEVE_Context.Models;

namespace VEVE_Context
{
    public interface IVeveProvider
    {
        IEnumerable<CustomerModel> GetCustomers();
        IEnumerable<CustomerModel> GetCustomersById(int customerId);
        IEnumerable<OrderItemsModel> GetItemsByOrder(int orderId);

        IEnumerable<CustomerOrderModel> GetCustomerOrders();
        IEnumerable<CustomerOrderModel> GetNewCustomerOrders();
        IEnumerable<CustomerOrderModel> GetDoneCustomerOrders();
        IEnumerable<CustomerOrderModel> DeleteCustomerOrders(int orderId);

        IEnumerable<CustomerOrderModel> GetOrdersOfCustomer(int customerId);

        IEnumerable<CustomerOrderModel> SetOrderStatus(int orderId, int statusId);
        CustomerModel CreateCustomer(CustomerModel data);
        CustomerOrderModel CreateCustOrder(CustomerOrderFormModel data);
        OrderItemsModel CreateOrderItem(OrderItemsModel data);
    }
}
