using System;
using System.IO;
using Newtonsoft.Json;

namespace Charp_modul10_dz
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var datasourse = File.ReadAllText("D:/test_json");
            Console.WriteLine(datasourse);

            Client client = JsonConvert.DeserializeObject<Client>(datasourse);

            bool appIsWork = true;



            while (appIsWork)
            {
                Command inputCommand; // команда, которую выберет пользователь для работы с данными

                string inputData; // временная переменная для данных, которые нужно установить или изменить

                Console.WriteLine("1 - Consultant\n2 - Manager"); // выбор работника

                var position = (WorkerPosition)int.Parse(Console.ReadLine());

                switch (position)
                {
                    case WorkerPosition.Consultant: // если выбрали консультанта

                        Consultant consultant = new Consultant();

                        Console.WriteLine("Выбирите действие: \n" +
                            "1 - Вывести инф. о клиенте\n" +
                            "2 - Изменить/Установить номер телефона клиента");

                        inputCommand = (Command)int.Parse(Console.ReadLine());

                        switch (inputCommand)
                        {
                            case Command.PrintInfo:

                                consultant.PrintInfoAboutClient(client);
                                break;


                            case Command.SetPhoneNumber:

                                Console.WriteLine("Введите данные, которые хотите изменить/установить");
                                inputData = Console.ReadLine();
                                consultant.SetField(client, inputData, Command.SetPhoneNumber);
                                break;

                        }
                        break;

                    case WorkerPosition.Manager: // если выбрали менеджера

                        Manager manager = new Manager();

                        Console.WriteLine("Выбирите действие: \n" +
                            "1 - Вывести инф. о клиенте\n" +
                            "2 - Изменить/Установить номер телефона клиента\n" +
                            "3 - Изменить/Установить серию и номер паспорта\n" +
                            "4 - Изменить/Установить Фамилию\n" +
                            "5 - Изменить/Установить Имя");

                        inputCommand = (Command)int.Parse(Console.ReadLine());

                        switch (inputCommand)
                        {
                            case Command.PrintInfo:

                                manager.PrintInfoAboutClient(client);
                                break;

                            case Command.SetPhoneNumber:

                                Console.WriteLine("Введите данные, которые хотите изменить/установить");
                                inputData = Console.ReadLine();
                                manager.SetField(client, inputData, Command.SetPhoneNumber);
                                break;

                            case Command.SetPassport:

                                Console.WriteLine("Введите данные, которые хотите изменить/установить");
                                inputData = Console.ReadLine();
                                manager.SetField(client, inputData, Command.SetPassport);
                                break;

                            case Command.SetLastName:

                                Console.WriteLine("Введите данные, которые хотите изменить/установить");
                                inputData = Console.ReadLine();
                                manager.SetField(client, inputData, Command.SetLastName);
                                break;

                            case Command.SetFirstName:

                                Console.WriteLine("Введите данные, которые хотите изменить/установить");
                                inputData = Console.ReadLine();
                                manager.SetField(client, inputData, Command.SetFirstName);
                                break;

                        }
                        break;

                }
                Console.WriteLine("Хотите продолжить ?\n" +
                    "Да - клавиша Y\n" +
                    "Нет - любая другая");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    appIsWork = true;
                }
                else
                {
                    appIsWork = false;
                }

            }
        }
        }
    }

    enum WorkerPosition
    {
        Consultant = 1, 
        Manager = 2
    }

    enum Command
    {
        PrintInfo = 1,
        SetPhoneNumber,
        SetPassport,
        SetLastName,
        SetFirstName,
}

