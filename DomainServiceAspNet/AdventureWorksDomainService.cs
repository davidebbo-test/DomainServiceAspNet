
namespace DomainServiceAspNet
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // Implements application logic using the AdventureWorksLT_DataEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class AdventureWorksDomainService : LinqToEntitiesDomainService<AdventureWorksLT_DataEntities>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Products' query.
        public IQueryable<Product> GetProducts()
        {
            return this.ObjectContext.Products.OrderBy(p => p.ProductID);
        }

        public void InsertProduct(Product product)
        {
            if ((product.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(product, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Products.AddObject(product);
            }
        }

        public void UpdateProduct(Product currentProduct)
        {
            if ((currentProduct.EntityState == EntityState.Detached))
            {
                // Custom logic: set a lower limit for the price.
                if (currentProduct.ListPrice < 5)
                    throw new ValidationException("The list price must be >= 5.");
                this.ObjectContext.Products.AttachAsModified(currentProduct,
                   this.ChangeSet.GetOriginal(currentProduct));
                // Custom logic: set the date to the current value.
                currentProduct.ModifiedDate = DateTime.Today;
            }
        }
        
        public void DeleteProduct(Product product)
        {
            if ((product.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(product, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Products.Attach(product);
                this.ObjectContext.Products.DeleteObject(product);
            }
        }
    }
}


