using System;
using DAL;
using Persistence;
using ConsoleTables;
namespace BL{
  public class UserBL{
  
    CustomerDAL customerBL =new CustomerDAL();
    string Username ="";
    public bool LoginBL(string PassWord,string UserName)
    {
      Username =UserName;
      return customerBL.Login(PassWord,Username);
    }
    public void Register(string fullname,string age,string number,string username,string password  ){
      customerBL.Register(fullname,age,number,username,password);
    }

    public bool CheckUser(String User){
      return customerBL.UserExist(User);
    }

    public bool CheckRole(string UserName){
      return customerBL.CheckRole(UserName);
    }
    public int GetId(string username){
      CustomerDAL getId = new CustomerDAL();
      int q = getId.GetId(username);     
      return q;
    }
    public string getUserName(){
      return this.Username;
    }

    public  List<User> GetAllCusTomer(){
      List<User> user;
      user = customerBL.GetAllCusTomer();
      return user;
    }
    public void UpdateCustomer(int idcustomer,string newage,string newname,string newphone,string newuser,string newpass){
      int idCustomer =  customerBL.GetId(Username);
      customerBL.UpdateCustomer(idCustomer,newage,newname,newphone,newuser,newpass);
    }
    public void DropCustomer(){
      int drop = customerBL.GetId(Username);
      customerBL.DropCustomer(drop);
    }
  }
}      


    
