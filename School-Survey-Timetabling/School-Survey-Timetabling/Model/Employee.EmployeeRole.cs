namespace School_Survey_Timetabling.Model
{
    public abstract partial class Employee : SchoolEntity
    {
        protected enum EmployeeRole
        {
            Administrator,
            Teacher,
            Volant,
        }
    }
}
