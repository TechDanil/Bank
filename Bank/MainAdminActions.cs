using System;
using System.Collections.Generic;

namespace Bank
{
    class MainAdminActions : User
    {

        protected List<string> usersToRemove = new List<string>();

        UserActions userActions = new UserActions();


        public void AddNewUser()
        {
            Console.WriteLine("Checking whether the intitial capital is more than 100");

            if (addMoney < 100)
            {
                Console.WriteLine("You cannot create a new user, top up your balance");

                this.userActions.AddBalance();

                this.AddNewUser();
            }

            else if (addMoney >= 100)
            {

                Console.WriteLine("create a new user\n");

                Console.WriteLine("enter a userName:\n ");


                userName = Convert.ToString(Console.ReadLine());

                users.Add(userName);
               

                isNumeric = int.TryParse(userName, out  number);

                if (isNumeric)
                {
                    Console.WriteLine("You cannot type only digits! Try again!");

                    this.AddNewUser();
                }

                else if(String.IsNullOrEmpty(userName))
                {
                    Console.WriteLine("you cannot leave it empty! Try again!");
                    
                    this.AddNewUser();
                }

                this.UsersPasswordCompare();
            }


        }

        private bool UsersPasswordCompare()
        {
        
            Console.WriteLine("Enter an indentical password to your username:\n ");

            password = Convert.ToString(Console.ReadLine());

            userPasswords.Add(password);

            if (String.IsNullOrEmpty(password))
            {
                Console.WriteLine("you cannot leave it empty! Try again");
                this.UsersPasswordCompare();
            }

            else if (userName == password)
            {
                userPasswords.Remove(password);

                Console.WriteLine("Now change password to another one\n");

               string passwordToChange = Convert.ToString(Console.ReadLine());

                userPasswords.Add(passwordToChange);

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

            userName = Convert.ToString(Console.ReadLine());


            if (users.Contains(userName))
            {
                usersToRemove.Add(userName);

                users.Remove(userName);

                Console.WriteLine("the user has been removed");
            }
            
            else
                Console.WriteLine("The user has not been found!");

            foreach (var item in usersToRemove)
            {
                Console.WriteLine(item);
            }

        }
        private void UsersUnblock()
        {

        }

        public void AdminsViewTheListOfUsers()
        {

            if (users.Equals(null))
                Console.WriteLine("There are no useres added yet");

            else
            {
                foreach (var usersOutPut in users)
                    Console.Write("User: " + usersOutPut + "\n");
            }
        }

    }
}

