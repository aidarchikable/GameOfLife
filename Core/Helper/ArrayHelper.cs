namespace Core.Helper
{
    public static class ArrayHelper
    {
        public static T[] Join<T>(this T[,] value)
        {
            var result = new T[value.Length];
            var i = 0;
            foreach (var cell in value)
            {
                result[i] = cell;
                i++;
            }

            return result;
        }
    }
}