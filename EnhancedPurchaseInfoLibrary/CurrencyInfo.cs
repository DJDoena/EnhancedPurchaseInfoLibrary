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
        public const ushort MinID = 0;

        public const ushort MaxID = 37;

        public int Id { get; }

        public ushort Digits { get; }

        public string Name { get; }

        public bool Space { get; }

        public bool Suffix { get; }

        public string Symbol { get; }

        public string Type { get; }

        public bool IsEmpty { get; }

        public static CurrencyInfo Empty { get; }

        public static CultureInfo DefaultFormatCulture { get; }

        public CultureInfo FormatCulture { get; set; }

        static CurrencyInfo()
        {
            Empty = new CurrencyInfo();

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

        public CurrencyInfo(int id)
        {
            const string Prefix = "CURRENCY_";

            if (id < MinID || id > MaxID)
            {
                throw (new ArgumentException("Invalid ID!", "id"));
            }

            Id = id;

            var name = Prefix + id;

            Digits = ushort.Parse(CurrencyDigits.ResourceManager.GetString(name));

            Name = CurrencyName.ResourceManager.GetString(name);

            Space = bool.Parse(CurrencySpace.ResourceManager.GetString(name));

            Suffix = bool.Parse(CurrencySuffix.ResourceManager.GetString(name));

            Symbol = CurrencySymbol.ResourceManager.GetString(name);

            Type = CurrencyType.ResourceManager.GetString(name);

            IsEmpty = false;

            FormatCulture = DefaultFormatCulture;
        }

        public string GetFormattedValue(long longValue)
        {
            var decimalValue = longValue / Constants.DigitDivider;

            var stringValue = GetFormattedValue(decimalValue);

            return stringValue;
        }

        public string GetFormattedValue(decimal decimalValue)
        {
            const int CURRENCY_XBT = 30; //from PluginInterface.5.cs

            var stringValue = Id == CURRENCY_XBT
                ? GetFormattedBitcoin(decimalValue)
                : GetFormattedValueInternal(decimalValue);

            return stringValue;
        }

        public string GetFormattedPlainValue(long longValue)
        {
            decimal decimalValue = longValue / Constants.DigitDivider;

            var stringValue = GetFormattedPlainValue(decimalValue);

            return stringValue;
        }

        public string GetFormattedPlainValue(decimal decimalValue) => Math.Round(decimalValue, Digits).ToString("F" + Digits, FormatCulture);

        private string GetFormattedValueInternal(decimal decimalValue)
        {
            var result = new StringBuilder();

            if (Suffix == false)
            {
                result.Append(Symbol);

                if (Space)
                {
                    result.Append(" ");
                }
            }

            var number = GetFormattedPlainValue(decimalValue);

            result.Append(number);

            if (Suffix)
            {
                if (Space)
                {
                    result.Append(" ");
                }

                result.Append(Symbol);
            }

            return result.ToString();
        }

        private string GetFormattedBitcoin(decimal decimalValue)
        {
            decimalValue /= 100_000_000m;

            var stringValue = GetFormattedValueInternal(decimalValue);

            return stringValue;
        }

        public string GetFormattedValue(double doubleValue) => GetFormattedValue(Convert.ToDecimal(doubleValue));

        public override int GetHashCode() => Id.GetHashCode();

        public override bool Equals(object obj) => Equals(obj as CurrencyInfo);

        #region IComparable<CurrencyInfo> Members

        public int CompareTo(CurrencyInfo other) => other != null ? Name.CompareTo(other.Name) : -1;

        #endregion

        #region IEquatable<CurrencyInfo> Members

        public bool Equals(CurrencyInfo other) => other != null ? Id == other.Id : false;

        #endregion
    }
}