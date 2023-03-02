using System.Data;
using System.Net;
using System;
using System.Data;
using System.Collections;
using Persistence;
using MySql.Data.MySqlClient;
namespace DAL{
    public class ProductDAL{

        public static MySqlConnection conn = DBMySQLUtils.GetDBConnection();
        public List<Product> GetProductByName(string nameproduct){
            conn.Open();
            string _Query = "SELECT * FROM product WHERE ProductName='"+nameproduct+"' or ProductName like '%"+nameproduct+"%' AND ProductAmount > 0" ;  
            MySqlCommand cmd = new MySqlCommand( _Query,conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            List<Product> ProductList = new List<Product>();
                if(dr.HasRows){
                    while(dr.Read()){
                    string product_name = dr.GetString("ProductName");
                    int product_price = dr.GetInt32("ProductPrice");
                    int product_amount = dr.GetInt32("ProductAmount");
                    string product_brand = dr.GetString("ProductBrand");
                    int product_id = dr.GetInt32("ProductId");
                    Product product = new Product(product_price,product_id,product_amount,product_brand,product_name);
                    ProductList.Add(product);
        }   
                    conn.Close();

                    return ProductList;    

        }
                else{
                    conn.Close();
                    return null;
        }           
        }
        public List<Product> GetProductByBrand(string namebrand){
            conn.Open();
            string _Query = "SELECT * FROM product WHERE ProductBrand ='"+namebrand+"' or ProductBrand like '%"+namebrand+"%' AND ProductAmount > 0";
            MySqlCommand cmd = new MySqlCommand( _Query,conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            List<Product> ProductList = new List<Product>();
            if(dr.HasRows){
                while(dr.Read()){
                string product_name = dr.GetString("ProductName");
                int product_price = dr.GetInt32("ProductPrice");
                int product_amount = dr.GetInt32("ProductAmount");
                string product_brand = dr.GetString("ProductBrand");
                int product_id = dr.GetInt32("ProductId");
                Product product = new Product(product_price,product_id,product_amount,product_brand,product_name);
                ProductList.Add(product);              
                }
                conn.Close();
                return ProductList;
            }
            else{
                conn.Close();
                return null;
            }
        }
        public List <Product> GetAllProduct(){
            conn.Open();
            string _Query = "SELECT * FROM product where Display = 1 AND ProductAmount > 0";
            List<Product> ProductList = new List<Product>();
            MySqlCommand cmd = new MySqlCommand( _Query,conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read()){
                string product_name = dr.GetString("ProductName");
                int product_price = dr.GetInt32("ProductPrice");
                int product_amount = dr.GetInt32("ProductAmount");
                string product_brand = dr.GetString("ProductBrand");
                int product_id = dr.GetInt32("ProductId");
                Product product = new Product(product_price,product_id,product_amount,product_brand,product_name);
                ProductList.Add(product);        
                }    
            conn.Close(); 
            return ProductList;
        }
        public Product GetProductById( int idproduct){
            conn.Open();
            string _Query = "SELECT* FROM product WHERE ProductId = '"+idproduct+"' AND ProductAmount > 0"; 
            MySqlCommand cmd = new MySqlCommand( _Query,conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read()){
                string product_name = dr.GetString("ProductName");
                int product_price = dr.GetInt32("ProductPrice");
                int product_amount = dr.GetInt32("ProductAmount");
                string product_brand = dr.GetString("ProductBrand");
                int product_id = dr.GetInt32("ProductId");
                Product product = new Product(product_price,product_id,product_amount,product_brand,product_name);
                conn.Close();
                return product;
            }
            else{
                conn.Close();
                return null;
            }
        }

        public void AddProduct(string productName,int productAmount,int productPrice,string productBrand){
            conn.Open();
            string _Query = "INSERT INTO product(ProductName, ProductAmount, ProductPrice, ProductBrand,Display) VALUES ('"+productName+"',"+productAmount+","+productPrice+",'"+productBrand+"',1)";
            MySqlCommand cmd = new MySqlCommand( _Query,conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            conn.Close();
        }

        public void DisplayProduct(int productID){
            conn.Open();
            string _Query ="UPDATE Product SET Display =0 WHERE ProductId =  '"+productID+"'" ;
            MySqlCommand cmd = new MySqlCommand( _Query,conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            conn.Close();

        }

        public void UpdateProduct(int idproduct, string productname,int productamount,int productprice,string productbrand){
            conn.Open();
            string _Query = "UPDATE product SET ProductName='"+productname+"', ProductAmount="+productamount+", ProductPrice="+productprice+",ProductBrand='"+productbrand+"' WHERE ProductId = "+idproduct+"";
            MySqlCommand cmd = new MySqlCommand( _Query,conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            conn.Close();

        }

        
    }
}
        
    
    
    
