using Persistence;
using DAL;
using System.Collections.Generic;
namespace BL{
    public class OrderBL{
    OrderDal OrderDal = new OrderDal();
    List<orders> ordersList = new List<orders>();
    List<OrderProduct> orderProducts = new List<OrderProduct>();

        public int GetOrderId(){
            int GetId = OrderDal.getCountOrder();
            return GetId+1;
        }

        public void ReamainingAmount(int amount,int quantity,int ProductID){
           int newAmount = amount - quantity;
            OrderDal.ReamainingAmount(newAmount,ProductID);
        }
        public void AddOrder(int idcustomer, int OrderID){
            OrderDal.CreateOrder(idcustomer,OrderID);
        }

        public void addOrderProduct(int productId,int quantity,int OrderId,int totalPrice ){
            OrderDal.addOrderProduct(productId,quantity,OrderId,totalPrice);
        }

        public List<orders> GetListOrderId(int CustomerId){
            List<orders> orders = new List<orders>();
            orders = OrderDal.GetOrderId(CustomerId);
            return orders;
        }

        public List<OrderProduct> GetListOrderProducts(int OrderID){
            orderProducts = OrderDal.GetListOrderProducts(OrderID);
            return orderProducts;
        }

        public List<orders> GetListAllOrder(){
            ordersList = OrderDal.GetListAllOrder();
            return ordersList;
        }

        public void ChangeStatus(int OrderId){
            OrderDal.ChangeStatus(OrderId);
        }

        public List<orders> GetOrderPending(){
            ordersList = OrderDal.GetOrderPending();
            return ordersList;
        }


    }
}