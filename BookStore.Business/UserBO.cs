using BookStore.Application.Repositories;
using BookStore.Business.Models;
using BookStore.Domain.Entities;
using BookStore.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Business
{
    public class UserBO : IUserBO
    {
        readonly private IUsersReadRepository _usersReadRepository;
        readonly private IUsersWriteRepository _usersWriteRepository;

        readonly private ICustomerRoleReadRepository _customerRoleReadRepository;
        readonly private ICustomerRoleWriteRepository _customerRoleWriteRepository;

        readonly private IRolesReadRepository _rolesReadRepository;
        readonly private IRolesWriteRepository _rolesWriteRepository;

        private readonly IConfiguration _configuration;

        public UserBO(IUsersReadRepository usersReadRepository, IUsersWriteRepository usersWriteRepository, IConfiguration configuration, IRolesReadRepository rolesReadRepository, IRolesWriteRepository rolesWriteRepository, ICustomerRoleReadRepository customerRoleReadRepository, ICustomerRoleWriteRepository customerRoleWriteRepository)
        {
            _usersReadRepository = usersReadRepository;
            _usersWriteRepository = usersWriteRepository;
            _rolesReadRepository = rolesReadRepository;
            _rolesWriteRepository = rolesWriteRepository;
            _customerRoleReadRepository = customerRoleReadRepository;
            _customerRoleWriteRepository = customerRoleWriteRepository;

            _configuration = configuration;
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
                name = users.name,
                surname = users.surname,
                phonenumber = users.phonenumber,
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
            var users = _usersReadRepository.GetAll().Where(x => x.id == userModel.id).FirstOrDefault();



            users.name = userModel.name;
            users.surname = userModel.surname;
            users.phonenumber = userModel.phonenumber;
            users.email = userModel.email;


            _usersWriteRepository.Update(users);
            await _usersWriteRepository.SaveAsync();



        }
        #region loginAndRegisteration 


        public string Login(LoginModel model)
        {


            var user = _usersReadRepository.GetWhere(x => x.username == model.username).FirstOrDefault();

            var userPassword = _usersReadRepository.GetWhere(x => x.password == model.password).FirstOrDefault();

            // Kullanıcı adı veya şifre doğru değilse hata döndür
            if (user == null || userPassword == null)
                return "Invalid username or password";

            var userRoles = GetRolesAsync(user.id).Result;

        
            var tokenClaims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
        new Claim(ClaimTypes.Name, user.name)
    };

          
            if (userRoles != null)
            {
                foreach (var role in userRoles)
                {
                    tokenClaims.Add(new Claim(ClaimTypes.Role, role));
                }
            }
        
            var token = GenerateToken(tokenClaims);
            return token;


        }

        public async Task<(int, string)> Registeration(RegistrationModel model)
        {

            var userExists = await _usersReadRepository.GetWhere(x => x.username == model.username).FirstOrDefaultAsync();
            if (userExists != null)
                return (0, "User already exists");

            var user = new Users()
            {
                email = model.email,
                username = model.username,
                name = model.name,
                password = model.password,
            };

            await _usersWriteRepository.AddAsync(user);

            try
            {
                // Değişiklikleri kaydet
                await _usersWriteRepository.SaveAsync();
                return (1, "User created successfully!");
            }
            catch (Exception ex)
            {
                // Hata durumunda uygun mesajı döndür
                return (0, $"User creation failed! Error: {ex.Message}");
            }


            //var userExists = await _userManager.FindByNameAsync(model.username ?? "");
            //if (userExists != null)
            //    return (0, "User already exists");

            //var user  = new UsersModel()
            //{
            //    Email = model.email,
            //    SecurityStamp = Guid.NewGuid().ToString(),
            //    UserName = model.username,

            //};
            //var createUserResult = await _userManager.CreateAsync(user, model.password ?? "");
            //if (!createUserResult.Succeeded)
            //    return (0, "User creation failed! Please check user details and try again.");


            //return (1, "User created successfully!");
        }
        private string GenerateToken(IEnumerable<Claim> claims)
        {



            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            if (authSigningKey.KeySize < 128)
            {

                using var hmac = new HMACSHA256();
                authSigningKey = new SymmetricSecurityKey(hmac.Key);
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Issuer"],
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
        public async Task<List<string>> GetRolesAsync(int id)//id göndericem
        {    // Kullanıcı adına göre kullanıcıyı al
             //var userRoles = from userrolemodel in _userrolerepo
             //           join crmmodel in _crmrepo on userrolemodel.Id equals crmmodel.RoleId
             //           where crmmodel.CustomerId = userid
             //           select userrolemodel.RoleName

            

            var roles = _rolesReadRepository.GetAll();
            var customerRoles = _customerRoleReadRepository.GetAll();

            var userRoles =(from role in roles 
                           join customerRole in customerRoles on role.id equals customerRole.RoleId
                           where customerRole.CustomerId == id
                           select role.role
                           ).ToList();

            return userRoles;
        }

        #endregion





    }

}
