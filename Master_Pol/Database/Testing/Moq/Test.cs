namespace Master_Pol.Database.Testing.Moq;

public class Test
{
    public int CalculateMaterial(IDatabaseService  databaseService, int productTypeId, int materialTypeId, int quantity, double param1, double param2)
    {
        try
        {
            decimal? productCoefficient = databaseService.GetProductCoefficient(productTypeId);
            if (productCoefficient == null)
            {
                return -1;
            }

            decimal? wastePercentage = databaseService.GetWastePercentage(materialTypeId);
            if (wastePercentage == null)
            {
                return -1;
            }

            double materialPerUnit = param1 * param2 * (double)productCoefficient;
            double totalMaterial = materialPerUnit * quantity / (1 - (double)wastePercentage);

            return Convert.ToInt32(Math.Ceiling(totalMaterial));
        }
        catch (Exception)
        {
            return -1;
        }
    }
}