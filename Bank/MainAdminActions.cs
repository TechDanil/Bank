using System;
using System.Collections.Generic;

namespace Bank
{
    public class MainAdminActions
    {

        static User user = new User();

        static Admin admin = new Admin();
      

        static PasswordToChange passwordToChange = new PasswordToChange();


        protected List<string> usersToAdd = new List<string>();

        protected List<string> passwordsToAdd = new List<string>();

        protected List<string> usersToRemove = new List<string>();

        protected List<int> adminsBalance = new List<int>();

        private int MaxLength = 5;

        private int money;

        public void AddNewUser()
        {

            Console.WriteLine("Checking whether the intitial capital is more than 100\n");

            if ( money < 100)
            {
                Console.WriteLine("You cannot create a new user, top up your balance\n");

                this.ReplanishBalance();

                this.AddNewUser();
            }

            else if (money >= 100)
            {

                Console.WriteLine("create a new user\n");

                Console.WriteLine("enter a userName:\n ");

                user.userName = Convert.ToString(Console.ReadLine());

                usersToAdd.Add(user.userName);

                user.isNumeric = int.TryParse(user.userName, out user.number);

                if (user.userName.Length >= MaxLength)
                {

                    if (user.isNumeric)
                    {
                        Console.WriteLine("You cannot type only digits! Try again!\n");

                        this.AddNewUser();
                    }

                    else if (String.IsNullOrEmpty(user.userName))
                    {
                        Console.WriteLine("you cannot leave it empty! Try again!\n");

                        this.AddNewUser();
                    }

                }

                else
                {

                    Console.WriteLine("your userName cannot be less than 5 symbols in it!");

                    this.AddNewUser();
                }

                this.UsersPasswordCompare();
            }


        }

        private bool UsersPasswordCompare()
        {

            Console.WriteLine("Enter an indentical password to your username:\n ");

            user.password = Convert.ToString(Console.ReadLine());

            passwordsToAdd.Add(user.password);

            if (String.IsNullOrEmpty(user.password))
            {
                Console.WriteLine("you cannot leave it empty! Try again");
                this.UsersPasswordCompare();
            }

            else if (user.userName == user.password)
            {

                passwordToChange.PasswordToChangeMethod(user.password, MaxLength, passwordsToAdd);

                return false;

            }

            else
            {
                Console.WriteLine("you've typped unindentical password" +
                        " to your username, pls check it again\n");
            }

            return true;
        }

        public void UserRemove()
        {

            Console.WriteLine("Type the name of the user you want to delete");

            user.userName = Convert.ToString(Console.ReadLine());

            if (usersToAdd.Contains(user.userName))
            {
                usersToRemove.Add(user.userName);

                usersToAdd.Remove(user.userName);

                Console.WriteLine("the user has been removed");
            }

            else
                Console.WriteLine("The user has not been found!");

            foreach (var item in usersToRemove)
            {
                Console.WriteLine(item);
            }

        }

        public void UsersUnblock()
        {
            
        }

        public void AdminsViewTheListOfUsers()
        {

            if (usersToAdd.Equals(null))
                Console.WriteLine("There are no useres added yet");

            else
            {
                foreach (var usersOutPut in usersToAdd)
                    Console.Write("User: " + usersOutPut + "\n");
            }
        }

        public bool AdminsSignOutOfSystem()
        {
            Console.WriteLine("Do you want to sign out of System?");

            string response = Convert.ToString(Console.ReadLine());

            if (response.ToLower() == "y")
            {
                return true;
            }

            else
            {
               admin.AdminsMenu();

                admin.AdminsActions();
            }
            return false;
        }

        private void ReplanishBalance()
        {
            Console.WriteLine("Enter that amount of money you need");

            int amount = Convert.ToInt32(Console.ReadLine());

             money += amount;

            adminsBalance.Add(money);

            Console.WriteLine("Hello, admin !" + " Now your balance is: " + adminsBalance[adminsBalance.Count - 1]);
        }


    }
}

