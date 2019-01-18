using App.Impl.NaiwyRozrostZiaren;
using App.Impl.NaiwyRozrostZiaren.Enum;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NaiwnyRozrostZiaren
{
   public partial class SimulationForm : Form
   {
      private BackgroundWorker worker;

      private readonly SimulationCreator m_creator;

      private bool m_isGameActive;

      private int m_cellSize;

      public SimulationForm()
      {
         InitializeComponent();
         pictureBox.BackColor = Color.White;
         m_cellSize = 2;
         m_isGameActive = false;
         btnPostprocessing.Enabled = false;
         worker = new BackgroundWorker();
         m_creator = new SimulationCreator(pictureBox.Height, pictureBox.Width, m_cellSize);
         pictureBox.BackgroundImage = m_creator.PopulationGridToBitmap();
         cbBoundary.DataSource = SimulationCreator.GetSupportedBoundaries();
         cbNeihborhood.DataSource = SimulationCreator.GetSupportedNeighborhoods();
         numGrainCount.Value = 10;
      }

      #region [Controls event section]

      private void StartButtonClicked(object sender, EventArgs e)
      {
         m_isGameActive = !m_isGameActive;

         if (m_isGameActive)
         {
            btnStartStop.BackColor = Color.IndianRed;
            btnStartStop.Text = "STOP";
            cbBoundary.Enabled = false;
            cbNeihborhood.Enabled = false;
            if (!m_creator.IsAnyFreeSpace())
            {
               btnPostprocessing.Enabled = true;
            }
            worker.DoWork += Work;
            worker.RunWorkerAsync();
         }
         else
         {
            cbBoundary.Enabled = true;
            cbNeihborhood.Enabled = true;
            btnStartStop.BackColor = Color.LawnGreen;
            btnPostprocessing.Enabled = false;
            btnStartStop.Text = "START";
         }
      }

      private void cbBoundary_SelectedIndexChanged(object sender, EventArgs e)
      {
         var type = (BoundaryCondition)Enum.Parse(typeof(BoundaryCondition), cbBoundary.Text);
         m_creator.SetBoundary(type);
      }

      private void cbNeihborhood_SelectedIndexChanged(object sender, EventArgs e)
      {
         var type = (Neighborhood)Enum.Parse(typeof(Neighborhood), cbNeihborhood.Text);
         m_creator.SetNeighborhood(type);
      }

      private void btnPostprocessing_Click(object sender, EventArgs e)
      {
         var postprocessing = new Postprocessing(m_creator.CurrentState, m_cellSize);
         var grains = m_creator.GetGrains();
         postprocessing.CalculateAverageGrainSurface(grains);
         postprocessing.CalculateBoudaryLength(grains, m_creator.GetBoundary());
         new PostprocessingForm(grains).ShowDialog();
      }

      private void ButtonNextStepClicked(object sender, EventArgs e)
      {
         UpdateUIPanel(m_creator.PopulationGridToBitmapForNextStep());
      }

      private void PictureBoxOnMouseClicked(object sender, MouseEventArgs e)
      {
         if (m_creator.IsAnyFreeSpace())
            UpdateUIPanel(m_creator.PutPoint(e.X / m_cellSize , e.Y / m_cellSize));
      }

      private void btnReset_Click(object sender, EventArgs e)
      {
         m_creator.ResetGrid();
         UpdateUIPanel(m_creator.PopulationGridToBitmapForNextStep());
         btnNextStep.Enabled = true;
         btnStartStop.Enabled = true;
         btnRandom.Enabled = true;
         btnStartStop.BackColor = Color.LawnGreen;
         btnStartStop.Text = "START";
         m_isGameActive = false;
         cbBoundary.Enabled = true;
         cbNeihborhood.Enabled = true;
         btnPostprocessing.Enabled = false;
      }

      private void btnChaos_Click(object sender, EventArgs e)
      {
         UpdateUIPanel(m_creator.GenerateRandomStartGrains((int)numGrainCount.Value), (int)numOffset.Value);
      }

      #endregion [Controls event section]

      private void Work(object sender, DoWorkEventArgs e)
      {
         while (m_isGameActive)
         {
            Invoke((Action)(() => UpdateUIPanel(m_creator.PopulationGridToBitmapForNextStep())));
            if (!m_creator.IsAnyFreeSpace())
               m_isGameActive = false;
         }
      }

      private void UpdateUIPanel(Bitmap bmp)
      {
         pictureBox.BackgroundImage = bmp;
         pictureBox.Refresh();

         if (!m_creator.IsAnyFreeSpace())
         {
            btnNextStep.Enabled = false;
            btnStartStop.Enabled = false;
            btnRandom.Enabled = false;
            btnPostprocessing.Enabled = true;
         }
      }
   }
}
