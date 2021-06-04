
namespace PenguinExpress.employee
{
  partial class Deliever
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
      this.lv_delivery_list = new System.Windows.Forms.ListView();
      this.ch_tracking_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ch_p_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ch_p_qty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ch_b_phone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ch_b_addr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ch_s_phone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.btn_refresh = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.lb_dv_id = new System.Windows.Forms.Label();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.lb_dv_id);
      this.panel1.Controls.Add(this.btn_refresh);
      this.panel1.Controls.Add(this.lv_delivery_list);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Location = new System.Drawing.Point(12, 12);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(776, 364);
      this.panel1.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.label1.Location = new System.Drawing.Point(3, 10);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(98, 17);
      this.label1.TabIndex = 0;
      this.label1.Text = "배송 리스트";
      // 
      // lv_delivery_list
      // 
      this.lv_delivery_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_tracking_id,
            this.ch_p_name,
            this.ch_p_qty,
            this.ch_b_addr,
            this.ch_b_phone,
            this.ch_s_phone});
      this.lv_delivery_list.FullRowSelect = true;
      this.lv_delivery_list.GridLines = true;
      this.lv_delivery_list.HideSelection = false;
      this.lv_delivery_list.Location = new System.Drawing.Point(3, 30);
      this.lv_delivery_list.Name = "lv_delivery_list";
      this.lv_delivery_list.Size = new System.Drawing.Size(770, 331);
      this.lv_delivery_list.TabIndex = 1;
      this.lv_delivery_list.UseCompatibleStateImageBehavior = false;
      this.lv_delivery_list.View = System.Windows.Forms.View.Details;
      // 
      // ch_tracking_id
      // 
      this.ch_tracking_id.Text = "운송장번호";
      this.ch_tracking_id.Width = 90;
      // 
      // ch_p_name
      // 
      this.ch_p_name.Text = "상품명";
      this.ch_p_name.Width = 130;
      // 
      // ch_p_qty
      // 
      this.ch_p_qty.Text = "상품수량";
      this.ch_p_qty.Width = 80;
      // 
      // ch_b_phone
      // 
      this.ch_b_phone.Text = "구매자번호";
      this.ch_b_phone.Width = 120;
      // 
      // ch_b_addr
      // 
      this.ch_b_addr.Text = "배송지";
      this.ch_b_addr.Width = 200;
      // 
      // ch_s_phone
      // 
      this.ch_s_phone.Text = "판매자번호";
      this.ch_s_phone.Width = 120;
      // 
      // btn_refresh
      // 
      this.btn_refresh.Location = new System.Drawing.Point(682, 4);
      this.btn_refresh.Name = "btn_refresh";
      this.btn_refresh.Size = new System.Drawing.Size(91, 23);
      this.btn_refresh.TabIndex = 2;
      this.btn_refresh.Text = "새로고침";
      this.btn_refresh.UseVisualStyleBackColor = true;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(12, 382);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(101, 56);
      this.button1.TabIndex = 1;
      this.button1.Text = "배송 완료";
      this.button1.UseVisualStyleBackColor = true;
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(119, 382);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(101, 56);
      this.button2.TabIndex = 2;
      this.button2.Text = "예상 급여";
      this.button2.UseVisualStyleBackColor = true;
      // 
      // lb_dv_id
      // 
      this.lb_dv_id.AutoSize = true;
      this.lb_dv_id.Location = new System.Drawing.Point(107, 12);
      this.lb_dv_id.Name = "lb_dv_id";
      this.lb_dv_id.Size = new System.Drawing.Size(28, 15);
      this.lb_dv_id.TabIndex = 3;
      this.lb_dv_id.Text = "id :";
      // 
      // Deliever
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.panel1);
      this.Name = "Deliever";
      this.Text = "Deliever";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Deliever_FormClosed);
      this.Load += new System.EventHandler(this.Deliever_Load_1);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label lb_dv_id;
    private System.Windows.Forms.Button btn_refresh;
    private System.Windows.Forms.ListView lv_delivery_list;
    private System.Windows.Forms.ColumnHeader ch_tracking_id;
    private System.Windows.Forms.ColumnHeader ch_p_name;
    private System.Windows.Forms.ColumnHeader ch_p_qty;
    private System.Windows.Forms.ColumnHeader ch_b_addr;
    private System.Windows.Forms.ColumnHeader ch_b_phone;
    private System.Windows.Forms.ColumnHeader ch_s_phone;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
  }
}