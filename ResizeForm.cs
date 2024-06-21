namespace tictactoe;

public class ResizeForm : Form
{
    GameForm gForm;
    Label rowLabel;
    Label colLabel;
    Label winRuleLabel;
    TextBox rowInput;
    TextBox colInput;
    TextBox winRuleInput;
    Button buttonOK;
    Button buttonCancel;
    String rowResult;
    String colResult;
    String winRuleResult;

    // ResizeForm(gForm): Instantiates the resize dialog with GameForm
    public ResizeForm(GameForm gForm)
    {
        this.gForm = gForm;
        InitializeComponent();
    }

    // InitializeComponent(): Initializes the dialog form
    private void InitializeComponent()
    {
        this.rowLabel = new Label();
        this.colLabel = new Label();
        this.winRuleLabel = new Label();
        this.rowInput = new TextBox();
        this.colInput = new TextBox();
        this.winRuleInput = new TextBox();
        this.buttonOK = new Button();
        this.buttonCancel = new Button();
        this.SuspendLayout();
        // 
        // rowLabel
        // 
        this.rowLabel.AutoSize = true;
        this.rowLabel.Location = new System.Drawing.Point(10, 12);
        this.rowLabel.Size = new System.Drawing.Size(72, 15);
        this.rowLabel.Text = "Rows: ";
        // 
        // colLabel
        // 
        this.colLabel.AutoSize = true;
        this.colLabel.Location = new System.Drawing.Point(100, 12);
        this.colLabel.Size = new System.Drawing.Size(72, 15);
        this.colLabel.Text = "Cols: ";
        // 
        // winRulesLabel
        // 
        this.winRuleLabel.AutoSize = true;
        this.winRuleLabel.Location = new System.Drawing.Point(190, 12);
        this.winRuleLabel.Size = new System.Drawing.Size(72, 35);
        this.winRuleLabel.Text = "Num to Win: ";
        // 
        // rowInput
        // 
        this.rowInput.Location = new System.Drawing.Point(50, 12);
        this.rowInput.Size = new System.Drawing.Size(20, 10);
        this.rowInput.TabIndex = 0;
        // 
        // colInput
        // 
        this.colInput.Location = new System.Drawing.Point(140, 12);
        this.colInput.Size = new System.Drawing.Size(20, 10);
        this.colInput.TabIndex = 1;
        // 
        // winRuleInput
        // 
        this.winRuleInput.Location = new System.Drawing.Point(270, 12);
        this.winRuleInput.Size = new System.Drawing.Size(20, 10);
        this.winRuleInput.TabIndex = 2;
        // 
        // buttonOK
        // 
        this.buttonOK.Location = new System.Drawing.Point(116, 41);
        this.buttonOK.Size = new System.Drawing.Size(75, 23);
        this.buttonOK.Text = "OK";
        this.buttonOK.UseVisualStyleBackColor = true;
        this.buttonOK.Click += buttonOKClick;
        this.buttonOK.TabIndex = 3;
        // 
        // buttonCancel
        // 
        this.buttonCancel.Location = new System.Drawing.Point(197, 41);
        this.buttonCancel.Size = new System.Drawing.Size(75, 23);
        this.buttonCancel.Text = "Cancel";
        this.buttonCancel.UseVisualStyleBackColor = true;
        this.buttonCancel.Click += buttonCancelClick;
        this.buttonCancel.TabIndex = 4;
        // 
        // ResizeForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(310, 76);
        this.Controls.Add(this.rowLabel);
        this.Controls.Add(this.colLabel);
        this.Controls.Add(this.winRuleLabel);
        this.Controls.Add(this.rowInput);
        this.Controls.Add(this.colInput);
        this.Controls.Add(this.winRuleInput);
        this.Controls.Add(this.buttonCancel);
        this.Controls.Add(this.buttonOK);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Resize Options";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    // buttonOKClick(sender, e): Actions when OK button is clicked
    private void buttonOKClick(object sender, EventArgs e)
    {
        rowResult = rowInput.Text;
        colResult = colInput.Text;
        winRuleResult = winRuleInput.Text;
        this.gForm.RecreateBoard(rowResult, colResult, winRuleResult);
        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    // buttonCancelClick(sender, e): Actions when Cancel button is clicked
    private void buttonCancelClick(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }
}