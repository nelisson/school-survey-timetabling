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
                var disc = db.Disciplines.First();

                user.Disciplines.Add(disc);
                db.SubmitChanges();

                Assert.AreEqual(user.Disciplines.Count, disc.Teachers.Count);
                Assert.AreEqual(user.Disciplines.Count, 1);
            }
        }

        [TestMethod]
        public void TeacherRemove()
        {
            using (var db = new EmefFatima())
            {
                var user = db.Employees.OfType<Teacher>().First();
                var disc = db.Disciplines.First();

                user.Disciplines.Remove(disc);

                db.SubmitChanges();
                Assert.AreEqual(user.Disciplines.Count, disc.Teachers.Count);
                Assert.AreEqual(user.Disciplines.Count, 0);
            }
        }
    }
}
