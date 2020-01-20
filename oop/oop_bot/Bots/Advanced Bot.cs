using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Net;
using System.Xml;
using System.Data;

namespace Chat_Bot
{
    class AdvancedBot : Bot
    {
        private List<double> Args;

        public AdvancedBot(string Name, string User)
            : base(Name, User)
        {
            Args = new List<double>();
            
            /*  Time  */
            Keywords.Add(Keyword.Time, new List<string>() { "время", "который час", "времени" });

            /*  Sub  */
            Keywords.Add(Keyword.Add, new List<string>() { "сложить", "прибавь", "прибавить", "сложи" });

            /*  Sub  */
            Keywords.Add(Keyword.Sub, new List<string>() { "вычти", "вычесть", "отнять", "отнеми" });

            /*  Mult  */
            Keywords.Add(Keyword.Mult, new List<string>() { "умножь", "умножение", "умножить" });

            /*  Div  */
            Keywords.Add(Keyword.Div, new List<string>() { "деление", "дели", "разделить", "подели", "делить" });

            /*  Exchange  */
            Keywords.Add(Keyword.Exchange,  new List<string>() { "курс", "курс валют", "валюты" });

            /*  Run  */
            Keywords.Add(Keyword.Run, new List<string>() { "выполни", "запусти"});

            /*  Math  */
            Keywords.Add(Keyword.Math, new List<string>() { "+", "-", "/", "*", "%" });
        }

        ~AdvancedBot() { }

        /* ------------------------------------------------------------------ */

        public string CurrentTime()
        {
            return $"{DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm")}";
        }

        public string RunProgram(string Message)
        {
            string[] Words = Message.Split(' ');
            Process.Start(Words[1]);
            return $"Открывается {Words[1]}";
        }

        protected string Add()
        {
            return $"{Args[0] + Args[1]}";
        }

        protected string Sub()
        {
            return $"{Args[0] - Args[1]}";
        }

        protected string Div()
        {
            return $"{Args[0] / Args[1]}";
        }

        public string Mult()
        {
            return $"{Args[0] * Args[1]}";
        }

        protected bool TryParse(string Message)
        {
            string[] Numbers = Regex.Split(Message, @"([-+]?[0-9]*\.?[0-9]+)");

            if (Numbers.GetLength(0) != 5)
                return false;

            foreach (string value in Numbers)
            {
                if (!string.IsNullOrEmpty(value) 
                    && double.TryParse(value, System.Globalization.NumberStyles.Any, 
                    System.Globalization.CultureInfo.InvariantCulture, out double num))
                {
                    Args.Add(num);
                }
            }

            return true;
        }

        protected string SayMath(string Message)
        {
            return new DataTable().Compute(Message, null).ToString();
        }

        /* ------------------------------------------------------------------ */

        protected XmlDocument GetExchange()
        {
            string UrlAddress = "http://www.cbr.ru/scripts/XML_daily.asp/";
            XmlDocument xDoc = new XmlDocument();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(UrlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                xDoc.Load(UrlAddress);
            }

            return xDoc;
        }

        public string Exchange()
        {
            string Output = "\n";
            XmlElement xRoot = GetExchange().DocumentElement;

            foreach (XmlNode xnode in xRoot)
            {
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "Name")
                        Output += $"1 {childnode.InnerText} = ";
                    if (childnode.Name == "Value")
                        Output += $"{childnode.InnerText}₽ \n";
                }
            }
            return Output;
        }

        /* ------------------------------------------------------------------ */

        public new string Answer(string Message)
        {
            string Output = "";
            Keyword Key = GetKeyword(Message);

            switch (Key)
            {
                case Keyword.Add:
                    if (TryParse(Message))
                        Output = Add();
                    break;

                case Keyword.Sub:
                    if (TryParse(Message))
                        Output = Sub();
                    break;

                case Keyword.Div:
                    if (TryParse(Message))
                        Output = Div();
                    break;

                case Keyword.Mult:
                    if (TryParse(Message))
                        Output = Mult();
                    break;

                case Keyword.Time:
                    Output = CurrentTime();
                    break;

                case Keyword.Exchange:
                    Output = Exchange();
                    break;

                case Keyword.Run:
                    Output = RunProgram(Message);
                    break;

                case Keyword.Math:
                    Output = SayMath(Message);
                    break;

                default:
                    Output = SayResponse(Key);
                    break;
            }

            Args.Clear();
            return ChatMessageFormat(Name, Output);
        }
    }
}
