using ListRequests.Types;

namespace ListRequests;

public partial class AddRequestForm : Form
{
    private int _userId;
    private readonly DatabaseAction.Database _db = new DatabaseAction.Database();

    public delegate void OnAddedHandler();
    public event OnAddedHandler OnAdded;
    
    public AddRequestForm(int userId)
    {
        InitializeComponent();
        
        this._userId = userId;
    }

    private void ApplyBtn_Click(object sender, EventArgs e)
    {
        string techType = TechTypeTextBox.Text;
        string techModel = TechModelTextBox.Text;
        string problemDescr = ProblemDescrTextBox.Text;

        if (string.IsNullOrWhiteSpace(techType) || string.IsNullOrWhiteSpace(techModel) || string.IsNullOrWhiteSpace(problemDescr))
        {
            MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        RequestModel newRequest = new RequestModel
        {
            HomeTechType = techType,
            HomeTechModel = techModel,
            ProblemDescription = problemDescr,
            StartDate = DateTime.Now,
            UserId = _userId,
            MasterId = null,
            CompletionDate = null,
            RequestStatus = "Новая заявка"
        };

        bool isAdd = _db.AddRequest(newRequest);

        if (isAdd)
        {
            MessageBox.Show("Заявка успешно создана", "Успех", MessageBoxButtons.OK);
            OnAdded?.Invoke();
        }
        else
        {
            MessageBox.Show("Не удалось добавить заявку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        this.Close();
    }

    private void CancelBtn_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}