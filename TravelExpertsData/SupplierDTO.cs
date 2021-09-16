using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public class SupplierDTO
    {
        public int SupplierId { get; set; }
        public string SupName { get; set; }

        public string SupplierName()
        {
            return SupName;
        }
    }
}
