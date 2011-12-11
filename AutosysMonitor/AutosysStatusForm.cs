using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace AutosysMonitor
{
    public partial class StatusForm : Form
    {
        private const string SYSTEMS = "systemer.txt";

        private List<IAutosysSystem> systemList = new List<IAutosysSystem>();

        public StatusForm()
        {
            InitializeComponent();
        }

        private void StatusForm_Load(object sender, EventArgs e)
        {
            ReadSystemsFromFile();

            this.SystemView.Update();

        }

        private void ReadSystemsFromFile()
        {
            ReadSystemsFromFile(SYSTEMS);
        }

        private void ReadSystemsFromFile(string filename)
        {
            systemList = AutosysSystemFileHandler.ReadFromFile(filename);
        }

        private void UpdateDataSource()
        {
            systemerDataSource.Clear();
            foreach (var item in systemList)
            {
                systemerDataSource.Add(item);
            }
        }



        private void updateAll()
        {
            List<IAutosysSystem> tempList = new List<IAutosysSystem>(systemList);


            foreach (IAutosysSystem item in tempList)
            {
				item.Update();
            }


            systemList.Clear();
            foreach (var item in tempList)
            {
                systemList.Add(item);
            }
        }

		private void UpdateAllButton_Click(object sender, EventArgs e)
        {

            updateAll();
            UpdateDataSource();
            SystemView.Invalidate();
            SystemView.Update();

        }

        private void Refreshtimer_Tick(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                this.backgroundWorker1.RunWorkerAsync();
            }
            UpdateDataSource();
            SystemView.Invalidate();
            SystemView.Update();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            updateAll();
        }


        private void SystemView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex != StatusColumn.DisplayIndex)
                return;
            var sys = systemList[e.RowIndex];
            Image ball;
			if(sys.GetType() == typeof(LineSplitter))
				return;
            if (sys.Alive)
            {
                //e.Value = global::AutosysMonitor.Properties.Resources.Red_ball;
                ball = global::AutosysMonitor.Properties.Resources.Green_ball;
            }
            else
            {
                ball = global::AutosysMonitor.Properties.Resources.Red_ball;
            }



            using (
                    Brush gridBrush = new SolidBrush(this.SystemView.GridColor),
                    backColorBrush = new SolidBrush(e.CellStyle.BackColor))
            {
                using (Pen gridLinePen = new Pen(gridBrush))
                {
                    // Erase the cell.
                    e.Graphics.FillRectangle(backColorBrush, e.CellBounds);

                    // Draw the grid lines (only the right and bottom lines;
                    // DataGridView takes care of the others).
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
                        e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
                        e.CellBounds.Bottom - 1);
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
                        e.CellBounds.Top, e.CellBounds.Right - 1,
                        e.CellBounds.Bottom);

                    //Draw image
                    int horsMiddle = (e.CellBounds.Left + e.CellBounds.Right) / 2;
                    int vertMiddle = (e.CellBounds.Bottom + e.CellBounds.Top) / 2;

                    horsMiddle -= ball.Width / 2;
                    vertMiddle -= ball.Height / 2;
                    Rectangle bounds = new Rectangle(horsMiddle, vertMiddle, ball.Width, ball.Height);

                    e.Graphics.DrawImage(ball, bounds);

                    // Draw the text content of the cell, ignoring alignment.

                    e.Handled = true;
                }
            }


        }

        private void ReloadFileButton_Click(object sender, EventArgs e)
        {
            var result = openSystemFileDialog.ShowDialog();
            systemList.Clear();
            ReadSystemsFromFile(openSystemFileDialog.FileName);
            SystemView.Invalidate();
            SystemView.Update();
        }

        private void StatusForm_Resize(object sender, EventArgs e)
        {
            var width = this.Width;
            SystemView.Width = width - 50;
        }

		private void systemerDataSource_CurrentChanged(object sender, EventArgs e)
		{

		}


    }



}

