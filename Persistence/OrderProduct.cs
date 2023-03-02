using System;
namespace Persistence;
public class OrderProduct{
    public int ProductId= 0;
    public int Quantity =0;
    public int TotalPrice = 0;
    public int OrderId =0;

    public OrderProduct(int ProductId,int Quantity,int TotalPrice, int OrderId){
        this.OrderId = OrderId;
        this.ProductId = ProductId;
        this.Quantity = Quantity;
        this.TotalPrice = TotalPrice;
    }


}