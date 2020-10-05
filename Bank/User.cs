using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Bank
{
    class User
    {

        protected List<int> usersBalance = new List<int>();

        protected List<string> users = new List<string>();

        protected List<string> userPasswords = new List<string>();

        protected static bool agree = true;

        protected Dictionary<string, Action> nonReturnActions;

        protected Dictionary<string, Func<bool>> returnActions;

        protected string choose;


        public static bool isNumeric;

        protected string userName;

        protected string password;


        protected int number = 0;


        protected Dictionary<string, string> constants = new Dictionary<string, string>
        {
            {"1", "look at balance" },
            {"2", "withdraw the balance" },
            {"3", "add money to your wallet" },
            {"4", "sign out of System" }
        };

        protected int addMoney;

        UserActions userActions;


        public void UserAccount()
        {

            userActions = new UserActions();

            Console.WriteLine("Hello a new user!!\n");

            Console.WriteLine("Do you want to sign out of the program? Type y/n\n");

            string userAnswer = Convert.ToString(Console.ReadLine());


            isNumeric = int.TryParse(userAnswer, out number);

            if (!isNumeric)
            {

                if (userAnswer.ToLower() == "y")
                {
                    Console.WriteLine("Bye :(");
                }

                else if(userAnswer.ToLower() == "n")
                {
                    this.userActions.SignUpAccount();

                    this.userActions.LogInAnAccount();

                    Console.WriteLine("Press any key to clear the window");

                    Console.ReadKey();

                    Console.Clear();

                    while (agree)
                    {
                        this.UsersMenu();

                        this.UsersAction();

                        agree = userActions.ChooseAction();
                    }
                }
            }

           
            else if (isNumeric)
            {
                Console.WriteLine("you cannot user digits!");

                this.UserAccount();
            }

            else if (String.IsNullOrEmpty(userAnswer))
            {
                Console.WriteLine("You cannot leave it empty!");

                this.UserAccount();

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

        public void SignUpAccount()
        {
            userActions = new UserActions();

            Console.WriteLine("Enter userName");

            userName = Convert.ToString(Console.ReadLine());

            users.Add(userName);


            isNumeric = int.TryParse(userName, out number);

            if (!isNumeric)
            {
                Console.WriteLine("Enter your password:\n ");


                password = Convert.ToString(Console.ReadLine());

                userPasswords.Add(password);

             this.userActions.onCheckPasswordAndUserName(userName, password);


            }
            else
            {
                Console.WriteLine("You cannot type digits !");

                this.SignUpAccount();
            }

        }

        public void UsersAction()
        {
            nonReturnActions = new Dictionary<string, Action>
            {
                { "1", userActions.LookAtBalance},

                { "2",  userActions.WithdrawMoney},

                { "3", userActions.AddBalance }

            };

            returnActions = new Dictionary<string, Func<bool>>
            {
                {"4", userActions.SignOutOfSystem}
            };

            choose = Convert.ToString(Console.ReadLine());

            if (nonReturnActions.ContainsKey(choose))
                nonReturnActions[choose]?.Invoke();

            else if (returnActions.ContainsKey(choose))
                returnActions[choose]?.Invoke();
        }


        protected void Message(string chooseAction)
        {
            Console.WriteLine($"You've chosen a function {chooseAction}");
        }


    }
}

