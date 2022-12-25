using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Task_2._2
{
    abstract class Worker
    {
        public Worker(string name)
        {
            Name = name;
        }
        public void Call()
        {
            // ...
        }
        public void WriteCode()
        {
            // ...
        }
        public void Relax()
        {
            // ...
        }
        public abstract void FillWorkDay();
        public string Name;
        public string Position;
        public string WorkDay = "Simple work day";
    }
    class Developer : Worker
    {
        public Developer(string name) : base(name)
        {
            Name = name;
            Position = "Розробник";
        }
        public override void FillWorkDay()
        {
            WriteCode();
            Call();
            Relax();
            WriteCode();
        }
    }
    class Manager : Worker
    {
        public Manager(string name) : base(name)
        {
            Name = name;
            Position = "Менеджер";
        }
        public override void FillWorkDay()
        {
            for(int i = 0; i <= random.Next(10); i++)
            {
                Call();
            }
            Relax();
            for (int i = 0; i <= random.Next(5); i++)
            {
                Call();
            }
        }
        private Random random;
    }
    class Team
    {
        public Team(string name)
        {
            Name = name;
        }
        public void addNewWorker(Worker worker)
        {
            listOfWorkers.Add(worker);
        }
        public void getInfoShort()
        {
            Console.WriteLine("Short team info: ");
            Console.WriteLine(Name);
            listOfWorkers.ForEach(worker =>
            {
                Console.WriteLine(worker.Name);
            });
        }
        public void getInfoLong()
        {
            Console.WriteLine("Long team info: ");
            Console.WriteLine(Name);
            listOfWorkers.ForEach(worker =>
            {
                Console.WriteLine(worker.Name + " - " + worker.Position + " - " + worker.WorkDay);
            });
        }

        private List<Worker> listOfWorkers = new List<Worker>();
        private string Name;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string teamName = Console.ReadLine();
            Team team = new Team(teamName);
            int numberOfWorkers = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfWorkers; i++)
            {
                string workerName = Console.ReadLine();
                string workerPosition = Console.ReadLine();
                while (workerPosition != "Developer" && workerPosition != "Manager")
                {
                    Console.WriteLine("Input real worker position");
                    workerPosition = Console.ReadLine();
                }
                if (workerPosition == "Developer")
                {
                    team.addNewWorker(new Developer(workerName));
                }
                if (workerPosition == "Manager")
                {
                    team.addNewWorker(new Manager(workerName));
                }
            }
            team.getInfoShort();
            team.getInfoLong();
            Console.ReadKey();
        }
    }
}
