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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class FormDirectoryRunJob : Form
    {
        public FormDirectoryRunJob()
        {
            InitializeComponent();
        }


        private void FormDirectoryRunJob_Load(object sender, EventArgs e)
        {

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

        string databasePSQ = "";
        string databasePIN ="";
        string databasePHR = "";
        public void loadListBoxFiles()
        {
            //labelMissingFiles.Text = "";
            var listOfFilesInDirectory = Global.connectionSession.RunCommand("cd " + Global.directoryTypeLocation + "; ls");

            string[] lines = (listOfFilesInDirectory.Result).Split('\n');

            databasePSQ = labelDatabase.Text + ".psq";
            databasePIN = labelDatabase.Text + ".pin";
            databasePHR = labelDatabase.Text + ".phr";

            // listViewFilesInDirectory.Clear(); // przy odswiezaniu wazne by wyczywscic pprzedna tablice
           
            string stdErr = "";
            string stdOut = "";
            string path = "";

         
        }


        public void setDataToJob(string jobName, string description, string tool, string partition, string timeLimit, string taskPerNode, string memory, string type, string query, string database, string splitInfo)
        {
            setLinuxRight();
            RunFromReRun = false;
            EditModeOFF();
            try
            {
                labelJobName.Text = jobName;
                label11Description.Text = description;
                labelTool.Text = tool;
                labelPartition.Text = partition.Replace("*","");
                labelTimelimit.Text = timeLimit;
                labelTasksPerNode.Text = taskPerNode;
                labelMemory.Text = memory;
                labelType.Text = type;
                labelQuery.Text = query;
                labelDatabase.Text = database;


                if (Global.splitQueryMultiplyJobs) //jesli dzielimy wyswietl
                {
                    labelCountFiles.Visible = true;
                    labelTotalNumberOfJobs.Visible = true;
                    if (Global.FormNewJobsADD3.OneFileSplitedTooManySequence) // jesli za malo seqwencji nic wybrane na plik rob jeden plik
                    {
                        labelTotalNumberOfJobs.Text = "1";
                    }
                    else
                    {
                        labelTotalNumberOfJobs.Text = countSplitedfFiles();
                    }
                   // labelTotalNumberOfJobs.Text= countSplitedfFiles();
                    labelSplitFilesB.Visible = true;
                    labelSplitFilesInfo.Visible = true;
                    labelSplitFilesInfo.Text = splitInfo;
                }
                else
                {
                    labelCountFiles.Visible = false;
                    labelTotalNumberOfJobs.Visible = false;
                    labelSplitFilesB.Visible = false;
                    labelSplitFilesInfo.Visible = false;
                }

                textBoxPolecenie.Text = "-outfmt 6 -evalue 10e-5";
                loadListBoxFiles();
            } //-num_threads +labelTasksPerNode.Text
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private void EditModeON()
        {
            buttonConfirm.Visible = true;
            buttonRunJob.Enabled = false;

            labelEDIT1.Visible = true;
            labelEDIT2.Visible = true;
            labelEDIT3.Visible = true;
            labelEDIT4.Visible = true;
            labelEDIT5.Visible = true;

            textBoxDescription.Visible = true;
            textBoxJobName.Visible = true;
            textBoxMemory.Visible = true;
            textBoxTaskPerNode.Visible = true;
            textBoxTimeLimit.Visible = true;
            comboBoxPartition.Visible = true;


            textBoxDescription.Text = label11Description.Text;
            textBoxJobName.Text = labelJobName.Text;
            textBoxMemory.Text = labelMemory.Text;
            textBoxTaskPerNode.Text = labelTasksPerNode.Text;
            textBoxTimeLimit.Text = labelTimelimit.Text;
            //comboBoxPartition.SelectedItem = labelPartition.Text;

        }
        private void EditModeOFF()
        {
            buttonConfirm.Visible = false;
            buttonRunJob.Enabled = true;

            labelEDIT1.Visible = false;
            labelEDIT2.Visible = false;
            labelEDIT3.Visible = false;
            labelEDIT4.Visible = false;
            labelEDIT5.Visible = false;
            labelEDIT6.Visible = false;

            textBoxDescription.Visible = false;
            textBoxJobName.Visible = false;
            textBoxMemory.Visible = false;
            textBoxTaskPerNode.Visible = false;
            textBoxTimeLimit.Visible = false;
            comboBoxPartition.Visible = false;
        }

        bool RunFromReRun = false;
        string ReRunTypeSplit;
        string ReRunDirectory;
        string ReRunDirectoryDB;
        string ReRunDirectoryQUERY;
        string ReRunDirectorySplitedFilesQuery;
        string ReRunMakeBlasDB;

        public void setDataToJobReRun(string jobName, string description, string tool, string partition, string timeLimit, string taskPerNode, string memory,
            string type, string query, string database, string splitInfo, string numberOfJobs, string reference, bool Splited, string TypeSplit, string Directory,
            string directoryDb, string directoryQuery, string directorySplitedFilesQuery, string makeBlastDB)
        {

            setLinuxRight();

            ReRunTypeSplit = TypeSplit;
            ReRunDirectory = Directory;
            ReRunDirectoryDB = directoryDb;
            ReRunDirectoryQUERY = directoryQuery;
            ReRunDirectorySplitedFilesQuery = directorySplitedFilesQuery;
            ReRunMakeBlasDB = makeBlastDB;

            //Console.WriteLine("ReRunMakeBlasDB: " + ReRunMakeBlasDB);
            //Console.WriteLine("ReRunDirectorySplitedFilesQuery: " + ReRunDirectorySplitedFilesQuery);
            //Console.WriteLine("ReRunDirectoryQUERY: " + ReRunDirectoryQUERY);
            //Console.WriteLine("ReRunDirectoryDB: " + ReRunDirectoryDB);
            //Console.WriteLine("ReRunDirectory: " + ReRunDirectory);
            //Console.WriteLine("ReRunTypeSplit: " + ReRunTypeSplit);
            //Console.WriteLine("splitInfo: " + splitInfo);
            //Console.WriteLine("numberOfJobs: " + numberOfJobs);

            foreach (var ele in Global.FormNewJobsADD3.bazaPartitionLimitSinfo) //by comboboxwybrac
            {
                comboBoxPartition.Items.Add(ele.PARTITION);
            }

            try
            {
                labelJobName.Text = jobName;
                label11Description.Text = description;
                labelTool.Text = tool;
                labelPartition.Text = partition.Replace("*", "");
                labelTimelimit.Text = timeLimit;
                labelTasksPerNode.Text = taskPerNode;
                labelMemory.Text = memory;
                labelType.Text = type;
                labelQuery.Text = query;
                labelDatabase.Text = database;


                if (Splited) //jesli dzielimy wyswietl
                {
                    labelCountFiles.Visible = true;
                    labelTotalNumberOfJobs.Visible = true;
                    labelTotalNumberOfJobs.Text = numberOfJobs;
                    // labelTotalNumberOfJobs.Text= countSplitedfFiles();
                    labelSplitFilesB.Visible = true;
                    labelSplitFilesInfo.Visible = true;
                    labelSplitFilesInfo.Text = splitInfo;
                }
                else
                {
                    labelCountFiles.Visible = false;
                    labelTotalNumberOfJobs.Visible = false;
                    labelSplitFilesB.Visible = false;
                    labelSplitFilesInfo.Visible = false;
                }

                textBoxPolecenie.Text = reference;
                RunFromReRun = true;
                EditModeON();
                //loadListBoxFiles();
            } //-num_threads +labelTasksPerNode.Text
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        public string countSplitedfFiles()
        { //zliczneie ilosci plikow
            string nrSplitedFilesCommand = String.Format("cd /tmp/lustre_shared/{0}/{1}{2}; ls -l . |egrep -c '^-'", Global.user, Global.directoryQueryLocation, Global.SplitedFilesQueryLocation);
            var nrSplitedFiles  = Global.connectionSession.RunCommand(nrSplitedFilesCommand);//create directory in tmpls
            return nrSplitedFiles.Result;
        }


        public string setGoodIndex(int index)
        {
            string numberGood = "";
            if(index < 10)
            {
                numberGood = "00" + index;
            }
            else if(index>9 && index <100)
            {
                numberGood = "0" + index;
            }
            else
            {
                numberGood = index.ToString();
            }

            return numberGood;
        }

        // bazasQueueUSER = new List<sQueue>(); //nowa lista by wyswietlic aktualna
        private void buttonRunJob_Click(object sender, EventArgs e)
        {
            if (RunFromReRun && ReRunTypeSplit != "NO SPLITING")
            {
                MessageBoxInfo messageBoxInfo = new MessageBoxInfo("Add new tasks, please wait... ::");
                messageBoxInfo.Show();

                int nrOfParts = Convert.ToInt32(labelTotalNumberOfJobs.Text);
                string JobNameIndex = "";
               // Console.WriteLine("NR Parts: " + nrOfParts);

                DateTime nowTime = DateTime.Now;
                // DODAWANIE JOBA MAIN JOBA KTORY BEDZIE DAWAL INOF O SPLITED JOBS

                string typeOfSpliting = ReRunTypeSplit;


                string historyJobsMainJob = String.Format("echo \"{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13};{14};{15};{16};{17};{18};{19};{20};{21}\" >> /home/users/{0}/.ServerFiles/HistoryJobsMainJob.txt", Global.user,
                                    labelJobName.Text, labelTool.Text, labelPartition.Text, labelTimelimit.Text, labelTasksPerNode.Text, labelMemory.Text, labelType.Text, labelQuery.Text,
                                    labelDatabase.Text, textBoxPolecenie.Text, typeOfSpliting, nrOfParts, ReRunDirectory, nowTime, label11Description.Text.Replace(";", ":"), "0", labelSplitFilesInfo.Text, ReRunDirectoryDB, ReRunDirectoryQUERY,ReRunDirectorySplitedFilesQuery,ReRunMakeBlasDB);

                for (int index = 1; index < nrOfParts + 1; index++)
                {
                    // setGoodIndex(index);
                    JobNameIndex = labelJobName.Text + "-" + setGoodIndex(index);

                   // Console.WriteLine("JobNameIndex: " + JobNameIndex);

                    string filesToCopy = @"{stdout-" + JobNameIndex + @".txt,stderr-" + JobNameIndex + @".txt}";//nazwy plikow wynikowych

                    string CopyFiles = String.Format("cp /tmp/lustre_shared/{0}/{1}{2} /home/users/{0}/{1}",
                        Global.user, ReRunDirectory, filesToCopy); //kopiowanie wynikow obliczen do katalog domowego

                    //string deleteTmpDirectory = @"rm -r /tmp/lustre_shared/" + Global.user + @"/" + Global.directoryTypeLocation; //for delete directory from a tmp
                    // echo \"{11}\" >>{1}; nie moze byc chyba bo jak bedzie error w folderku ktorym zlecono zadanko to usunie ten folder i do widzenia reszta zadan
                    string deleteCheckFile = ("rm /home/users/" + Global.user + "/" + ReRunDirectory + "check" + JobNameIndex + ".txt"); //for display good info and infor us if the data is

                    string[] splitString = labelQuery.Text.Split('.'); //podzial na dwa
                    string nameSplitedQueryIndex = String.Format("{0}.part_{1}.{2}", splitString[0], setGoodIndex(index), splitString[1]);

                    string staticPartOfCode = " -num_threads " + labelTasksPerNode.Text;

                    // string orderCode = String.Format("./{0} -query {1} -db {2} {3}", labelType.Text, labelQuery.Text, labelDatabase.Text, textBoxPolecenie.Text, Global.user, Global.directoryQueryLocation, Global.directoryDatabaseLocation, Global.directoryTypeLocation);

                    string copyFilesToTmpTypeEXE = labelType.Text;
                    string copyFilesToTmpDatabase = labelDatabase.Text + "*";//@"{" + labelDatabase.Text + ".*" + "}";

                    string runInPlaceDatabase = String.Format("/home/users/{0}/{2}{1}", Global.user, labelDatabase.Text, ReRunDirectoryDB);                                                                                                                                                                        // Global.connectionSession.RunCommand(lineDatabase);//przeniesienie plikow wybranych przez usera do tmp 
                    string runInPlaceQuery;
                    string LineCpQuery; 
                    if (ReRunDirectorySplitedFilesQuery == "NIE") //jesli nie ma dzielenia
                    {
                         runInPlaceQuery = String.Format("/tmp/lustre_shared/{0}/{1}{2}", Global.user, ReRunDirectoryQUERY, nameSplitedQueryIndex); // test zamaist kopiowac pliki uruchom z miejsca   
                         LineCpQuery = String.Format("cp /tmp/lustre_shared/{0}/{1}{3} /tmp/lustre_shared/{0}/{2}", Global.user, ReRunDirectoryQUERY, ReRunDirectory, nameSplitedQueryIndex);
                    }
                    else
                    {
                        LineCpQuery = String.Format("cp /tmp/lustre_shared/{0}/{1}{2}/{4} /tmp/lustre_shared/{0}/{3}", Global.user, ReRunDirectoryQUERY, ReRunDirectorySplitedFilesQuery, ReRunDirectory, nameSplitedQueryIndex); 
                        runInPlaceQuery = String.Format("/tmp/lustre_shared/{0}/{1}{2}/{3}", Global.user, ReRunDirectoryQUERY, ReRunDirectorySplitedFilesQuery, nameSplitedQueryIndex); // test zamaist kopiowac pliki uruchom z miejsca   
                    }
                    // string orderCode = String.Format("./{0} -query {1} -db {2} {3}{4}", labelType.Text, nameSplitedQueryIndex, labelDatabase.Text, textBoxPolecenie.Text, staticPartOfCode);
                    string orderCode = String.Format("./{0} -query {1} -db {2} {3}{4}", labelType.Text, runInPlaceQuery, runInPlaceDatabase, textBoxPolecenie.Text, staticPartOfCode);
                    string fileNameSH = "run_" + JobNameIndex + ".sh";

                   // Console.WriteLine("File name SH : " + fileNameSH);
                    //PRZENIESIENIE PLIKOW Z ROZNYCH MIEJSC WYBRANYCH DO FOLDERA TMP TAKIERGO DZIE JEST PLIK WYKONYWALNY

                    string mkdirDirectory = String.Format("mkdir /tmp/lustre_shared/{0}/{1} > /dev/null 2>&1", Global.user, ReRunDirectory);
                    Global.connectionSession.RunCommand(mkdirDirectory);//create directory in tmp
                    string makeBlastYesNo = "";


                    string lineTypeExe = String.Format("cp -n /home/users/{0}/{1}{2} /tmp/lustre_shared/{0}/{1}", Global.user, ReRunDirectory, copyFilesToTmpTypeEXE); //FilesToTMP, fileNameSH, tmpZnak);
                                                                                                                                                                                     // Global.connectionSession.RunCommand(lineTypeExe);//przeniesienie plikow wybranych przez usera do tmp 
                                                                                                                                                                                     //przeniesienie bazydnaych
                    string lineDatabase = String.Format("cp -n /home/users/{0}/{3}{2} /tmp/lustre_shared/{0}/{1}", Global.user, ReRunDirectory, copyFilesToTmpDatabase, ReRunDirectoryDB); //FilesToTMP, fileNameSH, tmpZnak);
                                                                                                                                                                                                                         //przeniesienie query

                    string sleepBeforeFinish = "sleep 2";
                    string createCheckFile = "cd /home/users/" + Global.user + "/" + ReRunDirectory + ";touch check" + JobNameIndex + ".txt";
                    Global.connectionSession.RunCommand("cd /home/users/" + Global.user + "/" + ReRunDirectory + ";touch check" + JobNameIndex + ".txt"); //create file check to if in function

                    //plik sbatch run caly
                    string line = String.Format("cd {0};echo  \"#!/bin/bash\" >{1};echo  \"#SBATCH --job-name={2}\" >>{1};echo  \"#SBATCH --time={3}\" >>{1};" +
            " echo  \"#SBATCH -p {4}\" >>{1};echo  \"#SBATCH --nodes=1\" >>{1};echo  \"#SBATCH --ntasks-per-node={5}\" >>{1};" +
            "echo  \"#SBATCH --mem={6}gb\" >>{1};echo  \"#SBATCH -e stderr-{2}.txt\" >>{1};echo  \"#SBATCH -o stdout-{2}.txt\" >>{1};" +
            " echo \"{16}\" >>{1}; echo \"{12}\" >>{1}; echo \"{13}\" >>{1}; echo \"{14}\" >>{1}; echo \"{11}\" >>{1}; echo  \"{7}\" >>{1}; echo \"{9}\" >>{1}; echo \"{15}\" >>{1}; echo \"{10}\" >>{1}",
            ReRunDirectory, fileNameSH, JobNameIndex, labelTimelimit.Text.Replace(".", "-"), labelPartition.Text,
            labelTasksPerNode.Text, labelMemory.Text, orderCode, Global.user, CopyFiles, deleteCheckFile, ReRunMakeBlasDB, lineTypeExe, lineDatabase, LineCpQuery, sleepBeforeFinish, createCheckFile); //zrobienie pliku sbatch


                    Global.connectionSession.RunCommand(line); //create plik batch z zawartoscia
                                                               //Console.WriteLine(line);
                                                               //przeneisienie pliku wykonywalnego WRESZCIE KURAN TO ODKRYL:EM

                    string lineRUNCOPY = String.Format("cp /home/users/{0}/{1}{2} /tmp/lustre_shared/{0}/{1} ", Global.user, ReRunDirectory, fileNameSH); //FilesToTMP, fileNameSH, tmpZnak);
                    Global.connectionSession.RunCommand(lineRUNCOPY);//przeniesienie plika run do folderu tmp

                    line = String.Format("cd /tmp/lustre_shared/{0}/{1}; sbatch {2}", Global.user, ReRunDirectory, fileNameSH);
                    // Console.WriteLine(line);
                    //wydobycie job id i jobname
                    string line2 = string.Format("{0} > /home/users/{1}/.ServerFiles/jobIDtmp.txt; cat /home/users/{1}/.ServerFiles/jobIDtmp.txt | cut -d \" \" -f4 > /home/users/{1}/.ServerFiles/jobID.txt", line, Global.user);
                    Global.connectionSession.RunCommand(line2); //uruchomienie sbatch na tmp i zapisanie job id
                                                                //Console.WriteLine(line2);
                                                                //zapisanie job id i job name to remember history of file
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
                           // Console.WriteLine(tempLine[oo]);
                        }
                    }

                    var isNumericJobID = int.TryParse(outputJobID.Result, out int JobIdCheck);
                  //  Console.WriteLine(outputJobID.Result);
                    if (!isNumericJobID)
                    {
                        //MessageBox.Show("No access to the selected partition");
                      //  Console.WriteLine(outputJobID.Result);
                        Global.connectionSession.RunCommand("rm /home/users/" + Global.user + "/" + ReRunDirectory + " run_" + JobNameIndex + ".sh");
                        Global.connectionSession.RunCommand(deleteCheckFile);
                        messageBoxInfo.Close();
                        //jesli wybrano partycje do ktorej nie mamy dostepu usun plik
                    }
                    else
                    {
                        nowTime = DateTime.Now;

                        string historyJobsAddItme = String.Format("echo \"{0};{2};{3};{4};{5}\" >> /home/users/{1}/.ServerFiles/HistoryJobs.txt", outputJobID.Result.Replace("\n", ""), Global.user,
                            JobNameIndex, ReRunDirectory, nowTime, label11Description.Text.Replace(";", ":"));


                        Global.connectionSession.RunCommand(historyJobsAddItme);
                        // zapisanie job id i job name to remember history of file END
                        Global.JobIDFromProgramm.Add(JobIdCheck);
                        RunFromReRun = false;
                        EditModeOFF();

                        //sacct -u tomaszkuzma --format=JobID,JobName,Submit,State |grep -v '.ba+'
                    }
                }
                Global.connectionSession.RunCommand(historyJobsMainJob); //od jednego joba
                messageBoxInfo.Close();
                MessageBox.Show("Job has been added");
                this.Visible = false;

            }
            else if(Global.splitQueryMultiplyJobs && RunFromReRun==false)
            {
                MessageBoxInfo messageBoxInfo = new MessageBoxInfo("Add new tasks, please wait... ::");
                messageBoxInfo.Show();
                string nrOfPartsString;
                Global.splitQueryMultiplyJobs = false;
                if (Global.FormNewJobsADD3.OneFileSplitedTooManySequence)
                {
                    nrOfPartsString = "1";
                }
                else
                {
                    nrOfPartsString = countSplitedfFiles();
                }
                int nrOfParts = Convert.ToInt32(nrOfPartsString);
                string JobNameIndex = "";
              //  Console.WriteLine("NR Parts: " + nrOfParts);

                DateTime nowTime = DateTime.Now;
                // DODAWANIE JOBA MAIN JOBA KTORY BEDZIE DAWAL INOF O SPLITED JOBS

                string typeOfSpliting = "";
                if (Global.SequencePerFile)
                {
                    typeOfSpliting = "S";
                }
                else
                {
                    typeOfSpliting = "P";
                }


        string historyJobsMainJob = String.Format("echo \"{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13};{14};{15};{16};{17};{18};{19};{20};{21}\" >> /home/users/{0}/.ServerFiles/HistoryJobsMainJob.txt", Global.user,
                            labelJobName.Text,labelTool.Text, labelPartition.Text,labelTimelimit.Text,labelTasksPerNode.Text,labelMemory.Text,labelType.Text,labelQuery.Text,
                            labelDatabase.Text, textBoxPolecenie.Text,typeOfSpliting,nrOfParts, Global.directoryTypeLocation, nowTime, label11Description.Text.Replace(";", ":"),Global.numberSplitedFiles, labelSplitFilesInfo.Text, Global.directoryDatabaseLocation, Global.directoryQueryLocation, Global.SplitedFilesQueryLocation, Global.makeblastdbComand);

                for (int index = 1; index < nrOfParts + 1; index++)
                {
                    // setGoodIndex(index);
                    JobNameIndex = labelJobName.Text + "-" + setGoodIndex(index);

                    //Console.WriteLine("JobNameIndex: " + JobNameIndex);

                    string filesToCopy = @"{stdout-" + JobNameIndex + @".txt,stderr-" + JobNameIndex + @".txt}";//nazwy plikow wynikowych

                    string CopyFiles = String.Format("cp /tmp/lustre_shared/{0}/{1}{2} /home/users/{0}/{1}",
                        Global.user, Global.directoryTypeLocation, filesToCopy); //kopiowanie wynikow obliczen do katalog domowego

                    //string deleteTmpDirectory = @"rm -r /tmp/lustre_shared/" + Global.user + @"/" + Global.directoryTypeLocation; //for delete directory from a tmp
                    // echo \"{11}\" >>{1}; nie moze byc chyba bo jak bedzie error w folderku ktorym zlecono zadanko to usunie ten folder i do widzenia reszta zadan
                    string deleteCheckFile = ("rm /home/users/" + Global.user + "/" + Global.directoryTypeLocation + "check" + JobNameIndex + ".txt"); //for display good info and infor us if the data is
                                                                                                                                                    
                    //podzial query
                    string[] splitString = labelQuery.Text.Split('.'); //podzial na dwa
                    string nameSplitedQueryIndex = String.Format("{0}.part_{1}.{2}", splitString[0], setGoodIndex(index), splitString[1]);

                    string staticPartOfCode = " -num_threads " + labelTasksPerNode.Text;
                   
                    // string orderCode = String.Format("./{0} -query {1} -db {2} {3}", labelType.Text, labelQuery.Text, labelDatabase.Text, textBoxPolecenie.Text, Global.user, Global.directoryQueryLocation, Global.directoryDatabaseLocation, Global.directoryTypeLocation);

                    string copyFilesToTmpTypeEXE = labelType.Text;
                    string copyFilesToTmpDatabase = labelDatabase.Text + "*";//@"{" + labelDatabase.Text + ".*" + "}";

                    string runInPlaceDatabase = String.Format("/home/users/{0}/{2}{1}", Global.user, labelDatabase.Text, Global.directoryDatabaseLocation);                                                                                                                                                                        // Global.connectionSession.RunCommand(lineDatabase);//przeniesienie plikow wybranych przez usera do tmp 
                    string runInPlaceQuery = String.Format("/tmp/lustre_shared/{0}/{1}{2}/{3}", Global.user, Global.directoryQueryLocation, Global.SplitedFilesQueryLocation, nameSplitedQueryIndex); // test zamaist kopiowac pliki uruchom z miejsca   

                    // string orderCode = String.Format("./{0} -query {1} -db {2} {3}{4}", labelType.Text, nameSplitedQueryIndex, labelDatabase.Text, textBoxPolecenie.Text, staticPartOfCode);
                    string orderCode = String.Format("./{0} -query {1} -db {2} {3}{4}", labelType.Text, runInPlaceQuery, runInPlaceDatabase, textBoxPolecenie.Text, staticPartOfCode);
                    string fileNameSH = "run_" + JobNameIndex + ".sh";

                   // Console.WriteLine("File name SH : " + fileNameSH);
                    //PRZENIESIENIE PLIKOW Z ROZNYCH MIEJSC WYBRANYCH DO FOLDERA TMP TAKIERGO DZIE JEST PLIK WYKONYWALNY

                    string mkdirDirectory = String.Format("mkdir /tmp/lustre_shared/{0}/{1} > /dev/null 2>&1", Global.user, Global.directoryTypeLocation);
                    Global.connectionSession.RunCommand(mkdirDirectory);//create directory in tmp
                    string makeBlastYesNo = "";

                    string lineTypeExe = String.Format("cp -n /home/users/{0}/{1}{2} /tmp/lustre_shared/{0}/{1}", Global.user, Global.directoryTypeLocation, copyFilesToTmpTypeEXE); //FilesToTMP, fileNameSH, tmpZnak);
                                                                                                                                                                                     // Global.connectionSession.RunCommand(lineTypeExe);//przeniesienie plikow wybranych przez usera do tmp 
                                                                                                                                                                                     //przeniesienie bazydnaych
                    string lineDatabase = String.Format("cp -n /home/users/{0}/{3}{2} /tmp/lustre_shared/{0}/{1}", Global.user, Global.directoryTypeLocation, copyFilesToTmpDatabase, Global.directoryDatabaseLocation); //FilesToTMP, fileNameSH, tmpZnak);
                                                                                   //przeniesienie query
                    string LineCpQuery = String.Format("cp /tmp/lustre_shared/{0}/{1}{2}/{4} /tmp/lustre_shared/{0}/{3}", Global.user, Global.directoryQueryLocation, Global.SplitedFilesQueryLocation, Global.directoryTypeLocation, nameSplitedQueryIndex);                                                                                                                                                                                       //Global.connectionSession.RunCommand(lineQuery);//przeniesienie plikow wybranych przez usera do tmp  //> /dev/null 2>&1


                    string memorySize;
                    if (checkPartitionToMemeoryLimitBigmem() == 256)
                    {
                        memorySize = "mb";
                    }
                    else
                    {
                        memorySize = "gb";
                    }

                    string sleepBeforeFinish = "sleep 2";
                    string createCheckFile = "cd /home/users/" + Global.user + "/" + Global.directoryTypeLocation + ";touch check" + JobNameIndex + ".txt";
                    Global.connectionSession.RunCommand("cd /home/users/" + Global.user + "/" + Global.directoryTypeLocation + ";touch check" + JobNameIndex + ".txt"); //create file check to if in function

                    //plik sbatch run caly
                    //        string line = String.Format("cd {0};echo  \"#!/bin/bash\" >{1};echo  \"#SBATCH --job-name={2}\" >>{1};echo  \"#SBATCH --time={3}\" >>{1};" +
                    //" echo  \"#SBATCH -p {4}\" >>{1};echo  \"#SBATCH --nodes=1\" >>{1};echo  \"#SBATCH --ntasks-per-node={5}\" >>{1};" +
                    //"echo  \"#SBATCH --mem={6}{18}\" >>{1};echo  \"#SBATCH -e stderr-{2}.txt\" >>{1};echo  \"#SBATCH -o stdout-{2}.txt\" >>{1};" +
                    //" echo \"{16}\" >>{1}; echo \"{12}\" >>{1}; echo \"{13}\" >>{1}; echo \"{14}\" >>{1}; echo \"{11}\" >>{1}; echo  \"{7}\" >>{1}; echo \"{9}\" >>{1}; echo \"{15}\" >>{1}; echo \"{10}\" >>{1}",
                    //Global.directoryTypeLocation, fileNameSH, JobNameIndex, labelTimelimit.Text.Replace(".", "-"), labelPartition.Text,
                    //labelTasksPerNode.Text, labelMemory.Text, orderCode, Global.user, CopyFiles, deleteCheckFile, Global.makeblastdbComand, lineTypeExe,
                    //lineDatabase, LineCpQuery, sleepBeforeFinish, createCheckFile, memorySize); //zrobienie pliku sbatch
                    string line = String.Format("cd {0};echo  \"#!/bin/bash\" >{1};echo  \"#SBATCH --job-name={2}\" >>{1};echo  \"#SBATCH --time={3}\" >>{1};" +
" echo  \"#SBATCH -p {4}\" >>{1};echo  \"#SBATCH --nodes=1\" >>{1};echo  \"#SBATCH --ntasks-per-node={5}\" >>{1};" +
"echo  \"#SBATCH --mem={6}gb\" >>{1};echo  \"#SBATCH -e stderr-{2}.txt\" >>{1};echo  \"#SBATCH -o stdout-{2}.txt\" >>{1};" +
" echo \"{16}\" >>{1}; echo \"{12}\" >>{1}; echo \"{13}\" >>{1}; echo \"{14}\" >>{1}; echo \"{11}\" >>{1}; echo  \"{7}\" >>{1}; echo \"{9}\" >>{1}; echo \"{15}\" >>{1}; echo \"{10}\" >>{1}",
Global.directoryTypeLocation, fileNameSH, JobNameIndex, labelTimelimit.Text.Replace(".", "-"), labelPartition.Text,
labelTasksPerNode.Text, labelMemory.Text, orderCode, Global.user, CopyFiles, deleteCheckFile, Global.makeblastdbComand, lineTypeExe,
lineDatabase, LineCpQuery, sleepBeforeFinish, createCheckFile); //zrobienie pliku sbatch

                    Global.connectionSession.RunCommand(line); //create plik batch z zawartoscia
                                                               //Console.WriteLine(line);
                                                               //przeneisienie pliku wykonywalnego WRESZCIE

                    string lineRUNCOPY = String.Format("cp /home/users/{0}/{1}{2} /tmp/lustre_shared/{0}/{1} ", Global.user, Global.directoryTypeLocation, fileNameSH); //FilesToTMP, fileNameSH, tmpZnak);
                    Global.connectionSession.RunCommand(lineRUNCOPY);//przeniesienie plika run do folderu tmp
                                                                     //Console.WriteLine(line);

                    
                   // Global.connectionSession.RunCommand("cd /home/users/" + Global.user + "/" + Global.directoryTypeLocation + ";touch check" + JobNameIndex + ".txt"); //create file check to if in function

                    line = String.Format("cd /tmp/lustre_shared/{0}/{1}; sbatch {2}", Global.user, Global.directoryTypeLocation, fileNameSH);
                    // Console.WriteLine(line);
                    //wydobycie job id i jobname
                    string line2 = string.Format("{0} > /home/users/{1}/.ServerFiles/jobIDtmp.txt; cat /home/users/{1}/.ServerFiles/jobIDtmp.txt | cut -d \" \" -f4 > /home/users/{1}/.ServerFiles/jobID.txt", line, Global.user);
                    Global.connectionSession.RunCommand(line2); //uruchomienie sbatch na tmp i zapisanie job id
                                                                //Console.WriteLine(line2);
                                                                //zapisanie job id i job name to remember history of file
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
                          //  Console.WriteLine(tempLine[oo]);
                        }
                    }

                    var isNumericJobID = int.TryParse(outputJobID.Result, out int JobIdCheck);
                   // Console.WriteLine(outputJobID.Result);
                    if (!isNumericJobID)
                    {
                        //MessageBox.Show("No access to the selected partition");
                      //  Console.WriteLine(outputJobID.Result);
                        Global.connectionSession.RunCommand("rm /home/users/" + Global.user + "/" + Global.directoryTypeLocation + " run_" + JobNameIndex + ".sh");
                        Global.connectionSession.RunCommand(deleteCheckFile);
                        messageBoxInfo.Close();
                        //jesli wybrano partycje do ktorej nie mamy dostepu usun plik
                    }
                    else
                    {
                        nowTime = DateTime.Now;

                        string historyJobsAddItme = String.Format("echo \"{0};{2};{3};{4};{5}\" >> /home/users/{1}/.ServerFiles/HistoryJobs.txt", outputJobID.Result.Replace("\n", ""), Global.user, 
                            JobNameIndex, Global.directoryTypeLocation, nowTime, label11Description.Text.Replace(";", ":"));

                        
                        Global.connectionSession.RunCommand(historyJobsAddItme);
                        // zapisanie job id i job name to remember history of file END
                        Global.JobIDFromProgramm.Add(JobIdCheck);

                        //sacct -u tomaszkuzma --format=JobID,JobName,Submit,State |grep -v '.ba+'
                    }
                }
                Global.connectionSession.RunCommand(historyJobsMainJob); //od jednego joba
                messageBoxInfo.Close();
                MessageBox.Show("Job has been added");
                this.Visible = false;

            }
            else if(RunFromReRun && ReRunTypeSplit == "NO SPLITING")
            {
                MessageBoxInfo messageBoxInfo = new MessageBoxInfo("Add new task, please wait...");
                messageBoxInfo.Show();

              //  Console.WriteLine("Add new task, please wait... no SPLIted xD");
                //DODAWANIE DO MAIN JOBA
                DateTime nowTime = DateTime.Now;
                // DODAWANIE JOBA MAIN JOBA KTORY BEDZIE DAWAL INOF O SPLITED JOBS

                string typeOfSpliting = "NO SPLITING";
                string nrOfParts = "1";

                string historyJobsMainJob = String.Format("echo \"{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13};{14};{15};0;{16};{17};{18};{19};{20}\" >> /home/users/{0}/.ServerFiles/HistoryJobsMainJob.txt", Global.user,
                                    labelJobName.Text, labelTool.Text, labelPartition.Text, labelTimelimit.Text, labelTasksPerNode.Text, labelMemory.Text, labelType.Text, labelQuery.Text,
                                    labelDatabase.Text, textBoxPolecenie.Text, typeOfSpliting, nrOfParts, ReRunDirectory, nowTime, label11Description.Text.Replace(";", ":"), 
                                    labelSplitFilesInfo.Text, ReRunDirectoryDB, ReRunDirectoryQUERY, "NIE", ReRunMakeBlasDB);

                string filesToCopy = @"{stdout-" + labelJobName.Text + @".txt,stderr-" + labelJobName.Text + @".txt}";//nazwy plikow wynikowych

                string CopyFiles = String.Format("cp /tmp/lustre_shared/{0}/{1}{2} /home/users/{0}/{1}",
                    Global.user, ReRunDirectory, filesToCopy); //kopiowanie wynikow obliczen do katalog domowego


                string deleteTmpDirectory = @"rm -r /tmp/lustre_shared/" + Global.user + @"/" + ReRunDirectory; //for delete directory from a tmp
                                                                                                                              // echo \"{11}\" >>{1}; nie moze byc chyba bo jak bedzie error w folderku ktorym zlecono zadanko to usunie ten folder i do widzenia reszta zadan
                string deleteCheckFile = ("rm /home/users/" + Global.user + "/" + ReRunDirectory + "check" + labelJobName.Text + ".txt"); //for display good info and infor us if the data is
                                                                                                                                                        //transported from tmp to our directory
                                                                                                                                                        //"./blastp -query bsu.fa -db eco.fa -outfmt 6 -evalue 10e-5 -num_threads 4";
                                                                                                                                                        // string orderCode = String.Format("/home/users/{4}/{7}{0} -query /home/users/{4}/{5}{1} -db /home/users/{4}/{6}{2} {3}", labelType.Text, labelQuery.Text, labelDatabase.Text, textBoxPolecenie.Text, Global.user, Global.directoryQueryLocation, Global.directoryDatabaseLocation, Global.directoryTypeLocation);
                string runInPlaceDatabase = String.Format("/home/users/{0}/{2}{1}", Global.user, labelDatabase.Text, ReRunDirectoryDB);                                                                                                                                                                        // Global.connectionSession.RunCommand(lineDatabase);//przeniesienie plikow wybranych przez usera do tmp 
                string runInPlaceQuery = String.Format("/tmp/lustre_shared/{0}/{1}{2}", Global.user, ReRunDirectoryQUERY, labelQuery.Text); // test zamaist kopiowac pliki uruchom z miejsca   

                string staticPartOfCode = " -num_threads " + labelTasksPerNode.Text;
                //string orderCode = String.Format("./{0} -query {1} -db {2} {3}{4}", labelType.Text, labelQuery.Text, labelDatabase.Text, textBoxPolecenie.Text, staticPartOfCode);
                string orderCode = String.Format("./{0} -query {1} -db {2} {3}{4}", labelType.Text, runInPlaceQuery, runInPlaceDatabase, textBoxPolecenie.Text, staticPartOfCode);
                // string orderCode = String.Format("./{0} -query {1} -db {2} {3}", labelType.Text, labelQuery.Text, labelDatabase.Text, textBoxPolecenie.Text, Global.user, Global.directoryQueryLocation, Global.directoryDatabaseLocation, Global.directoryTypeLocation);

                string fileNameSH = "run_" + labelJobName.Text + ".sh";
                //PRZENIESIENIE PLIKOW Z ROZNYCH MIEJSC WYBRANYCH DO FOLDERA TMP TAKIERGO DZIE JEST PLIK WYKONYWALNY

                string mkdirDirectory = String.Format("mkdir /tmp/lustre_shared/{0}/{1} > /dev/null 2>&1", Global.user, ReRunDirectory);
                Global.connectionSession.RunCommand(mkdirDirectory);//create directory in tmp
                string makeBlastYesNo = "";
            
                string copyFilesToTmpTypeEXE = labelType.Text;
                string copyFilesToTmpDatabase = labelDatabase.Text + "*";//@"{" + labelDatabase.Text + ".*" + "}";
                string copyFilesToTmpQuery = labelQuery.Text;
                string lineTypeExe = String.Format("cp -n /home/users/{0}/{1}{2} /tmp/lustre_shared/{0}/{1}", Global.user, ReRunDirectory, copyFilesToTmpTypeEXE); //FilesToTMP, fileNameSH, tmpZnak);
                                                                                                      //przeniesienie bazydnaych
                string lineDatabase = String.Format("cp -n /home/users/{0}/{3}{2} /tmp/lustre_shared/{0}/{1}", Global.user, ReRunDirectory, copyFilesToTmpDatabase, ReRunDirectoryDB); //FilesToTMP, fileNameSH, tmpZnak);
                                                                                  //przeniesienie query
                string lineQuery = String.Format("cp /home/users/{0}/{3}{2} /tmp/lustre_shared/{0}/{1} ", Global.user, ReRunDirectory, copyFilesToTmpQuery, ReRunDirectoryQUERY); //FilesToTMP, fileNameSH, tmpZnak);

                string sleepBeforeFinish = "sleep 2";
                string createCheckFile = "cd /home/users/" + Global.user + "/" + ReRunDirectory + ";touch check" + labelJobName.Text + ".txt";
                Global.connectionSession.RunCommand("cd /home/users/" + Global.user + "/" + ReRunDirectory + ";touch check" + labelJobName.Text + ".txt"); //create file check to if in function
                //plik sbatch run caly
                string line = String.Format("cd {0};echo  \"#!/bin/bash\" >{1};echo  \"#SBATCH --job-name={2}\" >>{1};echo  \"#SBATCH --time={3}\" >>{1};" +
        " echo  \"#SBATCH -p {4}\" >>{1};echo  \"#SBATCH --nodes=1\" >>{1};echo  \"#SBATCH --ntasks-per-node={5}\" >>{1};" +
        "echo  \"#SBATCH --mem={6}gb\" >>{1};echo  \"#SBATCH -e stderr-{2}.txt\" >>{1};echo  \"#SBATCH -o stdout-{2}.txt\" >>{1};" +
        " echo \"{16}\" >>{1}; echo \"{12}\" >>{1}; echo \"{13}\" >>{1}; echo \"{14}\" >>{1}; echo \"{11}\" >>{1}; echo  \"{7}\" >>{1}; echo \"{9}\" >>{1}; echo \"{15}\" >>{1}; echo \"{10}\" >>{1}",
        ReRunDirectory, fileNameSH, labelJobName.Text, labelTimelimit.Text.Replace(".", "-"), labelPartition.Text,
        labelTasksPerNode.Text, labelMemory.Text, orderCode, Global.user, CopyFiles, deleteCheckFile, ReRunMakeBlasDB, lineTypeExe, lineDatabase, lineQuery, sleepBeforeFinish, createCheckFile); //zrobienie pliku sbatch


                Global.connectionSession.RunCommand(line); //create plik batch z zawartoscia
                                                           //Console.WriteLine(line);
                                                           //przeneisienie pliku wykonywalnego WRESZCIE KURAN TO ODKRYL:EM


                string lineRUNCOPY = String.Format("cp /home/users/{0}/{1}{2} /tmp/lustre_shared/{0}/{1} ", Global.user, ReRunDirectory, fileNameSH); //FilesToTMP, fileNameSH, tmpZnak);
                Global.connectionSession.RunCommand(lineRUNCOPY);//przeniesienie plika run do folderu tmp
                                                                 //Console.WriteLine(line);


                line = String.Format("cd /tmp/lustre_shared/{0}/{1}; sbatch {2}", Global.user, ReRunDirectory, fileNameSH);
                // Console.WriteLine(line);
                //wydobycie job id i jobname
                string line2 = string.Format("{0} > /home/users/{1}/.ServerFiles/jobIDtmp.txt; cat /home/users/{1}/.ServerFiles/jobIDtmp.txt | cut -d \" \" -f4 > /home/users/{1}/.ServerFiles/jobID.txt", line, Global.user);
                Global.connectionSession.RunCommand(line2); //uruchomienie sbatch na tmp i zapisanie job id
                                                            //Console.WriteLine(line2);
                                                            //zapisanie job id i job name to remember history of file
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
                      //  Console.WriteLine(tempLine[oo]);
                    }
                }

                var isNumericJobID = int.TryParse(outputJobID.Result, out int JobIdCheck);
                //Console.WriteLine(outputJobID.Result);
                if (!isNumericJobID)
                {
                    MessageBox.Show("No access to the selected partition or diffrent problem " + outputJobID.Result);
                   // Console.WriteLine(outputJobID.Result);
                    Global.connectionSession.RunCommand("rm /home/users/" + Global.user + "/" + ReRunDirectory + " run_" + labelJobName.Text + ".sh");
                    Global.connectionSession.RunCommand(deleteCheckFile);
                    messageBoxInfo.Close();
                    //jesli wybrano partycje do ktorej nie mamy dostepu usun plik
                }
                else
                {
                    nowTime = DateTime.Now;

                    string historyJobsAddItme = String.Format("echo \"{0};{2};{3};{4};{5}\" >> /home/users/{1}/.ServerFiles/HistoryJobs.txt", outputJobID.Result.Replace("\n", ""), Global.user, labelJobName.Text, ReRunDirectory, nowTime, label11Description.Text.Replace(";", ":"));

                    Global.connectionSession.RunCommand(historyJobsAddItme);
                    Global.connectionSession.RunCommand(historyJobsMainJob); //dodanie do main Jobs
                    // zapisanie job id i job name to remember history of file END
                    Global.JobIDFromProgramm.Add(JobIdCheck);
                    RunFromReRun = false;
                    EditModeOFF();
                    messageBoxInfo.Close();

                    MessageBox.Show("Job has been added");
                    this.Visible = false;
                    //sacct -u tomaszkuzma --format=JobID,JobName,Submit,State |grep -v '.ba+'
                }
            }
            else
            {
                MessageBoxInfo messageBoxInfo = new MessageBoxInfo("Add new task, please wait...");
                messageBoxInfo.Show();

                //Console.WriteLine("Add new task, please wait... no SPLIted xD");
                //DODAWANIE DO MAIN JOBA
                DateTime nowTime = DateTime.Now;
                // DODAWANIE JOBA MAIN JOBA KTORY BEDZIE DAWAL INOF O SPLITED JOBS

                string typeOfSpliting = "NO SPLITING";
                string nrOfParts = "1";

                string historyJobsMainJob = String.Format("echo \"{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13};{14};{15};0;{16};{17};{18};{19};{20}\" >> /home/users/{0}/.ServerFiles/HistoryJobsMainJob.txt", Global.user,
                                    labelJobName.Text, labelTool.Text, labelPartition.Text, labelTimelimit.Text, labelTasksPerNode.Text, labelMemory.Text, labelType.Text, labelQuery.Text,
                                    labelDatabase.Text, textBoxPolecenie.Text, typeOfSpliting, nrOfParts, Global.directoryTypeLocation, nowTime, label11Description.Text.Replace(";", ":"), labelSplitFilesInfo.Text, Global.directoryDatabaseLocation, Global.directoryQueryLocation, "NIE", Global.makeblastdbComand);




                string filesToCopy = @"{stdout-" + labelJobName.Text + @".txt,stderr-" + labelJobName.Text + @".txt}";//nazwy plikow wynikowych

                string CopyFiles = String.Format("cp /tmp/lustre_shared/{0}/{1}{2} /home/users/{0}/{1}",
                    Global.user, Global.directoryTypeLocation, filesToCopy); //kopiowanie wynikow obliczen do katalog domowego


                string deleteTmpDirectory = @"rm -r /tmp/lustre_shared/" + Global.user + @"/" + Global.directoryTypeLocation; //for delete directory from a tmp
                                                                                                                              // echo \"{11}\" >>{1}; nie moze byc chyba bo jak bedzie error w folderku ktorym zlecono zadanko to usunie ten folder i do widzenia reszta zadan
                string deleteCheckFile = ("rm /home/users/" + Global.user + "/" + Global.directoryTypeLocation + "check" + labelJobName.Text + ".txt"); //for display good info and infor us if the data is
                                                                                                                                                        //transported from tmp to our directory
                                                                                                                                                        //"./blastp -query bsu.fa -db eco.fa -outfmt 6 -evalue 10e-5 -num_threads 4";
                                                                                                                                                        // string orderCode = String.Format("/home/users/{4}/{7}{0} -query /home/users/{4}/{5}{1} -db /home/users/{4}/{6}{2} {3}", labelType.Text, labelQuery.Text, labelDatabase.Text, textBoxPolecenie.Text, Global.user, Global.directoryQueryLocation, Global.directoryDatabaseLocation, Global.directoryTypeLocation);
                string runInPlaceDatabase = String.Format("/home/users/{0}/{2}{1}", Global.user, labelDatabase.Text, Global.directoryDatabaseLocation);                                                                                                                                                                        // Global.connectionSession.RunCommand(lineDatabase);//przeniesienie plikow wybranych przez usera do tmp 
                string runInPlaceQuery = String.Format("/tmp/lustre_shared/{0}/{1}{2}", Global.user, Global.directoryQueryLocation, labelQuery.Text); // test zamaist kopiowac pliki uruchom z miejsca   

                string staticPartOfCode = " -num_threads " + labelTasksPerNode.Text;
                //string orderCode = String.Format("./{0} -query {1} -db {2} {3}{4}", labelType.Text, labelQuery.Text, labelDatabase.Text, textBoxPolecenie.Text, staticPartOfCode);
                string orderCode = String.Format("./{0} -query {1} -db {2} {3}{4}", labelType.Text, runInPlaceQuery, runInPlaceDatabase, textBoxPolecenie.Text, staticPartOfCode);
                // string orderCode = String.Format("./{0} -query {1} -db {2} {3}", labelType.Text, labelQuery.Text, labelDatabase.Text, textBoxPolecenie.Text, Global.user, Global.directoryQueryLocation, Global.directoryDatabaseLocation, Global.directoryTypeLocation);

                string fileNameSH = "run_" + labelJobName.Text + ".sh";
                //PRZENIESIENIE PLIKOW Z ROZNYCH MIEJSC WYBRANYCH DO FOLDERA TMP TAKIERGO DZIE JEST PLIK WYKONYWALNY

                string mkdirDirectory = String.Format("mkdir /tmp/lustre_shared/{0}/{1} > /dev/null 2>&1", Global.user, Global.directoryTypeLocation);
                Global.connectionSession.RunCommand(mkdirDirectory);//create directory in tmp
                string makeBlastYesNo = "";
           
                string copyFilesToTmpTypeEXE = labelType.Text;
                string copyFilesToTmpDatabase = labelDatabase.Text + "*";//@"{" + labelDatabase.Text + ".*" + "}";
                string copyFilesToTmpQuery = labelQuery.Text;
                string lineTypeExe = String.Format("cp -n /home/users/{0}/{1}{2} /tmp/lustre_shared/{0}/{1}", Global.user, Global.directoryTypeLocation, copyFilesToTmpTypeEXE); //FilesToTMP, fileNameSH, tmpZnak);                                                                                                                                                 
              //przeniesienie bazydnaych
                string lineDatabase = String.Format("cp -n /home/users/{0}/{3}{2} /tmp/lustre_shared/{0}/{1}", Global.user, Global.directoryTypeLocation, copyFilesToTmpDatabase, Global.directoryDatabaseLocation); //FilesToTMP, fileNameSH, tmpZnak);

                string lineQuery = String.Format("cp /home/users/{0}/{3}{2} /tmp/lustre_shared/{0}/{1} ", Global.user, Global.directoryTypeLocation, copyFilesToTmpQuery, Global.directoryQueryLocation); //FilesToTMP, fileNameSH, tmpZnak);


                string sleepBeforeFinish = "sleep 2";
                string createCheckFile = "cd /home/users/" + Global.user + "/" + Global.directoryTypeLocation + ";touch check" + labelJobName.Text + ".txt";
                Global.connectionSession.RunCommand("cd /home/users/" + Global.user + "/" + Global.directoryTypeLocation + ";touch check" + labelJobName.Text + ".txt"); //create file check to if in function
                //plik sbatch run caly
                string line = String.Format("cd {0};echo  \"#!/bin/bash\" >{1};echo  \"#SBATCH --job-name={2}\" >>{1};echo  \"#SBATCH --time={3}\" >>{1};" +
        " echo  \"#SBATCH -p {4}\" >>{1};echo  \"#SBATCH --nodes=1\" >>{1};echo  \"#SBATCH --ntasks-per-node={5}\" >>{1};" +
        "echo  \"#SBATCH --mem={6}gb\" >>{1};echo  \"#SBATCH -e stderr-{2}.txt\" >>{1};echo  \"#SBATCH -o stdout-{2}.txt\" >>{1};" +
        " echo \"{16}\" >>{1}; echo \"{12}\" >>{1}; echo \"{13}\" >>{1}; echo \"{14}\" >>{1}; echo \"{11}\" >>{1}; echo  \"{7}\" >>{1}; echo \"{9}\" >>{1}; echo \"{15}\" >>{1}; echo \"{10}\" >>{1}",
        Global.directoryTypeLocation, fileNameSH, labelJobName.Text, labelTimelimit.Text.Replace(".", "-"), labelPartition.Text,
        labelTasksPerNode.Text, labelMemory.Text, orderCode, Global.user, CopyFiles, deleteCheckFile, Global.makeblastdbComand, lineTypeExe, lineDatabase, lineQuery, sleepBeforeFinish, createCheckFile); //zrobienie pliku sbatch


                Global.connectionSession.RunCommand(line); //create plik batch z zawartoscia
                                                           //Console.WriteLine(line);
                                                           //przeneisienie pliku wykonywalnego WRESZCIE 

                string lineRUNCOPY = String.Format("cp /home/users/{0}/{1}{2} /tmp/lustre_shared/{0}/{1} ", Global.user, Global.directoryTypeLocation, fileNameSH); //FilesToTMP, fileNameSH, tmpZnak);
                Global.connectionSession.RunCommand(lineRUNCOPY);//przeniesienie plika run do folderu tmp
                                                                 //Console.WriteLine(line);
                

                line = String.Format("cd /tmp/lustre_shared/{0}/{1}; sbatch {2}", Global.user, Global.directoryTypeLocation, fileNameSH);
                // Console.WriteLine(line);
                //wydobycie job id i jobname
                string line2 = string.Format("{0} > /home/users/{1}/.ServerFiles/jobIDtmp.txt; cat /home/users/{1}/.ServerFiles/jobIDtmp.txt | cut -d \" \" -f4 > /home/users/{1}/.ServerFiles/jobID.txt", line, Global.user);
                Global.connectionSession.RunCommand(line2); //uruchomienie sbatch na tmp i zapisanie job id
                                                            //Console.WriteLine(line2);
                                                            //zapisanie job id i job name to remember history of file
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
                       // Console.WriteLine(tempLine[oo]);
                    }
                }

                var isNumericJobID = int.TryParse(outputJobID.Result, out int JobIdCheck);
              //  Console.WriteLine(outputJobID.Result);
                if (!isNumericJobID)
                {
                    MessageBox.Show("No access to the selected partition or diffrent problem " + outputJobID.Result);
                   // Console.WriteLine(outputJobID.Result);
                    Global.connectionSession.RunCommand("rm /home/users/" + Global.user + "/" + Global.directoryTypeLocation + " run_" + labelJobName.Text + ".sh");
                    Global.connectionSession.RunCommand(deleteCheckFile);
                    messageBoxInfo.Close();
                    //jesli wybrano partycje do ktorej nie mamy dostepu usun plik
                }
                else
                {
                    nowTime = DateTime.Now;

                    string historyJobsAddItme = String.Format("echo \"{0};{2};{3};{4};{5}\" >> /home/users/{1}/.ServerFiles/HistoryJobs.txt", outputJobID.Result.Replace("\n", ""), Global.user, labelJobName.Text, Global.directoryTypeLocation, nowTime, label11Description.Text.Replace(";", ":"));

                    Global.connectionSession.RunCommand(historyJobsAddItme);
                    Global.connectionSession.RunCommand(historyJobsMainJob); //dodanie do main Jobs
                    // zapisanie job id i job name to remember history of file END
                    Global.JobIDFromProgramm.Add(JobIdCheck);
                    messageBoxInfo.Close();

                    MessageBox.Show("Job has been added");
                    this.Visible = false;
                    //sacct -u tomaszkuzma --format=JobID,JobName,Submit,State |grep -v '.ba+'
                }
            }
        }

        private void buttonPrevious_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            Global.FormNewJobsADD3.setDataToJob(labelJobName.Text, label11Description.Text, "Blast");
            Global.FormNewJobsADD3.Visible = true;
            Global.FormNewJobsADD3.Focus();
            Global.FormNewJobsADD3.BringToFront();



        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            Global.splitQueryMultiplyJobs = false;
            this.Visible = false;
        }

        private void labelTotalNumberOfJobs_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxEdit_CheckedChanged(object sender, EventArgs e)
        {

        }

        public bool checkFormOne()
        {
            if (textBoxJobName.Text != "")
            {
                return true;
            }
            else
            {
                MessageBox.Show("You must provide a job name");
                return false;
            }
        }

        private int day;
        private int hour;
        private int minute;
        private int second;

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            bool timeIsOK = false;
            if (comboBoxPartition.SelectedIndex > -1) //jesli partycja  nie sa puste
            {
                day = 0;
                hour = 0;
                minute = 0;
                second = 0;
                int number;

                bool result = Int32.TryParse(textBoxTimeLimit.Text, out number);
                if (result) //zostalu wprowadzone same liczby
                {
                    second = 0;
                    minute = 0;
                    hour = number % 24;
                    day = number / 24;
                    timeIsOK = true;

                //    Console.WriteLine("Converted '{0}' to {1}.", textBoxTimeLimit.Text, number);

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
            if (timeIsOK)
            {
                if (textBoxMemory.Text != "" && textBoxTaskPerNode.Text != "")
                {
                    int LimitMemory = checkPartitionToMemeoryLimitBigmem();
                    if (Convert.ToInt32(textBoxTaskPerNode.Text) <= 28 && Convert.ToInt32(textBoxMemory.Text) <= LimitMemory)
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
                                if (checkFormOne())
                                {
                                    //RUN
                                    label11Description.Text = textBoxDescription.Text.Replace(";", "");
                                    labelJobName.Text = textBoxJobName.Text.Replace(" ", "").Replace(";", "");
                                    labelMemory.Text = textBoxMemory.Text;
                                    labelTasksPerNode.Text = textBoxTaskPerNode.Text;
                                    labelTimelimit.Text = textBoxTimeLimit.Text;
                                    labelPartition.Text = comboBoxPartition.SelectedItem.ToString();
                                    MessageBox.Show("Options changed");
                                    buttonRunJob.Enabled = true;
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
                else
                {
                    MessageBox.Show("Task per node and memory can't be empty");
                }
            }
        }


        TimeClass timeByHandClass = new TimeClass();
        TimeClass timeLimitPartitionClass = new TimeClass();
        public void StringToTime(string textBox, TimeClass ClassTime)
        {

            if (textBox.Contains("-") && textBox[1].ToString() == "-" && Regex.Matches(textBox.ToString(), "-").Count == 1) //jesli zawiera - nie moze byc wiecejn niz 1
            {
                ClassTime.day = textBox[0].ToString();
                if (textBox[1].ToString() != "-" && char.IsDigit(textBox[1]) && textBox[2].ToString() == "-") //jesli bedzie wiecej niz 9 dni i 2 znak jestv liczba
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
            else if (Regex.Matches(textBox.ToString(), "-").Count == 0) //nie zawiera -
            {
                string[] separate = (textBox).Split(':');
                if (separate.Length == 2)//jeśli nie ma godzin
                {
                    ClassTime.day = "0";
                    ClassTime.hour = "0";
                    ClassTime.minute = separate[0];
                    ClassTime.second = separate[1];
                }
                else //jelsi sa godziny
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


        //bool firsttime = false;

        private void comboBoxPartition_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in Global.FormNewJobsADD3.bazaPartitionLimitSinfo)
            {
                if (item.PARTITION == comboBoxPartition.SelectedItem.ToString())
                {
                    textBoxTimeLimit.Text = item.TIMELIMIT.ToString().Replace(".", "-");
                    textBoxTimeLimit.ForeColor = Color.Gray;
                   // firsttime = true;
                }
            }
        }

        public TimeSpan CheckTimeLimitPartition()
        {
            foreach (var item in Global.FormNewJobsADD3.bazaPartitionLimitSinfo)
            {
                if (item.PARTITION == comboBoxPartition.SelectedItem.ToString())
                {
                    return item.TIMELIMIT;

                }
            }
            TimeSpan zero = new TimeSpan(0, 0, 0, 0);
            //            MessageBox.Show("WCHODZA ZERA :P:");
            return zero;
        }

        private void textBoxTaskPerNode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBoxMemory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        public void setLinuxRight()
        {

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // buttonResetDatagridView.Visible = true;
                panelBorderStyle.Visible = true;
                this.FormBorderStyle = FormBorderStyle.None;
                labelFormName.Text = "Run Jobs";
                buttonClosewindow.Visible = false;
                //buttonResetDatagridView.Visible = false;
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

        private void buttonX_Click_1(object sender, EventArgs e)
        {
            Global.splitQueryMultiplyJobs = false;
            this.Visible = false;
        }

        // ############################################### CODE NEEDED FOR LINUX RESIZE AND  MOVE FORM ###############################################################
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

        private void buttonClosewindow_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
