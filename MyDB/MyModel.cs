namespace MyDB
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MyModel : DbContext
    {

        public MyModel()
            : base("name=MyModel")
        {
        }



        public virtual DbSet<Person> Persons { get; set; }

        public virtual DbSet<Position> Positions { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}