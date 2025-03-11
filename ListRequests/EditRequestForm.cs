using ListRequests.Types;

namespace ListRequests;

public partial class EditRequestForm : Form
{
    private RequestModel _request;
    private readonly DatabaseAction.Database _db = new DatabaseAction.Database();

    public delegate void OnEditHandler();
    public event OnEditHandler OnEdit;
    
    public EditRequestForm(RequestModel request)
    {
        InitializeComponent();
        this._request = request;

        TechModelTextBox.Text = _request.HomeTechModel;
        TechTypeTextBox.Text = _request.HomeTechType;
        ProblemDescrTextBox.Text = _request.ProblemDescription;
    }

    private void ApplyEditBtn_Click(object sender, EventArgs e)
    {
        string techType = TechTypeTextBox.Text;
        string techModel = TechModelTextBox.Text;
        string problemDescr = ProblemDescrTextBox.Text;
        
        if (string.IsNullOrWhiteSpace(techType) || string.IsNullOrWhiteSpace(techModel) || string.IsNullOrWhiteSpace(problemDescr))
        {
            MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        
        _request.HomeTechModel = techModel;
        _request.HomeTechType = techType;
        _request.ProblemDescription = problemDescr;

        bool isEdit = _db.EditRequest(_request);

        if (isEdit)
        {
            MessageBox.Show("Заявка успешно изменена", "Успех", MessageBoxButtons.OK);
            OnEdit?.Invoke();
        }
        else
        {
            MessageBox.Show("Не удалось изменить заявку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        this.Close();
    }

    private void CalcenEditBtn_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}