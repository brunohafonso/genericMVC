using System;
using System.Linq;
using generic.mvc.domain.Entities;
using generic.mvc.repository.Context;

namespace generic.mvc.MVC
{
    public class InitDatabase
    {
        public static void initDb(GenericContext _context)
        {
            _context.Database.EnsureCreated();
            if(_context.Users.Any()) {
                return;
            }

            var user = new User("Bruno Afonso", Convert.ToDateTime("25/04/1995"));
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}