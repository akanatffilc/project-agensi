using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class AgensiCompareEx
{
    /// <summary>
    /// IComparableを実装している型について、valueがminとmaxの範囲に含まれているかどうかを返す
    /// </summary>
    /// <typeparam name="T">IComparableを実装している型</typeparam>
    /// <param name="value">比較対象</param>
    /// <param name="min">最小</param>
    /// <param name="max">最大</param>
    /// <returns>valueがminとmaxの範囲に含まれているかどうか</returns>
    public static bool InBetween<T>(this T value, T min, T max)
        where T : IComparable<T>
    {
        return value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
    }

}
