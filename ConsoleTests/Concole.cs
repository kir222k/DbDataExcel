using System;
using System.Collections.Generic;
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
        const string TextNoteFile = "Список листов:";
        const string TextNoteTable = "Данные листа:";

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

            Console.WriteLine(textHelp);
            Console.WriteLine($"{TextHelp}\n");

            // DataSet
            DataSet Ds;
            // экз. класса по работе с *.xlsx
            var DbData = new DbDataExcel();
            ////  имена листов
            List<string> listNames =new List<string>();

            while (true)
            {
                var input = Console.ReadLine();

                switch (input)
                {
                    case "-h":
                        Console.WriteLine(textHelp);
                        break;

                    case "-fp":
                        string filePath = FileDialog.GetFullPathFile();

                        if (new FileInfo(filePath).Extension.Contains("xls"))
                        {



                            Console.WriteLine($"\nВыбран файл:  {filePath}");
                            Console.WriteLine("В наличие следующие листы:");
                            // получим DataSet
                            Ds = DbData.GetDataFromExcel(filePath);
                            //
                            listNames.Clear();
                            // получим имена листов
                            foreach (DataTable Dt in Ds.Tables)
                            {
                                listNames.Add(Dt.TableName);
                                // выведем имена листов 
                                Console.WriteLine($"[{Dt.TableName}]");
                            }

                            // Выведем данные листа
                            Console.WriteLine("\nВведите имя  листа:");
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
                            Console.WriteLine("\nНеверное расширение, выберите файл Excel!");
                        }
                        break;

                    case "-exit":
                         return;

                    default:
                        Console.WriteLine("\nВведите правильную команду");
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
                    Console.Write("{0,-15}", cell);
                Console.WriteLine();
            }

            

        }


    }
}
