namespace InfinityChess
{
    partial class ShortCutForm
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
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(567, 452);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 1;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(651, 452);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCopy);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(738, 484);
            this.panel1.TabIndex = 3;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Alt+Backspace            \tUndo - Undo last change to game",
            "Ctrl+R                          \tResign - Resign this game - opponent wins",
            "Ctrl+Alt+2                  \tBoard 2D - Use a flat chess board",
            "Ctrl+Alt+C                  \tClock Window - Toggle the Chess Clock Window",
            "Ctrl+Alt+F                  \tFull Screen - Toggle full screen mode",
            "Ctrl+Alt+J                  \tTwo Computer Match - Start match against other compu" +
                "ter (LAN or RS232)",
            "Ctrl+Alt+N                  \tNotation - Toggle the notation pane",
            "Ctrl+Alt+O                  \tOptions - Set the main program options",
            "Ctrl+Alt+S                               Position Setup - Set up a position",
            "Ctrl+C                          \tCopy Game - Copy game notation to clipboard",
            "Ctrl+O                          \tOffer Draw - Offer draw to opponent",
            "Ctrl+E                          \tEngine Match - Start match between two engines",
            "Ctrl+F                          \tFlip Board - Rotate the chess board",
            "Ctrl+F10                      \tLoad Previous Game - Load previous game from datab" +
                "ase",
            "Ctrl+F11                      \tOpenings Book - Select opening book",
            "Ctrl+K                          \tAdd Kibitzer - Add a Kibitz engine pane to analy" +
                "se or assist in a game",
            "Ctrl+N                          \tNew Game - Start a new game",
            "Ctrl+P                          \tPrint Game - Print notation with embedded diagra" +
                "ms",
            "Ctrl+S                          \tSave - Save a new version of this game to the da" +
                "tabase",
            "Ctrl+Space                            \tMove Now - Force Engine to move now",
            "Ctrl+T                          \tLong game - Set a time control for a long tourna" +
                "ment game",
            "Ctrl+V                          \tPaste Game - Paste game (ASCII) from clipboard",
            "Ctrl+Z                          \tBlitz Game - Set a blitz time control",
            "F1                                  \tHelp - Open table of contents of help system" +
                "",
            "F10                                \tLoad Next Game - Load next game from database" +
                "",
            "F12                                \tDatabase - Open game database",
            "F2                                  \tEdit Game Data - Set player names, tournamen" +
                "t, result, etc. for this game",
            "F3                                  \tChange Main Engine - Change the main playing" +
                " or first analysis engine???",
            "F4                                  \tBook Options - Set the learning behaviour of" +
                " the opening book",
            "Shift+Ctrl+Alt+F11  \t\tOpenings book - Create new opening book",
            "Shift+Ctrl+Alt+O    \t\tBoard Design - Change board design and style  ",
            "Shift+Ctrl+K              \tRemove Kibitzer - Remove the last Kibitz engine pane",
            "Shift+Ctrl+M              \tSwitch off engine - Engine doesn\'t start thinking with" +
                " new moves",
            "Shift+Ctrl+O              \tTournament - Open engine tournament",
            "Shift+Ctrl+R              \tRated Game - New rated game",
            "Shift+F                        \tFriend mode - New game against friendly adapting " +
                "opponent"});
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(738, 446);
            this.listBox1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(738, 484);
            this.panel2.TabIndex = 3;
            // 
            // ShortCutForm
            // 
            this.AcceptButton = this.btnCopy;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(738, 484);
            this.Controls.Add(this.panel2);
            this.Name = "ShortCutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shortcuts";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox listBox1;
    }
}