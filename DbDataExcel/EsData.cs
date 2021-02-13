using System;
using System.Collections.Generic;
using System.Text;

namespace ES.DB.DbDataExcel
{
    /// <summary>
    /// Класс для хранения переработанных данных, получ. из Excel.
    /// </summary>
    public  class EsData : IEsData
    {
        public string NoteData { get; set; }
        public string TypeData { get; set; }
        /// <summary>
        /// Массив строковый. <see href="https://metanit.com/sharp/tutorial/2.4.php"/>
        /// </summary>
        public string[] DTableHeaders { get; set; }
        //public System.Data.DataTable DTable { get; set; }

       
        public EsData(string noteData, string typeData, string[] dTableHeaders)
        {
            NoteData = noteData;
            TypeData = typeData;
            DTableHeaders = dTableHeaders;
        }
        public EsData() { }   

    }

    /// <summary>
    /// Работа с данными, получ. из Excel.
    /// </summary>
    public class EsDataModify : ICreateEsData<EsData>
    {
        // 1) Получаем данные из Excel. 
        //    Достаем нужную таблицу, передаем ее как параметр метода CreateEsData



        // 2) Создаем и возвращаем экз. класса, кот. дальше будем 
        //    сериализовывать или/и загонять в БД.
        public EsData CreateEsData()
        {
            // 1) Запросить название Листа Excel(из консоли)
            // 2) Запросить Note
            // 3) Сообщить, что заголовки столбцов будут взяты из 1:1 (1 строка в Листе Excel)


            // Для теста из консоли
            EsData ED = new EsData()
            {
                NoteData = "Note", // задать как параметр метода
                TypeData = "TypeData", // задать как параметр метода
                DTableHeaders = new string[2] { "1", "2" } // задается при разборе таблицы
            };
            return ED;
        }


    }
}
