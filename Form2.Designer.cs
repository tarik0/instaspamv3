using System.Collections.Generic;

namespace instagram_spam_bot_v3
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.metroSetLabel1 = new MetroSet_UI.Controls.MetroSetLabel();
            this.metroSetLabel2 = new MetroSet_UI.Controls.MetroSetLabel();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.metroSetLabel3 = new MetroSet_UI.Controls.MetroSetLabel();
            this.metroSetLabel4 = new MetroSet_UI.Controls.MetroSetLabel();
            this.metroSetProgressBar1 = new MetroSet_UI.Controls.MetroSetProgressBar();
            this.metroSetLabel5 = new MetroSet_UI.Controls.MetroSetLabel();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(15, 125);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(164, 244);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // metroSetLabel1
            // 
            this.metroSetLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.metroSetLabel1.Location = new System.Drawing.Point(15, 99);
            this.metroSetLabel1.Name = "metroSetLabel1";
            this.metroSetLabel1.Size = new System.Drawing.Size(120, 23);
            this.metroSetLabel1.Style = MetroSet_UI.Design.Style.Dark;
            this.metroSetLabel1.StyleManager = null;
            this.metroSetLabel1.TabIndex = 1;
            this.metroSetLabel1.Text = "Başarılı Girişler";
            this.metroSetLabel1.ThemeAuthor = "Narwin";
            this.metroSetLabel1.ThemeName = "MetroDark";
            this.metroSetLabel1.Click += new System.EventHandler(this.metroSetLabel1_Click);
            // 
            // metroSetLabel2
            // 
            this.metroSetLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.metroSetLabel2.Location = new System.Drawing.Point(194, 99);
            this.metroSetLabel2.Name = "metroSetLabel2";
            this.metroSetLabel2.Size = new System.Drawing.Size(216, 23);
            this.metroSetLabel2.Style = MetroSet_UI.Design.Style.Dark;
            this.metroSetLabel2.StyleManager = null;
            this.metroSetLabel2.TabIndex = 3;
            this.metroSetLabel2.Text = "Başarısız Girişler ve Sebepleri";
            this.metroSetLabel2.ThemeAuthor = "Narwin";
            this.metroSetLabel2.ThemeName = "MetroDark";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.HorizontalScrollbar = true;
            this.listBox2.ItemHeight = 20;
            this.listBox2.Location = new System.Drawing.Point(194, 125);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(325, 244);
            this.listBox2.TabIndex = 2;
            // 
            // metroSetLabel3
            // 
            this.metroSetLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.metroSetLabel3.Location = new System.Drawing.Point(15, 391);
            this.metroSetLabel3.Name = "metroSetLabel3";
            this.metroSetLabel3.Size = new System.Drawing.Size(137, 23);
            this.metroSetLabel3.Style = MetroSet_UI.Design.Style.Dark;
            this.metroSetLabel3.StyleManager = null;
            this.metroSetLabel3.TabIndex = 4;
            this.metroSetLabel3.Text = "Giriş Yapılan Hesap:";
            this.metroSetLabel3.ThemeAuthor = "Narwin";
            this.metroSetLabel3.ThemeName = "MetroDark";
            // 
            // metroSetLabel4
            // 
            this.metroSetLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.metroSetLabel4.Location = new System.Drawing.Point(158, 391);
            this.metroSetLabel4.Name = "metroSetLabel4";
            this.metroSetLabel4.Size = new System.Drawing.Size(361, 23);
            this.metroSetLabel4.Style = MetroSet_UI.Design.Style.Dark;
            this.metroSetLabel4.StyleManager = null;
            this.metroSetLabel4.TabIndex = 5;
            this.metroSetLabel4.Text = "KİMSE";
            this.metroSetLabel4.ThemeAuthor = "Narwin";
            this.metroSetLabel4.ThemeName = "MetroDark";
            // 
            // metroSetProgressBar1
            // 
            this.metroSetProgressBar1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.metroSetProgressBar1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.metroSetProgressBar1.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.metroSetProgressBar1.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.metroSetProgressBar1.DisabledProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetProgressBar1.Location = new System.Drawing.Point(15, 443);
            this.metroSetProgressBar1.Maximum = 100;
            this.metroSetProgressBar1.Minimum = 0;
            this.metroSetProgressBar1.Name = "metroSetProgressBar1";
            this.metroSetProgressBar1.Orientation = MetroSet_UI.Enums.ProgressOrientation.Horizontal;
            this.metroSetProgressBar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetProgressBar1.Size = new System.Drawing.Size(504, 23);
            this.metroSetProgressBar1.Style = MetroSet_UI.Design.Style.Light;
            this.metroSetProgressBar1.StyleManager = null;
            this.metroSetProgressBar1.TabIndex = 6;
            this.metroSetProgressBar1.Text = "metroSetProgressBar1";
            this.metroSetProgressBar1.ThemeAuthor = "Narwin";
            this.metroSetProgressBar1.ThemeName = "MetroLite";
            this.metroSetProgressBar1.Value = 0;
            // 
            // metroSetLabel5
            // 
            this.metroSetLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.metroSetLabel5.Location = new System.Drawing.Point(15, 417);
            this.metroSetLabel5.Name = "metroSetLabel5";
            this.metroSetLabel5.Size = new System.Drawing.Size(504, 23);
            this.metroSetLabel5.Style = MetroSet_UI.Design.Style.Dark;
            this.metroSetLabel5.StyleManager = null;
            this.metroSetLabel5.TabIndex = 7;
            this.metroSetLabel5.Text = "İlerleme Yüzdesi";
            this.metroSetLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroSetLabel5.ThemeAuthor = "Narwin";
            this.metroSetLabel5.ThemeName = "MetroDark";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(534, 481);
            this.Controls.Add(this.metroSetLabel5);
            this.Controls.Add(this.metroSetProgressBar1);
            this.Controls.Add(this.metroSetLabel4);
            this.Controls.Add(this.metroSetLabel3);
            this.Controls.Add(this.metroSetLabel2);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.metroSetLabel1);
            this.Controls.Add(this.listBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Style = MetroSet_UI.Design.Style.Dark;
            this.Text = "Giriş Yapılıyor!";
            this.TextColor = System.Drawing.Color.White;
            this.ThemeName = "MetroDark";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Shown += new System.EventHandler(this.Form2_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private MetroSet_UI.Controls.MetroSetLabel metroSetLabel1;
        private MetroSet_UI.Controls.MetroSetLabel metroSetLabel2;
        private System.Windows.Forms.ListBox listBox2;
        private MetroSet_UI.Controls.MetroSetLabel metroSetLabel3;
        private MetroSet_UI.Controls.MetroSetLabel metroSetLabel4;
        private MetroSet_UI.Controls.MetroSetProgressBar metroSetProgressBar1;
        private MetroSet_UI.Controls.MetroSetLabel metroSetLabel5;
    }
}