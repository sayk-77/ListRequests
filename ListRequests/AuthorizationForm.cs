namespace ListRequests;

public partial class AuthorizationForm : Form
{
    private UserForm _userForm;
    private MasterRequestsForm _masterRequestsForm;
    private readonly DatabaseAction.Database _db = new DatabaseAction.Database();
    public AuthorizationForm()
    {
        InitializeComponent();
    }

    private void LoginBtn_Click(object sender, EventArgs e)
    {
        string login = LoginTextBox.Text;
        string password = PasswordTextBox.Text;

        if (!string.IsNullOrWhiteSpace(login) || !string.IsNullOrWhiteSpace(password))
        {
            (string type, int userId) = _db.Login(login, password);

            if (userId != -1)
            {
                if (type == "Мастер")
                {
                    _masterRequestsForm = new MasterRequestsForm(userId, type);
                    _masterRequestsForm.Show();
                    this.Hide();
                    return;
                }
                _userForm = new UserForm(userId, type);
                _userForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Логин или пароль не верны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        else
        {
            MessageBox.Show("Введите логин и пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}