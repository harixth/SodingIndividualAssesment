using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Individual_Assesment.Models
{
    public class NhibernateHelper
    {
        public static ISession OpenSession()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
            .Database(MySQLConfiguration.Standard
            .ConnectionString(c => c.FromConnectionStringWithKey("taskDB")))
            .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
            .BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}