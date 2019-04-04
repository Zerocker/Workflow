using System;
using System.IO;
using System.Collections.Generic;
using System.Windows;

namespace Chat_Bot
{
    class History
    {
        List<string> OldMessages;
        readonly string Filename;

        public History(string Path)
        {
            OldMessages = new List<string>();
            Filename = Path; 
        }

        public bool IsExists()
        {
            return File.Exists(Filename);
        }

        public int Count()
        {
            return OldMessages.Count;
        }

        public bool IsEmpty()
        {
            return File.ReadAllText(Filename).Length == 0;
        }

        public void Add(string Message)
        {
            OldMessages.Add(Message);
        }

        public string GetMessages()
        {
            var Output = "";
            foreach (var message in OldMessages)
            {
                Output += message + "\n";
            }
            return Output;
        }

        public void Clear()
        {
            try
            {
                OldMessages.Clear();
                File.WriteAllText(Filename, string.Empty);
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message);
            }
        }

        public void Write()
        {
            try
            {
                using (StreamWriter File = new StreamWriter(Filename, false, System.Text.Encoding.Default))
                {
                    foreach (var message in OldMessages)
                    {
                        File.WriteLine(message);
                    }
                }
                OldMessages.Clear();
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message);
            }

        }

        public bool Read()
        {
            try
            {
                if (File.Exists(Filename) && !IsEmpty())
                {
                    using (StreamReader File = new StreamReader(Filename, System.Text.Encoding.Default))
                    {
                        string Line;
                        while ((Line = File.ReadLine()) != null)
                        {
                            OldMessages.Add(Line);
                        }
                    }
                }
                return true;
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.Message);
                return false;
            }
        }
    }
}
