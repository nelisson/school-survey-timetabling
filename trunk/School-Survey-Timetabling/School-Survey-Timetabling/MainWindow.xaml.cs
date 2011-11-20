using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using School_Survey_Timetabling.Model;
using System.Collections.Generic;
using Extensions;

namespace School_Survey_Timetabling
{
    [ContractVerification(true)]
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Buttonf_Click(object sender, RoutedEventArgs e)
        {
            var escola = new EmefFatima();
            var teacher = new Teacher {Name = "Manolo", Workload = TimeSpan.FromHours(40)};
            var disc = new Discipline {Name = "Math", Teacher = teacher, Workload = TimeSpan.FromHours(10)};
            teacher.Disciplines.Add(disc);

            escola.Employees.InsertOnSubmit(teacher);
            escola.Disciplines.InsertOnSubmit(disc);

            escola.SubmitChanges();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            var escola = new EmefFatima();
            foreach (Teacher employee in escola.Employees.OfType<Teacher>())
            {
                Console.WriteLine(employee.Disciplines.FirstOrDefault());
            }
            foreach (Discipline discipline in escola.Disciplines)
            {
                Console.WriteLine(discipline);
            }
        }
    }
}