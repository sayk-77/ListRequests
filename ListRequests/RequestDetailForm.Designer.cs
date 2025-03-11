using System.ComponentModel;

namespace ListRequests;

partial class RequestDetailForm
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
        CommentTextBox = new System.Windows.Forms.TextBox();
        RepairPartTextBox = new System.Windows.Forms.TextBox();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        CancelSaveDetailBtn = new System.Windows.Forms.Button();
        SaveDetailBtn = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // CommentTextBox
        // 
        CommentTextBox.Location = new System.Drawing.Point(7, 39);
        CommentTextBox.Multiline = true;
        CommentTextBox.Name = "CommentTextBox";
        CommentTextBox.Size = new System.Drawing.Size(363, 86);
        CommentTextBox.TabIndex = 0;
        // 
        // RepairPartTextBox
        // 
        RepairPartTextBox.Location = new System.Drawing.Point(7, 172);
        RepairPartTextBox.Multiline = true;
        RepairPartTextBox.Name = "RepairPartTextBox";
        RepairPartTextBox.Size = new System.Drawing.Size(363, 85);
        RepairPartTextBox.TabIndex = 1;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(7, 9);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(140, 30);
        label1.TabIndex = 2;
        label1.Text = "Комментарий";
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(7, 139);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(178, 30);
        label2.TabIndex = 3;
        label2.Text = "Замененные детали";
        // 
        // CancelSaveDetailBtn
        // 
        CancelSaveDetailBtn.Location = new System.Drawing.Point(12, 263);
        CancelSaveDetailBtn.Name = "CancelSaveDetailBtn";
        CancelSaveDetailBtn.Size = new System.Drawing.Size(135, 35);
        CancelSaveDetailBtn.TabIndex = 4;
        CancelSaveDetailBtn.Text = "Отменить";
        CancelSaveDetailBtn.UseVisualStyleBackColor = true;
        CancelSaveDetailBtn.Click += CancelSaveDetailBtn_Click;
        // 
        // SaveDetailBtn
        // 
        SaveDetailBtn.Location = new System.Drawing.Point(235, 263);
        SaveDetailBtn.Name = "SaveDetailBtn";
        SaveDetailBtn.Size = new System.Drawing.Size(135, 35);
        SaveDetailBtn.TabIndex = 5;
        SaveDetailBtn.Text = "Сохранить";
        SaveDetailBtn.UseVisualStyleBackColor = true;
        SaveDetailBtn.Click += SaveDetailBtn_Click;
        // 
        // RequestDetailForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(379, 316);
        Controls.Add(SaveDetailBtn);
        Controls.Add(CancelSaveDetailBtn);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(RepairPartTextBox);
        Controls.Add(CommentTextBox);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Детали заявки";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button CancelSaveDetailBtn;
    private System.Windows.Forms.Button SaveDetailBtn;

    private System.Windows.Forms.TextBox RepairPartTextBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.TextBox CommentTextBox;

    #endregion
}