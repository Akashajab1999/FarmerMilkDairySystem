public class MilkCollection
{
  public string FarmerName {get;set;}
   public int Liters{get;set;}
   public int Fat{get;set;}

   public int RatePerLiter{get;set;}

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