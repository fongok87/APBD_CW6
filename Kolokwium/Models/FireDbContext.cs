using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class FireDbContext : DbContext
    {

        public DbSet<Action> Action { get; set; }

        public DbSet<Firefighter_Action> Firefighter_Action { get; set; }

        public DbSet<FireTruck_Action> FireTruck_Action { get; set; }

        public DbSet<FireTruck> FireTruck { get; set; }

        public DbSet<Firefighter> Firefighter { get; set; }

        public FireDbContext()
        {

        }

        public FireDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Firefighter_Action>()
                        .HasKey(p => new { p.IdFirefighter, p.IdAction });

            modelBuilder.Entity<Firefighter>(entity =>
            {
                var list = new List<Firefighter>
                {
                    new Firefighter
                    {
                        IdFirefighter = 1,
                        Firstname = "Rafał",
                        LastName = "Smoczynski"
                    },
                    new Firefighter
                    {
                        IdFirefighter = 2,
                        Firstname = "Kasia",
                        LastName = "Smoczynska"
                    },
                    new Firefighter
                    {
                        IdFirefighter = 3,
                        Firstname = "Maria",
                        LastName = "Ligowska"
                    }
                };
                entity.HasData(list);
            });

            modelBuilder.Entity<FireTruck>(entity =>
            {
                var list = new List<FireTruck>
                {
                    new FireTruck
                    {
                        IdFireTruck = 1,
                        OperationalNumber = "Pozarowy",
                        SpecialEquipment = 3
                    },
                    new FireTruck
                    {
                        IdFireTruck = 2,
                        OperationalNumber = "Latajacy",
                        SpecialEquipment = 2
                    },
                    new FireTruck
                    {
                        IdFireTruck = 3,
                        OperationalNumber = "Wodny",
                        SpecialEquipment = 1
                    }
                };
                entity.HasData(list);
            });

            modelBuilder.Entity<Action>(entity =>
            {
                var list = new List<Action>
                {
                    new Action
                    {
                        IdAction = 1,
                        StartTime = new DateTime(2020, 6, 23, 0, 0, 0, 0, DateTimeKind.Local),
                        EndTime = new DateTime(2020, 6, 24, 0, 0, 0, 0, DateTimeKind.Local),
                        NeedSpecialEquipment = 1
                    },
                    new Action
                    {
                        IdAction = 2,
                        StartTime = new DateTime(2020, 6, 24, 0, 0, 0, 0, DateTimeKind.Local),
                        EndTime = new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Local),
                        NeedSpecialEquipment = 2
                    },
                    new Action
                    {
                        IdAction = 3,
                        StartTime = new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Local),
                        EndTime = new DateTime(2020, 6, 26, 0, 0, 0, 0, DateTimeKind.Local),
                        NeedSpecialEquipment = 3
                    }
                };
                entity.HasData(list);
            });

            modelBuilder.Entity<Firefighter_Action>(entity =>
            {
                var list = new List<Firefighter_Action>
                {
                    new Firefighter_Action
                    {
                        IdFirefighter = 1,
                        IdAction = 3
                    },
                    new Firefighter_Action
                    {
                        IdFirefighter = 2,
                        IdAction = 2
                    },
                    new Firefighter_Action
                    {
                        IdFirefighter = 3,
                        IdAction = 1
                    }
                };
                entity.HasData(list);
            });

            modelBuilder.Entity<FireTruck_Action>(entity =>
            {
                var list = new List<FireTruck_Action>
                {
                    new FireTruck_Action
                    {
                        IdFireTruck_Action = 1,
                        IdFireTruck = 3,
                        IdAction = 1,
                        AssigmentDate = new DateTime(2020, 6, 23, 0, 0, 0, 0, DateTimeKind.Local),
                    },
                    new FireTruck_Action
                    {
                        IdFireTruck_Action = 2,
                        IdFireTruck = 2,
                        IdAction = 2,
                        AssigmentDate = new DateTime(2020, 6, 24, 0, 0, 0, 0, DateTimeKind.Local),
                    },
                    new FireTruck_Action
                    {
                        IdFireTruck_Action = 3,
                        IdFireTruck = 1,
                        IdAction = 3,
                        AssigmentDate = new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Local),
                    }
                };
                entity.HasData(list);
            });
        }
    }
}
