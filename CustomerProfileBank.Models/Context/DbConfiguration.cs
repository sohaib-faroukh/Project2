using CustomerProfileBank.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Context
{
   public class DbConfiguration
    {
        #region UserAndRole
        public class UserConfiguration : EntityTypeConfiguration<User>
        {
            public UserConfiguration()
            {
                this.ToTable("Users", "MYDATABASE");
                this.HasKey(P => P.Id);
                this.Property(p => p.FullName).HasMaxLength(200);
            }
        }

        public class RoleConfiguration : EntityTypeConfiguration<Role>
        {
            public RoleConfiguration()
            {
                this.ToTable("Roles", "MYDATABASE");
                this.HasKey(P => P.Id);
                this.Property(p => p.Name).HasMaxLength(200);
            }
        }

        public class PrivilegeConfiguration : EntityTypeConfiguration<Privilege>
        {
            public PrivilegeConfiguration()
            {
                this.ToTable("Privileges", "MYDATABASE");
                this.HasKey(P => P.Id);
            }
        }

        public class PrivilegeTypeConfiguration : EntityTypeConfiguration<PrivilegeType>
        {
            public PrivilegeTypeConfiguration()
            {
                this.ToTable("PrivilegeTypes", "MYDATABASE");
                this.HasKey(P => P.Id);
                this.Property(p => p.Name).HasMaxLength(200);
            }
        }
        public class Role_UserConfiguration : EntityTypeConfiguration<Role_User>
        {
            public Role_UserConfiguration()
            {
                this.ToTable("Role_Users", "MYDATABASE");
                this.HasKey(P => P.Id);
            }
        }
        #endregion


        #region CustomerInfo
        public class CustomerConfiguration : EntityTypeConfiguration<Customer>
        {
            public CustomerConfiguration()
            {
                this.ToTable("Customers", "MYDATABASE");
                this.HasKey(P => P.Id);
                this.Property(p => p.FirstName).HasMaxLength(200);
                this.Property(p => p.LastName).HasMaxLength(200);
                this.Property(p => p.Address).HasMaxLength(200);
            }
        }

        public class SurveyConfiguration : EntityTypeConfiguration<Survey>
        {
            public SurveyConfiguration()
            {
                this.ToTable("Surveys", "MYDATABASE");
                this.HasKey(P => P.Id);
                this.Property(p => p.Name).HasMaxLength(200);
                this.Property(p => p.Description).HasMaxLength(500);
            }
        }

        public class Survey_ResponseConfiguration : EntityTypeConfiguration<Survey_Response>
        {
            public Survey_ResponseConfiguration()
            {
                this.ToTable("Survey_Responses", "MYDATABASE");
                this.HasKey(P => P.Id);
            }
        }

        public class ServiceConfiguration : EntityTypeConfiguration<Service>
        {
            public ServiceConfiguration()
            {
                this.ToTable("Services", "MYDATABASE");
                this.HasKey(P => P.Id);
            }
        }
        public class ServiceTypeConfiguration : EntityTypeConfiguration<ServiceType>
        {
            public ServiceTypeConfiguration()
            {
                this.ToTable("ServiceTypes", "MYDATABASE");
                this.HasKey(P => P.Id);
                this.Property(p => p.Name).HasMaxLength(200);
            }
        }

        public class ResponseConfiguration : EntityTypeConfiguration<Response>
        {
            public ResponseConfiguration()
            {
                this.ToTable("Responses", "MYDATABASE");
                this.HasKey(P => P.Id);
                this.Property(p => p.Answer).HasMaxLength(500);
            }
        }

        public class Question_OrderConfiguration : EntityTypeConfiguration<Question_Order>
        {
            public Question_OrderConfiguration()
            {
                this.ToTable("Question_Orders", "MYDATABASE");
                this.HasKey(P => P.Id);
            }
        }

        public class QuestionConfiguration : EntityTypeConfiguration<Question>
        {
            public QuestionConfiguration()
            {
                this.ToTable("Questions", "MYDATABASE");
                this.HasKey(P => P.Id);
                this.Property(p => p.Text).HasMaxLength(500);
            }
        }
        public class HobbyTypeConfiguration : EntityTypeConfiguration<HobbyType>
        {
            public HobbyTypeConfiguration()
            {
                this.ToTable("HobbyTypes", "MYDATABASE");
                this.HasKey(P => P.Id);
                this.Property(p => p.Name).HasMaxLength(200);
            }
        }
        public class CustomerHobbyConfiguration : EntityTypeConfiguration<CustomerHobby>
        {
            public CustomerHobbyConfiguration()
            {
                this.ToTable("CustomerHobbies", "MYDATABASE");
                this.HasKey(P => P.Id);
            }
        }
        public class NumberConfiguration : EntityTypeConfiguration<Number>
        {
            public NumberConfiguration()
            {
                this.ToTable("Numbers", "MYDATABASE");
                this.HasKey(P => P.Id);
            }
        }
        public class NumberTypeConfiguration : EntityTypeConfiguration<NumberType>
        {
            public NumberTypeConfiguration()
            {
                this.ToTable("NumberTypes", "MYDATABASE");
                this.HasKey(P => P.Id);
                this.Property(p => p.Name).HasMaxLength(200);
            }
        }
        #endregion


        #region FingerPrint
        public class FingerPrintClassConfiguration : EntityTypeConfiguration<FingerPrintClass>
        {
            public FingerPrintClassConfiguration()
            {
                this.ToTable("FingerPrintClasses", "MYDATABASE");
                this.HasKey(P => P.Id);
                this.Property(p => p.Name).HasMaxLength(200);
            }
        }
        public class CustomerFingerPrintConfiguration : EntityTypeConfiguration<CustomerFingerPrint>
        {
            public CustomerFingerPrintConfiguration()
            {
                this.ToTable("CustomerFingerPrints", "MYDATABASE");
                this.HasKey(P => P.Id);
            }
        }
        public class UserFingerPrintConfiguration : EntityTypeConfiguration<UserFingerPrint>
        {
            public UserFingerPrintConfiguration()
            {
                this.ToTable("UserFingerPrints", "MYDATABASE");
                this.HasKey(P => P.Id);
            }
        }
        #endregion
    }
}
