using BookStore.Application.Repositories;
using BookStore.Application.Repositories.Author;
using BookStore.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business
{
    public class AuthorBO:IAuthorBO
    {
        readonly private IBookWriteRepository _bookWriteRepository;
        readonly private IBookReadRepository _bookReadRepository;
        readonly private IPricesReadRepository _priceReadRepository;
        readonly private IPricesWriteRepository _priceWriteRepository;
        readonly private IAuthorReadRepository _authorReadRepository;
        readonly private IAuthorWriteRepository _authorWriteRepository;


        public AuthorBO(IBookReadRepository bookReadRepository, IBookWriteRepository bookWriteRepository, IPricesReadRepository pricesReadRepository, IPricesWriteRepository pricesWriteRepository,IAuthorReadRepository authorReadRepository,IAuthorWriteRepository authorWriteRepository)

        {

            _bookReadRepository = bookReadRepository;
            _bookWriteRepository = bookWriteRepository;
            _priceReadRepository = pricesReadRepository;
            _priceWriteRepository = pricesWriteRepository;
            _authorReadRepository = authorReadRepository;
            _authorWriteRepository = authorWriteRepository; 



        }

        public Task<AuthorsModel> create(AuthorsModel bookModel)
        {
            throw new NotImplementedException();
        }

        public List<AuthorsModel> GetAll()
        {
           
            
                var authors = _authorReadRepository.GetAll().ToList();
                var AuthorsModelList = new List<AuthorsModel>();
               
                foreach (var author in authors)
                {
                    var authorsList = new AuthorsModel
                    {
                        id=author.id,
                        TC =author.TC,
                        birthday = author.birthday,
                        name = author.name,
                        email = author.email,
                        gender = author.gender,
                       



                    };
                    AuthorsModelList.Add(authorsList);
                }
                return AuthorsModelList;
            
        }

        public Task<AuthorsModel> GetById(int id, bool tracking = true)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(AuthorsModel authorModel)
        {
            throw new NotImplementedException();
        }
    }
}
