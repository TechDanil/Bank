using System;
using System.Collections.Generic;

namespace Bank
{
   public class UserActions 
    {

        static User user = new User();        

        public int money;

        public void AddBalance()
        {

            Console.WriteLine("Add that amount of money that you need\n");

            money = Convert.ToInt32(Console.ReadLine());

            user.addMoney += money;

            user.usersBalance.Add(user.addMoney);

            Console.WriteLine("Hello " + user.userName + " Now your balance is: " + user.usersBalance[user.usersBalance.Count - 1]);

        }

        public void LookAtBalance()
        {
            if (user.usersBalance == null)
                Console.WriteLine("There's no money yet");

            else if (user.usersBalance.Equals(0))
                Console.WriteLine("Your balance is empty");


            else
                Console.WriteLine("Hello " + user.userName + " Your current balance is: " + user.usersBalance[user.usersBalance.Count - 1]);

        }

        public void WithdrawMoney()
        {

            Console.WriteLine("How much would you like to withdraw?\n");

            int draw = Convert.ToInt32(Console.ReadLine());

            if (draw == null)
            {
                Console.WriteLine("You don't have any money to withdraw yet");

            }

            else
            {
                if (draw > user.addMoney)

                    Console.WriteLine("You cannot withdraw more than you've got");

                else if (draw <= 0)

                    Console.WriteLine("Please enter an amount greater than 0");

                else
                {
                    draw = user.addMoney - draw;

                    user.usersBalance.Add(draw);

                    Console.WriteLine("Hello, " + user.userName + " Now you balance is:  " + user.usersBalance[user.usersBalance.Count - 1]);
                }
            }
        }

        public bool SignOutOfSystem()
        {

            Console.WriteLine("Do you want to sign out of System? Type y/n");

            user.choose = Convert.ToString(Console.ReadLine());

            user.isNumeric = int.TryParse(user.choose, out user.number);

            if (!user.isNumeric)
            {
                if (user.choose.ToLower() == "y")
                {
                    return true;

                }
            }

            else
            {
                Console.WriteLine("you cannot use digits!");

                this.SignOutOfSystem();
            }

            if (String.IsNullOrEmpty(user.choose))
            {
                Console.WriteLine("You cannot leave it empty");
            }

            else
            {
                user.UsersMenu();

                user.UsersAction();
            }

            return false;
        }




    }
}
