using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using static System.IO.File;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddressBookSearch
{
    public partial class Form1 : Form
    {
        readonly List<Entry> entryList = new List<Entry>()
        {
            new Entry {FirstName = "Jeff", LastName = "Bezos", PhoneNumber = "0193857482" },
            new Entry {FirstName = "Bill", LastName = "Gates", PhoneNumber = "1059476859"},
            new Entry {FirstName = "Mark", LastName = "Zuckerberg", PhoneNumber = "1958473069"},
            new Entry {FirstName = "Bernard", LastName = "Arnault", PhoneNumber = "2837465986"},
            new Entry {FirstName = "Warren", LastName = "Buffett", PhoneNumber = "2968574966"},
            new Entry {FirstName = "Larry", LastName = "Ellison", PhoneNumber = "5421458908"},
            new Entry {FirstName = "Amancio", LastName = "Ortega", PhoneNumber = "3757486888"},
            new Entry {FirstName = "Jim", LastName = "Walton", PhoneNumber = "2958473633"},
            new Entry {FirstName = "Alice", LastName = "Walton", PhoneNumber = "7614239873"},
            new Entry {FirstName = "Rob", LastName = "Walton", PhoneNumber = "1234567890"}
        };
        public Form1()
        {
            InitializeComponent();
            AddEntries(entryList, "address-book.txt");
        }

        internal void AddEntries(List<Entry> fromEntryList, string toFile)
        {
            // Create a file with the name passed in as a string parameter, and a StreamWriter object to write to it. 
            using StreamWriter writer = CreateText(toFile);
            // With the StreamWriter, for each entry in the entry list passed in...
            fromEntryList.ForEach(entry =>
            {
                // ...get the entry number
                int entryNumber = fromEntryList.IndexOf(entry);
                // ...and write that entry's number, name, address, and phone number to the file on a single line.
                writer.WriteLine($"Entry {entryNumber + 1}:\t{entry.FirstName} {entry.LastName}, \t*{entry.PhoneNumber}*");
            });
        }

    }
}
