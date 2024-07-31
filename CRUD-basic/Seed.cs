using CRUD_basic.Data;
using CRUD_basic.DTO;
using CRUD_basic.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_basic
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            var user = new MyUser()
            {
                Id = Guid.NewGuid(),
                Name = "Sanjay",
                Email = "Sanjay.com",
                Address = "akaddress"
            };

            dataContext.MyUsers.Add(user);
            dataContext.SaveChanges();
        }
    }
        
}
