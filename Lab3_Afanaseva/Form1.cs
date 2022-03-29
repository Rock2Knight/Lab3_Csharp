using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// для работы с библиотекой OpenGL 
using Tao.OpenGl;
// для работы с библиотекой FreeGLUT 
using Tao.FreeGlut;
// для работы с элементом управления SimpleOpenGLControl 
using Tao.Platform.Windows;

namespace Lab3_Afanaseva
{
    public partial class Form1 : Form
    {
        // размеры окна 
        double ScreenW, ScreenH;

        // отношения сторон окна визуализации 
        // для корректного перевода координат мыши в координаты, 
        // принятые в программе 

        private float devX;
        private float devY;

        // массив, который будет хранить значения x,y точек графика 
        private float[,] GrapValuesArray;
        // количество элементов в массиве 
        private int elements_count = 0;

        // флаг, означающий, что массив с значениями координат графика пока еще не заполнен 
        private bool not_calculate = true;

        // номер ячейки массива, из которой будут взяты координаты для красной точки 
        // для визуализации текущего кадра 
        private int pointPosition = 0;

        //Массив цветов
        private Color[] colors = new Color[6];

        // вспомогательные переменные для построения линий от курсора мыши к координатным осям 
        float lineX, lineY;

        //Переменные для минимальных и максимальных значений по X и Y
        float xmin = -15.0f, ymin = -15.0f, xmax = 15.0f, ymax = 15.0f;

        // текущение координаты курсора мыши 
        float Mcoord_X = 0, Mcoord_Y = 0;

        string xmin_txt = "-15", ymin_txt = "-15", xmax_txt = "15", ymax_txt = "15";

        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // инициализация библиотеки glut 
            Glut.glutInit();
            // инициализация режима экрана 
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);

            // установка цвета очистки экрана (RGBA) 
            Gl.glClearColor(255, 255, 255, 1);

            // установка порта вывода 
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

            // активация проекционной матрицы 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            // очистка матрицы 
            Gl.glLoadIdentity();

            textBox1.Text = xmin_txt;
            textBox2.Text = xmax_txt;
            textBox3.Text = ymin_txt;
            textBox4.Text = ymax_txt;

            // определение параметров настройки проекции в зависимости от размеров сторон элемента AnT. 
            if ((float)AnT.Width <= (float)AnT.Height)
            {
                ScreenW = 30;
                ScreenH = 30.0 * (float)AnT.Height / (float)AnT.Width;
                Glu.gluOrtho2D(0.0, ScreenW, 0.0, ScreenH);
            }
            else
            {
                ScreenW = 30.0 * (float)AnT.Width / (float)AnT.Height;
                ScreenH = 30.0;
                Glu.gluOrtho2D(0.0, 30.0 * (float)AnT.Width / (float)AnT.Height, 0.0, 30.0);
            }

            // сохранение коэффициентов, которые нам необходимы для перевода координат указателя в оконной системе в координаты, 
            // принятые в нашей OpenGL сцене 
            devX = (float)ScreenW / (float)AnT.Width;
            devY = (float)ScreenH / (float)AnT.Height;

            // установка объектно-видовой матрицы 
            Gl.glMatrixMode(Gl.GL_MODELVIEW);

            // старт счетчика, отвечающего за вызов функции визуализации сцены 
            PointInGrap.Start();

        }

        private void chooseFunc(object sender, EventArgs e)
        {

        }

        private void choose_color(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            if (comboBox1.SelectedText == "График") colors[0] = colorDialog1.Color;
            else if (comboBox1.SelectedText == "Оси") colors[1] = colorDialog1.Color;
            else if (comboBox1.SelectedText == "Сетка точек") colors[2] = colorDialog1.Color;
            else if (comboBox1.SelectedText == "Точка") colors[3] = colorDialog1.Color;
            else if (comboBox1.SelectedText == "Линии курсора") colors[4] = colorDialog1.Color;
            else if (comboBox1.SelectedText == "Подпись координат") colors[5] = colorDialog1.Color;
        }

        private void AnT_MouseMove(object sender, MouseEventArgs e)
        {
            // сохраняем координаты мыши 
            Mcoord_X = e.X;
            Mcoord_Y = e.Y;

            // вычисляем параметры для будущей дорисовки линий от указателя мыши к координатным осям. 
            lineX = devX * e.X;
            lineY = (float)(ScreenH - devY * e.Y);

        }

        // функция визуализации текста 
        private void PrintText2D(float x, float y, string text)
        {

            // устанавливаем позицию вывода растровых символов 
            // в переданных координатах x и y. 
            Gl.glRasterPos2f(x, y);

            // в цикле foreach перебираем значения из массива text, 
            // который содержит значение строки для визуализации 
            foreach (char char_for_draw in text)
            {
                // символ C визуализируем с помощью функции glutBitmapCharacter, используя шрифт GLUT_BITMAP_9_BY_15. 
                Glut.glutBitmapCharacter(Glut.GLUT_BITMAP_9_BY_15, char_for_draw);
            }

        }

        private void draw_click(object sender, EventArgs e)
        {
            xmin = (float)Convert.ToDouble(textBox1.Text);
            xmax = (float)Convert.ToDouble(textBox2.Text);
            ymin = (float)Convert.ToDouble(textBox3.Text);
            ymax = (float)Convert.ToDouble(textBox4.Text);

            Draw();
            DrawDiagram();
        }

        // функция, производящая вычисления координат графика 
        // и заносящая их в массив GrapValuesArray 
        private void functionCalculation()
        {

            // определение локальных переменных X и Y 
            float x = 0, y = 0;

            // инициализация массива, который будет хранить значение 300 точек, 
            // из которых будет состоять график 

            GrapValuesArray = new float[300, 2];

            // счетчик элементов массива 
            elements_count = 0;

            // вычисления всех значений y для x, принадлежащего промежутку от -15 до 15 с шагом в 0.01f 
            for (x = xmin; x < xmax; x += 0.1f)
            {
                // вычисление y для текущего x 
                // по формуле y = (float)Math.Sin(x)*3 + 1; 
                // эта строка задает формулу, описывающую график функции для нашего уравнения y = f(x). 
                y = (float)Math.Sin(x) * 3 + 1;

                // запись координаты x 
                GrapValuesArray[elements_count, 0] = x;
                // запись координаты y 
                GrapValuesArray[elements_count, 1] = y;
                // подсчет элементов 
                elements_count++;

            }

            // изменяем флаг, сигнализировавший о том, что координаты графика не вычислены 
            not_calculate = false;

        }

        private void X_min_label_Click(object sender, EventArgs e)
        {

        }

        private void X_min_text(object sender, EventArgs e)
        {
        }

        // визуализация графика 
        private void DrawDiagram()
        {

            // проверка флага, сигнализирующего о том, что координаты графика вычислены 
            if (not_calculate)
            {
                // если нет, то вызываем функцию вычисления координат графика 
                functionCalculation();
            }

            // стартуем отрисовку в режиме визуализации точек 
            // объединяемых в линии (GL_LINE_STRIP) 
            Gl.glBegin(Gl.GL_LINE_STRIP);

            Gl.glColor3ub(colors[0].R, colors[0].G, colors[0].B);

            // рисуем начальную точку 
            Gl.glVertex2d(GrapValuesArray[0, 0], GrapValuesArray[0, 1]);

            // проходим по массиву с координатами вычисленных точек 
            for (int ax = 1; ax < elements_count; ax += 2)
            {
                // передаем в OpenGL информацию о вершине, участвующей в построении линий 
                Gl.glVertex2d(GrapValuesArray[ax, 0], GrapValuesArray[ax, 1]);
            }

            // завершаем режим рисования 
            Gl.glEnd();
            // устанавливаем размер точек, равный 5 пикселям 
            Gl.glPointSize(5);
            // устанавливаем текущим цветом - красный цвет 
            Gl.glColor3ub(colors[3].R, colors[3].G, colors[3].B);
            // активируем режим вывода точек (GL_POINTS) 
            Gl.glBegin(Gl.GL_POINTS);
            // выводим красную точку, используя ту ячейку массива, до которой мы дошли (вычисляется в функции обработчике событий таймера) 
            Gl.glVertex2d(GrapValuesArray[pointPosition, 0], GrapValuesArray[pointPosition, 1]);
            // завершаем режим рисования 
            Gl.glEnd();
            // устанавливаем размер точек равный единице 
            Gl.glPointSize(1);

        }

        // функция, управляющая визуализацией сцены 
        private void Draw()
        {

            // очистка буфера цвета и буфера глубины 
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            // очищение текущей матрицы 
            Gl.glLoadIdentity();

            // установка черного цвета 
            Gl.glColor3f(0, 0, 0);

            // помещаем состояние матрицы в стек матриц 
            Gl.glPushMatrix();

            // выполняем перемещение в пространстве по осям X и Y 
            Gl.glTranslated(15, 15, 0);

            // активируем режим рисования (Указанные далее точки будут выводиться как точки GL_POINTS) 
            Gl.glBegin(Gl.GL_POINTS);
            Gl.glColor3ub(colors[2].R, colors[2].G, colors[2].B);

            // с помощью прохода вдумя циклами, создаем сетку из точек 
            for (float ax = xmin; ax < xmax; ax+=1.0f)
            {
                for (float bx = ymin; bx < ymax; bx+=1.0f)
                {
                    // вывод точки 
                    Gl.glVertex2d(ax, bx);
                }
            }

            // завершение режима рисования примитивов 
            Gl.glEnd();

            // активируем режим рисования, каждые 2 последовательно вызванные команды glVertex 
            // объединяются в линии 
            Gl.glBegin(Gl.GL_LINES);

            Gl.glColor3ub(colors[1].R, colors[1].G, colors[1].B);
            // далее мы рисуем координатные оси и стрелки на их концах 
            Gl.glVertex2f(0, ymin);
            Gl.glVertex2f(0, ymax);

            Gl.glVertex2f(xmin, 0);
            Gl.glVertex2f(xmax, 0);

            // вертикальная стрелка 
            Gl.glVertex2d(0, ymax);
            Gl.glVertex2d(0.1, ymax-0.5f);
            Gl.glVertex2d(0, ymax);
            Gl.glVertex2d(-0.1, ymax-0.5f);

            // горизонтальная трелка 
            Gl.glVertex2d(xmax, 0);
            Gl.glVertex2d(xmax-1.0f, 0.1);
            Gl.glVertex2d(xmax, 0);
            Gl.glVertex2d(xmax-0.5f, -0.1);

            // завершаем режим рисования 
            Gl.glEnd();

            // выводим подписи осей "x" и "y" 
            PrintText2D(15.5f, 0, "x");
            PrintText2D(0.5f, 14.5f, "y");

            // вызываем функцию рисования графика 
            DrawDiagram();

            // возвращаем матрицу из стека 
            Gl.glPopMatrix();

            Gl.glColor3ub(colors[5].R, colors[5].G, colors[5].B);

            // выводим текст со значением координат возле курсора 
            PrintText2D(devX * Mcoord_X + 0.2f, (float)ScreenH - devY * Mcoord_Y + 0.4f, 
                "[ x: " + (devX * Mcoord_X - 15).ToString() + " ; y: " + ((float)ScreenH - devY * Mcoord_Y - 15).ToString() + "]");

            // устанавливаем красный цвет 
            Gl.glColor3ub(colors[4].R, colors[4].G, colors[4].B);

            // включаем режим рисования линий, для того чтобы нарисовать 
            // линии от курсора мыши к координатным осям 
            Gl.glBegin(Gl.GL_LINES);

            Gl.glVertex2d(lineX, ymax);
            Gl.glVertex2d(lineX, lineY);
            Gl.glVertex2d(xmax, lineY);
            Gl.glVertex2d(lineX, lineY);

            Gl.glEnd();

            // дожидаемся завершения визуализации кадра 
            Gl.glFlush();

            // сигнал для обновление элемента реализующего визуализацию. 
            AnT.Invalidate();

        }

        private void PointInGrap_Tick(object sender, EventArgs e)
        {
            // если мы дошли до последнего элемента массива 
            if (pointPosition == elements_count - 1)
                pointPosition = 0; // переходим к начальному элементу 

            // функция визуализации 
            Draw();


            // переход к следующему элементу массива 
            pointPosition++;

        }

    }

}
