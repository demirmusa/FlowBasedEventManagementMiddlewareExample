using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.EFCoreShared
{
    public static class EFCoreSharedDIExtensions
    {
        public static IServiceCollection AddGenericRepositoryScoped(this IServiceCollection collection)
        {
            collection.AddScoped(typeof(Example.EFCoreShared.interfaces.IGenericRepository<,>),
                typeof(Example.EFCoreShared.GenericRepository<,>));
            return collection;
        }
        public static IServiceCollection AddGenericRepositoryTransient(this IServiceCollection collection)
        {
            collection.AddTransient(typeof(Example.EFCoreShared.interfaces.IGenericRepository<,>),
                typeof(Example.EFCoreShared.GenericRepository<,>));
            return collection;
        }
        public static IServiceCollection AddGenericRepositorySingleton(this IServiceCollection collection)
        {
            collection.AddSingleton(typeof(Example.EFCoreShared.interfaces.IGenericRepository<,>),
                typeof(Example.EFCoreShared.GenericRepository<,>));
            return collection;
        }
    }
}
