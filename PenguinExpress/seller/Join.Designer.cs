
namespace PenguinExpress.seller
{
  partial class Join
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.label1 = new System.Windows.Forms.Label();
      this.tb_id = new System.Windows.Forms.TextBox();
      this.button1 = new System.Windows.Forms.Button();
      this.tb_pw = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.tb_pw_verify = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.tb_name = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.tb_phone1 = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.cb_addr_captital = new System.Windows.Forms.ComboBox();
      this.tb_addr = new System.Windows.Forms.TextBox();
      this.tb_phone2 = new System.Windows.Forms.TextBox();
      this.tb_phone3 = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.btn_onJoin = new System.Windows.Forms.Button();
      this.btn_cancel = new System.Windows.Forms.Button();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.label9);
      this.panel1.Controls.Add(this.label8);
      this.panel1.Controls.Add(this.tb_phone3);
      this.panel1.Controls.Add(this.tb_phone2);
      this.panel1.Controls.Add(this.tb_addr);
      this.panel1.Controls.Add(this.cb_addr_captital);
      this.panel1.Controls.Add(this.label6);
      this.panel1.Controls.Add(this.tb_phone1);
      this.panel1.Controls.Add(this.label5);
      this.panel1.Controls.Add(this.tb_name);
      this.panel1.Controls.Add(this.label4);
      this.panel1.Controls.Add(this.tb_pw_verify);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this.tb_pw);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.button1);
      this.panel1.Controls.Add(this.tb_id);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Location = new System.Drawing.Point(12, 12);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(349, 230);
      this.panel1.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(3, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(20, 15);
      this.label1.TabIndex = 0;
      this.label1.Text = "ID";
      // 
      // tb_id
      // 
      this.tb_id.Location = new System.Drawing.Point(111, 12);
      this.tb_id.Name = "tb_id";
      this.tb_id.Size = new System.Drawing.Size(130, 25);
      this.tb_id.TabIndex = 1;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(247, 12);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(99, 26);
      this.button1.TabIndex = 2;
      this.button1.Text = "중복확인";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // tb_pw
      // 
      this.tb_pw.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.tb_pw.Location = new System.Drawing.Point(111, 43);
      this.tb_pw.MaxLength = 20;
      this.tb_pw.Name = "tb_pw";
      this.tb_pw.PasswordChar = '*';
      this.tb_pw.Size = new System.Drawing.Size(130, 25);
      this.tb_pw.TabIndex = 4;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(3, 46);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(67, 15);
      this.label2.TabIndex = 3;
      this.label2.Text = "비밀번호";
      // 
      // tb_pw_verify
      // 
      this.tb_pw_verify.Location = new System.Drawing.Point(111, 74);
      this.tb_pw_verify.MaxLength = 20;
      this.tb_pw_verify.Name = "tb_pw_verify";
      this.tb_pw_verify.PasswordChar = '*';
      this.tb_pw_verify.Size = new System.Drawing.Size(130, 25);
      this.tb_pw_verify.TabIndex = 6;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(3, 77);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(102, 15);
      this.label3.TabIndex = 5;
      this.label3.Text = "비밀번호 확인";
      // 
      // tb_name
      // 
      this.tb_name.Location = new System.Drawing.Point(111, 105);
      this.tb_name.MaxLength = 5;
      this.tb_name.Name = "tb_name";
      this.tb_name.Size = new System.Drawing.Size(130, 25);
      this.tb_name.TabIndex = 8;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(3, 108);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(37, 15);
      this.label4.TabIndex = 7;
      this.label4.Text = "이름";
      // 
      // tb_phone1
      // 
      this.tb_phone1.Enabled = false;
      this.tb_phone1.Location = new System.Drawing.Point(111, 136);
      this.tb_phone1.Name = "tb_phone1";
      this.tb_phone1.ReadOnly = true;
      this.tb_phone1.Size = new System.Drawing.Size(45, 25);
      this.tb_phone1.TabIndex = 10;
      this.tb_phone1.Text = "010";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(3, 139);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(67, 15);
      this.label5.TabIndex = 9;
      this.label5.Text = "전화번호";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(3, 170);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(37, 15);
      this.label6.TabIndex = 11;
      this.label6.Text = "주소";
      // 
      // cb_addr_captital
      // 
      this.cb_addr_captital.FormattingEnabled = true;
      this.cb_addr_captital.Items.AddRange(new object[] {
            "강원도",
            "경기도",
            "경상남도",
            "경상북도",
            "광주광역시",
            "대구광역시",
            "대전광역시",
            "부산광역시",
            "서울특별시",
            "인천광역시",
            "전라남도",
            "전라북도",
            "충청남도",
            "충청북도"});
      this.cb_addr_captital.Location = new System.Drawing.Point(111, 167);
      this.cb_addr_captital.Name = "cb_addr_captital";
      this.cb_addr_captital.Size = new System.Drawing.Size(130, 23);
      this.cb_addr_captital.TabIndex = 12;
      // 
      // tb_addr
      // 
      this.tb_addr.Location = new System.Drawing.Point(111, 196);
      this.tb_addr.MaxLength = 100;
      this.tb_addr.Name = "tb_addr";
      this.tb_addr.Size = new System.Drawing.Size(235, 25);
      this.tb_addr.TabIndex = 13;
      // 
      // tb_phone2
      // 
      this.tb_phone2.Location = new System.Drawing.Point(179, 136);
      this.tb_phone2.MaxLength = 4;
      this.tb_phone2.Name = "tb_phone2";
      this.tb_phone2.Size = new System.Drawing.Size(45, 25);
      this.tb_phone2.TabIndex = 15;
      this.tb_phone2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_phone2_KeyPress);
      // 
      // tb_phone3
      // 
      this.tb_phone3.Location = new System.Drawing.Point(250, 136);
      this.tb_phone3.MaxLength = 4;
      this.tb_phone3.Name = "tb_phone3";
      this.tb_phone3.Size = new System.Drawing.Size(45, 25);
      this.tb_phone3.TabIndex = 16;
      this.tb_phone3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_phone3_KeyPress);
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(158, 139);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(15, 15);
      this.label8.TabIndex = 17;
      this.label8.Text = "-";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(229, 139);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(15, 15);
      this.label9.TabIndex = 18;
      this.label9.Text = "-";
      // 
      // btn_onJoin
      // 
      this.btn_onJoin.Location = new System.Drawing.Point(80, 248);
      this.btn_onJoin.Name = "btn_onJoin";
      this.btn_onJoin.Size = new System.Drawing.Size(105, 55);
      this.btn_onJoin.TabIndex = 1;
      this.btn_onJoin.Text = "회원가입";
      this.btn_onJoin.UseVisualStyleBackColor = true;
      this.btn_onJoin.Click += new System.EventHandler(this.btn_onJoin_Click);
      // 
      // btn_cancel
      // 
      this.btn_cancel.Location = new System.Drawing.Point(191, 248);
      this.btn_cancel.Name = "btn_cancel";
      this.btn_cancel.Size = new System.Drawing.Size(105, 55);
      this.btn_cancel.TabIndex = 2;
      this.btn_cancel.Text = "취소";
      this.btn_cancel.UseVisualStyleBackColor = true;
      // 
      // Join
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(373, 315);
      this.Controls.Add(this.btn_cancel);
      this.Controls.Add(this.btn_onJoin);
      this.Controls.Add(this.panel1);
      this.Name = "Join";
      this.Text = "Join";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox tb_phone1;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox tb_name;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox tb_pw_verify;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox tb_pw;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.TextBox tb_id;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cb_addr_captital;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox tb_phone3;
    private System.Windows.Forms.TextBox tb_phone2;
    private System.Windows.Forms.TextBox tb_addr;
    private System.Windows.Forms.Button btn_onJoin;
    private System.Windows.Forms.Button btn_cancel;
  }
}