using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using FileSystems;
using ExcelDataReader;


namespace ES.DB.DbDataExcel
{
    /// <summary>
    /// Получение даныых из Excel.
    /// </summary>
    /// <remarks>Используется библиотека ExcelDataReader.DataSet: <br/>
    /// <see href="https://github.com/ExcelDataReader/ExcelDataReader"/>
    /// </remarks>

    public class DbDataExcel : IExcelDb<DataSet>
    {

        /// <summary>
        /// Получение данных.
        /// </summary>
        /// <param name="pathExcelFile">Путь к файлу Excel.</param>
        /// <returns>Объект типа DataSet, кот. содержит таблицы <br/>
        /// по числу Листов в файле Excel.</returns>
        public DataSet GetDataFromExcel(string pathExcelFile)

        {
            // загрузим в DataSet данные из файла
            DataSet Ds = GetDataSet(pathExcelFile);

            // Подключить: - перенести в отдельный проект по сериализации

            // * Работа с сериализацией:
            //    Newtonsoft.Json
            //    https://www.newtonsoft.com/json


            //DataSet Ds = null;
            //return Ds;
            return Ds;
        }
        
        /// <summary>
        /// NotImplementedException используется при создании "заглушек" методов.<br/>
        /// Когда метод описан, но не содержит реализации как таковой.
        /// <see href="https://ru.stackoverflow.com/questions/451540/%D0%94%D0%BB%D1%8F-%D1%87%D0%B5%D0%B3%D0%BE-%D0%BD%D1%83%D0%B6%D0%B5%D0%BD-throw-new-notimplementedexception#:~:text=NotImplementedException%20%E2%80%94%20%D0%BC%D0%B5%D1%82%D0%BE%D0%B4%20%D0%BD%D0%B5%20%D1%80%D0%B5%D0%B0%D0%BB%D0%B8%D0%B7%D0%BE%D0%B2%D0%B0%D0%BD%2C%20%D0%BD%D0%BE%20%D0%B1%D1%83%D0%B4%D0%B5%D1%82%20%D1%80%D0%B5%D0%B0%D0%BB%D0%B8%D0%B7%D0%BE%D0%B2%D0%B0%D0%BD%20%D0%B2%20%D0%B1%D1%83%D0%B4%D1%83%D1%89%D0%B5%D0%BC.&text=%D0%98%D1%81%D0%BF%D0%BE%D0%BB%D1%8C%D0%B7%D1%83%D0%B5%D1%82%D1%81%D1%8F%2C%20%D0%B5%D1%81%D0%BB%D0%B8%20%D0%B1%D0%B0%D0%B7%D0%BE%D0%B2%D1%8B%D0%B9%20%D0%BA%D0%BB%D0%B0%D1%81%D1%81%20%D0%B8%D0%BB%D0%B8,%2D%D1%82%D0%BE%20%D0%B2%D0%BE%D0%B7%D0%BC%D0%BE%D0%B6%D0%BD%D0%BE%D1%81%D1%82%D1%8C%20%D0%BD%D0%B5%20%D0%BF%D0%BE%D0%B4%D0%B4%D0%B5%D1%80%D0%B6%D0%B8%D0%B2%D0%B0%D0%B5%D1%82%D1%81%D1%8F)."/>
        /// </summary>
        /// <returns></returns>
        DataSet IExcelDb<DataSet>.GetDataFromExcel()
        {
            throw new NotImplementedException();
        }


        private DataSet GetDataSet(string filePath)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            DataSet result=null;

            if (FileCheck.IsFileNameValid(filePath))
            {
                if ((File.Exists(filePath)) & (CheckAccessFile.CanReadFile(filePath) == true))
                {


                    using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                    {
                        // Auto-detect format, supports:
                        //  - Binary Excel files (2.0-2003 format; *.xls)
                        //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                        using (var reader = ExcelReaderFactory.CreateReader
                                    (stream,
                                        new ExcelReaderConfiguration()
                                        {
                                            FallbackEncoding = Encoding.GetEncoding(1252)

                                        }
                                    )
                               )
                        {
                            // Choose one of either 1 or 2:

                            /*
                            // 1. Use the reader methods
                            do
                            {
                                while (reader.Read())
                                {
                                    // reader.GetDouble(0);
                                }
                            } while (reader.NextResult());*/

                            // 2. Use the AsDataSet extension method
                            result = reader.AsDataSet();

                            // The result of each spreadsheet is in result.Tables
                        }
                    }
                }
                else
                {
                    result = null;
                }
            }

            return result;
        }

    }
}
