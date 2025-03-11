namespace ListRequests;

public partial class RequestDetailForm : Form
{
    private int _requestId;
    private int _masterId;
    private readonly DatabaseAction.Database _db = new DatabaseAction.Database();
    
    public RequestDetailForm(int requestId, int masterId)
    {
        InitializeComponent();
        
        _requestId = requestId;
        _masterId = masterId;

        InitializeTextBoxes();
    }

    private void InitializeTextBoxes()
    {
        (string, string) values = _db.GetCommentAndRepairPart(_requestId);
        
        CommentTextBox.Text = values.Item1;
        RepairPartTextBox.Text = values.Item2;
    }

    private void CancelSaveDetailBtn_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void SaveDetailBtn_Click(object sender, EventArgs e)
    {
        string comment = CommentTextBox.Text;
        string repairPart = RepairPartTextBox.Text;
        
        bool isSuccess = _db.SaveDetailRequest(comment, repairPart, _masterId, _requestId);

        if (isSuccess)
        {
            MessageBox.Show("Запись успешно обновлена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            MessageBox.Show("Ошибка при обновлении данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        this.Close();
    }
}