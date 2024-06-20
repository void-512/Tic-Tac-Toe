namespace tictactoe;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    /// 
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 600);
        this.Text = "TicTacToe";
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
    }

    private void CreateGridButtons()
        {
            int buttonWidth = this.Size.Width / 3 - 9;
            int buttonHeight = this.Size.Height / 3 - 20;
            int padding = 0;
            int startX = 0;
            int startY = 0;

            for (int row = 0; row < 3; row++)
                for (int col = 0; col < 3; col++)
                {
                    Button current = board.GetButton(row, col);
                    current.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
                    current.Location = new System.Drawing.Point(startX + col * (buttonWidth + padding), startY + row * (buttonHeight + padding));
                    this.Controls.Add(current);
                }
        }

    #endregion
}
