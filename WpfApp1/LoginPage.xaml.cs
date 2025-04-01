using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (TryLoginUser())
            {
                MessageBox.Show("Login successful!");
            }
            else
            {
                MessageBox.Show("Invalid email or password.");
            }
        }

        private bool TryLoginUser()
        {
            return AuthService.TryLoginUser(TxtEmail.Text, TxtPassword.Text);
        }

        private void BtnToRegister_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterPage());
        }
    }
}