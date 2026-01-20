using System;

class Program
{
    static void Main()
    {
        string name = "";
        while (name == "")
        {
            Console.Write("Enter your name: ");
            name = Console.ReadLine();
        }

        int age = 0;
        while (age <= 0)
        {
            Console.Write("Enter your age: ");
            if (!int.TryParse(Console.ReadLine(), out age) || age <= 0)
            {
                Console.WriteLine("Please enter a valid positive number.");
                age = 0;
            }
        }

        int ticketType = 0;
        double price = 0;
        string ticketName = "";

        while (true)
        {
            Console.WriteLine("Select ticket type:");
            Console.WriteLine("1: Child Ticket (€5)");
            Console.WriteLine("2: Adult Ticket (€10)");
            Console.WriteLine("3: Senior Ticket (€7)");
            Console.Write("Your choice: ");

            if (!int.TryParse(Console.ReadLine(), out ticketType))
            {
                Console.WriteLine("Invalid choice.");
                continue;
            }

            if (ticketType == 1 && age < 12)
            {
                ticketName = "Child Ticket";
                price = 5;
                break;
            }
            else if (ticketType == 2 && age >= 12 && age <= 64)
            {
                ticketName = "Adult Ticket";
                price = 10;
                break;
            }
            else if (ticketType == 3 && age >= 65)
            {
                ticketName = "Senior Ticket";
                price = 7;
                break;
            }
            else
            {
                Console.WriteLine("Ticket type does not match your age.");
            }
        }

        double originalPrice = price;
        double discountAmount = 0;

        Console.Write("Do you have a discount code? (yes/no): ");
        string hasCode = Console.ReadLine().ToLower();

        while (hasCode == "yes")
        {
            Console.Write("Enter discount code: ");
            string code = Console.ReadLine();

            if (string.Equals(code, "SALE20"))
            {
                discountAmount = price * 0.20;
                price = price - discountAmount;
                break;
            }
            else
            {
                Console.Write("Invalid code. Try again? (yes/no): ");
                hasCode = Console.ReadLine().ToLower();
            }
        }

        Console.WriteLine("Name: " + name);
        Console.WriteLine("Ticket Type: " + ticketName);
        Console.WriteLine("Original Price: €" + originalPrice);
        Console.WriteLine("Discount: €" + discountAmount);
        Console.WriteLine("Final Price: €" + price);
    }
}