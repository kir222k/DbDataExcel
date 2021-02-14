using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace ES.DB.DbDataExcel
{
    /// <summary>
    /// Класс для хранения переработанных данных, получ. из Excel.
    /// </summary>
    public class EsData : IEsData
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

}
