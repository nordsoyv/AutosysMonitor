﻿using System;
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

		private List<IAutosysSystem> currentSystemList = new List<IAutosysSystem>();
        private List<IAutosysSystem> masterSystemList = new List<IAutosysSystem>();

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
            masterSystemList = AutosysSystemFileHandler.ReadFromFile(filename);
            currentSystemList = masterSystemList.ToList();
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
            if (e.ColumnIndex == StatusColumn.DisplayIndex)
            {
                DrawStatusCell(e);
            }
            


		}

        private void DrawStatusCell(DataGridViewCellPaintingEventArgs e)
        {
            var sys = currentSystemList[e.RowIndex];
            Brush brush;
            if (sys.Alive)
            {
                //e.Value = global::AutosysMonitor.Properties.Resources.Red_ball;
                brush = Brushes.Green;
            }
            else
            {
                brush = Brushes.Red;
            }




            using (
                    Brush gridBrush = new SolidBrush(this.SystemView.GridColor),
                    backColorBrush = new SolidBrush(e.CellStyle.BackColor))
            {
                if (sys.GetType() == typeof(LineSplitter))
                {
                    brush = backColorBrush;
                }
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
                    var diameter = Math.Min(e.CellBounds.Width, e.CellBounds.Height);
                    diameter -= 4;
                    horsMiddle -= (diameter / 2);
                    vertMiddle -= (diameter / 2);

                    Rectangle bounds = new Rectangle(horsMiddle, vertMiddle, diameter, diameter);

                    e.Graphics.FillEllipse(brush, bounds);

                    e.Handled = true;
                }
            }
        }

		private void ReloadFileButton_Click(object sender, EventArgs e)
		{
			var result = openSystemFileDialog.ShowDialog();
			currentSystemList.Clear();
			ReadSystemsFromFile(openSystemFileDialog.FileName);
			SystemView.Invalidate();
			SystemView.Update();
		}

		private void StatusForm_Resize(object sender, EventArgs e)
		{
			var width = this.Width;
			SystemView.Width = width - SystemView.Location.X- 25;
			SystemView.Height = Height - SystemView.Location.Y-50;
		}

		private void UpdateDataSource()
		{
			lock (currentSystemList)
			{
				systemerDataSource.Clear();
				foreach (var item in currentSystemList)
				{
					systemerDataSource.Add(item);
				}
			}

		}

		private void updateAll()
		{
			List<IAutosysSystem> tempList = new List<IAutosysSystem>(currentSystemList);


			foreach (IAutosysSystem item in tempList)
			{
				item.Update();
			}

			lock (currentSystemList)
			{
				currentSystemList.Clear();
				foreach (var item in tempList)
				{
					currentSystemList.Add(item);
				}
			}


		}

		private void txtSetRefreshtime_TextChanged(object sender, EventArgs e)
		{
			try
			{
				int time = int.Parse(txtSetRefreshtime.Text);
				Refreshtimer.Interval = time;
			}
			catch (Exception)
			{

			}

		}

		private void ckbRefreshEnabled_CheckedChanged(object sender, EventArgs e)
		{
			if (ckbRefreshEnabled.Checked)
			{
				Refreshtimer.Enabled = true;
				txtSetRefreshtime.Enabled = true;
			}
			else
			{
				Refreshtimer.Enabled = false;
				txtSetRefreshtime.Enabled = false;
			}
		}

        private void systemerDataSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void SystemView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }

            var filterString = txtFilter.Text;
            var filterStrings = filterString.Split(' ');
            var filteredList = masterSystemList.Select(n => n).ToList();
            foreach (var filter in filterStrings)
            {
                filteredList = filteredList.Where(s => s.Tags != null).Where(s => s.Tags.Contains(filter)).Select(s => s).ToList();


            }
            currentSystemList = filteredList;
            SystemView.Invalidate();
            SystemView.Update();
        }
	}



}

