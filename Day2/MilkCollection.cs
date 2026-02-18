public class MilkCollection
{
  public string FarmerName {get;set;}
   public int Liters{get;set;}
   public int Fat{get;set;}

   public int RatePerLiter{get;set;}


public void SetLiters(int value)
    {
        if (value > 0)
            Liters = value;
        else
            Console.WriteLine("Liters cannot be negative.");
    }

    public void SetRate(int value)
    {
        if (value > 0)
            RatePerLiter = value;
        else
            Console.WriteLine("Rate must be positive.");
    }

    public void SetFat(int value)
    {
        if (value >= 0 && value <= 10)
            Fat = value;
        else
            Console.WriteLine("Fat must be between 0 and 10.");
    }

   
  public int CalculateAmount()
    {
       int amount = Liters * RatePerLiter;

        // Bonus logic
        if (Fat > 6)
        {
            amount += Liters * 2;
        }

        return amount;
 
    }

}