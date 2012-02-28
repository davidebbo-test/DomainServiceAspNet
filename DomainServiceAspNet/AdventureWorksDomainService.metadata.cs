﻿
namespace DomainServiceAspNet
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // The MetadataTypeAttribute identifies ProductMetadata as the class
    // that carries additional metadata for the Product class.
    [MetadataTypeAttribute(typeof(Product.ProductMetadata))]
    public partial class Product
    {

        // This class allows you to attach custom attributes to properties
        // of the Product class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ProductMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private ProductMetadata()
            {
            }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Color is required")]
            public string Color { get; set; }

            public Nullable<DateTime> DiscontinuedDate { get; set; }

            public decimal ListPrice { get; set; }

            public DateTime ModifiedDate { get; set; }

            public string Name { get; set; }

            public ProductCategory ProductCategory { get; set; }

            public Nullable<int> ProductCategoryID { get; set; }

            public int ProductID { get; set; }

            public ProductModel ProductModel { get; set; }

            public Nullable<int> ProductModelID { get; set; }

            public string ProductNumber { get; set; }

            public Guid rowguid { get; set; }

            public EntityCollection<SalesOrderDetail> SalesOrderDetails { get; set; }

            public Nullable<DateTime> SellEndDate { get; set; }

            public DateTime SellStartDate { get; set; }

            public string Size { get; set; }

            public decimal StandardCost { get; set; }

            public byte[] ThumbNailPhoto { get; set; }

            public string ThumbnailPhotoFileName { get; set; }

            public Nullable<decimal> Weight { get; set; }
        }
    }
}
