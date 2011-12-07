using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using School_Survey_Timetabling.Model;
using ILOG.CP;

namespace SchoolTests
{
    [TestClass]
    public class Tests
    {
        [ClassInitialize]
        public static void Create(TestContext contex)
        {
            using (var db = new EmefFatima())
            {
                var teacher = new Teacher {Name = "Manolo", Workload = TimeSpan.FromHours(40)};
                var discipline = new Discipline {Name = "Math", Workload = TimeSpan.FromHours(4)};
                //discipline.

                db.Employees.InsertOnSubmit(teacher);
                db.Disciplines.InsertOnSubmit(discipline);
                db.SubmitChanges();
            }
        }

        [TestMethod]
        public void TeacherInsert()
        {
            using (var db = new EmefFatima())
            {
                var user = db.Employees.OfType<Teacher>().First();
                var disc = db.Disciplines.First();

                user.Disciplines.Add(disc);
                db.SubmitChanges();

                Assert.AreEqual(user.Disciplines.Count, disc.Teachers.Count);
                Assert.AreEqual(user.Disciplines.Count, 1);

                user.Disciplines.Remove(disc);

                db.SubmitChanges();
                Assert.AreEqual(user.Disciplines.Count, disc.Teachers.Count);
                Assert.AreEqual(user.Disciplines.Count, 0);
            }
        }
      
    }
}
