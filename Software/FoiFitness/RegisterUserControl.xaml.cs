using BusinessLogicLayer;
using FoiFitness.utils;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for RegisterUserControl.xaml
    /// </summary>
    public partial class RegisterUserControl : UserControl
    {
        public AuthWindow parentWindow;
        public RegisterUserControl(AuthWindow parentWindow1)
        {
            InitializeComponent();
            parentWindow = parentWindow1;
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            ClearErrorMessages();

            bool firstnameValid = CheckFirstNameInput();
            bool lastnameValid = CheckLastNameInput();
            bool usernameValid = CheckUsernameInput();
            bool emailValid = CheckEmailInput();
            bool passwordValid = CheckPasswordInput();

            if (!firstnameValid || !lastnameValid || !usernameValid || !emailValid || !passwordValid)
            {
                return;
            }


            // Provided info from user
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string password = Hash.HashPassword(txtPassword.Password.ToString());

            // Check if username is already taken
            if (UserRepository.CheckIfUsernameTaken(username))
            {
                txtUsername.BorderBrush = Brushes.Red;
                txtUsername.BorderThickness = new Thickness(2);
                errorUsername.Content = "To korisnicko ime se vec koristi";
                errorUsername.Visibility = Visibility.Visible;
                return;
            }


            var userCreated = UserRepository.CreateUser(firstName, lastName, username, email, password);

            // Storing current user in app settings
            UserRepository.SaveCurrentUser(username);

            // Go to Input user Data
            var fitnessInputUserControl = new FitnessInputUserControl(parentWindow, username);
            parentWindow.cntControl.Content = fitnessInputUserControl;
        }

        private bool CheckPasswordInput()
        {
            string password = txtPassword.Password.ToString();
            if (!InputValidator.ValidatePassword(password))
            {
                errorPassword.Content = "Lozinka mora imati barem 6 znakova";
                errorPassword.Visibility = Visibility.Visible;
                txtPassword.BorderBrush = Brushes.Red;
                txtPassword.BorderThickness = new Thickness(2);
                return false;
            }

            return true;
        }

        private bool CheckEmailInput()
        {
            string email = txtEmail.Text;
            if (!InputValidator.ValidateEmail(email))
            {
                errorEmail.Content = "Email koji ste unesli nije ispravan!";
                errorEmail.Visibility = Visibility.Visible;
                txtEmail.BorderBrush = Brushes.Red;
                txtEmail.BorderThickness = new Thickness(2);
                return false;
            }

            return true;
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

        private bool CheckLastNameInput()
        {
            string lastName = txtLastName.Text;
            if (!InputValidator.ValidateName(lastName))
            {
                errorLastName.Content = "Prezime mora biti izmedu 2 i 50 znakova, bez specijalnih znakova!";
                errorLastName.Visibility = Visibility.Visible;
                txtLastName.BorderBrush = Brushes.Red;
                txtLastName.BorderThickness = new Thickness(2);
                return false;
            }

            return true;
        }

        private bool CheckFirstNameInput()
        {
            string firstName = txtFirstName.Text;
            if (!InputValidator.ValidateName(firstName))
            {
                errorFirstName.Content = "Ime mora biti izmedu 2 i 50 znakova, bez specijalnih znakova!";
                errorFirstName.Visibility = Visibility.Visible;
                txtFirstName.BorderBrush = Brushes.Red;
                txtFirstName.BorderThickness = new Thickness(2);
                return false;
            }

            return true;
        }

        private void ClearErrorMessages()
        {
            ClearFirstnameError();
            ClearLastnameError();
            ClearUsernameError();
            ClearEmailError();
            ClearPasswordError();
           
            errorDatabase.Visibility = Visibility.Hidden;
            errorDatabase.Content = "";
        }

        private void ClearFirstnameError()
        {
            txtFirstName.BorderBrush = Brushes.Black;
            errorFirstName.Content = "";
            errorFirstName.Visibility = Visibility.Hidden;
        }

        private void ClearLastnameError()
        {
            txtLastName.BorderBrush = Brushes.Black;
            errorLastName.Content = "";
            errorLastName.Visibility = Visibility.Hidden;
        }

        private void ClearUsernameError()
        {
            txtUsername.BorderBrush = Brushes.Black;
            errorUsername.Content = "";
            errorUsername.Visibility = Visibility.Hidden;
        }

        private void ClearEmailError()
        {
            txtEmail.BorderBrush = Brushes.Black;
            errorEmail.Content = "";
            errorEmail.Visibility = Visibility.Hidden;
        }

        private void ClearPasswordError()
        {
            txtPassword.BorderBrush = Brushes.Black;
            errorPassword.Content = "";
            errorPassword.Visibility = Visibility.Hidden;
        }

        private void txtFirstName_LostFocus(object sender, RoutedEventArgs e)
        {
            ClearFirstnameError();
            CheckFirstNameInput();
        }

        private void txtLastName_LostFocus(object sender, RoutedEventArgs e)
        {
            ClearLastnameError();
            CheckLastNameInput();
        }

        private void txtUsername_LostFocus(object sender, RoutedEventArgs e)
        {
            ClearUsernameError();
            CheckUsernameInput();
        }

        private void txtEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            ClearEmailError();
            CheckEmailInput();
        }

        private void txtPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            ClearPasswordError();
            CheckPasswordInput();
        }

        private void btnGoToLogin_Click(object sender, RoutedEventArgs e)
        {
            var loginUserControl = new LoginUserControl(parentWindow);
            parentWindow.contentControl.Content = loginUserControl;
        }

        private void userControlRegister_Loaded(object sender, RoutedEventArgs e)
        {
            txtFirstName.Focus();
        }
    }
}
