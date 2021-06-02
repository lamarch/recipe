namespace Recipe.Standard.Extensions
{
    public static class Long
    {
        public static void BoundAdd(this ref long nb, long l)
        {
            if (nb + l <= long.MaxValue)
            {
                nb += l;
            }
            else
            {
                nb = long.MaxValue;
            }
        }
    }
}