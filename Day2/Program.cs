MilkCollection milk = new MilkCollection();

Console.WriteLine("Enter Liters:");
milk.SetLiters(Convert.ToInt32(Console.ReadLine()));

Console.WriteLine("Enter Rate:");
milk.SetRate(Convert.ToInt32(Console.ReadLine()));

Console.WriteLine("Enter Fat:");
milk.SetFat(Convert.ToInt32(Console.ReadLine()));

Console.WriteLine("Total Amount: " + milk.CalculateAmount());
