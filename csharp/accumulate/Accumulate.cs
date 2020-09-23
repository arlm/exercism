using System;
using System.Collections.Generic;

public static class AccumulateExtensions
{
    public static IEnumerable<TResult> Accumulate<TSource, TResult>(
        this IEnumerable<TSource> collection,
        Func<TSource, TResult> func
    )
    {
        foreach (TSource item in collection)
        {
            yield return func(item);
        }
    }

    public static IEnumerable<TResult> AccumulateNonLazy<TSource, TResult>(
        this IEnumerable<TSource> collection,
        Func<TSource, TResult> func
    )
    {
        var result = new List<TResult>();
        
        foreach(TSource item in collection)
        {
            result.Add(func(item));
        }

        return result;    
    }
}