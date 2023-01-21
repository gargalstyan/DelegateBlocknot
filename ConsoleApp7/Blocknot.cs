using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public class Blocknot : IEnumerable<Record>
    {
        public const string FileName = "NewBlocknot.txt";

        private List<Record> records;

        public Blocknot()
        {
            records = new List<Record>();
        }

        public void Add(Record record)
        {
            records.Add(record);
        }
        public bool Remove(string record)
        {
            IEnumerable<Record> recordsToRemove = Find(item => item.Name == record);
            foreach (Record item in recordsToRemove)
            {
                records.Remove(item);
                return true;
            }
            return false;
        }

        public bool SaveToFile()
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(FileName))
                {
                    foreach (var item in records)
                    {
                        streamWriter.WriteLine(item);
                    }
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public void LoadFromFile()
        {
            records.Clear();
            using (StreamReader streamReader = new StreamReader(FileName))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    Record record = Record.Parse(line);
                    records.Add(record);
                }
            }
        }
       
        public IEnumerable<Record> Find(Predicate<Record> predicate)
        {
            foreach (var item in records)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
        public IEnumerator<Record> GetEnumerator()
        {
            return records.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return records.GetEnumerator();
        }
    }
}
