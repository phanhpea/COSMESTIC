using System;
namespace Persistence{
public class Product{
    public int ProductPrice=0;
    public int productPrice
{
        get
            { return ProductPrice; }
        set
            { ProductPrice= value; }
}
   

    public int ProductId=0;
    
    public int productId
{
        get
            { return ProductId; }
        set
            { ProductId= value; }
}

    public int ProductAmount = 0;
     public int productAmount
{
        get
            { return ProductAmount; }
        set
            { ProductAmount= value; }
}
    public string ProductBrand = "";
     public string productBrand
{
        get
            { return ProductBrand; }
        set
            { ProductBrand= value; }
}
    public string ProductName = "";
    public string productName
{
        get
            { return ProductName; }
        set
            { ProductName= value; }
}
    

    public Product(int ProductPrice, int ProductId,int ProductAmount, string ProductBrand, string ProductName){
        this.ProductPrice = ProductPrice;
        this.ProductId = ProductId;
        this.ProductAmount = ProductAmount;
        this.ProductBrand = ProductBrand;
        this.productName = ProductName;
}       
    public Product(){
    }


}
}