namespace OrderManagementApp.Model
{
    public class ProductListDTO
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public double UnitPrice { get; set; }

        public string DisplayText => $"{Name} ({UnitPrice:c})";

    }
}