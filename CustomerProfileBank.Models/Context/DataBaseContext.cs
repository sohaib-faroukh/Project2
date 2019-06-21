using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using CustomerProfileBank.Models.Models;
//using static CustomerProfileBank.Models.Context.DbConfiguration;

namespace CustomerProfileBank.Models.Context
{
    public class DataBaseContext : DbContext
    {
        #region initDb

        //Connect to database 
        public DataBaseContext(bool isReading) :
                base(new OracleConnection(ConfigurationManager.ConnectionStrings["CustomerBank"].ConnectionString), true)
        {
            if (isReading)
                this.Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer<DataBaseContext>(null);
        }
        public DataBaseContext() : this(false) { }

        #endregion

        #region dbSet

        //UserAndRole
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        //public DbSet<Role_User> Role_Users { get; set; }
        public DbSet<Privilege> Privileges { get; set; }

        //CustomerInfo
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerHobby> CustomerHobbies { get; set; }
        public DbSet<Number> Numbers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Service> Services { get; set; }

        //Survey
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyQuestion> SurveyQuestions { get; set; }
        public DbSet<SurveyResponse> SurveyResponses { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Option> Options { get; set; }
        
        //FingerPrint
        public DbSet<CustomerFingerPrint> CustomerFingerPrints { get; set; }
        public DbSet<UserFingerPrint> UserFingerPrints { get; set; }


        #endregion

        #region addCongigurations
        //add the configurations 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            //modelBuilder.HasDefaultSchema("MYDATABASE");
            modelBuilder.HasDefaultSchema(ConfigurationManager.AppSettings["DefaultSchema"]);
            modelBuilder.Types().Configure(entity => entity.ToTable(
                ConfigurationManager.AppSettings["DefaultSchema"] + "_" + entity.ClrType.Name.ToUpper()
            ));
            modelBuilder.Entity<User>().HasMany(u => u.Roles).WithMany(u => u.Users).Map(ur =>
            {
                ur.ToTable(ConfigurationManager.AppSettings["DefaultSchema"] + "_USERROLES");
            });
            modelBuilder.Entity<Role>().HasMany(p => p.Privileges).WithMany(r => r.Roles).Map(pr =>
            {
                pr.ToTable(ConfigurationManager.AppSettings["DefaultSchema"] + "_ROLEPRIVILEGES");
            });

        }
        #endregion
    }
}
