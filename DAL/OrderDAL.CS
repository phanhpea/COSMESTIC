using System.Security.Cryptography.X509Certificates;
using System;
using System.Data;
using System.Collections;
using Persistence;
using MySql.Data.MySqlClient;
namespace DAL{ 

    public class OrderDal{
        public static MySqlConnection conn = DBMySQLUtils.GetDBConnection();

        public int getCountOrder(){
            int countId =0;
            conn.Open();
            string _Query = "Select count(OrderId) From Orders";
            MySqlCommand cmd = new MySqlCommand( _Query,conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read()){
                countId = dr.GetInt32("Count(OrderId)");
            }
            conn.Close();
            return countId;
        }

        public void CreateOrder(int CustomerId,int OrderId){
            conn.Open();
            string _Query ="Insert into orders(CustomerId,OrderId,OrderStatus) Values("+CustomerId+","+OrderId+",0)";
            MySqlCommand cmd = new MySqlCommand( _Query,conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            conn.Close();
        }

        public void addOrderProduct(int productId,int quantity,int OrderId,int totalPrice ){
            conn.Open();
            string _Query = "Insert into orderproduct(ProductId,Quantity,TotalPrice,OrderId) Values("+productId+","+quantity+","+totalPrice+","+OrderId+")";
            MySqlCommand cmd = new MySqlCommand( _Query,conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            conn.Close();
        }

        public void ReamainingAmount(int quantity, int ProductId){
            conn.Open();
            string _Query ="Update product Set ProductAmount = '"+quantity+"' WHERE ProductId ='"+ProductId+"'";
            MySqlCommand cmd = new MySqlCommand( _Query,conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            conn.Close();
        }

        public List<orders> GetOrderId(int CustomerId){
            conn.Open();
            string _Query = "SELECT * FROM orders WHERE CustomerId = '"+CustomerId+"'";
            MySqlCommand cmd = new MySqlCommand( _Query,conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            List<orders> ordersList = new List<orders>();
            if(dr.HasRows){
                while(dr.Read()){
                   int orderId =  dr.GetInt32("OrderId");
                   int orderStatus = dr.GetInt32("OrderStatus");
                   int customerId = dr.GetInt32("CustomerId");
                   orders Orders = new orders(customerId,orderId,orderStatus);
                   ordersList.Add(Orders);
                }
            }
            conn.Close();
            return ordersList;
           
        }

        public List<OrderProduct> GetListOrderProducts(int OrderID){
            conn.Open();
            string _Query ="SELECT * FROM orderproduct WHERE OrderId ='"+OrderID+"'";
            MySqlCommand cmd = new MySqlCommand( _Query,conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            List<OrderProduct> orderProducts = new List<OrderProduct>();
            if(dr.HasRows){
                while(dr.Read()){
                    int productId = dr.GetInt32("ProductId");
                    int quantity = dr.GetInt32("Quantity");
                    int totalPrice = dr.GetInt32("TotalPrice");
                    int orderId = dr.GetInt32("OrderId");
                    OrderProduct orderProduct = new OrderProduct(productId,quantity,totalPrice,orderId);
                    orderProducts.Add(orderProduct);
                }
                
            }
            conn.Close();
            return orderProducts;
            
        }

        public List<orders> GetListAllOrder(){
            conn.Open();
            string _Query ="SELECT * FROM orders";
            MySqlCommand cmd = new MySqlCommand( _Query,conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            List<orders> ordersList = new List<orders>();
            if(dr.HasRows){
                while(dr.Read()){
                    int orderId =  dr.GetInt32("OrderId");
                    int orderStatus = dr.GetInt32("OrderStatus");
                    int customerId = dr.GetInt32("CustomerId");
                    orders Orders = new orders(customerId,orderId,orderStatus);
                    ordersList.Add(Orders);
                }
            }
            conn.Close();
            return ordersList;
        }

        public void ChangeStatus(int OrderId){
            conn.Open();
            string _Query = "UPDATE orders SET OrderStatus='1' WHERE OrderId = "+OrderId+"";
            MySqlCommand cmd = new MySqlCommand( _Query,conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            conn.Close();
        }

        public List<orders> GetOrderPending(){
            conn.Open();
            string _Query ="SELECT * FROM orders WHERE OrderStatus = 0";
            MySqlCommand cmd = new MySqlCommand( _Query,conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            List<orders> ordersList = new List<orders>();
            if(dr.HasRows){
                while(dr.Read()){
                   int orderId =  dr.GetInt32("OrderId");
                   int orderStatus = dr.GetInt32("OrderStatus");
                   int customerId = dr.GetInt32("CustomerId");
                   orders Orders = new orders(customerId,orderId,orderStatus);
                   ordersList.Add(Orders);
                }
            }
            conn.Close();
            return ordersList;
        }

    }

}
// slec orderproduct --> 
