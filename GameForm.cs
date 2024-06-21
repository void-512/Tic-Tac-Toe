namespace tictactoe;

public partial class GameForm : Form
{
    private ButtonBoard board;
    private int row;
    private int col;

    const int MenuHeight = 30;

    public GameForm()
    {
        board = new ButtonBoard();
        Tuple<int, int> size = board.GetSize();
        row = size.Item1;
        col = size.Item2;
        InitializeComponent();
        CreateGridButtons();
        InitializeMenu();
    }
}
