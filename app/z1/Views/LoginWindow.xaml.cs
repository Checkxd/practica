using System.Windows;
using z1.Services;

namespace z1.Views
{
    public partial class LoginWindow : Window
    {
        private readonly AuthService _authService;

        public User CurrentUser { get; private set; }

        public LoginWindow()
        {
            InitializeComponent();
            _authService = new AuthService();
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text.Trim();
            string password = PasswordBox.Password.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, введите имя пользователя и пароль.");
                return;
            }

            var user = await _authService.AuthenticateAsync(username, password);
            if (user != null)
            {
                CurrentUser = user;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль.");
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = new RegisterWindow();
            if (registerWindow.ShowDialog() == true)
            {
                // После успешной регистрации можно сразу попробовать войти
                UsernameTextBox.Text = "";
                PasswordBox.Password = "";
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}