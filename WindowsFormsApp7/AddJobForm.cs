using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



//TODO - pliki dodane czy nie, spradzanie czy sa jkaies pliki done2
//TODO - zapamietyqwac jobid i nazwy by potem sprawdzac standarderror //sacct -u tomaszkuzma --format=JobID,JobName,Submit,State |grep -v '.ba+' done2
//TODO -dodac form hostory do jobid nazwa error check done2
//TODO -sbatch run_loko.sh >wynik.txt to daje jobid nw jeszcze  done2
//TODO -dodawanie wyniku z sbatch do katalogu domowego po wykonaniu? done

//TODO -zmiana sposobu dodawania plikow i tworzenia nowych katalogow //done
//TODO -zmiana sposobu przenoszenia plikow do tmp, moze wybieranie ich z foldera czy cos, a nie jak teraz caly folder (wybor recznie po dodani chyba) //done
//TODO -usuwanie jobow z historii 
//TODO -canselowanie jobaow(w przyszlosci wielu za jednym zamachem) z poziomu histori raczej
//TODO -kilkanie data z historii wyswietla plik??
//TODO -kilkanie na job id daje malyb podglad i opcje jakie mozna wykonac dla niej typu usun cancel itd

namespace WindowsFormsApp7
{
    public partial class AddJobForm : Form
    {
        public List<PartitionTimeLimit> bazaPartitionLimitSinfo = new List<PartitionTimeLimit>(); //small
        public AddJobForm()
        {
            InitializeComponent();
            
        }
        bool oneTapData = false;
        string infoSplitTOPRINT;
        public void setDataToJob(string jobName, string description, string tool)
        {
            setLinuxRight();

            labelJobName.Text = jobName;
            labelDescription.Text = description;
            labelTool.Text = tool;
            loadDirectory();
            comboBoxDirectoryDatabase.SelectedItem = Global.directoryDatabaseLocation;
            comboBoxDirectoryQuery.SelectedItem = Global.directoryQueryLocation;
            comboBoxDirectoryType.SelectedItem = Global.directoryTypeLocation;

            // buttonSplitOption.Enabled = false;
            labelInfoAboutSplit.Text = infoSplitTOPRINT;

            if(!checkBoxSplitJob.Checked)
                buttonSplitOption.Enabled = false;

            if (!oneTapData)
            {
                foreach (var ele in bazaPartitionLimitSinfo)
                {
                    comboBoxPartition.Items.Add(ele.PARTITION);
                }
                oneTapData = true;
            }
            
        }

        public void setDataToJobReRun(string jobName, string description, string tool,string partition, string timelimit, string taskPerNode, string memory,
            string directoryDatabase, string directoryQuery, string directorType, string database, string query, string type)
        {
            setLinuxRight();

            labelJobName.Text = jobName;
            labelDescription.Text = description;
            labelTool.Text = tool;
            loadDirectory();
            comboBoxDirectoryDatabase.SelectedItem = directoryDatabase;
            comboBoxDirectoryQuery.SelectedItem = directoryQuery;
            comboBoxDirectoryType.SelectedItem = directorType;
            comboBoxDatabase.SelectedItem = database;
            comboBoxQuery.SelectedItem = query;
            comboBoxType.SelectedItem = type;

            // buttonSplitOption.Enabled = false;
            labelInfoAboutSplit.Text = infoSplitTOPRINT;

            if (!checkBoxSplitJob.Checked)
                buttonSplitOption.Enabled = false;

            if (!oneTapData)
            {
                foreach (var ele in bazaPartitionLimitSinfo)
                {
                    comboBoxPartition.Items.Add(ele.PARTITION);
                }
                oneTapData = true;
            }

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            try
            {
                foreach (var item in bazaPartitionLimitSinfo)
                {
                    if (item.PARTITION == comboBoxPartition.SelectedItem.ToString())
                    {
                        textBoxTimeLimit.Text = item.TIMELIMIT.ToString().Replace(".", "-");
                        textBoxTimeLimit.ForeColor = Color.Gray;
                        firsttime = true;
                    }
                }
            }
            catch
            {

            }
        }


        private void textBoxTimeLimit_TextChanged(object sender, EventArgs e)
        {

        }
        private bool firsttime = true;
        //click zaznacza wszytsko tylo wybranego itemu
        private void textBoxTimeLimit_Click(object sender, EventArgs e)
        {
            if (firsttime)
            {
                textBoxTimeLimit.SelectionStart = 0;
                textBoxTimeLimit.SelectionLength = textBoxTimeLimit.Text.Length;
                textBoxTimeLimit.ForeColor = Color.Black;
                firsttime = false;
            }
        }

        private void textBoxJobName_TextChanged(object sender, EventArgs e)
        {

        }

        //giive back timelimit for a picked partition 
        public TimeSpan CheckTimeLimitPartition()
        {
            foreach (var item in bazaPartitionLimitSinfo)
            {
                if (item.PARTITION == comboBoxPartition.SelectedItem.ToString())
                {
                    return item.TIMELIMIT;

                }
            }
            TimeSpan zero = new TimeSpan(0, 0, 0, 0);
//            MessageBox.Show("WCHODZA ZERA ::");
            return zero;
        }


        TimeClass timeByHandClass = new TimeClass();
        TimeClass timeLimitPartitionClass = new TimeClass();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="ClassTime"></param>
        public void StringToTime(string textBox, TimeClass ClassTime)
        {

            if (textBox.Contains("-") && textBox[1].ToString() == "-" || Regex.Matches(textBox.ToString(), "-").Count == 1) //if contain - cant be more then 1
            {
                ClassTime.day = textBox[0].ToString();
                if (textBox[1].ToString() != "-" && char.IsDigit(textBox[1]) && textBox[2].ToString() == "-") //if more then 9 days i 2 characters  ius number
                {
                    ClassTime.day = (ClassTime.day) + Convert.ToString(textBox[1]);
                }
                string result = textBox.Split('-').Skip(1).FirstOrDefault(); //to skip part about days
                string[] separate = (result).Split(':');
                if (separate.Length > 0)
                    ClassTime.hour = separate[0];
                else
                    ClassTime.hour = "0";
                if (separate.Length > 1)
                    ClassTime.minute = separate[1];
                else
                    ClassTime.minute = "0";
                if (separate.Length > 2)
                    ClassTime.second = separate[2];
                else
                    ClassTime.second = "0";
            }
            else if (Regex.Matches(textBox.ToString(), "-").Count == 0) //dont contain -
            {
                string[] separate = (textBox).Split(':');
                if (separate.Length == 2)//if there are no hours
                {
                    ClassTime.day = "0";
                    ClassTime.hour = "0";
                    ClassTime.minute = separate[0];
                    ClassTime.second = separate[1];
                }
                else //if there are hours
                {
                    ClassTime.day = "0";
                    ClassTime.hour = separate[0];
                    if (separate.Length > 1)
                        ClassTime.minute = separate[1];
                    else
                        ClassTime.minute = "0";
                    if (separate.Length > 2)
                        ClassTime.second = separate[2];
                    else
                        ClassTime.second = "0";
                }
            }
            else
            {
                ClassTime.day = "0";
                ClassTime.hour = "0";
                ClassTime.minute = "0";
                ClassTime.second = "0";
            }
        }
        /// <summary>
        /// Check if the data is the int 
        /// </summary>
        /// <returns></returns>
        public bool GoodDate()
        {
            int number;
            bool result = Int32.TryParse(timeByHandClass.day, out number);
            if (!result)
            {
               // Console.WriteLine("Converted '{0}' to {1}.", timeByHandClass.day, number);
               // MessageBox.Show("dni");
                return false;
            }
            result = Int32.TryParse(timeByHandClass.hour, out number);
            if (!result)
            {
                //Console.WriteLine("Converted '{0}' to {1}.", timeByHandClass.hour, number);
                //MessageBox.Show("godizn");
                return false;
            }
            result = Int32.TryParse(timeByHandClass.minute, out number);
            if (!result)
            {
                //Console.WriteLine("Converted '{0}' to {1}.", timeByHandClass.minute, number);
                //MessageBox.Show("minuty");
                return false;
            }
            result = Int32.TryParse(timeByHandClass.second, out number);
            if (!result)
            {
                //Console.WriteLine("Converted '{0}' to {1}.", timeByHandClass.minute, number);
               // MessageBox.Show("sekundy");
                return false;
            }
            return true;
        }

        private int day;
        private int hour;
        private int minute;
        private int second;

       
     
        private void NewJob_Load(object sender, EventArgs e)
        {

        }

        public bool checkQuery()
        {
            var format = comboBoxQuery.SelectedItem.ToString().Substring(comboBoxQuery.SelectedItem.ToString().LastIndexOf('.') + 1);
            var count = comboBoxQuery.SelectedItem.ToString().Count(x => x == '.');
            if (comboBoxQuery.SelectedIndex == -1)
            {
                MessageBox.Show("Enter the name query");
                return false;
            }
            else if (count <= 1)
            {

                if (format == "fa" || format == "fasta")
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("You have entered the wrong file format for query");
                    comboBoxQuery.SelectedIndex = -1;
                    return false;
                }
                
            }
            else
            {
                MessageBox.Show("You have entered the wrong file format for query");
                comboBoxQuery.SelectedIndex = -1;
                return false;
            }
        }

        public bool checkDatabase()
        {
            var format = comboBoxDatabase.SelectedItem.ToString().Substring(comboBoxDatabase.SelectedItem.ToString().LastIndexOf('.') + 1);
            var count = comboBoxDatabase.SelectedItem.ToString().Count(x => x == '.');
            if (comboBoxDatabase.SelectedIndex==-1)
            {
                MessageBox.Show("Enter the database name");
                return false;
            }
            else if (count <= 1) //jesli ma pliki z kropkami :)
            {

                if (format == "fa" || format == "fasta")
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("You have entered the wrong file format for database");
                    comboBoxDatabase.SelectedIndex = -1;
                    return false;
                }
                
            }
            else
            {
                MessageBox.Show("You have entered the wrong file format for database");
                comboBoxDatabase.SelectedIndex = -1;
                return false;
            }
        }


        public void RunFormSettings()
        {
            if (Application.OpenForms.OfType<FormDirectoryRunJob>().Count() >= 1)
            {
                Global.FormNewJobADD4.setDataToJob(labelJobName.Text, labelDescription.Text, "Blast", comboBoxPartition.SelectedItem.ToString(),
                textBoxTimeLimit.Text.Replace(".", "-"), textBoxTasksPerNode.Text, textBoxMemory.Text, comboBoxType.SelectedItem.ToString(), comboBoxQuery.SelectedItem.ToString(), comboBoxDatabase.SelectedItem.ToString(),labelInfoAboutSplit.Text);
                Global.FormNewJobADD4.Visible = true;
                Global.FormNewJobADD4.Focus();
                Global.FormNewJobADD4.BringToFront();
                this.Visible = false;

            }
            else
            {
                Global.FormNewJobADD4.setDataToJob(labelJobName.Text, labelDescription.Text, "Blast", comboBoxPartition.SelectedItem.ToString(),
                    textBoxTimeLimit.Text.Replace(".", "-"), textBoxTasksPerNode.Text, textBoxMemory.Text, comboBoxType.SelectedItem.ToString(), comboBoxQuery.SelectedItem.ToString(), comboBoxDatabase.SelectedItem.ToString(), labelInfoAboutSplit.Text);
                this.Visible = false;
                Global.FormNewJobADD4.Show();
            }
        }


        public bool databaseHaveIndex(string DirectoryDatabase, string NameDatabase, string oneLetter)
        {
            string pin= NameDatabase +"."+oneLetter+"in";
            string psq= NameDatabase + "." + oneLetter + "sq";
            string phr= NameDatabase + "." + oneLetter + "hr";
            bool indb = false;
            bool sqdb = false;
            bool hrdb = false;

            string fileDB = NameDatabase;
            var listOfFilesInDirectory = Global.connectionSession.RunCommand("cd " + DirectoryDatabase + "; ls");

            string[] lines = (listOfFilesInDirectory.Result).Split('\n');

            for (int i = 0; i < lines.Length - 1; i++) //-1 bo wyjdze bo za zakres
            {
                if (lines[i] == pin)
                    indb = true;

                if (lines[i] == psq)
                    sqdb = true;

                if (lines[i] == phr)
                    hrdb = true;

            }
            if (indb && sqdb && hrdb)
                return true;
            else
                return false;
        }

        public bool QueryAndDatabaseNotEmpty()
        {
            if (comboBoxQuery.SelectedIndex != -1 && comboBoxDatabase.SelectedIndex != -1)
                return true;
            else
            {
                MessageBox.Show("You must select database and query files");
                return false;
            }
        }

        public bool checkSplit()
        {
            if (checkBoxSplitJob.Checked)
            {
                if (splitNumber != "")
                {
                    Global.splitQueryMultiplyJobs = true; // jesli zaznaczone i nie puste daj na to by dzielic inaczej zeby nie dzileic
                    return true;
                }
                else
                {
                    Global.splitQueryMultiplyJobs = false ;
                    return false;
                }
            }
            else
            {
                Global.splitQueryMultiplyJobs = false;
                return true;
            }
        }

        public string countSplitedfFiles()
        { //zliczneie ilosci plikow
            string nrSplitedFilesCommand = String.Format("cd /tmp/lustre_shared/{0}/{1}{2}; ls -l . |egrep -c '^-'", Global.user, Global.directoryQueryLocation, Global.SplitedFilesQueryLocation);
            var nrSplitedFiles = Global.connectionSession.RunCommand(nrSplitedFilesCommand);//create directory in tmpls
            return nrSplitedFiles.Result;
        }

        public bool OneFileSplitedTooManySequence = false;
        public bool splitedFilesAreReady()
        {
            // cat bsu.fa | grep ">" |wc -l

            if (!checkBoxSplitJob.Checked) //jesli nie jest zaznaczone po prostu przejdz dalej bo nie ma sensu sprawdzac czy plik jest podzielony
            {
                return true;
            }
            var commandToNrOfSplitedFiles = Global.connectionSession.RunCommand("cd " + Global.directoryQueryLocation + "; cat " + comboBoxQuery.SelectedItem.ToString() + "| grep \">\" |wc -l");
            string nrOfSplitedFilesREALTIME = commandToNrOfSplitedFiles.Result;

            string nrOfPartsString = countSplitedfFiles(); //+1

            if (Global.SequencePerFile) //jeslii wybrane x sekwencji na plik
            {
                double devi = (double)Convert.ToInt32(nrOfSplitedFilesREALTIME) / Global.numberSplitedFiles;//to dzielimy zaokraglaajc w gore ilosc sekwencji przez wpisana liczbe
                decimal actualNrRoundUP = (int)Math.Ceiling(devi); // zaokraglwnie w gore
                //Console.WriteLine("float: " + devi);
                //Console.WriteLine("actual needed: " + actualNrRoundUP);
               // Console.WriteLine("counted: " + Convert.ToInt32(countSplitedfFiles()));

                if (Convert.ToInt32(nrOfSplitedFilesREALTIME) < Global.numberSplitedFiles) // jesli liczba wpisanych sekwecji na plik jest wieksza niz liczba wszystkich sekwecji
                {
                    OneFileSplitedTooManySequence = true;
                    return true;
                }
                else
                {

                    if ((Convert.ToInt32(countSplitedfFiles())) == actualNrRoundUP) //i sprawdzamy czy wynik rowna sie liczbie pliow
                    {
                        //pliki gotowereturn
                        OneFileSplitedTooManySequence = false ;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Wait we are still spliting files");
                        OneFileSplitedTooManySequence = false;
                        return false;
                    }
                }
            }
            else // jesli wybrano podzial na x plikow
            {

                //Console.WriteLine("actual needed: " + Global.numberSplitedFiles);
                //Console.WriteLine("counted: " + Convert.ToInt32(countSplitedfFiles()));
                if (Global.numberSplitedFiles == Convert.ToInt32(countSplitedfFiles())) //to tylko sprawdzamy czy wprowadzona liczba zgadza sie z liczba plikow
                {
                    OneFileSplitedTooManySequence = false;
                    return true;
                }
                else
                {
                    MessageBox.Show("Wait we are still spliting files");
                    OneFileSplitedTooManySequence = false;
                    return false;
                }
            }

        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (checkSplit())
            {
                Global.makeblastdbComand = "";
                if (comboBoxType.SelectedIndex > -1) //  katalog  nie sa puste
                {
                    if (QueryAndDatabaseNotEmpty()) //sprawdza czy wybrane sa jakies pliki bazy i query nie moga byc puste
                    {
                        if (checkQuery() && checkDatabase())// sprawdza ich popranwosc pliow
                        {
                            day = 0;
                            hour = 0;
                            minute = 0;
                            second = 0;
                            int number;
                            bool timeIsOK = false;
                            if (comboBoxPartition.SelectedIndex > -1) //jesli partycja  nie sa puste
                            {
                                bool result = Int32.TryParse(textBoxTimeLimit.Text, out number);
                                if (result) //zostalu wprowadzone same liczby
                                {
                                    //second = 0;
                                    //minute = number % 60;
                                    //hour = number / 60;
                                    //day = hour / 24;
                                    //hour = hour % 24;
                                    //zmiana by wpisywany czas byl w minutach a nie godzinach 
                                    second = 0;
                                    minute = 0;
                                    hour = number % 24;
                                    day = number / 24;
                                    timeIsOK = true;

                                   // Console.WriteLine("Converted '{0}' to {1}.", textBoxTimeLimit.Text, number);

                                    string timeLimitPartition = CheckTimeLimitPartition().ToString().Replace(".", "-"); //zwraca czaslimit do partycji
                                    StringToTime(timeLimitPartition, timeLimitPartitionClass);

                                }
                                else if (char.IsDigit(textBoxTimeLimit.Text[0]))
                                {
                                    string timeLimitPartition = CheckTimeLimitPartition().ToString().Replace(".", "-"); //zwraca czaslimit do partycji
                                    StringToTime(timeLimitPartition, timeLimitPartitionClass);
                                    string timeLimit = textBoxTimeLimit.Text;
                                    StringToTime(timeLimit, timeByHandClass);

                                    if (GoodDate()) //sprawdzmay czy wprowadzony czas jest faktycznie intem
                                    {
                                        int min2 = Convert.ToInt32(timeByHandClass.second) / 60; //jesli sekund wiecej niz 60 daj do minut i jelsi jeszcze jakas sekunda zaokraglij w gore

                                        if (Convert.ToInt32(timeByHandClass.second) % 60 > 0)
                                        {
                                            min2++;
                                        }

                                        minute = ((Convert.ToInt32(timeByHandClass.minute) + min2) % 60);
                                        hour = Convert.ToInt32(timeByHandClass.minute) / 60;
                                        hour += Convert.ToInt32(timeByHandClass.hour);
                                        day = hour / 24;
                                        hour = hour % 24;
                                        day += Convert.ToInt32(timeByHandClass.day);
                                        timeIsOK = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("You have entered the wrong time limit format");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Time Limit must start with a number");
                                }

                            }
                            else//musisz wybrac partycje combobox
                            {
                                MessageBox.Show("Select partitions");
                            }

                            if (splitedFilesAreReady()) // sprawdzamy czy wymagana liczba plikow jest ronwa aktualnej liczbuie, dzielimy pliki na czesci i liczba potrzebych plikow rowna sie aktualna liczba
                            {
                                if (timeIsOK)
                                {
                                    var isNumericTask = int.TryParse(textBoxTasksPerNode.Text, out int task);
                                    var isNumericMemory = int.TryParse(textBoxMemory.Text, out int memor);

                                    if ((textBoxTasksPerNode.Text.Length > 0 && isNumericTask) && (textBoxMemory.Text.Length > 0 && isNumericMemory)) //jesli task i memory to liczby
                                    {
                                        int LimitMemory = checkPartitionToMemeoryLimitBigmem(); //to check if is bigmem, if it is limit is 256mb
                                        if (Convert.ToInt32(textBoxTasksPerNode.Text) <= 28 && Convert.ToInt32(textBoxMemory.Text) <= LimitMemory)
                                        {
                                            if (day <= Convert.ToInt32(timeLimitPartitionClass.day))
                                            {
                                                if ((day == Convert.ToInt32(timeLimitPartitionClass.day) && hour <= Convert.ToInt32(timeLimitPartitionClass.hour)
                                                   && minute <= Convert.ToInt32(timeLimitPartitionClass.minute)) || day < Convert.ToInt32(timeLimitPartitionClass.day)
                                                   || (day == Convert.ToInt32(timeLimitPartitionClass.day) && hour < Convert.ToInt32(timeLimitPartitionClass.hour)))
                                                {

                                                    //if it was a number convert to int to * 60 to mea it hours
                                                    int tmpINT = 0;
                                                    if (!textBoxTimeLimit.Text.Contains("-") && !textBoxTimeLimit.Text.Contains(":"))
                                                    {
                                                        tmpINT = Convert.ToInt32(textBoxTimeLimit.Text) * 60;
                                                        textBoxTimeLimit.Text = tmpINT.ToString();
                                                    }

                                                    if (comboBoxDirectoryDatabase.SelectedIndex == -1 || comboBoxDirectoryQuery.SelectedIndex == -1 || comboBoxDirectoryType.SelectedIndex == -1)
                                                    {
                                                        MessageBox.Show("You must select the directory where the necessary files are located");

                                                    }

                                                    else
                                                    {
                                                        if (comboBoxQuery.SelectedIndex == -1 || comboBoxDatabase.SelectedIndex == -1 || comboBoxType.SelectedIndex == -1)
                                                        {
                                                            MessageBox.Show("You must select the files");

                                                        }
                                                        else
                                                        {
                                                            RunFormSettings();
                                                        }
                                                    }

                                                    if (!textBoxTimeLimit.Text.Contains("-") && !textBoxTimeLimit.Text.Contains(":"))
                                                    {
                                                        tmpINT = Convert.ToInt32(textBoxTimeLimit.Text) / 60;
                                                        textBoxTimeLimit.Text = tmpINT.ToString();
                                                    }

                                                    //this.Close();

                                                }
                                                else //day == day partiton
                                                {
                                                    MessageBox.Show("You are exceeding the maximum Time limit for this partition which is " + timeLimitPartitionClass.day + "d " + timeLimitPartitionClass.hour + "h " + timeLimitPartitionClass.minute + "m");
                                                }
                                            }
                                            else // day <= od daypartition
                                            {
                                                MessageBox.Show("You are exceeding the maximum Time limit for this partition which is " + timeLimitPartitionClass.day + "d " + timeLimitPartitionClass.hour + "h " + timeLimitPartitionClass.minute + "m");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Task per node can't be larger than 28 and memory can't be larger than "+ LimitMemory);
                                        }
                                    }
                                    else// jesli task per node i memory to nie liczby
                                    {
                                        MessageBox.Show("A number must be entered in Tasks Per Node and Memory");
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("You must select a type");
                }
            }
            else
            {
                MessageBox.Show("You must set split options if you have checked this option");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }



        private void buttonPrevious_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;

            checkBoxSplitJob.Checked = false;
            buttonSplitOption.Enabled = false;
            labelInfoAboutSplit.Text = "";
            infoSplitTOPRINT = "";

            startchecking = false;

            //if we are back we have to clear info about split files

            splitNumber = "";

            Global.FormToolsToChooseADD2.setDataToJob(labelJobName.Text, labelDescription.Text);
            Global.FormToolsToChooseADD2.Visible = true;
            Global.FormToolsToChooseADD2.Focus();
            Global.FormToolsToChooseADD2.BringToFront();

        }


        private void buttonCreateDirectory_Click(object sender, EventArgs e)
        {
            AddDirectoryForm directorForm = new AddDirectoryForm();
            directorForm.ShowDialog();
            //comboBoxDirectory.SelectedItem.c

            //after close direcotry form refresh list directory

            loadDirectory();
        }

        public void loadDirectory()
        {
            var output = Global.connectionSession.RunCommand("ls -d *//");
            string newLine = Environment.NewLine;
            comboBoxDirectory.Items.Clear();
            comboBoxDirectoryQuery.Items.Clear();
            comboBoxDirectoryDatabase.Items.Clear();
            comboBoxDirectoryType.Items.Clear();
            string[] lines = (output.Result).Split('\n');
            for (int i = 0; i < lines.Length - 1; i++)
            {
                if (lines[i] != ".ServerFiles/")
                {
                    comboBoxDirectory.Items.Add(lines[i]);
                    comboBoxDirectoryQuery.Items.Add(lines[i]);
                    comboBoxDirectoryDatabase.Items.Add(lines[i]);
                    comboBoxDirectoryType.Items.Add(lines[i]);

                }
            }
        }

        private void buttonAddFiles_Click(object sender, EventArgs e)
        {
            if (comboBoxDirectory.SelectedIndex > -1)
            {
                string workingdirectory = "/home/users/" + Global.user + "/" + comboBoxDirectory.SelectedItem.ToString();
                string uploadfile = "";

               // Console.WriteLine("Creating client and connecting");
                using (var client = new SftpClient(Global.host, Global.user, Global.pass))
                {
                    client.Connect();
                  //  Console.WriteLine("Connected to {0}", Global.host);
                    client.ChangeDirectory(workingdirectory);
                  //  Console.WriteLine("Changed directory to {0}", workingdirectory);
                    var listDirectory = client.ListDirectory(workingdirectory);
                   // Console.WriteLine("Listing directory:");

                    OpenFileDialog openFileDialog1 = new OpenFileDialog();
                    openFileDialog1.Multiselect = true;
                    MessageBoxInfo messageBoxInfo = new MessageBoxInfo("1");

                    if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string strfilename = openFileDialog1.FileName;
                        // MessageBox.Show(strfilename); //show path
                        messageBoxInfo.Show();

                        foreach (String file in openFileDialog1.FileNames) // for uploading multiple files
                        {
                            try
                            {
                                using (var fileStream = new FileStream(file, FileMode.Open))
                                {
                                   // Console.WriteLine("Uploading {0} ({1:N0} bytes)", file, fileStream.Length);
                                    client.BufferSize = 4 * 1024; // bypass Payload error large files
                                    client.UploadFile(fileStream, Path.GetFileName(file));
                                    Console.WriteLine(file);
                                }


                            }
                            catch (SecurityException ex)
                            {
                                // The user lacks appropriate permissions to read files, discover paths, etc.
                                MessageBox.Show("Security error. Please contact your administrator for details.\n\n" +
                                    "Error message: " + ex.Message + "\n\n" +
                                    "Details (send to Support):\n\n" + ex.StackTrace
                                );
                            }
                            catch (Exception ex)
                            {
                                // Could not load the image - probably related to Windows file system permissions.
                                MessageBox.Show("Cannot display the image: " + file.Substring(file.LastIndexOf('\\'))
                                    + ". You may not have permission to read the file, or " +
                                    "it may be corrupt.\n\nReported error: " + ex.Message);
                            }
                        }
                        messageBoxInfo.Close();
                        MessageBox.Show("Files added");
                    }
                }
                Global.connectionSession.RunCommand("cd " + comboBoxDirectory.SelectedItem.ToString() + "; chmod 740 " + "blast*");// zmiana chmod na wykonwyale
                Global.connectionSession.RunCommand("cd " + comboBoxDirectory.SelectedItem.ToString() + "; chmod 740 " + "makeblastdb*");// zmiana chmod na wykonwyale
                Global.connectionSession.RunCommand("cd " + comboBoxDirectory.SelectedItem.ToString() + "; chmod 740 " + "seqkit*");// zmiana chmod na wykonwyale
                //loadListBoxFiles(comboBoxDirectory);

            }
            else
            {
                MessageBox.Show("Select the directory to which you want to transfer files or create a new one");
            }
        }

        private void comboBoxDirectory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //loadListBoxFiles(comboBoxDirectory);
        }


        public void loadListBoxFiles(ComboBox comboBoxDirectory, ComboBox comboBoxFiles,bool exe)
        {
            try
            {
                var listOfFilesInDirectory = Global.connectionSession.RunCommand("cd " + comboBoxDirectory.SelectedItem.ToString() + "; ls");

                string[] lines = (listOfFilesInDirectory.Result).Split('\n');
                comboBoxFiles.Items.Clear();
                if (exe == false)
                {
                    for (int i = 0; i < lines.Length - 1; i++) //-1 bo wyjdze bo za zakres
                    {
                        if(lines[i].Contains("fa") || lines[i].Contains("fasta")) //by dodawal do comboboxa tylko pliki z fasta czyli query i database
                            comboBoxFiles.Items.Add(lines[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < lines.Length - 1; i++) //-1 bo wyjdze bo za zakres
                    {
                        if (!lines[i].Contains("."))
                            comboBoxFiles.Items.Add(lines[i]);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string checkFormatFileToIndexing()
        {
            if (String.Compare(comboBoxType.SelectedItem.ToString(), "blastp", true) == 0)
            {
                return "prot";
            }
            else if (String.Compare(comboBoxType.SelectedItem.ToString(), "blastn", true) == 0)
            {
                return "nucl";
            }
            else if (String.Compare(comboBoxType.SelectedItem.ToString(), "blastx", true) == 0)
            {
                return "prot";
            }
            return "exit";
        }

        public bool checkIfmakeBlastDBisInFolder()
        {
            var listOfFilesInDirectory = Global.connectionSession.RunCommand("cd " + comboBoxDirectoryType.SelectedItem.ToString() + "; ls");

            string[] lines = (listOfFilesInDirectory.Result).Split('\n');

                for (int i = 0; i < lines.Length - 1; i++) //-1 bo wyjdze bo za zakres
                {
                    if (lines[i].ToLower() == "makeblastdb")
                     return true;
                }
            return false;
        }
        string directoryWhereDatabaseIndex;
        string nameDatabase;
        string literka;
        public bool startchecking = false;


        public void activeCheckingIfDatabaseIsIndexedAlready()
        {
            if (databaseHaveIndex(directoryWhereDatabaseIndex, nameDatabase, literka))
            {
                buttonNext.Enabled = true;
                startchecking = false;
                comboBoxDirectoryDatabase.Enabled = true;
                comboBoxDatabase.Enabled = true;
                MessageBox.Show("The files are indexed, you can go further");
            }
        }

        private int checkPartitionToMemeoryLimitBigmem()
        {
            if (Convert.ToString(comboBoxPartition.SelectedItem) == "bigmem")
            {
                return 256;
            }
            else
            {
                return 128;
            }
        }

        public void something(string comandMakeBlast)
        {


            string fileNameSH = "run_" + labelJobName.Text + "-Indexing.sh";
            string JobName = labelJobName.Text + "-Indexing";
            string timeLimit = "1:00:00";
            string partition = "fast";
            int taskPerNode = 1;
            int memory = 8;

            string mkdirDirectory = String.Format("mkdir /tmp/lustre_shared/{0}/{1} > /dev/null 2>&1", Global.user, Global.directoryDatabaseLocation); //ditrctorydatabase?
            Global.connectionSession.RunCommand(mkdirDirectory);//create directory in tmp

            //przeniesienie makeblastdb do tmp
            string makeBlastYesNo = "makeblastdb";
                string lineMAKEBLASTdb = String.Format("cp /home/users/{0}/{1}{2} /tmp/lustre_shared/{0}/{3} ", Global.user, Global.directoryTypeLocation, makeBlastYesNo, Global.directoryDatabaseLocation); //FilesToTMP, fileNameSH, tmpZnak);
                Global.connectionSession.RunCommand(lineMAKEBLASTdb);//przeniesienie programu mekablastdb do folderu tmp

            ////--------------
            string filesToCopy = @"{stdout-" + JobName + @".txt,stderr-" + JobName + @".txt,"+ comboBoxDatabase.SelectedItem.ToString()+@".*}";//nazwy plikow wynikowych
            string CopyFiles = String.Format("cp /tmp/lustre_shared/{0}/{1}{2} /home/users/{0}/{1}",
                Global.user, Global.directoryDatabaseLocation, filesToCopy); //kopiowanie wynikow obliczen do katalog domowego
            ////--------------

            ////--------------
            string deleteTmpDirectory = @"rm -r /tmp/lustre_shared/" + Global.user + @"/" + Global.directoryDatabaseLocation; //for delete directory from a tmp                                                 
            string deleteCheckFile = ("rm /home/users/" + Global.user + "/" + Global.directoryDatabaseLocation + "check" + JobName + ".txt"); //for display good info and infor us if the data is

            ////--------------
            string lineDatabase = String.Format("cp -n /home/users/{0}/{1}{2} /tmp/lustre_shared/{0}/{1}", Global.user, Global.directoryDatabaseLocation, comboBoxDatabase.SelectedItem.ToString()); //FilesToTMP, fileNameSH, tmpZnak);
            string sleepBeforeFinish = "sleep 2";
            ////--------------
            string memorySize;
            if(checkPartitionToMemeoryLimitBigmem() == 256)
            {
                memorySize = "mb";
            }
            else
            {
                memorySize = "gb";
            }

            string line = String.Format("cd {0};echo  \"#!/bin/bash\" >{1};echo  \"#SBATCH --job-name={2}\" >>{1};echo  \"#SBATCH --time={3}\" >>{1};" +
   " echo  \"#SBATCH -p {4}\" >>{1};echo  \"#SBATCH --nodes=1\" >>{1};echo  \"#SBATCH --ntasks-per-node={5}\" >>{1};" +
   "echo  \"#SBATCH --mem={6}{13}\" >>{1};echo  \"#SBATCH -e stderr-{2}.txt\" >>{1};echo  \"#SBATCH -o stdout-{2}.txt\" >>{1};" +
   " echo \"{11}\" >>{1}; echo \"{7}\" >>{1}; echo  \"{12}\" >>{1}; echo \"{9}\" >>{1}; echo \"{10}\" >>{1}",
   Global.directoryDatabaseLocation, fileNameSH, JobName, timeLimit, partition, taskPerNode, memory, comandMakeBlast, Global.user, CopyFiles, deleteCheckFile,
   lineDatabase, sleepBeforeFinish, memorySize); //zrobienie pliku sbatch

            Global.connectionSession.RunCommand(line); //create plik batch z zawartoscia


            string lineRUNCOPY = String.Format("cp /home/users/{0}/{1}{2} /tmp/lustre_shared/{0}/{1} ", Global.user, Global.directoryDatabaseLocation, fileNameSH); //FilesToTMP, fileNameSH, tmpZnak);
            Global.connectionSession.RunCommand(lineRUNCOPY);//przeniesienie plika run do folderu tmp
            //Console.WriteLine(line);
            Global.connectionSession.RunCommand("cd /home/users/" + Global.user + "/" + Global.directoryDatabaseLocation + ";touch check" + JobName + ".txt"); //create file check to if in function

            line = String.Format("cd /tmp/lustre_shared/{0}/{1}; sbatch {2}", Global.user, Global.directoryDatabaseLocation, fileNameSH);
            // Console.WriteLine(line);
            //wydobycie job id i jobname
            string line2 = string.Format("{0} > /home/users/{1}/.ServerFiles/jobIDtmp.txt; cat /home/users/{1}/.ServerFiles/jobIDtmp.txt | cut -d \" \" -f4 > /home/users/{1}/.ServerFiles/jobID.txt", line, Global.user);
            Global.connectionSession.RunCommand(line2); //uruchomienie sbatch na tmp i zapisanie job id

            //etap dodawanie info o dodanym jobie
            AddInfoHistoryAboutAddedJob(JobName);


        }
           
        public void AddInfoHistoryAboutAddedJob(string JobName) //funkcja ktora uzupelnia onfo o dodanej jobie w plikach
        {

            MessageBoxInfo messageBoxInfo = new MessageBoxInfo("Preparation for indexing the database, please wait...");
            messageBoxInfo.Show();

            string JobID = String.Format("cat /home/users/{0}/.ServerFiles/jobID.txt", Global.user);

            var outputJobID = Global.connectionSession.RunCommand(JobID);

            //Console.WriteLine(output.Result);
            //----- ZAPISANIE DANYCH Z PLIKU-----//
            string[] linessss = (outputJobID.Result).Split('\n');


            for (int i = 0; i < linessss.Length - 1; i++) //-1 bo wyjdze bo za zakres
            {
                var tempLine = linessss[i].Split(' ');
                for (int oo = 0; oo < tempLine.Length; oo++)
                {
                    //Console.WriteLine(tempLine[oo]);
                }
            }

            var isNumericJobID = int.TryParse(outputJobID.Result, out int JobIdCheck);
            //Console.WriteLine(outputJobID.Result);

            DateTime nowTime = DateTime.Now;

            string historyJobsAddItme = String.Format("echo \"{0};{2};{3};{4};Database indexing\" >> /home/users/{1}/.ServerFiles/HistoryJobs.txt", outputJobID.Result.Replace("\n", ""), Global.user, JobName, Global.directoryDatabaseLocation, nowTime);

            Global.connectionSession.RunCommand(historyJobsAddItme);
            // zapisanie job id i job name to remember history of file END
            Global.JobIDFromProgramm.Add(JobIdCheck);
            messageBoxInfo.Close();

            MessageBox.Show("Job for indexing has been added");
            directoryWhereDatabaseIndex = comboBoxDirectoryDatabase.SelectedItem.ToString();
            nameDatabase = comboBoxDatabase.SelectedItem.ToString();
            literka = checkFormatFileToIndexing()[0].ToString();
            startchecking = true;
            //sacct -u tomaszkuzma --format=JobID,JobName,Submit,State |grep -v '.ba+'
        }

        public void viewInformationAboutIndexinfFiles(string DirectoryDatabase, string NameDatabase)
        {

            if(checkFormatFileToIndexing() != "exit") //FUNKCJA  zwraca na info odnosnie indexow czy bialkowe czy nukleotydowe
            {
                string indexingType = checkFormatFileToIndexing()[0].ToString(); //zwraca litere jaki format powinny mie cpliki
                if (databaseHaveIndex(DirectoryDatabase, NameDatabase, indexingType))//funkcja ktora sprawdza czy juz s apliki
                {
                    DialogResult dialogResult = MessageBox.Show("Indexed files exist in the selected folder. Do you want to index them again?", "Indexed files", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes) //puszczamy joba tylko od indexowania
                    {
                        string indexingComand = String.Format("./makeblastdb -in {0} -input_type fasta -dbtype {1}", comboBoxDatabase.SelectedItem.ToString(), checkFormatFileToIndexing());
                        // Global.makeblastdbComand = indexingComand;
                        // RunFormSettings();

                        if (checkIfmakeBlastDBisInFolder())
                        {
                            comboBoxDirectoryDatabase.Enabled = false;
                            comboBoxDatabase.Enabled = false;
                            Global.connectionSession.RunCommand("cd " + Global.directoryDatabaseLocation + ";rm " + comboBoxDatabase.SelectedItem.ToString() + ".*"); //jelsi tak usuwaj pliki stare indeksowane
                            something(indexingComand);

                            //buttonNext.Enabled = true;
                        }
                        else
                            MessageBox.Show("Makeblastdb is missing, add it to the folder  with tool");
                        //something(indexingComand);
                        //do something wykonac indekswoaniue sprawdzic czy sa pliki i run program
                    }
                    else if (dialogResult == DialogResult.No)// nie indeksuujemy jeszcze raz puszczamy normalnie program
                    {
                        buttonNext.Enabled = true;
                    }
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("No index files, do you want me to do this?", "Indexed files", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes) //puszczamy joba tylko od indexowania
                    {
                        string indexingComand = String.Format("./makeblastdb -in {0} -input_type fasta -dbtype {1}", comboBoxDatabase.SelectedItem.ToString(), checkFormatFileToIndexing());
                        // Global.makeblastdbComand = indexingComand;
                        // RunFormSettings();

                        if (checkIfmakeBlastDBisInFolder())
                        {
                            // Global.connectionSession.RunCommand("cd " + Global.directoryTypeLocation + ";rm " + comboBoxDatabase.SelectedItem.ToString() + ".*"); //jelsi tak usuwaj pliki stare indeksowane
                            comboBoxDirectoryDatabase.Enabled = false;
                            comboBoxDatabase.Enabled = false;
                            something(indexingComand);

                            //buttonNext.Enabled = true;
                        }
                        else
                            MessageBox.Show("Makeblastdb is missing, add it to the folder  with tool");
                    }
                    else if (dialogResult == DialogResult.No)// nie indeksuujemy jeszcze raz puszczamy normalnie program
                    {
                        directoryWhereDatabaseIndex = comboBoxDirectoryDatabase.SelectedItem.ToString();
                        nameDatabase = comboBoxDatabase.SelectedItem.ToString();
                        literka = checkFormatFileToIndexing()[0].ToString();
                        startchecking = true;
                    }

                }
            }
            else
            {
                MessageBox.Show("I don't know the formatting tool(you may have chosen a tool that does not exist), you must add a command in the terminal, contact the program creator to solve the problem");
            }
        }

        private void comboBoxDirectoryQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxQuery.SelectedIndex = -1; 
            loadListBoxFiles(comboBoxDirectoryQuery, comboBoxQuery,false);
            Global.directoryQueryLocation = comboBoxDirectoryQuery.SelectedItem.ToString();
            if(comboBoxDirectoryDatabase.SelectedIndex==-1)
                comboBoxDirectoryDatabase.SelectedItem = comboBoxDirectoryQuery.SelectedItem;
        }

        private void comboBoxDirectoryDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            startchecking = false; //by zastopowac sprawdzanie jesli zmienimy plik
            comboBoxDatabase.SelectedIndex = -1;
            loadListBoxFiles(comboBoxDirectoryDatabase, comboBoxDatabase,false);
            Global.directoryDatabaseLocation = comboBoxDirectoryDatabase.SelectedItem.ToString();
            if (comboBoxDirectoryQuery.SelectedIndex == -1)
                comboBoxDirectoryQuery.SelectedItem = comboBoxDirectoryDatabase.SelectedItem;

        }

        private void comboBoxDirectoryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxType.SelectedIndex = -1;
            loadListBoxFiles(comboBoxDirectoryType, comboBoxType,true);
            Global.directoryTypeLocation = comboBoxDirectoryType.SelectedItem.ToString();
        }

        private void comboBoxDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            startchecking = false; //by zastopowac sprawdzanie jesli zmienimy plik
            if (comboBoxDatabase.SelectedIndex != -1)
            {
                if (comboBoxType.SelectedIndex == -1)
                {
                    MessageBox.Show("You must select a tool type");
                    comboBoxDatabase.SelectedIndex = -1;
                    //Global.FileDatabaseLocation = comboBoxDatabase.SelectedItem.ToString();
                }
                else
                {
                    buttonNext.Enabled = false;
                    if (checkDatabase())
                    {
                        viewInformationAboutIndexinfFiles(comboBoxDirectoryDatabase.SelectedItem.ToString(), comboBoxDatabase.SelectedItem.ToString());
                        
                    }
                }
            }      
        }

        private void comboBoxQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            infoSplitTOPRINT = "";
            labelInfoAboutSplit.Text = "";
            splitNumber = "";
            if (comboBoxQuery.SelectedIndex != -1) //by sie nie wysypalo przy zmianie folder
            {
                checkQuery();

            }     
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Global.FileTypeLocation = comboBoxType.SelectedItem.ToString() ;
        }

        public string splitNumber="";
        public bool splitFiles = false;

        public bool checkIfSeqKitisInFolder()
        {
            var listOfFilesInDirectory = Global.connectionSession.RunCommand("cd " + comboBoxDirectoryType.SelectedItem.ToString() + "; ls");

            string[] lines = (listOfFilesInDirectory.Result).Split('\n');

            for (int i = 0; i < lines.Length - 1; i++) //-1 bo wyjdze bo za zakres
            {
                if (lines[i].ToLower() == "seqkit")
                    return true;
            }
            return false;
        }


        private void buttonSplitOption_Click(object sender, EventArgs e)
        {


            if (comboBoxQuery.SelectedIndex != -1)
            {
                if (checkIfSeqKitisInFolder())
                {
                    FormSplitOptions formSplitOptions = new FormSplitOptions(comboBoxDirectoryQuery.SelectedItem.ToString(), comboBoxQuery.SelectedItem.ToString(), labelJobName.Text);
                    formSplitOptions.ShowDialog();

                    if (splitNumber != "") //jesli splitnumber jest pusty nie usupelniaj czyli byl wcisniety x nie uzupelniaj
                    {
                        if (splitFiles)
                        {
                            labelInfoAboutSplit.Text = "You split the file into " + splitNumber + " files and you will order so many jobs";
                            infoSplitTOPRINT = "You split the file into " + splitNumber + " files and you will order so many jobs";
                        }
                        else
                        {
                            labelInfoAboutSplit.Text = "You divided the file by number of sequences,  " + splitNumber + " sequences per file";
                            infoSplitTOPRINT = "You divided the file by number of sequences,  " + splitNumber + " sequences per file";
                        }
                    }
                    else
                    {
                        labelInfoAboutSplit.Text = "";
                        infoSplitTOPRINT = "";
                    }
                }
                else
                {
                    MessageBox.Show("SeqKit is missing, add it to the folder with tool");
                }
            }
            else
            {
                MessageBox.Show("You must select the query file you want to split");
            }
        }

        private void textBoxTasksPerNode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                   (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBoxMemory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                   (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void checkBoxSplitJob_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSplitJob.Checked)
            {
                buttonSplitOption.Enabled = true;
                labelInfoAboutSplit.Text = infoSplitTOPRINT;
            }
            else
            {
                buttonSplitOption.Enabled = false;
                labelInfoAboutSplit.Text = "";
            }
        }

        public void setLinuxRight()
        {

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // buttonResetDatagridView.Visible = true;
                panelBorderStyle.Visible = true;
                this.FormBorderStyle = FormBorderStyle.None;
                labelFormName.Text = "Sinfo Partition";
                //buttonResetDatagridView.Visible = false;
                buttonClosewindow.Visible = false;
            }
            else
            {
                //buttonResetDatagridView.Visible = false;
                panelBorderStyle.Visible = false;
                buttonClosewindow.Visible = true;
                //buttonResize.Visible = false;
                // this.panelControlLocation.Location = new Point(0, 0);
            }
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            startchecking = false;
        }

        //https://stackoverflow.com/questions/1592876/make-a-borderless-form-movable?noredirect=1&lq=1

        // MOVE PANEL LINUX
        private bool mouseDown;
        private Point lastLocation;
        private void panelBorderStyle_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panelBorderStyle_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panelBorderStyle_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            if (mouseDown && this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                lastLocation = e.Location;
            }

        }

        private void buttonX_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            startchecking = false;
        }

        private void buttonClosewindow_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void textBoxTasksPerNode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
