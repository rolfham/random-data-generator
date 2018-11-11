using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using MemoryCache = System.Runtime.Caching.MemoryCache;

namespace random_data_generator.RandomData
{
    public static class LookupHelper
    {
        public static MemoryCache Cache = MemoryCache.Default;
        public static Entity GetRandomRecord(string logicalName, IOrganizationService service, Random r)
        {
            if (Cache.Get(logicalName) is List<Entity> list)
            {
                return list[r.Next(0, list.Count - 1)];
            }

            var query = new QueryExpression(logicalName) { NoLock = true, ColumnSet = new ColumnSet(false) };
            var result = service.RetrieveMultiple(query).Entities.ToList();

            var policy = new CacheItemPolicy();
            Cache.Set(logicalName, result, policy);
     
            return result[r.Next(0, result.Count - 1)];

        }

    }
}
