namespace Master_Pol.Database.Testing.Moq;

public interface IDatabaseService
{
    decimal? GetProductCoefficient(int productTypeId);
    decimal? GetWastePercentage(int materialTypeId);
}