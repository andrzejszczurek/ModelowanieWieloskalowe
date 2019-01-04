using App.Impl.GameOfLive;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;

namespace TheGameOfLive
{
   public partial class GameForm : Form
   {
      private BackgroundWorker worker;

      private readonly GameCreator m_gameCreator;

      private bool m_isGameActive;

      private int m_operationCounter = 0;

      private Size m_shapePreviewSize;

      private int m_cellSize = 10;

      private int m_shapePreviewCellSize = 10;

      public GameForm()
      {
         InitializeComponent();
         m_gameCreator = new GameCreator(m_cellSize, new Size(pictureBox.Width, pictureBox.Height));
         m_isGameActive = false;
         m_shapePreviewSize = new Size(pbShapeView.Width, pbShapeView.Height);
         worker = new BackgroundWorker();
         cbShapes.DataSource = Enum.GetValues(typeof(Shape));
         pictureBox.BackColor = Color.White;
         pictureBox.BackgroundImage = m_gameCreator.PopulationGridToBitmap();

         pbShapeView.BackColor = Color.White;
         pbShapeView.BackgroundImage = m_gameCreator.GetCustomPopulationGrid(m_shapePreviewSize, m_shapePreviewCellSize, Shape.Point);
      }

      #region [Controls event section]

      private void StartButtonClicked(object sender, EventArgs e)
      {
         m_isGameActive = !m_isGameActive;

         if (m_isGameActive)
         {
            btnStartStop.BackColor = Color.IndianRed;
            btnStartStop.Text = "STOP";
            worker.DoWork += Work;
            worker.RunWorkerAsync();
         }
         else
         {
            btnStartStop.BackColor = Color.LawnGreen;
            btnStartStop.Text = "START";
         }
      }

      private void ButtonNextStepClicked(object sender, EventArgs e)
      {
         UpdateUIPanel(m_gameCreator.PopulationGridToBitmapForNextStep());
      }

      private void PictureBoxOnMouseClicked(object sender, MouseEventArgs e)
      {
         // póki co dodawać kształty można tylko przy zatrzymanej grze
         //if (m_isGameActive)
         //   return;
         UpdateUIPanel(m_gameCreator.PutSelectedShape(e.X, e.Y));
      }

      private void ShapesSelectedIndexChanged(object sender, EventArgs e)
      {
         var shape = (Shape)Enum.Parse(typeof(Shape), cbShapes.Text);
         m_gameCreator.CurrentShape = shape;
         pbShapeView.BackgroundImage = m_gameCreator.GetCustomPopulationGrid(m_shapePreviewSize, m_shapePreviewCellSize, shape);
         pbShapeView.Refresh();
      }

      #endregion [Controls event section]

      private void Work(object sender, DoWorkEventArgs e)
      {
         while (m_isGameActive)
         {
            Invoke((Action)(() => UpdateUIPanel(m_gameCreator.PopulationGridToBitmapForNextStep())));
            m_operationCounter++;
            Thread.Sleep(100);
         }
      }

      private void UpdateUIPanel(Bitmap bmp)
      {
         pictureBox.BackgroundImage = bmp;
         pictureBox.Refresh();
      }

      private void btnReset_Click(object sender, EventArgs e)
      {
         m_gameCreator.ResetGrid();
      }

      private void btnChaos_Click(object sender, EventArgs e)
      {
         m_gameCreator.GenerateRandomPopulation();
         UpdateUIPanel(m_gameCreator.PopulationGridToBitmapForNextStep());
      }
   }
}
