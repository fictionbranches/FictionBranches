using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace FictionBranches.Web.Extensions;

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum enumValue)
    {
        var member = enumValue.GetType()
            .GetMember(enumValue.ToString())
            .FirstOrDefault();
        return member?.GetCustomAttribute<DisplayAttribute>()?.GetName() ?? "";
    }
    public static string GetDisplayShortName(this Enum enumValue)
    {
        var member = enumValue.GetType()
            .GetMember(enumValue.ToString())
            .FirstOrDefault();
        return member?.GetCustomAttribute<DisplayAttribute>()?.GetShortName() ?? "";
    }

    public static T[] GetAllValues<T>() where T : Enum
    {
        return Enum.GetValues(typeof(T)).Cast<T>().ToArray();
    }
}

public static class LinqExtensions
{
    public static IOrderedQueryable<TSource> OrderByDirection<TSource, TKey>(this IQueryable<TSource> source,
        SortDirection sortDirection,
        Expression<Func<TSource, TKey>> keySelector) => sortDirection switch
    {
        SortDirection.Descending => source.OrderByDescending(keySelector),
        _ => source.OrderBy(keySelector)
    };
}

public enum SortDirection
{
    Ascending, Descending, None
}

public static class StringExtensions
{
    public static bool EqualsIgnoreCase(this string? a, string? b)
    {
        return a is null ? b is null : string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
    }
}

public static class HttpContextExtensions
{
    public static string? GetPathWithQuery(this HttpContext? httpContext)
    {
        return httpContext?.Request == null ? null : $"{httpContext.Request.Path}{httpContext.Request.QueryString}";
    }

    public static string ToQueryString(this Dictionary<string, object?> queryParams)
    {
        if (queryParams.Count == 0)
            return "";
        return "?" + string.Join('&', queryParams.Select(e => ToQueryStringItem(e.Key, e.Value)));
    }

    private static string ToQueryStringItem(string key, object? value)
    {
        var escapedKey = Uri.EscapeDataString(key);
        if (value == null)
            return escapedKey;
        var valueString = value?.ToString();
        return string.IsNullOrWhiteSpace(valueString) ? escapedKey : $"{escapedKey}={Uri.EscapeDataString(valueString)}";
    }
}