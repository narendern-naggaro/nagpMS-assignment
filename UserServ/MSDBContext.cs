﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserServ
{
    public class MSDBContext:DbContext
    {
        public MSDBContext(DbContextOptions<MSDBContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
    }
}
