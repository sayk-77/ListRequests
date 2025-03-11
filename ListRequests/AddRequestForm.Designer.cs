using System.ComponentModel;

namespace ListRequests;

partial class AddRequestForm
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
        TechTypeTextBox = new System.Windows.Forms.TextBox();
        TechModelTextBox = new System.Windows.Forms.TextBox();
        ProblemDescrTextBox = new System.Windows.Forms.TextBox();
        VeiewTechLabel = new System.Windows.Forms.Label();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        ApplyBtn = new System.Windows.Forms.Button();
        CancelBtn = new System.Windows.Forms.Button();
        label3 = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        label5 = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // TechTypeTextBox
        // 
        TechTypeTextBox.Location = new System.Drawing.Point(30, 52);
        TechTypeTextBox.Name = "TechTypeTextBox";
        TechTypeTextBox.Size = new System.Drawing.Size(343, 27);
        TechTypeTextBox.TabIndex = 0;
        // 
        // TechModelTextBox
        // 
        TechModelTextBox.Location = new System.Drawing.Point(30, 131);
        TechModelTextBox.Name = "TechModelTextBox";
        TechModelTextBox.Size = new System.Drawing.Size(343, 27);
        TechModelTextBox.TabIndex = 1;
        // 
        // ProblemDescrTextBox
        // 
        ProblemDescrTextBox.Location = new System.Drawing.Point(30, 206);
        ProblemDescrTextBox.Multiline = true;
        ProblemDescrTextBox.Name = "ProblemDescrTextBox";
        ProblemDescrTextBox.Size = new System.Drawing.Size(343, 136);
        ProblemDescrTextBox.TabIndex = 2;
        // 
        // VeiewTechLabel
        // 
        VeiewTechLabel.Location = new System.Drawing.Point(30, 26);
        VeiewTechLabel.Name = "VeiewTechLabel";
        VeiewTechLabel.Size = new System.Drawing.Size(100, 23);
        VeiewTechLabel.TabIndex = 3;
        VeiewTechLabel.Visible = false;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(30, 105);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(131, 23);
        label1.TabIndex = 4;
        label1.Visible = false;
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(34, 180);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(179, 23);
        label2.TabIndex = 5;
        label2.Visible = false;
        // 
        // ApplyBtn
        // 
        ApplyBtn.Location = new System.Drawing.Point(239, 364);
        ApplyBtn.Name = "ApplyBtn";
        ApplyBtn.Size = new System.Drawing.Size(134, 31);
        ApplyBtn.TabIndex = 6;
        ApplyBtn.Text = "Добавить";
        ApplyBtn.UseVisualStyleBackColor = true;
        ApplyBtn.Click += ApplyBtn_Click;
        // 
        // CancelBtn
        // 
        CancelBtn.Location = new System.Drawing.Point(30, 364);
        CancelBtn.Name = "CancelBtn";
        CancelBtn.Size = new System.Drawing.Size(134, 31);
        CancelBtn.TabIndex = 7;
        CancelBtn.Text = "Отменить";
        CancelBtn.UseVisualStyleBackColor = true;
        CancelBtn.Click += CancelBtn_Click;
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(34, 28);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(113, 20);
        label3.TabIndex = 8;
        label3.Text = "Тип техники";
        // 
        // label4
        // 
        label4.Location = new System.Drawing.Point(34, 108);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(127, 20);
        label4.TabIndex = 9;
        label4.Text = "Модель техники";
        // 
        // label5
        // 
        label5.Location = new System.Drawing.Point(34, 180);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(181, 23);
        label5.TabIndex = 10;
        label5.Text = "Описание проблемы";
        // 
        // AddRequestForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.Control;
        ClientSize = new System.Drawing.Size(406, 408);
        Controls.Add(label5);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(CancelBtn);
        Controls.Add(ApplyBtn);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(VeiewTechLabel);
        Controls.Add(ProblemDescrTextBox);
        Controls.Add(TechModelTextBox);
        Controls.Add(TechTypeTextBox);
        Location = new System.Drawing.Point(19, 19);
        Text = "Создание заявки";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;

    private System.Windows.Forms.Label VeiewTechLabel;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button ApplyBtn;
    private System.Windows.Forms.Button CancelBtn;

    private System.Windows.Forms.TextBox TechModelTextBox;
    private System.Windows.Forms.TextBox ProblemDescrTextBox;

    private System.Windows.Forms.TextBox TechTypeTextBox;

    #endregion
}