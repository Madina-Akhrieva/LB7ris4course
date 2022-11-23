using System;
using System.Xml.Linq;


namespace LB7Me
{
    class Program
    {
        private static DepositOperations depositOperations = new DepositOperations();
        public static readonly string FILE_PATH = "C:\\Users\\akhri\\source\\repos\\LB7Me\\LB7Me\\XMLFile1.xml";

        static void Main(string[] args)
        {
            depositOperations.readDepositInformation(FILE_PATH);

            Console.Write("Ваш выбор: ");
            string depositNumber = Console.ReadLine();

            Console.WriteLine("Депозит, с которым вы будете работать под номером " + depositNumber + "\n");

            depositOperations.getDepoositByNumber(depositNumber, FILE_PATH);

            Menu(depositNumber, FILE_PATH);

        }

        static void Menu(string depositNumber, string fileName)
        {
            Console.WriteLine("\n");
            Console.WriteLine("Выберите пункт меню, который хотите выполнлить:");

            Console.WriteLine("1. Просмотреть остаток на счете.");
            Console.WriteLine("2. Рассчетать процентные начисления.");
            Console.WriteLine("3. Снять процентные начисления.");
            Console.WriteLine("4. Пополнить счет.");
            Console.WriteLine("5. Формирование выписки (отчета) о проделанных ооперацииях.");
            Console.WriteLine("\n");
            Console.Write("Ввeдите Ваш выбор: ");
            String choice = Console.ReadLine();
            Console.WriteLine("\n");
            switch (choice)
            {
                case "1":
                    depositOperations.getRemains(depositNumber, fileName);
                    Menu(depositNumber, fileName);
                    break;
                case "2":
                    depositOperations.countInterestAccuraks(depositNumber, fileName);
                    Menu(depositNumber, fileName);
                    break;
                case "3":
                    depositOperations.getInterestAccurance(depositNumber, fileName);
                    Menu(depositNumber, fileName);
                    break;
                case "4":
                    depositOperations.putInterestAccurance(depositNumber, fileName);
                    Menu(depositNumber, fileName);
                    break;
            }
        }

        
    }
}
