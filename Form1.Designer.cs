namespace tictactoe;

partial class GameForm
{
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

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(col * 200, row * 150);
        this.Text = "TicTacToe";
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
    }

    private void CreateGridButtons()
    {
        int buttonWidth = this.Size.Width / col - 10;
        int buttonHeight = this.Size.Height / row - 20;

        for (int r = 0; r < row; r++)
        {
            for (int c = 0; c < col; c++)
            {
                Button current = board.GetButton(r, c);
                current.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
                current.Location = new System.Drawing.Point(c * buttonWidth, r * buttonHeight);
                this.Controls.Add(current);
            }
        }
    }

    #endregion
}
