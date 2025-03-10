using Master_Pol.Database.Testing.Moq;

namespace UnitTest;
using Moq;
using Xunit;


public class UnitTest1
{
    
    // Тестирования метода подсчета материалов с валидными данными
    [Fact]
    public void CalculatorMaterialValid()
    {
        var mockDb = new Mock<IDatabaseService>();
        mockDb.Setup(db => db.GetProductCoefficient(1)).Returns(0.5m);
        mockDb.Setup(db => db.GetWastePercentage(2)).Returns(0.1m);

        var calc = new Test();
        
        int productTypeId = 1;
        int materialTypeId = 2;
        int quantity = 10;
        double param1 = 2.0;
        double param2 = 3.0;
        
        int res = calc.CalculateMaterial(mockDb.Object ,productTypeId, materialTypeId, quantity, param1, param2);
        
        Assert.Equal(34, res);
        
    }

    // Тестирования метода подсчета материалов с невалидными данными
    [Fact]
    public void CalculatorMaterialInvalidProduct()
    {
        var mockDb = new Mock<IDatabaseService>();
        mockDb.Setup(db => db.GetProductCoefficient(1)).Returns((decimal?)null);
        var calc = new Test();
        
        int productTypeId = 1;
        int materialTypeId = 2;
        int quantity = 10;
        double param1 = 2.0;
        double param2 = 3.0;
        
        int res = calc.CalculateMaterial(mockDb.Object ,productTypeId, materialTypeId, quantity, param1, param2);
        
        Assert.Equal(-1, res);
        
    }
    
    // Тестирования метода подсчета материалов с невалидными данными
    [Fact]
    public void CalculatorMaterialInvalidWaste()
    {
        var mockDb = new Mock<IDatabaseService>();
        mockDb.Setup(db => db.GetProductCoefficient(1)).Returns(0.5m);
        mockDb.Setup(db => db.GetWastePercentage(2)).Returns((decimal?)null);
        
        var calc = new Test();
        
        int productTypeId = 1;
        int materialTypeId = 2;
        int quantity = 10;
        double param1 = 2.0;
        double param2 = 3.0;
        
        int res = calc.CalculateMaterial(mockDb.Object ,productTypeId, materialTypeId, quantity, param1, param2);
        
        Assert.Equal(-1, res);
        
    }


    
}