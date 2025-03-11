using ListRequests.Types;

namespace ListRequests;

public partial class MasterRequestsForm : Form
{
    private int _userId;
    private string _type;
    private readonly DatabaseAction.Database _db = new DatabaseAction.Database();
    private List<RequestModel> _allRequests;

    private readonly string[] _filters = { "Все заказы", "Новая заявка", "В процессе ремонта", "Готова к выдаче" };

    public MasterRequestsForm(int userId, string type)
    {
        InitializeComponent();
        this._userId = userId;
        this._type = type;

        InitializeColumnListRequests();
        InitializeFilterRequests();
        InitializeRequests();

        ListRequests.MouseDoubleClick += ListRequestOpenComment;
        FilterRequestComboBox.SelectedIndexChanged += FilterRequests;
    }

    public void InitializeFilterRequests()
    {
        FilterRequestComboBox.Items.Clear();

        foreach (var filter in _filters)
        {
            FilterRequestComboBox.Items.Add(filter);
        }

        FilterRequestComboBox.SelectedIndex = 0;
    }

    public void InitializeRequests()
    {
        ListRequests.Items.Clear();
        
        _allRequests = _db.GetRequests(_type, _userId);

        UpdateRequestsList();
    }

    public void InitializeColumnListRequests()
    {
        ListRequests.Columns.Add("Номер заявки", 130);
        ListRequests.Columns.Add("Дата добавления", 150);
        ListRequests.Columns.Add("Вид бытовой техники", 200);
        ListRequests.Columns.Add("Модель бытовой техники", 220);
        ListRequests.Columns.Add("Описание проблемы", 150);
        ListRequests.Columns.Add("Статус заявки", 150);
    }

    public void ListRequestOpenComment(object sender, MouseEventArgs e)
    {
        if (ListRequests.SelectedItems.Count > 0)
        {
            ListViewItem selectedItem = ListRequests.SelectedItems[0];

            if (int.TryParse(selectedItem.SubItems[0].Text, out int requestId))
            {
                RequestDetailForm rdForm = new RequestDetailForm(requestId, _userId);
                rdForm.Show();
            }
            else
            {
                MessageBox.Show("Неверный формат ID заявки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        else
        {
            MessageBox.Show("Выберите заявку из списка.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void FilterRequests(object sender, EventArgs e)
    {
        int filterIndex = FilterRequestComboBox.SelectedIndex;

        if (_filters[filterIndex] == "Все заказы")
        {
            UpdateRequestsList();
            return;
        }

        ListRequests.Items.Clear();

        foreach (var request in _allRequests)
        {
            if (request.RequestStatus == _filters[filterIndex])
            {
                ListViewItem item = new ListViewItem
                ([
                    request.RequestId.ToString(),
                    request.StartDate?.ToString("yyyy-MM-dd") ?? string.Empty,
                    request.HomeTechType ?? string.Empty,
                    request.HomeTechModel ?? string.Empty,
                    request.ProblemDescription ?? string.Empty,
                    request.RequestStatus ?? string.Empty
                ]);

                ListRequests.Items.Add(item);
            }
        }
    }

    private void UpdateRequestsList()
    {
        ListRequests.Items.Clear();

        foreach (var request in _allRequests)
        {
            ListViewItem item = new ListViewItem
            ([
                request.RequestId.ToString(),
                request.StartDate?.ToString("yyyy-MM-dd") ?? string.Empty,
                request.HomeTechType ?? string.Empty,
                request.HomeTechModel ?? string.Empty,
                request.ProblemDescription ?? string.Empty,
                request.RequestStatus ?? string.Empty
            ]);

            ListRequests.Items.Add(item);
        }
    }

    private void RequestDoneBtn_Click(object sender, EventArgs e)
    {
        if (ListRequests.SelectedItems.Count > 0)
        {
            ListViewItem selectedItem = ListRequests.SelectedItems[0];
            
            if (int.TryParse(selectedItem.SubItems[0].Text, out int requestId))
            {
                if (selectedItem.SubItems[5].Text != "В процессе ремонта")
                {
                    MessageBox.Show("Заказ еще не в работе или уже выполнен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string repairPart = RepairPartTextBox.Text;

                bool isSuccessUpdateStatus = _db.UpdateCompleteStatusRequest(requestId, "Готова к выдаче", repairPart);

                if (isSuccessUpdateStatus)
                {
                    MessageBox.Show("Статус заказа изменен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RepairPartTextBox.Text = string.Empty;
                    InitializeRequests();
                }
                else
                {
                    MessageBox.Show("Не удалось изменить статус заказа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать заказ", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    private void ProcessRequestBtn_Click(object sender, EventArgs e)
    {
        if (ListRequests.SelectedItems.Count > 0)
        {
            ListViewItem selectedItem = ListRequests.SelectedItems[0];
            
            if (int.TryParse(selectedItem.SubItems[0].Text, out int requestId))
            {
                if (selectedItem.SubItems[5].Text != "Новая заявка")
                {
                    MessageBox.Show("Заказ уже в работе или выполнен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                bool isSuccessUpdateStatus = _db.UpdateProcessStatusRequest(requestId, "В процессе ремонта");

                if (isSuccessUpdateStatus)
                {
                    MessageBox.Show("Статус заказа изменен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RepairPartTextBox.Text = string.Empty;
                    InitializeRequests();
                }
                else
                {
                    MessageBox.Show("Не удалось изменить статус заказа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать заказ", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}