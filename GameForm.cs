namespace tictactoe;

public partial class GameForm : Form
{
    private ButtonBoard board;
    private int row;
    private int col;
    private int winRule;
    const int MenuHeight = 30;

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
}
