using System;

namespace Names
{
    internal static class HeatmapTask
    {
        public static string[] GetMonthOrDays(NameData[] names, int x, int y,int i, string[]  array)
        {
            while ( x <= i)
            {
                array[x - y] = x.ToString();
                x++;
            }
            return array;
        }

        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            var monthArr = new string[12];
            var daysArr = new string[30];
            string[] months = GetMonthOrDays(names, 1, 1, 12, monthArr);
            string[] days = GetMonthOrDays(names, 2, 2, 31, daysArr);
            double[,] heat = new double[30, 12]; 
            var i = 0;
            while (i < 30)
            {
                double[] c = new double[12];
                foreach (var name in names)
                    if (name.BirthDate.Day == i + 2)
                        c[name.BirthDate.Month - 1] = c[name.BirthDate.Month - 1] + 1;
                var j = 0;
                while (j < 12) { heat[i, j] = c[j]; j++; }
                i++;
            }
            return new HeatmapData("Пример карты интенсивностей",
            heat, days, months);
        }
    }
}