using ALMADINA.Entity;
using ALMADINA.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ALMADINA.Data
{
    public class ProjectContext : IdentityDbContext<ApplicationUser>
    {
        public ProjectContext() : base("SQLConnection", throwIfV1Schema: true)
        {
        }

        public static ProjectContext Create()
        {
            return new ProjectContext();
        }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<User> Useres { get; set; }
        public DbSet<LevelOrClass> LevelOrClasses { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<FeeType> FeeTypes { get; set; }
        public DbSet<FeesRegister> FeesRegisters {  get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Subject> Subjects { get; set; }

    }
}