using System;
using System.Collections.Generic;
using System.Linq;

namespace Bank
{
    class User : Bank
    {
        public Dictionary<string, string> userDataBase = new Dictionary<string, string>();
        public List<int> usersBalance = new List<int>();
        public List<int> currentBalance = new List<int>();
        public static bool agree = true;
        public Dictionary<string, string> constants = new Dictionary<string, string>
        {
            {"1", "look at balance" },
            {"2", "withdraw the balance" },
            {"3", "add money to your wallet" },
            {"4", "sign out of System" }
        };
        public int addMoney;
        public void UserAccount()
        {
            Console.WriteLine("Hello a new user!!\n");

            Console.WriteLine("Do you want to sign out of the program?\n");
            string userAnswer = Convert.ToString(Console.ReadLine());
            if (userAnswer == "y")
            {
                Console.WriteLine("Bye :(");
            }
            else
            {
                SignUpAccount();
                LogInAnAccount();
                Console.WriteLine("Press any key to clear the window");
                Console.ReadKey();
                Console.Clear();
                while (agree)
                {
                    UsersMenu();
                    UsersActions();
                    agree = ChooseAction();
                }
            }

        }


        public void SignUpAccount()
        {
            string userName;
            string password;
            Console.WriteLine("Create a new account");

            Console.WriteLine("Enter your username:\n ");


            userDataBase.Add("userName", userName = Convert.ToString(Console.ReadLine( )));

            Console.WriteLine("Enter your password:\n ");

            userDataBase.Add("password", password = Convert.ToString(Console.ReadLine()));

            Console.WriteLine("Congratualtions you created a new account! \n");



        }



        public bool ChooseAction()
        {
            Console.WriteLine("\nDo you want to choose another action?:\n ");
            string choose = Convert.ToString(Console.ReadLine());
            if (choose != "y")
            {
                return false;
            }
            return true;
        }

        public void LogInAnAccount()
        {
            int tries = 0;
            Console.WriteLine("\nType your userName first and then password to log in");

            try
            {
                if (Console.ReadLine() == userDataBase["userName"])
                {
                    Console.WriteLine("The user has been found!\n");
                    Console.WriteLine("Now enter you password\n");
                    while (tries < 3)
                    {
                        tries++;
                        if (Console.ReadLine() == userDataBase["password"])
                        {
                            Console.WriteLine($"You've entered a correct password! and it's been your {tries} attempt\n");
                            break;
                        }
                        else
                            Console.WriteLine("Your password is wrong, try again\n ");
                        if (tries == 3)
                        {
                            Console.WriteLine("Unfurtenetly, you've been blocked\n");
                        }
                    }
                }
                else
                    throw new InvalidCastException("Unfortunetly, the user has not been found! Try again\n");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                LogInAnAccount();
            }

        }

        
    

        public void UsersMenu()
        {
            Console.WriteLine("Select any feature down below");

            Console.WriteLine("1. Look at your balance");

            Console.WriteLine("2. withdraw money");

            Console.WriteLine("3. Add money to you wallet");

            Console.WriteLine("4. sign out of system");
        }

        public void UsersActions()
        {


            string chooseAction = Convert.ToString(Console.ReadLine());
            switch (chooseAction)
            {
                case "1":
                    Message(constants[chooseAction]);
                    LookAtBalance();
                    break;
                case "2":
                    Message(constants[chooseAction]);
                    WithdrawMoney();
                    break;
                case "3":
                    Message(constants[chooseAction]);
                    AddBalance();
                    break;
                case "4":
                    Message(constants[chooseAction]);
                    SignOutOfSystem();
                    break;
            }


        }

        public void AddBalance()
        {

            Console.WriteLine("Add that amount of money that you need\n");
            int money = Convert.ToInt32(Console.ReadLine());
            addMoney += money;
            usersBalance.Add(addMoney);

            Console.WriteLine("Now your balance is: " + usersBalance[usersBalance.Count - 1]);


        }

        public void LookAtBalance()
        {
            if (usersBalance.Equals(0))
                Console.WriteLine("Your balance is empty");
            else
                Console.WriteLine("Your current balance is: " + usersBalance[usersBalance.Count - 1]);

        }

        public void WithdrawMoney()
        {
            Console.WriteLine("How much would you like to withdraw?\n");
            int draw = Convert.ToInt32(Console.ReadLine());
            if (draw > addMoney)
                Console.WriteLine("You cannot withdraw more than you've got");
            else if (draw <= 0)
                Console.WriteLine("Please enter an amount greater than 0");
            else
            {
                draw = addMoney - draw;
                currentBalance.Add(draw);
                Console.WriteLine("Now you balance is:  " + currentBalance[currentBalance.Count - 1]);
            }
        }
        public void Message(string chooseAction)
        {
            Console.WriteLine($"You've chosen a function {chooseAction}");
        }

        public bool SignOutOfSystem()
        {
            Console.WriteLine("Do you want to sign out of System?");
            string response = Convert.ToString(Console.ReadLine());
            if (response == "y")
            {
                return false;
            }
            else
            {
                UsersMenu();
                UsersActions();
            }
            return true;
        }
    }
}

