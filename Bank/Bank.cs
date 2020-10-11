using System;

namespace Bank
{
  public  class Bank
    {
        static User user = new User();

        static Admin admin = new Admin();


        static void Main(string[] args)
        {
           
            Start();
      
        }

        static void Start()
        {
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
