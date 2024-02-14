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
        Task<BookModel> create(BookModel bookModel);
        
        
        
        
        //void Update(int id);
    }
}
