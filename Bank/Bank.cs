using System;

namespace Bank
{
    class Bank
    {
        static void Main(string[] args)
        {
            User user = new User();
            Admin admin = new Admin();
            Console.WriteLine("Choose what side you want to be");
            if(Console.ReadLine() == "user")
            user.UserAccount();
            else
            admin.AdminAccount();
        }
    }
}
