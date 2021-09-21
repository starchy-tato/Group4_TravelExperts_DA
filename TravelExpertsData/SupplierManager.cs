using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public static class SupplierManager
    {
        public static void AddSupplier(Supplier s)
        {
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                db.Suppliers.Add(s);
                db.SaveChanges();
            }
        }

        public static void UpdateSupplier(Supplier newSupplier)
        {
            Supplier oldSupplier = new Supplier(); // old package product supplier before change
            using (TravelExpertsContext db = new TravelExpertsContext())
            {
                oldSupplier = db.Suppliers.Find(newSupplier.SupplierId);
                db.Entry(oldSupplier).CurrentValues.SetValues(newSupplier);
                db.SaveChanges();
            }
        }
    }
}
