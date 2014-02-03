using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class AgensiDateTimeEx
{
    /// <summary>
    /// 残り時間を表す文字列を返す
    /// </summary>
    public static string ToRemainingTimeString(this DateTime now, DateTime to)
    {
        var span = to - now;

        if (span.TotalSeconds <= 0)
            return "";

        if (span.TotalMinutes < 1)
            return string.Format("{0}秒", span.Seconds);

        if (span.TotalHours < 1)
            return string.Format("{0}分{1}", span.Minutes, span.Seconds > 0 ? string.Format("{0}秒", span.Seconds) : "");

        if (span.TotalDays < 1)
            return string.Format("{0}時間{1}", span.Hours, span.Minutes > 0 ? string.Format("{0}分", span.Minutes) : "");

        return string.Format("{0}日{1}{2}", span.Days, span.Hours > 0 ? string.Format("と{0}時間", span.Hours) : "", span.Minutes > 0 ? string.Format("{0}分", span.Minutes) : "");
    }

    public static DateTime ToFirstDayOfMonth(this DateTime now)
    {
        return now.AddDays((-1) * (now.Day - 1));
    }

    /// <summary>
    /// 指定日時を起点として何週経過しているかを取得する
    /// </summary>
    public static int GetWeekCountByBaseDate(this DateTime now, DateTime baseDate)
    {
        return (int)((now - baseDate).TotalDays / 7);
    }

    /// <summary>
    /// Agensiで使用する書式で日時を返す
    /// </summary>
    public static string ToApplicationTimeString(this DateTime now)
    {
        return now.Date == DateTime.Today ? now.ToString("H:mm") : now.ToString("M/d");
    }

    /// <summary>
    /// 最終ログインで使用する書式で日時を返す
    /// </summary>
    public static string ToLastLoginTimeString(this DateTime dateTime)
    {
        var span = DateTime.Now - dateTime;

        if (span.TotalMinutes <= 5)
            return "5分以内";

        if (span.TotalMinutes <= 10)
            return "10分以内";

        if (span.TotalMinutes <= 30)
            return "30分以内";

        if (span.TotalHours <= 1)
            return "1時間以内";

        if (span.TotalHours <= 3)
            return "3時間以内";

        if (span.TotalHours <= 6)
            return "6時間以内";

        if (span.TotalHours <= 12)
            return "12時間以内";

        if (span.TotalHours <= 24)
            return "24時間以内";

        return "1日以上";
    }

    /// <summary>
    /// 指定日時を超えているか
    /// </summary>
    public static bool IsOver(this DateTime now, DateTime dateTime)
    {
        return dateTime <= now;
    }

    /// <summary>
    /// 残り時間を算出
    /// </summary>
    public static int GetRemainingSeconds(this DateTime now, DateTime dateTime)
    {
        var second = (int)(dateTime - now).TotalSeconds;
        return second <= 0 ? 0 : second;
    }

    public static bool InBetweenOrNull(this DateTime value, DateTime? min, DateTime? max)
    {
        return (min == null || value.CompareTo(min.Value) >= 0) && (max == null || value.CompareTo(max.Value) <= 0);
    }

    public static bool InBetweenOrNull(this DateTime value, DateTime min, DateTime? max)
    {
        return value.CompareTo(min) >= 0 && (max == null || value.CompareTo(max.Value) <= 0);
    }

    public static bool InBetweenOrNull(this DateTime value, DateTime? min, DateTime max)
    {
        return value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
    }
}
