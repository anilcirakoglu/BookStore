using BookStore.Application.Repositories;
using BookStore.Business.Models;
using BookStore.Domain.Entities;
using BookStore.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business
{
    public class UserBO : IUserBO
    {
        readonly private IUsersReadRepository _usersReadRepository;
        readonly private IUsersWriteRepository _usersWriteRepository;

        public UserBO(IUsersReadRepository usersReadRepository, IUsersWriteRepository usersWriteRepository)
        {
            _usersReadRepository = usersReadRepository;
            _usersWriteRepository = usersWriteRepository;
        }

        public async Task<UsersModel> create(UsersModel UserModel)
        {
            var user = new Users()
            {
                id = UserModel.id,
                name = UserModel.name,
                surname = UserModel.surname,
                phonenumber = UserModel.phonenumber,
                email = UserModel.email


            };
            await _usersWriteRepository.AddAsync(user);
            await _usersWriteRepository.SaveAsync();
            

            return UserModel;
        }


        public List<UsersModel> GetAll()
        {
            var users = _usersReadRepository.GetAll().ToList();
            var usersList = new List<UsersModel>();

            foreach (var price in users)
            {
                var userList = new UsersModel()
                {
                    id = price.id,
                    name = price.name,
                    surname = price.surname,
                    phonenumber = price.phonenumber,
                    email = price.email,




                };
                usersList.Add(userList);
            }
            return usersList;
        }

        public async Task<UsersModel> GetById(int id, bool tracking = true)
        {
            var users = await _usersReadRepository.GetByIdAsync(id);


            var User = new UsersModel
            {
                id = users.id,
                name = users.name,
                surname = users.surname,
                phonenumber = users.phonenumber,
                email = users.email,




            };

            return User;
        }

        public async Task RemoveAsync(int id)
        {
            var users = await _usersReadRepository.GetByIdAsync(id);


            var User = new UsersModel
            {
                id = users.id,
                name=users.name, 
                surname = users.surname,
                phonenumber=users.phonenumber,
                email = users.email
                
              

            };
            await _usersWriteRepository.RemoveAsync(id);
            await _usersWriteRepository.SaveAsync();
        }

        public async Task<int> SaveAsync()
        {
            var user = await _usersWriteRepository.SaveAsync();
            return user;
        }

        public async Task UpdateAsync(UsersModel userModel)
        {
            var users = _usersReadRepository.GetAll().Where(x=>x.id == userModel.id).FirstOrDefault();


                
                users.name = userModel.name;
                users.surname = userModel.surname;
                users.phonenumber = userModel.phonenumber;
                users.email = userModel.email;

               
               _usersWriteRepository.Update(users);
                await _usersWriteRepository.SaveAsync();
            
           
           
        }

        
    }

}
