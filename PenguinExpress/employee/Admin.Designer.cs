
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
      this.lb_id = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // lb_id
      // 
      this.lb_id.AutoSize = true;
      this.lb_id.Location = new System.Drawing.Point(349, 198);
      this.lb_id.Name = "lb_id";
      this.lb_id.Size = new System.Drawing.Size(37, 15);
      this.lb_id.TabIndex = 0;
      this.lb_id.Text = "ㅎㅇ";
      // 
      // Admin
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.lb_id);
      this.Name = "Admin";
      this.Text = "Admin";
      this.Load += new System.EventHandler(this.Admin_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lb_id;
  }
}