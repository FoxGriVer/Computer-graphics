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

namespace Gr6
{
    public partial class Form1 : Form
    {
        double positionX = 0, positionY = 0, angle = 0, scale = 1;
        public int imageId;
        public uint mGlTextureObject;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            glControl.InitializeContexts();
            mGlTextureObject = 0;
            imageId = 0;
            positionX = 0;
            positionY = 0;
            Gl.glClearColor(255, 255, 255, 1);
            DrawMethod();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);  // инициализация режима экрана 

            Il.ilInit();                // инициализация библиотеки openIL 
            Il.ilEnable(Il.IL_ORIGIN_SET);

            Gl.glClearColor(255, 255, 255, 1);             // установка цвета очистки экрана (RGBA) 
            Gl.glViewport(0, 0, glControl.Width, glControl.Height);             // установка порта вывода 

            Gl.glMatrixMode(Gl.GL_PROJECTION);            // активация проекционной матрицы 
            Gl.glLoadIdentity();            // очистка матрицы 
            Glu.gluPerspective(45, (float)glControl.Width / (float)glControl.Height, 0.1, 200);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);            // установка объектно-видовой матрицы 
            Gl.glLoadIdentity();

            Gl.glEnable(Gl.GL_DEPTH_TEST);             // начальные настройки OpenGL                 

            Lightning();
            //FogEffect();
        }

        public void DrawMethod()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();
            Gl.glClearColor(255, 255, 255, 1);
            // включаем режим текстурирования 
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            // включаем режим текстурирования, указывая идентификатор mGlTextureObject 
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextureObject);

            Gl.glPushMatrix();

            Gl.glTranslated(positionX, positionY, -7);
            Gl.glScaled(scale, scale, scale);
            Gl.glRotated(angle, 1, 0, 1);

            InitOurFigure();
           
            Gl.glPopMatrix();
            // отключаем режим текстурирования 
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            glControl.Invalidate();

        }

        private void TextureMethod()
        {
            // создаем изображение с идентификатором imageId 
            Il.ilGenImages(1, out imageId);
            // делаем изображение текущим 
            Il.ilBindImage(imageId);

            // адрес изображения  
            string url = @"C:\Users\Pavel\Documents\Visual Studio 2015\Projects\Gr6\Gr6\bin\Debug\space.jpg";
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
                // очищаем память 
                Il.ilDeleteImages(1, ref imageId);
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

        public void Lightning()
        {
            Gl.glDisable(Gl.GL_ALPHA_TEST);
            Gl.glDisable(Gl.GL_BLEND);
            Gl.glDisable(Gl.GL_FOG);

            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            var ambient = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, ambient);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            Gl.glColorMaterial(Gl.GL_FRONT, Gl.GL_AMBIENT);
        }

        public void FogEffect()
        {                    
            Gl.glDisable(Gl.GL_ALPHA_TEST);
            Gl.glDisable(Gl.GL_BLEND);

            Gl.glEnable(Gl.GL_ALPHA_TEST);
            Gl.glEnable(Gl.GL_FOG);
            float[] fog_color = { 0.5f, 0.5f, 0.5f, 1f };
            Gl.glFogfv(Gl.GL_FOG_COLOR, fog_color);
            Gl.glFogi(Gl.GL_FOG_MODE, Gl.GL_LINEAR);
            Gl.glFogf(Gl.GL_FOG_START, 3.0f);
            Gl.glFogf(Gl.GL_FOG_END, 10.0f);
        }

        public void TransparencyEffect()
        {
            Gl.glDisable(Gl.GL_FOG);
            Gl.glDisable(Gl.GL_ALPHA_TEST);
            Gl.glDisable(Gl.GL_BLEND);

            Gl.glEnable(Gl.GL_ALPHA_TEST);
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
            //Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
            Gl.glColor4d(0, 0, 0, 0.3);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Q)
            {
                TransparencyEffect();
            }
            if (e.KeyData == Keys.E)
            {
                FogEffect();
            }
            if (e.KeyData == Keys.V)
            {
                Lightning();
            }
            if (e.KeyData == Keys.D)
            {
                positionX += 1;
            }
            if (e.KeyData == Keys.A)
            {
                positionX -= 1;
            }
            if (e.KeyData == Keys.W)
            {
                positionY += 1;
            }
            if (e.KeyData == Keys.S)
            {
                positionY -= 1;
            }
            if (e.KeyData == Keys.R)
            {
                angle += 2;
            }
            if (e.KeyData == Keys.Z)
            {
                scale += 0.1;
            }
            if (e.KeyData == Keys.X)
            {
                scale -= 0.1;
            }

            //DrawMethod();
            //TextureMethod();
        }

        public void InitOurFigure()
        {                        
            Gl.glBegin(Gl.GL_TRIANGLES);

            float x = -1, y = -2, z = 2;
            float len = 1.5f;
            float[] a = { x, y, z }; 
            float[] b = { x, y + len, z };
            float[] c = { x + len, y + len, z };
            float[] d = { 0, 0, -1 };            

            Gl.glNormal3f(0.0f, 0.0f, 1.0f);
            Gl.glVertex3d(a[0], a[1], a[2]);
            Gl.glTexCoord2f(0.0f, 0.0f);
            Gl.glVertex3d(b[0], b[1], b[2]);
            Gl.glTexCoord2f(1.0f, 0.0f);
            Gl.glVertex3d(c[0], c[1], c[2]);
            Gl.glTexCoord2f(0.0f, 1.0f);

            Gl.glColor4d(0.0, 0.0, 0.0, 0.1);
            Gl.glNormal3f(0.0f, 0.0f, 1.0f);
            Gl.glVertex3d(a[0], a[1], a[2]);
            Gl.glTexCoord2f(0.0f, 0.0f);
            Gl.glVertex3d(b[0], b[1], b[2]);
            Gl.glTexCoord2f(1.0f, 0.0f);
            Gl.glVertex3d(d[0], d[1], d[2]);
            Gl.glTexCoord2f(0.0f, 1.0f);

            Gl.glNormal3f(0.0f, 0.0f, 1.0f);
            Gl.glVertex3d(c[0], c[1], c[2]);
            Gl.glTexCoord2f(0.0f, 0.0f);
            Gl.glVertex3d(b[0], b[1], b[2]);
            Gl.glTexCoord2f(1.0f, 0.0f);
            Gl.glVertex3d(d[0], d[1], d[2]);
            Gl.glTexCoord2f(0.0f, 1.0f);            

            Gl.glNormal3f(0.0f, 0.0f, 1.0f);
            Gl.glVertex3d(c[0], c[1], c[2]);
            Gl.glTexCoord2f(0.0f, 0.0f);
            Gl.glVertex3d(a[0], a[1], a[2]);
            Gl.glTexCoord2f(1.0f, 0.0f);
            Gl.glVertex3d(d[0], d[1], d[2]);
            Gl.glTexCoord2f(0.0f, 1.0f);

            Gl.glEnd();           
        }
    }
}
