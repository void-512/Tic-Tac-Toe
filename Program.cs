namespace tictactoe;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
       
        ApplicationConfiguration.Initialize();
        Application.Run(new GameForm());
    }    
}


public class ButtonBoard
{
    private bool roundPlayer;
    private int row = 3;
    private int col = 3;

    private int winRule = 3;

    private Button[, ] board;

    public delegate bool CheckWinDelegate(Button button, char currentPlayer);
    public event CheckWinDelegate CheckWinEvent;

    public Tuple<int, int> GetSize()
    {
        return new Tuple<int, int>(row, col);
    }

    public Button GetButton(int r, int c)
    {
        return board[r, c];
    }

    private Tuple<int, int> GetLocation(Button button)
    {
        int row = ((Tuple<int, int, char>)button.Tag).Item1;
        int col = ((Tuple<int, int, char>)button.Tag).Item2;
        return new Tuple<int, int>(row, col);
    }

    private char GetPlayer(Button button)
    {
        return ((Tuple<int, int, char>)button.Tag).Item3;
    }
    
    public ButtonBoard()
    {
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

    private void SetButtonPlayer(Button current, char player)
    {
        Tuple<int, int> location = GetLocation(current);
        current.Tag = new Tuple<int, int, char>(location.Item1, location.Item2, player);
    }

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
            MessageBox.Show($"Player {GetPlayer(button)} wins the round");
            RefreshBoard();
        }
        else return;
    }
    
    private void RefreshBoard()
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
}