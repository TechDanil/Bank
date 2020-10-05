using System;
using System.Reflection.Metadata;

namespace Bank
{
    class Bank
    {
        static void Main(string[] args)
        {
            User user = new User();

            Admin admin = new Admin();

            Console.WriteLine("Choose what side you want to be: 1 - user, 2 - admin");

            int choose = Convert.ToInt32(Console.ReadLine());

            switch (choose)
            {
                case 1:

                    user.UserAccount();

                    break;

                case 2:

                   admin.AdminAccount();

                    break;
            }


        }
    }
}
