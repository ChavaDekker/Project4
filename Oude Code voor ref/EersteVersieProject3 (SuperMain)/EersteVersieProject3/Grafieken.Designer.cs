namespace EersteVersieProject3
{
    partial class Grafieken
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Origin_Button = new System.Windows.Forms.Button();
            this.Year_Button = new System.Windows.Forms.Button();
            this.StyleButton = new System.Windows.Forms.Button();
            this.ArchitectButton = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.EXIT = new System.Windows.Forms.Button();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.CreatePDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // Origin_Button
            // 
            this.Origin_Button.Location = new System.Drawing.Point(911, 14);
            this.Origin_Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Origin_Button.Name = "Origin_Button";
            this.Origin_Button.Size = new System.Drawing.Size(108, 63);
            this.Origin_Button.TabIndex = 11;
            this.Origin_Button.Text = "Origin";
            this.Origin_Button.UseVisualStyleBackColor = true;
            this.Origin_Button.Click += new System.EventHandler(this.Origin_Button_Click);
            // 
            // Year_Button
            // 
            this.Year_Button.Location = new System.Drawing.Point(783, 108);
            this.Year_Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Year_Button.Name = "Year_Button";
            this.Year_Button.Size = new System.Drawing.Size(111, 65);
            this.Year_Button.TabIndex = 10;
            this.Year_Button.Text = "Year";
            this.Year_Button.UseVisualStyleBackColor = true;
            this.Year_Button.Click += new System.EventHandler(this.Year_Button_Click);
            // 
            // StyleButton
            // 
            this.StyleButton.Location = new System.Drawing.Point(908, 110);
            this.StyleButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.StyleButton.Name = "StyleButton";
            this.StyleButton.Size = new System.Drawing.Size(111, 63);
            this.StyleButton.TabIndex = 9;
            this.StyleButton.Text = "Style Building";
            this.StyleButton.UseVisualStyleBackColor = true;
            this.StyleButton.Click += new System.EventHandler(this.StyleButton_Click);
            // 
            // ArchitectButton
            // 
            this.ArchitectButton.Location = new System.Drawing.Point(786, 12);
            this.ArchitectButton.Name = "ArchitectButton";
            this.ArchitectButton.Size = new System.Drawing.Size(108, 65);
            this.ArchitectButton.TabIndex = 8;
            this.ArchitectButton.Text = "Architect";
            this.ArchitectButton.UseVisualStyleBackColor = true;
            this.ArchitectButton.Click += new System.EventHandler(this.ArchitectButton_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(10, 11);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Number of buildings";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(748, 621);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // EXIT
            // 
            this.EXIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EXIT.Location = new System.Drawing.Point(1297, 11);
            this.EXIT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.EXIT.Name = "EXIT";
            this.EXIT.Size = new System.Drawing.Size(108, 46);
            this.EXIT.TabIndex = 12;
            this.EXIT.Text = "EXIT";
            this.EXIT.UseVisualStyleBackColor = true;
            this.EXIT.Click += new System.EventHandler(this.EXIT_Click);
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(786, 194);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Style";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(619, 438);
            this.chart2.TabIndex = 14;
            this.chart2.Text = "chart2";
            this.chart2.Click += new System.EventHandler(this.chart2_Click);
            // 
            // CreatePDF
            // 
            this.CreatePDF.Location = new System.Drawing.Point(1048, 66);
            this.CreatePDF.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CreatePDF.Name = "CreatePDF";
            this.CreatePDF.Size = new System.Drawing.Size(108, 63);
            this.CreatePDF.TabIndex = 15;
            this.CreatePDF.Text = "Create PDF";
            this.CreatePDF.UseVisualStyleBackColor = true;
            this.CreatePDF.Click += new System.EventHandler(this.CreatePDF_Click);
            // 
            // Grafieken
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 674);
            this.ControlBox = false;
            this.Controls.Add(this.CreatePDF);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.EXIT);
            this.Controls.Add(this.Origin_Button);
            this.Controls.Add(this.Year_Button);
            this.Controls.Add(this.StyleButton);
            this.Controls.Add(this.ArchitectButton);
            this.Controls.Add(this.chart1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Grafieken";
            this.Text = "Grafieken";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Origin_Button;
        private System.Windows.Forms.Button Year_Button;
        private System.Windows.Forms.Button StyleButton;
        private System.Windows.Forms.Button ArchitectButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button EXIT;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Button CreatePDF;
    }
}