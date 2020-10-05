using System;

namespace Bank
{
    class UserActions : User
    {

        User user;

        public void onCheckPasswordAndUserName(string userName, string password)
        {
            if (userName.Length >= 5 || password.Length >= 5)
            {
                Console.WriteLine("Congratualtions you created a new account! \n");
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

        public bool ChooseAction()
        {
            Console.WriteLine("\nDo you want to choose another action?:\n ");

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

        public void LogInAnAccount()
        {
            int tries = 0;

            string check;

            Console.WriteLine("\nType your userName first and then password to log in");

            check = Convert.ToString(Console.ReadLine());

            try
            {
                if (check == userName)
                {
                    Console.WriteLine("The user has been found!\n");
                }
                else
                    throw new InvalidCastException("Unfortunetly, the user has not been found! Try again\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                LogInAnAccount();
            }

            Console.WriteLine("Now enter your password\n");

            bool isChecked = true;

            while (isChecked)
            {
                check = Convert.ToString(Console.ReadLine());

                tries++;

                if (check == password)
                {
                    Console.WriteLine($"You've entered a correct password! and it's been your {tries} attempt\n");
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
                }
            }

        }

        public void AddBalance()
        {

            Console.WriteLine("Add that amount of money that you need\n");

            int money = Convert.ToInt32(Console.ReadLine());

            addMoney += money;

            usersBalance.Add(addMoney);

            Console.WriteLine("Hello " + userName + " Now your balance is: " + usersBalance[usersBalance.Count - 1]);

        }

        public void LookAtBalance()
        {
            if (usersBalance == null)
                Console.WriteLine("There's no money yet");

            else if (usersBalance.Equals(0))
                Console.WriteLine("Your balance is empty");


            else
                Console.WriteLine("Hello " + userName + " Your current balance is: " + usersBalance[usersBalance.Count - 1]);

        }

        public void WithdrawMoney()
        {

            Console.WriteLine("How much would you like to withdraw?\n");

            int draw = Convert.ToInt32(Console.ReadLine());

            if (draw.Equals(null))

                Console.WriteLine("You don't have any money to withdraw yet");

            else
            {
                if (draw > addMoney)

                    Console.WriteLine("You cannot withdraw more than you've got");

                else if (draw <= 0)

                    Console.WriteLine("Please enter an amount greater than 0");

                else
                {
                    draw = addMoney - draw;

                    usersBalance.Add(draw);

                    Console.WriteLine("Hello, " + userName + " Now you balance is:  " + usersBalance[usersBalance.Count - 1]);
                }
            }
        }

        public bool SignOutOfSystem()
        {
            user = new User();

            Console.WriteLine("Do you want to sign out of System? Type y/n");

            choose = Convert.ToString(Console.ReadLine());



            isNumeric = int.TryParse(choose, out number);

            if (!isNumeric)
            {
                if (choose.ToLower() == "y")
                {
                    return true;

                }
            }

            else
            {
                Console.WriteLine("you cannot use digits!");

                this.SignOutOfSystem();
            }

            if (String.IsNullOrEmpty(choose))
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
