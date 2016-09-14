using Microsoft.AspNet.Identity.EntityFramework;
using PubsAutoMapperMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PubsAutoMapperMVCApp.DataContexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("PubsConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}