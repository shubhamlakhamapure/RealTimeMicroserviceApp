namespace ShoppingCart.UI.Utility
{
    public static class Environment
    {
        private static string URL = @"https://localhost:44327/api";
        public static string Base_Product_URL()
        {
            return $"{URL}/product/";
        }
        public static string Base_Category_URL()
        {
            return $"{URL}/category /";
        }
    }

}
