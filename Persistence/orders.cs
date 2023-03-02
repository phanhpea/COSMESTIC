using System;
namespace Persistence;
public class orders{
    int CustomerId= 0;
    public int customerId
    {
        get
        {
            {return CustomerId;}
        }
        set
        {
            {CustomerId = value;}
        }
    }

    int OrderId =0;
    public int orderId
    {
        get
        {
            {return OrderId;}
        }
        set
        {
            {OrderId =value;}
        }
    }
    int OrderStatus =0;
    public int orderStatus 
    {
        get
        {
            {return OrderStatus;}
        }
        set
        {
            {OrderStatus = value;}
        }
    }
    

    public orders(int CustomerId,int OrderId, int OrderStatus){
        this.CustomerId = CustomerId;
        this.OrderId  = OrderId;
        this.OrderStatus = OrderStatus;
    }
}