namespace Gr5
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.glControl = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.DrawFigure = new System.Windows.Forms.Button();
            this.RotateButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // glControl
            // 
            this.glControl.AccumBits = ((byte)(0));
            this.glControl.AutoCheckErrors = false;
            this.glControl.AutoFinish = false;
            this.glControl.AutoMakeCurrent = true;
            this.glControl.AutoSwapBuffers = true;
            this.glControl.BackColor = System.Drawing.Color.White;
            this.glControl.ColorBits = ((byte)(32));
            this.glControl.DepthBits = ((byte)(16));
            this.glControl.Location = new System.Drawing.Point(349, 12);
            this.glControl.Name = "glControl";
            this.glControl.Size = new System.Drawing.Size(1132, 849);
            this.glControl.StencilBits = ((byte)(0));
            this.glControl.TabIndex = 0;
            // 
            // DrawFigure
            // 
            this.DrawFigure.Location = new System.Drawing.Point(12, 12);
            this.DrawFigure.Name = "DrawFigure";
            this.DrawFigure.Size = new System.Drawing.Size(331, 77);
            this.DrawFigure.TabIndex = 1;
            this.DrawFigure.Text = "Загрузить фигуру ( Q )";
            this.DrawFigure.UseVisualStyleBackColor = true;
            this.DrawFigure.Click += new System.EventHandler(this.DrawFigure_Click);
            // 
            // RotateButton
            // 
            this.RotateButton.Location = new System.Drawing.Point(12, 95);
            this.RotateButton.Name = "RotateButton";
            this.RotateButton.Size = new System.Drawing.Size(331, 77);
            this.RotateButton.TabIndex = 2;
            this.RotateButton.Text = "Вращать ( R )";
            this.RotateButton.UseVisualStyleBackColor = true;
            this.RotateButton.Click += new System.EventHandler(this.RotateButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(331, 77);
            this.button1.TabIndex = 3;
            this.button1.Text = "Передвигать ( W A S D)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 261);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(331, 77);
            this.button2.TabIndex = 4;
            this.button2.Text = "Масштабировать ( Z X )";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1493, 873);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.RotateButton);
            this.Controls.Add(this.DrawFigure);
            this.Controls.Add(this.glControl);
            this.Name = "Form1";
            this.Text = "Lab5";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl glControl;
        private System.Windows.Forms.Button DrawFigure;
        private System.Windows.Forms.Button RotateButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

