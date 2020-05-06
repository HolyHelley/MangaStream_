namespace MangaStream
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listViewCatalog = new System.Windows.Forms.ListView();
            this.imageListCatalog = new System.Windows.Forms.ImageList(this.components);
            this.pictureBoxPage = new System.Windows.Forms.PictureBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageListTree = new System.Windows.Forms.ImageList(this.components);
            this.lblName = new System.Windows.Forms.Label();
            this.btnToRead = new System.Windows.Forms.Button();
            this.lblAbout = new System.Windows.Forms.Label();
            this.pnlName = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlAbout = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolsItemBookMarks = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsItemDownloads = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsItemTheme = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsItemLight = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsItemDark = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsItemFun = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsItemDep = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pnlGenres = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNetCheck = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPage)).BeginInit();
            this.pnlName.SuspendLayout();
            this.pnlAbout.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pnlGenres.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewCatalog
            // 
            this.listViewCatalog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewCatalog.BackColor = System.Drawing.Color.White;
            this.listViewCatalog.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listViewCatalog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.listViewCatalog.HideSelection = false;
            this.listViewCatalog.LargeImageList = this.imageListCatalog;
            this.listViewCatalog.Location = new System.Drawing.Point(222, 31);
            this.listViewCatalog.Name = "listViewCatalog";
            this.listViewCatalog.Size = new System.Drawing.Size(882, 437);
            this.listViewCatalog.TabIndex = 0;
            this.listViewCatalog.UseCompatibleStateImageBehavior = false;
            this.listViewCatalog.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewCatalog_ItemSelectionChanged);
            this.listViewCatalog.SelectedIndexChanged += new System.EventHandler(this.listViewCatalog_SelectedIndexChanged);
            this.listViewCatalog.Click += new System.EventHandler(this.ListViewCatalog_Click);
            this.listViewCatalog.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewCatalog_MouseDown);
            this.listViewCatalog.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listViewCatalog_MouseUp);
            // 
            // imageListCatalog
            // 
            this.imageListCatalog.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListCatalog.ImageSize = new System.Drawing.Size(85, 120);
            this.imageListCatalog.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBoxPage
            // 
            this.pictureBoxPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxPage.Image = global::MangaStream6.Properties.Resources.manga_logo;
            this.pictureBoxPage.InitialImage = null;
            this.pictureBoxPage.Location = new System.Drawing.Point(813, 31);
            this.pictureBoxPage.Name = "pictureBoxPage";
            this.pictureBoxPage.Size = new System.Drawing.Size(183, 214);
            this.pictureBoxPage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPage.TabIndex = 1;
            this.pictureBoxPage.TabStop = false;
            this.pictureBoxPage.Visible = false;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.BackColor = System.Drawing.Color.White;
            this.treeView1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treeView1.LineColor = System.Drawing.Color.White;
            this.treeView1.Location = new System.Drawing.Point(12, 31);
            this.treeView1.Name = "treeView1";
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.ShowRootLines = false;
            this.treeView1.Size = new System.Drawing.Size(204, 437);
            this.treeView1.TabIndex = 2;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeView1_NodeMouseClick);
            // 
            // imageListTree
            // 
            this.imageListTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTree.ImageStream")));
            this.imageListTree.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTree.Images.SetKeyName(0, "TreeViewCursor.png");
            // 
            // lblName
            // 
            this.lblName.AutoEllipsis = true;
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblName.Location = new System.Drawing.Point(6, 24);
            this.lblName.MaximumSize = new System.Drawing.Size(250, 100);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(103, 13);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "<Название манги>";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnToRead
            // 
            this.btnToRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToRead.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnToRead.Location = new System.Drawing.Point(1022, 31);
            this.btnToRead.Name = "btnToRead";
            this.btnToRead.Size = new System.Drawing.Size(57, 49);
            this.btnToRead.TabIndex = 4;
            this.btnToRead.Text = "Читать";
            this.btnToRead.UseVisualStyleBackColor = true;
            this.btnToRead.Visible = false;
            this.btnToRead.Click += new System.EventHandler(this.BtnToRead_Click);
            // 
            // lblAbout
            // 
            this.lblAbout.AutoEllipsis = true;
            this.lblAbout.AutoSize = true;
            this.lblAbout.BackColor = System.Drawing.Color.Transparent;
            this.lblAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAbout.Location = new System.Drawing.Point(6, 20);
            this.lblAbout.MaximumSize = new System.Drawing.Size(275, 0);
            this.lblAbout.MinimumSize = new System.Drawing.Size(100, 0);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(100, 13);
            this.lblAbout.TabIndex = 7;
            this.lblAbout.Text = "<Описание>";
            // 
            // pnlName
            // 
            this.pnlName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlName.AutoScroll = true;
            this.pnlName.Controls.Add(this.label1);
            this.pnlName.Controls.Add(this.lblName);
            this.pnlName.Location = new System.Drawing.Point(813, 251);
            this.pnlName.Name = "pnlName";
            this.pnlName.Size = new System.Drawing.Size(279, 80);
            this.pnlName.TabIndex = 8;
            this.pnlName.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.MaximumSize = new System.Drawing.Size(200, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Название";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlAbout
            // 
            this.pnlAbout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAbout.AutoScroll = true;
            this.pnlAbout.Controls.Add(this.label2);
            this.pnlAbout.Controls.Add(this.lblAbout);
            this.pnlAbout.Location = new System.Drawing.Point(813, 337);
            this.pnlAbout.Name = "pnlAbout";
            this.pnlAbout.Size = new System.Drawing.Size(279, 153);
            this.pnlAbout.TabIndex = 9;
            this.pnlAbout.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.MaximumSize = new System.Drawing.Size(200, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Описание";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolsItemBookMarks,
            this.ToolsItemDownloads,
            this.ToolsItemSettings});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1104, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolsItemBookMarks
            // 
            this.ToolsItemBookMarks.Name = "ToolsItemBookMarks";
            this.ToolsItemBookMarks.Size = new System.Drawing.Size(70, 20);
            this.ToolsItemBookMarks.Text = "Закладки";
            this.ToolsItemBookMarks.Click += new System.EventHandler(this.ЗакладкиToolStripMenuItem_Click);
            // 
            // ToolsItemDownloads
            // 
            this.ToolsItemDownloads.Name = "ToolsItemDownloads";
            this.ToolsItemDownloads.Size = new System.Drawing.Size(127, 20);
            this.ToolsItemDownloads.Text = "Загруженная манга";
            this.ToolsItemDownloads.Click += new System.EventHandler(this.ЗагруженнаяМангаToolStripMenuItem_Click);
            // 
            // ToolsItemSettings
            // 
            this.ToolsItemSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolsItemTheme});
            this.ToolsItemSettings.Name = "ToolsItemSettings";
            this.ToolsItemSettings.Size = new System.Drawing.Size(79, 20);
            this.ToolsItemSettings.Text = "Настройки";
            // 
            // ToolsItemTheme
            // 
            this.ToolsItemTheme.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolsItemLight,
            this.ToolsItemDark,
            this.ToolsItemFun,
            this.ToolsItemDep});
            this.ToolsItemTheme.Name = "ToolsItemTheme";
            this.ToolsItemTheme.Size = new System.Drawing.Size(102, 22);
            this.ToolsItemTheme.Text = "Тема";
            // 
            // ToolsItemLight
            // 
            this.ToolsItemLight.Name = "ToolsItemLight";
            this.ToolsItemLight.Size = new System.Drawing.Size(160, 22);
            this.ToolsItemLight.Text = "Светлая";
            this.ToolsItemLight.Click += new System.EventHandler(this.ToolTheme_Click);
            // 
            // ToolsItemDark
            // 
            this.ToolsItemDark.Name = "ToolsItemDark";
            this.ToolsItemDark.Size = new System.Drawing.Size(160, 22);
            this.ToolsItemDark.Text = "Темная";
            this.ToolsItemDark.Click += new System.EventHandler(this.ToolTheme_Click);
            // 
            // ToolsItemFun
            // 
            this.ToolsItemFun.Name = "ToolsItemFun";
            this.ToolsItemFun.Size = new System.Drawing.Size(160, 22);
            this.ToolsItemFun.Text = "Веселая";
            this.ToolsItemFun.Click += new System.EventHandler(this.ToolTheme_Click);
            // 
            // ToolsItemDep
            // 
            this.ToolsItemDep.Name = "ToolsItemDep";
            this.ToolsItemDep.Size = new System.Drawing.Size(160, 22);
            this.ToolsItemDep.Text = "Сентябрь горит";
            this.ToolsItemDep.Click += new System.EventHandler(this.ToolTheme_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(335, 205);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(345, 23);
            this.progressBar1.TabIndex = 11;
            this.progressBar1.Visible = false;
            // 
            // pnlGenres
            // 
            this.pnlGenres.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGenres.AutoScroll = true;
            this.pnlGenres.Controls.Add(this.label3);
            this.pnlGenres.Location = new System.Drawing.Point(1002, 108);
            this.pnlGenres.Name = "pnlGenres";
            this.pnlGenres.Size = new System.Drawing.Size(91, 137);
            this.pnlGenres.TabIndex = 12;
            this.pnlGenres.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(24, 0);
            this.label3.MaximumSize = new System.Drawing.Size(200, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Жанры";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Visible = false;
            // 
            // lblNetCheck
            // 
            this.lblNetCheck.AutoSize = true;
            this.lblNetCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNetCheck.Location = new System.Drawing.Point(972, 3);
            this.lblNetCheck.Name = "lblNetCheck";
            this.lblNetCheck.Size = new System.Drawing.Size(51, 20);
            this.lblNetCheck.TabIndex = 13;
            this.lblNetCheck.Text = "label4";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1104, 511);
            this.Controls.Add(this.lblNetCheck);
            this.Controls.Add(this.pnlGenres);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pnlAbout);
            this.Controls.Add(this.pnlName);
            this.Controls.Add(this.btnToRead);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.pictureBoxPage);
            this.Controls.Add(this.listViewCatalog);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1000, 550);
            this.Name = "Form1";
            this.Text = "MangaStream";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPage)).EndInit();
            this.pnlName.ResumeLayout(false);
            this.pnlName.PerformLayout();
            this.pnlAbout.ResumeLayout(false);
            this.pnlAbout.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlGenres.ResumeLayout(false);
            this.pnlGenres.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewCatalog;
        private System.Windows.Forms.PictureBox pictureBoxPage;
        private System.Windows.Forms.ImageList imageListCatalog;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnToRead;
        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.Panel pnlName;
        private System.Windows.Forms.Panel pnlAbout;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlGenres;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem ToolsItemBookMarks;
        private System.Windows.Forms.ToolStripMenuItem ToolsItemDownloads;
        private System.Windows.Forms.ImageList imageListTree;
        private System.Windows.Forms.ToolStripMenuItem ToolsItemSettings;
        private System.Windows.Forms.ToolStripMenuItem ToolsItemTheme;
        private System.Windows.Forms.ToolStripMenuItem ToolsItemLight;
        private System.Windows.Forms.ToolStripMenuItem ToolsItemDark;
        private System.Windows.Forms.ToolStripMenuItem ToolsItemFun;
        private System.Windows.Forms.ToolStripMenuItem ToolsItemDep;
        private System.Windows.Forms.Label lblNetCheck;
        private System.Windows.Forms.Timer timer1;
    }
}

