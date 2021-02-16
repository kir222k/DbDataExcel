using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.IO;
using ES.DB.DbDataExcel;
using FileSystems;

namespace ConsoleTests
{
    /// <summary>
    /// Консоль для работы с миграцией данных из *.xlsx
    /// </summary>
    class Concole
    {
        //const string Text
        const string TextHelp ="Для получения справки -h";
        const string TextHelpFileOpen   = "-fp           открыть диалог выбора файла";
        //const string TextHelpPull       = "-pull         просмотр данных листа";
        const string TextHelpExit       = "-exit         завершение работы";

        const string TextErrNeedValideFile = "Выберите файл Excel!";
        //const string TextNoteFile = "--------------------------\nВ наличие следующие листы:\n--------------------------";
        //const string TextNoteTable = "Данные листа:";
        const string TextWelcome = "Ввод команды> ";

        static void Main()
        {
            /*
            // Экз. класса по работе с данными Excel.
            EsDataModify EsMod = new EsDataModify();
            // Создадим объект EsData.
            var EsDt = EsMod.CreateEsData();

            // Проверим, что получилось.
            Console.WriteLine($"EsDt.NoteData= {EsDt.NoteData}\n" +
                $"EsDt.TypeData= { EsDt.TypeData}\n"+
                $"EsDt.DTableHeaders= {EsDt.DTableHeaders}\n");
            /* -- list from console --
            EsDt.NoteData= Note
            EsDt.TypeData= TypeData
            EsDt.DTableHeaders= System.String[]
            */

            // FileDialog FD = new FileDialog();
            //string filePath = FileDialog.GetFullPathFile();
            //Console.WriteLine(filePath);

            ConsoleRun();

        }

        static void ConsoleRun()
        {
            string textHelp = $"\n{TextHelpFileOpen}\n{TextHelpExit}\n";

            ConsoleColorText(textHelp, ConsoleColor.Red);
            Console.WriteLine($"{TextHelp}\n");
            //Console.Write(TextWelcome);

            // DataSet,
            DataSet Ds;
            // экз. класса по работе с *.xlsx
            var DbData = new DbDataExcel();
            ////  имена листов
            List<string> listNames =new List<string>();
            // Формат строки
            List<int> listLenStr = new List<int>();

            while (true)
            {
                ConsoleWelcome(TextWelcome);
                var input = Console.ReadLine();

                switch (input)
                {
                    case "-h":
                        ConsoleColorText(textHelp, ConsoleColor.Red);
                        break;

                    case "-fp":
                        string filePath = FileDialog.GetFullPathFile();

                        if (new FileInfo(filePath).Extension.Contains("xls"))
                        {



                            //Console.WriteLine($"\nВыбран файл:  {filePath}");
                            Console.Write("\nВыбран файл:");
                            ConsoleColorText(filePath,ConsoleColor.Green); //Console.WriteLine("\n");
                            Console.WriteLine();
                            // получим DataSet
                            Ds = DbData.GetDataFromExcel(filePath);
                            //
                            listNames.Clear();

                            //Console.WriteLine(TextNoteFile);
                            // получим имена листов
                            foreach (DataTable Dt in Ds.Tables)
                            {
                                listNames.Add(Dt.TableName);
                                // выведем имена листов 
                                
                                //Console.WriteLine(Dt.TableName);
                                //Console.WriteLine("{0,-40} {1,-20} {2,-20}", Dt.TableName, $"Строк: {Dt.Rows.Count}", $"Записей: {Dt.Columns.Count}"); // "{0,-15}"
                            }

                            // список длин имен листов для форматирования по самому длинному
                            listLenStr.Clear();
                            foreach (string item in listNames)
                            {
                                //Console.WriteLine(item.Max());
                                listLenStr.Add(item.Length);
                            }
                            Console.Write("Количество листов: "); // {listNames.Count}\n");
                            ConsoleColorText(listNames.Count.ToString(), ConsoleColor.Green); Console.WriteLine("\n");
                            // Форматирование - первое слово (название листа) по наиболее длинному слову
                            string formatStrTabName = "{0, -" + (listLenStr.Max() + 2).ToString() + " }";
                            string formatStr = "{0,-20} {1,-20}";
                            
                            // выведем имена листов с форматированием
                            foreach (DataTable Dt in Ds.Tables)
                            {
                                // Console.WriteLine(formatStr, Dt.TableName, $"Строк: {Dt.Rows.Count}", $"Записей: {Dt.Columns.Count}"); // "{0,-15}"
                                //Console.Write(formatStrTabName, Dt.TableName);
                                ConsoleColorText(formatStrTabName, Dt.TableName, ConsoleColor.Green);
                                Console.WriteLine(formatStr, $"Строк: {Dt.Rows.Count}", $"Записей: {Dt.Columns.Count}");
                            }



                            // Выведем данные листа
                            //Console.WriteLine("\nВведите имя листа <Выделение - LB, копипаст - RB>:");
                            ConsoleWelcome("\nВведите имя листа <Выделение - LB, копипаст - RB>:");

                            var inputNameList = Console.ReadLine();
                            //  - проверить что такой лист есть
                            if (listNames.Contains(inputNameList))
                            {
                                Console.WriteLine("Имеются данные:\n");
                                // и выводим его данные
                                ShowListExcelData(Ds.Tables[inputNameList]);
                            }
                        }
                        else
                        {
                            Console.WriteLine(TextErrNeedValideFile);
                        }
                        //Console.WriteLine(TextWelcome);
                        break;

                    case "-exit":
                         return;

                    default:
                        Console.WriteLine("\nВведите правильную команду");
                        ConsoleColorText(textHelp, ConsoleColor.Red);
                        break;
                }

            }
        }

        static void ShowListExcelData (DataTable Dt)
        {
            //for (int i = 0; i < Dt.Rows.Count; i++)
            //{
            //    string strRec = "";
            //    for (int j = 0; j < Dt.Columns.Count; j++)
            //    {
            //        //strRec += Dt.Rows[i][j].ToString() + "                  ";
            //        Console.Write("{0,-20}", Dt.Rows[i][j].ToString());
            //        //  Console.WriteLine("{0,-20} {1,-20} {2,-20}", dt.TableName,  dt.Rows.Count,  dt.Columns.Count);
            //    }
            //    //Console.WriteLine(strRec);
            //    Console.WriteLine("");
            //    break;
            //}

            
            //foreach (DataColumn column in Dt.Columns)
            //    Console.Write("\t{0}", column.ColumnName);
            
            //Console.WriteLine();

            // перебор всех строк таблицы
            foreach (DataRow row in Dt.Rows)
            {
                // получаем все ячейки строки
                var cells = row.ItemArray;
                foreach (object cell in cells)
                    //Console.Write("\t{0}", cell);
                    Console.Write("{0,-30}", cell);
                Console.WriteLine();
            }

            

        }

        static void ConsoleWelcome(string textWelcome)
        {
            ConsoleColor consColorDef = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(textWelcome);
            Console.ForegroundColor = consColorDef;
        }

        static void ConsoleColorText (string text, ConsoleColor color)
        {
            ConsoleColor consColorDef = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = consColorDef;

        }

        static void ConsoleColorText(string formatText, string text, ConsoleColor color)
        {
            ConsoleColor consColorDef = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(formatText, text);
            Console.ForegroundColor = consColorDef;

        }

    }
}
