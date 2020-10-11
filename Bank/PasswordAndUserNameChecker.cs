using System;

namespace Bank
{
   public class PasswordAndUserNameChecker
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
