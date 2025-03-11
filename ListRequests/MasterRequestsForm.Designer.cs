using System.ComponentModel;

namespace ListRequests;

partial class MasterRequestsForm
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
        ProcessRequestBtn = new System.Windows.Forms.Button();
        RequestDoneBtn = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        RequestSearchTextBox = new System.Windows.Forms.TextBox();
        RepairPartTextBox = new System.Windows.Forms.TextBox();
        label3 = new System.Windows.Forms.Label();
        SearchBtn = new System.Windows.Forms.Button();
        ListRequests = new System.Windows.Forms.ListView();
        FilterRequestComboBox = new System.Windows.Forms.ComboBox();
        SuspendLayout();
        // 
        // ProcessRequestBtn
        // 
        ProcessRequestBtn.Location = new System.Drawing.Point(583, 205);
        ProcessRequestBtn.Name = "ProcessRequestBtn";
        ProcessRequestBtn.Size = new System.Drawing.Size(209, 34);
        ProcessRequestBtn.TabIndex = 0;
        ProcessRequestBtn.Text = "Взять в работу";
        ProcessRequestBtn.UseVisualStyleBackColor = true;
        ProcessRequestBtn.Click += ProcessRequestBtn_Click;
        // 
        // RequestDoneBtn
        // 
        RequestDoneBtn.Location = new System.Drawing.Point(580, 403);
        RequestDoneBtn.Name = "RequestDoneBtn";
        RequestDoneBtn.Size = new System.Drawing.Size(209, 40);
        RequestDoneBtn.TabIndex = 1;
        RequestDoneBtn.Text = "Заказ выполнен";
        RequestDoneBtn.UseVisualStyleBackColor = true;
        RequestDoneBtn.Click += RequestDoneBtn_Click;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(583, 126);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(209, 26);
        label1.TabIndex = 5;
        label1.Text = "Фильтрация заказов";
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(582, 15);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(194, 27);
        label2.TabIndex = 6;
        label2.Text = "Поиск заказов";
        // 
        // RequestSearchTextBox
        // 
        RequestSearchTextBox.Location = new System.Drawing.Point(582, 45);
        RequestSearchTextBox.Name = "RequestSearchTextBox";
        RequestSearchTextBox.Size = new System.Drawing.Size(207, 27);
        RequestSearchTextBox.TabIndex = 7;
        // 
        // RepairPartTextBox
        // 
        RepairPartTextBox.Location = new System.Drawing.Point(583, 350);
        RepairPartTextBox.Multiline = true;
        RepairPartTextBox.Name = "RepairPartTextBox";
        RepairPartTextBox.Size = new System.Drawing.Size(206, 47);
        RepairPartTextBox.TabIndex = 8;
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(583, 324);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(187, 23);
        label3.TabIndex = 9;
        label3.Text = "Замененные детали";
        // 
        // SearchBtn
        // 
        SearchBtn.Location = new System.Drawing.Point(583, 78);
        SearchBtn.Name = "SearchBtn";
        SearchBtn.Size = new System.Drawing.Size(205, 27);
        SearchBtn.TabIndex = 10;
        SearchBtn.Text = "Поиск";
        SearchBtn.UseVisualStyleBackColor = true;
        // 
        // ListRequests
        // 
        ListRequests.Location = new System.Drawing.Point(22, 15);
        ListRequests.Name = "ListRequests";
        ListRequests.Size = new System.Drawing.Size(544, 428);
        ListRequests.TabIndex = 2;
        ListRequests.UseCompatibleStateImageBehavior = false;
        ListRequests.View = System.Windows.Forms.View.Details;
        // 
        // FilterRequestComboBox
        // 
        FilterRequestComboBox.FormattingEnabled = true;
        FilterRequestComboBox.Location = new System.Drawing.Point(583, 155);
        FilterRequestComboBox.Name = "FilterRequestComboBox";
        FilterRequestComboBox.Size = new System.Drawing.Size(208, 28);
        FilterRequestComboBox.TabIndex = 11;
        // 
        // MasterRequestsForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(FilterRequestComboBox);
        Controls.Add(SearchBtn);
        Controls.Add(label3);
        Controls.Add(RepairPartTextBox);
        Controls.Add(RequestSearchTextBox);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(ListRequests);
        Controls.Add(RequestDoneBtn);
        Controls.Add(ProcessRequestBtn);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Учет заказов на ремонт техники (Мастер)";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.ComboBox FilterRequestComboBox;

    private System.Windows.Forms.Button SearchBtn;

    private System.Windows.Forms.Label label3;

    private System.Windows.Forms.TextBox RepairPartTextBox;

    private System.Windows.Forms.Button ProcessRequestBtn;
    private System.Windows.Forms.Button RequestDoneBtn;
    private System.Windows.Forms.ListView ListRequests;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox RequestSearchTextBox;

    #endregion
}