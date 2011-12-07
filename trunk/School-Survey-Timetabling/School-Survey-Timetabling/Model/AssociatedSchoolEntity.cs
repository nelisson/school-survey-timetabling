using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Diagnostics.Contracts;

namespace School_Survey_Timetabling.Model
{
    public abstract class AssociatedSchoolEntity<T1, T2> : SchoolEntity
        where T1 : AssociatedSchoolEntity<T1, T2>
        where T2 : AssociatedSchoolEntity<T1, T2>
    {
        public AssociatedSchoolEntity(bool thisSide)
        {
            if (thisSide)
                _association = new EntitySet<DualAssociation<T1, T2>>(e => { e.First = (T1)this; }, e => { e.First = null; });
            else
                _association = new EntitySet<DualAssociation<T1, T2>>(e => { e.Second = (T2)this; }, e => { e.Second = null; });
        }

        protected readonly EntitySet<DualAssociation<T1, T2>> _association;
        protected internal virtual EntitySet<DualAssociation<T1, T2>> Association
        {
            get { return _association; }
            set
            {
                Contract.Requires<ArgumentNullException>(value != null);
                _association.Assign(value);
                OnPropertyChanged("Association");
            }
        }
    }
}
