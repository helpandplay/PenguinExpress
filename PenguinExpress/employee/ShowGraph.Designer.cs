﻿
namespace PenguinExpress.employee
{
  partial class ShowGraph
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
      System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
      System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
      System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
      this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
      this.lb_max = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
      this.SuspendLayout();
      // 
      // chart
      // 
      chartArea1.Name = "ChartArea1";
      this.chart.ChartAreas.Add(chartArea1);
      legend1.Name = "Legend1";
      this.chart.Legends.Add(legend1);
      this.chart.Location = new System.Drawing.Point(12, 12);
      this.chart.Name = "chart";
      series1.ChartArea = "ChartArea1";
      series1.Legend = "Legend1";
      series1.Name = "Series1";
      this.chart.Series.Add(series1);
      this.chart.Size = new System.Drawing.Size(538, 426);
      this.chart.TabIndex = 0;
      this.chart.Text = "chart1";
      // 
      // lb_max
      // 
      this.lb_max.AutoSize = true;
      this.lb_max.Location = new System.Drawing.Point(421, 232);
      this.lb_max.Name = "lb_max";
      this.lb_max.Size = new System.Drawing.Size(45, 15);
      this.lb_max.TabIndex = 1;
      this.lb_max.Text = "label1";
      // 
      // ShowGraph
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(560, 450);
      this.Controls.Add(this.lb_max);
      this.Controls.Add(this.chart);
      this.Name = "ShowGraph";
      this.Text = "ShowGraph";
      this.Load += new System.EventHandler(this.ShowGraph_Load);
      ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DataVisualization.Charting.Chart chart;
    private System.Windows.Forms.Label lb_max;
  }
}