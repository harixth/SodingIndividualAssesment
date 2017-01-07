using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace Individual_Assesment.Models
{
    public class TaskMap : ClassMap<Task>
    {
        public TaskMap()
        {
            Table("Task");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
        }
    }
}