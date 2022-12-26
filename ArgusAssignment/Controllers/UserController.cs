using ArgusAssignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArgusAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //TODO : dependency injection için private alan.
        private readonly ArgusDBContext _context;
        //TODO : constructor
        public UserController(ArgusDBContext context)
        {
            //TODO : Dependency injection
            _context = context;
        }

        //TODO : Tüm kullanıcıları listeleyip çağırmak
        [HttpGet("GetAll")]
        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        //TODO : parametre olarak id gönderip id ile eşleşen kullanıcıyı bulmak
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);

        }
        //TODO : model yollayıp kullanıcı eklemek
        [HttpPost("AddUser")]
        public IActionResult AddUser(User user)
        {
            _context.Add(user);
           _context.SaveChanges();
            return Ok();
        }
        //TODO : model yollayıp kullanıcı güncellemek
        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(User model)
        {
            if (model == null || model.Id == 0)
            {
                return BadRequest();

            }

            var user =  _context.Users.Find(model.Id);
            if (user == null)
            {
                return NotFound();
            }

            user.Name = model.Name;
            user.Surname = model.Surname;
            user.PhoneNumber = model.PhoneNumber;
            user.Adress = model.Adress;
            user.DateOfBirth = model.DateOfBirth;
           _context.SaveChanges();
            return Ok();
        }
        //TODO : id ile kullanıcı silmek
        [HttpDelete("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user =  _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();

            }
            _context.Users.Remove(user);
             _context.SaveChanges();
            return Ok();

        }
    }
}
