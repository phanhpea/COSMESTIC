using System;
namespace Persistence{
public class User{

    public int UserId=0;
    public string UserName ="";
    public string UserAge="";
    public string UserPhone="";
    public string UserFullName="";
    public string UserPassWord="";

public User(int UserId,string UserName,string UserAge,string UserPhone,string UserFullName, string UserPassWord) {
    this.UserId = UserId;
    this.UserName = UserName;
    this.UserAge = UserAge;
    this.UserFullName = UserFullName;
    this.UserPhone = UserPhone;
    this.UserPassWord = UserPassWord;
}
}
}