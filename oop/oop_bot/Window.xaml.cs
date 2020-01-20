using System;
using System.Windows;

namespace Chat_Bot
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AdvancedBot Bob;
        History Archive;
        string Username = "";
        string Botname = "Bob";
        
        public MainWindow()
        {
            InitializeComponent();
            InputName();
        
            Bob = new AdvancedBot(Botname, Username);
            Archive = new History($"{Botname} - {Username}.txt");

            RestoreHistory();
        }

        private void RestoreHistory()
        {
            Archive.Read();
            ChatText.Text = Archive.IsExists() && !Archive.IsEmpty() ? Archive.GetMessages() : Bob.SayGreetings() + "\n";
            ChatText.Focus();
            ChatText.CaretIndex = ChatText.Text.Length;
            ChatText.ScrollToEnd();
        }

        private void InputName()
        {
            while (Username == "")
            {
                NameDialog InputDialog = new NameDialog("Введите своё имя:");
                if (InputDialog.ShowDialog() == true)
                {
                    Username = InputDialog.Answer;
                }
                else
                {
                    Application.Current.Shutdown();
                }
            }
        }

        private void Menu_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Menu_EraseChatHistory(object sender, RoutedEventArgs e)
        {
            var DeleteRequest = MessageBox.Show(
                "Вы уверены, что хотите очистить историю сообщений?", 
                "Внимание!",
                MessageBoxButton.YesNo, 
                MessageBoxImage.Question
                );

            if (DeleteRequest == MessageBoxResult.Yes)
            {
                Archive.Clear();
                ChatText.Clear();
                ChatText.Text = "История сообщений удалена!" + "\n";
            }
        }

        private void Menu_Restart(object sender, RoutedEventArgs e)
        {
            var DeleteRequest = MessageBox.Show(
                "Вы уверены, что хотите очистить содержимое окна?",
                "Внимание!",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
                );

            if (DeleteRequest == MessageBoxResult.Yes)
            {
                ChatText.Clear();
            }
        }

        private void Menu_About(object sender, RoutedEventArgs e)
        {
            var DeleteRequest = MessageBox.Show(
                "Создано никем . . .",
                "О программе",
                MessageBoxButton.OK,
                MessageBoxImage.Question
                );
        }

        private void Send_Message(object sender, RoutedEventArgs e)
        {
            var UserMessage = $"{Bot.ChatMessageFormat("Me", MessageText.Text)}";
            var BotMessage = $"{Bob.Answer(MessageText.Text)}";

            MessageText.Clear();

            Archive.Add(UserMessage);
            Archive.Add(BotMessage);

            ChatText.Text += UserMessage + "\n";
            ChatText.Text += BotMessage + "\n";
            ChatText.ScrollToEnd();

            if (Archive.Count() % 10 == 0)
            {
                Archive.Write();
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            Archive.Write();

            base.OnClosing(e);
        }
    }
}
