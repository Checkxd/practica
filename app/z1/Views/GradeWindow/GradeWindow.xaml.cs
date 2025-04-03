using System.Windows;
using System.Windows.Controls;

namespace z1.Views
{
    public partial class GradeWindow : Window
    {
        public int GradeValue { get; private set; }
        public string Comment { get; private set; }
        public bool IsConfirmed { get; private set; }

        public GradeWindow(int initialGrade = 0, string initialComment = "")
        {
            InitializeComponent();

            // Установка начальных значений
            GradeComboBox.SelectedIndex = initialGrade > 1 ? initialGrade - 2 : 0;
            CommentTextBox.Text = initialComment;

            // Убираем текст-подсказку при фокусе
            CommentTextBox.GotFocus += (s, e) =>
            {
                if (CommentTextBox.Text == "Введите комментарий")
                    CommentTextBox.Text = "";
            };

            CommentTextBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(CommentTextBox.Text))
                    CommentTextBox.Text = "Введите комментарий";
            };
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (GradeComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                GradeValue = int.Parse(selectedItem.Content.ToString());
                Comment = CommentTextBox.Text == "Введите комментарий" ? "" : CommentTextBox.Text;
                IsConfirmed = true;
                DialogResult = true;
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}