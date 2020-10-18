using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

using lmgtdomain.Book.Repository;
using lmgtdomain.Book.Converter;
using lmgtdomain.Book.Validator;
using lmgtpersistence.Domain.Book;
namespace lmgtdiregister.Domain
{
    public class BookDIRegisterForWeb : IForWeb
    {
        public void Register(IServiceCollection services)
        {
            _Repository(services);
            _Validator(services);
            _Converter(services);
        }

        private void _Repository(IServiceCollection services)
        {
            services.AddTransient<IBookCategoryRepository,BookCategoryRepository>();
            services.AddTransient<IBookRepository ,BookRepository>();
            services.AddTransient<IBookSettingsRepository,BookSettingsRepository>();
            services.AddTransient<ILendBookRepository,LendBookRepository>();
            services.AddTransient<IBookOutputModelRepository,BookOutputModelRepository>();
        }

        private void _Validator(IServiceCollection services)
        {
            services.AddTransient<IBookValidator,BookAuthorValidator>();
            services.AddTransient<IBookValidator,BookCategoryValidator>();
            services.AddTransient<IBookValidator,BookCoverImageValidator>();
            services.AddTransient<IBookValidator,BookDescriptionValidator>();
            services.AddTransient<IBookValidator,BookNameValidator>();
            services.AddTransient<IBookValidator,BookPublisherValidator>();

            services.AddTransient<List<IBookValidator>>(s => {
                return s.GetServices<IBookValidator>().ToList();
            });
            
            services.AddTransient<ILendBookValidator,LendBookBookValidator>();
            services.AddTransient<ILendBookValidator,LendBookLendByValidator>();
            services.AddTransient<ILendBookValidator,LendBookLendToValidator>();

            services.AddTransient<List<ILendBookValidator>>(s=> {
                return s.GetServices<ILendBookValidator>().ToList();
            });
        }

        private void _Converter(IServiceCollection services)
        {
            services.AddTransient<ToBookDtoConverter,ToBookDtoConverter>();
            services.AddTransient<ToLendBookConverter,ToLendBookConverter>();
        }
    }
}