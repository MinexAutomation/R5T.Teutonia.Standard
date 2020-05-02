using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Lombardy.Standard;

using R5T.Teutonia.Default;


namespace R5T.Teutonia.Standard
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="IFileSystemCloningOperator"/> service.
        /// </summary>
        public static IServiceCollection AddFileSystemCloningOperator(this IServiceCollection services)
        {
            services.AddDefaultFileSystemCloningOperator(
                services.AddDefaultFileSystemCloningDifferencerAction(),
                services.AddStringlyTypedPathOperatorAction());

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IFileSystemCloningOperator"/> service.
        /// </summary>
        public static IServiceCollection AddFileSystemCloningOperator<TFileSystemCloningOperator>(this IServiceCollection services)
            where TFileSystemCloningOperator: IFileSystemCloningOperator
        {
            services.AddFileSystemCloningOperator();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IFileSystemCloningOperator"/> service.
        /// </summary>
        public static ServiceAction<IFileSystemCloningOperator> AddFileSystemCloningOperatorAction(this IServiceCollection services)
        {
            var serviceAction = new ServiceAction<IFileSystemCloningOperator>(() => services.AddFileSystemCloningOperator());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="IFileSystemCloningDifferencer"/> service.
        /// </summary>
        public static IServiceCollection AddFileSystemCloningDifferencer(this IServiceCollection services)
        {
            services.AddDefaultFileSystemCloningDifferencer();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IFileSystemCloningDifferencer"/> service.
        /// </summary>
        public static ServiceAction<IFileSystemCloningDifferencer> AddFileSystemCloningDifferencerAction(this IServiceCollection services)
        {
            var serviceAction = new ServiceAction<IFileSystemCloningDifferencer>(() => services.AddFileSystemCloningDifferencer());
            return serviceAction;
        }
    }
}
