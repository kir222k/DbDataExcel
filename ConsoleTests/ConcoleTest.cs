using System;
using ES.DB.DbDataExcel;
using FileSystems;

namespace ConsoleTests
{
    class ConcoleTest
    {
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

            FileDialog FD = new FileDialog();
            string filePath = FD.GetFullPathFile();
            Console.WriteLine(filePath);


        }
}
}
