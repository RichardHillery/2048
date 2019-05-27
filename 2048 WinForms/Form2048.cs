using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048_WinForms
{
    public partial class Form2048 : Form
    {
        public Form2048()
        {
            InitializeComponent();
            Square[] Row1 = new Square[] { new Square(panelBackground, 0, 0), new Square(panelBackground, 0, 1), new Square(panelBackground, 0, 2), new Square(panelBackground, 0, 3) };
            Square[] Row2 = new Square[] { new Square(panelBackground, 1, 0), new Square(panelBackground, 1, 1), new Square(panelBackground, 1, 2), new Square(panelBackground, 1, 3) };
            Square[] Row3 = new Square[] { new Square(panelBackground, 2, 0), new Square(panelBackground, 2, 1), new Square(panelBackground, 2, 2), new Square(panelBackground, 2, 3) };
            Square[] Row4 = new Square[] { new Square(panelBackground, 3, 0), new Square(panelBackground, 3, 1), new Square(panelBackground, 3, 2), new Square(panelBackground, 3, 3) };
            squares = new Square[][] { Row1, Row2, Row3, Row4 };
            StartOver();
        }

        private Square[][] squares;

       
        private void StartOver()
        {
            foreach (var row in squares)
            {
                foreach (var square in row)
                { square.Value = 0; }
            }
            // squares[1][2].Value = 2;  //first move.
            // First move is later.
            labelStatus.Text = "Press an Arrow Key to play";
        }
        private Keys _prevMoveDownUp = Keys.Down;
        private Keys _prevMoveRL = Keys.Left;

        public enum MoveModes
        {
            None,
            Normal,
            TwoPersonWaitingForMouse,
            TwoPersonWaitingForArrow,
            Hard,
            Harder

        }

        public static bool IsWaitingForMouse
        {
            get { return _moveMode == MoveModes.TwoPersonWaitingForMouse; }
            set { _moveMode = MoveModes.TwoPersonWaitingForMouse; }
        }
        public static bool IsWaitingForArrow
        {
            get { return _moveMode == MoveModes.TwoPersonWaitingForArrow; }
            set { _moveMode = MoveModes.TwoPersonWaitingForArrow; }
        }


        private static MoveModes _moveMode = MoveModes.None;
        public MoveModes MoveMode
        {
            get { return _moveMode; }
            set
            {
                switch (value)
                {
                    case MoveModes.None:
                        labelStatus.Text = "Press 1 for normal, 2 for two person, 3 for hard.";
                        break;
                    case MoveModes.Normal:
                        labelStatus.Text = "Normal";
                        break;
                    case MoveModes.TwoPersonWaitingForMouse:
                        labelStatus.Text = "Player 1 click or double click a square";
                        break;
                    case MoveModes.TwoPersonWaitingForArrow:
                        labelStatus.Text = "Player 2 press arrow.";
                        break;
                    case MoveModes.Hard:
                        labelStatus.Text = "hard.";
                        break;
                }
                _moveMode = value;
            }
        }

        // The order to search for the next point to put the square. if we went down, then left:
        private static Point[] DownLeft = {
            new Point (3,3), new Point(3,2), new Point (3,1), new Point (3,0),
            new Point (2,3), new Point(2,2), new Point (2,1), new Point (2,0),
            new Point (1,3), new Point(1,2), new Point (1,1), new Point (1,0),
            new Point (0,3), new Point(0,2), new Point (0,1), new Point (0,0),
        };
        private static Point[] DownRight = {
            new Point (3,0), new Point(3,1), new Point (3,2), new Point (3,3),
            new Point (2,0), new Point(2,1), new Point (2,2), new Point (2,3),
            new Point (1,0), new Point(1,1), new Point (1,2), new Point (1,3),
            new Point (0,0), new Point(0,1), new Point (0,2), new Point (0,3),
        };
        private static Point[] UpLeft = {
            new Point (0,3), new Point(0,2), new Point (0,1), new Point (0,0),
            new Point (1,3), new Point(1,2), new Point (1,1), new Point (1,0),
            new Point (2,3), new Point(2,2), new Point (2,1), new Point (2,0),
            new Point (3,3), new Point(3,2), new Point (3,1), new Point (3,0),
        };
        private static Point[] UpRight = {
            new Point (0,0), new Point(0,1), new Point (0,2), new Point (0,3),
            new Point (1,0), new Point(1,1), new Point (1,2), new Point (1,3),
            new Point (2,0), new Point(2,1), new Point (2,2), new Point (2,3),
            new Point (3,0), new Point(3,1), new Point (3,2), new Point (3,3),
        };

        private List<Keys> PendingKeyDowns = new List<Keys>();

        private void Form2048_KeyDown(object sender, KeyEventArgs e)
        {
            PendingKeyDowns.Add(e.KeyCode);
        }



        private bool swapSquares(Point From, Point To)
        {
            // We swap these two.
            squares[From.Y][From.X].Value = squares[To.Y][To.X].Value;
            squares[To.Y][To.X].Value = 0;
            //somethingMoved = true;
            // We need to animate the movements:
            // To animate the movement, we move them back to where they started, and start the animations.
            Point tempPoint = squares[From.Y][From.X].GetPanel.Location;
            squares[From.Y][From.X].GetPanel.Location = squares[To.Y][To.X].GetPanel.Location;
            squares[To.Y][To.X].GetPanel.Location = tempPoint;
            squares[From.Y][From.X].AnimationInProgress = true;
            squares[To.Y][To.X].AnimationInProgress = true;
            squares[To.Y][To.X].GetPanel.Visible = false;
            return true;

        }

        private bool MergeSquares(Point From, Point To)
        {
            // We swap these two.
            squares[From.Y][From.X].Value *= 2;
            squares[To.Y][To.X].Value = 0;
            //somethingMoved = true;
            // We need to animate the movements:
            // To animate the movement, we move them back to where they started, and start the animations.
            Point tempPoint = squares[From.Y][From.X].GetPanel.Location;
            squares[From.Y][From.X].GetPanel.Location = squares[To.Y][To.X].GetPanel.Location;
            squares[To.Y][To.X].GetPanel.Location = tempPoint;
            squares[From.Y][From.X].AnimationInProgress = true;
            squares[To.Y][To.X].AnimationInProgress = true;
            squares[To.Y][To.X].GetPanel.Visible = false;
            return true;

        }

        private bool MergeRows(Keys k)
        {
            bool somethingMerged = false;
            for (int row = 0; row < 4; row++)
                if (MergeRow(k, row)) somethingMerged = true;
            return somethingMerged;
        }
        private bool MergeCols(Keys k)
        {
            bool somethingMerged = false;
            for (int col = 0; col < 4; col++)
                if (MergeCols(k, col)) somethingMerged = true;
            return somethingMerged;
        }
        private bool MoveRows(Keys k)
        {
            bool somethingMoved = false;
            for (int row = 0; row < 4; row++)
                if (MoveRow(k, row)) somethingMoved = true;
            return somethingMoved;
        }
        private bool MoveCols(Keys k)
        {
            bool somethingMoved = false;
            for (int col = 0; col < 4; col++)
                if (MoveCols(k, col)) somethingMoved = true;
            return somethingMoved;
        }
        private bool MoveCols(Keys k, int col)
        {
            bool somethingMoved = false;
            //if (PendingKeyDowns.Count == 0) return;
            //Keys k = PendingKeyDowns[0];
            //PendingKeyDowns.RemoveAt(0);
            switch (k)
            {
                case Keys.Down:
                    // When moving squares down, I am really moving the hole up.
                    for (int row = 3; row > 0; row--)
                        if (squares[row][col].Value == 0 && squares[row - 1][col].Value != 0)
                            somethingMoved = swapSquares(new Point(col, row), new Point(col, row - 1));
                    break;
                case Keys.Up:
                    for (int row = 0; row < 3; row++)
                        if (squares[row][col].Value == 0 && squares[row + 1][col].Value != 0)
                            somethingMoved = swapSquares(new Point(col, row), new Point(col, row + 1));
                    break;
            }
            return somethingMoved;
        }

        private bool MoveRow(Keys k, int row)
        {
            bool somethingMoved = false;
            //if (PendingKeyDowns.Count == 0) return;
            //Keys k = PendingKeyDowns[0];
            //PendingKeyDowns.RemoveAt(0);
            switch (k)
            {
                case Keys.Right:
                    for (int col = 3; col > 0; col--)
                        if (squares[row][col].Value == 0 && squares[row][col - 1].Value != 0)
                            somethingMoved = swapSquares(new Point(col, row), new Point(col - 1, row));

                    break;
                case Keys.Left:
                    for (int col = 0; col < 3; col++)
                        if (squares[row][col].Value == 0 && squares[row][col + 1].Value != 0)
                            somethingMoved = (swapSquares(new Point(col, row), new Point(col + 1, row)));
                    break;
            }
            return somethingMoved;
        }
        private bool MergeCols(Keys k, int col)
        {
            bool somethingMerged = false;
            //if (PendingKeyDowns.Count == 0) return;
            //Keys k = PendingKeyDowns[0];
            //PendingKeyDowns.RemoveAt(0);
            switch (k)
            {
                case Keys.Down:
                    // When moving squares down, I am really moving the hole up.
                    for (int row = 3; row > 0; row--)
                        if (squares[row][col].Value != 0)
                            if (squares[row][col].Value == squares[row - 1][col].Value)
                                somethingMerged = MergeSquares(new Point(col, row), new Point(col, row - 1));
                    break;
                case Keys.Up:
                    for (int row = 0; row < 3; row++)
                        if (squares[row][col].Value != 0)
                            if (squares[row][col].Value == squares[row + 1][col].Value)
                                somethingMerged = MergeSquares(new Point(col, row), new Point(col, row + 1));
                    break;
            }
            return somethingMerged;
        }

        private bool MergeRow(Keys k, int row)
        {
            bool somethingMerged = false;
            //if (PendingKeyDowns.Count == 0) return;
            //Keys k = PendingKeyDowns[0];
            //PendingKeyDowns.ReMergeAt(0);
            switch (k)
            {
                case Keys.Right:
                    for (int col = 3; col > 0; col--)
                        if (squares[row][col].Value != 0)
                            if (squares[row][col].Value == squares[row][col - 1].Value)
                                somethingMerged = MergeSquares(new Point(col, row), new Point(col - 1, row));

                    break;
                case Keys.Left:
                    for (int col = 0; col < 3; col++)
                        if (squares[row][col].Value != 0)
                            if (squares[row][col].Value == squares[row][col + 1].Value)
                                somethingMerged = (MergeSquares(new Point(col, row), new Point(col + 1, row)));
                    break;
            }
            return somethingMerged;
        }
        public bool MakeMove(Point[] searchOrder)
        {
            for (int ix = 0; ix < searchOrder.Length; ix++)
            {
                if (squares[searchOrder[ix].X][searchOrder[ix].Y].Value == 0)
                {
                    // We know where to put this, but what to put here?
                    // For now, we just put a 2.
                    squares[searchOrder[ix].X][searchOrder[ix].Y].Value = 2;
                    return false; // Not at end
                }

            }
            return true; // At the end;
        }
        private Random rand = new Random();
        private bool MakeMove(Keys k)
        {
            bool youLose = false;
            switch (MoveMode)
            {
                case MoveModes.Hard:


                    switch (k)
                    {
                        case Keys.Right:
                            {
                                // Next, we make our move.
                                // Last was left, so we pick the correct down up for the previous move
                                Point[] searchOrder = (_prevMoveDownUp == Keys.Down) ? DownRight : UpRight;
                                if (MakeMove(searchOrder))
                                    youLose = true;
                                _prevMoveRL = Keys.Left;
                            }

                            break;
                        case Keys.Left:
                            {
                                // Next, we make our move.
                                // Last was , so rightwe pick the correct down up for the previous move
                                Point[] searchOrder = (_prevMoveDownUp == Keys.Down) ? DownLeft : UpLeft;
                                if (MakeMove(searchOrder))
                                    youLose = true;
                                _prevMoveRL = Keys.Right;
                            }
                            break;
                        case Keys.Up:
                            {
                                // Next, we make our move.
                                // Last was , so rightwe pick the correct down up for the previous move
                                Point[] searchOrder = (_prevMoveRL == Keys.Right) ? DownLeft : UpLeft;
                                if (MakeMove(searchOrder))
                                    youLose = true;
                                _prevMoveDownUp = Keys.Up;
                            }
                            break;
                        case Keys.Down:
                            {
                                // Next, we make our move.
                                // Last was , so rightwe pick the correct down up for the previous move
                                Point[] searchOrder = (_prevMoveRL == Keys.Right) ? DownLeft : UpLeft;
                                if (MakeMove(searchOrder))
                                    youLose = true;
                                _prevMoveDownUp = Keys.Down;
                            }
                            break;

                    }
                    break;
                case MoveModes.TwoPersonWaitingForMouse:
                    break;
                case MoveModes.TwoPersonWaitingForArrow:
                    break;
                case MoveModes.Normal:
                    // Need to pick an empty square at random.
                    // 10% of the time the value is a 4, otherwise a 2.
                    List<Point> EmptySquares = new List<Point>();
                    for (int row = 0; row < 4; row++)
                        for (int col = 0; col < 4; col++)
                            if (squares[row][col].Value == 0)
                                EmptySquares.Add(new Point(col, row));  // X is column
                    if (EmptySquares.Count == 0)
                    {
                        labelStatus.Text = "You Lose!";
                        return true;
                    }
                    int r = rand.Next(EmptySquares.Count);
                    int pick2or4 = rand.Next(10) == 0 ? 4 : 2;
                    squares[EmptySquares[r].Y][EmptySquares[r].X].Value = pick2or4;
                    break;
                case MoveModes.Harder:
                    // Need to pick an empty square at random.
                    // 10% of the time the value is a 4, otherwise a 2.
                    List<Point> EmptySquares2 = new List<Point>();
                    for (int row = 0; row < 4; row++)
                        for (int col = 0; col < 4; col++)
                            if (squares[row][col].Value == 0)
                                EmptySquares2.Add(new Point(col, row));  // X is column
                    if (EmptySquares2.Count == 0)
                    {
                        labelStatus.Text = "You Lose!";
                        return true;
                    }
                    int r2 = rand.Next(EmptySquares2.Count);
                    int pick12or4 = rand.Next(50) == 0 ? 1 : rand.Next(10) == 0 ? 4 : 2;
                    squares[EmptySquares2[r2].Y][EmptySquares2[r2].X].Value = pick12or4;
                    break;
            }
            if (youLose)
                labelStatus.Text = "You Lose!";
            return youLose;

        }


        private int step = 0;
        private Keys KeyInProgress = Keys.A;
        private bool didIMakeAMoveThisKeysroke;
        //private bool didIMakeAMergeThisKeystroke;
        private bool NotRight;
        private bool NotLeft;
        private bool NotUp;
        private bool NotDown;

        private void Timer1_Tick(object sender, EventArgs e)
        {
            bool animationInProgress = false;
            foreach (var row in squares)
            {
                foreach (var square in row)
                { if (square.Animate()) animationInProgress = true; ; }
            }
            if (animationInProgress) return;

            if (MoveMode == MoveModes.TwoPersonWaitingForMouse && PendingKeyDowns.Count > 0)
                PendingKeyDowns.Clear();

            switch (step)
            {
                case 0:
                    // Get a key input, and then start moving accordingly.
                    if (PendingKeyDowns.Count == 0) return;
                    KeyInProgress = PendingKeyDowns[0];
                    PendingKeyDowns.RemoveAt(0);
                    labelStatus.Text = "";
                    didIMakeAMoveThisKeysroke = false;
                    if (MoveMode == MoveModes.TwoPersonWaitingForArrow)
                        MoveMode = MoveModes.TwoPersonWaitingForMouse;
                    if (MoveMode == MoveModes.None)
                    {
                        switch (KeyInProgress)
                        {
                            case Keys.D1:
                                MoveMode = MoveModes.Normal;
                                break;
                            case Keys.D2:
                                MoveMode = MoveModes.TwoPersonWaitingForMouse;
                                break;
                            case Keys.D3:
                                MoveMode = MoveModes.Hard;
                                break;
                        }
                    }
                    else
                        step = 1;
                    break;
                case 1:
                    // Move in the desired direction.
                    if (!MoveDirection(KeyInProgress))
                        step = 2;
                    else
                        didIMakeAMoveThisKeysroke = true;
                    //  If nothing moves, go to case 2:
                    break;
                case 2:
                    // Merge
                    if (MergeDirection(KeyInProgress))
                        didIMakeAMoveThisKeysroke = true;
                    step = 3;
                    break;
                case 3:
                    // Move in the desired direction.
                    if (!MoveDirection(KeyInProgress))
                        if (didIMakeAMoveThisKeysroke)
                            step = 4;
                        else
                        {
                            // Does not count as a move
                            if (MoveMode == MoveModes.TwoPersonWaitingForMouse)
                                MoveMode = MoveModes.TwoPersonWaitingForArrow;

                            step = 0;
                            if (KeyInProgress == Keys.Up) NotUp = true;
                            if (KeyInProgress == Keys.Down) NotDown = true;
                            if (KeyInProgress == Keys.Left) NotLeft = true;
                            if (KeyInProgress == Keys.Right) NotRight = true;
                            labelStatus.Text = "Nope!  "
                                + (NotUp ? "Not Up " : "")
                                + (NotDown ? "Not Down " : "")
                                + (NotLeft ? "Not Left " : "")
                                + (NotRight ? "Not Right " : "")
                                 ;
                            if (NotUp && NotDown && NotLeft && NotRight)
                            {
                                // Start over
                                step = 5;
                            }
                        }
                    else
                        didIMakeAMoveThisKeysroke = true;
                    //  If nothing moves, go to case 2:
                    break;
                case 4:
                    if (MakeMove(KeyInProgress))
                        step = 4;
                    else
                        step = 0;
                    NotRight = false;
                    NotLeft = false;
                    NotUp = false;
                    NotDown = false;
                    break;
                case 5:
                    StartOver();
                    step = 0;
                    break;

            }
            // If we moved, we start next animation now.
            foreach (var row in squares)
                foreach (var square in row)
                    square.Animate();
        }

        private bool MergeDirection(Keys k)
        {
            bool itMerge = false;
            if (MergeRows(k)) itMerge = true;
            if (MergeCols(k)) itMerge = true;
            return itMerge;
        }

        private bool MoveDirection(Keys k)
        {
            bool itMoved = false;
            if (MoveRows(k)) itMoved = true;
            if (MoveCols(k)) itMoved = true;
            return itMoved;

        }

        private ModeSelection ms = new ModeSelection();
        private void LabelStatus_Click(object sender, EventArgs e)
        {
            ms.SetCaller(this, MoveMode);
            ms.Show();

        }

      

        private void Form2048_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X < 60 && e.Y < 35)
            {
                ms.SetCaller(this, MoveMode);
                ms.Show();

            }
        }
    }
}
