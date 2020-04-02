using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCoverterPart2.Services
{
    public class ConvertersService
    {
        ILifetimeScope scope;

        public ConvertersService(ILifetimeScope scope)
        {
            this.scope = scope;
        }

        public List<IConverter> GetConverters()
        {
            List<IConverter> converters = new List<IConverter>();

            converters.AddRange(this.scope.Resolve<IEnumerable<IConverter>>());


            return converters;
        }
    }
}
