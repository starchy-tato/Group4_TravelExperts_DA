using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public static class ProductSupplierManager
    {
        /* 
         * TechSupportManager class to Add, Delet, and Modify products
         * from the Products table in the database.
         */

        /// <summary>
        /// adds another customer
        /// </summary>
        /// <param name="cust">customer to add</param>
        public static void AddProduct(Product product)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Modify existing product
        /// </summary>
        /// <param name="newProd">customer with new data</param>
        public static void UpdateProduct(Product newProd)
        {
            Product oldProd; // product with original data
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                oldProd = db.Products.Find(newProd.ProductId);  // find the object  to modify
                db.Entry(oldProd).CurrentValues.SetValues(newProd);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Delete existing product
        /// </summary>
        /// <param name="prod"></param>
        public static void DeleteProduct(Product prod)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                db.Products.Remove(prod);
                db.SaveChanges();
            }
        }

        public static List<SupplierDTO> GetProductSuppliers(int prodid)
        {
            List<SupplierDTO> prodSuppliers = null;

            // get suppliers for a given product
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                prodSuppliers = (from p in db.Products
                                 join ps in db.ProductsSuppliers on p.ProductId equals ps.ProductId
                                 join s in db.Suppliers on ps.SupplierId equals s.SupplierId
                                 where p.ProductId == prodid
                                 orderby s.SupName ascending
                                 select new SupplierDTO
                                 {
                                     SupName = s.SupName,
                                     SupplierId = s.SupplierId,
                                 }).ToList();
            }
            return prodSuppliers;
        }

        //public static List<Supplier> GetAllSuppliers(int prodid) Taking into consideration current Product
        public static List<Supplier> GetAllSuppliers()
        {
            /*
             * List all other suppliers which are not providing for Product (prodid)
             * and also suppliers which are not supplying to any other product because maybe they are new
             * 
             * 
             * using (TravelExpertsContext db = new TravelExpertsContext())
            {
                allSuppliers = (from s in db.Suppliers
                                join ps in db.ProductsSuppliers
                                on s.SupplierId equals ps.SupplierId into supplierGroup
                                from sup in supplierGroup.DefaultIfEmpty()
                                join prod in db.Products
                                on sup.ProductId equals prod.ProductId into productGroup
                                from pro in productGroup.DefaultIfEmpty()
                                where pro.ProductId != prodid
                                orderby s.SupName ascending
                                select new Supplier
                                {
                                    SupName = s.SupName,
                                    SupplierId = s.SupplierId
                                }).ToList();

            }
             */
            List<Supplier> allSuppliers = null;

            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                allSuppliers = (from s in db.Suppliers
                                orderby s.SupName ascending
                                select new Supplier
                                {
                                    SupName = s.SupName,
                                    SupplierId = s.SupplierId
                                }).ToList();

            }
            return allSuppliers;
        }
        /// <summary>
        /// Add a record to the ProuctsSupplier table
        /// </summary>
        /// <param name="pid">ProductId</param>
        /// <param name="sid">SupplierId</param>
        public static bool AddProductSupplier(int pid, int sid)
        {
            /*
             * 
             * Add product supplier to database using ProductsSupplier Identity key
            */
            bool result = true;
            ProductsSupplier pSup = null;

            if (GetSingleProductSupplier(pid, sid) == null)
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {

                    pSup = new ProductsSupplier();
                    pSup.ProductId = pid;
                    pSup.SupplierId = sid;
                    db.ProductsSuppliers.Add(pSup);
                    db.SaveChanges();
                }
            }
            else result = false;
                    
            return result;
        }
        /// <summary>
        /// Remove a single record from ProductsSupplier table
        /// </summary>
        /// <param name="pid">ProductId</param>
        /// <param name="sid">SupplierId</param>
        public static bool RemoveProductSupplier(int pid, int sid)
        {
            /*
             * 
             * Remove product supplier record by passing product id and supplier id keys
            */
            bool result = true;

            if (GetSingleProductSupplier(pid, sid) != null)
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    db.ProductsSuppliers.Remove(GetSingleProductSupplier(pid, sid));
                    db.SaveChanges();
                }
            }
            else result = false;

            return result;
        }
        /// <summary>
        /// Retrieves a Product Supplier record by passing ProductId, and SupplierId
        /// </summary>
        /// <param name="pid">Product Id</param>
        /// <param name="sid">Supplier Id</param>
        /// <returns>ProductsSupplier object</returns>
        public static ProductsSupplier GetSingleProductSupplier(int pid, int sid)
        {
            ProductsSupplier pSup;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                pSup = db.ProductsSuppliers.Where(productSupplierTable => productSupplierTable.ProductId == pid &&
                    productSupplierTable.SupplierId == sid).FirstOrDefault();
            }

            return pSup;

        }
    } // end of class
}// end of namespace
