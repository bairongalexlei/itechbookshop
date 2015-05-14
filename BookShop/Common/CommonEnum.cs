using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Common
{
    public class CommonEnum
    {
        #region Receipt Type
        public enum ReceiptType
        {
            [DisplayValue("Individual")]
            Individual = 1,
            [DisplayValue("Organization")]
            Organization = 2,
            [DisplayValue("Others")]
            Others = 3
        }
        #endregion

        #region Status
        public enum Status
        {
            [DisplayValue("Active")]
            Active = 1,
            [DisplayValue("Deleted")]
            Deleted = 2
        }
        #endregion

        #region Status
        public enum UserType
        {
            [DisplayValue("CFO")]
            CFO = 1,
            [DisplayValue("Other")]
            Other = 2
        }
        #endregion
    }
}
