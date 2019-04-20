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
                this.ToTable("Users");
                this.HasKey(P => P.Id);
                this.Property(p => p.FullName).HasMaxLength(200);
            }
        }

        public class RoleConfiguration : EntityTypeConfiguration<Role>
        {
            public RoleConfiguration()
            {
                this.ToTable("Roles");
                this.HasKey(P => P.Id);
                this.Property(p => p.Name).HasMaxLength(200);
            }
        }

        public class PrivilegeConfiguration : EntityTypeConfiguration<Privilege>
        {
            public PrivilegeConfiguration()
            {
                this.ToTable("Privileges");
                this.HasKey(P => P.Id);
            }
        }

        public class PrivilegeTypeConfiguration : EntityTypeConfiguration<PrivilegeType>
        {
            public PrivilegeTypeConfiguration()
            {
                this.ToTable("PrivilegeTypes");
                this.HasKey(P => P.Id);
                this.Property(p => p.Name).HasMaxLength(200);
            }
        }
        //public class Role_UserConfiguration : EntityTypeConfiguration<Role_User>
        //{
        //    public Role_UserConfiguration()
        //    {
        //        this.ToTable("Role_Users");
        //        this.HasKey(P => P.Id);
        //    }
        //}
        #endregion


        #region CustomerInfo
        public class CustomerConfiguration : EntityTypeConfiguration<Customer>
        {
            public CustomerConfiguration()
            {
                this.ToTable("Customers");
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
                this.ToTable("Surveys");
                this.HasKey(P => P.Id);
                this.Property(p => p.Name).HasMaxLength(200);
                this.Property(p => p.Description).HasMaxLength(500);
            }
        }

        public class Survey_ResponseConfiguration : EntityTypeConfiguration<Survey_Response>
        {
            public Survey_ResponseConfiguration()
            {
                this.ToTable("Survey_Responses");
                this.HasKey(P => P.Id);
            }
        }

        public class ServiceConfiguration : EntityTypeConfiguration<Service>
        {
            public ServiceConfiguration()
            {
                this.ToTable("Services");
                this.HasKey(P => P.Id);
            }
        }
        public class ServiceTypeConfiguration : EntityTypeConfiguration<ServiceType>
        {
            public ServiceTypeConfiguration()
            {
                this.ToTable("ServiceTypes");
                this.HasKey(P => P.Id);
                this.Property(p => p.Name).HasMaxLength(200);
            }
        }

        public class ResponseConfiguration : EntityTypeConfiguration<Response>
        {
            public ResponseConfiguration()
            {
                this.ToTable("Responses");
                this.HasKey(P => P.Id);
                this.Property(p => p.Answer).HasMaxLength(500);
            }
        }

        public class Question_OrderConfiguration : EntityTypeConfiguration<Question_Order>
        {
            public Question_OrderConfiguration()
            {
                this.ToTable("Question_Orders");
                this.HasKey(P => P.Id);
            }
        }

        public class QuestionConfiguration : EntityTypeConfiguration<Question>
        {
            public QuestionConfiguration()
            {
                this.ToTable("Questions");
                this.HasKey(P => P.Id);
                this.Property(p => p.Text).HasMaxLength(500);
            }
        }
        public class HobbyTypeConfiguration : EntityTypeConfiguration<HobbyType>
        {
            public HobbyTypeConfiguration()
            {
                this.ToTable("HobbyTypes");
                this.HasKey(P => P.Id);
                this.Property(p => p.Name).HasMaxLength(200);
            }
        }
        public class CustomerHobbyConfiguration : EntityTypeConfiguration<CustomerHobby>
        {
            public CustomerHobbyConfiguration()
            {
                this.ToTable("CustomerHobbies");
                this.HasKey(P => P.Id);
            }
        }
        public class NumberConfiguration : EntityTypeConfiguration<Number>
        {
            public NumberConfiguration()
            {
                this.ToTable("Numbers");
                this.HasKey(P => P.Id);
            }
        }
        public class NumberTypeConfiguration : EntityTypeConfiguration<NumberType>
        {
            public NumberTypeConfiguration()
            {
                this.ToTable("NumberTypes");
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
                this.ToTable("FingerPrintClasses");
                this.HasKey(P => P.Id);
                this.Property(p => p.Name).HasMaxLength(200);
            }
        }
        public class CustomerFingerPrintConfiguration : EntityTypeConfiguration<CustomerFingerPrint>
        {
            public CustomerFingerPrintConfiguration()
            {
                this.ToTable("CustomerFingerPrints");
                this.HasKey(P => P.Id);
            }
        }
        public class UserFingerPrintConfiguration : EntityTypeConfiguration<UserFingerPrint>
        {
            public UserFingerPrintConfiguration()
            {
                this.ToTable("UserFingerPrints");
                this.HasKey(P => P.Id);
            }
        }
        #endregion
    }
}
