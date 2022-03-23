using backend_user_registration.Data;

namespace backend_user_registration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private UserRegistrationContext _context;

        public UsersController(UserRegistrationContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult addUser([FromBody] CreateUserDto userDto)
        {
            User user = new User
            {
                name = userDto.name;
                birthdate = userDto.birthdate;
                phoneNumbers = userDto.phoneNumbers;
                adresses = userDto.adresses;
                socialMedia = userDto.socialMedia;
                cpf = userDto.cpf;
                rg = userDto.rg;
            };

            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(findUserById), new { id = user.id }, user);

        }

        [HttpGet]
        public IEnumerable<User> findUsers()
        {
            return _context.Users;
        }
    }
}