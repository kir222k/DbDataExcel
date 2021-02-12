using System;
using ES.DB.DbDataExcel;

namespace ConsoleTests
{
    class ConcoleTest
    {
        static void Main(string[] args)
        {
            EsDataModify EsMod = new EsDataModify();
            var EsDt = EsMod.CreateEsData();

            Console.WriteLine($"EsDt.NoteData= {EsDt.NoteData}" +
                $"EsDt.TypeData= { EsDt.TypeData}"+
                $"EsDt.DTableHeaders= {EsDt.DTableHeaders}");

        }
    }
}
