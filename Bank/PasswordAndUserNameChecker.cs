using System;

namespace Bank
{
    class PasswordAndUserNameChecker : Admin
    {

        public void ChackingPasswrodAndUserNameIfItsEmpty(string adminUserName, string adminPassword)
        {
            if (String.IsNullOrEmpty(adminUserName) || String.IsNullOrEmpty(adminPassword))
            {
                Console.WriteLine("You cannot leave it empty");
            }
        }

    }
}
