using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;


namespace MyDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<MyModel>()); // ініціалізація БД

            using (MyModel myModel = new MyModel()) // підключаємось до контексту нашої БД
            {
                Position p1 = new Position { PositionName = "Junior", Salary = 750 };

                Position p2 = new Position { PositionName = "Midle", Salary = 1800 };

                Position p3 = new Position { PositionName = "Senior", Salary = 2500 };

                Position p4 = new Position { PositionName = "PM", Salary = 2000 };

                myModel.Positions.AddRange(new List<Position> { p1, p2, p3, p4 });
                myModel.SaveChanges();

                var position = myModel.Positions.ToList();
                foreach (var item in position)
                {
                    Console.WriteLine("{0}, {1}, {2}, {3}", item.Id, item.PositionName, item.Salary, item.Person != null ? item.Person.Name : "Даних немає");
                }

                Console.WriteLine(new string('-', 30));

                Person person1 = new Person { Name = "Vladislav Rudenko", Age = 23, Position = new List<Position> { p1 } };

                Person person2 = new Person { Name = "Max Bogach", Age = 28, Position = new List<Position> { p2 } };

                Person person3 = new Person { Name = "Kostya Sticenko", Age = 32, Position = new List<Position> { p3 } };

                Person person4 = new Person { Name = "Alex Bilyk", Age = 25, Position = new List<Position> { p4 } };

                myModel.Persons.AddRange(new List<Person> { person1, person2, person3, person4 });
                myModel.SaveChanges();

                var info1 = myModel.Positions.ToList();

                foreach (var item in info1)
                {
                    Console.WriteLine("{0}, {1}, {2}", item.Person.Name, item.Person.Age, item.PositionName);
                }

                Console.WriteLine(new string('-', 30));

                Position po1 = myModel.Positions.FirstOrDefault(p => p.Id == 5);
                if (po1 != null)
                    Console.WriteLine("{0}, {1}, {2}", po1.Person.Name, po1.Person.Age, po1.PositionName);

                Console.WriteLine(new string('-', 30));

                Position po2 = myModel.Positions.First(p => p.Id == 2);
                if (po2 != null)
                    Console.WriteLine("{0}, {1}, {2}", po2.Person.Name, po2.Person.Age, po2.PositionName);

                Console.WriteLine(new string('-', 30));

                var info2 = myModel.Positions.OrderBy(p => p.Person.Name);
                foreach (var item in info2)
                {
                    Console.WriteLine("{0}, {1}, {2}", item.Person.Name, item.Person.Age, item.PositionName);
                }

                Console.WriteLine(new string('-', 30));

                int num2 = myModel.Positions.Count(p => p.PositionName.Contains("Junior")); // знаходимо к-ть записів які містять ключове слово Junior
                Console.WriteLine("{0}", num2);

                Console.WriteLine(new string('-', 30));

                int num3 = myModel.Persons.Min(p => p.Age);  // для знаходження мін, макс і середнього значення по виборкі використовуємо Min, Max, Average
                Console.WriteLine("Мінімальний вік - {0}", num3);

                Console.WriteLine(new string('-', 30));

                int num4 = myModel.Persons.Max(p => p.Age);
                Console.WriteLine("Максимальний вік - {0}", num4);

                Console.WriteLine(new string('-', 30));

                double num5 = myModel.Persons.Average(p => p.Age);
                Console.WriteLine("Середній вік - {0}", num5);
            }
            Console.ReadKey();
        }
    }
}
