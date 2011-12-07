using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace School_Survey_Timetabling.Model
{
    public abstract class DualAssociation<T1, T2>
        where T1 : AssociatedSchoolEntity<T1, T2>
        where T2 : AssociatedSchoolEntity<T1, T2>
    {

        protected internal abstract long IdFirst { get; set; }
        protected internal abstract long IdSecond { get; set; }

        protected EntityRef<T1> _first;

        protected EntityRef<T2> _second;

        public T1 First
        {
            get
            {
                return _first.Entity;
            }
            set
            {
                var previousValue = _first.Entity;
                if (previousValue == value && _first.HasLoadedOrAssignedValue) return;

                if (previousValue != null)
                {
                    _first.Entity = null;
                    previousValue.Association.Remove(this);
                }
                _first.Entity = value;
                if (value != null)
                {
                    value.Association.Add(this);
                    IdFirst = value.Id;
                }
                else
                {
                    IdFirst = default(int);
                }
            }
        }

        public T2 Second
        {
            get
            {
                return _second.Entity;
            }
            set
            {
                var previousValue = _second.Entity;
                if (previousValue == value && _second.HasLoadedOrAssignedValue) return;

                if ((previousValue != null))
                {
                    _second.Entity = null;
                    previousValue.Association.Remove(this);
                }
                _second.Entity = value;
                if ((value != null))
                {
                    value.Association.Add(this);
                    IdSecond = value.Id;
                }
                else
                {
                    IdSecond = default(int);
                }
            }
        }
    }
}

