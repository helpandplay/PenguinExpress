
namespace PenguinExpress.employee
{
  partial class SetWorker
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
      this.cb_workers = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.lb_region = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.lb_trackingId = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.btn_ok = new System.Windows.Forms.Button();
      this.btn_cancel = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.label4);
      this.panel1.Controls.Add(this.cb_workers);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this.lb_region);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.lb_trackingId);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Location = new System.Drawing.Point(12, 12);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(227, 170);
      this.panel1.TabIndex = 0;
      // 
      // cb_workers
      // 
      this.cb_workers.FormattingEnabled = true;
      this.cb_workers.Location = new System.Drawing.Point(96, 72);
      this.cb_workers.Name = "cb_workers";
      this.cb_workers.Size = new System.Drawing.Size(121, 23);
      this.cb_workers.TabIndex = 6;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(3, 75);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(87, 15);
      this.label3.TabIndex = 5;
      this.label3.Text = "배정할 기사";
      // 
      // lb_region
      // 
      this.lb_region.AutoSize = true;
      this.lb_region.Location = new System.Drawing.Point(102, 46);
      this.lb_region.Name = "lb_region";
      this.lb_region.Size = new System.Drawing.Size(0, 15);
      this.lb_region.TabIndex = 4;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(3, 44);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(37, 15);
      this.label2.TabIndex = 3;
      this.label2.Text = "지역";
      // 
      // lb_trackingId
      // 
      this.lb_trackingId.AutoSize = true;
      this.lb_trackingId.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.lb_trackingId.Location = new System.Drawing.Point(102, 12);
      this.lb_trackingId.Name = "lb_trackingId";
      this.lb_trackingId.Size = new System.Drawing.Size(0, 17);
      this.lb_trackingId.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(3, 10);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(82, 15);
      this.label1.TabIndex = 1;
      this.label1.Text = "운송장번호";
      // 
      // btn_ok
      // 
      this.btn_ok.Location = new System.Drawing.Point(13, 188);
      this.btn_ok.Name = "btn_ok";
      this.btn_ok.Size = new System.Drawing.Size(111, 42);
      this.btn_ok.TabIndex = 1;
      this.btn_ok.Text = "배정";
      this.btn_ok.UseVisualStyleBackColor = true;
      this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
      // 
      // btn_cancel
      // 
      this.btn_cancel.Location = new System.Drawing.Point(128, 188);
      this.btn_cancel.Name = "btn_cancel";
      this.btn_cancel.Size = new System.Drawing.Size(111, 42);
      this.btn_cancel.TabIndex = 2;
      this.btn_cancel.Text = "취소";
      this.btn_cancel.UseVisualStyleBackColor = true;
      this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Impact", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.label4.Location = new System.Drawing.Point(20, 121);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(168, 29);
      this.label4.TabIndex = 8;
      this.label4.Text = "PenguinExpress";
      // 
      // SetWorker
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(251, 242);
      this.Controls.Add(this.btn_cancel);
      this.Controls.Add(this.btn_ok);
      this.Controls.Add(this.panel1);
      this.Name = "SetWorker";
      this.Text = "SetWorker";
      this.Load += new System.EventHandler(this.SetWorker_Load);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label lb_trackingId;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cb_workers;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label lb_region;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btn_ok;
    private System.Windows.Forms.Button btn_cancel;
    private System.Windows.Forms.Label label4;
  }
}