using Home_task_10_2;

var visitor = new ShippingCostVisitor();

var foodProduct = new FoodProduct(10, 5, 100);
foodProduct.Accept(visitor);
Console.WriteLine($"Shipping cost for food product: {visitor.ShippingCost}");

var electronicProduct = new ElectronicProduct(10, 15, 1000);
electronicProduct.Accept(visitor);
Console.WriteLine($"Shipping cost for electronic product: {visitor.ShippingCost}");

var clothingProduct = new ClothingProduct(5, 2, 200);
clothingProduct.Accept(visitor);
Console.WriteLine($"Shipping cost for clothing product: {visitor.ShippingCost}");
