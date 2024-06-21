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
        this.ClientSize = new System.Drawing.Size(col * 200, row * 150 + MenuHeight);
        this.Text = "TicTacToe";
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
    }

    private void CreateGridButtons()
    {
        int buttonWidth = this.Size.Width / col - 10;
        int buttonHeight = (this.Size.Height - MenuHeight) / row - 20;

        for (int r = 0; r < row; r++)
        {
            for (int c = 0; c < col; c++)
            {
                Button current = board.GetButton(r, c);
                current.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
                current.Location = new System.Drawing.Point(c * buttonWidth, r * buttonHeight + MenuHeight);
                this.Controls.Add(current);
            }
        }
    }

    private void InitializeMenu()
    {
        // Create a MenuStrip
        MenuStrip menuStrip = new MenuStrip();

        // Create top-level menu items
        ToolStripMenuItem changeSizeItem = new ToolStripMenuItem("Change Size");
        ToolStripMenuItem restartItem = new ToolStripMenuItem("Restart");
        ToolStripMenuItem exitItem = new ToolStripMenuItem("Exit");
        
        changeSizeItem.Click +=  ChangeSizeItemClick;
        exitItem.Click += ExitItemClick;
        restartItem.Click += RestartItemClick;

        // Add top-level menus to the MenuStrip
        menuStrip.Items.Add(changeSizeItem);
        menuStrip.Items.Add(restartItem);
        menuStrip.Items.Add(exitItem);

        // Add the MenuStrip to the form
        this.MainMenuStrip = menuStrip;
        this.Controls.Add(menuStrip);
    }

    private void ChangeSizeItemClick(object sender, EventArgs e)
    {
        ResizeForm dialog = new ResizeForm(this);
        dialog.ShowDialog(this);
    }

    private void RestartItemClick(object sender, EventArgs e)
    {
        board.RefreshBoard();
    }

    private void ExitItemClick(object sender, EventArgs e)
    {
        this.Close();
    }

    public void RecreateBoard(string row, string col, string winRule)
    {
        for (int i = this.Controls.Count - 1; i >= 0; i--)
        {
            Control control = this.Controls[i];
            this.Controls.RemoveAt(i);
            control.Dispose();
        }
        int.TryParse(row, out this.row);
        int.TryParse(col, out this.col);
        int.TryParse(winRule, out this.winRule);
        board = new ButtonBoard(this.row, this.col, this.winRule);
        InitializeComponent();
        CreateGridButtons();
        InitializeMenu();
    }
    
    #endregion
}
