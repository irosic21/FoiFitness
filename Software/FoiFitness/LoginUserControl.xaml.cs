using BusinessLogicLayer;
using FoiFitness.utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
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

namespace FoiFitness
{
    /// <summary>
    /// Interaction logic for LoginUserControl.xaml
    /// </summary>
    public partial class LoginUserControl : UserControl
    {
        public AuthWindow parentWindow;
        public LoginUserControl(AuthWindow parentWindow1)
        {
            InitializeComponent();
            parentWindow = parentWindow1;
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = Hash.HashPassword(txtPassword.Password.ToString());

            var credentialsValid = UserRepository.CheckCredentials(username, password);
            if (!credentialsValid)
            {
                MessageBox.Show("Neispravno korisnicko ime ili lozinka!");
            }
            else
            {
                // Spremanje prijavljenog korisnika
                UserRepository.SaveCurrentUser(username);

                var mainWindow = new MainWindow();
                mainWindow.Show();
                this.parentWindow.Close();
            }
        }


        private bool CheckUsernameInput()
        {
            string username = txtUsername.Text;
            if (!InputValidator.ValidateUsername(username))
            {
                errorUsername.Content = "Korisnicko ime mora biti izmedu 3 i 20 znakova, bez specijalnih znakova!";
                errorUsername.Visibility = Visibility.Visible;
                txtUsername.BorderBrush = Brushes.Red;
                txtUsername.BorderThickness = new Thickness(2);
                return false;
            }

            return true;
        }

        private void btnGoToRegister_Click(object sender, RoutedEventArgs e)
        {
            this.parentWindow.Height = 800;
            var registerUserControl = new RegisterUserControl(parentWindow);
            parentWindow.contentControl.Content = registerUserControl;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtUsername.Focus();
        }
    }
}
