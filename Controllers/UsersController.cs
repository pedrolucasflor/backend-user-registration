using backend_user_registration.Data;
using backend_user_registration.Data.Dtos;
using backend_user_registration.Data.Query;
using backend_user_registration.Models;
using Canducci.Pagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_user_registration.Controllers
{
    [ApiController]
    [Route("/api/users")]
    public class UsersController : ControllerBase
    {
        private UserRegistrationContext _context;

        public UsersController(UserRegistrationContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void addUser([FromBody] CreateUserDto userDto)
        {
            User user = new User
            {
                name = userDto.name,
                birthdate = userDto.birthdate,
                socialMedia = userDto.socialMedia,
                phoneNumbers = new List<PhoneNumber>(),
                addresses = new List<Address>(),
                cpf = userDto.cpf,
                rg = userDto.rg
            };
            
            userDto.phoneNumbers.ForEach(phoneNumberDto => {
                PhoneNumber phoneNumber = new PhoneNumber
                {
                    number = phoneNumberDto.number,
                    label = phoneNumberDto.label
                };
                user.phoneNumbers.Add(phoneNumber);
            });

            userDto.addresses.ForEach(addressDto => {
                Address address = new Address
                {
                    name = addressDto.name,
                    label = addressDto.label
                };
                user.addresses.Add(address);
            });

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        [HttpGet]
        public PaginatedRest<User> findUsersAsync([FromQuery]FindUsersQuery query)
        {
            query.page ??= 1;
            query.size ??= 5;

            if (query.name == null || query.name.Trim().Length == 0) {
                var users = _context.Users
                    .AsNoTracking()
                    .OrderBy(c => c.id)
                    .ToPaginatedRest(query.page.Value, query.size.Value);

                return users;
            } else {
                var users = _context.Users.Where(e => e.name.Contains(query.name))
                    .AsNoTracking()
                    .OrderBy(c => c.id)
                    .ToPaginatedRest(query.page.Value, query.size.Value);

                return users;
                // var users = from user in _context.Users
                //     where user.name.Contains(query.name)
                //     select new User
                //     {
                //         id = user.id,
                //         name = user.name,
                //         birthdate = user.birthdate,
                //         socialMedia = user.socialMedia,
                //         phoneNumbers = user.phoneNumbers,
                //         addresses = user.addresses,
                //         cpf = user.cpf,
                //         rg = user.rg
                //     };
            }
        }

        [HttpGet("{id}")]
        public User findUser(int id)
        {
            var user = from u in _context.Users
                where u.id == id
                select new User
                {
                    id = u.id,
                    name = u.name,
                    birthdate = u.birthdate,
                    socialMedia = u.socialMedia,
                    phoneNumbers = u.phoneNumbers,
                    addresses = u.addresses,
                    cpf = u.cpf,
                    rg = u.rg
                };

            return user.First();
        }

        [HttpPut("{id}")]
        public void updateUser(int id, [FromBody]User userQuery) {
            var persistedUser = from u in _context.Users
                where u.id == id
                select new User
                {
                    id = u.id,
                    name = u.name,
                    birthdate = u.birthdate,
                    socialMedia = u.socialMedia,
                    phoneNumbers = u.phoneNumbers,
                    addresses = u.addresses,
                    cpf = u.cpf,
                    rg = u.rg
                };

            User user = persistedUser.First();

            if (user == null) {
                throw new ArgumentException("user not found");
            }
            
            user.name = userQuery.name;
            user.birthdate = userQuery.birthdate;
            user.phoneNumbers = userQuery.phoneNumbers;
            user.addresses = userQuery.addresses;
            user.socialMedia = userQuery.socialMedia;
            user.cpf = userQuery.cpf;
            user.rg = userQuery.rg;

            _context.Entry(user).State =  EntityState.Modified;
            _context.SaveChanges();
        }
    }
}