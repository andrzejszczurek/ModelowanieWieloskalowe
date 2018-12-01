namespace TheGameOfLive
{
   partial class GameForm
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
         this.panelPopulation = new System.Windows.Forms.Panel();
         this.btnNextStep = new System.Windows.Forms.Button();
         this.btnStartStop = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // panelPopulation
         // 
         this.panelPopulation.BackColor = System.Drawing.SystemColors.ButtonFace;
         this.panelPopulation.Location = new System.Drawing.Point(217, 12);
         this.panelPopulation.Name = "panelPopulation";
         this.panelPopulation.Size = new System.Drawing.Size(450, 450);
         this.panelPopulation.TabIndex = 0;
         // 
         // btnNextStep
         // 
         this.btnNextStep.Location = new System.Drawing.Point(24, 86);
         this.btnNextStep.Name = "btnNextStep";
         this.btnNextStep.Size = new System.Drawing.Size(175, 44);
         this.btnNextStep.TabIndex = 1;
         this.btnNextStep.Text = "Next Step";
         this.btnNextStep.UseVisualStyleBackColor = true;
         this.btnNextStep.Click += new System.EventHandler(this.ButtonNextStepClicked);
         // 
         // btnStartStop
         // 
         this.btnStartStop.BackColor = System.Drawing.Color.LawnGreen;
         this.btnStartStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.btnStartStop.Location = new System.Drawing.Point(24, 12);
         this.btnStartStop.Name = "btnStartStop";
         this.btnStartStop.Size = new System.Drawing.Size(175, 52);
         this.btnStartStop.TabIndex = 3;
         this.btnStartStop.Text = "START";
         this.btnStartStop.UseVisualStyleBackColor = false;
         this.btnStartStop.Click += new System.EventHandler(this.StartButtonClicked);
         // 
         // GameForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
         this.ClientSize = new System.Drawing.Size(679, 471);
         this.Controls.Add(this.btnStartStop);
         this.Controls.Add(this.btnNextStep);
         this.Controls.Add(this.panelPopulation);
         this.Name = "GameForm";
         this.Text = "Game of Live";
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel panelPopulation;
      private System.Windows.Forms.Button btnNextStep;
      private System.Windows.Forms.Button btnStartStop;
   }
}

