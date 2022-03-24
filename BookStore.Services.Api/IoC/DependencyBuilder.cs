using BooksStore.Infraestructure.DataAccess.Repositories;
using BookStore.Domain.Contracts;
using BookStore.Domain.Entities;

namespace BookStore.Services.Api.IoC
{
    public static class DependencyBuilder
    {
        public static void DependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<Book>, BookRepository>();
            services.AddScoped<IQueryRepository<Category>, CategoryRepository>();
        }
    }
}
