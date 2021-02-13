using System;
using ES.DB.DbDataExcel;

namespace ConsoleTests
{
    class ConcoleTest
    {
        static void Main(string[] args)
        {
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
        }
    }
}
