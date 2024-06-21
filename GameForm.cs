namespace tictactoe;

public partial class GameForm : Form
{
    private ButtonBoard board;
    private int row;
    private int col;
    private int winRule;
    const int MenuHeight = 30;
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    // Dispose(disposing): System Generated Function
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    // GameForm(): Instantiates the GameForm object
    public GameForm()
    {
        board = new ButtonBoard();
        Tuple<int, int, int> boardInfo = board.GetBoardInfo();
        row = boardInfo.Item1;
        col = boardInfo.Item2;
        winRule = boardInfo.Item3;
        InitializeComponent();
        CreateGridButtons();
        InitializeMenu();
    }

    // InitializeComponent(): Set basic features of the form
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(col * 200, row * 150 + MenuHeight);
        this.Text = "TicTacToe";
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
    }

    // CreateGridButtons(): Initialize the board with buttons
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

    // InitializeMenu(): Initialize the menu bar at top of form
    private void InitializeMenu()
    {
        // Create a MenuStrip
        MenuStrip menuStrip = new MenuStrip();

        // Create menu items
        ToolStripMenuItem changeSizeItem = new ToolStripMenuItem("Change Size");
        ToolStripMenuItem restartItem = new ToolStripMenuItem("Restart");
        ToolStripMenuItem exitItem = new ToolStripMenuItem("Exit");
        
        changeSizeItem.Click +=  ChangeSizeItemClick;
        exitItem.Click += ExitItemClick;
        restartItem.Click += RestartItemClick;

        // Add menus to the MenuStrip
        menuStrip.Items.Add(changeSizeItem);
        menuStrip.Items.Add(restartItem);
        menuStrip.Items.Add(exitItem);

        // Add the MenuStrip to the form
        this.MainMenuStrip = menuStrip;
        this.Controls.Add(menuStrip);
    }

    // ChangeSizeItemClick(sender, e): Actions when Change Size button is clicked
    private void ChangeSizeItemClick(object sender, EventArgs e)
    {
        ResizeForm dialog = new ResizeForm(this);
        dialog.ShowDialog(this);
    }

    // RestartItemClick(sender, e): Actions when Restart button is clicked
    private void RestartItemClick(object sender, EventArgs e)
    {
        board.RefreshBoard();
    }

    // ExitItemClick(sender, e): Actions when Exit button is clicked
    private void ExitItemClick(object sender, EventArgs e)
    {
        this.Close();
    }

    // RecreateBoard(row, col, winRule): Regenerate the board with row, col, winRule (if they are integers)
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
}
