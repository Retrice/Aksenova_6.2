using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (TryRegisterUser())
            {
                MessageBox.Show("Registration successful!");
                NavigationService.Navigate(new LoginPage());
            }
            else
            {
                MessageBox.Show("Error during registration. Email may already exist.");
            }
        }

        private bool TryRegisterUser()
        {
            return AuthService.TryRegisterUser(
                TxtNickname.Text,
                TxtEmail.Text,
                TxtPassword.Text,
                TxtName.Text,
                TxtSurname.Text,
                TxtDescription.Text,
                TxtInstitution.Text);
        }

        private void BtnToLogin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }
    }
}