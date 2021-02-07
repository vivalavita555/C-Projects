using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Paddle _paddle;
        Ball[] _balls;
        const int _NumBalls = 2; // try many balls
        int _NumBallsAlive;
        int _nLevels;
        int _Score = 0;
        Block[,] _blocks;
        int _nBlocksX = 8;
        int _nBlocksY = 3;
        int _numBlocksAlive;
        Timer _timer;
        public Random _rand = new Random(1);
        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.DoubleBuffer |
                 ControlStyles.UserPaint
                , true);
            Width = 1000;
            Height = 800;
            BackColor = Color.Black;
            _paddle = new Paddle(this);
            _balls = new Ball[_NumBalls];
            _NumBallsAlive = _NumBalls;
            for (int i = 0; i < _NumBalls; i++)
            {
                _balls[i] = new Ball(this)
                {
                    _pos = new Point(
                      100 + i * 20,
                      200 + i * 20)
                };
            }
            MakeBlocks();
            _timer = new Timer();
            _timer.Interval = 15; //msecs
            _timer.Tick += tmr_Tick;
            _timer.Enabled = true;
        }

        private void MakeBlocks()
        {
            _numBlocksAlive = _nBlocksX * _nBlocksY;
            _blocks = new Block[_nBlocksX, _nBlocksY];
            for (int i = 0; i < _nBlocksX; i++)
            {
                for (int j = 0; j < _nBlocksY; j++)
                {
                    _blocks[i, j] = new Block(this, i, j);
                    Invalidate(_blocks[i, j].GetRect());
                }
            }
        }

        void tmr_Tick(object sender, EventArgs e)
        {
            Point res;
            for (int iBall = 0; iBall < _NumBalls; iBall++)
            {
                // first we see if the ball will collide
                // with the frame, the paddle or the blocks
                var ball = _balls[iBall];
                if (!ball.IsDead)
                {
                    // first see if it hits the walls
                    res = WillCollide(
                      ball,
                      ClientRectangle, // rect of whole frame
                      fShouldBeInside: true);
                    if (res.X == 0 && res.Y == 0) //didn't hit
                    {
                        // see if it hits paddle
                        res = WillCollide(
                          ball,
                          _paddle.GetRect(),  // rect of paddle
                          fShouldBeInside: false);
                        if (res.X == 0 && res.Y == 0) //didn't hit
                        {
                            // see if it hits any block
                            if (_numBlocksAlive == 0)
                            {
                                _nLevels++;
                                _nBlocksY++;
                                // reward: bring back some balls
                                int nBallsToBringBackToLife = 0;
                                for (int i = 0; i < _NumBalls; i++)
                                {
                                    if (_balls[i].IsDead)
                                    {
                                        _balls[i].IsDead = false;
                                        _balls[i]._pos.X = 100 + 10 * i;
                                        _balls[i]._pos.Y = 100 + 10 * i;
                                        _NumBallsAlive++;
                                        Invalidate(_balls[i].GetRect());
                                        if (++nBallsToBringBackToLife == 3)
                                        {
                                            break;
                                        }
                                    }
                                }

                                MakeBlocks();
                            }
                            else
                            {
                                for (int i = 0; i < _nBlocksX; i++)
                                {
                                    for (int j = 0; j < _nBlocksY; j++)
                                    {
                                        if (!_blocks[i, j].IsDead)
                                        {
                                            res = WillCollide(
                                                ball,
                                                _blocks[i, j].GetRect(),
                                                fShouldBeInside: false);
                                            if (res.X != 0 || res.Y != 0)
                                            {
                                                Beep(100, 10);
                                                _blocks[i, j].IsDead = true;
                                                _numBlocksAlive--;
                                                _Score++;
                                                Invalidate(_blocks[i, j].GetRect());
                                            }
                                        }
                                    }
                                }

                            }
                        }
                        else
                        {// hit paddle
                            Beep(400, 10);
                        }
                    }
                    else
                    { // did hit frame edge
                        if (res.Y == -1)
                        {// hit bottom of frame
                            ball.IsDead = true;
                            Invalidate(ball.GetRect());
                            _NumBallsAlive--;
                        }
                    }
                    // now we can move the ball
                    Invalidate(ball.GetRect());
                    ball._pos.X += ball._velocity.X;
                    ball._pos.Y += ball._velocity.Y;
                    Invalidate(ball.GetRect());
                }
            }
            if (_NumBallsAlive == 0)
            {
                this._timer.Enabled = false;
            }
            this.Text = string.Format(
              "Blocks by Calvin Hsia. Score = {0}  # Levels = {1} # of balls left = {2}",
              _Score,
              _nLevels,
              _NumBallsAlive);
        }
        //see if the ball will collide with the given rect
        // if it should be inside (like the frame) 
        // or outside the rect (like the paddle)
        // returns 0,0 if no collision, or 
        // a point indicating a new direction 
        // also adjusts ball velocity so won't collide
        Point WillCollide(
          Ball ball,
          Rectangle rectTest,
          bool fShouldBeInside)
        {
            var res = new Point();

            int nCollides = 0;
            if (fShouldBeInside)
            {
                nCollides = 1;
            }
            else
            {
                var rect = ball.GetRect();
                rect = new Rectangle(
                    new Point(
                        rect.Left + ball._velocity.X,
                        rect.Top + ball._velocity.Y),
                    ball._size);
                if (rect.IntersectsWith(rectTest))
                {
                    nCollides = 1;
                }
            }

            if (ball._velocity.X != 0)
            {
                if (ball._velocity.X > 0)
                {
                    var edgeX = rectTest.Left;
                    if (fShouldBeInside)
                    {
                        edgeX = rectTest.Left + rectTest.Width;
                    }
                    if (ball._pos.X < edgeX &&
                        ball._pos.X +
                        ball._size.Width +
                        ball._velocity.X >= edgeX)
                    {
                        res.X = -nCollides;
                    }
                }
                else
                {
                    var edgeX = rectTest.Left + rectTest.Width;
                    if (fShouldBeInside)
                    {
                        edgeX = rectTest.Left;
                    }
                    if (ball._pos.X > edgeX &&
                        ball._pos.X +
                        ball._velocity.X <= edgeX)
                    {
                        res.X = nCollides;
                    }
                }
            }
            if (ball._velocity.Y != 0)
            {
                if (ball._velocity.Y > 0)
                {
                    var edgeY = rectTest.Top;
                    if (fShouldBeInside)
                    {
                        edgeY = rectTest.Top + rectTest.Height;
                    }
                    if (ball._pos.Y < edgeY &&
                        ball._pos.Y +
                        ball._size.Height +
                        ball._velocity.Y >= edgeY)
                    {
                        res.Y = -nCollides;
                    }
                }
                else
                {
                    var edgeY = rectTest.Top + rectTest.Height;
                    if (fShouldBeInside)
                    {
                        edgeY = rectTest.Top;
                    }
                    if (ball._pos.Y > edgeY &&
                        ball._pos.Y +
                        ball._velocity.Y <= edgeY)
                    {
                        res.Y = nCollides;
                    }
                }
            }
            if (res.X != 0) // if it collides in x direction
            {
                ball._velocity.X =
                    res.X * (1 + _rand.Next(ball._speedMax));
            }
            if (res.Y != 0)
            {
                ball._velocity.Y =
                    res.Y * (1 + _rand.Next(ball._speedMax));
            }

            return res;

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            _paddle.Draw(e);
            {
                for (int i = 0; i < _NumBalls; i++)
                {
                    _balls[i].Draw(e);
                }
                foreach (var blk in _blocks)
                {
                    blk.Draw(e);
                }
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            _paddle.OnKeyDown(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            _paddle.OnMouseMove(e);
        }

        [DllImport("kernel32.dll")]
        public static extern bool Beep(int BeepFreq, int BeepDuration);

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    public abstract class BaseObj
    {
        public Brush _brush;
        public Point _pos;
        public Size _size;
        public Form1 _form;
        public Point _velocity;// vector
        public int _speedMax = 10;
        public bool IsDead;
        public abstract void Draw(PaintEventArgs e);
        static int curColor = 0xffffff;
        public Rectangle GetRect()
        {
            return new Rectangle(
              _pos.X,
              _pos.Y,
              _size.Width,
              _size.Height);
        }
        public void MakeNewColor()
        {
            // http://blogs.msdn.com/b/calvin_hsia/archive/2011/01/26/10120810.aspx
            var newColor = Color.FromArgb(
                            (byte)(0xff), //opaque
                            (byte)(curColor & 0xff), //red
                            (byte)((curColor >> 4) & 0xff),//green
                            (byte)((curColor >> 8) & 0xff) //blue
                            );
            _brush = new SolidBrush(newColor);
            curColor -= 100; // change the color some way
        }
    }

    public class Ball : BaseObj
    {
        public Ball(Form1 form1)
        {
            this._form = form1;
            MakeNewColor();
            _size = new Size(20, 20);
            MakeNewSpeed(new Point());
        }
        void MakeNewSpeed(Point newDirection)
        {
            if (newDirection.X == 0 &&
              newDirection.Y == 0) // initializing
            {
                while (_velocity.X == 0 && _velocity.Y == 0)
                {
                    _velocity.X = _speedMax -
                            _form._rand.Next(_speedMax * 2);
                    _velocity.Y = _speedMax -
                            _form._rand.Next(_speedMax * 2);
                }
            }
            else
            {
                _velocity.X = newDirection.X;
                _velocity.Y = newDirection.Y;
            }
        }

        public override void Draw(PaintEventArgs e)
        {
            if (!IsDead)
            {
                var rect = GetRect();
                if (e.ClipRectangle.IntersectsWith(rect))
                {
                    e.Graphics.FillEllipse(_brush, rect);
                }
            }
        }

        public override string ToString()
        {
            return string.Format("P={0} V={1} {2}", _pos, _velocity, GetRect());
        }
    }

    public class Block : BaseObj
    {
        int _marginX = 50;
        int _marginY = 70;
        public Block(Form1 form, int i, int j)
        {
            _form = form;
            _size = new Size(70, 20);
            _pos = new Point(
              (_marginX + _size.Width) * i,
              40 + (_marginY + _size.Height) * j + 20
              );
            MakeNewColor();
        }

        public override void Draw(PaintEventArgs e)
        {
            if (!IsDead)
            {
                var rect = GetRect();
                if (e.ClipRectangle.IntersectsWith(rect))
                {
                    e.Graphics.FillRectangle(_brush, rect);
                }
            }
        }
    }

    public class Paddle : BaseObj
    {
        public int _speed = 10;
        public Paddle(Form1 form)
        {
            _form = form;
            _brush = Brushes.Blue;
            _pos = new Point(10, _form.Height - 80);
            _size = new Size(150, 10);
        }
        public override void Draw(PaintEventArgs e)
        {
            var rect = GetRect();
            if (e.ClipRectangle.IntersectsWith(rect))
            {
                e.Graphics.FillRectangle(_brush, rect);
            }
        }

        internal void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    _form.Invalidate(GetRect());
                    _pos.X -= _speed;
                    _form.Invalidate(GetRect());
                    break;
                case Keys.Right:
                    _form.Invalidate(GetRect());
                    _pos.X += _speed;
                    _form.Invalidate(GetRect());
                    break;
                case Keys.Q:
                    Environment.Exit(0);
                    break;
            }
        }

        internal void OnMouseMove(MouseEventArgs e)
        {
            _form.Invalidate(GetRect());
            _pos.X = e.X;
            _form.Invalidate(GetRect());
        }

    }


}