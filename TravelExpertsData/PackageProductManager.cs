using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public static class PackageProductManager
    {

        /* 
         * TechSupportManager class to Add, Delet, and Modify products
         * from the Products table in the database.
         */

        public static void AddPackage(Package pkge)
        {
            using(TravelExpertsContext db = new TravelExpertsContext())
            {
                db.Packages.Add(pkge);
                db.SaveChanges();
            }

        }

        public static void UpdatePackage(Package newPackage)
        {
            Package oldPackage = new Package(); // old package product supplier before change
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                oldPackage = db.Packages.Find(newPackage.PackageId);
                db.Entry(oldPackage).CurrentValues.SetValues(newPackage);
                db.SaveChanges();
            }

        }
        /// <summary>
        /// adds another customer
        /// </summary>
        /// <param name="cust">customer to add</param>
        public static void AddPkgProdSupplier(PackagesProductsSupplier pkgps)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                db.PackagesProductsSuppliers.Add(pkgps);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Modify existing product
        /// </summary>
        /// <param name="newProd">customer with new data</param>
        public static void UpdatePkgProdSupplier(PackagesProductsSupplier newpkgps)
        {
            int pkgid = newpkgps.PackageId;
            int sid = newpkgps.ProductSupplierId;
            PackagesProductsSupplier oldpkgps = new PackagesProductsSupplier(); // old package product supplier before change
            oldpkgps = GetSinglePackageProductSupplier(pkgid, sid); 
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                db.Entry(oldpkgps).CurrentValues.SetValues(newpkgps);
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

        public static List<PackageProductSupplierDTO> GetPackageProductSuppliers(int pkgeid)
        {
            List<PackageProductSupplierDTO> pkgeProdSuppliers = null;

            // get suppliers for a given product
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                pkgeProdSuppliers = (from pkge in db.Packages
                                     join pps in db.PackagesProductsSuppliers on pkge.PackageId equals pps.PackageId
                                     join ps in db.ProductsSuppliers on pps.ProductSupplierId equals ps.ProductSupplierId
                                     join p in db.Products on ps.ProductId equals p.ProductId
                                     join s in db.Suppliers on ps.SupplierId equals s.SupplierId
                                     where pkge.PackageId == pkgeid
                                     orderby p.ProdName ascending
                                 select new PackageProductSupplierDTO
                                 {
                                     ProductSupplierId = ps.ProductSupplierId,
                                     ProdName = p.ProdName,
                                     SupName = s.SupName
                                 }).ToList();
            }
            return pkgeProdSuppliers;
        }

        //public static List<Supplier> GetAllSuppliers(int prodid) Taking into consideration current Product
        public static List<PackageProductSupplierDTO> GetAllSupplierProducts()
        {
            /*
             * List all other suppliers which are not providing for Product (prodid)
             * and also suppliers which are not supplying to any other product because maybe they are new
             * 
             */
            List<PackageProductSupplierDTO> allProductsSuppliers = null;

            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                allProductsSuppliers = (from p in db.Products
                                        join ps in db.ProductsSuppliers on p.ProductId equals ps.ProductId
                                        join s in db.Suppliers on ps.SupplierId equals s.SupplierId
                                        orderby p.ProdName ascending, s.SupName ascending
                                        select new PackageProductSupplierDTO
                                        {
                                            ProductSupplierId = ps.ProductSupplierId,
                                            ProdName = p.ProdName,
                                            SupName = s.SupName
                                        }).ToList();

            }
            return allProductsSuppliers;
        }


        /// <summary>
        /// Add a record to the ProuctsSupplier table
        /// </summary>
        /// <param name="pid">ProductId</param>
        /// <param name="sid">SupplierId</param>
        public static bool AddProductSupplier(int pkid, int psid)
        {
            /*
             * 
             * Add product supplier to database using ProductsSupplier Identity key
            */
            bool result = true;
            PackagesProductsSupplier ppSup = null;

            if (GetSinglePackageProductSupplier(pkid, psid) == null)
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {

                    ppSup = new PackagesProductsSupplier();
                    ppSup.PackageId = pkid;
                    ppSup.ProductSupplierId = psid;
                    db.PackagesProductsSuppliers.Add(ppSup);
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
        public static bool RemovePkgProdSupplier(int pkgid, int psid)
        {
            /*
             * 
             * Remove package product supplier record by passing product id and product supplier id keys
            */
            bool result = true;

            if (GetSinglePackageProductSupplier(pkgid, psid) != null)
            {
                using (TravelExpertsContext db = new TravelExpertsContext())
                {
                    db.PackagesProductsSuppliers.Remove(GetSinglePackageProductSupplier(pkgid, psid));
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
        public static PackagesProductsSupplier GetSinglePackageProductSupplier(int pkid, int prsid)
        {
            PackagesProductsSupplier ppSup;
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                ppSup = db.PackagesProductsSuppliers.Where(ppsTable => ppsTable.PackageId == pkid &&
                    ppsTable.ProductSupplierId == prsid).FirstOrDefault();
            }

            return ppSup;

        }
    }
}
