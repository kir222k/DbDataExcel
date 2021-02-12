﻿
using System.Collections.Generic;
using System.Text;

namespace ES.DB.DbDataExcel
{

    /// <summary>
    /// Реализация данного интерфейса - в классе, кот. выполняет получение данных из файла Excel.
    /// <see href="https://metanit.com/sharp/tutorial/3.9.php"/>
    /// </summary>
    interface IExcelDb
    {
        System.Data.DataSet GetDataFromExcel();
        System.IO.Path PathExcelFile { get; set; }

    }

    /// <summary>
    /// Реализация в классе, кот. позволяет выаодить разную информацию об Excel файле.
    /// </summary>
    interface IExcelDbView
    {
        void ShowExcelDataTablesInfo();
    }

    /// <summary>
    /// Реализация данного интерфейса - класс для записи в БД или/и json.
    /// </summary>
    interface IEsData
    {
        string NoteData { get; set; }
        string TypeData { get; set; }
       // System.Data.DataTable DTable { get; set; }
        string [] DTableHeaders { get; set; }

    }

    /// <summary>
    /// Реализация данного интерфейса - в классе,  метод кот. создает экз. класса:IEsData  на основе данных, полученных через класс:IExcelDb.
    /// </summary>
    /// <remarks>Используется обобщенный тип.<br/>
    /// <see href="https://metanit.com/sharp/tutorial/3.12.php"/>
    /// </remarks>
    interface ICreateEsData<T>
    {
        T CreateEsData();
    }






}
