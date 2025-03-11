using System.ComponentModel;

namespace ListRequests;

partial class UserForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        label1 = new System.Windows.Forms.Label();
        ListRequests = new System.Windows.Forms.ListView();
        AddRequestBtn = new System.Windows.Forms.Button();
        DeleteRequestBtn = new System.Windows.Forms.Button();
        EditRequestBtn = new System.Windows.Forms.Button();
        SearchTextBox = new System.Windows.Forms.TextBox();
        SearchRequestsBtn = new System.Windows.Forms.Button();
        FilterComboBox = new System.Windows.Forms.ComboBox();
        label2 = new System.Windows.Forms.Label();
        ApplyFilterBtn = new System.Windows.Forms.Button();
        MastersComboBox = new System.Windows.Forms.ComboBox();
        MasterLabel = new System.Windows.Forms.Label();
        ApplyMasterBtn = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        label1.Location = new System.Drawing.Point(29, 8);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(149, 30);
        label1.TabIndex = 0;
        label1.Text = "Список заявок";
        // 
        // ListRequests
        // 
        ListRequests.FullRowSelect = true;
        ListRequests.GridLines = true;
        ListRequests.Location = new System.Drawing.Point(29, 101);
        ListRequests.Name = "ListRequests";
        ListRequests.Size = new System.Drawing.Size(595, 333);
        ListRequests.TabIndex = 1;
        ListRequests.UseCompatibleStateImageBehavior = false;
        ListRequests.View = System.Windows.Forms.View.Details;
        // 
        // AddRequestBtn
        // 
        AddRequestBtn.Location = new System.Drawing.Point(530, 51);
        AddRequestBtn.Name = "AddRequestBtn";
        AddRequestBtn.Size = new System.Drawing.Size(94, 35);
        AddRequestBtn.TabIndex = 2;
        AddRequestBtn.Text = "Добавить";
        AddRequestBtn.UseVisualStyleBackColor = true;
        AddRequestBtn.Click += AddRequestBtn_Click;
        // 
        // DeleteRequestBtn
        // 
        DeleteRequestBtn.Location = new System.Drawing.Point(627, 142);
        DeleteRequestBtn.Name = "DeleteRequestBtn";
        DeleteRequestBtn.Size = new System.Drawing.Size(142, 35);
        DeleteRequestBtn.TabIndex = 3;
        DeleteRequestBtn.Text = "Удалить";
        DeleteRequestBtn.UseVisualStyleBackColor = true;
        DeleteRequestBtn.Click += DeleteRequestBtn_Click;
        // 
        // EditRequestBtn
        // 
        EditRequestBtn.Location = new System.Drawing.Point(627, 101);
        EditRequestBtn.Name = "EditRequestBtn";
        EditRequestBtn.Size = new System.Drawing.Size(142, 35);
        EditRequestBtn.TabIndex = 4;
        EditRequestBtn.Text = "Редактировать";
        EditRequestBtn.UseVisualStyleBackColor = true;
        EditRequestBtn.Click += EditRequestBtn_Click;
        // 
        // SearchTextBox
        // 
        SearchTextBox.Location = new System.Drawing.Point(29, 51);
        SearchTextBox.Multiline = true;
        SearchTextBox.Name = "SearchTextBox";
        SearchTextBox.Size = new System.Drawing.Size(393, 35);
        SearchTextBox.TabIndex = 5;
        // 
        // SearchRequestsBtn
        // 
        SearchRequestsBtn.Location = new System.Drawing.Point(440, 51);
        SearchRequestsBtn.Name = "SearchRequestsBtn";
        SearchRequestsBtn.Size = new System.Drawing.Size(72, 35);
        SearchRequestsBtn.TabIndex = 6;
        SearchRequestsBtn.Text = "Поиск";
        SearchRequestsBtn.UseVisualStyleBackColor = true;
        SearchRequestsBtn.Click += SearchRequestsBtn_Click;
        // 
        // FilterComboBox
        // 
        FilterComboBox.FormattingEnabled = true;
        FilterComboBox.Location = new System.Drawing.Point(631, 218);
        FilterComboBox.Name = "FilterComboBox";
        FilterComboBox.Size = new System.Drawing.Size(138, 28);
        FilterComboBox.TabIndex = 7;
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(631, 193);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(93, 22);
        label2.TabIndex = 8;
        label2.Text = "Фильтр";
        // 
        // ApplyFilterBtn
        // 
        ApplyFilterBtn.Location = new System.Drawing.Point(630, 252);
        ApplyFilterBtn.Name = "ApplyFilterBtn";
        ApplyFilterBtn.Size = new System.Drawing.Size(141, 29);
        ApplyFilterBtn.TabIndex = 9;
        ApplyFilterBtn.Text = "Применить";
        ApplyFilterBtn.UseVisualStyleBackColor = true;
        ApplyFilterBtn.Click += ApplyFilterBtn_Click;
        // 
        // MastersComboBox
        // 
        MastersComboBox.FormattingEnabled = true;
        MastersComboBox.Location = new System.Drawing.Point(629, 322);
        MastersComboBox.Name = "MastersComboBox";
        MastersComboBox.Size = new System.Drawing.Size(140, 28);
        MastersComboBox.TabIndex = 10;
        // 
        // MasterLabel
        // 
        MasterLabel.Location = new System.Drawing.Point(630, 295);
        MasterLabel.Name = "MasterLabel";
        MasterLabel.Size = new System.Drawing.Size(92, 24);
        MasterLabel.TabIndex = 11;
        MasterLabel.Text = "Мастер";
        // 
        // ApplyMasterBtn
        // 
        ApplyMasterBtn.Location = new System.Drawing.Point(628, 356);
        ApplyMasterBtn.Name = "ApplyMasterBtn";
        ApplyMasterBtn.Size = new System.Drawing.Size(143, 30);
        ApplyMasterBtn.TabIndex = 12;
        ApplyMasterBtn.Text = "Назначить";
        ApplyMasterBtn.UseVisualStyleBackColor = true;
        ApplyMasterBtn.Click += ApplyMasterBtn_Click;
        // 
        // UserForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(ApplyMasterBtn);
        Controls.Add(MasterLabel);
        Controls.Add(MastersComboBox);
        Controls.Add(ApplyFilterBtn);
        Controls.Add(label2);
        Controls.Add(FilterComboBox);
        Controls.Add(SearchRequestsBtn);
        Controls.Add(SearchTextBox);
        Controls.Add(EditRequestBtn);
        Controls.Add(DeleteRequestBtn);
        Controls.Add(AddRequestBtn);
        Controls.Add(ListRequests);
        Controls.Add(label1);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Система учета заявок на ремонт бытовой техники";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button ApplyMasterBtn;

    private System.Windows.Forms.Button ApplyFilterBtn;
    private System.Windows.Forms.ComboBox MastersComboBox;
    private System.Windows.Forms.Label MasterLabel;

    private System.Windows.Forms.ComboBox FilterComboBox;
    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Button SearchRequestsBtn;

    private System.Windows.Forms.TextBox SearchTextBox;

    private System.Windows.Forms.ListView ListRequests;
    private System.Windows.Forms.Button AddRequestBtn;
    private System.Windows.Forms.Button DeleteRequestBtn;
    private System.Windows.Forms.Button EditRequestBtn;

    private System.Windows.Forms.Label label1;

    #endregion
}