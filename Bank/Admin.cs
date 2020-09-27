using System;
using System.Collections.Generic;
using System.Linq;

namespace Bank
{
    class Admin : User
    {
        public static string newUserName;
        public static string password;
        public void AdminsMenu()
        {
            Console.WriteLine("Select any feature down below");

            Console.WriteLine("1. look at the list of users");

            Console.WriteLine("2. Add a new user");

            Console.WriteLine("3. delete the user");

            Console.WriteLine("4. unblock the user");

            Console.WriteLine("5. sign out of system");
        }

        public Dictionary<string, string> adminsData = new Dictionary<string, string>
        {
            {"userName", "a" },
            {"password", "a" }
        };
        public Dictionary<string, string> adminsActions = new Dictionary<string, string>
        {
            {"1", "to look at the list of users" },
            {"2", "to add a new user" },
            {"3", "to delete the user" },
            {"4", "to unblock the user" },
            {"5", "to sign out of system" }
        };

        public void AdminAccount()
        {
            AdminLogIn();
            agree = true;
            while (agree)
            {
                AdminsMenu();
                AdminChooseAction();
                agree = ChooseAction();
            }

        }

        public void AdminLogIn()
        {
            try
            {
                Console.WriteLine("Enter your Admin's userName: ");
                if (Console.ReadLine() == adminsData["userName"])
                    Console.WriteLine("proceeded! ");
                Console.WriteLine("Enter your Amin's password: ");
                if (Console.ReadLine() == adminsData["password"])
                    Console.WriteLine("Proceeded! ");
                else
                    throw new InvalidCastException("Data is wrong, try again!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                AdminLogIn();
            }

        }

        public void AdminChooseAction()
        {
            Console.WriteLine("Choose any action");
            string chooseAction = Convert.ToString(Console.ReadLine());
            switch (chooseAction)
            {
                case "1":
                    Message(adminsActions[chooseAction]);
                    AdminsViewTheListOfUsers();
                    break;

                case "2":
                    Message(adminsActions[chooseAction]);
                    AddNewUser();
                    break;

                case "3":
                    Message(adminsActions[chooseAction]);
                    UserRemove();
                    break;

                case "4":
                    Message(adminsActions[chooseAction]);
                    break;

                case "5":
                    Message(adminsActions[chooseAction]);
                    AdminsSignOutOfSystem();
                    break;
            }
        }

        public void AdminsViewTheListOfUsers()
        {

            foreach (var theListOfUsers in userDataBase)
                Console.Write(theListOfUsers.Key + " " + theListOfUsers.Value);

        }


        public void AddNewUser()
        {
            Console.WriteLine("Checking whether the intitial capital is more than 100");
            if (addMoney < 100)
            {
                Console.WriteLine("You cannot create a new user, top up your balance");
                AddBalance();
                AddNewUser();
            }
            else if (addMoney > 100)
            {

                Console.WriteLine("create a new user\n");

                Console.WriteLine("type his userName:\n ");

                userDataBase.Add("userName", newUserName = Convert.ToString(Console.ReadLine()));

                Console.WriteLine("Enter an indentical password to your username:\n ");

                password = Convert.ToString(Console.ReadLine());
                try
                {
                    if (password == userDataBase["userName"])
                    {
                        userDataBase.Add(" password", password);

                        Console.WriteLine("Now change password to another one\n");

                        string passwordToChange = Convert.ToString(Console.ReadLine());

                        userDataBase[" password"] = passwordToChange;

                        Console.WriteLine("your password has been changed!\n");

                    }
                    else
                        throw new InvalidCastException("you've typped unindentical password" +
                            " to your username, pls check it again\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    AddNewUser();
                }
            }


        }

        private void UserRemove()
        {
            List<string> usersToRemove = new List<string>();

            foreach (var pair in userDataBase)
            {
                if (pair.Equals(userDataBase["userName"]) && pair.Equals(userDataBase[" password"]))
                    usersToRemove.Add(pair.Key);
                    usersToRemove.Add(pair.Key);

            }
            foreach (var item in usersToRemove)
            {
                userDataBase.Remove(item[item.Length - 1].ToString());
                Console.WriteLine("The user has been removed! ");    
            }

        }

        public void UsersUnblock()
        {

        }

        public bool AdminsSignOutOfSystem()
        {
            Console.WriteLine("Do you want to sign out of System?");
            string response = Convert.ToString(Console.ReadLine());
            if (response == "y")
            {
                return false;
            }
            else
            {
                AdminsMenu();
                AdminChooseAction();
            }
            return true;
        }


    }
}


