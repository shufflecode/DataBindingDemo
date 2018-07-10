using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingDemo.Models
{
    public class TableViewModel
    {
        public TableViewModel(string foo, List<TableEntry> tableEntries)
        {
            Name = foo;
            Entries = new ObservableCollection<TableEntry>();
            foreach (var tableEntry in tableEntries)
            {
                Entries.Add(tableEntry);
            }

        }

        public ObservableCollection<TableEntry> Entries { get; set; }

        public string Name { get; set; }
    }


    public class TableEntry : INotifyPropertyChanged
    {
        public int Lenght { get; set; }

        public string Name { get; set; }

        public Type VariableType { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
