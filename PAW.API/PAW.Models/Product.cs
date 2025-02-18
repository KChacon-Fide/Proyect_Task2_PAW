namespace PAW.Data.Models;

public partial class Product
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ProductId { get; set; }
    public decimal Price { get; set; }
    public string Sku { get; set; }
    public int Quantity { get; set; }
}
