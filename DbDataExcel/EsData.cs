using System;
using System.Collections.Generic;
using System.Text;

namespace ES.DB.DbDataExcel
{
    /// <summary>
    /// Класс для хранения переработанных данных, получ. из Excel.
    /// </summary>
    class EsData : IEsData
    {
        public string NoteData { get; set; }
        public string TypeData { get; set; }
        public string[] DTableHeaders { get; set; }
        //public System.Data.DataTable DTable { get; set; }
    }

    /// <summary>
    /// Работа с данными, получ. из Excel.
    /// </summary>
    class EsDataModify : ICreateEsData<EsData>
    {
        // 1) Получаем данные из Excel. 
        //    Достаем нужную таблицу



        // 2) Создаем экз. класса, кот. дальше будем 
        //    сериализовывать или/и загонять в БД.
        public EsData CreateEsData()
        {
            EsData ED = new EsData
            {
                NoteData = "Данные кабелей",
                TypeData = "Используется расчетной моделью",
                DTableHeaders = ["1", "2", "3"]                
            };

            return ED;
        }


    }
}
