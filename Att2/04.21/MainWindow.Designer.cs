namespace _04._21
{
    partial class MainWindow
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
            this.trolleyadd_btn = new System.Windows.Forms.Button();
            this.mecAdd_btn = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // trolleyadd_btn
            // 
            this.trolleyadd_btn.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.trolleyadd_btn.Location = new System.Drawing.Point(1152, 12);
            this.trolleyadd_btn.Name = "trolleyadd_btn";
            this.trolleyadd_btn.Size = new System.Drawing.Size(131, 38);
            this.trolleyadd_btn.TabIndex = 0;
            this.trolleyadd_btn.Text = "Добавить троллейбус";
            this.trolleyadd_btn.UseVisualStyleBackColor = true;
            this.trolleyadd_btn.Click += new System.EventHandler(this.trolleyadd_btn_Click);
            // 
            // mecAdd_btn
            // 
            this.mecAdd_btn.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mecAdd_btn.Location = new System.Drawing.Point(1152, 56);
            this.mecAdd_btn.Name = "mecAdd_btn";
            this.mecAdd_btn.Size = new System.Drawing.Size(131, 37);
            this.mecAdd_btn.TabIndex = 1;
            this.mecAdd_btn.Text = "Добавить механика";
            this.mecAdd_btn.UseVisualStyleBackColor = true;
            this.mecAdd_btn.Click += new System.EventHandler(this.mecAdd_btn_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(13, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1133, 763);
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 10;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 787);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.mecAdd_btn);
            this.Controls.Add(this.trolleyadd_btn);
            this.Name = "MainWindow";
            this.Text = "Task4";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        
        private System.Windows.Forms.Button trolleyadd_btn;
        private System.Windows.Forms.Button mecAdd_btn;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Timer updateTimer;
    }
}

