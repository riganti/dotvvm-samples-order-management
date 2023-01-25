using System;

namespace OrderManagementApp.Model
{
    public class OrderListDTO
    {

        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public string ContactEmail { get; set; }

        public double TotalPrice { get; set; }

        public int ItemsCount { get; set; }

    }
}