using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDBContext : DbContext
    {
        public NZWalksDBContext(DbContextOptions<NZWalksDBContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed the data for Difficulties - Easy, Medium, Hard
            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("4300c759-736a-403f-8aaf-8d606378ffd2"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("af9199b8-5a57-4138-ba86-c3204bb75bcc"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("4bd8fc8b-7982-4bcb-a3ea-4708967f8b06"),
                    Name = "Hard"
                }
            };
            modelBuilder.Entity<Difficulty>().HasData(difficulties); //Adding -Seed data

            //Seed data for Regions
            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("a4d3a610-b010-459e-87ed-84c65d35d15a"), // Auckland
                    Name = "Auckland",
                    Code = "AUK",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/3b/Auckland_City_Skyline.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("5c61e9de-85f4-48aa-b9ea-be0603f91f8d"), // Wellington
                    Name = "Wellington",
                    Code = "WEL",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/3e/Wellington_City_Skyline.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("35ac7d7d-0978-4495-93b8-469a2d240e37"), // Christchurch
                    Name = "Christchurch",
                    Code = "CHR",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/8/8e/Christchurch_Cathedral.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("901035d4-dd1d-4fa3-a0fc-9db3c41713b5"), // Hamilton
                    Name = "Hamilton",
                    Code = "HAM",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/4f/Hamilton_Gardens.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("cd1ee686-1d2b-43b1-9ded-bdaa13f9692a"), // Tauranga
                    Name = "Tauranga",
                    Code = "TAU",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/2/2c/Tauranga_Bay.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("51a9170f-eb58-45d7-913f-377c980825d2"), // Dunedin
                    Name = "Dunedin",
                    Code = "DUN",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/5/5c/Dunedin_City.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("0ac86219-a84c-4fce-b0c1-db0b14e3c9ac"), // Napier-Hastings
                    Name = "Napier-Hastings",
                    Code = "NAP",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/4b/Napier_Hastings.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("b2bac570-237b-473c-9edf-f40533ac4dba"), // Palmerston North
                    Name = "Palmerston North",
                    Code = "PAL",
                    RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/7/7e/Palmerston_North_City.jpg"
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);
            //Seed Data for Walks
        }

        //Migration to SQL Commands needs to entered in Package manager console
        //1.    Add-Migration "Initial Migration"
        //2.    Update-Database (it'll creates DB in SQL(tables,mapping..)
    }
}
