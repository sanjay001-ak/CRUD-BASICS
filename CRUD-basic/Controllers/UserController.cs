using CRUD_basic.Data;
using CRUD_basic.DTO;
using CRUD_basic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_basic.Controllers
{
    [ApiController] // Saying that it is a API controller and not MVC Controller
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly DataContext dbcontext;
        public UserController(DataContext dbcontext)
        {
               this.dbcontext = dbcontext;
        }
        [HttpGet]
        public async  Task<IActionResult> GetUsers()
        {
            return Ok( await dbcontext.MyUsers.ToListAsync());
        }

        [HttpPost]

        public IActionResult Adduser(MyUserDTO userdto)
        {
            var user = new MyUser()
            {
                Id = Guid.NewGuid(),
                Name = userdto.Name,
                Email = userdto.Email,
                Address = userdto.Address
            };

            dbcontext.MyUsers.Add(user);
            dbcontext.SaveChanges();

            return Ok(user);
        }

        [HttpPut]
        [Route("{id:guid}")]

        public IActionResult Updateuser([FromRoute] Guid id, MyUserDTO Myuserdto)
        {
            var user = dbcontext.MyUsers.Find(id);
            if (user != null)
            {
                user.Name = Myuserdto.Name;
                user.Email = Myuserdto.Email;
                user.Address = Myuserdto.Address;
                dbcontext.SaveChanges();
                return Ok(user);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]

        public IActionResult Deleteuser([FromRoute]Guid id)
        {
            var user = dbcontext.MyUsers.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            dbcontext.MyUsers.Remove(user);
            dbcontext.SaveChanges();
            return Ok(user);
        }
    }
}
