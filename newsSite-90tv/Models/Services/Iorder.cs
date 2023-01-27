using newsSite90tv.Models.apimodels;
using newsSite90tv.Models.apiobject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsSite90tv.Models.Services
{
    public interface Iorder
    {

        Task<AllApi> AddOrderDetail(OrderDetailAddApiModel model,string token);
        Task<AllApi> AddOrder(string token);

        Task<Order> GetLastOrder(long appuserid);

        Task<OrderApiObject> GetOrderInfo(int idaddress ,string token);

        Task<OrderHistoryApiObject> GetOrderHistory(string token);

        Task<OrderDetailListApiObject> GetOrderDetail(long idorder);

       
    }
}
