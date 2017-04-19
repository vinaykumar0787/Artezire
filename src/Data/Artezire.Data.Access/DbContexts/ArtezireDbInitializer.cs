using Artezire.Data.Entities;
using Artezire.Data.Entities.Enums;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Artezire.Data.Access
{
    public class ArtezireDbInitializer : CreateDatabaseIfNotExists<ArtezireDbContext>
    {
        protected override void Seed(ArtezireDbContext context)
        {
            SeedDb(context);
            base.Seed(context);
        }

        private void SeedDb(ArtezireDbContext context)
        {
            IList<ProductType> productTypes = new List<ProductType>(){
                new ProductType
                {
                    ProductTypeName = "ANTIQUE",
                    ProductTypeDescription = "ANTIQUE Item",
                    ProductTypeCode = ProductTypeEnum.ANTIQUE,
                },
                new ProductType
                {
                    ProductTypeName = "ART",
                    ProductTypeDescription = "ART Item",
                    ProductTypeCode = ProductTypeEnum.ART,
                },
                new ProductType
                {
                    ProductTypeName = "DECORATIONS",
                    ProductTypeDescription = "DECORATIONS Item",
                    ProductTypeCode = ProductTypeEnum.DECORATIONS,
                } };

            foreach(ProductType pdt in productTypes)
            {
                context.ProductTypes.Add(pdt);
            }

            IList<ProductStatus> productStatuses = new List<ProductStatus>(){
                new ProductStatus
                {
                    ProductStatusDescription = "ONSALE",
                    ProductStatusCode = ProductStatusEnum.ONSALE
                },
                new ProductStatus
                {
                    ProductStatusDescription = "APPROVED",
                    ProductStatusCode = ProductStatusEnum.APPROVED
                },
                new ProductStatus
                {
                    ProductStatusDescription = "DISPATCHED",
                    ProductStatusCode = ProductStatusEnum.DISPATCHED
                },
                new ProductStatus
                {
                    ProductStatusDescription = "DELIVERED",
                    ProductStatusCode = ProductStatusEnum.DELIVERED
                } };

            foreach (ProductStatus pds in productStatuses)
            {
                context.ProductStatuses.Add(pds);
            }

           

        }
    }
}
