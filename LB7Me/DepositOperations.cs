using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LB7Me
{
    public class DepositOperations
    {
        private CrudFileLogicImpl crudFile = new CrudFileLogicImpl();
        public void readDepositInformation(string filePath)
        {
            Console.WriteLine("Выбере, пожалуйста, депозит из списка ниже.");

            XDocument xdoc = XDocument.Load(filePath);

            XElement deposits = xdoc.Element("deposits");

            if (deposits != null)
            {
                foreach (XElement deposit in deposits.Elements("deposit"))
                {

                    XAttribute number = deposit.Attribute("number");
                    XElement amount = deposit.Element("amount");
                    XElement currancy = deposit.Element("currancy");
                    XElement remains = deposit.Element("remains");
                    XElement interestAccruals = deposit.Element("interestAccruals");
                    XElement percent = deposit.Element("percent");

                    Console.WriteLine($"Deposit: {number?.Value}");
                    Console.WriteLine($"Amount: {amount?.Value}");
                    Console.WriteLine($"Currancy: {currancy?.Value}");
                    Console.WriteLine($"Remains: {remains?.Value}");
                    Console.WriteLine($"InterestAccruals: {interestAccruals?.Value}");
                    Console.WriteLine($"Percent: {percent?.Value}");

                    Console.WriteLine();
                }
            }

            crudFile.AddData(DateTime.Now + " Прочтение информации о всех депозитах.");
            
        }

        public void getDepoositByNumber(string number, string fileName)
        {
            XDocument xdoc = XDocument.Load(fileName);

            var chosenDeposit = xdoc.Element("deposits")?   
                .Elements("deposit")             
                .FirstOrDefault(p => p.Attribute("number")?.Value == number);

            XAttribute num = chosenDeposit.Attribute("number");
            XElement amount = chosenDeposit.Element("amount");
            XElement currancy = chosenDeposit.Element("currancy");
            XElement remains = chosenDeposit.Element("remains");
            XElement interestAccruals = chosenDeposit.Element("interestAccruals");
            XElement percent = chosenDeposit.Element("percent");

            Console.WriteLine($"Deposit: {num?.Value}");
            Console.WriteLine($"Amount: {amount?.Value}");
            Console.WriteLine($"Currancy: {currancy?.Value}");
            Console.WriteLine($"Remains: {remains?.Value}");
            Console.WriteLine($"InterestAccruals: {interestAccruals?.Value}");
            Console.WriteLine($"Percent: {percent?.Value}");
            Console.WriteLine("\n");

            crudFile.AddData(DateTime.Now +" Поиск депозита по номеру.");

        }

        internal void putInterestAccurance(string depositNumber, string fileName)
        {
            Console.WriteLine("Введите, пожалуйста, сумму на которою хотите поплнить баланс.");
                Console.Write("Сумма пополнения: ");
            string amount = Console.ReadLine();
            Console.WriteLine("Идет процесс поплнения счета...");

            XDocument xdoc = XDocument.Load(fileName);

            var deposit = xdoc.Element("deposits")?
                .Elements("deposit")
                .FirstOrDefault(p => p.Attribute("number")?.Value == depositNumber);

            if (deposit != null)
            {
                var remains = deposit.Element("remains");
                if (remains != null) remains.Value = amount;

                xdoc.Save(fileName);
            }

            getDepoositByNumber(depositNumber, fileName);
            Console.WriteLine("Процесс поплнения успешно завершен!");
            Console.WriteLine("Проверьте, что средства поступили на счет.");

            crudFile.AddData(DateTime.Now +" Пополнение баланса.");
        }

        public void getRemains(string number, string fileName)
        {
            XDocument xdoc = XDocument.Load(fileName);

            var chosenDeposit = xdoc.Element("deposits")?
                .Elements("deposit")
                .FirstOrDefault(p => p.Attribute("number")?.Value == number);

            XAttribute num = chosenDeposit.Attribute("number");
            XElement amount = chosenDeposit.Element("amount");
            XElement currancy = chosenDeposit.Element("currancy");
            XElement remains = chosenDeposit.Element("remains");
            XElement interestAccruals = chosenDeposit.Element("interestAccruals");
            XElement percent = chosenDeposit.Element("percent");
            Console.WriteLine(" Остаток счета  " + DateTime.Now + "  составляет " + remains.Value);

            crudFile.AddData(DateTime.Now + "Прочтение информации об остатках на счету.");


        }

        public void countInterestAccuraks(string number, string fileName)
        {
            XDocument xdoc = XDocument.Load(fileName);

            var chosenDeposit = xdoc.Element("deposits")?
                .Elements("deposit")
                .FirstOrDefault(p => p.Attribute("number")?.Value == number);

            XAttribute num = chosenDeposit.Attribute("number");
            XElement amount = chosenDeposit.Element("amount");
            XElement currancy = chosenDeposit.Element("currancy");
            XElement remains = chosenDeposit.Element("remains");
            XElement interestAccruals = chosenDeposit.Element("interestAccruals");
            XElement percent = chosenDeposit.Element("percent");

            Console.WriteLine("Идет процесс рассчета процентных начислений...");
            Console.WriteLine("Сумма процентных начислений составила " + interestAccruals.Value);

            Console.WriteLine(" Остаток счета " + DateTime.Now + " составляет " + remains.Value);


            crudFile.AddData(DateTime.Now  + " Рассчет процентных начислений.");

        }

        public void getInterestAccurance(string number, string fileName)
        {
            Console.WriteLine("Идет процесс снятия процентных начислений...");

            XDocument xdoc = XDocument.Load(fileName);

            var deposit = xdoc.Element("deposits")?
                .Elements("deposit")
                .FirstOrDefault(p => p.Attribute("number")?.Value == number);

            if (deposit != null)
            {
                var remains = deposit.Element("remains");
                if (remains != null) remains.Value = "0";

                xdoc.Save(fileName);
            }

            getDepoositByNumber(number, fileName);


            crudFile.AddData(DateTime.Now +" Снятие процентных начислений.");
        }
    }
}
