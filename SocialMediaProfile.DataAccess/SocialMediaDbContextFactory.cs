using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaProfile.DataAccess
{
    public class SocialMediaDbContextFactory : IDesignTimeDbContextFactory<SocialMediaDbContext>
    {
        SocialMediaDbContext IDesignTimeDbContextFactory<SocialMediaDbContext>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SocialMediaDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-MU3HI5L\\SQLEXPRESS;Database=SOCIAL_MEDIA.DB;Trusted_Connection=True;Connect Timeout=10");

            return new SocialMediaDbContext(optionsBuilder.Options);
        }
    }
}
