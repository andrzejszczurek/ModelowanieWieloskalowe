namespace NaiwnyRozrostZiaren
{
   partial class SimulationForm
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
         this.btnNextStep = new System.Windows.Forms.Button();
         this.btnStartStop = new System.Windows.Forms.Button();
         this.pictureBox = new System.Windows.Forms.PictureBox();
         this.btnReset = new System.Windows.Forms.Button();
         this.btnRandom = new System.Windows.Forms.Button();
         this.cbBoundary = new System.Windows.Forms.ComboBox();
         this.cbNeihborhood = new System.Windows.Forms.ComboBox();
         this.lblBoundaryType = new System.Windows.Forms.Label();
         this.lblneighborhood = new System.Windows.Forms.Label();
         this.btnPostprocessing = new System.Windows.Forms.Button();
         this.lblOffset = new System.Windows.Forms.Label();
         this.numOffset = new System.Windows.Forms.NumericUpDown();
         this.lblGrainCount = new System.Windows.Forms.Label();
         this.numGrainCount = new System.Windows.Forms.NumericUpDown();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.numOffset)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.numGrainCount)).BeginInit();
         this.SuspendLayout();
         // 
         // btnNextStep
         // 
         this.btnNextStep.Location = new System.Drawing.Point(24, 70);
         this.btnNextStep.Name = "btnNextStep";
         this.btnNextStep.Size = new System.Drawing.Size(170, 44);
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
         this.btnStartStop.Size = new System.Drawing.Size(170, 52);
         this.btnStartStop.TabIndex = 3;
         this.btnStartStop.Text = "START";
         this.btnStartStop.UseVisualStyleBackColor = false;
         this.btnStartStop.Click += new System.EventHandler(this.StartButtonClicked);
         // 
         // pictureBox
         // 
         this.pictureBox.Location = new System.Drawing.Point(205, 14);
         this.pictureBox.Name = "pictureBox";
         this.pictureBox.Size = new System.Drawing.Size(462, 445);
         this.pictureBox.TabIndex = 6;
         this.pictureBox.TabStop = false;
         this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxOnMouseClicked);
         // 
         // btnReset
         // 
         this.btnReset.Location = new System.Drawing.Point(24, 170);
         this.btnReset.Name = "btnReset";
         this.btnReset.Size = new System.Drawing.Size(170, 45);
         this.btnReset.TabIndex = 8;
         this.btnReset.Text = "Reset";
         this.btnReset.UseVisualStyleBackColor = true;
         this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
         // 
         // btnRandom
         // 
         this.btnRandom.Location = new System.Drawing.Point(24, 120);
         this.btnRandom.Name = "btnRandom";
         this.btnRandom.Size = new System.Drawing.Size(170, 44);
         this.btnRandom.TabIndex = 9;
         this.btnRandom.Text = "Losowe zarodki";
         this.btnRandom.UseVisualStyleBackColor = true;
         this.btnRandom.Click += new System.EventHandler(this.btnChaos_Click);
         // 
         // cbBoundary
         // 
         this.cbBoundary.FormattingEnabled = true;
         this.cbBoundary.Location = new System.Drawing.Point(24, 250);
         this.cbBoundary.Name = "cbBoundary";
         this.cbBoundary.Size = new System.Drawing.Size(121, 21);
         this.cbBoundary.TabIndex = 10;
         this.cbBoundary.SelectedIndexChanged += new System.EventHandler(this.cbBoundary_SelectedIndexChanged);
         // 
         // cbNeihborhood
         // 
         this.cbNeihborhood.FormattingEnabled = true;
         this.cbNeihborhood.Location = new System.Drawing.Point(24, 290);
         this.cbNeihborhood.Name = "cbNeihborhood";
         this.cbNeihborhood.Size = new System.Drawing.Size(121, 21);
         this.cbNeihborhood.TabIndex = 11;
         this.cbNeihborhood.SelectedIndexChanged += new System.EventHandler(this.cbNeihborhood_SelectedIndexChanged);
         // 
         // lblBoundaryType
         // 
         this.lblBoundaryType.AutoSize = true;
         this.lblBoundaryType.Location = new System.Drawing.Point(21, 234);
         this.lblBoundaryType.Name = "lblBoundaryType";
         this.lblBoundaryType.Size = new System.Drawing.Size(55, 13);
         this.lblBoundaryType.TabIndex = 12;
         this.lblBoundaryType.Text = "Boundary:";
         // 
         // lblneighborhood
         // 
         this.lblneighborhood.AutoSize = true;
         this.lblneighborhood.Location = new System.Drawing.Point(21, 274);
         this.lblneighborhood.Name = "lblneighborhood";
         this.lblneighborhood.Size = new System.Drawing.Size(74, 13);
         this.lblneighborhood.TabIndex = 13;
         this.lblneighborhood.Text = "Neithborhood:";
         // 
         // btnPostprocessing
         // 
         this.btnPostprocessing.Location = new System.Drawing.Point(24, 436);
         this.btnPostprocessing.Name = "btnPostprocessing";
         this.btnPostprocessing.Size = new System.Drawing.Size(170, 23);
         this.btnPostprocessing.TabIndex = 14;
         this.btnPostprocessing.Text = "Postprocessing";
         this.btnPostprocessing.UseVisualStyleBackColor = true;
         this.btnPostprocessing.Click += new System.EventHandler(this.btnPostprocessing_Click);
         // 
         // lblOffset
         // 
         this.lblOffset.AutoSize = true;
         this.lblOffset.Location = new System.Drawing.Point(21, 314);
         this.lblOffset.Name = "lblOffset";
         this.lblOffset.Size = new System.Drawing.Size(64, 13);
         this.lblOffset.TabIndex = 15;
         this.lblOffset.Text = "Grain offset:";
         // 
         // numOffset
         // 
         this.numOffset.Location = new System.Drawing.Point(24, 330);
         this.numOffset.Name = "numOffset";
         this.numOffset.Size = new System.Drawing.Size(120, 20);
         this.numOffset.TabIndex = 17;
         // 
         // lblGrainCount
         // 
         this.lblGrainCount.AutoSize = true;
         this.lblGrainCount.Location = new System.Drawing.Point(20, 353);
         this.lblGrainCount.Name = "lblGrainCount";
         this.lblGrainCount.Size = new System.Drawing.Size(65, 13);
         this.lblGrainCount.TabIndex = 18;
         this.lblGrainCount.Text = "Grain count:";
         // 
         // numGrainCount
         // 
         this.numGrainCount.Location = new System.Drawing.Point(24, 369);
         this.numGrainCount.Name = "numGrainCount";
         this.numGrainCount.Size = new System.Drawing.Size(120, 20);
         this.numGrainCount.TabIndex = 19;
         // 
         // SimulationForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
         this.ClientSize = new System.Drawing.Size(679, 471);
         this.Controls.Add(this.numGrainCount);
         this.Controls.Add(this.lblGrainCount);
         this.Controls.Add(this.numOffset);
         this.Controls.Add(this.lblOffset);
         this.Controls.Add(this.btnPostprocessing);
         this.Controls.Add(this.lblneighborhood);
         this.Controls.Add(this.lblBoundaryType);
         this.Controls.Add(this.cbNeihborhood);
         this.Controls.Add(this.cbBoundary);
         this.Controls.Add(this.btnRandom);
         this.Controls.Add(this.btnReset);
         this.Controls.Add(this.pictureBox);
         this.Controls.Add(this.btnStartStop);
         this.Controls.Add(this.btnNextStep);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Name = "SimulationForm";
         this.Text = "Naiwny rozrost ziarem";
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.numOffset)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.numGrainCount)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion
      private System.Windows.Forms.Button btnNextStep;
      private System.Windows.Forms.Button btnStartStop;
      private System.Windows.Forms.PictureBox pictureBox;
      private System.Windows.Forms.Button btnReset;
      private System.Windows.Forms.Button btnRandom;
      private System.Windows.Forms.ComboBox cbBoundary;
      private System.Windows.Forms.ComboBox cbNeihborhood;
      private System.Windows.Forms.Label lblBoundaryType;
      private System.Windows.Forms.Label lblneighborhood;
      private System.Windows.Forms.Button btnPostprocessing;
      private System.Windows.Forms.Label lblOffset;
      private System.Windows.Forms.NumericUpDown numOffset;
      private System.Windows.Forms.Label lblGrainCount;
      private System.Windows.Forms.NumericUpDown numGrainCount;
   }
}