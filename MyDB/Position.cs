
namespace MyDB
{
    public class Position
    {
        // звязок 1

        public int Id { get; set; }

        public string PositionName { get; set; }

        public int Salary { get; set; }

        public int? PersonId { get; set; } // зовнішній ключ

        public Person Person { get; set; } // властивість для навігації щоб ми могли переходити з Person в Position

    }
}