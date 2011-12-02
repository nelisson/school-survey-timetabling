using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using School_Survey_Timetabling.Model;

namespace SchoolTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TeacherInsert()
        {

           
            using (var db = new EmefFatima())
            {
                var user = db.Employees.OfType<Teacher>().First();
                
            }
        }
    }
}
