using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Group4_TravelExperts_DA_GUI
{
    /// <summary>
    /// A repository of validation methods
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// checks if textbox has anything in it
        /// </summary>
        /// <param name="tb">text box to validate</param>
        /// <returns>true if valid, and false if not</returns>
        public static bool IsPresent(TextBox tb)
        {
            bool isValid = true;
            if(String.IsNullOrEmpty(tb.Text))// empty
            {
                MessageBox.Show(tb.Tag + " is required");
                tb.Focus(); 
                isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// checks if user selected from combo box
        /// </summary>
        /// <param name="cb">combo box to validate</param>
        /// <returns>true is selected, and false if not</returns>
        public static bool IsSelected(ComboBox cb)
        {
            bool isValid = true;
            if (cb.SelectedIndex == -1)// no selection
            {
                MessageBox.Show(cb.Tag + " has to be selected");
                cb.Focus();
                isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// checks if a textbox contains whole number that is greater than or equal to zero
        /// </summary>
        /// <param name="tb">textbox to validate</param>
        /// <returns>true if valid, and false if not</returns>
        public static bool IsNonNegativeInt(TextBox tb)
        {
            bool isValid = true;
            int value;
            if(!Int32.TryParse(tb.Text, out value)) // if the content cannot be  parsed as int
            {
                MessageBox.Show(tb.Tag + " has to be a whole number");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }
            else if(value < 0 ) // int, but negative
            {
                MessageBox.Show(tb.Tag + " cannot be negative");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// checks if a textbox contains whole number within range
        /// </summary>
        /// <param name="tb">textbox to validate</param>
        /// <param name="minValue">minimum value allowed</param>
        /// <param name="maxValue">maximum value allowed</param>
        /// <returns>true if valid, and false if not</returns>
        public static bool IsIntInRange(TextBox tb, int minValue, int maxValue)
        {
            bool isValid = true;
            int value;
            if (!Int32.TryParse(tb.Text, out value)) // if the content cannot be  parsed as int
            {
                MessageBox.Show(tb.Tag + " has to be a whole number");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }
            else if (value < minValue || value > maxValue) // int, but outside the range
            {
                MessageBox.Show(tb.Tag + $" has to be between {minValue} and {maxValue}");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// checks if a textbox contains a number (possibly with decimal part)
        /// that is greater than or equal to zero
        /// </summary>
        /// <param name="tb">textbox to validate</param>
        /// <returns>true if valid, and false if not</returns>
        public static bool IsNonNegativeDouble(TextBox tb)
        {
            bool isValid = true;
            double value;
            if (!Double.TryParse(tb.Text, out value)) // if the content cannot be  parsed as double
            {
                MessageBox.Show(tb.Tag + " has to be a number");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }
            else if (value < 0) // double, but negative
            {
                MessageBox.Show(tb.Tag + " cannot be negative");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }
            return isValid;
        }


        /// <summary>
        /// checks if a textbox contains a number (possibly with decimal part)
        /// that is greater than or equal to zero
        /// </summary>
        /// <param name="tb">textbox to validate</param>
        /// <returns>true if valid, and false if not</returns>
        public static bool IsNonNegativeDecimal(TextBox tb)
        {
            bool isValid = true;
            decimal value;
            if (!Decimal.TryParse(tb.Text, out value)) // if the content cannot be  parsed as double
            {
                MessageBox.Show(tb.Tag + " has to be a number");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }
            else if (value < 0) // double, but negative
            {
                MessageBox.Show(tb.Tag + " cannot be negative");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// checks if a textbox contains decimal number within range
        /// </summary>
        /// <param name="tb">textbox to validate</param>
        /// <param name="minValue">minimum value allowed</param>
        /// <param name="maxValue">maximum value allowed</param>
        /// <returns>true if valid, and false if not</returns>
        public static bool IsDecimalInRange(TextBox tb, decimal minValue, decimal maxValue)
        {
            bool isValid = true;
            decimal value;
            if (!Decimal.TryParse(tb.Text, out value)) // if the content cannot be  parsed as decimal
            {
                MessageBox.Show(tb.Tag + " has to be a decimal number");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }
            else if (value < minValue || value > maxValue) // int, but outside the range
            {
                MessageBox.Show(tb.Tag + $" has to be between {minValue} and {maxValue}");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }
            return isValid;
        }
        /// <summary>
        /// IsValidProdCode: valid Product Code is 4 upper alpha characters followed by 2 digits (example: ELEC10) 
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static bool IsValidProdCode(TextBox tb)
        {
            bool isValid = true;
            if (!Regex.IsMatch(tb.Text, @"^[A-Z]{4}[0-9]{2}$"))
            {
                MessageBox.Show(tb.Tag + " should be 4 UPPER alpha characters followed by 2 digits.");
                tb.SelectAll();
                tb.Focus();
                isValid = false;
            }
            return isValid;
        }

    }
}
