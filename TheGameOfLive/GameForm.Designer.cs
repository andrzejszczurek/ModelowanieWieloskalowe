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
         this.btnNextStep = new System.Windows.Forms.Button();
         this.btnStartStop = new System.Windows.Forms.Button();
         this.cbShapes = new System.Windows.Forms.ComboBox();
         this.label1 = new System.Windows.Forms.Label();
         this.pictureBox = new System.Windows.Forms.PictureBox();
         this.pbShapeView = new System.Windows.Forms.PictureBox();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pbShapeView)).BeginInit();
         this.SuspendLayout();
         // 
         // btnNextStep
         // 
         this.btnNextStep.Location = new System.Drawing.Point(24, 86);
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
         // cbShapes
         // 
         this.cbShapes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cbShapes.FormattingEnabled = true;
         this.cbShapes.Location = new System.Drawing.Point(24, 162);
         this.cbShapes.Name = "cbShapes";
         this.cbShapes.Size = new System.Drawing.Size(170, 21);
         this.cbShapes.TabIndex = 4;
         this.cbShapes.SelectedIndexChanged += new System.EventHandler(this.ShapesSelectedIndexChanged);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(24, 143);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(43, 13);
         this.label1.TabIndex = 5;
         this.label1.Text = "Kształt:";
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
         // pbShapeView
         // 
         this.pbShapeView.Location = new System.Drawing.Point(24, 198);
         this.pbShapeView.Name = "pbShapeView";
         this.pbShapeView.Size = new System.Drawing.Size(170, 170);
         this.pbShapeView.TabIndex = 7;
         this.pbShapeView.TabStop = false;
         // 
         // GameForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
         this.ClientSize = new System.Drawing.Size(679, 471);
         this.Controls.Add(this.pbShapeView);
         this.Controls.Add(this.pictureBox);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.cbShapes);
         this.Controls.Add(this.btnStartStop);
         this.Controls.Add(this.btnNextStep);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Name = "GameForm";
         this.Text = "Game of Live";
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pbShapeView)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion
      private System.Windows.Forms.Button btnNextStep;
      private System.Windows.Forms.Button btnStartStop;
      private System.Windows.Forms.ComboBox cbShapes;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.PictureBox pictureBox;
      private System.Windows.Forms.PictureBox pbShapeView;
   }
}

