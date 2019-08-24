using System.Collections.Generic;
namespace MyDB
{
    public class Person // таблиця Person
    {
        // звязок М

        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public ICollection<Position> Position { get; set; } // якщо ICollection, то зв'язок 1 to M, один робітник може бути тільки
                                                            // на одній посаді (будем вважати що компанія в нас велика) 
        public Person()
        {
            Position = new List<Position>();
        }
    }
}