using System;

namespace m1k4.Model
{
    public class PriceComponent
    {
        /// <summary>Gets or sets PriceComponentId.</summary>
        public int PriceComponentId { get; set; }

        /// <summary>Gets or sets PriceComponentTypeId.</summary>
        public int PriceComponentTypeId { get; set; }

        /// <summary>Gets or sets FromDate.</summary>
        public DateTime FromDate { get; set; }

        /// <summary>Gets or sets ThroughDate.</summary>
        public DateTime ThroughDate { get; set; }

        /// <summary>Gets or sets Price.</summary>
        public decimal Price { get; set; }

        /// <summary>Gets or sets Percent.</summary>
        public decimal Percent { get; set; }

        /// <summary>Gets or sets ProductId.</summary>
        public int ProductId { get; set; }

        /// <summary>Gets or sets OrganizationId.</summary>
        public Organization Organization { get; set; }

        /// <summary>Gets or sets QuantityBreakId.</summary>
        public int QuantityBreakId { get; set; }

        /// <summary>Gets or sets OrderValueId.</summary>
        public int OrderValueId { get; set; }

        /// <summary>Gets or sets ProductCategoryId.</summary>
        public ProductCategory ProductCategory { get; set; }

        /// <summary>Gets or sets GeographicBoundaryId.</summary>
        public GeographicBoundary GeographicBoundary { get; set; }

        /// <summary>Gets or sets SaleTypeId.</summary>
        public int SaleTypeId { get; set; }
    }

}