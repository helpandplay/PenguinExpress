
namespace PenguinExpress.seller
{
  partial class AddProduct
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
      this.tb_p_name = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.tb_p_qty = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.cb_p_choice = new System.Windows.Forms.ComboBox();
      this.panel2 = new System.Windows.Forms.Panel();
      this.label4 = new System.Windows.Forms.Label();
      this.tb_s_phone = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.tb_s_name = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.panel3 = new System.Windows.Forms.Panel();
      this.label7 = new System.Windows.Forms.Label();
      this.tb_b_phone = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.tb_b_name = new System.Windows.Forms.TextBox();
      this.label9 = new System.Windows.Forms.Label();
      this.tb_s_addr = new System.Windows.Forms.TextBox();
      this.tb_b_addr = new System.Windows.Forms.TextBox();
      this.btn_addProduct = new System.Windows.Forms.Button();
      this.btn_cancel = new System.Windows.Forms.Button();
      this.tb_b_phone2 = new System.Windows.Forms.TextBox();
      this.tb_b_phone3 = new System.Windows.Forms.TextBox();
      this.label10 = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.cb_p_choice);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this.tb_p_qty);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.tb_p_name);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Location = new System.Drawing.Point(12, 12);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(302, 99);
      this.panel1.TabIndex = 0;
      // 
      // tb_p_name
      // 
      this.tb_p_name.Location = new System.Drawing.Point(105, 7);
      this.tb_p_name.MaxLength = 100;
      this.tb_p_name.Name = "tb_p_name";
      this.tb_p_name.Size = new System.Drawing.Size(182, 25);
      this.tb_p_name.TabIndex = 3;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 10);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(67, 15);
      this.label1.TabIndex = 2;
      this.label1.Text = "상품이름";
      // 
      // tb_p_qty
      // 
      this.tb_p_qty.Location = new System.Drawing.Point(105, 38);
      this.tb_p_qty.Name = "tb_p_qty";
      this.tb_p_qty.Size = new System.Drawing.Size(182, 25);
      this.tb_p_qty.TabIndex = 5;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 41);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(37, 15);
      this.label2.TabIndex = 4;
      this.label2.Text = "수량";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 72);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(37, 15);
      this.label3.TabIndex = 6;
      this.label3.Text = "품목";
      // 
      // cb_p_choice
      // 
      this.cb_p_choice.FormattingEnabled = true;
      this.cb_p_choice.Items.AddRange(new object[] {
            "의류",
            "전자제품류",
            "식품류",
            "식기류",
            "가구류",
            "의약품",
            "기타"});
      this.cb_p_choice.Location = new System.Drawing.Point(105, 69);
      this.cb_p_choice.Name = "cb_p_choice";
      this.cb_p_choice.Size = new System.Drawing.Size(182, 23);
      this.cb_p_choice.TabIndex = 7;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.tb_s_addr);
      this.panel2.Controls.Add(this.label4);
      this.panel2.Controls.Add(this.tb_s_phone);
      this.panel2.Controls.Add(this.label5);
      this.panel2.Controls.Add(this.tb_s_name);
      this.panel2.Controls.Add(this.label6);
      this.panel2.Location = new System.Drawing.Point(12, 117);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(302, 99);
      this.panel2.TabIndex = 8;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(12, 72);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(37, 15);
      this.label4.TabIndex = 6;
      this.label4.Text = "주소";
      // 
      // tb_s_phone
      // 
      this.tb_s_phone.Location = new System.Drawing.Point(105, 38);
      this.tb_s_phone.Name = "tb_s_phone";
      this.tb_s_phone.ReadOnly = true;
      this.tb_s_phone.Size = new System.Drawing.Size(182, 25);
      this.tb_s_phone.TabIndex = 5;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(12, 41);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(52, 15);
      this.label5.TabIndex = 4;
      this.label5.Text = "연락처";
      // 
      // tb_s_name
      // 
      this.tb_s_name.Location = new System.Drawing.Point(105, 7);
      this.tb_s_name.MaxLength = 100;
      this.tb_s_name.Name = "tb_s_name";
      this.tb_s_name.ReadOnly = true;
      this.tb_s_name.Size = new System.Drawing.Size(182, 25);
      this.tb_s_name.TabIndex = 3;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(12, 10);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(52, 15);
      this.label6.TabIndex = 2;
      this.label6.Text = "판매자";
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.label11);
      this.panel3.Controls.Add(this.label10);
      this.panel3.Controls.Add(this.tb_b_phone3);
      this.panel3.Controls.Add(this.tb_b_phone2);
      this.panel3.Controls.Add(this.tb_b_addr);
      this.panel3.Controls.Add(this.label7);
      this.panel3.Controls.Add(this.tb_b_phone);
      this.panel3.Controls.Add(this.label8);
      this.panel3.Controls.Add(this.tb_b_name);
      this.panel3.Controls.Add(this.label9);
      this.panel3.Location = new System.Drawing.Point(12, 222);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(302, 99);
      this.panel3.TabIndex = 8;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(12, 72);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(37, 15);
      this.label7.TabIndex = 6;
      this.label7.Text = "주소";
      // 
      // tb_b_phone
      // 
      this.tb_b_phone.Location = new System.Drawing.Point(105, 38);
      this.tb_b_phone.MaxLength = 13;
      this.tb_b_phone.Name = "tb_b_phone";
      this.tb_b_phone.ReadOnly = true;
      this.tb_b_phone.Size = new System.Drawing.Size(42, 25);
      this.tb_b_phone.TabIndex = 5;
      this.tb_b_phone.Text = "010";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(12, 41);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(52, 15);
      this.label8.TabIndex = 4;
      this.label8.Text = "연락처";
      // 
      // tb_b_name
      // 
      this.tb_b_name.Location = new System.Drawing.Point(105, 7);
      this.tb_b_name.MaxLength = 10;
      this.tb_b_name.Name = "tb_b_name";
      this.tb_b_name.Size = new System.Drawing.Size(182, 25);
      this.tb_b_name.TabIndex = 3;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(12, 10);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(52, 15);
      this.label9.TabIndex = 2;
      this.label9.Text = "구매자";
      // 
      // tb_s_addr
      // 
      this.tb_s_addr.Location = new System.Drawing.Point(105, 69);
      this.tb_s_addr.Name = "tb_s_addr";
      this.tb_s_addr.ReadOnly = true;
      this.tb_s_addr.Size = new System.Drawing.Size(182, 25);
      this.tb_s_addr.TabIndex = 7;
      // 
      // tb_b_addr
      // 
      this.tb_b_addr.Location = new System.Drawing.Point(105, 69);
      this.tb_b_addr.Name = "tb_b_addr";
      this.tb_b_addr.Size = new System.Drawing.Size(182, 25);
      this.tb_b_addr.TabIndex = 7;
      // 
      // btn_addProduct
      // 
      this.btn_addProduct.Location = new System.Drawing.Point(12, 336);
      this.btn_addProduct.Name = "btn_addProduct";
      this.btn_addProduct.Size = new System.Drawing.Size(147, 56);
      this.btn_addProduct.TabIndex = 9;
      this.btn_addProduct.Text = "택배 예약";
      this.btn_addProduct.UseVisualStyleBackColor = true;
      // 
      // btn_cancel
      // 
      this.btn_cancel.Location = new System.Drawing.Point(167, 336);
      this.btn_cancel.Name = "btn_cancel";
      this.btn_cancel.Size = new System.Drawing.Size(147, 56);
      this.btn_cancel.TabIndex = 10;
      this.btn_cancel.Text = "취소";
      this.btn_cancel.UseVisualStyleBackColor = true;
      // 
      // tb_b_phone2
      // 
      this.tb_b_phone2.Location = new System.Drawing.Point(175, 38);
      this.tb_b_phone2.MaxLength = 13;
      this.tb_b_phone2.Name = "tb_b_phone2";
      this.tb_b_phone2.Size = new System.Drawing.Size(42, 25);
      this.tb_b_phone2.TabIndex = 8;
      // 
      // tb_b_phone3
      // 
      this.tb_b_phone3.Location = new System.Drawing.Point(245, 38);
      this.tb_b_phone3.MaxLength = 13;
      this.tb_b_phone3.Name = "tb_b_phone3";
      this.tb_b_phone3.Size = new System.Drawing.Size(42, 25);
      this.tb_b_phone3.TabIndex = 9;
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(152, 41);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(15, 15);
      this.label10.TabIndex = 10;
      this.label10.Text = "-";
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(223, 41);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(15, 15);
      this.label11.TabIndex = 11;
      this.label11.Text = "-";
      // 
      // AddProduct
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(326, 400);
      this.Controls.Add(this.btn_cancel);
      this.Controls.Add(this.btn_addProduct);
      this.Controls.Add(this.panel3);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.Name = "AddProduct";
      this.Text = "AddProduct";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.ComboBox cb_p_choice;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox tb_p_qty;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox tb_p_name;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.TextBox tb_s_addr;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox tb_s_phone;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox tb_s_name;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.TextBox tb_b_phone3;
    private System.Windows.Forms.TextBox tb_b_phone2;
    private System.Windows.Forms.TextBox tb_b_addr;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox tb_b_phone;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox tb_b_name;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Button btn_addProduct;
    private System.Windows.Forms.Button btn_cancel;
  }
}