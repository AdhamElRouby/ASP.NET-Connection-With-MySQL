using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using System.Security.Policy;
using EntityFramework.Model;
using System.Net.Mime;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            // add a participant using a form
            AddParticipant();
            // show the full names of participants and their startups
            ShowNameAndStartup();
        }
        public static void ShowNameAndStartup()
        {
            using var dbContext = new AddDbContext();
            
            var names = dbContext.Participants.Join(dbContext.Startups,
                p => p.StartupID, e => e.StartupID,
                (p, e) => new
                {
                    FullName = $"{p.FirstName} {p.LastName}",
                    StartupName = e.StartupName
                }).ToList();

            Console.WriteLine("All participants to the competition:");
            
            foreach (var participant in names)
            {
                Console.WriteLine($"Full Name: {participant.FullName}, Startup Name: {participant.StartupName}");
            }
        }
        public static void AddParticipant()
        {
            using var dbContext = new AddDbContext();
            Console.Write("Enter your First Name: ");
            var firstName = Console.ReadLine();
            Console.Write("Enter your Last Name: ");
            var lastName = Console.ReadLine();
            Console.Write("Enter your phone number: ");
            var phoneNumber = Console.ReadLine();
            Console.Write("Enter your email: ");
            var email = Console.ReadLine();
            Console.Write("Enter your startup id: ");
            var startupId = Console.ReadLine();
            try
            {
                dbContext.Database.ExecuteSqlRaw($"INSERT INTO participants (FirstName, LastName, PhoneNumber, Email, StartupID) " +
                                                 $"VALUES (\"{firstName}\", \"{lastName}\", \"{phoneNumber}\",\"{email}\", {startupId});");
                Console.WriteLine("Loading...");
                dbContext.SaveChanges();
                Console.WriteLine("You have been sucessfully added to the competition's participants");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}