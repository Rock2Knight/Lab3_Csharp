namespace Lab3_Afanaseva
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
            this.components = new System.ComponentModel.Container();
            this.AnT = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.PointInGrap = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.XminLabel = new System.Windows.Forms.Label();
            this.drawButton = new System.Windows.Forms.Button();
            this.XmaxLabel = new System.Windows.Forms.Label();
            this.YminLabel = new System.Windows.Forms.Label();
            this.YmaxLabel = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.functions = new System.Windows.Forms.ComboBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // AnT
            // 
            this.AnT.AccumBits = ((byte)(0));
            this.AnT.AutoCheckErrors = false;
            this.AnT.AutoFinish = false;
            this.AnT.AutoMakeCurrent = true;
            this.AnT.AutoSwapBuffers = true;
            this.AnT.BackColor = System.Drawing.Color.Black;
            this.AnT.ColorBits = ((byte)(32));
            this.AnT.DepthBits = ((byte)(16));
            this.AnT.Location = new System.Drawing.Point(2, 32);
            this.AnT.Name = "AnT";
            this.AnT.Size = new System.Drawing.Size(996, 585);
            this.AnT.StencilBits = ((byte)(0));
            this.AnT.TabIndex = 0;
            this.AnT.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AnT_MouseMove);
            // 
            // PointInGrap
            // 
            this.PointInGrap.Tick += new System.EventHandler(this.PointInGrap_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1129, 82);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(114, 22);
            this.textBox1.TabIndex = 1;
            // 
            // XminLabel
            // 
            this.XminLabel.AutoSize = true;
            this.XminLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.XminLabel.ForeColor = System.Drawing.Color.Maroon;
            this.XminLabel.Location = new System.Drawing.Point(1036, 84);
            this.XminLabel.Name = "XminLabel";
            this.XminLabel.Size = new System.Drawing.Size(57, 20);
            this.XminLabel.TabIndex = 2;
            this.XminLabel.Text = "X min";
            this.XminLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // drawButton
            // 
            this.drawButton.Location = new System.Drawing.Point(1032, 257);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(210, 23);
            this.drawButton.TabIndex = 3;
            this.drawButton.Text = " Нарисовать";
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.draw_click);
            // 
            // XmaxLabel
            // 
            this.XmaxLabel.AutoSize = true;
            this.XmaxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.XmaxLabel.ForeColor = System.Drawing.Color.Maroon;
            this.XmaxLabel.Location = new System.Drawing.Point(1036, 114);
            this.XmaxLabel.Name = "XmaxLabel";
            this.XmaxLabel.Size = new System.Drawing.Size(61, 20);
            this.XmaxLabel.TabIndex = 4;
            this.XmaxLabel.Text = "X max";
            this.XmaxLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // YminLabel
            // 
            this.YminLabel.AutoSize = true;
            this.YminLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.YminLabel.ForeColor = System.Drawing.Color.Maroon;
            this.YminLabel.Location = new System.Drawing.Point(1036, 147);
            this.YminLabel.Name = "YminLabel";
            this.YminLabel.Size = new System.Drawing.Size(56, 20);
            this.YminLabel.TabIndex = 5;
            this.YminLabel.Text = "Y min";
            this.YminLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // YmaxLabel
            // 
            this.YmaxLabel.AutoSize = true;
            this.YmaxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.YmaxLabel.ForeColor = System.Drawing.Color.Maroon;
            this.YmaxLabel.Location = new System.Drawing.Point(1037, 178);
            this.YmaxLabel.Name = "YmaxLabel";
            this.YmaxLabel.Size = new System.Drawing.Size(60, 20);
            this.YmaxLabel.TabIndex = 6;
            this.YmaxLabel.Text = "Y max";
            this.YmaxLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1129, 112);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(114, 22);
            this.textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(1129, 147);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(114, 22);
            this.textBox3.TabIndex = 8;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(1129, 178);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(114, 22);
            this.textBox4.TabIndex = 9;
            // 
            // functions
            // 
            this.functions.FormattingEnabled = true;
            this.functions.Items.AddRange(new object[] {
            "SIN",
            "COS",
            "TAN"});
            this.functions.Location = new System.Drawing.Point(1040, 32);
            this.functions.Name = "functions";
            this.functions.Size = new System.Drawing.Size(202, 24);
            this.functions.TabIndex = 10;
            this.functions.Text = "SIN";
            this.functions.SelectedIndexChanged += new System.EventHandler(this.chooseFunc);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Оси",
            "Точки",
            "График",
            "Сетка точек",
            "Линии курсора",
            "Подписи курсора"});
            this.comboBox1.Location = new System.Drawing.Point(1032, 221);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(211, 24);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.choose_color);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 707);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.functions);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.YmaxLabel);
            this.Controls.Add(this.YminLabel);
            this.Controls.Add(this.XmaxLabel);
            this.Controls.Add(this.drawButton);
            this.Controls.Add(this.XminLabel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.AnT);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl AnT;
        private System.Windows.Forms.Timer PointInGrap;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label XminLabel;
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.Label XmaxLabel;
        private System.Windows.Forms.Label YminLabel;
        private System.Windows.Forms.Label YmaxLabel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ComboBox functions;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

