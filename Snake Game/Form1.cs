using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Graphics paper;
        Snake snake = new Snake();
        Random randFood = new Random();
        Food food;

        bool left = false;
        bool right = false;
        bool up = false;
        bool down = false;

        public Form1()
        {
            InitializeComponent();
            food = new Food(randFood);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            paper = e.Graphics;
            food.drawFood(paper);
            snake.drawSnake(paper);
            
            for (int i = 0; i < snake.snakeRec.Length; i++)
            {
                if(snake.snakeRec[i].IntersectsWith(food.foodRec))
                {
                    food.foodLocation(randFood);
                    food.drawFood(paper);
                    snake.length++;
                }
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down && up == false)
            {
                down = true;
                up = false;
                left = false;
                right = false;
            }
            else if (e.KeyData == Keys.Up && down == false)
            {
                down = false;
                up = true;
                left = false;
                right = false;
            }
            else if (e.KeyData == Keys.Left && right == false)
            {
                down = false;
                up = false;
                left = true;
                right = false;
            }
            else if (e.KeyData == Keys.Right && left == false)
            {
                down = false;
                up = false;
                left = false;
                right = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (down) { snake.moveDown(); }
            if (up) { snake.moveUp(); }
            if (left) { snake.moveLeft(); }
            if (right) { snake.moveRight(); }
            this.Invalidate();
        }
    }
}
