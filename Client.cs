using System;

namespace Charp_modul10_dz
{
    class Client
    {
        public string firstName; 
        public string lastName;
        public string passport;
        public string phoneNumber;

        public Client(string firstName, string lastName, string passport, string phoneNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.passport = passport;
            this.phoneNumber = phoneNumber;
        }

        
        string HidePassport(string passport) 
        {
            if (passport != null)
            {
                string hiddenPassport = string.Empty;
                foreach (var pass in passport.Split())
                {
                    hiddenPassport += "*";
                }
                return hiddenPassport;
            }
            return null;
        }
        public void SetField(string data, Command command, WorkerPosition position) // сеттер, дающий доступ ко всем
                                                                                    // полям только работнику
                                                                                    // с должностью - мэнеджер
                                                                                    // и только в номеру - для консультанта
        {
            if (command == Command.SetPhoneNumber) phoneNumber = data;
            if (position == WorkerPosition.Manager)
            {
                switch (command)
                {
                    case Command.SetFirstName:

                        firstName = data;
                        break;

                    case Command.SetLastName:

                        lastName = data;
                        break;

                    case Command.SetPassport:

                        passport = data;
                        break;
                }
            }
            else Console.WriteLine("Error");
        }
        public string GetClientInfo(WorkerPosition position) 
        {
            if (position == WorkerPosition.Consultant)
            {
                return $"firstname: {firstName ?? "none"}\n" +
                       $"lastname: {lastName ?? "none"}\n" +
                       $"passport: {HidePassport(passport) ?? "none"}\n" +
                       $"phonenumber: {phoneNumber ?? "none"}";
            }
            else
            {
                return $"firstname: {firstName ?? "none"}\n" +
                       $"lastname: {lastName ?? "none"}\n" +
                       $"passport: {passport ?? "-none-"}\n" +
                       $"phonenumber: {phoneNumber ?? "none"}";
            }
            
        }
    }
}
