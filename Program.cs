using System.Text;
using Homework;

namespace Homework;

internal class Program
{
    static async Task Main(string[] args)
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        do
        {
            User newUser = new User();
            var service = new RegisterService();


            Console.Write("Enter email: ");
            newUser.Email = Console.ReadLine();

            Console.Write("Enter first name: ");
            newUser.FirstName = Console.ReadLine();

            Console.Write("Enter second name: ");
            newUser.SecondName = Console.ReadLine();

            Console.Write("Enter url photo: ");
            newUser.Photo = await Console.ReadLine().UriToBase64();

            Console.Write("Enter phone: ");
            newUser.Phone = Console.ReadLine().ToPhoneFormat();

            Console.Write("Enter password: ");
            newUser.Password = Console.ReadLine();

            Console.Write("Confirm password: ");
            newUser.ConfirmPassword = Console.ReadLine();



            bool res = await service.RegisterUser(newUser);

            if (res)
            {
                Console.Clear();

                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("Success registered!");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Press Enter");
                Console.ResetColor();

                Console.ReadLine();
            } 
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Press Enter");
                Console.ResetColor();

                Console.ReadLine();

                Console.Clear();
            }
        }
        while (true);
    }
}
