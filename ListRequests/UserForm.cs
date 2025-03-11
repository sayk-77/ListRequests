using System.Security.Policy;
using ListRequests.DatabaseAction;
using ListRequests.Types;

namespace ListRequests;

public partial class UserForm : Form
{
    private string[] _filters = ["Все", "Новая заявка", "В процессе ремнота", "Готова к выдаче"];

    private List<MasterModel> _masters;
    
    private AddRequestForm _addRequestForm;
    private EditRequestForm _editRequestForm;
    private readonly DatabaseAction.Database _db = new DatabaseAction.Database();
    
    private List<RequestModel> _requests;
    
    private int _userId;
    private string _type;
    public UserForm(int userId, string type)
    {
        InitializeComponent();
        
        this._userId = userId;
        this._type = type;

        SettingUi();
        
        InitializeColumnsListView();
        InitializeRowsListView(_type, _userId);
    }

    private void AddRequestBtn_Click(object sender, EventArgs e)
    {
        _addRequestForm = new AddRequestForm(_userId);
        _addRequestForm.OnAdded += UpdateRequestsList;
        _addRequestForm.Show();
    }

    private void UpdateRequestsList()
    {
        ListRequests.Items.Clear();
        InitializeRowsListView(_type, _userId);
    }


    private void InitializeColumnsListView()
    {
        ListRequests.Columns.Add("Номер заявки", 130);
        ListRequests.Columns.Add("Дата добавления", 150);
        ListRequests.Columns.Add("Вид бытовой техники", 200);
        ListRequests.Columns.Add("Модель бытовой техники", 220);
        ListRequests.Columns.Add("Описание проблемы", 150);
        ListRequests.Columns.Add("Статус заявки", 150);
    }

    private void InitializeRowsListView(string type, int userId)
    {
        List<RequestModel> requests = _db.GetRequests(type, userId);
        _requests = requests;
        
        foreach (var request in requests)
        {
            ListViewItem item = new ListViewItem
            ([
                request.RequestId.ToString(),
                request.StartDate.ToString(),
                request.HomeTechType,
                request.HomeTechModel,
                request.ProblemDescription,
                request.RequestStatus
            ]);

            ListRequests.Items.Add(item);
        }
    }

    private void DeleteRequestBtn_Click(object sender, EventArgs e)
    {
        var activeRequest = int.Parse(ListRequests.SelectedItems[0].Text);

        if (activeRequest == 0)
        {
            MessageBox.Show("Выберите заявку для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        bool isDelete = _db.DeleteRequest(activeRequest);

        if (isDelete)
        {
            MessageBox.Show("Заявка успешно удалена", "Успех", MessageBoxButtons.OK);

            foreach (ListViewItem item in ListRequests.Items)
            {
                if (item.SubItems[0].Text == activeRequest.ToString())
                {
                    item.Remove();
                    break;
                }
            }
        }
        else
        {
            MessageBox.Show("Не удалось удалить заявку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void EditRequestBtn_Click(object sender, EventArgs e)
    {
        if (ListRequests.SelectedItems.Count == 0)
        {
            MessageBox.Show("Выберите заявку для редактирования", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        ListViewItem selectedItem = ListRequests.SelectedItems[0];
        
        RequestModel activeRequest = new RequestModel
        {
            RequestId = int.Parse(selectedItem.SubItems[0].Text),
            HomeTechType = selectedItem.SubItems[2].Text,
            HomeTechModel = selectedItem.SubItems[3].Text,
            ProblemDescription = selectedItem.SubItems[4].Text
        };

        _editRequestForm = new EditRequestForm(activeRequest);
        _editRequestForm.OnEdit += UpdateRequestsList;
        _editRequestForm.Show();
    }

    private void SearchRequestsBtn_Click(object sender, EventArgs e)
    {
        string query = SearchTextBox.Text.Trim();

        if (string.IsNullOrEmpty(query))
        {
            UpdateRequestsList();
            return;
        }
        
        ListRequests.Items.Clear();
        
        foreach (var request in _requests)
        {
            if (request.RequestId.ToString().Contains(query, StringComparison.OrdinalIgnoreCase))
            {
                AddRequestToListView(request);
                continue;
            }

            if ((request.StartDate?.ToString("yyyy-MM-dd") ?? "").Contains(query, StringComparison.OrdinalIgnoreCase) ||
                (request.HomeTechType ?? "").Contains(query, StringComparison.OrdinalIgnoreCase) ||
                (request.HomeTechModel ?? "").Contains(query, StringComparison.OrdinalIgnoreCase) ||
                (request.ProblemDescription ?? "").Contains(query, StringComparison.OrdinalIgnoreCase))
            {
                AddRequestToListView(request);
            }
        }

        if (ListRequests.Items.Count == 0)
        {
            MessageBox.Show("По вашему запросу ничего не найдено", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    
    private void AddRequestToListView(RequestModel request)
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

    public void SettingUi()
    {
        if (this._type == "Оператор")
        {
            AddRequestBtn.Visible = false;
            MastersComboBox.Items.Clear();
            
            _masters = _db.GetMasters();
            
            foreach (var master in _masters)
            {
                MastersComboBox.Items.Add(master.MasterName);
            }
        }
        else
        {
            MasterLabel.Visible = false;
            MastersComboBox.Visible = false;
            ApplyMasterBtn.Visible = false;
        }
        
        FilterComboBox.Items.Add("Все");
        FilterComboBox.Items.Add("Новая заявка");
        FilterComboBox.Items.Add("В процессе ремонта");
        FilterComboBox.Items.Add("Готова к выдаче");
        FilterComboBox.SelectedIndex = 0;
    }

    private void ApplyFilterBtn_Click(object sender, EventArgs e)
    {
        int filterIndex = FilterComboBox.SelectedIndex;
        
        if (_filters[filterIndex] == "Все")
        {
            UpdateRequestsList();
            return;
        }
        
        ListRequests.Items.Clear();

        foreach (var request in _requests)
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

    private void ApplyMasterBtn_Click(object sender, EventArgs e)
    {
        var masterIndex = MastersComboBox.SelectedIndex;
        if (masterIndex == -1)
        {
            MessageBox.Show("Выберите мастера", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (ListRequests.SelectedItems.Count == 0)
        {
            MessageBox.Show("Выберите заказ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        int requestId = int.Parse(ListRequests.SelectedItems[0].SubItems[0].Text);
        int masterId = _masters.FirstOrDefault(m => m.Id == masterIndex).MasterId;
        
        bool isSetMaster = _db.SelectMaster(requestId, masterId);

        if (isSetMaster)
        {
            MessageBox.Show("Мастер успешно назначен", "Успех", MessageBoxButtons.OK);
            UpdateRequestsList();
        }
        else
        {
            MessageBox.Show($"Для заказа номер {requestId} уже назначен мастер", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}