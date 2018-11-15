namespace InfinityChess
{
    partial class AnalysisUc
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblEngine = new System.Windows.Forms.Label();
            this.lblMoveDepth = new System.Windows.Forms.Label();
            this.lblExpectedMove = new System.Windows.Forms.Label();
            this.lblRate = new System.Windows.Forms.Label();
            this.lblDepth = new System.Windows.Forms.Label();
            this.lblPoints = new System.Windows.Forms.Label();
            this.pbEngineScore = new System.Windows.Forms.PictureBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolTipController = new System.Windows.Forms.ToolTip(this.components);
            this.lvNotations = new System.Windows.Forms.ListView();
            this.Notations = new System.Windows.Forms.ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)(this.pbEngineScore)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEngine
            // 
            this.lblEngine.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblEngine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEngine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.lblEngine.ForeColor = System.Drawing.Color.Black;
            this.lblEngine.Location = new System.Drawing.Point(6, 6);
            this.lblEngine.Name = "lblEngine";
            this.lblEngine.Size = new System.Drawing.Size(165, 21);
            this.lblEngine.TabIndex = 17;
            this.lblEngine.Text = "Toga 1.114 Beta sec";
            this.lblEngine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEngine.Click += new System.EventHandler(this.lblEngine_Click);
            // 
            // lblMoveDepth
            // 
            this.lblMoveDepth.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblMoveDepth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMoveDepth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblMoveDepth.ForeColor = System.Drawing.Color.Black;
            this.lblMoveDepth.Location = new System.Drawing.Point(177, 6);
            this.lblMoveDepth.Name = "lblMoveDepth";
            this.lblMoveDepth.Size = new System.Drawing.Size(131, 21);
            this.lblMoveDepth.TabIndex = 16;
            this.lblMoveDepth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExpectedMove
            // 
            this.lblExpectedMove.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblExpectedMove.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblExpectedMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblExpectedMove.ForeColor = System.Drawing.Color.Black;
            this.lblExpectedMove.Location = new System.Drawing.Point(293, 32);
            this.lblExpectedMove.Name = "lblExpectedMove";
            this.lblExpectedMove.Size = new System.Drawing.Size(78, 22);
            this.lblExpectedMove.TabIndex = 15;
            this.lblExpectedMove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRate
            // 
            this.lblRate.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblRate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblRate.ForeColor = System.Drawing.Color.Black;
            this.lblRate.Location = new System.Drawing.Point(214, 32);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(73, 22);
            this.lblRate.TabIndex = 14;
            this.lblRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDepth
            // 
            this.lblDepth.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblDepth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDepth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblDepth.ForeColor = System.Drawing.Color.Black;
            this.lblDepth.Location = new System.Drawing.Point(116, 33);
            this.lblDepth.Name = "lblDepth";
            this.lblDepth.Size = new System.Drawing.Size(92, 22);
            this.lblDepth.TabIndex = 13;
            this.lblDepth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPoints
            // 
            this.lblPoints.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblPoints.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoints.ForeColor = System.Drawing.Color.Black;
            this.lblPoints.Location = new System.Drawing.Point(22, 33);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(88, 22);
            this.lblPoints.TabIndex = 3;
            this.lblPoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbEngineScore
            // 
            this.pbEngineScore.BackColor = System.Drawing.SystemColors.Control;
            this.pbEngineScore.Image = global::InfinityChess.Properties.Resources.orange;
            this.pbEngineScore.Location = new System.Drawing.Point(3, 32);
            this.pbEngineScore.Name = "pbEngineScore";
            this.pbEngineScore.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.pbEngineScore.Size = new System.Drawing.Size(16, 23);
            this.pbEngineScore.TabIndex = 12;
            this.pbEngineScore.TabStop = false;
            // 
            // btnGo
            // 
            this.btnGo.BackColor = System.Drawing.SystemColors.Control;
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGo.Location = new System.Drawing.Point(332, 3);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(39, 24);
            this.btnGo.TabIndex = 3;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = false;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblEngine);
            this.panel1.Controls.Add(this.lblExpectedMove);
            this.panel1.Controls.Add(this.lblPoints);
            this.panel1.Controls.Add(this.lblMoveDepth);
            this.panel1.Controls.Add(this.lblRate);
            this.panel1.Controls.Add(this.btnGo);
            this.panel1.Controls.Add(this.lblDepth);
            this.panel1.Controls.Add(this.pbEngineScore);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(426, 60);
            this.panel1.TabIndex = 18;
            // 
            // toolTipController
            // 
            this.toolTipController.AutoPopDelay = 5000;
            this.toolTipController.InitialDelay = 1000;
            this.toolTipController.ReshowDelay = 500;
            // 
            // lvNotations
            // 
            this.lvNotations.BackColor = System.Drawing.SystemColors.Control;
            this.lvNotations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Notations});
            this.lvNotations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvNotations.FullRowSelect = true;
            this.lvNotations.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvNotations.Location = new System.Drawing.Point(0, 60);
            this.lvNotations.MultiSelect = false;
            this.lvNotations.Name = "lvNotations";
            this.lvNotations.Size = new System.Drawing.Size(426, 101);
            this.lvNotations.TabIndex = 20;
            this.lvNotations.UseCompatibleStateImageBehavior = false;
            this.lvNotations.View = System.Windows.Forms.View.Details;
            this.lvNotations.SelectedIndexChanged += new System.EventHandler(this.lvNotations_SelectedIndexChanged);
            // 
            // Notations
            // 
            this.Notations.Width = 900;
            // 
            // AnalysisUc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 161);
            this.Controls.Add(this.lvNotations);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AnalysisUc";
            this.Load += new System.EventHandler(this.AnalysisUc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbEngineScore)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblEngine;
        private System.Windows.Forms.Label lblMoveDepth;
        private System.Windows.Forms.Label lblExpectedMove;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.Label lblDepth;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.PictureBox pbEngineScore;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTipController;
        private System.Windows.Forms.ListView lvNotations;
        private System.Windows.Forms.ColumnHeader Notations;

    }
}
