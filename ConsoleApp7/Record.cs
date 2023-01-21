using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
   public class Record
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public Record()
            : this("unnamed", String.Empty)
        {

        }
        public Record(string name) : this(name, "") { }
        public Record(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }
        public static Record Parse(string input)
        {   if (input == "" || input.LastIndexOf('-') == -1)
                throw new ArgumentException("Invalid format");
            string name = input.Substring(0, input.IndexOf('-')).Trim();
            string phone = input.Substring(input.LastIndexOf('-') + 1).Trim();

            return new Record(name, phone);
        }
        public override string ToString()
        {
            return $"{Name} ----- {Phone}";
        }

        public static bool operator ==(Record record, Record record1)
        {
            return record.Name == record1.Name;
        }
        public static bool operator !=(Record record, Record record1)
        {
            return !(record.Name == record1.Name);
        }
        public override bool Equals(object? obj)
        {
            return Name == ((Record)obj).Name;    
        }
    }
}
