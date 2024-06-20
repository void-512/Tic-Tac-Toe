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
        Application.Run(new Form1());
    }    
}


public class ButtonBoard
{
    private bool roundPlayer;
    private int row = 3;
    private int col = 3;

    private int winRule = 3;

    public Tuple<int, int> GetSize()
    {
        return new Tuple<int, int>(row, col);
    }

    private Button[, ] board;
    public ButtonBoard()
    {
        board = new Button[row, col];
        for (int r = 0; r < row; r++)
            for (int c = 0; c < col; c++)
            {
                board[r, c] = new Button();
                board[r, c].Tag = new Tuple<int, int, char>(r, c, '\0');
                board[r, c].Click += ButtonClick;
            }
    }

    public Button GetButton(int r, int c)
    {
        return board[r, c];
    }

    private void SetButtonTag(Button current, char player)
    {
        int currentRow = ((Tuple<int, int, char>)current.Tag).Item1;
        int currentCol = ((Tuple<int, int, char>)current.Tag).Item2;
        current.Tag = new Tuple<int, int, char>(currentRow, currentCol, player);
    }

    private char GetPlayer(Button button)
    {
        return ((Tuple<int, int, char>)button.Tag).Item3;
    }

    private bool isWin(Button current)
    {
        int count = 1;
        int currentRow = ((Tuple<int, int, char>)current.Tag).Item1;
        int currentCol = ((Tuple<int, int, char>)current.Tag).Item2;
        char currentPlayer = GetPlayer(current);
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
        currentRow = ((Tuple<int, int, char>)current.Tag).Item1;
        currentCol = ((Tuple<int, int, char>)current.Tag).Item2;
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
        count = 1;
        currentRow = ((Tuple<int, int, char>)current.Tag).Item1;
        currentCol = ((Tuple<int, int, char>)current.Tag).Item2;
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
        currentRow = ((Tuple<int, int, char>)current.Tag).Item1;
        currentCol = ((Tuple<int, int, char>)current.Tag).Item2;
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
        count = 1;
        currentRow = ((Tuple<int, int, char>)current.Tag).Item1;
        currentCol = ((Tuple<int, int, char>)current.Tag).Item2;
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
        currentRow = ((Tuple<int, int, char>)current.Tag).Item1;
        currentCol = ((Tuple<int, int, char>)current.Tag).Item2;
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
        count = 1;
        currentRow = ((Tuple<int, int, char>)current.Tag).Item1;
        currentCol = ((Tuple<int, int, char>)current.Tag).Item2;
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
        currentRow = ((Tuple<int, int, char>)current.Tag).Item1;
        currentCol = ((Tuple<int, int, char>)current.Tag).Item2;
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


    private void ButtonClick(object sender, EventArgs e)
    {
        Button? button = sender as Button;
        char player = GetPlayer(button);
        if (player != '\0') return;
        if (roundPlayer == true)
        {
            button.Text ="X";
            SetButtonTag(button, 'X');
            roundPlayer = false;
        }
        else 
        {
            button.Text= "O";
            SetButtonTag(button, 'O');
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
            for (int c = 0; c < col; c++)
            {
                Button current = GetButton(r, c);
                SetButtonTag(current, '\0');
                current.Text = "";
            }
    }
}