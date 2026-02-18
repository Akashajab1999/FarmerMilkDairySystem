
MilkCollection milkCollection = new MilkCollection();

 
        Console.WriteLine("Enter Farmer Name:");
        milkCollection.FarmerName = Console.ReadLine();

        Console.WriteLine("Enter Milk in Liters:");
        milkCollection.Liters = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Fat:");
        milkCollection.Fat = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Rate Per Liter:");
        milkCollection.RatePerLiter = Convert.ToInt32(Console.ReadLine());

        int total = milkCollection.CalculateAmount();

        Console.WriteLine("Total Amount: " + total);
