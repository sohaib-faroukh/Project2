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
        public DbSet<Question_Order> Question_Orders { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Survey_Response> Survey_Responses { get; set; }

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
            modelBuilder.Types().Configure(entity => entity.ToTable(ConfigurationManager.AppSettings["DefaultSchema"] +"_"+ entity.ClrType.Name.ToUpper()));

            //UserAndRole Configration 

            //modelBuilder.Configurations.Add(new UserConfiguration());
            //modelBuilder.Configurations.Add(new RoleConfiguration());
            //modelBuilder.Configurations.Add(new PrivilegeConfiguration());
            //modelBuilder.Configurations.Add(new PrivilegeTypeConfiguration());
            //modelBuilder.Configurations.Add(new Role_UserConfiguration());

            //CustomerInfo Configuration
            //modelBuilder.Configurations.Add(new CustomerConfiguration());
            //modelBuilder.Configurations.Add(new SurveyConfiguration());
            //modelBuilder.Configurations.Add(new Survey_ResponseConfiguration());
            //modelBuilder.Configurations.Add(new ServiceConfiguration());
            //modelBuilder.Configurations.Add(new ServiceTypeConfiguration());
            //modelBuilder.Configurations.Add(new ResponseConfiguration());
            //modelBuilder.Configurations.Add(new Question_OrderConfiguration());
            //modelBuilder.Configurations.Add(new QuestionConfiguration());
            //modelBuilder.Configurations.Add(new HobbyTypeConfiguration());
            //modelBuilder.Configurations.Add(new CustomerHobbyConfiguration());
            //modelBuilder.Configurations.Add(new NumberConfiguration());
            //modelBuilder.Configurations.Add(new NumberTypeConfiguration());



            //FingerPrint Configuration
            //modelBuilder.Configurations.Add(new FingerPrintClassConfiguration());
            //modelBuilder.Configurations.Add(new CustomerFingerPrintConfiguration());
            //modelBuilder.Configurations.Add(new UserFingerPrintConfiguration());                  

        }
        #endregion
    }
}
