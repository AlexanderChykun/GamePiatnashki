namespace PiatnashkiOnWinForms
{
    partial class GameForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && (components != null) )
            {
                components.Dispose ();
            }
            base.Dispose ( disposing );
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent ()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabBegin = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.numericSize = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.grBoxGameField = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.новаяИграToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.правилаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabBegin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabBegin);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Location = new System.Drawing.Point(-4, -25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(497, 344);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Enter += new System.EventHandler(this.tabControl1_Enter);
            this.tabControl1.Leave += new System.EventHandler(this.tabControl1_Leave);
            // 
            // tabBegin
            // 
            this.tabBegin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabBegin.BackgroundImage")));
            this.tabBegin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabBegin.Controls.Add(this.button2);
            this.tabBegin.Controls.Add(this.numericSize);
            this.tabBegin.Controls.Add(this.button1);
            this.tabBegin.Controls.Add(this.label1);
            this.tabBegin.Controls.Add(this.pictureBox1);
            this.tabBegin.Location = new System.Drawing.Point(4, 22);
            this.tabBegin.Name = "tabBegin";
            this.tabBegin.Padding = new System.Windows.Forms.Padding(3);
            this.tabBegin.Size = new System.Drawing.Size(489, 318);
            this.tabBegin.TabIndex = 0;
            this.tabBegin.Text = "tabPage1";
            this.tabBegin.UseVisualStyleBackColor = true;
            this.tabBegin.Enter += new System.EventHandler(this.tabBegin_Enter);
            this.tabBegin.Resize += new System.EventHandler(this.tabBegin_Resize);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(459, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // numericSize
            // 
            this.numericSize.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.numericSize.Cursor = System.Windows.Forms.Cursors.Default;
            this.numericSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericSize.ForeColor = System.Drawing.Color.White;
            this.numericSize.Location = new System.Drawing.Point(346, 112);
            this.numericSize.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericSize.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericSize.Name = "numericSize";
            this.numericSize.Size = new System.Drawing.Size(46, 38);
            this.numericSize.TabIndex = 4;
            this.numericSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericSize.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(292, 194);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 74);
            this.button1.TabIndex = 3;
            this.toolTip1.SetToolTip(this.button1, "Начало игры");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(298, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Размер поля";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(246, 225);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage2.BackgroundImage")));
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.grBoxGameField);
            this.tabPage2.Controls.Add(this.menuStrip1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(489, 318);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Enter += new System.EventHandler(this.tabPage2_Enter);
            this.tabPage2.Leave += new System.EventHandler(this.tabPage2_Leave);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Black;
            this.button3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button3.Location = new System.Drawing.Point(460, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(29, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "X";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // grBoxGameField
            // 
            this.grBoxGameField.BackColor = System.Drawing.Color.Transparent;
            this.grBoxGameField.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.grBoxGameField.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.grBoxGameField.Location = new System.Drawing.Point(115, 30);
            this.grBoxGameField.Name = "grBoxGameField";
            this.grBoxGameField.Size = new System.Drawing.Size(242, 260);
            this.grBoxGameField.TabIndex = 1;
            this.grBoxGameField.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новаяИграToolStripMenuItem,
            this.правилаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(483, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // новаяИграToolStripMenuItem
            // 
            this.новаяИграToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.новаяИграToolStripMenuItem.Name = "новаяИграToolStripMenuItem";
            this.новаяИграToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.новаяИграToolStripMenuItem.Text = "Новая игра";
            this.новаяИграToolStripMenuItem.Click += new System.EventHandler(this.новаяИграToolStripMenuItem_Click);
            // 
            // правилаToolStripMenuItem
            // 
            this.правилаToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.правилаToolStripMenuItem.Name = "правилаToolStripMenuItem";
            this.правилаToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.правилаToolStripMenuItem.Text = "Правила";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(490, 310);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Игра \"Пятнашки\"";
            this.tabControl1.ResumeLayout(false);
            this.tabBegin.ResumeLayout(false);
            this.tabBegin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabBegin;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem новаяИграToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem правилаToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown numericSize;
        private System.Windows.Forms.GroupBox grBoxGameField;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

