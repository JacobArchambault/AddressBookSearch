using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using static System.IO.File;

namespace AddressBookSearch
{
    public partial class Form1 : Form
    {
        // Create a new entry list with some sample data.
        private readonly List<Entry> entryList = new List<Entry>()
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
            // Add entries from our sample list to a new text file on initializing the form.
            InitializeComponent();
            AddEntries(entryList, "address-book.txt");
        }

        internal void AddEntries(List<Entry> fromEntryList, string toFile)
        {
            // Create a file with the file name passed in as a string parameter, and a StreamWriter object to write to it. 
            using StreamWriter writer = CreateText(toFile);
            // With the StreamWriter, for each entry in the entry list passed in...
            fromEntryList.ForEach(entry =>
            {
                // ...write that entry's name and phone number to the file on a single line.
                writer.WriteLine($"{entry.FirstName} {entry.LastName}, \t{entry.PhoneNumber}");
            });
        }

        // On clicking the search button...
        private void searchButton_Click(object sender, EventArgs e)
        {
            // Create a streamreader object with which to read the address-book.txt file
            using StreamReader reader = new StreamReader("address-book.txt");
            // Reset the results textbox.
            resultsTextBox.Text = "";
            do
            {
                // read each line of the file
                string record = reader.ReadLine();
                // If the line contains the text the reader enters into the search box,
                if (record.Contains(searchTextBox.Text))
                {
                    // then append it to the results textbox on its own line.
                    resultsTextBox.Text += record;
                    resultsTextBox.AppendText(Environment.NewLine);
                }
                // ...until the end of the file is reached.
            } while (!reader.EndOfStream);
        }
    }
}
