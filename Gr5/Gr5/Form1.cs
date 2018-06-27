using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform;
using Tao.DevIl;

namespace Gr5
{
    public partial class Form1 : Form
    {
        double positionX, positionY;
        public int imageId;
        public uint mGlTextureObject;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            positionX = 0;
            positionY = 0;
            imageId = 0;
            mGlTextureObject = 0;
            glControl.InitializeContexts();
            Gl.glClearColor(255, 255, 255, 1);
            DrawMethod();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);   // инициализация режима экрана 

            Il.ilInit();        // инициализация библиотеки openIL
            Il.ilEnable(Il.IL_ORIGIN_SET);

            Gl.glClearColor(255,255,255,1); // установка цвета очистки экрана (RGBA)
            Gl.glViewport(0, 0, glControl.Width, glControl.Height); // установка порта вывода 

            Gl.glMatrixMode(Gl.GL_PROJECTION);      // активация проекционной матрицы 
            Gl.glLoadIdentity();                // очистка матрицы
            Glu.gluOrtho2D(0, 0, glControl.Width, glControl.Height);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);           // установка объектно-видовой матрицы
            Gl.glLoadIdentity();

            Gl.glEnable(Gl.GL_DEPTH_TEST);          // начальные настройки OpenGL 
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
        }

        private void DrawFigure_Click(object sender, EventArgs e)
        {
            
        }
        
        private void TextureMethod()
        {
            // создаем изображение с идентификатором imageId 
            Il.ilGenImages(1, out imageId);
            // делаем изображение текущим 
            Il.ilBindImage(imageId);

            // адрес изображения  
            string url = @"C:\Users\Pavel\Documents\Visual Studio 2015\Projects\Gr5\Gr5\bin\Debug\space.jpg";
            if (Il.ilLoadImage(url))
            {

                // если загрузка прошла успешно 
                // сохраняем размеры изображения 
                int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
                int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);

                // определяем число бит на пиксель 
                int bitspp = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);

                switch (bitspp) // в зависимости от полученного результата 
                {
                    // создаем текстуру, используя режим GL_RGB или GL_RGBA 
                    case 24:
                        mGlTextureObject = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), width, height);
                        break;
                    case 32:
                        mGlTextureObject = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                        break;
                }
                DrawMethod();
            }
        }

        private static uint MakeGlTexture(int Format, IntPtr pixels, int w, int h)
        {
            // идентификатор текстурного объекта 
            uint texObject;
            // генерируем текстурный объект 
            Gl.glGenTextures(1, out texObject);
            // устанавливаем режим упаковки пикселей 
            Gl.glPixelStorei(Gl.GL_UNPACK_ALIGNMENT, 1);
            // создаем привязку к только что созданной текстуре 
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texObject);
            // устанавливаем режим фильтрации и повторения текстуры 
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexEnvf(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_REPLACE);
            // создаем RGB или RGBA текстуру 
            switch (Format)
            {
                case Gl.GL_RGB:
                    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB, w, h, 0, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;

                case Gl.GL_RGBA:
                    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, w, h, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;
            }
            // возвращаем идентификатор текстурного объекта 
            return texObject;
        }

        public void DrawMethod()
        {            
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearColor(255, 255, 255, 1);

            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextureObject);               // включаем режим текстурирования, указывая идентификатор mGlTextureObject 

            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glVertex2d(0, 0.75);
            Gl.glTexCoord2f(0, (float)0.75);
            Gl.glVertex2d(0.65, 0.25);
            Gl.glTexCoord2f((float)0.65, (float)0.25);
            Gl.glVertex2d(0.4, -0.6);
            Gl.glTexCoord2f((float)0.4, (float)-0.6);
            Gl.glVertex2d(-0.4, -0.6);
            Gl.glTexCoord2f((float)-0.4, (float)-0.6);
            Gl.glVertex2d(-0.65, 0.25);
            Gl.glTexCoord2f((float)-0.65, (float)0.25);
            Gl.glEnd();


            //Gl.glBegin(Gl.GL_LINE_STRIP);

            //Gl.glVertex2d(0, 0.75);
            //Gl.glTexCoord2f(0, (float)0.75);

            //Gl.glVertex2d(0.15, 0.25);
            //Gl.glTexCoord2f((float)0.15, (float)0.25);

            //Gl.glVertex2d(0.65, 0.25);
            //Gl.glTexCoord2f((float)0.65, (float)0.25);

            //Gl.glVertex2d(0.25, -0.13);
            //Gl.glTexCoord2f((float)0.25, (float)-0.13);

            //Gl.glVertex2d(0.4, -0.6);
            //Gl.glTexCoord2f((float)0.4, (float)-0.6);

            //Gl.glVertex2d(0, -0.3);
            //Gl.glTexCoord2f(0, (float)-0.3);

            //Gl.glVertex2d(-0.4, -0.6);
            //Gl.glTexCoord2f((float)-0.4, (float)-0.6);

            //Gl.glVertex2d(-0.25, -0.13);
            //Gl.glTexCoord2f((float)-0.25, (float)-0.13);

            //Gl.glVertex2d(-0.65, 0.25);
            //Gl.glTexCoord2f((float)-0.65, (float)0.25);

            //Gl.glVertex2d(-0.15, 0.25);
            //Gl.glTexCoord2f((float)-0.15, (float)0.25);

            //Gl.glVertex2d(0, 0.75);
            //Gl.glTexCoord2f(0, (float)0.75);

            //Gl.glEnd();

            Gl.glFlush();
            Gl.glDisable(Gl.GL_TEXTURE_2D);                 // отключаем режим текстурирования 
            glControl.Invalidate();
        }

        private void RotateButton_Click(object sender, EventArgs e)
        {
            Gl.glRotated((double)15, 0, 0, 1);
            DrawMethod();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.D)
            {
                positionX += 0.1;
                Gl.glTranslated(positionX, 0, 0);
                positionX -= 0.1;
            }
            if (e.KeyData == Keys.A)
            {
                positionX += 0.1;
                Gl.glTranslated(-positionX, 0, 0);
                positionX -= 0.1;
            }
            if (e.KeyData == Keys.W)
            {
                positionY += 0.1;
                Gl.glTranslated(0, positionY, 0);
                positionY -= 0.1;
            }
            if (e.KeyData == Keys.S)
            {
                positionY += 0.1;
                Gl.glTranslated(0, -positionY, 0);
                positionY -= 0.1;
            }
            if (e.KeyData == Keys.R)
            {
                Gl.glRotated((double)15, 0, 0, 1);
            }
            if (e.KeyData == Keys.Z)
            {
                Gl.glScaled(1.1, 1.1, 1);
            }
            if (e.KeyData == Keys.X)
            {
                Gl.glScaled(0.9, 0.9, 1);
            }
            //DrawMethod();
            TextureMethod();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            positionX += 0.1;
            Gl.glTranslated(positionX, 0, 0);
            positionX -= 0.1;
            DrawMethod();
        }        
    }
}
