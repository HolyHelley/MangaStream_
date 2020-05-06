using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace MangaStream
{

    public partial class Form1 : Form
    {
        WebClient webClient = new WebClient();
        Section section = Section.Genres;
        bool mangaselect = false;
        bool internetCheck = true;
        public Form1()
        {
            InitializeComponent();
            #region Передача данных в класс HTmlparsing
            HtmlParsing.listViewCatalog = listViewCatalog;
            HtmlParsing.lblAbout = lblAbout;
            HtmlParsing.lblName = lblName;
            HtmlParsing.treeView1 = treeView1;
            HtmlParsing.imageListCatalog = imageListCatalog;
            HtmlParsing.pictureBoxInfo = pictureBoxPage;
            HtmlParsing.mangalist = new List<MangaInCatalog>();
            HtmlParsing.genrelist = new List<GenreCatalog>();
            HtmlParsing.chapters = new List<string>();
            HtmlParsing.progressBar = progressBar1;
            #endregion

            timer1.Start();
        }

        enum Section
        {
            Genres,
            Downloads,
            BookMarks
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HtmlParsing.GenresToTreeView();
            HtmlParsing.GetCoverToList("list/genre/art");
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                HtmlParsing.autonome = true;
            }
        }
        /// <summary>
        /// Клик по дереву с жанрами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            section = Section.Genres;
            TreeNode treeNode = e.Node;
            var nodeName = treeNode.Text;
            //  imageListCatalog.Images.Clear();
            foreach (GenreCatalog genre in HtmlParsing.genrelist)
            {
                if (genre.GenreName == nodeName)
                {
                    HtmlParsing.GetCoverToList(genre.GenreLink);
                }
            }
            // progressBar1.Value = 100;
            //  progressBar1.Visible = false;
        }
        /// <summary>
        /// По клику на иконку в листе собираем информацию получаем список глав
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewCatalog_Click(object sender, EventArgs e)///Загружаем главы в обьект манги по клику
        {

            try
            {
                if (listViewCatalog.SelectedItems.Count == 1)
                {
                    if (internetCheck)
                    {
                        foreach (MangaInCatalog mangaInCatalog in HtmlParsing.mangalist)
                        {

                            if (listViewCatalog.SelectedItems[0].Text == mangaInCatalog.MangaName)
                            {
                                if (!HtmlParsing.autonome)
                                {
                                    if (section != Section.Downloads)
                                    {
                                        HtmlParsing.GetChaptersList(mangaInCatalog);
                                        mangaInCatalog.CurrentChapter = mangaInCatalog.Chapters[0];//Получение главы
                                        mangaInCatalog.CurrentPage = 0;
                                    }
                                }

                                if (File.Exists(Environment.CurrentDirectory + "/bookmarks.txt"))
                                {
                                    using (StreamReader streamReader = File.OpenText(Environment.CurrentDirectory + "/bookmarks.txt"))
                                    {
                                        while (!streamReader.EndOfStream)
                                        {
                                            var str = streamReader.ReadLine();
                                            var arr = str.Split('~');
                                            if (arr[0] == mangaInCatalog.MangaName)
                                            {
                                                mangaInCatalog.CurrentChapter = arr[1];
                                                mangaInCatalog.CurrentPage = Convert.ToInt32(arr[2]);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        btnToRead.Visible = true;

                        HtmlParsing.MangaInfo();//Показать информацию о манге
                        pnlName.Visible = true;
                        pnlAbout.Visible = true;
                        pnlGenres.Visible = true;
                        btnToRead.Visible = true;
                        pictureBoxPage.Visible = true;
                        if (!mangaselect)
                            listViewCatalog.Size = new Size(listViewCatalog.Size.Width - 300, listViewCatalog.Size.Height);
                        mangaselect = true;
                    }
                }
                else if(listViewCatalog.SelectedItems.Count == 0)
                {
                    //btnToRead.Visible = false;
                    //pnlName.Visible = false;
                    //pnlAbout.Visible = false;
                    //pnlGenres.Visible = false;
                    
                    //pictureBoxPage.Visible = true;

                    //if (!mangaselect)
                    //    listViewCatalog.Size = new Size(listViewCatalog.Size.Width + 300, listViewCatalog.Size.Height);

                    //mangaselect = false;
                }
            }
            catch
            {
                MessageBox.Show("Нет интернета");
            }
        }
        private void BtnToRead_Click(object sender, EventArgs e)
        {
            if (listViewCatalog.SelectedItems.Count == 1)
            {
                MangaInCatalog manga = new MangaInCatalog();
                foreach (MangaInCatalog mangaIn in HtmlParsing.mangalist)
                {
                    if (listViewCatalog.SelectedItems[0].Text == mangaIn.MangaName)
                    {
                        manga = mangaIn;
                        break;
                    }
                }
                Form2 form2 = new Form2(manga);//Передаем мангу на форму чтения
                form2.Show();
            }
        }
        /// <summary>
        /// Показать закладки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ЗакладкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            section = Section.BookMarks;
            listViewCatalog.Items.Clear();
            string[] infoArr = new string[6];
            HtmlParsing.mangalist.Clear();
            if (File.Exists(Environment.CurrentDirectory + "/bookmarks.txt"))
            {
                using (StreamReader streamReader = new StreamReader(Environment.CurrentDirectory + "/bookmarks.txt"))
                {
                    while (!streamReader.EndOfStream)
                    {
                        MangaInCatalog manga = new MangaInCatalog();
                        var str = streamReader.ReadLine();
                        infoArr = str.Split('~');
                        manga.MangaName = infoArr[0];
                        manga.MangaGenre = infoArr[3];
                        manga.MangaImage = infoArr[5];
                        manga.MangaLink = infoArr[4];
                        manga.CurrentPage = Convert.ToInt32(infoArr[2]);
                        var imagename = Environment.CurrentDirectory + "/" + manga.MangaGenre + "/" + manga.MangaLink + ".jpg";
                        Directory.CreateDirectory(Environment.CurrentDirectory + "/" + manga.MangaGenre);
                        if (!File.Exists(imagename))
                            webClient.DownloadFile(manga.MangaImage, imagename);
                        var image = Image.FromFile(imagename);
                        imageListCatalog.Images.Add(manga.MangaLink, image);
                        var item = listViewCatalog.Items.Add(manga.MangaName);
                        HtmlParsing.mangalist.Add(manga);
                        item.ImageKey = manga.MangaLink;
                    }
                }
            }
            else
            {
                FileStream fs = File.Create(Environment.CurrentDirectory + "/bookmarks.txt");
                fs.Close();
            }
        }
        /// <summary>
        /// Показать загрузки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ЗагруженнаяМангаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            section = Section.Downloads;
            listViewCatalog.Items.Clear();
            string[] infoArr = new string[7];
            HtmlParsing.mangalist.Clear();
            if (File.Exists(Environment.CurrentDirectory + "/downloads.txt"))
            {
                StreamReader streamReader = new StreamReader(Environment.CurrentDirectory + "/downloads.txt");
                while (!streamReader.EndOfStream)
                {
                    MangaInCatalog manga = new MangaInCatalog();
                    manga.Chapters = new List<string>();
                    var str = streamReader.ReadLine();
                    infoArr = str.Split('~');
                    manga.MangaName = infoArr[0];
                    manga.MangaGenre = infoArr[5];
                    manga.MangaImage = infoArr[3];
                    manga.MangaLink = infoArr[1];
                    manga.CurrentChapter = infoArr[2];
                    manga.MangaLargeImage = infoArr[4];
                    manga.MangaAbout = infoArr[6];
                    StreamReader stream = new StreamReader(Environment.CurrentDirectory + "/" + manga.MangaLink + "/info.txt");
                    {
                        while (!stream.EndOfStream)
                        {
                            var line = stream.ReadLine();
                            manga.Chapters.Add(line);
                        }
                    }
                    var imagename = Environment.CurrentDirectory + "/" + manga.MangaGenre + "/" + manga.MangaLink + ".jpg";
                    Directory.CreateDirectory(Environment.CurrentDirectory + "/" + manga.MangaGenre);
                    if (!File.Exists(imagename))
                        webClient.DownloadFile(manga.MangaImage, imagename);
                    var image = Image.FromFile(imagename);
                    imageListCatalog.Images.Add(manga.MangaLink, image);
                    var item = listViewCatalog.Items.Add(manga.MangaName);
                    HtmlParsing.mangalist.Add(manga);
                    item.ImageKey = manga.MangaLink;
                    //  pictureBoxPage.Image = Image.FromFile(manga.MangaLargeImage);
                }
            }
            else
            {
                FileStream fs = File.Create(Environment.CurrentDirectory + "/downloads.txt");
                fs.Close();
            }
        }

        private void ToolTheme_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            ChangeTheme(item);
        }
        /// <summary>
        /// Сменить тему
        /// </summary>
        /// <param name="item"></param>
        public void ChangeTheme(ToolStripMenuItem item)
        {
            switch (item.Name)
            {
                case "ToolsItemLight":
                    this.BackColor = Color.FromArgb(224, 224, 224);
                    lblAbout.ForeColor = Color.FromArgb(64, 0, 0);
                    lblName.ForeColor = Color.FromArgb(64, 0, 0);
                    label1.ForeColor = Color.FromArgb(64, 0, 0);
                    label2.ForeColor = Color.FromArgb(64, 0, 0);
                    label3.ForeColor = Color.FromArgb(64, 0, 0);
                    treeView1.BackColor = Color.White;
                    listViewCatalog.BackColor = Color.White;
                    treeView1.ForeColor = Color.FromArgb(64, 0, 0);
                    listViewCatalog.ForeColor = Color.FromArgb(64, 0, 0);
                    btnToRead.ForeColor = Color.FromArgb(64, 0, 0);
                    break;
                case "ToolsItemDark":
                    this.BackColor = Color.FromArgb(39, 43, 54);
                    lblAbout.ForeColor = Color.FromArgb(192, 192, 255);
                    lblName.ForeColor = Color.FromArgb(192, 192, 255);
                    label1.ForeColor = Color.FromArgb(192, 192, 255);
                    label2.ForeColor = Color.FromArgb(192, 192, 255);
                    label3.ForeColor = Color.FromArgb(192, 192, 255);
                    treeView1.BackColor = Color.FromArgb(73, 83, 114);
                    listViewCatalog.BackColor = Color.FromArgb(73, 83, 114);
                    treeView1.ForeColor = Color.FromArgb(192, 192, 255);
                    listViewCatalog.ForeColor = Color.FromArgb(192, 192, 255);
                    btnToRead.ForeColor = Color.FromArgb(192, 192, 255);
                    break;
                case "ToolsItemFun":
                    this.BackColor = Color.FromArgb(249, 239, 168);
                    lblAbout.ForeColor = Color.FromArgb(64, 0, 0);
                    lblName.ForeColor = Color.FromArgb(64, 0, 0);
                    label1.ForeColor = Color.FromArgb(64, 0, 0);
                    label2.ForeColor = Color.FromArgb(64, 0, 0);
                    label3.ForeColor = Color.FromArgb(64, 0, 0);
                    treeView1.BackColor = Color.White;
                    listViewCatalog.BackColor = Color.White;
                    treeView1.ForeColor = Color.FromArgb(64, 0, 0);
                    listViewCatalog.ForeColor = Color.FromArgb(64, 0, 0);
                    btnToRead.ForeColor = Color.FromArgb(64, 0, 0);
                    break;
                case "ToolsItemDep":
                    this.BackColor = Color.FromArgb(27, 24, 48);
                    lblAbout.ForeColor = Color.FromArgb(255, 192, 192);
                    lblName.ForeColor = Color.FromArgb(255, 192, 192);
                    label1.ForeColor = Color.FromArgb(255, 192, 192);
                    label2.ForeColor = Color.FromArgb(255, 192, 192);
                    label3.ForeColor = Color.FromArgb(255, 192, 192);
                    treeView1.BackColor = Color.FromArgb(255, 192, 192);
                    listViewCatalog.BackColor = Color.FromArgb(255, 192, 192);
                    treeView1.ForeColor = Color.Purple;
                    listViewCatalog.ForeColor = Color.Purple;
                    btnToRead.ForeColor = Color.FromArgb(255, 192, 192);
                    break;
            }
        }

        private void listViewCatalog_MouseDown(object sender, MouseEventArgs e)
        {
          
        }

        private void listViewCatalog_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listViewCatalog_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            
        }

        private void listViewCatalog_MouseUp(object sender, MouseEventArgs e)
        {
            if (listViewCatalog.SelectedItems.Count == 0)
            {
                btnToRead.Visible = false;
                pnlName.Visible = false;
                pnlAbout.Visible = false;
                pnlGenres.Visible = false;

                pictureBoxPage.Visible = false;

                if (mangaselect)
                    listViewCatalog.Size = new Size(listViewCatalog.Size.Width + 300, listViewCatalog.Size.Height);

                mangaselect = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                if (!internetCheck)
                {
                    HtmlParsing.GenresToTreeView();
                    HtmlParsing.GetCoverToList("list/genre/art");
                    internetCheck = true;
                }
                lblNetCheck.ForeColor = Color.Green;
                lblNetCheck.Text = "Online";
            }
            else 
            {
                if (internetCheck)
                {
                    internetCheck = false;
                    MessageBox.Show("Нет подключения");
                    
                }
                lblNetCheck.ForeColor = Color.Red;
                lblNetCheck.Text = "Offline";

            }
        }
    }
}
