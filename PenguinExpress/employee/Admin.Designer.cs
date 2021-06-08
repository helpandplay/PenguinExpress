
namespace PenguinExpress.employee
{
  partial class Admin
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
      this.listTab = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.lv_delivery = new System.Windows.Forms.ListView();
      this.ch_tracking_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ch_seller_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ch_p_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ch_p_qty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ch_p_code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ch_region_code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ch_rv_time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ch_e_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ch_status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.lv_complete = new System.Windows.Forms.ListView();
      this.ch_cp_tracking_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ch_cp_s_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ch_cp_s_phone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ch_cp_b_phone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ch_cp_worker_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ch_cp_rv_time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.ch_cp_time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.btn_refresh = new System.Windows.Forms.Button();
      this.btn_getItemGraph = new System.Windows.Forms.Button();
      this.btn_getRegionGraph = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.listTab.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.SuspendLayout();
      // 
      // listTab
      // 
      this.listTab.Controls.Add(this.tabPage1);
      this.listTab.Controls.Add(this.tabPage2);
      this.listTab.Location = new System.Drawing.Point(12, 35);
      this.listTab.Name = "listTab";
      this.listTab.SelectedIndex = 0;
      this.listTab.Size = new System.Drawing.Size(1044, 364);
      this.listTab.TabIndex = 0;
      this.listTab.Selected += new System.Windows.Forms.TabControlEventHandler(this.listTab_Selected);
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.lv_delivery);
      this.tabPage1.Location = new System.Drawing.Point(4, 25);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(1036, 335);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "배송 현황";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // lv_delivery
      // 
      this.lv_delivery.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_tracking_id,
            this.ch_seller_id,
            this.ch_p_name,
            this.ch_p_qty,
            this.ch_p_code,
            this.ch_region_code,
            this.ch_rv_time,
            this.ch_e_id,
            this.ch_status});
      this.lv_delivery.FullRowSelect = true;
      this.lv_delivery.GridLines = true;
      this.lv_delivery.HideSelection = false;
      this.lv_delivery.Location = new System.Drawing.Point(6, 6);
      this.lv_delivery.Name = "lv_delivery";
      this.lv_delivery.Size = new System.Drawing.Size(1024, 323);
      this.lv_delivery.TabIndex = 0;
      this.lv_delivery.UseCompatibleStateImageBehavior = false;
      this.lv_delivery.View = System.Windows.Forms.View.Details;
      this.lv_delivery.DoubleClick += new System.EventHandler(this.lv_delivery_DoubleClick);
      // 
      // ch_tracking_id
      // 
      this.ch_tracking_id.Text = "운송장번호";
      this.ch_tracking_id.Width = 90;
      // 
      // ch_seller_id
      // 
      this.ch_seller_id.Text = "판매자 ID";
      this.ch_seller_id.Width = 80;
      // 
      // ch_p_name
      // 
      this.ch_p_name.Text = "상품이름";
      this.ch_p_name.Width = 80;
      // 
      // ch_p_qty
      // 
      this.ch_p_qty.Text = "상품수량";
      this.ch_p_qty.Width = 80;
      // 
      // ch_p_code
      // 
      this.ch_p_code.Text = "품목";
      this.ch_p_code.Width = 70;
      // 
      // ch_region_code
      // 
      this.ch_region_code.Text = "배송지역";
      this.ch_region_code.Width = 80;
      // 
      // ch_rv_time
      // 
      this.ch_rv_time.Text = "예약시간";
      this.ch_rv_time.Width = 200;
      // 
      // ch_e_id
      // 
      this.ch_e_id.Text = "배송 기사";
      this.ch_e_id.Width = 80;
      // 
      // ch_status
      // 
      this.ch_status.Text = "배송상태";
      this.ch_status.Width = 120;
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.lv_complete);
      this.tabPage2.Location = new System.Drawing.Point(4, 25);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(1036, 335);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "배송 완료 리스트";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // lv_complete
      // 
      this.lv_complete.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_cp_tracking_id,
            this.ch_cp_s_id,
            this.ch_cp_s_phone,
            this.ch_cp_b_phone,
            this.ch_cp_worker_name,
            this.ch_cp_rv_time,
            this.ch_cp_time});
      this.lv_complete.FullRowSelect = true;
      this.lv_complete.GridLines = true;
      this.lv_complete.HideSelection = false;
      this.lv_complete.Location = new System.Drawing.Point(6, 6);
      this.lv_complete.Name = "lv_complete";
      this.lv_complete.Size = new System.Drawing.Size(1024, 323);
      this.lv_complete.TabIndex = 0;
      this.lv_complete.UseCompatibleStateImageBehavior = false;
      this.lv_complete.View = System.Windows.Forms.View.Details;
      // 
      // ch_cp_tracking_id
      // 
      this.ch_cp_tracking_id.Text = "운송장번호";
      this.ch_cp_tracking_id.Width = 90;
      // 
      // ch_cp_s_id
      // 
      this.ch_cp_s_id.Text = "판매자 ID";
      this.ch_cp_s_id.Width = 80;
      // 
      // ch_cp_s_phone
      // 
      this.ch_cp_s_phone.Text = "판매자연락처";
      this.ch_cp_s_phone.Width = 130;
      // 
      // ch_cp_b_phone
      // 
      this.ch_cp_b_phone.Text = "구매자연락처";
      this.ch_cp_b_phone.Width = 130;
      // 
      // ch_cp_worker_name
      // 
      this.ch_cp_worker_name.Text = "배송자";
      this.ch_cp_worker_name.Width = 80;
      // 
      // ch_cp_rv_time
      // 
      this.ch_cp_rv_time.Text = "예약 시간";
      this.ch_cp_rv_time.Width = 190;
      // 
      // ch_cp_time
      // 
      this.ch_cp_time.Text = "배송완료시간";
      this.ch_cp_time.Width = 190;
      // 
      // btn_refresh
      // 
      this.btn_refresh.Location = new System.Drawing.Point(964, 12);
      this.btn_refresh.Name = "btn_refresh";
      this.btn_refresh.Size = new System.Drawing.Size(88, 34);
      this.btn_refresh.TabIndex = 2;
      this.btn_refresh.Text = "새로고침";
      this.btn_refresh.UseVisualStyleBackColor = true;
      this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
      // 
      // btn_getItemGraph
      // 
      this.btn_getItemGraph.Location = new System.Drawing.Point(12, 405);
      this.btn_getItemGraph.Name = "btn_getItemGraph";
      this.btn_getItemGraph.Size = new System.Drawing.Size(130, 48);
      this.btn_getItemGraph.TabIndex = 3;
      this.btn_getItemGraph.Text = "품목별 통계";
      this.btn_getItemGraph.UseVisualStyleBackColor = true;
      this.btn_getItemGraph.Click += new System.EventHandler(this.btn_getItemGraph_Click);
      // 
      // btn_getRegionGraph
      // 
      this.btn_getRegionGraph.Location = new System.Drawing.Point(148, 405);
      this.btn_getRegionGraph.Name = "btn_getRegionGraph";
      this.btn_getRegionGraph.Size = new System.Drawing.Size(130, 48);
      this.btn_getRegionGraph.TabIndex = 4;
      this.btn_getRegionGraph.Text = "지역별 통계";
      this.btn_getRegionGraph.UseVisualStyleBackColor = true;
      this.btn_getRegionGraph.Click += new System.EventHandler(this.btn_getRegionGraph_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Impact", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.label1.Location = new System.Drawing.Point(13, 3);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(168, 29);
      this.label1.TabIndex = 5;
      this.label1.Text = "PenguinExpress";
      // 
      // Admin
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1068, 465);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btn_getRegionGraph);
      this.Controls.Add(this.btn_getItemGraph);
      this.Controls.Add(this.btn_refresh);
      this.Controls.Add(this.listTab);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Admin";
      this.Text = "Admin";
      this.Load += new System.EventHandler(this.Admin_Load);
      this.listTab.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TabControl listTab;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.ListView lv_delivery;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.ListView lv_complete;
    private System.Windows.Forms.Button btn_refresh;
    private System.Windows.Forms.Button btn_getItemGraph;
    private System.Windows.Forms.Button btn_getRegionGraph;
    private System.Windows.Forms.ColumnHeader ch_tracking_id;
    private System.Windows.Forms.ColumnHeader ch_seller_id;
    private System.Windows.Forms.ColumnHeader ch_p_name;
    private System.Windows.Forms.ColumnHeader ch_p_qty;
    private System.Windows.Forms.ColumnHeader ch_p_code;
    private System.Windows.Forms.ColumnHeader ch_region_code;
    private System.Windows.Forms.ColumnHeader ch_rv_time;
    private System.Windows.Forms.ColumnHeader ch_status;
    private System.Windows.Forms.ColumnHeader ch_cp_tracking_id;
    private System.Windows.Forms.ColumnHeader ch_cp_s_id;
    private System.Windows.Forms.ColumnHeader ch_cp_s_phone;
    private System.Windows.Forms.ColumnHeader ch_cp_b_phone;
    private System.Windows.Forms.ColumnHeader ch_cp_worker_name;
    private System.Windows.Forms.ColumnHeader ch_cp_rv_time;
    private System.Windows.Forms.ColumnHeader ch_cp_time;
    private System.Windows.Forms.ColumnHeader ch_e_id;
    private System.Windows.Forms.Label label1;
  }
}