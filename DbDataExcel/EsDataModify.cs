using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace ES.DB.DbDataExcel
{

    /// <summary>
    /// Работа данными. Получение данных - класс DbDataExcel. Класс-данные - EsData.
    /// </summary>
    public class EsDataModify : ICreateEsData<EsData>
    {
        // 1) Получаем данные из Excel. 
        //    Достаем нужную таблицу, передаем ее как параметр метода CreateEsData


        ///<summary>
        /// Создаем и возвращаем экз. класса, кот. дальше будем 
        /// сериализовывать или/и загонять в БД.
        ///</summary> 
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

        ///<inheritdoc/>
        public EsData CreateEsData(DataTable Dt, string noteData, string typeData)
        {
            EsData ED = new EsData()
            {
                NoteData = noteData,
                TypeData = typeData,
                DTableHeaders = new string[2] { "1", "2" }
            };

            Dt = null;
            return ED;
        }

        public string[] CreateHeadersTable()
        {
            return null;
        }



    }
}
