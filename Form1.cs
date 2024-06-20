namespace tictactoe;

public partial class Form1 : Form
{
    private ButtonBoard board;
    private int boardRow;
    private int boardCol;
    public Form1()
    {
        InitializeComponent();
        board = new ButtonBoard();
        Tuple<int, int> size = board.GetSize();
        boardRow = size.Item1;
        boardCol = size.Item2;
        
        CreateGridButtons();
    }
}
