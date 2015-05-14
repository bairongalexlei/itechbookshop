using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Common
{
    class StringEnum
    {

    }

    #region Class DisplayValueAttribute

    /// <summary>
    /// Simple attribute class for storing String Values
    /// </summary>
    public class DisplayValueAttribute : Attribute
    {
        private string _value;

        /// <summary>
        /// Creates a new <see cref="DisplayValueAttribute"/> instance.
        /// </summary>
        /// <param name="value">Value.</param>
        public DisplayValueAttribute(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value></value>
        public string Value
        {
            get { return _value; }
        }
    }

    #endregion
}
