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
            if (entity.Roles != null && entity.Roles.Count > 0)
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
            }
            else
            {
                entity.Roles = new List<Role>();
            }

            Context.Users.Add(entity);

            Context.SaveChanges();

            return entity;
        }

        public override User Edit(User newEntity)
        {
            if (newEntity.Roles != null && newEntity.Roles.Count > 0)
            {
                var entityRoles = newEntity.Roles.ToList();
                newEntity.Roles.Clear();
                List<Role> roles = new List<Role>();
                foreach (var role in entityRoles)
                {
                    var roleToAdd = this.Context.Roles.FirstOrDefault(ele => ele.Id == role.Id);
                    if (roleToAdd != null)
                    {
                        roles.Add(roleToAdd);
                    }
                }

                newEntity.Roles = roles;
            }

            else
            {
                newEntity.Roles = new List<Role>();
            }

            Context.Entry(newEntity).State = EntityState.Modified;

            Context.SaveChanges();

            return newEntity;
        }
    }
}
