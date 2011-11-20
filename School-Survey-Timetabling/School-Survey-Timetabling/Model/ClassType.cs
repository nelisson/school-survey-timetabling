using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace School_Survey_Timetabling.Model
{
    internal enum ClassType
    {
        [Description("")]
        Normal,

        [Description("P")]
        Progression,

        [Description("J")]
        Kindergarten,
    }
}
