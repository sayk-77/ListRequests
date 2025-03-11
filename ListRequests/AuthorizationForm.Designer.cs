namespace ListRequests;

partial class AuthorizationForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
        LoginTextBox = new System.Windows.Forms.TextBox();
        PasswordTextBox = new System.Windows.Forms.TextBox();
        auth_label = new System.Windows.Forms.Label();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        LoginBtn = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // LoginTextBox
        // 
        LoginTextBox.Location = new System.Drawing.Point(283, 107);
        LoginTextBox.Multiline = true;
        LoginTextBox.Name = "LoginTextBox";
        LoginTextBox.Size = new System.Drawing.Size(222, 42);
        LoginTextBox.TabIndex = 0;
        // 
        // PasswordTextBox
        // 
        PasswordTextBox.Location = new System.Drawing.Point(283, 185);
        PasswordTextBox.Multiline = true;
        PasswordTextBox.Name = "PasswordTextBox";
        PasswordTextBox.Size = new System.Drawing.Size(222, 42);
        PasswordTextBox.TabIndex = 1;
        // 
        // auth_label
        // 
        auth_label.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
        auth_label.Location = new System.Drawing.Point(313, 28);
        auth_label.Name = "auth_label";
        auth_label.Size = new System.Drawing.Size(167, 42);
        auth_label.TabIndex = 2;
        auth_label.Text = "Авторизация";
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(283, 80);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(101, 24);
        label1.TabIndex = 3;
        label1.Text = "Логин";
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(283, 158);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(101, 24);
        label2.TabIndex = 4;
        label2.Text = "Пароль";
        // 
        // LoginBtn
        // 
        LoginBtn.Location = new System.Drawing.Point(324, 243);
        LoginBtn.Name = "LoginBtn";
        LoginBtn.Size = new System.Drawing.Size(145, 39);
        LoginBtn.TabIndex = 5;
        LoginBtn.Text = "Войти";
        LoginBtn.UseVisualStyleBackColor = true;
        LoginBtn.Click += LoginBtn_Click;
        // 
        // AuthorizationForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(LoginBtn);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(auth_label);
        Controls.Add(PasswordTextBox);
        Controls.Add(LoginTextBox);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Авторизация";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button LoginBtn;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.TextBox PasswordTextBox;
    private System.Windows.Forms.Label auth_label;

    private System.Windows.Forms.TextBox LoginTextBox;

    #endregion
}