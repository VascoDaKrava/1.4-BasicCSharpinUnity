namespace Kravchuk
{
    public static class L5_2
    {
        // 5.2 Реализовать метод расширения для поиска количество символов в строке
        /// <summary>
        /// Calculate quantity of chars ch in the string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ch"></param>
        /// <returns></returns>
        public static int QuantityChars(this string str, char ch)
        {
            int quantity = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ch)
                    quantity++;
            }
            return quantity;
        }
    }
}