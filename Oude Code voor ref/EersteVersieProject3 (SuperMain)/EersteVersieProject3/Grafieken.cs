using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using Microsoft.VisualBasic.FileIO;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;




namespace EersteVersieProject3
{
    public partial class Grafieken : Form
    {
        string image1 = null;
        string image2 = null;
        string image3 = null;
        string image4 = null; //HABBO: Variables image1 till image4 will be used to store images for the PDF.
        NpgsqlCommand cmd;

        public Grafieken(NpgsqlCommand cmd)
        {
            InitializeComponent();
            this.cmd = cmd;
        }


        private void ArchitectButton_Click(object sender, EventArgs e) //clears all current points and create new ones related to the clicked button
        {
            // clear the graph of the button
            foreach (var series in chart1.Series)
                series.Points.Clear();

            // create new graph of the button
            List<Architectbar> GraphBars = new List<Architectbar>();
            GraphBars.Add(new Architectbar("'A. Ot%'"));
            GraphBars.Add(new Architectbar("'J. & Zn%'"));
            GraphBars.Add(new Architectbar("'J.H. van%'"));
            GraphBars.Add(new Architectbar("'T.L. Kan%'"));
            GraphBars.Add(new Architectbar("'P.G. Bus%'"));
            GraphBars.Add(new Architectbar("'M.J. Gra%'"));
            GraphBars.Add(new Architectbar("'H.P.J. de%'"));
            GraphBars.Add(new Architectbar("'E.H. Kra%'"));
            GraphBars.Add(new Architectbar("'A.W. Meyn%'"));
            GraphBars.Add(new Architectbar("'M.A.C. Mei%'"));
            GraphBars.Add(new Architectbar("'Jac. van%'"));
            GraphBars.Add(new Architectbar("'E.J. Mar%'"));
            GraphBars.Add(new Architectbar("'J.C. Mey%'"));
            GraphBars.Add(new Architectbar("'H.D. Bak%'"));

            Architect graph = new Architect(GraphBars);

            foreach (Architectbar bar in graph.Bars)
                this.chart1.Series["Number of buildings"].Points.AddXY(bar.GetName(cmd), bar.GetValue(cmd));

            // Sets angle of names of the bars in the graph
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

            // Makes sure name of every bar is shown
            this.chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            // For PDF
            image1 = "Architect barplot.jpg";
            chart1.SaveImage(image1, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Jpeg); // HABBO: chart1 will be stored inside inside image1

        }
        private void Year_Button_Click(object sender, EventArgs e) //clears all current points and create new ones related to the clicked button
        {
            foreach (var series in chart1.Series)
                series.Points.Clear();

            List<ConstrYearGraphBar> GraphBars = new List<ConstrYearGraphBar>();
            GraphBars.Add(new ConstrYearGraphBar("1600", "'16%'"));
            GraphBars.Add(new ConstrYearGraphBar("1700", "'17%'"));
            GraphBars.Add(new ConstrYearGraphBar("1810", "'181%'"));
            GraphBars.Add(new ConstrYearGraphBar("1820", "'182%'"));
            GraphBars.Add(new ConstrYearGraphBar("1830", "'183%'"));
            GraphBars.Add(new ConstrYearGraphBar("1840", "'184%'"));
            GraphBars.Add(new ConstrYearGraphBar("1850", "'185%'"));
            GraphBars.Add(new ConstrYearGraphBar("1860", "'186%'"));
            GraphBars.Add(new ConstrYearGraphBar("1870", "'187%'"));
            GraphBars.Add(new ConstrYearGraphBar("1880", "'188%'"));
            GraphBars.Add(new ConstrYearGraphBar("1890", "'189%'"));
            GraphBars.Add(new ConstrYearGraphBar("1900", "'190%'"));
            GraphBars.Add(new ConstrYearGraphBar("1910", "'191%'"));
            GraphBars.Add(new ConstrYearGraphBar("1920", "'192%'"));
            GraphBars.Add(new ConstrYearGraphBar("1930", "'193%'"));
            GraphBars.Add(new ConstrYearGraphBar("1940", "'194%'"));
            GraphBars.Add(new ConstrYearGraphBar("1950", "'195%'"));
            GraphBars.Add(new ConstrYearGraphBar("1960", "'196%'"));
            GraphBars.Add(new ConstrYearGraphBar("1970", "'197%'"));
            GraphBars.Add(new ConstrYearGraphBar("1980", "'198%'"));
            GraphBars.Add(new ConstrYearGraphBar("1990", "'199%'"));
            GraphBars.Add(new ConstrYearGraphBar("2000", "'2%'"));

            ConstrYearGraph graph = new ConstrYearGraph(GraphBars);

            foreach (ConstrYearGraphBar bar in graph.Bars)
                this.chart1.Series["Number of buildings"].Points.AddXY(bar.identifier, bar.GetValue(cmd));

            // Sets angle of names of the bars in the graph
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

            // Makes sure name of every bar is shown
            this.chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            // For PDF
            image2 = "Construction year graph.jpg";
            chart1.SaveImage(image2, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Jpeg); // HABBO: chart1 will be stored inside inside image2
        }
        private void Origin_Button_Click(object sender, EventArgs e) //clears all current points and create new ones related to the clicked button
        {
            foreach (var series in chart1.Series)
                series.Points.Clear();

            List<Originbar> GraphBars = new List<Originbar>();
            GraphBars.Add(new Originbar("'Bio%'"));
            GraphBars.Add(new Originbar("'Open%'"));
            GraphBars.Add(new Originbar("'Sport%'"));
            GraphBars.Add(new Originbar("'School%'"));
            GraphBars.Add(new Originbar("'Relig%'"));
            GraphBars.Add(new Originbar("'Tuinobj%'"));
            GraphBars.Add(new Originbar("'Bedrijf%'"));
            GraphBars.Add(new Originbar("'Tuin'"));
            GraphBars.Add(new Originbar("'Woni%'"));
            GraphBars.Add(new Originbar("'Woning(en) He%'"));
            GraphBars.Add(new Originbar("'Hor%'"));
            GraphBars.Add(new Originbar("'Begraa%'"));
            GraphBars.Add(new Originbar("'Woning(en) met bedrij%'"));
            GraphBars.Add(new Originbar("'Caf'"));
            GraphBars.Add(new Originbar("'Wate%'"));
            GraphBars.Add(new Originbar("'Weg-%'"));
            GraphBars.Add(new Originbar("'Woning(en) vrij%'"));
            GraphBars.Add(new Originbar("'Woning(en) flat%'"));
            GraphBars.Add(new Originbar("'Los%'"));
            GraphBars.Add(new Originbar("'Agra%'"));

            Origin graph = new Origin(GraphBars);

            foreach (Originbar bar in graph.Bars)
                this.chart1.Series["Number of buildings"].Points.AddXY(bar.GetName(cmd), bar.GetValue(cmd));

            // Sets angle of names of the bars in the graph
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

            // Makes sure name of every bar is shown
            this.chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            // For PDF
            image3 = "Origin graph.jpg";
            chart1.SaveImage(image3, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Jpeg); // HABBO: chart1 will be stored inside inside image3
        }
        private void StyleButton_Click(object sender, EventArgs e) //clears all current points and create new ones related to the clicked button
        {
            foreach (var series in chart2.Series)
                series.Points.Clear();

            List<BuildingStylebar> GraphBars = new List<BuildingStylebar>();
            GraphBars.Add(new BuildingStylebar("'Expr%'"));
            GraphBars.Add(new BuildingStylebar("'Niet%'"));
            GraphBars.Add(new BuildingStylebar("'Jug%'"));
            GraphBars.Add(new BuildingStylebar("'Over%'"));
            GraphBars.Add(new BuildingStylebar("'Chal%'"));
            GraphBars.Add(new BuildingStylebar("'Nieuw Trad%'"));
            GraphBars.Add(new BuildingStylebar("'Ku%'"));
            GraphBars.Add(new BuildingStylebar("'Art%'"));
            GraphBars.Add(new BuildingStylebar("'Um%'"));
            GraphBars.Add(new BuildingStylebar("'Ecl%'"));
            GraphBars.Add(new BuildingStylebar("'Moder%'"));
            GraphBars.Add(new BuildingStylebar("'Neo%'"));
            GraphBars.Add(new BuildingStylebar("'Ams%'"));

            BuildingStyle graph = new BuildingStyle(GraphBars);

            int total = 0;
            foreach (BuildingStylebar bar in graph.Bars)
                total += bar.GetValue(cmd);

            int percentage;
            foreach (BuildingStylebar bar in graph.Bars)
            {
                percentage = (int)(((float)(bar.GetValue(cmd)))/(float)total * 100);
                this.chart2.Series["Style"].Points.AddXY(bar.GetName(cmd) + percentage + " %", bar.GetValue(cmd));
            }

            // to not show text in pie chart
            chart2.Series[0]["PieLabelStyle"] = "Disabled";

            // For PDF
            image4 = "Building style graph.jpg";
            chart2.SaveImage(image4, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Jpeg); // HABBO: chart1 will be stored inside inside image4

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void EXIT_Click(object sender, EventArgs e) //Close the WindowsForms-thread and continue running monogame
        {
            Application.ExitThread();
        }

        private void CreatePDF_Click(object sender, EventArgs e) // Creates a PDF file containing all graphs and puts it in a map of the program
        {
            Document doc = new Document(); // HABBO: A variable doc is declared, which will be a new instance of a Document object.
            
            using (var stream = new FileStream("Explanation of visuals report.pdf", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                PdfWriter.GetInstance(doc, stream);
                doc.Open();

                // graph 1
                if (image1 != null)
                {
                    doc.Add(new Paragraph("The amount of monuments per architect"));
                    using (var imageStream = new FileStream(image1, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        var image_instance1 = iTextSharp.text.Image.GetInstance(imageStream);
                        image_instance1.ScaleToFit(500f, 500f);
                        doc.Add(image_instance1); // HABBO: Image1 will be added to the PDF
                    }
                }

                // graph 2
                if (image2 != null)
                {
                    doc.NewPage();
                    doc.Add(new Paragraph("The amount of monuments per decade"));
                    using (var imageStream = new FileStream(image2, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        var image_instance2 = iTextSharp.text.Image.GetInstance(imageStream);
                        image_instance2.ScaleToFit(500f, 500f);
                        doc.Add(image_instance2); // HABBO: Image2 will be added to the PDF
                    }
                }

                // graph 3
                if (image3 != null)
                {
                    doc.NewPage();
                    doc.Add(new Paragraph("The amount of monuments per original usage"));
                    using (var imageStream = new FileStream(image3, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        var image_instance3 = iTextSharp.text.Image.GetInstance(imageStream);
                        image_instance3.ScaleToFit(500f, 500f);
                        doc.Add(image_instance3); // HABBO: Image3 will be added to the PDF
                    }
                }

                // graph 4
                if (image4 != null)
                {

                    doc.NewPage();
                    doc.Add(new Paragraph("The amount of monuments per architectural style in percentages"));
                    using (var imageStream = new FileStream(image4, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        var image_instance4 = iTextSharp.text.Image.GetInstance(imageStream);
                        image_instance4.ScaleToFit(500f, 500f);
                        doc.Add(image_instance4); // HABBO: Image4 will be added to the PDF
                    }
                }

                if (image1 == null && image2 == null && image3 == null && image4 == null)
                {
                    doc.Add(new Paragraph("No graphs were selected"));
                }

                doc.Close();
            }

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
    }
}
