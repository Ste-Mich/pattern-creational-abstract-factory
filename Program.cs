using System;

/*  O výrobu instancí objektů se starají továrny.  
 *  - umožňují kombinaci mnoha stylů a nábytků
 *  - lepší než vytvářet kombinace pomocí podtříd - exponenciální růst - modrý čtverec, modrý kruh, červený čtverec, červený kruh...
 */

namespace Abstract_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            IFurnitureFactory factory = new VictorianFurnitureFactory();
            var chair = factory.CreateChair();
            var table = factory.CreateTable();

            chair.SitOn();
            Console.WriteLine("Chair has " + chair.LegCount + " legs.");
            Console.WriteLine("Is chair comfy? " + chair.IsComfy.ToString());
            Console.WriteLine("Table has " + table.LegCount + " legs.");
            Console.WriteLine("What shape is table? " + table.Shape);

            Console.WriteLine("- - - ");
            Console.WriteLine("  Factory changed");
            Console.WriteLine("- - - ");

            factory = new ModernFurnitureFactory();
            chair = factory.CreateChair();
            table = factory.CreateTable();

            chair.SitOn();
            Console.WriteLine("Chair has " + chair.LegCount + " legs.");
            Console.WriteLine("Is chair comfy? " + chair.IsComfy.ToString());
            Console.WriteLine("Table has " + table.LegCount + " legs.");
            Console.WriteLine("What shape is table? " + table.Shape);


        }
    }

    interface IFurnitureFactory
    {
        public IChair CreateChair();
        public ITable CreateTable();
    }

    public class VictorianFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair()
        {
            return new VictorianChair() { LegCount = 4, IsGoodLooking = true, IsComfy = true };
        }

        public ITable CreateTable()
        {
            return new VictorianTable() { LegCount = 3, Shape = "Practical" };
        }
    }

    public class ModernFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair()
        {
            return new ModernChair() { LegCount = 1, IsGoodLooking = false, IsComfy = false };
        }

        public ITable CreateTable()
        {
            return new ModernTable() { LegCount = 1, Shape = "Weird" };
        }
    }

    public interface IChair
    {
        public void SitOn();
        int LegCount { get; set; }
        bool IsGoodLooking { get; set; }
        bool IsComfy { get; set; }
    }

    public class VictorianChair : IChair
    {
        public int LegCount { get; set; }
        public bool IsGoodLooking { get; set; }
        public bool IsComfy { get; set; }

        public void SitOn()
        {
            Console.WriteLine("Sitting on a Victorian chair.");
        }
    }

    public class ModernChair : IChair
    {
        public int LegCount { get; set; }
        public bool IsGoodLooking { get; set; }
        public bool IsComfy { get; set; }

        public void SitOn()
        {
            Console.WriteLine("Sitting on a Modern chair.");
        }
    }

    public interface ITable
    {
        int LegCount { get; set; }
        string Shape { get; set; }
    }

    public class VictorianTable : ITable
    {
        public int LegCount { get; set; }
        public string Shape { get; set; }
    }

    public class ModernTable : ITable
    {
        public int LegCount { get; set; }
        public string Shape { get; set; }
    }
}
