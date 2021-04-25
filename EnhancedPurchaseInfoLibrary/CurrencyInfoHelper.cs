namespace DoenaSoft.DVDProfiler.EnhancedPurchaseInfo
{
    public static class CurrencyInfoHelper
    {
        public static CurrencyInfo TryGetCurrencyInfo(int localityId)
        {
            if (localityId <= CurrencyInfo.MinID || localityId >= CurrencyInfo.MaxID)
            {
                return null;
            }

            switch (localityId)
            {
                case 32: //Argentina
                    {
                        return new CurrencyInfo(1); //Argentina (Peso)
                    }
                case 2:  //Australia
                    {
                        return new CurrencyInfo(2); //Australia (Dollar)
                    }
                case 23: //Brazil
                    {
                        return new CurrencyInfo(3); //Brazil (Real)
                    }
                case 3:  //Canada
                case 19: //Canada (Quebec)
                    {
                        return new CurrencyInfo(4); //Canada (Dollar)
                    }
                case 49: //Chile
                    {
                        return new CurrencyInfo(5); //Chile (Peso)
                    }
                case 6:  //China
                    {
                        return new CurrencyInfo(6); //China (Renminbi)
                    }
                case 36: //Czech Republic
                    {
                        return new CurrencyInfo(33); //Czech Republic (Koruna)
                    }
                case 14: //"Denmark"
                    {
                        return new CurrencyInfo(7); //Denmark (Krone)
                    }
                case 45: //Estonia
                    {
                        return new CurrencyInfo(35); //Estonia (Kroon)
                    }
                case 4:  //United Kingdom
                    {
                        return new CurrencyInfo(9); //Great Britain (Pound)
                    }
                case 21: //Hong Kong
                    {
                        return new CurrencyInfo(10); //Hong Kong (Dollar)
                    }
                case 34: //Hungary
                    {
                        return new CurrencyInfo(31); //Hungary (Forint)
                    }
                case 26: //Iceland
                    {
                        return new CurrencyInfo(11); //Iceland (Krona)
                    }
                case 39: //India
                    {
                        return new CurrencyInfo(12); //India (Rupee)
                    }
                case 27: //Indonesia
                    {
                        return new CurrencyInfo(13); //Indonesia (Rupiah)
                    }
                case 24: //Israel
                    {
                        return new CurrencyInfo(14); //Israel (Shekel)
                    }
                case 17: //Japan
                    {
                        return new CurrencyInfo(15); //Japan (Yen)
                    }
                case 37: //Malaysia
                    {
                        return new CurrencyInfo(29); //Malaysia (Ringgit)
                    }
                case 25: //Mexico
                    {
                        return new CurrencyInfo(16); //Mexico (New Peso)
                    }
                case 1:  //New Zealand
                    {
                        return new CurrencyInfo(17); //New Zealand (Dollar)
                    }
                case 12: //Norway
                    {
                        return new CurrencyInfo(18); //Norway (Krone)
                    }
                case 43: //Philippines
                    {
                        return new CurrencyInfo(19); //Philippines (Peso)
                    }
                case 29: //Poland
                    {
                        return new CurrencyInfo(32); //Poland (Zloty)
                    }
                case 46: //Romania
                    {
                        return new CurrencyInfo(36); //Romania (New leu)
                    }
                case 48: //Russia
                    {
                        return new CurrencyInfo(20); //Russia (Rouble)
                    }
                case 35: //Singapore
                    {
                        return new CurrencyInfo(21); //Singapore (Dollar)
                    }
                //case 33: //Slovakia - part of the Euro since 2009
                //    {
                //        return new CurrencyInfo(37); //Slovakia (Koruna)
                //    }
                case 20: //South Africa
                    {
                        return new CurrencyInfo(22); //South Africa (Rand)
                    }
                case 18: //South Korea
                    {
                        return new CurrencyInfo(23); //South Korea (Won)
                    }
                case 11: //Sweden
                    {
                        return new CurrencyInfo(24); //Sweden (Krona)
                    }
                case 22: //Switzerland
                    {
                        return new CurrencyInfo(25); //Switzerland (Franc)
                    }
                case 28: //Taiwan
                    {
                        return new CurrencyInfo(26); //Taiwan (Dollar)
                    }
                case 38: //Thailand
                    {
                        return new CurrencyInfo(27); //Thailand (Baht)
                    }
                case 31: //Turkey
                    {
                        return new CurrencyInfo(28); //Turkey (1 million Lira)
                    }
                case 0:  //United States
                    {
                        return new CurrencyInfo(0); //United States (Dollar)
                    }
                case 42: //Vietnam
                    {
                        return new CurrencyInfo(34); //Vietnam (Dong)
                    }
                case 40: //Austria
                case 30: //Belgium
                case 16: //Finland
                case 8:  //France
                case 5:  //Germany
                case 41: //Greece
                case 44: //Ireland
                case 13: //Italy
                case 9:  //Netherlands
                case 15: //Portugal
                case 33: //Slovakia - part of the Euro since 2009
                case 10: //Spain
                    {
                        return new CurrencyInfo(8); //Europe (Euro)
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
