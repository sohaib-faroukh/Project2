using CustomerProfileBank.Models.Context;
using CustomerProfileBank.Models.Models;
using CustomerProfileBank.Models.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Repositories
{
    public class UserRepo : GeneralRepository<DataBaseContext, User>
    {
        public override User Add(User entity)
        {
            var entityRoles = entity.Roles.ToList();
            entity.Roles.Clear();
            Console.WriteLine(entityRoles);

            List<Role> roles = new List<Role>();

            if (entityRoles != null && entityRoles.Count > 0)
            {
                foreach (var role in entityRoles)
                {
                    var roleToAdd = this.Context.Roles.FirstOrDefault(ele => ele.Id == role.Id);
                    if (roleToAdd != null)
                    {
                        roles.Add(roleToAdd);
                    }
                }

                entity.Roles = roles;
            }

            Context.Users.Add(entity);

            Context.SaveChanges();

            return entity;
        }

        public override User Edit(User entity)
        {
            var entityRoles = entity.Roles.ToList();
            entity.Roles.Clear();

            List<Role> roles = new List<Role>();

            if (entityRoles != null && entityRoles.Count > 0)
            {
                foreach (var role in entityRoles)
                {
                    var roleToAdd = this.Context.Roles.FirstOrDefault(ele => ele.Id == role.Id);
                    if (roleToAdd != null)
                    {
                        roles.Add(roleToAdd);
                    }
                }

                entity.Roles = roles;
                Context.Entry(entity).State = EntityState.Modified;
            }

            Context.SaveChanges();

            return entity;
        }
    }
}
