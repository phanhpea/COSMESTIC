using System.Text;
using System.Text.RegularExpressions;
using ConsoleTables;
using System;
using BL;
using Persistence;
using Spectre.Console;
namespace ConsolePL 
{ 
    class Program
    {
        public static string Username = "";
        public const string motif1 = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
        public const string motif2 = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$";
        public const string motif3 = @"^\d{4}\-(0?[1-9]|1[012])\-(0?[1-9]|[12][0-9]|3[01])$";


        public static string line = "==============================";
        public static string bline ="=====================================================";
        public static string [] adminMenu = {"PRODUCT MANAGEMENT","VIEW CUSTOMER","CHECK ORDERS", "LOG OUT"};
        public static string [] customerMenu = {"SEARCH PRODUCT BY NAME", "SEARCH PRODUCT BY BRAND","ORDER","SETTING ACCOUNT","LOG OUT"};
        public static UserBL CusPL = new UserBL();
        public static ProductBL ProductBL = new ProductBL();
        public static OrderBL orderBL = new OrderBL();


        public static void Main(string[] args)
        {   
            //ChangeText();
            homepage();
        }
        public static void homepage(){
            string Title = @"
██╗    ██╗███████╗██╗      ██████╗ ██████╗ ███╗   ███╗███████╗    ████████╗ ██████╗ 
██║    ██║██╔════╝██║     ██╔════╝██╔═══██╗████╗ ████║██╔════╝    ╚══██╔══╝██╔═══██╗
██║ █╗ ██║█████╗  ██║     ██║     ██║   ██║██╔████╔██║█████╗         ██║   ██║   ██║
██║███╗██║██╔══╝  ██║     ██║     ██║   ██║██║╚██╔╝██║██╔══╝         ██║   ██║   ██║
╚███╔███╔╝███████╗███████╗╚██████╗╚██████╔╝██║ ╚═╝ ██║███████╗       ██║   ╚██████╔╝
 ╚══╝╚══╝ ╚══════╝╚══════╝ ╚═════╝ ╚═════╝ ╚═╝     ╚═╝╚══════╝       ╚═╝    ╚═════╝ 
                                                                                    
";
            string Title1 = @"
██████╗ ███████╗ █████╗      ██████╗ ██████╗ ███████╗███╗   ███╗███████╗███████╗████████╗██╗ ██████╗
██╔══██╗██╔════╝██╔══██╗    ██╔════╝██╔═══██╗██╔════╝████╗ ████║██╔════╝██╔════╝╚══██╔══╝██║██╔════╝
██████╔╝█████╗  ███████║    ██║     ██║   ██║███████╗██╔████╔██║█████╗  ███████╗   ██║   ██║██║     
██╔═══╝ ██╔══╝  ██╔══██║    ██║     ██║   ██║╚════██║██║╚██╔╝██║██╔══╝  ╚════██║   ██║   ██║██║     
██║     ███████╗██║  ██║    ╚██████╗╚██████╔╝███████║██║ ╚═╝ ██║███████╗███████║   ██║   ██║╚██████╗
╚═╝     ╚══════╝╚═╝  ╚═╝     ╚═════╝ ╚═════╝ ╚══════╝╚═╝     ╚═╝╚══════╝╚══════╝   ╚═╝   ╚═╝ ╚═════╝
                                                                                                    
";
            Console.WriteLine(Title);
            Console.WriteLine(Title1);
            var image = new CanvasImage("Pound_layer_cake.jpg");
            image.MaxWidth(30);
            AnsiConsole.Write(image);
            string[] menu = {"REGISTER", "LOGIN",};
            short MainHomePage =0;
            MainHomePage=Menu("HomePage", menu);
       
            switch(MainHomePage){

            case 1: 
                Register();
                homepage();
                break;
                
            case 2: 
                Login();  
                break;
            
            default: Console.WriteLine("ERROR!");
                homepage();
                break;
            }
        }

        public static void Login(){
            bool a;
            string UserName;
            string PassWord ="";
            do{ 
            Console.WriteLine("ENTER YOUR USERNAME: ");
            UserName = Console.ReadLine();
            Console.WriteLine("ENTER YOUR PASSWORD:");
            PassWord = GetPassword();
            }
            while (!CusPL.LoginBL(UserName,PassWord));
            Username = UserName;
            bool check;
            check = CusPL.CheckRole(UserName);
            if(check)
            {
            string admin  = @"
            ██╗    ██╗███████╗██╗      ██████╗ ██████╗ ███╗   ███╗███████╗
            ██║    ██║██╔════╝██║     ██╔════╝██╔═══██╗████╗ ████║██╔════╝
            ██║ █╗ ██║█████╗  ██║     ██║     ██║   ██║██╔████╔██║█████╗  
            ██║███╗██║██╔══╝  ██║     ██║     ██║   ██║██║╚██╔╝██║██╔══╝  
            ╚███╔███╔╝███████╗███████╗╚██████╗╚██████╔╝██║ ╚═╝ ██║███████╗
            ╚══╝╚══╝ ╚══════╝╚══════╝ ╚═════╝ ╚═════╝ ╚═╝     ╚═╝╚══════╝
                                                                    
            ";      
            string admin1 = @"
            ███████╗███████╗██╗     ██╗     ███████╗██████╗ 
            ██╔════╝██╔════╝██║     ██║     ██╔════╝██╔══██╗
            ███████╗█████╗  ██║     ██║     █████╗  ██████╔╝
            ╚════██║██╔══╝  ██║     ██║     ██╔══╝  ██╔══██╗
            ███████║███████╗███████╗███████╗███████╗██║  ██║
            ╚══════╝╚══════╝╚══════╝╚══════╝╚══════╝╚═╝  ╚═╝
                                                    
            ";
            Console.WriteLine(admin);
            Console.WriteLine(admin1);
            AdminMenu();
            } else
            {
            string customer = @"
            ██╗    ██╗███████╗██╗      ██████╗ ██████╗ ███╗   ███╗███████╗
            ██║    ██║██╔════╝██║     ██╔════╝██╔═══██╗████╗ ████║██╔════╝
            ██║ █╗ ██║█████╗  ██║     ██║     ██║   ██║██╔████╔██║█████╗  
            ██║███╗██║██╔══╝  ██║     ██║     ██║   ██║██║╚██╔╝██║██╔══╝  
            ╚███╔███╔╝███████╗███████╗╚██████╗╚██████╔╝██║ ╚═╝ ██║███████╗
            ╚══╝╚══╝ ╚══════╝╚══════╝ ╚═════╝ ╚═════╝ ╚═╝     ╚═╝╚══════╝
                                                                    
            ";
            string customer1 = @"
            ██████╗██╗   ██╗███████╗████████╗ ██████╗ ███╗   ███╗███████╗██████╗ 
            ██╔════╝██║   ██║██╔════╝╚══██╔══╝██╔═══██╗████╗ ████║██╔════╝██╔══██╗
            ██║     ██║   ██║███████╗   ██║   ██║   ██║██╔████╔██║█████╗  ██████╔╝
            ██║     ██║   ██║╚════██║   ██║   ██║   ██║██║╚██╔╝██║██╔══╝  ██╔══██╗
            ╚██████╗╚██████╔╝███████║   ██║   ╚██████╔╝██║ ╚═╝ ██║███████╗██║  ██║
            ╚═════╝ ╚═════╝ ╚══════╝   ╚═╝    ╚═════╝ ╚═╝     ╚═╝╚══════╝╚═╝  ╚═╝
                                                                            
            ";
            Console.WriteLine(customer);
            Console.WriteLine(customer1);
            CustomerMenu();
            } 
        }

        public static void Register(){
            string number = "";
            string fullname;
            string username="";
            string password = "";
            string age ="";
            Console.WriteLine("ENTER YOUR FULL NAME: ");
            fullname = Console.ReadLine(); 
            do{
            Console.WriteLine("ENTER YOUR DATE OF BIRTH: ");
            Console.WriteLine("THE DATE OF BIRTH WILL BE IN THE FORMAR yyyy-mm-dd");
            age = Console.ReadLine();
            }
            while(CheckTime(age)==false);
            do{
            Console.WriteLine("ENTER YOUR PHONE NUMBER: ");
            number = Console.ReadLine();
            }
            while(ChekPhone(number)== false);

            do{
            Console.WriteLine("ENTER YOUR USERNAME : ");
            username = Console.ReadLine();
            
            }while(CusPL.CheckUser(username));

            do{
            Console.WriteLine("ENTER YOUR PASSWORD: ");
            password = GetPassword();
            }while(CheckPass(password)== false);
            // Console.WriteLine(password);
            CusPL.Register(fullname, age, number, username, password  );
            Console.WriteLine("CREATE ACCOUNT SUCCESS !");
        }       

        public static string GetPassword(){
            StringBuilder pass = new StringBuilder();
            while (true)
            {
                int x = Console.CursorLeft;
                int y = Console.CursorTop;
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    pass.Remove(pass.Length - 1, 1);
                    Console.SetCursorPosition(x - 1, y);
                    Console.Write(" ");
                    Console.SetCursorPosition(x - 1, y);
                }
                else if (key.Key != ConsoleKey.Backspace)
                {
                    pass.Append(key.KeyChar);
                    Console.Write("*");
                }
            }
            return pass.ToString();
        }

        public static bool ChekPhone(string number){
    
            if (number != null){
                if(Regex.IsMatch(number, motif1)==true ){
                    // Console.WriteLine("PhoneNumber is Wrong");
                    return true;
                }
                else{
                    Console.WriteLine("PHONE NUMBER IS WRONG");
                    return false;
                }
            }
            else return false;
        }

        public static bool CheckTime (string time){
            if(time != null){
                if(Regex.IsMatch(time, motif3)== true){
                    return true;
                }
                else{
                    Console.WriteLine("DATE OF BIRTH IS WRONG");
                    return false;
                }
            }
            else return false;
        }

        public static bool CheckPass(string pass){
            if (pass != null){
            if(Regex.IsMatch(pass, motif2)== true){
                return true;
            }
            else{
                Console.WriteLine("MINIUM EIGHT CHATACTERS, AT LEAST ONE LETTER AND ONE NUMBER:");
                return false;
            }
            }
            else return false;
        }

        public static List<User> GetAllCusTomer(){
            Console.WriteLine("SHOW CUSTOMER INFORMATION");
            List<User> user;
            user = CusPL.GetAllCusTomer();
            // var table = new ConsoleTable("CustomerId","FullName","Phone Number","Date Of Birth");
            var table = new Table();
            table.AddColumns("CustomerId","FullName","Phone Number","Date Of Birth");
            table.BorderColor(Color.DarkGreen);

            foreach(var item in user){
                table.AddRow(item.UserId.ToString(),item.UserFullName,item.UserPhone,item.UserAge);
            }
            AnsiConsole.Write(table);
            return user;        
        }

        private static short Menu(string Title, string [] Menuitems){
            string logo = "Mo hinh 3 lop";
            short choose = 0;
            string line ="==================================";
            Console.WriteLine(line);
            Console.WriteLine(line);
            for(int i = 0;i < Menuitems.Length; i ++)
        {
                Console.WriteLine(""+(i+1)+"."+Menuitems[i]);
        }
            Console.WriteLine(line);
            do{
                Console.WriteLine("YOUR CHOICE");
            try{
                choose = Int16.Parse(Console.ReadLine());
            } catch{
                Console.WriteLine("YOUR CHOICE IS WRONG !");
            }
            }   while(choose <= 0 || choose > Menuitems.Length);
            return choose;
        }
        
        public static void AdminMenu(){
            short mainchoose = 0;
            mainchoose = Menu("Choice of Admin",adminMenu);
            switch(mainchoose){
                case 1:
                    ProductManagement();
                    AdminMenu();
                    break;
                
                case 2:
                    GetAllCusTomer();
                    AdminMenu();
                    break;

                case 3: 
                    CheckOrder();
                    AdminMenu();
                    break;

                
                case 4:
                    homepage();
                    break;
                
                default: 
                    Console.WriteLine("ERROR!");
                    AdminMenu();
                    break;
            }
        }

        public static List<Product> GetAllProduct(){
            List<Product> ProductList = new List<Product>();
            ProductList = ProductBL.GetAllProduct();
            // var table = new ConsoleTable("Product Id","Product Name","Product Price","Product Amount","Product Brand");
            var table = new Table();
            table.AddColumns("Product Id","Product Name","Product Price","Product Amount","Product Brand");
            table.BorderColor(Color.DarkGreen);
            foreach (var item in ProductList)
            {   
                if(item.ProductAmount >0){
                table.AddRow(item.ProductId.ToString(),item.ProductName,item.ProductPrice.ToString("#,##0")+" VND",item.ProductAmount.ToString(),item.productBrand );
                }
            }
      
            AnsiConsole.Write(table);
            return ProductList;
    }

        public static void AddProduct(){
            int amount;
            Console.WriteLine("ENTER NAME OF PRODUCT");
            string name = Console.ReadLine();
            do{
            Console.WriteLine("ENTER AMOUNT OF PRODUCT");
            amount = Convert.ToInt32(Console.ReadLine());
            }
            while(amount < 1);
            Console.WriteLine("ENTER PRICE OF PRODUCT");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("ENTER BRAND OF PRODUCT:");
            string brand = Console.ReadLine();
            ProductBL.AddProduct(name,amount,price,brand);
            Console.WriteLine("SUCCESSFULLY ADDED NEW PRODUCT");
            GetAllProduct();
        }

        public static void DisplayProduct(){
            GetAllProduct();
            Console.WriteLine("ENTER PRODUCTID YOU WANT TO DISPLAY:");
            int dropId = Convert.ToInt32(Console.ReadLine());
            ProductBL.DropProduct(dropId);
            Console.WriteLine("DISPLAY PRODUCT SUCCESS");
        }

        public static void UpdateProduct(){
            GetAllProduct();
            Console.WriteLine("ENTER ID OF PRODUCT YOU WANT TO UPDATE");
            int idUpdate = Convert.ToInt32(Console.ReadLine());
            Product product;
            product = ProductBL.GetProductById(idUpdate);
            Console.WriteLine("ProductName:"+product.ProductName);
            Console.WriteLine("ProductAmount:"+product.ProductAmount);
            Console.WriteLine("ProductPrice:"+product.ProductPrice);
            Console.WriteLine("ProductBrand:"+product.ProductBrand);
            Console.WriteLine("ENTER NEW NAME OF PRODUCT:");
            string NewName = Console.ReadLine();
            Console.WriteLine("ENTER NEW AMOUNT OF PRODUCT:");
            int NewAmount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("ENTER NEW PRICE OF PRODUCT: ");
            int NewPrice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("ENTER NEW BRAND OF PRODUCT: ");
            string NewBrand = Console.ReadLine();
            ProductBL.UpdateProduct(idUpdate, NewName,NewAmount,NewPrice,NewBrand);
            Console.WriteLine("SUCCESSFULLY CHANGED INFORMATION!");
        }

        // public static void ViewCustomerInformation(){
        //     CusPL.GetAllCusTomer();
        // }

        public static void ProductManagement(){
            string [] productManagement = {"Add Product", "Display Product","Update Product","Exit"};
            short menu = 0;
            menu = Menu("ProductMenu",productManagement);
            switch(menu){
                case 1: 
                    AddProduct();
                    ProductManagement();
                    break;

                case 2: 
                    DisplayProduct();
                    ProductManagement();
                    break;
                
                case 3: 
                    UpdateProduct();
                    ProductManagement();
                    break;
                
                case 4: 
                    AdminMenu();
                    break;
                
                default: 
                    Console.WriteLine("ERROR!");
                    ProductManagement();
                    break;
            }
        }

       public static void ViewAllOrder(){
             int idUser = CusPL.GetId(Username);
            List<orders> ordersList = new List<orders>();
            ordersList =orderBL.GetListAllOrder();
            if(ordersList.Count==0){
                Console.WriteLine("YOUR STORE DOES NOT HAVE ANY ORDERS YET!");
           }else{
    
                // var table = new ConsoleTable("OrderId","ProductId","CustomerID","ProductName","TotalPrice","OrderStatus");
                var table = new Table();
                table.AddColumns("OrderId","ProductId","CustomerID","ProductName","TotalPrice","OrderStatus");

                table.BorderColor(Color.DarkGreen);
                foreach(var item in ordersList)
                {
                    List<OrderProduct> orderProducts = new List<OrderProduct>();
                    orderProducts = orderBL.GetListOrderProducts(item.orderId);
                    string getStatus ="";
                    if(item.orderStatus ==0){
                        getStatus = "Order is Pending";
                    }
                    else if(item.orderStatus== 1){
                        getStatus ="Order is Delivery";
                    }
                    else if(item.orderStatus== 2){
                        getStatus = "Order is Received";
                    }
                    
                    foreach(var abc in orderProducts)
                    {   
                        Product product;
                        product = ProductBL.GetProductById(abc.ProductId);
                        table.AddRow(abc.OrderId.ToString(),abc.ProductId.ToString(),item.customerId.ToString(),product.ProductName,abc.TotalPrice.ToString("#,##0")+" VND",getStatus);

                    }
                     
                }
                AnsiConsole.Write(table);
           }
        }

        public static void ShowOrderPending(){
            Console.WriteLine("SHOW ORDER IS PENDING");
             int idUser = CusPL.GetId(Username);
            List<orders> ordersList = new List<orders>();
            ordersList =orderBL.GetOrderPending();
            if(ordersList.Count== 0){
                Console.WriteLine("YOUR STORE DOES NOT HAVE ANY ORDER IS PENDING !");
           }else{
                //var table = new ConsoleTable("OrderId","ProductId","CustomerID","ProductName","TotalPrice","OrderStatus");
                var table = new Table();
                table.AddColumns("OrderId","ProductId","CustomerID","ProductName","TotalPrice","OrderStatus");
                table.BorderColor(Color.DarkGreen);
                foreach(var item in ordersList)
                {
                    List<OrderProduct> orderProducts = new List<OrderProduct>();
                    orderProducts = orderBL.GetListOrderProducts(item.orderId);
                    foreach(var abc in orderProducts)
                    {   
                        string statusOrder ="ORDER IS PENDING";
                        Product product;
                        product = ProductBL.GetProductById(abc.ProductId);
                        table.AddRow(abc.OrderId.ToString(),abc.ProductId.ToString(),item.customerId.ToString(),product.ProductName,abc.TotalPrice.ToString("#,##0")+" VND",statusOrder);
                       


                    }
                }
                 AnsiConsole.Write(table);
           }
         }

        public static void ConfirmOrder(){
            ShowOrderPending();
            Console.WriteLine("ENTER THE ID ORDER OF THE ORDER YOU HAVE GIVEN TO THE SHIPPER");
            int ConfirmOrder = Convert.ToInt32(Console.ReadLine());
            orderBL.ChangeStatus(ConfirmOrder);
            Console.WriteLine("CONFIRMED ORDER SUCCESSFUL");

        }

        public static void CheckOrder(){
            string [] checkorder = {"VIEW ALL ORDER", "CONFIRM ORDER", "EXIT"};
            short menu = 0;
            menu = Menu("CheckOrder",checkorder);
            switch(menu){
                case 1: 
                    ViewAllOrder();
                    CheckOrder();
                      break;

                case 2: 
                    ConfirmOrder();
                    CheckOrder();
                    break;

                
                case 3: 
                    AdminMenu();
                    break;
                
                default: 
                    Console.WriteLine("ERROR!");
                    CheckOrder();
                    break;
            
            }
        }



        public static void CustomerMenu(){
            short mainchoose = 0;
            mainchoose = Menu("Choice of Customer", customerMenu);
            switch(mainchoose){
                case 1: 
                    GetProductByName();
                    CustomerMenu();
                    break;

                case 2:
                    GetProductByBrand();
                    CustomerMenu();
                    break;

                case 3:
                    Order();
                    CustomerMenu();
                    break;
                
                case 4:
                    UpdateInfor();
                    CustomerMenu();
                    break;
                
                case 5:
                    homepage();
                    break;
                
                default: break;
            }
        }

        public static void GetProductByName(){
           string product_name;
           Console.WriteLine("ENTER NAME OF PRODUCT:");
           product_name = Console.ReadLine();
            List<Product> ProductList = new List<Product>();
            ProductList = ProductBL.GetProductByName(product_name);
           if(ProductList != null){
                //  var table = new ConsoleTable("Product Id","Product Name","Product Price","Product Amount","Product Brand");
                var table = new Table();
                table.AddColumns("Product Id","Product Name","Product Price","Product Amount","Product Brand");
                table.BorderColor(Color.DarkGreen);

                foreach(var item in ProductList)
                {
                    table.AddRow(item.ProductId.ToString(),item.ProductName,item.ProductPrice.ToString("#,##0")+" VND",item.ProductAmount.ToString(),item.productBrand );
                }
                AnsiConsole.Write(table);
           }else{
                Console.WriteLine("THERE ARE NO PRODUCT YOU ARE LOOKING FOR!");
           }

    }
        
        public static void GetProductByBrand(){
            string product_brand;
            Console.WriteLine("ENTER NAME OF BRAND");
            product_brand = Console.ReadLine();
            List<Product> ProductList = new List<Product>();
            ProductList = ProductBL.GetProductByBrand(product_brand);
            if(ProductList== null){
             
                Console.WriteLine("THERE ARE NO BRAND YOU ARE LOOKING FOR!");
           }else{
                //   var table = new ConsoleTable("Product Id","Product Name","Product Price","Product Amount","Product Brand");
                var table = new Table();
                table.AddColumns("Product Id","Product Name","Product Price","Product Amount","Product Brand");
                table.BorderColor(Color.DarkGreen);
                foreach(var item in ProductList)
                {
                    table.AddRow(item.ProductId.ToString(),item.ProductName,item.ProductPrice.ToString("#,##0")+" VND",item.ProductAmount.ToString(),item.productBrand );
                }
                AnsiConsole.Write(table);
           }
    }
                    
        public static void CreateOrder(){
            
                int idUser = CusPL.GetId(Username);
                int a= orderBL.GetOrderId();
                orderBL.AddOrder(idUser,a);
                // orderBL.order(idUser,productId,quantity);
                checkOrder(a);
        }  
        

        public static void checkOrder(int OrderId){
            int Quantity =0;
            int ProductId=0;
            int Choose =0;
            GetAllProduct();
            Product product = new Product();
            do{
                Console.WriteLine("ENTER PRODUCT ID YOU WANT TO BUY:");
                try{
                ProductId = Int16.Parse(Console.ReadLine());
                product =  ProductBL.GetProductById(ProductId);
                } catch{
                Console.WriteLine("ID ERROR !");
                }    
            }
            while(product==null);

            Console.WriteLine("ENTER AMOUNT OF PRODUCT YOU WANT TO BUY ");
            Quantity = Int16.Parse(Console.ReadLine());
            if( Quantity > product.ProductAmount || Quantity <= 0){
                Console.WriteLine("ERROR QUANTITY!");
                checkOrder(ProductId);
            }
            else
            {
                int Total= product.ProductPrice* Quantity;
                orderBL.addOrderProduct(ProductId,Quantity, OrderId,Total);
                int amount = product.ProductAmount;
                orderBL.ReamainingAmount(amount,Quantity,ProductId);
                string name = product.productName;
                Console.WriteLine("YOU BUY {0} SUCCESSFULLY",name);
                Console.WriteLine("ENTER 1 TO BUY MORE PRODUCT");
                Console.WriteLine("ENTER 0 TO END ORDER");
                Choose = Int16.Parse(Console.ReadLine());

                if(Choose ==1){
                    checkOrder(OrderId);
                }
                else{
                    Console.WriteLine("YOUR ORDER IS CREATE!");
                }   
            }
        }

        public static void MyOrder(){
            int idUser = CusPL.GetId(Username);
            List<orders> ordersList = new List<orders>();
            ordersList =orderBL.GetListOrderId(idUser);
            if(ordersList.Count==0){
                Console.WriteLine("YOU DON'T HAVE ANY ORDERS YET!");
           }else{
    
                // var table = new ConsoleTable("OrderId","ProductName","ProductId","TotalPrice","ProductBrand","OrderStatus");
                var table = new Table();
                table.AddColumns("OrderId","ProductName","ProductId","TotalPrice","ProductBrand","OrderStatus");
                table.BorderColor(Color.DarkGreen);
                foreach(var item in ordersList)
                {
                    List<OrderProduct> orderProducts = new List<OrderProduct>();
                    orderProducts = orderBL.GetListOrderProducts(item.orderId);
                    string getStatus ="";
                    // var table = new ConsoleTable("CustomerId","OrderId","OrderStatus");
                    if(item.orderStatus ==0){
                        getStatus = "Order is Pending";
                    }
                    else if(item.orderStatus== 1){
                        getStatus ="Order is Delivery";
                    }
                    else if(item.orderStatus== 2){
                        getStatus = "The customer has Received the order";
                    }
                    
                    foreach(var abc in orderProducts)
                    {   
                        Product product;
                        product = ProductBL.GetProductById(abc.ProductId);
                        table.AddRow(abc.OrderId.ToString(),product.ProductName,abc.ProductId.ToString(),abc.TotalPrice.ToString("#,##0")+" VND",product.productBrand,getStatus);

                    }
                     
                }
                AnsiConsole.Write(table);
           }
        }

        public static void Order(){
            string [] menuOrder = {"CREATE ORDER","MY ORDER", "EXIT"};
            short menu = 0;
            menu = Menu("menuOrder",menuOrder);
            switch(menu){
                case 1: 
                    CreateOrder();
                    Order();
                    break;
                case 2:
                    MyOrder();
                    Order();
                    break;
                case 3:
                    CustomerMenu();
                    break;
                default:
                    Console.WriteLine("Error!");
                    CustomerMenu();
                    break;
            }
        }
        
        public static void UpdateInfor(){
            Console.WriteLine("ENTER NEW FULLNAME");
            string newname = Console.ReadLine();
            string newphone ="";
            string newpass ="";
            string newage="";

            do{
            Console.WriteLine("ENTER NEW PHONENUMBER:");
            newphone = Console.ReadLine();}
            while(ChekPhone(newphone)==false);

            do{
            Console.WriteLine("ENTER NEW YOUR DATE OF BIRTH:");
            Console.WriteLine("THE DATE OF BIRTH WILL BE IN THE FORMAT YYYY-DD-MM");
            newage = Console.ReadLine();}
            while(CheckTime(newage)==false);
            Console.WriteLine("ENTER NEW USERNAME:");
            string newuser = Console.ReadLine();

            do{
            Console.WriteLine("ENTER NEW PASSWORD:");
            newpass = GetPassword();}
            while(CheckPass(newpass)==false);

            
            int idcustomer =  CusPL.GetId(Username);
            CusPL.UpdateCustomer(idcustomer,newage,newname,newphone,newuser,newpass);
            Console.WriteLine("UPADATE INFORMATION SUCCESS!");
        }
        public  static void ChangeText(){
            Console.WriteLine("",Console.ForegroundColor);
            Console.ForegroundColor = ConsoleColor.Magenta;
        } 
    }
}


//delete. use case actor, động từ usecase
// nhập sai thì cho nhập lại, k quay về main chính (order)
// thiet ke database
// file exe
// don vi tien te, dau cham, kieu du lieu tien
//customer --> order--> : create/ my order : ten sp/sl/gia tien/ trang thai don hang: select customerid trong order
// select orderid của customer trong orderdetail
// sller: see all order/ change status order