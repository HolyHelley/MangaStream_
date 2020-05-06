using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MangaStream
{
    public partial class Form2 : Form
    {
        int pageNumber;
        int pagesCount;
        public MangaInCatalog Manga;
        int pictureBoxLocationX;
        int pictureBoxLocationY;
        int pictureBoxSizeW;
        int pictureBoxSizeY;
        Point MouseDownLocation;
        string currentChapter;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(MangaInCatalog manga)
        {
            InitializeComponent();
            HtmlParsing.pictureBoxPages = pictureBox1;
            HtmlParsing.mangaPages = new List<string>();
            Manga = manga;
        }
        /// <summary>
        /// При открытии манги
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Mouse_Wheel);

                pageNumber = Manga.CurrentPage;
                currentChapter = Manga.CurrentChapter;
                // comboBox1.SelectedIndex = 0;
                if (!File.Exists(Environment.CurrentDirectory + "/" + currentChapter + "/manga" + pageNumber + ".jpg"))//если манга не загружена 
                {
                    HtmlParsing.ReadManga(Manga, currentChapter);
                    HtmlParsing.pictureBoxPages.ImageLocation = HtmlParsing.mangaPages[pageNumber];//Загружаеи картинку страницы
                    pagesCount = HtmlParsing.mangaPages.Count;
                }
                else
                {
                    HtmlParsing.pictureBoxPages.Image = Image.FromFile(Environment.CurrentDirectory + "/" + currentChapter + "/manga" + pageNumber + ".jpg");
                    MessageBox.Show("Чтение из кэша");
                    pagesCount = Directory.EnumerateFiles(Environment.CurrentDirectory + "/" + currentChapter).Count() - 1;
                }

                foreach (string str in Manga.Chapters)//Загрузка томов в комбо бокс
                {
                    var point = str.LastIndexOf("v") + 3;

                    ComboboxChapterlist.Items.Add(str.Substring(point, str.Length - point));
                }

                for (int i = 0; i < ComboboxChapterlist.Items.Count; i++)//пытаемся переключить комбобокс
                {
                    var point = currentChapter.LastIndexOf("v") + 3;
                    var boxItemText = ComboboxChapterlist.Items[i];
                    var cutCurrentVol = currentChapter.Substring(point, currentChapter.Length - point);
                    if (boxItemText.ToString() == cutCurrentVol)
                    {
                        ComboboxChapterlist.SelectedIndex = i;

                    }
                }

            }
            catch
            {
                Console.WriteLine("Ошибочка загрузки");
            }
            // pictureBox1.Size = new Size(pictureBox1.,pictureBox1.Image.Height);
            pictureBoxSizeW = pictureBox1.Size.Width;
            pictureBoxSizeY = pictureBox1.Size.Height;
            pictureBoxLocationX = pictureBox1.Location.X;
            pictureBoxLocationY = pictureBox1.Location.Y;
            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            NextPage();
        }

        private void NextPage()
        {
            if ((pageNumber + 1) < pagesCount)
            {
                pageNumber++;

                if (!File.Exists(Environment.CurrentDirectory + "/" + currentChapter + "/manga" + pageNumber + ".jpg"))
                {
                    // HtmlParsing.ReadManga(Manga, Manga.Chapters[0]);
                    HtmlParsing.pictureBoxPages.ImageLocation = HtmlParsing.mangaPages[pageNumber];
                }
                else//Если манга загружена то страница из файла из файла
                {
                    HtmlParsing.pictureBoxPages.Image = Image.FromFile(Environment.CurrentDirectory + "/" + currentChapter + "/manga" + pageNumber + ".jpg");

                }
                pictureBox1.Location = new Point(pictureBox1.Location.X, panel1.Location.Y + 50);
                
            }
            else//другая глава
            {
                if (Manga.Chapters.IndexOf(currentChapter) + 1 < Manga.Chapters.Count())
                {
                    currentChapter = Manga.Chapters[Manga.Chapters.IndexOf(currentChapter) + 1];
                    pageNumber = 0;
                    HtmlParsing.ReadManga(Manga, currentChapter);
                    pagesCount = HtmlParsing.mangaPages.Count();
                    HtmlParsing.pictureBoxPages.ImageLocation = HtmlParsing.mangaPages[pageNumber];
                    //HtmlParsing.pictureBoxPages.ImageLocation = HtmlParsing.mangaPages[pageNumber];
                }
                else
                    MessageBox.Show("Конец");//Последняя страница
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MouseDownLocation = e.Location;
            }
            if (e.Button == MouseButtons.Left)
            {
                NextPage();
            }
    
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                //координаты мыши + расстояние от стороны - позиция клика
                pictureBox1.Left = e.X + pictureBox1.Left - MouseDownLocation.X;
                pictureBox1.Top = e.Y + pictureBox1.Top - MouseDownLocation.Y;
            }

        }
        /// <summary>
        /// Прокрутка колесиком вверх и вниз
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mouse_Wheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                if (((panel1.Location.Y + panel1.Size.Height) - (pictureBox1.Location.Y + pictureBox1.Size.Height)) < 50)
                    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - 100);
                else
                {
                    // NextPage();
                }

            }
            else if (e.Delta > 0)
            {
                if (pictureBox1.Location.Y < panel1.Location.Y)
                    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + 100);
            }
        }


        private void btnPrev_Click(object sender, EventArgs e)
        {
            PrevPage();

        }

        private void PrevPage()
        {
            if ((pageNumber - 1) >= 0)
            {
                pageNumber--;
                if (!File.Exists(Environment.CurrentDirectory + "/" + currentChapter + "/manga" + pageNumber + ".jpg"))
                {
                    // HtmlParsing.ReadManga(Manga, Manga.Chapters[0]);
                    HtmlParsing.pictureBoxPages.ImageLocation = HtmlParsing.mangaPages[pageNumber];
                }
                else
                {
                    HtmlParsing.pictureBoxPages.Image = Image.FromFile(Environment.CurrentDirectory + "/" + currentChapter + "/manga" + pageNumber + ".jpg");
                }
            }
            else
            {
                MessageBox.Show("Начало");
            }
        }




        /// <summary>
        /// Открыть том для чтения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeVol_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Скачать текущий том
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownload_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ТЫ не сможешь)))");
        }



        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            //pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            //pictureBox1.Size = new Size(pictureBoxSizeW + 100 * trackBar1.Value, pictureBoxSizeY + 100 * trackBar1.Value);
            // pictureBox1.Location = new Point(pictureBoxLocationX - 25 * trackBar1.Value, pictureBoxLocationY);
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            PrevPage();
        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            NextPage();
        }

        private void ToolStripButton5_Click(object sender, EventArgs e)
        {
            List<string> stringList = new List<string>();

            if (File.Exists(Environment.CurrentDirectory + "/bookmarks.txt"))//если нет файла закладок
            {
                using (StreamReader streamReader = File.OpenText(Environment.CurrentDirectory + "/bookmarks.txt"))
                {
                    while (!streamReader.EndOfStream)
                    {
                        var str = streamReader.ReadLine();

                        var arr = str.Split('~');
                        if (arr[0] != Manga.MangaName)
                        {
                            stringList.Add(str);
                            Console.WriteLine(str);
                        }
                    }
                }
                using (StreamWriter streamWriter = File.CreateText(Environment.CurrentDirectory + "/bookmarks.txt"))
                {
                    foreach (string str in stringList)
                    {
                        streamWriter.WriteLine(str);
                    }
                }
            }

            File.AppendAllText(Environment.CurrentDirectory + "/bookmarks.txt", Manga.MangaName + "~"
                    + currentChapter + "~" + pageNumber + "~" + Manga.MangaGenre + "~" + Manga.MangaLink
                    + "~" + Manga.MangaImage + Environment.NewLine);
            MessageBox.Show("Добавлено в закладки");
        }

        private void ToolStripButton6_Click(object sender, EventArgs e)
        {
            foreach (string str in Manga.Chapters)//скачиваем текущую главу
            {
                var point = str.LastIndexOf("v") + 3;
                var vol = str.Substring(point, str.Length - point);
                if (vol == (ComboboxChapterlist.SelectedItem.ToString()))
                {
                    Manga.CurrentChapter = currentChapter;
                    HtmlParsing.DownLoadManga(str, Manga);
                }
            }
            MessageBox.Show("Том загружен");
        }

        private void ComboboxChapterlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (string str in Manga.Chapters)
            {
                var point = str.LastIndexOf("v") + 3;
                var vol = str.Substring(point, str.Length - point);//глава
                //Console.WriteLine(str+"======"+vol);
                if (vol == (ComboboxChapterlist.SelectedItem.ToString()))
                {
                    HtmlParsing.ReadManga(Manga, str);
                    currentChapter = str;
                    pagesCount = HtmlParsing.mangaPages.Count;     
                    
                    HtmlParsing.pictureBoxPages.ImageLocation = HtmlParsing.mangaPages[pageNumber];
                }
            }
        }

        private void TrackBar2_Scroll(object sender, EventArgs e)
        {

            //pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            pictureBox1.Size = new Size(pictureBoxSizeW + 50 * trackBar2.Value, pictureBoxSizeY + 50 * trackBar2.Value);
            //   pictureBox1.Image.Size = new Size(pictureBox1.Image.Width + 1 * trackBar2.Value, pictureBox1.Image.Height + 1 * trackBar2.Value);
            //pictureBox1.Image.Width = pictureBox1.Image.Width + 1 * trackBar2.Value;
        }

        private void PictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            trackBar2.Value = 0;
            pictureBox1.Width = pictureBox1.Image.Width;
            pictureBox1.Height = pictureBox1.Image.Height;
            pictureBoxSizeW = pictureBox1.Width;
            pictureBoxSizeY = pictureBox1.Height;
            pictureBox1.Location = new Point(panel1.Location.X, panel1.Location.Y);
            pictureBox1.Width = panel1.Width;
        }

        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Width = panel1.Width;
        }
    }
}
