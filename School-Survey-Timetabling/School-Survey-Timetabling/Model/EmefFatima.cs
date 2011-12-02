﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;

namespace School_Survey_Timetabling.Model
{
    [Database(Name = "Escola")]
    public sealed class EmefFatima : DataContext
    {
        private const string ConnectionString = "database.sdf";

        public EmefFatima()
            : base(ConnectionString)
        {
            if (!DatabaseExists())
                CreateDatabase();

            ObservableRooms = new ObservableCollection<Room>(Rooms);
            ObservableRooms.CollectionChanged += ObservableRooms_CollectionChanged;
        }

        void ObservableRooms_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Rooms.InsertAllOnSubmit(e.NewItems.Cast<Room>());
                    break;

                case NotifyCollectionChangedAction.Remove:
                    Rooms.DeleteAllOnSubmit(e.OldItems.Cast<Room>());
                    break;
            }
        }

        public Table<Discipline> Disciplines
        {
            get { return GetTable<Discipline>(); }
        }

        public Table<Employee> Employees
        {
            get { return GetTable<Employee>(); }
        }

        public Table<Block> Blocks
        {
            get { return GetTable<Block>(); }
        }

        public Table<Class> Classes
        {
            get { return GetTable<Class>(); }
        }

        public Table<CycleYear> CycleYears
        {
            get { return GetTable<CycleYear>(); }
        }

        public Table<Room> Rooms
        {
            get { return GetTable<Room>(); }
        }
        
        private Table<TeacherDiscipline> TeacherDisplines
        {
            get { return GetTable<TeacherDiscipline>(); }
        }

        public ObservableCollection<Room> ObservableRooms { get; private set; }
    }
}
