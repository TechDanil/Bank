using System;
using System.Collections.Generic;

namespace Bank
{
    public class Admin
    {
        static PasswordAndUserNameChecker passwordAndUserNameChecker = new PasswordAndUserNameChecker();

        static MainAdminActions mainAdminActions = new MainAdminActions();

        Dictionary<string, Action> nonReturnAdminActions = new Dictionary<string, Action>
        {
           {"1", mainAdminActions.AdminsViewTheListOfUsers },
           
            {"2", mainAdminActions.AddNewUser },
           
            {"3", mainAdminActions.UserRemove }

        };

        Dictionary<string, Func<bool>> returnAdminActions = new Dictionary<string, Func<bool>>
        {
            {"5", mainAdminActions.AdminsSignOutOfSystem}

        };

        static User user = new User();

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

        private string adminUserName;

        private string adminPassword;



        public void AdminsMenu()
        {
            Console.WriteLine("Select any feature down below");

            Console.WriteLine("1. look at the list of users");

            Console.WriteLine("2. Add a new user");

            Console.WriteLine("3. delete the user");

            Console.WriteLine("4. unblock the user");

            Console.WriteLine("5. sign out of system");
        }


        public void AdminAccount()
        {
            this.AdminLogIn();

            user.agree = true;

            while (user.agree)
            {
                this.AdminsMenu();

                this.AdminsActions();

                user.agree = user.ChooseAction();
            }

        }

        protected void AdminLogIn()
        {

            try
            {
                Console.WriteLine("Enter your Admin's userName: ");

                adminUserName = Convert.ToString(Console.ReadLine());


                Console.WriteLine("Enter admin's password");

                adminPassword = Convert.ToString(Console.ReadLine());



                user.isNumeric = int.TryParse(adminUserName, out user.number);


                if (adminUserName.Length >= user.lengthOfUserName || adminPassword.Length >= user.lengthOfPassword)
                {
                    passwordAndUserNameChecker.ChackingPasswrodAndUserNameIfItsEmpty(adminUserName, adminPassword);


                    if (!user.isNumeric)
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

        public void AdminsActions()
        {
            user.choose = Convert.ToString(Console.ReadLine());

            if (nonReturnAdminActions.ContainsKey(user.choose))
            {
                nonReturnAdminActions[user.choose]?.Invoke();
            }

            else if (returnAdminActions.ContainsKey(user.choose))
            {
                returnAdminActions[user.choose]?.Invoke();
            }

        }



    }


}


