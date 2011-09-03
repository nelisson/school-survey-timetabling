using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Globalization;

namespace School_Survey_Timetabling
{
    [Table(Name = "TabelaTeste")]
    public class TesteLINQ
    {
        [ContractVerification(false)]
        public int ID { get; set; }
        public float Teste { get; set; }

        [ContractInvariantMethod]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Required for code contracts.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(Teste >= 0);
        }

        public int M(string s)
        {
            Contract.Requires<ArgumentNullException>(s != null, "s nao pode ser null omg.");
            //Contract.Ensures(Contract.Result<List<int>>().TrueForAll((i) => i > 0));
            Contract.Ensures(Contract.Result<int>() > 0);
            Teste = -3;
            //return new List<int> { -1, 2, 3, 4, 5 };
            return -5;
        }

        public void M2()
        {
            var x = M(null);
        }
    }
}