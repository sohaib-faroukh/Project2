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
    public class RoleRepo : GeneralRepository<DataBaseContext, Role>
    {

        /// <summary>
        /// add role to database repository
        /// </summary>
        /// <param name="entity">new role</param>
        /// <returns></returns>
        public override Role Add(Role entity)
        {

            #region Users
            // Users
            if (entity.Users != null && entity.Users.Count > 0)
            {
                var entityUsers = entity.Users.ToList();
                entity.Users.Clear();
                Console.WriteLine(entityUsers);

                List<User> users = new List<User>();

                if (entityUsers != null && entityUsers.Count > 0)
                {
                    foreach (var _ele_ in entityUsers)
                    {
                        var item = this.Context.Users.FirstOrDefault(ele => ele.Id == _ele_.Id);
                        if (item != null)
                        {
                            users.Add(item);
                        }
                    }

                    entity.Users = users;
                }
            }
            else
            {
                entity.Users = new List<User>();
            }

            #endregion


            #region Privileges

            // Users
            if (entity.Privileges != null && entity.Privileges.Count > 0)
            {
                var entityPrivileges = entity.Privileges.ToList();
                entity.Privileges.Clear();
                Console.WriteLine(entityPrivileges);

                List<Privilege> privileges = new List<Privilege>();

                if (entityPrivileges != null && entityPrivileges.Count > 0)
                {
                    foreach (var _ele_ in entityPrivileges)
                    {
                        var item = this.Context.Privileges.FirstOrDefault(ele => ele.Id == _ele_.Id);
                        if (item != null)
                        {
                            privileges.Add(item);
                        }
                    }

                    entity.Privileges = privileges;
                }
            }
            else
            {
                entity.Privileges = new List<Privilege>();
            }


            #endregion


            Context.Roles.Add(entity);

            Context.SaveChanges();

            return entity;
        }

        /// <summary>
        /// update role in database 
        /// </summary>
        /// <param name="entity">new role</param>
        /// <returns></returns>
        public override Role Edit(Role entity)
        {
            #region Users
            // Users
            if (entity.Users != null && entity.Users.Count > 0)
            {
                var entityUsers = entity.Users.ToList();
                entity.Users.Clear();
                Console.WriteLine(entityUsers);

                List<User> users = new List<User>();

                if (entityUsers != null && entityUsers.Count > 0)
                {
                    foreach (var _ele_ in entityUsers)
                    {
                        var item = this.Context.Users.FirstOrDefault(ele => ele.Id == _ele_.Id);
                        if (item != null)
                        {
                            users.Add(item);
                        }
                    }

                    entity.Users = users;
                }
            }
            else
            {
                entity.Users = new List<User>();
            }

            #endregion


            #region Privileges

            // Privileges
            if (entity.Privileges != null && entity.Privileges.Count > 0)
            {
                var entityPrivileges = entity.Privileges.ToList();
                entity.Privileges.Clear();
                Console.WriteLine(entityPrivileges);

                List<Privilege> privileges = new List<Privilege>();

                if (entityPrivileges != null && entityPrivileges.Count > 0)
                {
                    foreach (var _ele_ in entityPrivileges)
                    {
                        var item = this.Context.Privileges.FirstOrDefault(ele => ele.Id == _ele_.Id);
                        if (item != null)
                        {
                            privileges.Add(item);
                        }
                    }

                    entity.Privileges = privileges;
                }
            }
            else
            {
                entity.Privileges = new List<Privilege>();
            }


            #endregion

            Context.Entry(entity).State = EntityState.Modified;

            Context.SaveChanges();

            return entity;
        }

    }
}
