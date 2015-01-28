namespace AutofacDynamicContext.EF
{
    using AutofacDynamicContext.Domain;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public interface ISampleContext { }

    public class SampleContext : DbContext, ISampleContext
    {
        public SampleContext()
            : base("name=SampleContext")
        {
        }

        public SampleContext(string name) : base(name)
        {
        }

        public virtual DbSet<Employee> MyEntities { get; set; }
    }

}