using System;
using System.Collections.Generic;
using System.IO;

namespace Chat_Bot
{
    class Bot
    // Текстовый бот
    {
        // Basic fields
        private string _Name_;
        private string _User_;
        protected Dictionary<Keyword, List<string>> Keywords;
        protected Dictionary<Keyword, List<string>> Responses;
        protected List<string> HistoryMessages;

        // Properties
        public string Name { get => _Name_; set => _Name_ = value; }
        public string User { get => _User_; set => _User_ = value; }

        // Init
        public Bot(string Name, string User)
        {
            this.Name = Name;
            this.User = User;
            HistoryMessages = new List<string>();

            /*  Keywords  */
            Keywords = new Dictionary<Keyword, List<string>>
            {
                /*  Greetings   */
                [Keyword.Hello] = new List<string>() {
                "привет", "приветствую", "здравствуй", "здравствуйте" },

                /*  Farewells   */
                [Keyword.Bye] = new List<string>() {
                "пока", "прощай", "до свидания", "всего доброго" },

                /*  Name   */
                [Keyword.Name] = new List<string>() {
                "имя", "как тебя зовут" }
            };

            /*  Aliases  */
            Responses = new Dictionary<Keyword, List<string>>
            {
                [Keyword.Hello] = new List<string>(),
                [Keyword.Bye] = new List<string>(),
                [Keyword.Name] = new List<string>(),
            };

            Responses[Keyword.Hello].Add($"Привет!");
            Responses[Keyword.Hello].Add($"Привет, {User}!");
            Responses[Keyword.Hello].Add($"Здравствуйте!");
            Responses[Keyword.Hello].Add($"Здравствуйте, {User}!");

            Responses[Keyword.Bye].Add($"Пока!");
            Responses[Keyword.Bye].Add($"Прощай!");
            Responses[Keyword.Bye].Add($"До свидания!");
            Responses[Keyword.Bye].Add($"Пока, {User}!");
            Responses[Keyword.Bye].Add($"Прощай, {User}!");
            Responses[Keyword.Bye].Add($"До свидания, {User}!");

            Responses[Keyword.Name].Add($"Меня зовут, {Name}");
            Responses[Keyword.Name].Add($"Моё имя - {Name}");
            Responses[Keyword.Name].Add($"Я - {Name}");
        }

        ~Bot()
        {
        }

        public string SayGreetings()
        {
            return $"{User} вошёл в чат!";
        }

        public static string ChatMessageFormat(string Name, string Text)
        {
            return $"{Name} ({DateTime.Now.ToString("HH:mm:ss")}): {Text}";
        }

        protected string SayResponse(Keyword key)
        {
            if (key == Keyword.Hello || key == Keyword.Bye || key == Keyword.Name)
            {
                var RandomIndex = new Random().Next(Responses[key].Count);
                return Responses[key][RandomIndex];
            }
            return "?";
        }

        protected Keyword GetKeyword(string Message)
        {
            foreach (var pair in Keywords)
            {
                foreach (var word in pair.Value)
                {
                    if (Message.ToLower().Contains(word))
                    {
                        return pair.Key;
                    }
                }
            }
            return Keyword.Unknown;
        }

        public string Answer(string Message)
        {
            string Output = SayResponse(GetKeyword(Message));
            return ChatMessageFormat(Name, Output);
        }
    }
}