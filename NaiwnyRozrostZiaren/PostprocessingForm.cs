using App.Impl.NaiwyRozrostZiaren;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NaiwnyRozrostZiaren
{
   public partial class PostprocessingForm : Form
   {
      private int panelCounter;

      public PostprocessingForm(IEnumerable<GrainElement> grains)
      {
         InitializeComponent();
         panelCounter = 0;

         foreach (var grain in grains)
         {
            GenerateInfoPanel(grain);
         }
      }

      private void GenerateInfoPanel(GrainElement grain)
      {
         var offset = 30 * ++panelCounter;
         var panel = new Panel();
         panel.Height = 15;
         panel.Width = 20;
         panel.Location = new Point(10, offset);
         panel.BackColor = grain.Color;

         var label = new Label();
         label.Location = new Point(30, offset);
         label.Text = $"Powierzchnia: {grain.AverageSurface} j, Długość: {grain.BoundaryLength} j";
         label.Width = 300;

         Controls.Add(panel);
         Controls.Add(label);
      }

   }
}
