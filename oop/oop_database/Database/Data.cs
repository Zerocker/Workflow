using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Lab
{
    public class Database
    {
        /*  Спецификация файла .nocsv:
         *  1. Файл должен начинаться с заголовка ID,LASTNAME,E-MAIL,JOB,HIREDATE
         *  2. Каждая строка файла — это одна строка таблицы, данные для объета Employee.
         *  3. Разделителем значений колонок является ";"
         * 
         *  Каждое поле в строке должно соответствовать своёму типу, заданному в Employee:
         *      ID: целое безнаковое
         *      LastName: любая строка без символа разделителя
         *      Mail: строка с форматом адреса электронной почты
         *      Job: тип сотрудника
         *      HireDate: число.месяц.год
         *      
         *  Типы сотрудников:
         *      SA_MAN, SA_REP, SA_CLERK, ST_MAN, ST_CLERK, SH_MAN, SH_CLERK, UNKNOWN
         */

        public const string HEADER = "ID;LASTNAME;E-MAIL;JOB;HIREDATE";
        public const string EXTENSION = ".nocsv";
        public const string SEPARATOR = ";";

        public List<Employee> Storage { get; private set; }
        public string Filename { get; private set; }
        public Database()
        {
            Storage = new List<Employee>();
        }

        public int Count
        {
            get { return Storage.Count; }
        }

        public bool HasOnlyHeader(string filename)
        {
            return (File.Exists(filename) && File.ReadAllText(filename).Contains(HEADER));
        }

        public bool LoadFromFile(string path)
        {
            Storage.Clear();
            if (File.Exists(path))
            {
                using (TextFieldParser parser = new TextFieldParser(path))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(SEPARATOR);
                    if (!parser.ReadLine().Contains(HEADER))
                        throw new System.Exception($"Invaid file format: {path}!");
                       
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        var node = new Employee(fields[0], fields[1], fields[2], fields[3], fields[4]);
                        Storage.Add(node);
                    }
                }
                Filename = path;
                return true;
            }
            else
                throw new System.Exception($"Unable to open {path}!");
        }


        public void SaveToFile()
        {
            if (File.Exists(Filename) && File.ReadLines(Filename).First().Contains(HEADER))
            {
                using (var file = new StreamWriter(Filename, false, System.Text.Encoding.Default))
                {
                    file.WriteLine(HEADER);
                    foreach (var node in Storage)
                    {
                        var field = $"{node.ID}" + SEPARATOR +
                                    $"{node.LastName}" + SEPARATOR +
                                    $"{node.Mail}" + SEPARATOR + 
                                    $"{node.Job}" + SEPARATOR + 
                                    $"{node.HireDate}";
                        file.WriteLine(field);
                    }
                }
            }
            else
                throw new System.Exception($"Unable to save {Filename}!");
        }

        public void Add(Employee node)
        {
            if (!Storage.Any(item => item.GetHashCode() == node.GetHashCode() && item.ID == node.ID))
                Storage.Add(node);
            else
                throw new System.Exception("The entered employee's information is already in the database!");
        }

        public void Delete(Employee node)
        {
            if (!Storage.Any(item => item.GetHashCode() == node.GetHashCode()))
                throw new System.Exception("The entered employee's information does not exist in the database!");

            Storage = Storage.Where(item => item.GetHashCode() != node.GetHashCode()).ToList();
        }

        public void Update(Employee node)
        {
            if (!Storage.Any(item => item.ID == node.ID))
                throw new System.Exception("The entered employee's information does not exist in the database!");

            var index = Storage.FindIndex(item => item.ID == node.ID);
            if (index < Storage.Count && index > -1)
                Storage[index] = node;
        }

        public void Sort(string property)
        {
            Storage = Storage.OrderBy(item => item.GetType().GetProperty(property).GetValue(item, null)).ToList();
        }

        public int Find(string property, string value, out Employee Node)
        {
            int count = 0;
            foreach (var item in Storage)
            {
                if (item.GetType().GetProperty(property).GetValue(item, null).ToString() == value)
                {
                    Node = item;
                    return count;
                }
                else
                    count++;
            }
            Node = new Employee();
            return -1;
        }

        public void Clear()
        {
            Storage.Clear();
            Filename = string.Empty;
        }

        public override string ToString()
        {
            return string.Concat(Storage.Select(item => item.ToString() + "\n"));
        }
    }
}
