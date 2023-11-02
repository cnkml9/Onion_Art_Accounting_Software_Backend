﻿using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using AspNetCoreHero.ThrowR;
using Microsoft.EntityFrameworkCore;

namespace ZeusApp.Application.Extensions;

public static class QueryableExtensions
{
    public static async Task<PaginatedResult<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize) where T : class
    {
        Throw.Exception.IfNull(source, nameof(source));

        pageNumber = pageNumber == 0 ? 1 : pageNumber;
        pageSize = pageSize == 0 ? 10 : pageSize;

        var count = await source.LongCountAsync();

        pageNumber = pageNumber <= 0 ? 1 : pageNumber;

        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        return PaginatedResult<T>.Success(items, 200, count, pageNumber, pageSize);
    }
}
