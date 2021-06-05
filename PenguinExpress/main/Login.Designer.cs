
namespace PenguinExpress.main
{
  partial class Login
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

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
      this.tab_login = new System.Windows.Forms.TabControl();
      this.tab_page1 = new System.Windows.Forms.TabPage();
      this.btn_join = new System.Windows.Forms.Button();
      this.btn_login = new System.Windows.Forms.Button();
      this.tb_pwd = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.tb_id = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.tab_page2 = new System.Windows.Forms.TabPage();
      this.btn_e_login = new System.Windows.Forms.Button();
      this.tb_e_pwd = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.tb_e_id = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.tab_login.SuspendLayout();
      this.tab_page1.SuspendLayout();
      this.tab_page2.SuspendLayout();
      this.SuspendLayout();
      // 
      // tab_login
      // 
      this.tab_login.Controls.Add(this.tab_page1);
      this.tab_login.Controls.Add(this.tab_page2);
      this.tab_login.Location = new System.Drawing.Point(12, 12);
      this.tab_login.Name = "tab_login";
      this.tab_login.SelectedIndex = 0;
      this.tab_login.Size = new System.Drawing.Size(343, 292);
      this.tab_login.TabIndex = 0;
      // 
      // tab_page1
      // 
      this.tab_page1.BackColor = System.Drawing.Color.Transparent;
      this.tab_page1.Controls.Add(this.btn_join);
      this.tab_page1.Controls.Add(this.btn_login);
      this.tab_page1.Controls.Add(this.tb_pwd);
      this.tab_page1.Controls.Add(this.label2);
      this.tab_page1.Controls.Add(this.tb_id);
      this.tab_page1.Controls.Add(this.label1);
      this.tab_page1.Location = new System.Drawing.Point(4, 25);
      this.tab_page1.Name = "tab_page1";
      this.tab_page1.Padding = new System.Windows.Forms.Padding(3);
      this.tab_page1.Size = new System.Drawing.Size(335, 263);
      this.tab_page1.TabIndex = 0;
      this.tab_page1.Text = "일반 로그인";
      // 
      // btn_join
      // 
      this.btn_join.Location = new System.Drawing.Point(166, 175);
      this.btn_join.Name = "btn_join";
      this.btn_join.Size = new System.Drawing.Size(135, 44);
      this.btn_join.TabIndex = 5;
      this.btn_join.Text = "회원가입";
      this.btn_join.UseVisualStyleBackColor = true;
      this.btn_join.Click += new System.EventHandler(this.btn_join_Click);
      // 
      // btn_login
      // 
      this.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btn_login.Location = new System.Drawing.Point(36, 175);
      this.btn_login.Name = "btn_login";
      this.btn_login.Size = new System.Drawing.Size(124, 44);
      this.btn_login.TabIndex = 4;
      this.btn_login.Text = "로그인";
      this.btn_login.UseVisualStyleBackColor = true;
      this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
      // 
      // tb_pwd
      // 
      this.tb_pwd.Location = new System.Drawing.Point(127, 74);
      this.tb_pwd.MaxLength = 20;
      this.tb_pwd.Name = "tb_pwd";
      this.tb_pwd.PasswordChar = '*';
      this.tb_pwd.Size = new System.Drawing.Size(174, 25);
      this.tb_pwd.TabIndex = 3;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(33, 77);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(67, 15);
      this.label2.TabIndex = 2;
      this.label2.Text = "비밀번호";
      // 
      // tb_id
      // 
      this.tb_id.Location = new System.Drawing.Point(127, 43);
      this.tb_id.MaxLength = 12;
      this.tb_id.Name = "tb_id";
      this.tb_id.Size = new System.Drawing.Size(174, 25);
      this.tb_id.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(33, 46);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(52, 15);
      this.label1.TabIndex = 0;
      this.label1.Text = "아이디";
      // 
      // tab_page2
      // 
      this.tab_page2.Controls.Add(this.btn_e_login);
      this.tab_page2.Controls.Add(this.tb_e_pwd);
      this.tab_page2.Controls.Add(this.label3);
      this.tab_page2.Controls.Add(this.tb_e_id);
      this.tab_page2.Controls.Add(this.label4);
      this.tab_page2.Location = new System.Drawing.Point(4, 25);
      this.tab_page2.Name = "tab_page2";
      this.tab_page2.Padding = new System.Windows.Forms.Padding(3);
      this.tab_page2.Size = new System.Drawing.Size(335, 263);
      this.tab_page2.TabIndex = 1;
      this.tab_page2.Text = "직원 로그인";
      this.tab_page2.UseVisualStyleBackColor = true;
      // 
      // btn_e_login
      // 
      this.btn_e_login.Location = new System.Drawing.Point(36, 175);
      this.btn_e_login.Name = "btn_e_login";
      this.btn_e_login.Size = new System.Drawing.Size(265, 44);
      this.btn_e_login.TabIndex = 10;
      this.btn_e_login.Text = "로그인";
      this.btn_e_login.UseVisualStyleBackColor = true;
      this.btn_e_login.Click += new System.EventHandler(this.btn_e_login_Click);
      // 
      // tb_e_pwd
      // 
      this.tb_e_pwd.Location = new System.Drawing.Point(127, 74);
      this.tb_e_pwd.MaxLength = 20;
      this.tb_e_pwd.Name = "tb_e_pwd";
      this.tb_e_pwd.PasswordChar = '*';
      this.tb_e_pwd.Size = new System.Drawing.Size(174, 25);
      this.tb_e_pwd.TabIndex = 9;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(33, 77);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(67, 15);
      this.label3.TabIndex = 8;
      this.label3.Text = "비밀번호";
      // 
      // tb_e_id
      // 
      this.tb_e_id.Location = new System.Drawing.Point(127, 43);
      this.tb_e_id.MaxLength = 12;
      this.tb_e_id.Name = "tb_e_id";
      this.tb_e_id.Size = new System.Drawing.Size(174, 25);
      this.tb_e_id.TabIndex = 7;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(33, 46);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(52, 15);
      this.label4.TabIndex = 6;
      this.label4.Text = "아이디";
      // 
      // Login
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(369, 314);
      this.Controls.Add(this.tab_login);
      this.Name = "Login";
      this.Text = "Login";
      this.Load += new System.EventHandler(this.Login_Load);
      this.tab_login.ResumeLayout(false);
      this.tab_page1.ResumeLayout(false);
      this.tab_page1.PerformLayout();
      this.tab_page2.ResumeLayout(false);
      this.tab_page2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tab_login;
    private System.Windows.Forms.TabPage tab_page1;
    private System.Windows.Forms.Button btn_join;
    private System.Windows.Forms.Button btn_login;
    private System.Windows.Forms.TextBox tb_pwd;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox tb_id;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TabPage tab_page2;
    private System.Windows.Forms.Button btn_e_login;
    private System.Windows.Forms.TextBox tb_e_pwd;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox tb_e_id;
    private System.Windows.Forms.Label label4;
  }
}