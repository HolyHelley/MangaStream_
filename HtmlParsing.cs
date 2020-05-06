using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MangaStream
{
    public static class HtmlParsing
    {
        #region Поля
        public static ListView listViewCatalog;
        public static List<MangaInCatalog> mangalist;
        public static List<GenreCatalog> genrelist;
        public static List<string> chapters;
        public static List<string> mangaPages;
        public static PictureBox pictureBoxInfo;
        public static PictureBox pictureBoxPages;
        public static ImageList imageListCatalog;
        public static ProgressBar progressBar;
        public static TreeView treeView1;
        public static Label lblName;
        public static Label lblAbout;
        public static WebClient webClient;
        public static string siteRoot = "https://readmanga.me/";
        public static bool autonome = false;
        #endregion

        /// <summary>
        /// Сбор информации о манге картинок и описания и жанров
        /// 
        /// </summary>
        public static void MangaInfo()
        {
            string mangaName;
            if (!autonome)
            {
                foreach (MangaInCatalog manga in mangalist)
                {
                    if (manga.MangaName == listViewCatalog.SelectedItems[0].Text)
                    {
                        mangaName = listViewCatalog.SelectedItems[0].Text;
                        var index = listViewCatalog.SelectedItems[0].ImageIndex;
                        pictureBoxInfo.Image = listViewCatalog.SelectedItems[0].ImageList.Images[manga.MangaName];
                        lblName.Text = listViewCatalog.SelectedItems[0].Text;
                        webClient = new WebClient();
                        webClient.Encoding = Encoding.UTF8;

                        var htmlstring = webClient.DownloadString(siteRoot + manga.MangaLink);
                        // Console.WriteLine(htmlstring);
                        Match m = Regex.Match(htmlstring,
                           @"(?<=<meta name=.description. content=.Описание\s{1,2}манги).*(?=\/>)");

                        Match m2 = Regex.Match(htmlstring,
                           @"(?<=data-media=.)https:\/\/static\.readmanga\.me\/uploads\/pics\/\d{2,3}\/\d{2,3}\/\d{2,3}.*?(?=.>)");
                        manga.MangaLargeImage = m2.Value;
                        pictureBoxInfo.ImageLocation = manga.MangaLargeImage;
                        manga.MangaAbout = m.Value;
                        lblAbout.Text = manga.MangaAbout;

                    }
                }
            }
            else
            {
                foreach (MangaInCatalog manga in mangalist)
                {
                    if (manga.MangaName == listViewCatalog.SelectedItems[0].Text)
                    {
                        mangaName = listViewCatalog.SelectedItems[0].Text;
                        pictureBoxInfo.Image = Image.FromFile(manga.MangaLargeImage);
                        lblName.Text = listViewCatalog.SelectedItems[0].Text; ;
                        lblAbout.Text = manga.MangaAbout;
                        pictureBoxInfo.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
            }
        }
        /// <summary>
        /// Вывод жанров в колонку
        /// </summary>
        public static void GenresToTreeView()
        {
            try
            {
                webClient = new WebClient();
                //Хранение структуры каждой манги
                GenreCatalog genre = new GenreCatalog(); ;
                Stream genresPage = webClient.OpenRead(siteRoot + "list/genres/sort_name");
                StreamReader streamReader = new StreamReader(genresPage, Encoding.UTF8);
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();
                    if (line.Contains("<a href=\"/list/genre/"))////начинаем читать блок с мангой из жанра
                    {
                        var link = line.Substring(20);
                        genre.GenreLink = link.Substring(0, link.IndexOf(" ") - 1);
                        var point1 = line.LastIndexOf("\"") + 2;
                        var point2 = line.LastIndexOf("<");
                        genre.GenreName = line.Substring(point1, point2 - point1);
                        genre.GenreName = char.ToUpper(genre.GenreName[0]) + genre.GenreName.Substring(1);
                        //  Console.WriteLine(genre.GenreName);
                        genrelist.Add(genre);
                        genre = new GenreCatalog();
                    }
                }
            }
            catch
            {
                Console.WriteLine("LOL2");
            }

            foreach (GenreCatalog genreCatalog in genrelist)
            {
                treeView1.Nodes.Add(genreCatalog.GenreName);
            }

        }
        /// <summary>
        /// Получить список томов для манги
        /// </summary>
        /// <param name="manga"></param>
        public static void GetChaptersList(MangaInCatalog manga)
        {
            string result;
            webClient = new WebClient();
            chapters = new List<string>();

            try
            {
                result = webClient.DownloadString(siteRoot + "/" + manga.MangaLink);
                //  Console.WriteLine(result);
                MatchCollection m = Regex.Matches(result, @"\/\w*\/vol\d*\/\d*");

                foreach (Match match in m)
                {
                    if (!chapters.Contains(match.Value))
                        chapters.Add(match.Value);
                }
                manga.Chapters = chapters;
                foreach (string ch in manga.Chapters)
                {
                    // Console.WriteLine(ch);
                }
            }
            catch
            {
                MessageBox.Show("Ошибочка GetChapterList");
            }
        }
        /// <summary>
        /// ССылки на страницы манги и главу
        /// </summary>
        /// <param name="manga"></param>
        /// <param name="chapter"></param>
        public static void ReadManga(MangaInCatalog manga, string chapter)
        {

            string result;
            webClient = new WebClient();
            result = webClient.DownloadString(siteRoot + chapter);
           Console.WriteLine(result);
            mangaPages.Clear();
            MatchCollection m = Regex.Matches(result,
             @"https:\/\/\w{2,3}\.mangas\.rocks\/(?=\'\,\'https:\/\/h23)");//PARS JPEG PAGES OF MANGA
                                                                                                                                                                         // Console.WriteLine(m.Count);
            MatchCollection m2 = Regex.Matches(result, @"auto\/\d*\/\d*\/\d*\/[1\.\w?\-=&]*");

            if (m.Count == 0)
            {
                result = webClient.DownloadString(siteRoot + "/" + chapter + "?mtr=1");
                // Console.WriteLine(result);
                  m = Regex.Matches(result,
             @"https:\/\/\w{2,3}\.mangas\.rocks\/(?=\'\,\'https:\/\/h23)");//PARS JPEG PAGES OF MANGA
                                                                                                                                                                         // Console.WriteLine(m.Count);
             m2 = Regex.Matches(result, @"auto\/\d*\/\d*\/\d*\/[1\.\w?\-=&]*");
            }
            var c = 0;
            Console.WriteLine(m.Count.ToString()+" "+m2.Count.ToString());
            foreach (Match match in m)
            {
                mangaPages.Add(match.Value+m2[c].Value);
                c++;
            }
           
            
            foreach (string s in mangaPages)
            {
                 Console.WriteLine(s);
            }


        }
        /// <summary>
        /// Сохранить том в ккэш
        /// </summary>
        /// <param name="chapter"></param>
        public static void DownLoadManga(string chapter, MangaInCatalog manga)
        {
            webClient = new WebClient();
            int i = 0;
            bool yetExist = false;
            Directory.CreateDirectory(Environment.CurrentDirectory + "/" + chapter);
            webClient.DownloadFile(manga.MangaLargeImage, Environment.CurrentDirectory + "/" + chapter + "/" + "mangacover" + ".jpg");
            manga.MangaLargeImage = Environment.CurrentDirectory + "/" + chapter + "/" + "mangacover" + ".jpg";////Скачать обложку

            File.AppendAllText(Environment.CurrentDirectory + "/" + manga.MangaLink + "/info.txt",//записать в папке с мангой скачанные главы
            manga.CurrentChapter + Environment.NewLine); //записывается каждый раз

            if (File.Exists(Environment.CurrentDirectory + "/downloads.txt"))
            {
                using (StreamReader fs = new StreamReader(Environment.CurrentDirectory + "/downloads.txt"))//если уже записана в загрузки то не записываем
                {
                    string[] splitName = new string[7];
                    while (!fs.EndOfStream)
                    {
                        var line = fs.ReadLine();
                        splitName = line.Split('~');
                        if (splitName[0] == manga.MangaName)
                        {
                            yetExist = true;
                        }
                    }
                }
            }
            if (!yetExist)
            {
                File.AppendAllText(Environment.CurrentDirectory + "/downloads.txt",//Записать информацию о манге название описание
                 manga.MangaName + "~" + manga.MangaLink + "~" + manga.CurrentChapter + "~" + manga.MangaImage + "~" + manga.MangaLargeImage + "~"
                 + manga.MangaGenre + "~" + manga.MangaAbout + Environment.NewLine); //записывается один раз
            }

            foreach (string page in mangaPages)//Загрузка страниц
            {
                webClient.DownloadFile(page, Environment.CurrentDirectory + "/" + chapter + "/manga" + i.ToString() + ".jpg");//Скачать страницы главы
                i++;
            }

            //File.AppendAllText(Environment.CurrentDirectory +"/"+manga.CurrentChapter+ "/chapters.txt",
            //    manga.MangaLink + "~" + manga.CurrentChapter+"~"+ + Environment.NewLine);
        }
        /// <summary>
        /// Вывести в листвью картинки маленькие превьюшки и названия
        /// </summary>
        /// <param name="genrePath"></param>
        public static void GetCoverToList(string genrePath)
        {

            //  WebClient webClient;
            webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            HtmlParsing.mangalist.Clear();
            MangaInCatalog manga = new MangaInCatalog();
            progressBar.Visible = true;
            progressBar.Value = 0;
            listViewCatalog.Clear();

            try
            {
                var htmlstring = webClient.DownloadString(HtmlParsing.siteRoot + genrePath);
                //Console.WriteLine(htmlstring);
                MatchCollection m = Regex.Matches(htmlstring,
                   @"(?<=href=.)\/[\w_]+.\stitle=..+(?=.>.*<\/a>)");
                foreach (Match match in m)
                {
                    // Console.WriteLine(match.Value);
                }
                Console.WriteLine(m.Count.ToString());
                MatchCollection m2 = Regex.Matches(htmlstring,
                   @"(?!data-original=.)https:\/\/static\.readmanga\.me\/uploads\/pics\/\d{2,3}\/\d{2,3}\/\d{2,3}.*.jpg");//картинки
                int ind = 0;
                string[] nameLink = new string[2];

                foreach (Match match in m2) //заполнение
                {

                    var cutter = m[ind].Value.Replace("href=", "");
                    manga = new MangaInCatalog();
                    manga.MangaImage = match.Value;
                    nameLink = cutter.Split('=');
                    manga.MangaName = nameLink[1].Remove(0, 1);
                    manga.MangaLink = nameLink[0].Replace("\" title", "").Remove(0, 1);
                    manga.MangaGenre = genrePath;
                    HtmlParsing.mangalist.Add(manga);
                    ind++;
                }

            }
            catch (WebException)
            {
                MessageBox.Show("Автономная работа");
            }
            // Console.WriteLine(m2.Count.ToString());
            ///конец
            progressBar.Step = Convert.ToInt32(Math.Ceiling((double)100 / 1 + mangalist.Count));
            int index = 0;
            foreach (MangaInCatalog mng in HtmlParsing.mangalist)////Запоолнение листвью
            {
                progressBar.PerformStep();
                var imagename = Environment.CurrentDirectory + "/" + genrePath + "/" + mng.MangaLink + ".jpg";
                Directory.CreateDirectory(Environment.CurrentDirectory + "/" + genrePath);
                if (!File.Exists(imagename))
                    webClient.DownloadFile(mng.MangaImage, imagename);
                var image = Image.FromFile(imagename);
                imageListCatalog.Images.Add(mng.MangaLink, image);

                var item = listViewCatalog.Items.Add(mng.MangaName);
                item.ImageKey = mng.MangaLink;
                index++;
            }
            progressBar.Visible = false;
            progressBar.Value = 0;

        }
    }
}
