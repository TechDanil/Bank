using System;
using System.Collections.Generic;

namespace Bank
{
    class Admin : MainAdminActions
    {

        private string adminUserName;

        private string adminPassword;

        protected void AdminsMenu()
        {
            Console.WriteLine("Select any feature down below");

            Console.WriteLine("1. look at the list of users");

            Console.WriteLine("2. Add a new user");

            Console.WriteLine("3. delete the user");

            Console.WriteLine("4. unblock the user");

            Console.WriteLine("5. sign out of system");
        }

        protected Dictionary<string, string> adminsData = new Dictionary<string, string>
        {
            {"userName", "admin" },
            {"password", "admin" }
        };

        protected Dictionary<string, string> adminsActions = new Dictionary<string, string>
        {
            {"1", "to look at the list of users" },
            {"2", "to add a new user" },
            {"3", "to delete the user" },
            {"4", "to unblock the user" },
            {"5", "to sign out of system" }
        };



        PasswordAndUserNameChecker passwordAndUserNameChecker;

        MainAdminActions mainAdminActions = new MainAdminActions();
        
        UserActions userActions;

        public void AdminAccount()
        {
            userActions = new UserActions();

            this.AdminLogIn();

            agree = true;

            while (agree)
            {
                this.AdminsMenu();

                this.AdminChooseAction();

                agree =  userActions.ChooseAction();
            }

        }

        protected void AdminLogIn()
        {
            passwordAndUserNameChecker = new PasswordAndUserNameChecker();

            try
            {
                Console.WriteLine("Enter your Admin's userName: ");

                adminUserName = Convert.ToString(Console.ReadLine());


                Console.WriteLine("Enter admin's password");

                adminPassword = Convert.ToString(Console.ReadLine());

                

                isNumeric = int.TryParse(adminUserName, out number);


                if (adminUserName.Length >=5 || adminPassword.Length >=5)
                {
                    this.passwordAndUserNameChecker.ChackingPasswrodAndUserNameIfItsEmpty(adminUserName, adminPassword);


                    if (!isNumeric)
                    {

                        if (adminUserName == adminsData["userName"] && adminPassword == adminsData["password"])

                            Console.WriteLine("proceeded! ");

                        else
                        {
                            Console.WriteLine("type a correct password or userName! ");

                            this.AdminLogIn();
                        }
                    }

                    else
                    {
                        Console.WriteLine("you cannot use numbers while typing username");

                        this.AdminLogIn();
                    }

                }

                else
                    throw new InvalidCastException("you connot type less than 5 symbolse!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                this.AdminLogIn();
            }

        }

        protected void AdminChooseAction()
        {

            nonReturnActions = new Dictionary<string, Action>
            {
                { "1", mainAdminActions.AdminsViewTheListOfUsers},

                { "2",mainAdminActions.AddNewUser},

                { "3", mainAdminActions.UserRemove}


            };

            returnActions = new Dictionary<string, Func<bool>>
            {

                { "5",AdminsSignOutOfSystem}
            };

            choose = Convert.ToString(Console.ReadLine());

            if (nonReturnActions.ContainsKey(choose))
                nonReturnActions[choose]?.Invoke();

            else if (returnActions.ContainsKey(choose))
                returnActions[choose]?.Invoke();

        }

        private bool AdminsSignOutOfSystem()
        {
            Console.WriteLine("Do you want to sign out of System?");

            string response = Convert.ToString(Console.ReadLine());

            if (response.ToLower() == "y")
            {
                return true;
            }

            else
            {
                this.AdminsMenu();

                this.AdminChooseAction();
            }
            return false;
        }


    }


}


