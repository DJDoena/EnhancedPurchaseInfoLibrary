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

        public static CultureInfo DefaultFormatCulture { get; set; }

        public CultureInfo FormatCulture { get; set; }

        static CurrencyInfo()
        {
            Empty = new CurrencyInfo();

            DefaultFormatCulture = System.Threading.Thread.CurrentThread.CurrentCulture;
        }

        private CurrencyInfo()
        {
            this.Id = -1;

            this.Digits = 0;

            this.Name = string.Empty;

            this.Space = false;

            this.Suffix = false;

            this.Symbol = string.Empty;

            this.Type = string.Empty;

            this.IsEmpty = true;

            this.FormatCulture = DefaultFormatCulture;
        }

        public CurrencyInfo(int id)
        {
            const string Prefix = "CURRENCY_";

            if (id < MinID || id > MaxID)
            {
                throw (new ArgumentException("Invalid ID!", "id"));
            }

            this.Id = id;

            var name = Prefix + id;

            this.Digits = ushort.Parse(CurrencyDigits.ResourceManager.GetString(name));

            this.Name = CurrencyName.ResourceManager.GetString(name);

            this.Space = bool.Parse(CurrencySpace.ResourceManager.GetString(name));

            this.Suffix = bool.Parse(CurrencySuffix.ResourceManager.GetString(name));

            this.Symbol = CurrencySymbol.ResourceManager.GetString(name);

            this.Type = CurrencyType.ResourceManager.GetString(name);

            this.IsEmpty = false;

            this.FormatCulture = DefaultFormatCulture;
        }

        public string GetFormattedValue(long longValue)
        {
            var decimalValue = longValue / Constants.DigitDivider;

            var stringValue = this.GetFormattedValue(decimalValue);

            return stringValue;
        }

        public string GetFormattedValue(decimal decimalValue)
        {
            const int CURRENCY_XBT = 30; //from PluginInterface.5.cs

            var stringValue = this.Id == CURRENCY_XBT
                ? this.GetFormattedBitcoin(decimalValue)
                : this.GetFormattedValueInternal(decimalValue);

            return stringValue;
        }

        public string GetFormattedPlainValue(long longValue)
        {
            var decimalValue = longValue / Constants.DigitDivider;

            var stringValue = this.GetFormattedPlainValue(decimalValue);

            return stringValue;
        }

        public string GetFormattedPlainValue(decimal decimalValue) => Math.Round(decimalValue, this.Digits).ToString("F" + this.Digits, this.FormatCulture);

        private string GetFormattedValueInternal(decimal decimalValue)
        {
            var result = new StringBuilder();

            if (this.Suffix == false)
            {
                result.Append(this.Symbol);

                if (this.Space)
                {
                    result.Append(" ");
                }
            }

            var number = this.GetFormattedPlainValue(decimalValue);

            result.Append(number);

            if (this.Suffix)
            {
                if (this.Space)
                {
                    result.Append(" ");
                }

                result.Append(this.Symbol);
            }

            return result.ToString();
        }

        private string GetFormattedBitcoin(decimal decimalValue)
        {
            decimalValue /= 100_000_000m;

            var stringValue = this.GetFormattedValueInternal(decimalValue);

            return stringValue;
        }

        public string GetFormattedValue(double doubleValue) => this.GetFormattedValue(Convert.ToDecimal(doubleValue));

        public override int GetHashCode() => this.Id.GetHashCode();

        public override bool Equals(object obj) => this.Equals(obj as CurrencyInfo);

        #region IComparable<CurrencyInfo> Members

        public int CompareTo(CurrencyInfo other) => other != null ? this.Name.CompareTo(other.Name) : -1;

        #endregion

        #region IEquatable<CurrencyInfo> Members

        public bool Equals(CurrencyInfo other) => other != null ? this.Id == other.Id : false;

        #endregion
    }
}