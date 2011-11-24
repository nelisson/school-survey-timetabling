using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
            _frame.Navigate(new Register());
        }

        private void Buttonf_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            var escola = new EmefFatima();
            foreach (Class employee in escola.Classes)
            {
                Console.WriteLine(employee.CycleYear);
            }
            foreach (CycleYear discipline in escola.CycleYears)
            {
                Console.WriteLine(discipline.Class);
            }
        }
    }
}