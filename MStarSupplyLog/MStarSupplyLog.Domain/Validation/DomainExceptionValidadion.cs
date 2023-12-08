using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStarSupplyLog.Domain.Validation
{
    public class DomainExceptionValidadion : Exception
    {
        public DomainExceptionValidadion(string error) : base(error) {}

        public static void When(bool hasError, string error)
        {
            if (hasError) 
                throw new DomainExceptionValidadion(error);
        }
    }
}
