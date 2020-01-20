using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Lab
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database CurrentDatabase = new Database();

        public MainWindow()
        {
            InitializeComponent();

            //DatabaseGrid.ItemsSource = null;
            DatabaseGrid.ItemsSource = CurrentDatabase.Storage;
        }

        public bool IsGroupEnabled
        {
            get { return CurrentDatabase.Filename == string.Empty; }
        }

        private void Open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Database files (*.nocsv)|*.nocsv|All files (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };

            try
            {
                if (openFileDialog.ShowDialog() == true)
                {
                    CurrentDatabase.LoadFromFile(openFileDialog.FileName);
                    DatabaseGrid.Items.Refresh();
                    groupGrid.IsEnabled = true;
                    logStatus.Text = $"The database is loaded!";
                    this.Title = $"{openFileDialog.SafeFileName} | " + Title;
                }
            }
            catch (Exception Error)
            {
                logStatus.Text = Error.Message;
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                CurrentDatabase.SaveToFile();
                logStatus.Text = $"The database is saved - {CurrentDatabase.Filename}!";
            }
            catch (Exception Error)
            {
                logStatus.Text = Error.Message;
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            CurrentDatabase.Clear();
            RefreshGrid();
            groupGrid.IsEnabled = DatabaseGrid.HasItems;
            logStatus.Text = "Ready";
            this.Title = Title.Substring(Title.IndexOf('|') + 2); ;
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Database files (*.nocsv)|*.nocsv|All files (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };

            try
            {
                if (saveFileDialog.ShowDialog() == true)
                {
                    File.WriteAllText(saveFileDialog.FileName, Database.HEADER);

                    CurrentDatabase.LoadFromFile(saveFileDialog.FileName);

                    RefreshGrid();
                    groupGrid.IsEnabled = true;
                    logStatus.Text = $"The database is created!";
                    this.Title = $"{saveFileDialog.SafeFileName} | " + Title;
                }
            }
            catch (Exception Error)
            {
                logStatus.Text = Error.Message;
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
        }

        private void RefreshGrid(int rowIndex = -1)
        {
            DatabaseGrid.ItemsSource = null;
            DatabaseGrid.ItemsSource = CurrentDatabase.Storage;
            DatabaseGrid.SelectedIndex = rowIndex;
        }

        private void Action_Node(object sender, RoutedEventArgs e)
        {
            var key = ((Button)sender).Tag.ToString();
            var index = -1;

            try
            {
                Employee Node = new Employee()
                {
                    ID = idBox.Text,
                    LastName = lastNameBox.Text,
                    Mail = mailBox.Text,
                    Job = jobBox.Text,
                    HireDate = hireDatePicker.Text
                };

                switch (key)
                {
                    case "add_act":
                        CurrentDatabase.Add(Node);
                        logStatus.Text = "The entered information about the new employee was added";
                        index = CurrentDatabase.Storage.IndexOf(Node);
                        break;
                    case "delete_act":
                        CurrentDatabase.Delete(Node);
                        logStatus.Text = "The entered employee's information was found and removed!";
                        index = CurrentDatabase.Storage.IndexOf(Node);
                        break;
                    case "update_act":
                        CurrentDatabase.Update(Node);
                        logStatus.Text = "The entered employee's information was found and updated!";
                        index = CurrentDatabase.Storage.IndexOf(Node);
                        break;
                    case "find_act":
                        index = CurrentDatabase.Find("ID", idBox.Text, out Node);
                        if (index >= 0)
                            logStatus.Text = $"Found > {Node.ToString()}";
                        else
                            logStatus.Text = "The employee with entered ID wasn't found! ";
                        break;
                    default:
                        break;
                }
                RefreshGrid(index);
            }
            catch (Exception error)
            {
                logStatus.Text = error.Message;
            }
        }

        private void Force_Sort(object sender, RoutedEventArgs e)
        {
            var property = ((MenuItem)sender).Tag.ToString();
            CurrentDatabase.Sort(property);
            RefreshGrid();
            logStatus.Text = $"> The database was sorted by {((MenuItem)sender).Header}!";
        }
    }
}