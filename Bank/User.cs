using System;
using System.Collections.Generic;


namespace Bank
{
    public class User 
    {
        static MainAdminActions mainAdminActions = new MainAdminActions();

        static UserActions userActions = new UserActions();

        public List<int> usersBalance = new List<int>();

        public List<string> users = new List<string>();

        Dictionary<string, Action> nonReturnActions = new Dictionary<string, Action>
            {
                { "1", userActions.LookAtBalance},

                { "2",  userActions.WithdrawMoney},

                { "3", userActions.AddBalance }

            };

        Dictionary<string, Func<bool>> returnActions = new Dictionary<string, Func<bool>>
            {
                {"4", userActions.SignOutOfSystem}
            };

        public List<string> userPasswords = new List<string>();

        public bool agree = true;



        protected Dictionary<string, string> constants = new Dictionary<string, string>
        {
            {"1", "look at balance" },
            {"2", "withdraw the balance" },
            {"3", "add money to your wallet" },
            {"4", "sign out of System" }
        };

        public string choose;

        public bool isNumeric;

        public string userName;

        public string password;

        public int number = 0;

        public int addMoney;

        public int lengthOfPassword = 5;

        public int lengthOfUserName = 5;

        public int money;

        public void UserAccount()
        {

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

                else if (userAnswer.ToLower() == "n")
                {
                    this.SignUpAccount();

                    this.LogInAnAccount();
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

        public void UsersAction()
        {
            choose = Convert.ToString(Console.ReadLine());

            if (nonReturnActions.ContainsKey(choose))
            {
                nonReturnActions[choose]?.Invoke();
            }

            else if (returnActions.ContainsKey(choose))
            {
                returnActions[choose]?.Invoke();
            }
        }


        public bool ChooseAction()
        {

            Console.WriteLine("\nDo you want to contiinue?:\n ");

            choose = Convert.ToString(Console.ReadLine());

            isNumeric = int.TryParse(choose, out number);

            if (isNumeric)
            {
                Console.WriteLine("you cannot use digits here! Try again");

                this.ChooseAction();
            }

            else if (String.IsNullOrEmpty(choose))
            {
                Console.WriteLine("you cannot leave this field empty! ");

                this.ChooseAction();
            }

            return choose.ToLower() == "y";
        }


        public void UsersMenu()
        {
            Console.WriteLine("Select any feature down below");

            Console.WriteLine("1. Look at your balance");

            Console.WriteLine("2. withdraw money");

            Console.WriteLine("3. Add money to you wallet");

            Console.WriteLine("4. sign out of system");
        }



        protected void SignUpAccount()
        {

            Console.WriteLine("Enter userName");

            userName = Convert.ToString(Console.ReadLine());

            users.Add(userName);

            isNumeric = int.TryParse(userName, out number);

            if (!isNumeric)
            {
                Console.WriteLine("Enter your password:\n ");

                password = Convert.ToString(Console.ReadLine());

                userPasswords.Add(password);

                this.onCheckPasswordAndUserName(userName, password);

            }

            else
            {
                Console.WriteLine("You cannot type digits !");

                this.SignUpAccount();
            }

        }


        protected void LogInAnAccount()
        {
            int tries = 0;

            string name;

            Console.WriteLine("\nType your userName first and then password to log in");

            name = Convert.ToString(Console.ReadLine());

            try
            {
                if (users.IndexOf(name) == users.LastIndexOf(userName))
                {
                    Console.WriteLine("The user has been found!\n");
                }
                else
                    throw new InvalidCastException("Unfortunetly, the user has not been found! Try again\n");
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                this.LogInAnAccount();
            }

            Console.WriteLine("Now enter your password\n");

            bool isChecked = true;

            while (isChecked)
            {
                name = Convert.ToString(Console.ReadLine());

                tries++;

                if (name == password)
                {
                    Console.WriteLine($"You've entered a correct password! and it's been your {tries} attempt\n");

                    Console.WriteLine("Press any key to clear the window");

                    Console.ReadKey();

                    Console.Clear();

                    while (agree)
                    {
                        this.UsersMenu();

                        this.UsersAction();

                        agree = ChooseAction();
                    }

                    break;
                }

                else
                {
                    Console.WriteLine("Your password is wrong, try again\n ");

                }

                if (tries == 3)
                {
                    isChecked = false;

                    Console.WriteLine("Unfurtenetly, you've been blocked\n");

                        mainAdminActions.UsersUnblock();
                }
            }

        }



        protected void Message(string chooseAction)
        {
            Console.WriteLine($"You've chosen a function {chooseAction}");
        }

        protected void onCheckPasswordAndUserName(string userName, string password)
        {
            if (userName.Length >= lengthOfUserName || password.Length >= lengthOfPassword)
            {
                Console.WriteLine("Congratualtions you've created a new account! \n");
            }

            else if (String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(password))
            {
                Console.WriteLine("You cannot leave it empty!");

                this.SignUpAccount();
            }

            else
            {
                Console.WriteLine("your password or UserName cannot be less than 5 symbles in it!");

                this.SignUpAccount();
            }

        }

    }
}

