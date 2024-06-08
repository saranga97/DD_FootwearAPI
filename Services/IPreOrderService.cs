using System.Collections.Generic;
using DD_FootwearAPI.Models;

namespace DD_FootwearAPI.Services
{
    public interface IPreOrderService
    {
        IEnumerable<PreOrder> GetAllPreOrders();
        PreOrder GetPreOrderById(int id);
        void CreatePreOrder(PreOrder preOrder);
        void UpdatePreOrder(int id, PreOrder preOrder); // Add the 'int id' parameter
        void DeletePreOrder(int id);
    }
}
