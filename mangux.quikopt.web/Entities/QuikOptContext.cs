using mangux.quikopt.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mangux.quikopt.web
{
    public class QuikOptContext : IdentityDbContext<IdentityUser>
    {
        public QuikOptContext()
            : base("QuikOptContext")
        {
     
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }

}