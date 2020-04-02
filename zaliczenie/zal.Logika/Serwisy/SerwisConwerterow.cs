using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zal.Logika.Serwisy
{
   public class SerwisConwerterow
    {
        ILifetimeScope scope;
        public SerwisConwerterow(ILifetimeScope scope)
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
