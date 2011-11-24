namespace School_Survey_Timetabling.Model
{
    internal abstract partial class Employee : SchoolEntity
    {
        protected enum EmployeeRole
        {
            Administrator,
            Teacher,
            Volant,
        }
    }
}
