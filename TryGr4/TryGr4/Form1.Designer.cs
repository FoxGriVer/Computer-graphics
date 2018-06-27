using System;

namespace TryGr4
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButtonViewX = new System.Windows.Forms.RadioButton();
            this.radioButtonViewY = new System.Windows.Forms.RadioButton();
            this.radioButtonViewZ = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxScaleZ = new System.Windows.Forms.TextBox();
            this.textBoxScaleY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelScaleY = new System.Windows.Forms.Label();
            this.textBoxScaleX = new System.Windows.Forms.TextBox();
            this.labelScaleX = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonStartForm = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxMoveZ = new System.Windows.Forms.TextBox();
            this.textBoxMoveY = new System.Windows.Forms.TextBox();
            this.buttonMove = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMoveX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonRotate = new System.Windows.Forms.Button();
            this.radioButtonRotateY = new System.Windows.Forms.RadioButton();
            this.radioButtonRotateX = new System.Windows.Forms.RadioButton();
            this.radioButtonRotateZ = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(372, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1400, 1339);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 197);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(330, 64);
            this.button1.TabIndex = 2;
            this.button1.Text = "Маштабировать ( Q )";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButtonViewX
            // 
            this.radioButtonViewX.AutoSize = true;
            this.radioButtonViewX.Location = new System.Drawing.Point(6, 35);
            this.radioButtonViewX.Name = "radioButtonViewX";
            this.radioButtonViewX.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.radioButtonViewX.Size = new System.Drawing.Size(71, 33);
            this.radioButtonViewX.TabIndex = 5;
            this.radioButtonViewX.TabStop = true;
            this.radioButtonViewX.Text = "X";
            this.radioButtonViewX.UseVisualStyleBackColor = true;
            // 
            // radioButtonViewY
            // 
            this.radioButtonViewY.AutoSize = true;
            this.radioButtonViewY.Location = new System.Drawing.Point(6, 74);
            this.radioButtonViewY.Name = "radioButtonViewY";
            this.radioButtonViewY.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.radioButtonViewY.Size = new System.Drawing.Size(70, 33);
            this.radioButtonViewY.TabIndex = 6;
            this.radioButtonViewY.TabStop = true;
            this.radioButtonViewY.Text = "Y";
            this.radioButtonViewY.UseVisualStyleBackColor = true;
            // 
            // radioButtonViewZ
            // 
            this.radioButtonViewZ.AutoSize = true;
            this.radioButtonViewZ.Location = new System.Drawing.Point(6, 113);
            this.radioButtonViewZ.Name = "radioButtonViewZ";
            this.radioButtonViewZ.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.radioButtonViewZ.Size = new System.Drawing.Size(68, 33);
            this.radioButtonViewZ.TabIndex = 7;
            this.radioButtonViewZ.TabStop = true;
            this.radioButtonViewZ.Text = "Z";
            this.radioButtonViewZ.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxScaleZ);
            this.groupBox1.Controls.Add(this.textBoxScaleY);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.labelScaleY);
            this.groupBox1.Controls.Add(this.textBoxScaleX);
            this.groupBox1.Controls.Add(this.labelScaleX);
            this.groupBox1.Location = new System.Drawing.Point(12, 193);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.groupBox1.Size = new System.Drawing.Size(354, 267);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры маштабирвоания";
            // 
            // textBoxScaleZ
            // 
            this.textBoxScaleZ.Location = new System.Drawing.Point(282, 144);
            this.textBoxScaleZ.Name = "textBoxScaleZ";
            this.textBoxScaleZ.Size = new System.Drawing.Size(66, 35);
            this.textBoxScaleZ.TabIndex = 5;
            this.textBoxScaleZ.Text = "1";
            // 
            // textBoxScaleY
            // 
            this.textBoxScaleY.Location = new System.Drawing.Point(282, 99);
            this.textBoxScaleY.Name = "textBoxScaleY";
            this.textBoxScaleY.Size = new System.Drawing.Size(66, 35);
            this.textBoxScaleY.TabIndex = 3;
            this.textBoxScaleY.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(260, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Маштабировать по Z:";
            // 
            // labelScaleY
            // 
            this.labelScaleY.AutoSize = true;
            this.labelScaleY.Location = new System.Drawing.Point(13, 109);
            this.labelScaleY.Name = "labelScaleY";
            this.labelScaleY.Size = new System.Drawing.Size(262, 29);
            this.labelScaleY.TabIndex = 2;
            this.labelScaleY.Text = "Маштабировать по Y:";
            // 
            // textBoxScaleX
            // 
            this.textBoxScaleX.Location = new System.Drawing.Point(282, 52);
            this.textBoxScaleX.Name = "textBoxScaleX";
            this.textBoxScaleX.Size = new System.Drawing.Size(66, 35);
            this.textBoxScaleX.TabIndex = 1;
            this.textBoxScaleX.Text = "1";
            // 
            // labelScaleX
            // 
            this.labelScaleX.AutoSize = true;
            this.labelScaleX.Location = new System.Drawing.Point(13, 68);
            this.labelScaleX.Name = "labelScaleX";
            this.labelScaleX.Size = new System.Drawing.Size(263, 29);
            this.labelScaleX.TabIndex = 0;
            this.labelScaleX.Text = "Маштабировать по X:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonViewY);
            this.groupBox2.Controls.Add(this.radioButtonViewX);
            this.groupBox2.Controls.Add(this.radioButtonViewZ);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(354, 175);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Плоскость проекции";
            // 
            // buttonStartForm
            // 
            this.buttonStartForm.Location = new System.Drawing.Point(12, 1118);
            this.buttonStartForm.Name = "buttonStartForm";
            this.buttonStartForm.Size = new System.Drawing.Size(354, 64);
            this.buttonStartForm.TabIndex = 10;
            this.buttonStartForm.Text = "Исходная форма ( R )";
            this.buttonStartForm.UseVisualStyleBackColor = true;
            this.buttonStartForm.Click += new System.EventHandler(this.buttonStartForm_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxMoveZ);
            this.groupBox3.Controls.Add(this.textBoxMoveY);
            this.groupBox3.Controls.Add(this.buttonMove);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.textBoxMoveX);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(12, 480);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.groupBox3.Size = new System.Drawing.Size(354, 267);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Параметры перемещения";
            // 
            // textBoxMoveZ
            // 
            this.textBoxMoveZ.Location = new System.Drawing.Point(282, 144);
            this.textBoxMoveZ.Name = "textBoxMoveZ";
            this.textBoxMoveZ.Size = new System.Drawing.Size(66, 35);
            this.textBoxMoveZ.TabIndex = 5;
            this.textBoxMoveZ.Text = "0";
            // 
            // textBoxMoveY
            // 
            this.textBoxMoveY.Location = new System.Drawing.Point(282, 99);
            this.textBoxMoveY.Name = "textBoxMoveY";
            this.textBoxMoveY.Size = new System.Drawing.Size(66, 35);
            this.textBoxMoveY.TabIndex = 3;
            this.textBoxMoveY.Text = "0";
            // 
            // buttonMove
            // 
            this.buttonMove.Location = new System.Drawing.Point(18, 197);
            this.buttonMove.Name = "buttonMove";
            this.buttonMove.Size = new System.Drawing.Size(330, 64);
            this.buttonMove.TabIndex = 2;
            this.buttonMove.Text = "Переместить ( W )";
            this.buttonMove.UseVisualStyleBackColor = true;
            this.buttonMove.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Переместить по Z:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Переместить по Y:";
            // 
            // textBoxMoveX
            // 
            this.textBoxMoveX.Location = new System.Drawing.Point(282, 52);
            this.textBoxMoveX.Name = "textBoxMoveX";
            this.textBoxMoveX.Size = new System.Drawing.Size(66, 35);
            this.textBoxMoveX.TabIndex = 1;
            this.textBoxMoveX.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 29);
            this.label4.TabIndex = 0;
            this.label4.Text = "Переместить по X:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonRotate);
            this.groupBox4.Controls.Add(this.radioButtonRotateY);
            this.groupBox4.Controls.Add(this.radioButtonRotateX);
            this.groupBox4.Controls.Add(this.radioButtonRotateZ);
            this.groupBox4.Location = new System.Drawing.Point(12, 764);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(354, 251);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ось вращения";
            // 
            // buttonRotate
            // 
            this.buttonRotate.Location = new System.Drawing.Point(18, 166);
            this.buttonRotate.Name = "buttonRotate";
            this.buttonRotate.Size = new System.Drawing.Size(330, 64);
            this.buttonRotate.TabIndex = 8;
            this.buttonRotate.Text = "Вращать ( E )";
            this.buttonRotate.UseVisualStyleBackColor = true;
            this.buttonRotate.Click += new System.EventHandler(this.buttonRotate_Click);
            // 
            // radioButtonRotateY
            // 
            this.radioButtonRotateY.AutoSize = true;
            this.radioButtonRotateY.Location = new System.Drawing.Point(6, 74);
            this.radioButtonRotateY.Name = "radioButtonRotateY";
            this.radioButtonRotateY.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.radioButtonRotateY.Size = new System.Drawing.Size(70, 33);
            this.radioButtonRotateY.TabIndex = 6;
            this.radioButtonRotateY.TabStop = true;
            this.radioButtonRotateY.Text = "Y";
            this.radioButtonRotateY.UseVisualStyleBackColor = true;
            // 
            // radioButtonRotateX
            // 
            this.radioButtonRotateX.AutoSize = true;
            this.radioButtonRotateX.Location = new System.Drawing.Point(6, 35);
            this.radioButtonRotateX.Name = "radioButtonRotateX";
            this.radioButtonRotateX.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.radioButtonRotateX.Size = new System.Drawing.Size(71, 33);
            this.radioButtonRotateX.TabIndex = 5;
            this.radioButtonRotateX.TabStop = true;
            this.radioButtonRotateX.Text = "X";
            this.radioButtonRotateX.UseVisualStyleBackColor = true;
            // 
            // radioButtonRotateZ
            // 
            this.radioButtonRotateZ.AutoSize = true;
            this.radioButtonRotateZ.Location = new System.Drawing.Point(6, 113);
            this.radioButtonRotateZ.Name = "radioButtonRotateZ";
            this.radioButtonRotateZ.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.radioButtonRotateZ.Size = new System.Drawing.Size(68, 33);
            this.radioButtonRotateZ.TabIndex = 7;
            this.radioButtonRotateZ.TabStop = true;
            this.radioButtonRotateZ.Text = "Z";
            this.radioButtonRotateZ.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 1035);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(354, 64);
            this.button2.TabIndex = 13;
            this.button2.Text = "Несколько действий ( S )";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1784, 1353);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.buttonStartForm);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButtonViewX;
        private System.Windows.Forms.RadioButton radioButtonViewY;
        private System.Windows.Forms.RadioButton radioButtonViewZ;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxScaleZ;
        private System.Windows.Forms.TextBox textBoxScaleY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelScaleY;
        private System.Windows.Forms.TextBox textBoxScaleX;
        private System.Windows.Forms.Label labelScaleX;
        private System.Windows.Forms.Button buttonStartForm;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxMoveZ;
        private System.Windows.Forms.TextBox textBoxMoveY;
        private System.Windows.Forms.Button buttonMove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxMoveX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonRotate;
        private System.Windows.Forms.RadioButton radioButtonRotateY;
        private System.Windows.Forms.RadioButton radioButtonRotateX;
        private System.Windows.Forms.RadioButton radioButtonRotateZ;
        private System.Windows.Forms.Button button2;
    }
}

