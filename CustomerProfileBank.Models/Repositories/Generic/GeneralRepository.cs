using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustomerProfileBank.Models.Repositories.Generic
{
    public abstract class GeneralRepository<context, Entity> : IGeneralRepository<Entity>
        where Entity : class
        where context : DbContext, new()
    {

        private context _entities = new context();
        public context Context
        {

            get { return _entities; }
            set { _entities = value; }
        }
        public virtual IEnumerable<Entity> GetAll()
        {


            IEnumerable<Entity> query = _entities.Set<Entity>();
            return query;
        }

        public virtual Entity FindById(int id)
        {
            Entity query = null;
            try
            {
                query = _entities.Set<Entity>().Find(id);
                return query;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public virtual IQueryable<Entity> FindBy(System.Linq.Expressions.Expression<Func<Entity, bool>> predicate)
        {

            IQueryable<Entity> query = _entities.Set<Entity>().Where(predicate);
            return query;
        }

        public virtual Entity Add(Entity entity)
        {
            _entities.Set<Entity>().Add(entity);
            Save();
            return entity;
        }
        public virtual bool Delete(int Id)
        {
            Entity query = _entities.Set<Entity>().Find(Id);
            _entities.Set<Entity>().Remove(query);
            Save();
            return true;
        }
        public virtual Entity Edit(Entity entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
            Save();
            return entity;
        }



        public virtual Entity Edit(Entity entityOld, Entity entityNew)
        {
            _entities.Entry(entityOld).CurrentValues.SetValues(entityNew);
            Save();
            return entityNew;
        }
        public virtual void Save()
        {
            try
            {
                _entities.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
            }
        }

        public virtual IQueryable<Entity> Include(Expression<Func<Entity, object>> includes)
        {
            IQueryable<Entity> query = _entities.Set<Entity>().Include(includes);
            return query;
            //if (includes != null)
            //{
            //    query = includes.Aggregate(query,
            //              (current, include) => current.Include(include));
            //}

            //return query;
        }

        public virtual Expression<Func<TElement, bool>> BuildContainsExpression<TElement, TValue>(

             Expression<Func<TElement, TValue>> valueSelector, IEnumerable<TValue> values)

        {

            if (null == valueSelector) { throw new ArgumentNullException("valueSelector"); }

            if (null == values) { throw new ArgumentNullException("values"); }

            ParameterExpression p = valueSelector.Parameters.Single();

            // p => valueSelector(p) == values[0] || valueSelector(p) == ...

            if (!values.Any())

            {

                return e => false;

            }

            var equals = values.Select(value => (Expression)Expression.Equal(valueSelector.Body, Expression.Constant(value, typeof(TValue))));

            var body = equals.Aggregate<Expression>((accumulate, equal) => Expression.Or(accumulate, equal));

            return Expression.Lambda<Func<TElement, bool>>(body, p);

        }

    }
}
