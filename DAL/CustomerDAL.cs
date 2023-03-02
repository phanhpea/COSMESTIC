using System.Runtime.InteropServices.ComTypes;
using System.Data;
using System;
using Persistence;
using MySql.Data.MySqlClient;
namespace DAL{

  public class CustomerDAL{
        
    public static MySqlConnection conn = DBMySQLUtils.GetDBConnection();

        
    public bool Login(string Username, string passWord){
          
      conn.Open();

      string _Query = "SELECT * FROM user WHERE UserName='"+Username+"'AND Password='"+ passWord+"'";  
      MySqlCommand cmd = new MySqlCommand( _Query,conn);
      MySqlDataReader dr = cmd.ExecuteReader();

      if(dr.Read()){
            conn.Close();
            return true;    
        }
      else{
          Console.WriteLine("Your Password or Username is wrong!");
          conn.Close();
          return false;
            }           
    }
    public bool CheckRole(string username){
      conn.Open();
      string _Query = "SELECT* FROM user WHERE UserName = '"+username+"'";
      MySqlCommand cmd = new MySqlCommand( _Query,conn);
      MySqlDataReader dr = cmd.ExecuteReader();
      dr.Read();
        string check = dr.GetString("role");
      if(check == "Admin")
      {
        conn.Close();
        return true;
      }
      else{
        conn.Close();
        return false;
      }
    }
    public void Register(string fullname,string age,string phone,string username,string password){
      conn.Open();
      string _Query = "INSERT INTO user(FullName, DateOfBirth, CustomerNumber, UserName, PassWord, Role) VALUES ('"+fullname+"','"+age+"',"+phone+",'"+username+"','"+password+"','Customer')";
      MySqlCommand cmd = new MySqlCommand( _Query,conn);
      MySqlDataReader dr = cmd.ExecuteReader();
      conn.Close();
    }
    public bool UserExist(string username){
      conn.Open();
      string _Query = "SELECT* FROM user WHERE UserName = '"+username+"'"; 
      MySqlCommand cmd = new MySqlCommand( _Query,conn);
      MySqlDataReader dr = cmd.ExecuteReader();
      if(dr.Read())
      {
        Console.WriteLine("UserName is exist!");
        conn.Close();
        return true;
      }
      else
      { 
        conn.Close();
        return false;
      }
    }
    public int GetId(string UserName){
      conn.Open();
      string _Query = "SELECT * FROM user WHERE UserName = '"+UserName+"'";
      MySqlCommand cmd = new MySqlCommand( _Query,conn);
      MySqlDataReader dr = cmd.ExecuteReader();
      int IdUser=0 ; 
      if(dr.Read()){
        IdUser  = dr.GetInt32("CustomerId");
      }
      conn.Close();
      return IdUser;
    }

    public User GetCustomerById( int idcustomer){
      conn.Open();
      string _Query = "SELECT* FROM product WHERE CustomerId = '"+idcustomer+"'"; 
      MySqlCommand cmd = new MySqlCommand( _Query,conn);
      MySqlDataReader dr = cmd.ExecuteReader();
      if(dr.Read()){
        int id_customer = dr.GetInt32("CustomerId");
        string customer_name = dr.GetString("Fullname");
        string customer_phone = dr.GetString("CustomerNumber");
        string customer_age = dr.GetString("DateOfBirth");
        string Customer_user = dr.GetString("UserName");
        string Customer_password = dr.GetString("PassWord");
        User user = new User(id_customer,Customer_user,customer_age,customer_phone,customer_name,Customer_password);
        conn.Close();
        return user;
            }
      else{
        conn.Close();
        return null;
          }
        }

    public List <User> GetAllCusTomer(){
      conn.Open();
      string _Query = "SELECT * FROM user WHERE Role = 'Customer'";
      List<User> UserList = new List<User>();
      MySqlCommand cmd = new MySqlCommand( _Query,conn);
      MySqlDataReader dr = cmd.ExecuteReader();
      while(dr.Read()){
        string user_fullname = dr.GetString("FullName");
        DateTime dob = new DateTime();
        dob = dr.GetDateTime("DateOfBirth");
        string birth = dob.ToShortDateString();
        string user_phone = dr.GetString("CustomerNumber");
        string user_name = dr.GetString("UserName");
        int user_id = dr.GetInt32("CustomerId");
        string user_password = dr.GetString("PassWord");
        User user = new User(user_id,user_name,birth,user_phone,user_fullname, user_password);
        UserList.Add(user);      
                }    
        conn.Close(); 
        return UserList;
        }

    public void DropCustomer(int customerID){
      conn.Open();
      string _Query ="DELETE FROM user WHERE CustomerId =  '"+customerID+"'" ;
      MySqlCommand cmd = new MySqlCommand( _Query,conn);
      MySqlDataReader dr = cmd.ExecuteReader();
      conn.Close();
    }

    public void UpdateCustomer(int idcustomer,string age, string customerfullname,string phone,string username,string password){
      conn.Open();
      string _Query = "UPDATE user SET FullName='"+customerfullname+"', CustomerNumber='"+phone+"', UserName='"+username+"',PassWord='"+password+"',DateOfBirth ='"+age+"' WHERE CustomerId = "+idcustomer+"";
      MySqlCommand cmd = new MySqlCommand( _Query,conn);
      MySqlDataReader dr = cmd.ExecuteReader();
      conn.Close();
        }
    }
}


