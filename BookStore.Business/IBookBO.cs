using BookStore.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business
{
    public interface IBookBO 
    {
        // commentlediğim taktirde controllerda methodu görmeyecek. BookBO içerisinde get all methodunu commentlersem get all hata verecektir.
        List<BookModel> GetAll();
        Task<BookModel> GetById(int id, bool tracking = true);
        List<BookModel> getFindBooksByCategoryAndAuthor(string category, string author);

        List<BookModel> getBooksStartingFromId(int id,int take);

        List<BooksCountByAuthorandCategoryModel> getCountBooksByAuthor();

        Task<BookModel> create(BookModel bookModel);

        Task UpdateAsync(BookModel BookModel);
        Task<int> SaveAsync();
        Task RemoveAsync(int id);
        List<BookWithPropertiesTestModel> GetBookWithProperties();
        List<BookCountsInCategoryModel> GetBookCountsInCategory();

    }
}
