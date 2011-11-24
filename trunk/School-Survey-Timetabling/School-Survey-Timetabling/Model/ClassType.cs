namespace School_Survey_Timetabling.Model
{
    using System.ComponentModel;

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
