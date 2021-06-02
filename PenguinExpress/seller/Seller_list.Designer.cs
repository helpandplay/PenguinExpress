
namespace PenguinExpress.seller
{
  partial class Seller_list
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
      this.lv_reg = new System.Windows.Forms.ListView();
      this.ch_prod_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ch_prod_qty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ch_b_phone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ch_b_addr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ch_rv_time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ch_status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.btn_add_rv = new System.Windows.Forms.Button();
      this.btn_rv_cancel = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.btn_reg_refresh = new System.Windows.Forms.Button();
      this.lv_cp = new System.Windows.Forms.ListView();
      this.ch_cp_prod_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ch_cp_prod_qty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ch_cp_b_phone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ch_cp_b_addr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ch_cp_time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ch_cp_status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.btn_cp_refresh = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.ch_tracking_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ch_cp_tracking_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.SuspendLayout();
      // 
      // lv_reg
      // 
      this.lv_reg.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_tracking_id,
            this.ch_prod_name,
            this.ch_prod_qty,
            this.ch_b_phone,
            this.ch_b_addr,
            this.ch_rv_time,
            this.ch_status});
      this.lv_reg.FullRowSelect = true;
      this.lv_reg.GridLines = true;
      this.lv_reg.HideSelection = false;
      this.lv_reg.Location = new System.Drawing.Point(12, 30);
      this.lv_reg.Name = "lv_reg";
      this.lv_reg.Size = new System.Drawing.Size(776, 254);
      this.lv_reg.TabIndex = 0;
      this.lv_reg.UseCompatibleStateImageBehavior = false;
      this.lv_reg.View = System.Windows.Forms.View.Details;
      this.lv_reg.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_reg_ColumnClick);
      // 
      // ch_prod_name
      // 
      this.ch_prod_name.Tag = "false";
      this.ch_prod_name.Text = "이름";
      this.ch_prod_name.Width = 150;
      // 
      // ch_prod_qty
      // 
      this.ch_prod_qty.Tag = "false";
      this.ch_prod_qty.Text = "수량";
      this.ch_prod_qty.Width = 50;
      // 
      // ch_b_phone
      // 
      this.ch_b_phone.Tag = "false";
      this.ch_b_phone.Text = "연락처";
      this.ch_b_phone.Width = 90;
      // 
      // ch_b_addr
      // 
      this.ch_b_addr.Tag = "false";
      this.ch_b_addr.Text = "주소";
      this.ch_b_addr.Width = 100;
      // 
      // ch_rv_time
      // 
      this.ch_rv_time.Tag = "false";
      this.ch_rv_time.Text = "예약된 시간";
      this.ch_rv_time.Width = 120;
      // 
      // ch_status
      // 
      this.ch_status.Tag = "false";
      this.ch_status.Text = "상태";
      this.ch_status.Width = 90;
      // 
      // btn_add_rv
      // 
      this.btn_add_rv.Location = new System.Drawing.Point(12, 290);
      this.btn_add_rv.Name = "btn_add_rv";
      this.btn_add_rv.Size = new System.Drawing.Size(112, 57);
      this.btn_add_rv.TabIndex = 1;
      this.btn_add_rv.Text = "택배 예약";
      this.btn_add_rv.UseVisualStyleBackColor = true;
      // 
      // btn_rv_cancel
      // 
      this.btn_rv_cancel.Location = new System.Drawing.Point(130, 290);
      this.btn_rv_cancel.Name = "btn_rv_cancel";
      this.btn_rv_cancel.Size = new System.Drawing.Size(112, 57);
      this.btn_rv_cancel.TabIndex = 2;
      this.btn_rv_cancel.Text = "예약 취소";
      this.btn_rv_cancel.UseVisualStyleBackColor = true;
      this.btn_rv_cancel.Click += new System.EventHandler(this.btn_rv_cancel_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(9, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(87, 15);
      this.label1.TabIndex = 3;
      this.label1.Text = "등록 리스트";
      // 
      // btn_reg_refresh
      // 
      this.btn_reg_refresh.Location = new System.Drawing.Point(697, 1);
      this.btn_reg_refresh.Name = "btn_reg_refresh";
      this.btn_reg_refresh.Size = new System.Drawing.Size(91, 23);
      this.btn_reg_refresh.TabIndex = 4;
      this.btn_reg_refresh.Text = "새로고침";
      this.btn_reg_refresh.UseVisualStyleBackColor = true;
      this.btn_reg_refresh.Click += new System.EventHandler(this.btn_reg_refresh_Click);
      // 
      // lv_cp
      // 
      this.lv_cp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_cp_tracking_id,
            this.ch_cp_prod_name,
            this.ch_cp_prod_qty,
            this.ch_cp_b_phone,
            this.ch_cp_b_addr,
            this.ch_cp_time,
            this.ch_cp_status});
      this.lv_cp.FullRowSelect = true;
      this.lv_cp.GridLines = true;
      this.lv_cp.HideSelection = false;
      this.lv_cp.Location = new System.Drawing.Point(12, 382);
      this.lv_cp.Name = "lv_cp";
      this.lv_cp.Size = new System.Drawing.Size(776, 320);
      this.lv_cp.TabIndex = 5;
      this.lv_cp.UseCompatibleStateImageBehavior = false;
      this.lv_cp.View = System.Windows.Forms.View.Details;
      this.lv_cp.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_cp_ColumnClick);
      // 
      // ch_cp_prod_name
      // 
      this.ch_cp_prod_name.Tag = "false";
      this.ch_cp_prod_name.Text = "이름";
      this.ch_cp_prod_name.Width = 150;
      // 
      // ch_cp_prod_qty
      // 
      this.ch_cp_prod_qty.Tag = "false";
      this.ch_cp_prod_qty.Text = "수량";
      this.ch_cp_prod_qty.Width = 50;
      // 
      // ch_cp_b_phone
      // 
      this.ch_cp_b_phone.Tag = "false";
      this.ch_cp_b_phone.Text = "연락처";
      this.ch_cp_b_phone.Width = 90;
      // 
      // ch_cp_b_addr
      // 
      this.ch_cp_b_addr.Tag = "false";
      this.ch_cp_b_addr.Text = "주소";
      this.ch_cp_b_addr.Width = 100;
      // 
      // ch_cp_time
      // 
      this.ch_cp_time.Tag = "false";
      this.ch_cp_time.Text = "도착 시간";
      this.ch_cp_time.Width = 130;
      // 
      // ch_cp_status
      // 
      this.ch_cp_status.Tag = "false";
      this.ch_cp_status.Text = "상태";
      this.ch_cp_status.Width = 80;
      // 
      // btn_cp_refresh
      // 
      this.btn_cp_refresh.Location = new System.Drawing.Point(697, 353);
      this.btn_cp_refresh.Name = "btn_cp_refresh";
      this.btn_cp_refresh.Size = new System.Drawing.Size(91, 23);
      this.btn_cp_refresh.TabIndex = 6;
      this.btn_cp_refresh.Text = "새로고침";
      this.btn_cp_refresh.UseVisualStyleBackColor = true;
      this.btn_cp_refresh.Click += new System.EventHandler(this.btn_cp_refresh_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 364);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(87, 15);
      this.label2.TabIndex = 7;
      this.label2.Text = "완료 리스트";
      // 
      // ch_tracking_id
      // 
      this.ch_tracking_id.Tag = "false";
      this.ch_tracking_id.Text = "운송장번호";
      this.ch_tracking_id.Width = 100;
      // 
      // ch_cp_tracking_id
      // 
      this.ch_cp_tracking_id.Tag = "false";
      this.ch_cp_tracking_id.Text = "운송장번호";
      this.ch_cp_tracking_id.Width = 100;
      // 
      // Seller_list
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 685);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.btn_cp_refresh);
      this.Controls.Add(this.lv_cp);
      this.Controls.Add(this.btn_reg_refresh);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btn_rv_cancel);
      this.Controls.Add(this.btn_add_rv);
      this.Controls.Add(this.lv_reg);
      this.Name = "Seller_list";
      this.Text = "List";
      this.Load += new System.EventHandler(this.List_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ListView lv_reg;
    private System.Windows.Forms.ColumnHeader ch_prod_name;
    private System.Windows.Forms.ColumnHeader ch_prod_qty;
    private System.Windows.Forms.ColumnHeader ch_b_phone;
    private System.Windows.Forms.ColumnHeader ch_b_addr;
    private System.Windows.Forms.ColumnHeader ch_rv_time;
    private System.Windows.Forms.ColumnHeader ch_status;
    private System.Windows.Forms.Button btn_add_rv;
    private System.Windows.Forms.Button btn_rv_cancel;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btn_reg_refresh;
    private System.Windows.Forms.ListView lv_cp;
    private System.Windows.Forms.ColumnHeader ch_cp_prod_name;
    private System.Windows.Forms.ColumnHeader ch_cp_prod_qty;
    private System.Windows.Forms.ColumnHeader ch_cp_b_phone;
    private System.Windows.Forms.ColumnHeader ch_cp_b_addr;
    private System.Windows.Forms.Button btn_cp_refresh;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ColumnHeader ch_cp_time;
    private System.Windows.Forms.ColumnHeader ch_cp_status;
    private System.Windows.Forms.ColumnHeader ch_tracking_id;
    private System.Windows.Forms.ColumnHeader ch_cp_tracking_id;
  }
}