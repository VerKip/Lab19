using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Computer> computers = new List<Computer>()
            {
                new Computer(){ Code = 01, Name = "Lenovo", PType="Intel Core i5", GHz=2.5, Ram=8, Storage=512, VideoCard=4, Price=62999, Number=100},
                new Computer(){ Code = 02, Name = "HP", PType="Intel Core i3", GHz=2, Ram=8, Storage=256, VideoCard=4, Price=39999, Number=58},
                new Computer(){ Code = 03, Name = "Acer", PType="Intel Core i5", GHz=2.7, Ram=16, Storage=512, VideoCard=4, Price=84999, Number=24},
                new Computer(){ Code = 04, Name = "MSI", PType="Intel Core i7", GHz=2.3, Ram=16, Storage=1000, VideoCard=8, Price=130499, Number=3},
                new Computer(){ Code = 05, Name = "MSI", PType="Intel Core i5", GHz=2.7, Ram=8, Storage=256, VideoCard=4, Price=71999, Number=14},
                new Computer(){ Code = 06, Name = "MSI", PType="Intel Core i5", GHz=2.7, Ram=8, Storage=512, VideoCard=6, Price=99999, Number=7},
            };

            Console.WriteLine("Введите тип процессора");
            string ptype = Console.ReadLine();
            List<Computer> computers1 = computers.Where(x => x.PType == ptype).ToList();
            Print(computers1);

            Console.WriteLine("Введите минимальный объем оперативной памяти в Гб");
            ushort ram = Convert.ToUInt16(Console.ReadLine());
            List<Computer> computers2 = computers.Where(x => x.Ram >= ram).ToList();
            Print(computers2);

            Console.WriteLine("Сортировка по увеличению стоимости");
            List<Computer> computers3 = computers.OrderBy(x => x.Price)
                .ToList();
            Print(computers3);

            Console.WriteLine("Сортировка по типу процессора");
            IEnumerable<IGrouping<string, Computer>> computers4 = computers.GroupBy(x => x.PType);
            foreach (IGrouping<string, Computer> gr in computers4)
            {
                Console.WriteLine(gr.Key);
                foreach (Computer c in gr)
                {
                    Console.WriteLine($"{c.Code} {c.Name} {c.PType} {c.GHz} {c.Ram} {c.Storage} {c.VideoCard} {c.Price} {c.Number}");
                }
            }
            Console.WriteLine();

            Console.WriteLine("Самый дорогой компьютер");
            Computer computers5 = computers.OrderByDescending(x => x.Price).FirstOrDefault();
            Console.WriteLine($"{computers5.Code} {computers5.Name} {computers5.PType} {computers5.GHz} {computers5.Ram} {computers5.Storage} {computers5.VideoCard} {computers5.Price} {computers5.Number}");
            Console.WriteLine();

            Console.WriteLine("Самый дешевый компьютер");
            Computer computers6 = computers.OrderBy(x => x.Price).FirstOrDefault();
            Console.WriteLine($"{computers6.Code} {computers5.Name} {computers5.PType} {computers5.GHz} {computers5.Ram} {computers5.Storage} {computers5.VideoCard} {computers5.Price} {computers5.Number}");
            Console.WriteLine();

            Console.WriteLine("Есть ли хотя бы одна модель компьютера, которой больше 30 штук в наличии?");
            Console.WriteLine(computers.Any(x => x.Number > 30)); 

            Console.ReadKey();
        }

        static void Print(List<Computer> computers)
        {
            foreach(Computer c in computers)
            {
                Console.WriteLine($"{c.Code} {c.Name} {c.PType} {c.GHz} {c.Ram} {c.Storage} {c.VideoCard} {c.Price} {c.Number}");  
            }
            Console.WriteLine();
        }
    }
}
