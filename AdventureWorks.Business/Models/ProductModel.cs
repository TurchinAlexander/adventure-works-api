using System;

namespace AdventureWorks.Business.Models
{
    public class ProductModel
    {
        public Int32 ProductId { get; set; }

        public string Name { get; set; }

        public bool MakeFlag { get; set; }

        public bool FinishedGoodsFlag { get; set; }

        public string Color { get; set; }

        public Int16 SafetyStockLevel { get; set; }

        public Int16 ReorderPoint { get; set; }

        public decimal StandardCost { get; set; }

        public decimal ListPrice { get; set; }

        public string Size { get; set; }

        public string SizeUnitMeasureCode { get; set; }

        public string WeightUnitMeasureCode { get; set; }

        public decimal? Weight { get; set; }

        public Int32 DaysToManufacture { get; set; }

        public string ProductLine { get; set; }

        public string Class { get; set; }

        public string Style { get; set; }

        public Int32? ProductSubcategoryId { get; set; }

        public Int32? ProductModelId { get; set; }

        public DateTime SellStartDate { get; set; }

        public DateTime? SellEndDate { get; set; }

        public DateTime? DiscontinuedDate { get; set; }

        public Guid rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}