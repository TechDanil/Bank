using System;
using System.Collections.Generic;

namespace Bank
{

    public class PasswordToChange
    {
        public void PasswordToChangeMethod(string password, int MaxLength, List<string> passwordsToAdd)
        {
            if (password.Length >= MaxLength)
            {
                passwordsToAdd.Remove(password);

                Console.WriteLine("Now change password to another one\n");

                string passwordToChange = Convert.ToString(Console.ReadLine());

                passwordsToAdd.Add(passwordToChange);

                if (passwordToChange.Length >= MaxLength)
                {
                    Console.WriteLine("your password has been changed successfuly!!");

                }

                else
                {
                    Console.WriteLine("your password cannot be less than 5 symbols!!");

                    this.PasswordToChangeMethod(password, MaxLength, passwordsToAdd);
                }



            }


        }
    }
}
