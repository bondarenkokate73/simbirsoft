using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int razm = 3;
        public static int xod = 0;
        public static int player;
        public static bool gameover = false;
        int[,] nxn = new int[7, 7];

        interface IGame
        {
            bool proverka(int[,] nxn, int razm);
        }

        public class Game : IGame
        {
            public bool proverka(int[,] nxn, int razm)
            {
            int el1 =0;
            int el2 = 0;
             
                //Проверка на наличие полностью заполненных строк/стоблцов/диагоналей
                //Проверка по строчкам
                for (int a = 1; a < razm + 1; a++)
                {
                    el1 = 0;
                    el2 = 0;
                    if (gameover == true)
                    { break; }
                    for (int b = 1; b < razm + 1; b++)
                    {
                        if ((nxn[a, b] != 1) & (nxn[a, b] != 2))
                        {
                            el1 = 0;
                            el2 = 0;
                            break;
                        }
                        else if ((nxn[a, b] == 1))
                        {
                            el1++;
                            if (el1 == razm) { player = 1; gameover = true; break; }
                        }
                        else if ((nxn[a, b] == 2))
                        {
                            el2++;
                            if (el2 == razm) { player = 2; gameover = true; break; }
                        }
                        else if ((el1 == razm) | (el2 == razm))
                        {
                            break;
                        }
                    }

                    //Проверка по столбцам
                    for (int b = 1; b < razm + 1; b++)
                    {
                        el1 = 0;
                        el2 = 0;
                        if (gameover == true)
                        { break; }
                        for (int l = 1; l < razm + 1; l++)
                        {
                            if ((nxn[l, b] != 1) & (nxn[l, b] != 2))
                            {
                                el1 = 0;
                                el2 = 0;
                                break;
                            }
                            else if ((nxn[l, b] == 1))
                            {
                                el1++;
                                if (el1 == razm) { player = 1; gameover = true; break; }
                            }
                            else if ((nxn[l, b] == 2))
                            {

                                el2++;
                                if (el2 == razm) { player = 2; gameover = true; break; }
                            }
                            else if ((el1 == razm) | (el2 == razm))
                            {
                                break;
                            }
                        }
                    }

                    el1 = 0;
                    el2 = 0;

                    //Проверка по главной диагонали
                    for (int b = 1; b < razm + 1; b++)
                    {
                        if (gameover == true)
                        { break; }
                        if ((nxn[b, b] != 1) & (nxn[b, b] != 2))
                        {
                            el1 = 0;
                            el2 = 0;
                            break;
                        }
                        else if ((nxn[b, b] == 1))
                        {
                            el1++;
                            if (el1 == razm) { player = 1; gameover = true; break; }
                        }
                        else if ((nxn[b, b] == 2))
                        {
                            el2++;
                            if (el2 == razm) { player = 2; gameover = true; break; }
                        }
                        else if ((el1 == razm) | (el2 == razm))
                        {
                            break;
                        }
                    }

                    el1 = 0;
                    el2 = 0;

                    //Проверка по побочной диагонали
                    for (int z = razm; z > 0; z--)
                    {
                        if (gameover == true)
                        { break; }
                        for (int b = 1; b < razm + 1; z--, b++)
                        {
                            if ((nxn[z, b] != 1) & (nxn[z, b] != 2))
                            {
                                el1 = 0;
                                el2 = 0;
                                break;
                            }
                            else if ((nxn[z, b] == 1))
                            {
                                el1++;
                                if (el1 == razm) { player = 1; gameover = true; break; }
                            }
                            else if ((nxn[z, b] == 2))
                            {
                                el2++;
                                if (el2 == razm) { player = 2; gameover = true; break; }
                            }
                            else if ((el1 == razm) | (el2 == razm))
                            {
                                break;
                            }
                        }
                    }
                    //Проверка на ничью (кончились клетки)
                    if (xod + 1 == razm * razm)
                    {
                        gameover= true;
                    }
                }
                return gameover;
            }
        }

        //Отрисовка поля
        public void createPole()
        {
            string pole = Convert.ToString(comboBox1.SelectedItem);
            if (pole == "4х4") { razm = 4; }
            if (pole == "5х5") { razm = 5; }
            if (pole == "6х6") { razm = 6; }

            button6.Visible = true;
            button9.Visible = true;
            button23.Visible = true;
            button24.Visible = true;
            button25.Visible = true;
            button7.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button5.Visible = true;

            if (razm > 3)
            {
                button21.Visible = true;
                button20.Visible = true;
                button19.Visible = true;
                button18.Visible = true;
                button22.Visible = true;
                button8.Visible = true;
                button4.Visible = true;

                if (razm > 4)
                {
                    button11.Visible = true;
                    button13.Visible = true;
                    button17.Visible = true;
                    button15.Visible = true;
                    button29.Visible = true;
                    button34.Visible = true;
                    button35.Visible = true;
                    button36.Visible = true;
                    button37.Visible = true;

                    if (razm > 5)
                    {
                        button33.Visible = true;
                        button32.Visible = true;
                        button31.Visible = true;
                        button30.Visible = true;
                        button27.Visible = true;
                        button26.Visible = true;
                        button28.Visible = true;
                        button14.Visible = true;
                        button16.Visible = true;
                        button12.Visible = true;
                        button10.Visible = true;
                    }
                }
            }
        }

        //Кнопка "Начать игру"
        private void button1_Click(object sender, EventArgs e)
        {
            gameover = false;
            player = 0;
            //Задали значение по умолчанию
            comboBox1.Text = "3x3";
            label3.Visible = true;
            //Отрисовываем поле нужного размера
            createPole();
            button1.Visible = false;
            button38.Visible = true;
            label3.Text = "Ход игрока " + textBox1.Text; hod = 1;
        }

        public void Hod()
        {
            //Счетчик количества ходов 
            xod++;
            label4.Text = "Ходов сделано: " + xod;
            if (xod % 2 == 0)
            {
                label3.Text = "Ход игрока " + textBox1.Text; hod = 1;
            }
            else
            {
                label3.Text = "Ход игрока " + textBox2.Text; hod = 2;
            }
        }

        //Сообщение о конце игры
        public void konec(int player, int xod)
        {
            if (player == 1)
            {
                label4.Text = "Ходов сделано: " + (xod + 1);
                label3.Text = "Конец игры";
                MessageBox.Show("Конец игры! Выиграл: " + textBox1.Text);
            }
            else if (player == 2)
            {
                label4.Text = "Ходов сделано: " + (xod + 1);
                label3.Text = "Конец игры";
                MessageBox.Show("Конец игры! Выиграл: " + textBox2.Text);
            }
            else 
            {
                label4.Text = "Ходов сделано: " + (xod + 1);
                label3.Text = "Конец игры";
                MessageBox.Show("Упс.. Ничья :)");
            }
        }

        //При нажатии на клетку
        public void click(int[,] nxn, int i, int j, Button a)
        {
            if (hod == 1) { a.Image = Image.FromFile(@"крестик.png"); }
            if (hod == 2) { a.Image = Image.FromFile(@"нолик.png"); }
            a.Enabled = false;
            nxn[i, j] = hod;
            //Юзаем класс от интерфейса
            Game g = new Game();
            bool b = g.proverka(nxn, razm);
            if (b == false)
            {
                Hod();
            }
            else
            {
                konec(player,xod);
            }
        }

        public static int i;
        public static int j;
        public static int hod;
        Button a = new Button();

        //Обрабатываем нажатия кнопок
        private void button2_Click(object sender, EventArgs e)
        {
            i = 1; j = 1;
            a = button2;
            click(nxn, i, j, a);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            i = 1; j = 2;
            a = button3;
            click(nxn, i, j,a);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            i = 1; j = 3;
            a = button5;
            click(nxn, i, j, a);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            i = 1; j = 4;
            a = button4;
            click(nxn, i, j, a);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            i = 1; j = 5;
            a = button11;
            click(nxn, i, j, a);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            i = 1; j = 6;
            a = button10;
            click(nxn, i, j, a);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            i = 2; j = 1;
            a = button7;
            click(nxn, i, j, a);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            i = 2; j = 2;
            a = button6;
            click(nxn, i, j, a);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            i = 2; j = 3;
            a = button9;
            click(nxn, i, j, a);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            i = 2; j = 4;
            a = button8;
            click(nxn, i, j, a);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            i = 2; j = 5;
            a = button13;
            click(nxn, i, j, a);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            i = 2; j = 6;
            a = button12;
            click(nxn, i, j, a);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            i = 3; j = 1;
            a = button25;
            click(nxn, i, j, a);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            i = 3; j = 2;
            a = button24;
            click(nxn, i, j, a);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            i = 3; j = 3;
            a = button23;
            click(nxn, i, j, a);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            i = 3; j = 4;
            a = button22;
            click(nxn, i, j, a);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            i = 3; j = 5;
            a = button17;
            click(nxn, i, j, a);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            i = 3; j = 6;
            a = button16;
            click(nxn, i, j, a);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            i = 4; j = 1;
            a = button21;
            click(nxn, i, j, a);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            i = 4; j = 2;
            a = button20;
            click(nxn, i, j, a);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            i = 4; j = 3;
            a = button19;
            click(nxn, i, j, a);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            i = 4; j = 4;
            a = button18;
            click(nxn, i, j, a);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            i = 4; j = 5;
            a = button15;
            click(nxn, i, j, a);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            i = 4; j = 6;
            a = button14;
            click(nxn, i, j, a);
        }

        private void button37_Click(object sender, EventArgs e)
        {
            i = 5; j = 1;
            a = button37;
            click(nxn, i, j, a);
        }

        private void button36_Click(object sender, EventArgs e)
        {
            i = 5; j = 2;
            a = button36;
            click(nxn, i, j, a);
        }

        private void button35_Click(object sender, EventArgs e)
        {
            i = 5; j = 3;
            a = button35;
            click(nxn, i, j, a);
        }

        private void button34_Click(object sender, EventArgs e)
        {
            i = 5; j = 4;
            a = button34;
            click(nxn, i, j, a);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            i = 5; j = 5;
            a = button29;
            click(nxn, i, j, a);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            i = 5; j = 6;
            a = button28;
            click(nxn, i, j, a);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            i = 6; j = 1;
            a = button33;
            click(nxn, i, j, a);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            i = 6; j = 2;
            a = button32;
            click(nxn, i, j, a);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            i = 6; j = 3;
            a = button31;
            click(nxn, i, j, a);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            i = 6; j = 4;
            a = button30;
            click(nxn, i, j, a);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            i = 6; j = 5;
            a = button27;
            click(nxn, i, j, a);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            i = 6; j = 6;
            a = button26;
            click(nxn, i, j, a);
        }

        //Очищение поля для новой игры
        public void obnull(Button but)
        {
            but.Visible = false;
            but.Enabled = true;
            but.Image = null;
        }

        //Кнопка "Очистить поле"
        private void button38_Click(object sender, EventArgs e)
        {

            xod = 0;
            obnull(button6);
            obnull(button9);
            obnull(button23);
            obnull(button24);
            obnull(button25);
            obnull(button7);
            obnull(button2);
            obnull(button3);
            obnull(button5);

            obnull(button21);
            obnull(button20);
            obnull(button19);
            obnull(button18);
            obnull(button22);
            obnull(button8);
            obnull(button4);

            obnull(button11);
            obnull(button13);
            obnull(button17);
            obnull(button15);
            obnull(button29);
            obnull(button34);
            obnull(button35);
            obnull(button36);
            obnull(button37);

            obnull(button33);
            obnull(button32);
            obnull(button31);
            obnull(button30);
            obnull(button27);
            obnull(button26);
            obnull(button28);
            obnull(button14);
            obnull(button16);
            obnull(button12);
            obnull(button10);
            //--------------------------------
            button1.Visible = true;
            button38.Visible = false;

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    nxn[i, j] = 0;
                }
            }
        }

    }
}
