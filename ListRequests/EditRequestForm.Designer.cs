using System.ComponentModel;

namespace ListRequests;

partial class EditRequestForm
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
        CalcenEditBtn = new System.Windows.Forms.Button();
        ApplyEditBtn = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
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
        // CalcenEditBtn
        // 
        CalcenEditBtn.Location = new System.Drawing.Point(30, 364);
        CalcenEditBtn.Name = "CalcenEditBtn";
        CalcenEditBtn.Size = new System.Drawing.Size(134, 31);
        CalcenEditBtn.TabIndex = 3;
        CalcenEditBtn.Text = "Отменить";
        CalcenEditBtn.UseVisualStyleBackColor = true;
        CalcenEditBtn.Click += CalcenEditBtn_Click;
        // 
        // ApplyEditBtn
        // 
        ApplyEditBtn.Location = new System.Drawing.Point(239, 364);
        ApplyEditBtn.Name = "ApplyEditBtn";
        ApplyEditBtn.Size = new System.Drawing.Size(134, 31);
        ApplyEditBtn.TabIndex = 4;
        ApplyEditBtn.Text = "Изменить";
        ApplyEditBtn.UseVisualStyleBackColor = true;
        ApplyEditBtn.Click += ApplyEditBtn_Click;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(34, 28);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(113, 20);
        label1.TabIndex = 5;
        label1.Text = "Тип техники";
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(34, 180);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(181, 23);
        label2.TabIndex = 6;
        label2.Text = "Описание проблемы";
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(34, 108);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(127, 20);
        label3.TabIndex = 7;
        label3.Text = "Модель техники";
        // 
        // EditRequestForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(406, 408);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(ApplyEditBtn);
        Controls.Add(CalcenEditBtn);
        Controls.Add(ProblemDescrTextBox);
        Controls.Add(TechModelTextBox);
        Controls.Add(TechTypeTextBox);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Редактирование заявки";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.TextBox TechTypeTextBox;
    private System.Windows.Forms.TextBox TechModelTextBox;
    private System.Windows.Forms.TextBox ProblemDescrTextBox;
    private System.Windows.Forms.Button CalcenEditBtn;
    private System.Windows.Forms.Button ApplyEditBtn;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;

    #endregion
}