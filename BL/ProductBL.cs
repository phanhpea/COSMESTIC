using System;
using Persistence;
using DAL;
using ConsoleTables;
namespace BL{
    public class ProductBL{
        List<Product> ProductList = new List<Product>();
        ProductDAL ProductDAL = new ProductDAL();
        public List<Product> GetProductByName(string productName){
           ProductList = ProductDAL.GetProductByName(productName);
           return ProductList;
        }   
        public List<Product> GetProductByBrand(string productBrand){
            ProductList = ProductDAL.GetProductByBrand(productBrand);
            return ProductList;
        }
        public List<Product> GetAllProduct(){
            ProductList = ProductDAL.GetAllProduct();    
            return ProductList;      
        }
        public void AddProduct(string Name,int Amount, int Price, string Brand){
            ProductDAL.AddProduct(Name,Amount,Price,Brand);
        }
        public void DropProduct(int idProduct){
            ProductDAL.DisplayProduct(idProduct);
        }
        public void UpdateProduct(int idUpdate,string NewName,int NewAmount,int NewPrice,string NewBrand){
            ProductDAL.UpdateProduct(idUpdate, NewName,NewAmount,NewPrice, NewBrand);
        }

        public Product GetProductById(int id){
            Product product = new Product();
            product = ProductDAL.GetProductById(id);
            return product;
        }
    }
}

