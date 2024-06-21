namespace tictactoe;

public class ButtonBoard
{
    private bool roundPlayer;
    private const int DefaultRow = 3;
    private const int DefaultCol = 3;
    private const int DefaultWinRule = 3;
    private int row;
    private int col;
    private int winRule;
    private Button[, ] board;
    public delegate bool CheckWinDelegate(Button button, char currentPlayer);
    public event CheckWinDelegate CheckWinEvent;

    // GetBoardInfo(): returns the row, col, and winRule of the game
    public Tuple<int, int, int> GetBoardInfo()
    {
        return new Tuple<int, int, int>(row, col, winRule);
    }

    // GetButton(r, c): returns the button at (r, c) on the board
    public Button GetButton(int r, int c)
    {
        return board[r, c];
    }

    // GetLocation(button): returns location (r, c) of the button on the board
    private Tuple<int, int> GetLocation(Button button)
    {
        int row = ((Tuple<int, int, char>)button.Tag).Item1;
        int col = ((Tuple<int, int, char>)button.Tag).Item2;
        return new Tuple<int, int>(row, col);
    }

    // GetPlayer(button): returns the player that occupies the button
    private char GetPlayer(Button button)
    {
        return ((Tuple<int, int, char>)button.Tag).Item3;
    }
    
    // ButtonBoard(): Instantiates the ButtonBoard object
    public ButtonBoard()
    {
        row = DefaultRow;
        col = DefaultCol;
        winRule = DefaultWinRule;
        board = new Button[row, col];
        for (int r = 0; r < row; r++)
        {
            for (int c = 0; c < col; c++)
            {
                board[r, c] = new Button();
                board[r, c].Tag = new Tuple<int, int, char>(r, c, '\0');
                board[r, c].Click += ButtonClick;
            }
        }
        CheckWinEvent += CheckHorizontalWin;
        CheckWinEvent += CheckVerticalWin;
        CheckWinEvent += CheckDiagonal1Win;
        CheckWinEvent += CheckDiagonal2Win;
    }

    // ButtonBoard(row, col, winRule): Instantiates the ButtonBoard object with given parameters
    public ButtonBoard(int row, int col, int winRule)
    {
        this.row = row;
        this.col = col;
        this.winRule = winRule;
        board = new Button[row, col];
        for (int r = 0; r < row; r++)
        {
            for (int c = 0; c < col; c++)
            {
                board[r, c] = new Button();
                board[r, c].Tag = new Tuple<int, int, char>(r, c, '\0');
                board[r, c].Click += ButtonClick;
            }
        }
        CheckWinEvent += CheckHorizontalWin;
        CheckWinEvent += CheckVerticalWin;
        CheckWinEvent += CheckDiagonal1Win;
        CheckWinEvent += CheckDiagonal2Win;
    }

    // SetButtonPlayer(current, player): Set the current button occupied by player
    private void SetButtonPlayer(Button current, char player)
    {
        Tuple<int, int> location = GetLocation(current);
        current.Tag = new Tuple<int, int, char>(location.Item1, location.Item2, player);
    }

    // isWin(current): Justifies whether the player of current button wins
    private bool isWin(Button current)
    {
        char currentPlayer = GetPlayer(current);
        bool result = false;
        if (CheckWinEvent is not null)
        {
            foreach (CheckWinDelegate checkWinFunc in CheckWinEvent.GetInvocationList())
            {
                result = result || checkWinFunc(current, currentPlayer);
            }
        }
        return result;
    }

    // ButtonClick(sender, e): Actions when current button is clicked
    private void ButtonClick(object sender, EventArgs e)
    {
        Button? button = sender as Button;
        char player = GetPlayer(button);
        if (player != '\0') return;
        if (roundPlayer == true)
        {
            button.Text ="X";
            SetButtonPlayer(button, 'X');
            roundPlayer = false;
        }
        else 
        {
            button.Text= "O";
            SetButtonPlayer(button, 'O');
            roundPlayer = true;
        }
        if (isWin(button))
        {
            MessageBox.Show($"Player {GetPlayer(button)} wins the round!");
            RefreshBoard();
        }
        else if (isDraw())
        {
            MessageBox.Show("It's a draw!");
            RefreshBoard();
        }
        else return;
    }
    
    // RefreshBoard(): Emptyies the game board
    public void RefreshBoard()
    {
        for (int r = 0; r < row; r++)
        {
            for (int c = 0; c < col; c++)
            {
                Button current = GetButton(r, c);
                SetButtonPlayer(current, '\0');
                current.Text = "";
            }
        }   
    }

    // CheckHorizontalWin(button, currentPlayer): Check if the player wins under horizontal direction
    private bool CheckHorizontalWin(Button button, char currentPlayer)
    {
        int count = 1;
        Tuple<int, int> buttonLocation = GetLocation(button);
        int currentRow = buttonLocation.Item1;
        int currentCol = buttonLocation.Item2;
        while (true)
        {
            if (currentCol == 0)
                break;
            currentCol--;
            if (GetPlayer(GetButton(currentRow, currentCol)) == currentPlayer)
                count++;
            else 
                break;
            if (count == winRule)
                return true;
        }
        currentRow = buttonLocation.Item1;
        currentCol = buttonLocation.Item2;
        while (true)
        {
            if (currentCol == col - 1)
                break;
            currentCol++;
            if (GetPlayer(GetButton(currentRow, currentCol)) == currentPlayer)
                count++;
            else 
                break;
            if (count == winRule)
                return true;
        }
        return false;
    }

    // CheckVerticalWin(button, currentPlayer): Check if the player wins under vertical direction
    private bool CheckVerticalWin(Button button, char currentPlayer)
    {
        int count = 1;
        Tuple<int, int> buttonLocation = GetLocation(button);
        int currentRow = buttonLocation.Item1;
        int currentCol = buttonLocation.Item2;
        while (true)
        {
            if (currentRow == 0)
                break;
            currentRow--;
            if (GetPlayer(GetButton(currentRow, currentCol)) == currentPlayer)
                count++;
            else 
                break;
            if (count == winRule)
                return true;
        }
        currentRow = buttonLocation.Item1;
        currentCol = buttonLocation.Item2;
        while (true)
        {
            if (currentRow == row - 1)
                break;
            currentRow++;
            if (GetPlayer(GetButton(currentRow, currentCol)) == currentPlayer)
                count++;
            else 
                break;
            if (count == winRule)
                return true;
        }
        return false;
    }

    // CheckDiagonal1Win(button, currentPlayer): Check if the player wins under main diagonal direction
    private bool CheckDiagonal1Win(Button button, char currentPlayer)
    {
        int count = 1;
        Tuple<int, int> buttonLocation = GetLocation(button);
        int currentRow = buttonLocation.Item1;
        int currentCol = buttonLocation.Item2;
        while (true)
        {
            if (currentRow == 0 || currentCol == 0)
                break;
            currentRow--;
            currentCol--;
            if (GetPlayer(GetButton(currentRow, currentCol)) == currentPlayer)
                count++;
            else 
                break;
            if (count == winRule)
                return true;
        }
        currentRow = buttonLocation.Item1;
        currentCol = buttonLocation.Item2;
        while (true)
        {
            if (currentRow == row - 1 || currentCol == col - 1)
                break;
            currentRow++;
            currentCol++;
            if (GetPlayer(GetButton(currentRow, currentCol)) == currentPlayer)
                count++;
            else 
                break;
            if (count == winRule)
                return true;
        }
        return false;
    }

    // CheckDiagonal2Win(button, currentPlayer): Check if the player wins under secondary diagonal direction
    private bool CheckDiagonal2Win(Button button, char currentPlayer)
    {
        int count = 1;
        Tuple<int, int> buttonLocation = GetLocation(button);
        int currentRow = buttonLocation.Item1;
        int currentCol = buttonLocation.Item2;
        while (true)
        {
            if (currentRow == row - 1 || currentCol == 0)
                break;
            currentRow++;
            currentCol--;
            if (GetPlayer(GetButton(currentRow, currentCol)) == currentPlayer)
                count++;
            else 
                break;
            if (count == winRule)
                return true;
        }
        currentRow = buttonLocation.Item1;
        currentCol = buttonLocation.Item2;
        while (true)
        {
            if (currentRow ==  0 || currentCol == col - 1)
                break;
            currentRow--;
            currentCol++;
            if (GetPlayer(GetButton(currentRow, currentCol)) == currentPlayer)
                count++;
            else 
                break;
            if (count == winRule)
                return true;
        }
        return false;
    }

    // isDraw(): Check if the board is fully occupied
    private bool isDraw()
    {
        int occupied = 0;
        foreach (Button button in board)
        {
            if (GetPlayer(button) != '\0')
            {
                occupied++;
            }
        }
        return occupied == row * col ? true : false;
    }
}