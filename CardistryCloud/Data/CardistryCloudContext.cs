using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CardistryCloud.Models
{
    public class CardistryCloudContext : DbContext
    {
        public CardistryCloudContext (DbContextOptions<CardistryCloudContext> options)
            : base(options)
        {
        }

        public DbSet<CardistryCloud.Models.Cardtrick> Cardtrick { get; set; }
    }
}
