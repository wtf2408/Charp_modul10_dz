using System;
using System.Runtime.InteropServices;

namespace Charp_modul10_dz
{
    class Client
    {
        public string firstName; 
        public string lastName;
        public string passport;
        public string phoneNumber;

        public ChangeInfo ChangeInformer { get; set;  }

        public Client(string firstName, string lastName, string passport, string phoneNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.passport = passport;
            this.phoneNumber = phoneNumber;
            ChangeInformer = new ChangeInfo() { ChangedData = new System.Collections.Generic.Dictionary<string, string>()};

            
        }
        void SaveChanges(WorkerPosition workerPosition, string changedData, string newData)
        {
            changedData = changedData ?? "none";
            ChangeInformer.LastChangeTime = DateTime.Now;
            ChangeInformer.LastChangerName = workerPosition;
            ChangeInformer.ChangedData.Add(newData, changedData); 
        }

        string HidePassport(string passport) 
        {
            if (passport != null)
            {
                return "**** ******";
            }
            return null;
        }


        public void SetField(string data, Command command, WorkerPosition position) // сеттер, дающий доступ ко всем
                                                                                    // полям только работнику
                                                                                    // с должностью - мэнеджер
                                                                                    // и только в номеру - для консультанта
        {
            if (position == WorkerPosition.Consultant)
            {
                SaveChanges(WorkerPosition.Consultant, phoneNumber, data);
                phoneNumber = data;
                
            }
            if (position == WorkerPosition.Manager)
            {
                switch (command)
                {
                    case Command.SetFirstName:

                        SaveChanges(WorkerPosition.Manager, firstName, data);
                        firstName = data;
                        break;

                    case Command.SetLastName:
                        
                        SaveChanges(WorkerPosition.Manager, lastName, data);
                        lastName = data;
                        break;

                    case Command.SetPassport:

                        SaveChanges(WorkerPosition.Manager, passport, data);
                        passport = data;
                        break;

                    case Command.SetPhoneNumber:

                        SaveChanges(WorkerPosition.Manager, phoneNumber, data);
                        phoneNumber = data;
                        break;
                }
            }
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
