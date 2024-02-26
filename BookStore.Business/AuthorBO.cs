using BookStore.Application.Repositories;
using BookStore.Application.Repositories.Author;
using BookStore.Business.Models;
using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business
{
    public class AuthorBO : IAuthorBO
    {
        readonly private IBookWriteRepository _bookWriteRepository;
        readonly private IBookReadRepository _bookReadRepository;
        readonly private IPricesReadRepository _priceReadRepository;
        readonly private IPricesWriteRepository _priceWriteRepository;
        readonly private IAuthorReadRepository _authorReadRepository;
        readonly private IAuthorWriteRepository _authorWriteRepository;


        public AuthorBO(IBookReadRepository bookReadRepository, IBookWriteRepository bookWriteRepository, IPricesReadRepository pricesReadRepository, IPricesWriteRepository pricesWriteRepository, IAuthorReadRepository authorReadRepository, IAuthorWriteRepository authorWriteRepository)

        {

            _bookReadRepository = bookReadRepository;
            _bookWriteRepository = bookWriteRepository;
            _priceReadRepository = pricesReadRepository;
            _priceWriteRepository = pricesWriteRepository;
            _authorReadRepository = authorReadRepository;
            _authorWriteRepository = authorWriteRepository;



        }

        public async Task<AuthorsModel> create(AuthorsModel authorModel)
        {
            var author = new Authors()
            {
                id = authorModel.id,
                TC = authorModel.TC,
                name = authorModel.name,
                birthday = authorModel.birthday,
                email = authorModel.email,
                gender = authorModel.gender,
            };
            await _authorWriteRepository.AddAsync(author);
            await _authorWriteRepository.SaveAsync();
            return authorModel;
        }

        public List<AuthorsModel> GetAll()
        {


            var authors = _authorReadRepository.GetAll().ToList();
            var AuthorsModelList = new List<AuthorsModel>();

            foreach (var author in authors)
            {
                var authorsList = new AuthorsModel
                {
                    id = author.id,
                    TC = author.TC,
                    birthday = author.birthday,
                    name = author.name,
                    email = author.email,
                    gender = author.gender,




                };
                AuthorsModelList.Add(authorsList);
            }
            return AuthorsModelList;

        }

        public async Task<AuthorsModel> GetById(int id, bool tracking = true)
        {
            var author = await _authorReadRepository.GetByIdAsync(id);
            var authors = new AuthorsModel
            {
                id = author.id,
                TC = author.TC,
                birthday = author.birthday,
                name = author.name,
                email = author.email,
                gender = author.gender

            };
            return authors;
        }

        public async Task RemoveAsync(int id)
        {
            var author = await _authorReadRepository.GetByIdAsync(id);
            var authorRemove = new AuthorsModel
            {
                id = author.id,
                TC = author.TC,
                birthday = author.birthday,
                name = author.name,
                email = author.email,
                gender = author.gender

            };
            await _authorWriteRepository.RemoveAsync(id);
            await _authorWriteRepository.SaveAsync();
        }

        public async Task<int> SaveAsync()
        {
            var author = await _authorWriteRepository.SaveAsync();
            return author;
        }

        public async Task UpdateAsync(AuthorsModel authorModel)
        {
            var authorUpdate = _authorReadRepository.GetAll().FirstOrDefault(x => x.id == authorModel.id);

            if (authorUpdate != null)
            {
                authorUpdate.TC = authorModel.TC;
                authorUpdate.birthday = authorModel.birthday;
                authorUpdate.name = authorModel.name;
                authorUpdate.gender = authorModel.gender;
            }
            _authorWriteRepository.Update(authorUpdate);
            await _authorWriteRepository.SaveAsync();
        }
    }
}
