﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TribunalsVoting
{
    /// <summary>
    /// Interaction logic for AdminList.xaml
    /// </summary>
    public partial class AdminList : UserControl
    {
        //tanggalin mo nalang kung papalitan mo na ng value galing database
        public class DataObject
        {
            public int A { get; set; }
            public String B { get; set; }
        }

        public AdminList()
        {
            InitializeComponent();

            //tanggalin mo nalang kung papalitan mo na ng value galing database
            var list = new ObservableCollection<DataObject>();

            list.Add(new DataObject() { A = 1, B = "Carl Emerson L. Argente" });
            list.Add(new DataObject() { A = 2, B = "Tan" });
            list.Add(new DataObject() { A = 3, B = "Bersamin" });
            list.Add(new DataObject() { A = 4, B = "Cejo" });
            list.Add(new DataObject() { A = 5, B = "Argente" });
            list.Add(new DataObject() { A = 6, B = "Tan" });
            list.Add(new DataObject() { A = 7, B = "Bersamin" });
            list.Add(new DataObject() { A = 8, B = "Cejo" });
            list.Add(new DataObject() { A = 9, B = "Argente" });
            list.Add(new DataObject() { A = 10, B = "Tan" });
            list.Add(new DataObject() { A = 11, B = "Bersamin" });
            list.Add(new DataObject() { A = 12, B = "Cejo" });
            list.Add(new DataObject() { A = 13, B = "Argente" });
            list.Add(new DataObject() { A = 14, B = "Tan" });
            list.Add(new DataObject() { A = 15, B = "Bersamin" });
            list.Add(new DataObject() { A = 16, B = "Cejo" });
            this.dataGrid1.ItemsSource = list;

        }
    }
}