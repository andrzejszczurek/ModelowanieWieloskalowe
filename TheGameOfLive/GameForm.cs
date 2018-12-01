using App.Impl.GameOfLive;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TheGameOfLive
{
   public partial class GameForm : Form
   {
      private BackgroundWorker worker;

      private readonly GameCreator m_gameCreator;

      private bool m_isGameActive;

      private int m_operationCounter = 0;

      public GameForm()
      {
         InitializeComponent();
         m_gameCreator = new GameCreator(10, new Size(panelPopulation.Width, panelPopulation.Height));
         m_isGameActive = false;
         worker = new BackgroundWorker();
      }

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
         panelPopulation.Refresh();
         UpdateUIPanel(m_gameCreator.PopulationGridToBitmap());
      }

      private void Work(object sender, DoWorkEventArgs e)
      {
         if (m_operationCounter == 0)
            m_gameCreator.Population =
               m_gameCreator.StructuresFactory.PutStructure(m_gameCreator.Population, new Seed(3, 3), Shape.Glider);

         while (m_isGameActive)
         {
            Invoke((Action)(() => UpdateUIPanel(m_gameCreator.PopulationGridToBitmap())));
            m_operationCounter++;
            Thread.Sleep(80);
         }
      }

      private void UpdateUIPanel(Bitmap bmp)
      {
         panelPopulation.BackgroundImage = bmp;
      }
   }
}
