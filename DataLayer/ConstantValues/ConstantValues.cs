namespace RestoSys
{
    /// <summary>
    /// Stock Entry for manufacture goods, add in the inv_stock
    /// </summary>

    public static class ItemType
    {
        public static string Consumable = "C";
        public static string HumanResource = "H";
        public static string Ingredient = "I";
        public static string Lend = "L";
        public static string Manufacture = "M";
        public static string Retail = "R";
        public static string Service = "S";
    }

    public static class StockType
    {
        public const string Damaged = "D";
        public const string IngredientConsumed = "C";
        public const string Lost = "L";
        public const string Purchase = "P";
        public const string PurchaseReturn = "N";
        public const string Sales = "S";
        public const string SalesReturn = "R";

        //Ingredient consumed
        public const string StockEntry = "E";//Manufactured

        public static string GetEntryTypeText(string stockType)
        {
            switch (stockType)
            {
                case StockType.Purchase:
                    return "Purchase";

                case StockType.Lost:
                    return "Lost";

                case StockType.Sales:
                    return "Sales";

                case StockType.Damaged:
                    return "Damage";

                case StockType.SalesReturn:
                    return "Sales return";

                case StockType.PurchaseReturn:
                    return "Purchase Return";

                case StockType.IngredientConsumed:
                    return "Stock Clearance (Ingredients are consumed)";

                case StockType.StockEntry:
                    return "Stock Entry(Product Manufactured goods is ready for sales)";

                default:
                    break;
            }
            return "";
        }

        internal static string GetStockSign(string stockType)
        {
            switch (stockType)
            {
                case StockType.Purchase:
                    return "+";

                case StockType.Lost:
                    return "-";

                case StockType.Sales:
                    return "-";

                case StockType.Damaged:
                    return "-";

                case StockType.SalesReturn:
                    return "+";

                case StockType.PurchaseReturn:
                    return "-";

                case StockType.IngredientConsumed:
                    return "-";

                case StockType.StockEntry:
                    return "+";
            }
            return "";
        }
    }
}