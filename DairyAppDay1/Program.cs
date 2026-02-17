Console.Write("Enter Farmer Name: ");
string name = Console.ReadLine();

Console.Write("Enter Milk Quantity: ");
double qty = Convert.ToDouble(Console.ReadLine());

Console.Write("Enter Rate per Liter: ");
double rate = Convert.ToDouble(Console.ReadLine());

double total = qty * rate;

Console.WriteLine("Farmer: " + name);
Console.WriteLine("Total Amount: " + total);

