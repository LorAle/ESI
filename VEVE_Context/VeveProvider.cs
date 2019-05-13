using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEVE_Context.Models;

namespace VEVE_Context
{
    public class VeveProvider : IVeveProvider
    {
        private readonly VEVEEntities _context;
        public VeveProvider(VEVEEntities context)
        {
            _context = context;
        }

        public IEnumerable<CustomerOrderModel> GetCustomerOrders()
        {
            return _context.CUSTORDER.Select(x => new CustomerOrderModel
            {
                CUSTID = x.CUSTID,
                CUSTORDERID = x.CUSTORDERID,
                DATE = x.DATE,
                STATUS = x.STATUS
            }).ToList();
        }

        public IEnumerable<OrderItemsModel> GetItemsByOrder(int orderId) {
            var ordersFromDB = _context.CUSTORDER.Where(x => x.CUSTORDERID == orderId).SingleOrDefault();
            if (ordersFromDB!=null)
            {
                return ordersFromDB.ORDERITEMS.Select(x => new OrderItemsModel
                {
                    ITEMID = x.ITEMID,
                    CUSTORDERID = x.CUSTORDERID,
                    ARTICLENUMBER = x.ARTICLENUMBER,
                    COLORCODE = x.COLORCODE,
                    QUANTITY = x.QUANTITY,
                    COLORNAME = x.COLORNAME,
                    HASPRINT = x.HASPRINT,
                    PRINTNUMBER =x.PRINTNUMBER

                }).ToList();
            }
            return new List<OrderItemsModel>();
        }
        public IEnumerable<CustomerOrderModel> GetNewCustomerOrders()
        {
            var ordersFromDB = _context.CUSTORDER.Where(x => x.STATUS == 1);
            if (ordersFromDB != null)
            {
                return ordersFromDB.Select(x => new CustomerOrderModel
                {
                    CUSTID = x.CUSTID,
                    CUSTORDERID = x.CUSTORDERID,
                    DATE = x.DATE,
                    STATUS = x.STATUS
                }).ToList();
            }
            return new List<CustomerOrderModel>();
        }
        public IEnumerable<CustomerOrderModel> GetDoneCustomerOrders()
        {
            var ordersFromDB = _context.CUSTORDER.Where(x => x.STATUS !=1);
            if (ordersFromDB != null)
            {
                return ordersFromDB.Select(x => new CustomerOrderModel
                {
                    CUSTID = x.CUSTID,
                    CUSTORDERID = x.CUSTORDERID,
                    DATE = x.DATE,
                    STATUS = x.STATUS
                }).ToList();
            }
            return new List<CustomerOrderModel>();
        }

        public IEnumerable<CustomerOrderModel> DeleteCustomerOrders(int orderId) {
            var ordersFromDB = _context.CUSTORDER.Where(x => x.CUSTORDERID == orderId).SingleOrDefault();
            if (ordersFromDB != null)
            {

                /*var items = ordersFromDB.ORDERITEMS.Select(x => new OrderItemsModel
                {
                    _context.ORDERITEMS.Remove(x)
                });
                _context.ORDERITEMS.Remove(items);
                */
                _context.CUSTORDER.Remove(ordersFromDB);
                _context.SaveChanges();
            }

            return new List<CustomerOrderModel>();
        }

        public IEnumerable<CustomerModel> GetCustomers()
        {
            return _context.CUSTOMERS.Select(x => new CustomerModel
            {
                BUSINESSPARTNER = x.BUSINESSPARTNER,
                CITY = x.CITY,
                COUNTRY = x.COUNTRY,
                CUSTID = x.CUSTID,
                LASTNAME = x.LASTNAME,
                POSTCODE = x.POSTCODE,
                PRENAME = x.PRENAME,
                STREET = x.STREET
            }).ToList();
        }

        public IEnumerable<CustomerOrderModel> GetOrdersOfCustomer(int customerId)
        {
            var customerFromDB = _context.CUSTOMERS.Where(x => x.CUSTID == customerId).SingleOrDefault();
            if (customerFromDB != null)
            {
                return customerFromDB.CUSTORDER.Select(x => new CustomerOrderModel
                {
                    CUSTID = x.CUSTID,
                    CUSTORDERID = x.CUSTORDERID,
                    DATE = x.DATE,
                    STATUS = x.STATUS
                }).ToList();
            }
            return new List<CustomerOrderModel>();
        }

        public IEnumerable<CustomerOrderModel> SetOrderStatus(int orderId, int statusId) {
            //TODO: Geupdatetes Entitiy returnen
            //TODO: Fehlerfall Nachricht liefern

            var orderFromDB = _context.CUSTORDER.Where(x => x.CUSTORDERID == orderId).SingleOrDefault();
            if (orderFromDB != null) {
                orderFromDB.STATUS = statusId;
                _context.SaveChanges();
            }

            return new List<CustomerOrderModel>();
        }
    }
}
