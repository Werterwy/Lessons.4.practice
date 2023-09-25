using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons._4.practice
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public BankAccount Account { get; set; }
        public BankCard Card { get; set; }

        public Client(int clientId, string name)
        {
            ClientId = clientId;
            Name = name;
            Account = new BankAccount();
            Card = new BankCard();
        }

        public void MakePayment(decimal amount, BankAccount recipientAccount)
        {
            if (Account.Balance >= amount)
            {
                Account.Withdraw(amount);
                recipientAccount.Deposit(amount);
                Console.WriteLine($"{Name} совершил платеж на сумму {amount:C}.");
            }
            else
            {
                Console.WriteLine($"{Name}: Недостаточно средств на счете для совершения платежа.");
            }
        }

        public void CancelAccount()
        {
            Account.CloseAccount();
            Console.WriteLine($"{Name}: Счет аннулирован.");
        }

        public void BlockCard()
        {
            Card.BlockCard();
            Console.WriteLine($"{Name}: Банковская карта заблокирована.");
        }
    }

    public class BankAccount
    {
        public decimal Balance { get; private set; }
        public bool IsClosed { get; private set; }

        public BankAccount()
        {
            Balance = 0;
            IsClosed = false;
        }

        public void Deposit(decimal amount)
        {
            if (!IsClosed)
            {
                Balance += amount;
                Console.WriteLine($"Счет пополнен на {amount:C}. Новый баланс: {Balance:C}");
            }
            else
            {
                Console.WriteLine("Счет закрыт. Невозможно пополнить.");
            }
        }

        public void Withdraw(decimal amount)
        {
            if (!IsClosed && Balance >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"Сумма {amount:C} снята. Новый баланс: {Balance:C}");
            }
            else
            {
                Console.WriteLine("Недостаточно средств или счет закрыт. Операция отклонена.");
            }
        }

        public void CloseAccount()
        {
            IsClosed = true;
        }
    }

    public class BankCard
    {
        public bool IsBlocked { get; private set; }

        public BankCard()
        {
            IsBlocked = false;
        }

        public void BlockCard()
        {
            IsBlocked = true;
        }
    }

    public class Administrator
    {
        public void BlockCardForExceedingPayment(Client client, decimal amount)
        {
            if (client.Card.IsBlocked)
            {
                Console.WriteLine("Банковская карта уже заблокирована.");
            }
            else if (client.Account.Balance < amount)
            {
                client.Card.BlockCard();
                Console.WriteLine($"{client.Name}: Банковская карта заблокирована за превышение лимита.");
            }
        }
    }

    class SystemPayments
    {
        static void Main(string[] args)
        {
/*
            6.Задача на взаимодействие между классами. Разработать систему «Платежи». 
                Клиент имеет Счет в банке и Банковскую карту(КК).
                Клиент может оплатить Заказ, сделать платеж на другой 
                Счет, заблокировать КК и аннулировать Счет.
                Администратор может заблокировать КК за превышение платежа.*/


            Client client1 = new Client(1, "Иван");
            Administrator admin = new Administrator();

            // Пополнение счет клиента
            client1.Account.Deposit(1000);

            Client client2 = new Client(2, "Мария");
            client2.Account.Deposit(500);

            // платеж между клиентами
            client1.MakePayment(200, client2.Account);

            // заблокировать карту клиента за превышение лимита
            admin.BlockCardForExceedingPayment(client1, 300);

            // Аннулируем счет клиента
            client1.CancelAccount();

            Console.ReadLine();
        }
    }

}
