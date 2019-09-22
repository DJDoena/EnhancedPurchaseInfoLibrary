using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using DoenaSoft.DVDProfiler.EnhancedPurchaseInfo.Resources;

namespace DoenaSoft.DVDProfiler.EnhancedPurchaseInfo
{
    [DebuggerDisplay("DenominationType={Type} DenominationDesc={Name}")]
    public sealed class CurrencyInfo : IComparable<CurrencyInfo>, IEquatable<CurrencyInfo>
    {
        public readonly Int32 Id;

        public readonly UInt16 Digits;

        public readonly string Name;

        public readonly Boolean Space;

        public readonly Boolean Suffix;

        public readonly string Symbol;

        public readonly string Type;

        public const UInt16 MinID = 0;

        public const UInt16 MaxID = 37;

        public readonly Boolean IsEmpty;

        public static readonly CurrencyInfo Empty = new CurrencyInfo();

        public static CultureInfo DefaultFormatCulture { get; set; }

        public CultureInfo FormatCulture { get; set; }

        static CurrencyInfo()
        {
            DefaultFormatCulture = System.Threading.Thread.CurrentThread.CurrentCulture;
        }

        private CurrencyInfo()
        {
            Id = -1;

            Digits = 0;

            Name = string.Empty;

            Space = false;

            Suffix = false;

            Symbol = string.Empty;

            Type = string.Empty;

            IsEmpty = true;

            FormatCulture = DefaultFormatCulture;
        }

        public CurrencyInfo(Int32 id)
        {
            const string Prefix = "CURRENCY_";

            if ((id < MinID) || (id > MaxID))
            {
                throw (new ArgumentException("Invalid ID!", "id"));
            }

            Id = id;

            string name = Prefix + id;

            Digits = UInt16.Parse(CurrencyDigits.ResourceManager.GetString(name));

            Name = CurrencyName.ResourceManager.GetString(name);

            Space = Boolean.Parse(CurrencySpace.ResourceManager.GetString(name));

            Suffix = Boolean.Parse(CurrencySuffix.ResourceManager.GetString(name));

            Symbol = CurrencySymbol.ResourceManager.GetString(name);

            Type = CurrencyType.ResourceManager.GetString(name);

            IsEmpty = false;

            FormatCulture = DefaultFormatCulture;
        }

        public string GetFormattedValue(Int64 longValue)
        {
            Decimal decimalValue = longValue / Constants.DigitDivider;

            string stringValue = GetFormattedValue(decimalValue);

            return (stringValue);
        }

        public string GetFormattedValue(Decimal decimalValue)
        {
            const Int32 CURRENCY_XBT = 30; //from PluginInterface.5.cs

            string stringValue;
            if (Id == CURRENCY_XBT)
            {
                stringValue = GetFormattedBitcoin(decimalValue);
            }
            else
            {
                stringValue = GetFormattedValueInternal(decimalValue);
            }

            return (stringValue);
        }

        public string GetFormattedPlainValue(Int64 longValue)
        {
            Decimal decimalValue = ((Decimal)longValue) / Constants.DigitDivider;

            string stringValue = GetFormattedPlainValue(decimalValue);

            return (stringValue);
        }

        public string GetFormattedPlainValue(Decimal decimalValue)
            => (Math.Round(decimalValue, Digits).ToString("F" + Digits, FormatCulture));

        private string GetFormattedValueInternal(Decimal decimalValue)
        {
            StringBuilder result = new StringBuilder();

            if (Suffix == false)
            {
                result.Append(Symbol);

                if (Space)
                {
                    result.Append(" ");
                }
            }

            string number = GetFormattedPlainValue(decimalValue);

            result.Append(number);

            if (Suffix)
            {
                if (Space)
                {
                    result.Append(" ");
                }

                result.Append(Symbol);
            }

            return (result.ToString());
        }

        private string GetFormattedBitcoin(Decimal decimalValue)
        {
            decimalValue = decimalValue / 100000000m;

            string stringValue = GetFormattedValueInternal(decimalValue);

            return (stringValue);
        }

        public string GetFormattedValue(Double doubleValue)
            => (GetFormattedValue(Convert.ToDecimal(doubleValue)));

        public override Int32 GetHashCode()
            => (Id.GetHashCode());

        public override Boolean Equals(Object obj)
            => (Equals(obj as CurrencyInfo));

        #region IComparable<CurrencyInfo> Members

        public Int32 CompareTo(CurrencyInfo other)
            => ((other != null) ? (Name.CompareTo(other.Name)) : -1);

        #endregion

        #region IEquatable<CurrencyInfo> Members

        public Boolean Equals(CurrencyInfo other)
            => ((other != null) ? (Id == other.Id) : false);

        #endregion
    }
}