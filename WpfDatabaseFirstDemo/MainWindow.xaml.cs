using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDatabaseFirstDemo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UNIVERSITYEntities dbContext = new UNIVERSITYEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StudentsDataGrid.ItemsSource = dbContext.Students.ToList();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Ошибка загрузки: " + ex.Message);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Students newStudent = new Students
                {
                    FirstName = "Тест",
                    LastName = "Студент",
                    BirthDate = DateTime.Now.AddYears(-20)
                };
                dbContext.Students.Add(newStudent);
                dbContext.SaveChanges();
                LoadButton_Click(sender, e);
                MessageBox.Show("Студент добавлен!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления: " + ex.Message);
            }
        }
           
            protected override void OnClosed(EventArgs e)
            {
            dbContext.Dispose();
            base.OnClosed(e);
            }
        }
    }

