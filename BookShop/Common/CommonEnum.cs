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

        #region Account Type
        public enum AccountType
        {
            [DisplayValue("Church")]
            Church = 1,
            [DisplayValue("Individual")]
            Individual = 2,
            [DisplayValue("Organization")]
            Organization = 3,
            [DisplayValue("Y-Church")]
            YChurch = 4,
            [DisplayValue("Y-Individual")]
            YIndividual = 5,
            [DisplayValue("Y-Organization")]
            YOrganization = 6
        }
        #endregion

        #region Payment Method
        public enum PaymentMethod
        {
            [DisplayValue("Cash")]
            Cash = 1,
            [DisplayValue("Cheque")]
            Cheque = 2,
            [DisplayValue("Others")]
            Others = 3,
            [DisplayValue("Master Card")]
            MasterCard = 4,
            [DisplayValue("Visa")]
            Visa = 5
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
