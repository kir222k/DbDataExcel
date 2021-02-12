using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

namespace ES.DB.DbDataExcel
{
   public class DbDataExcel : IExcelDb<DataSet>
    {
        public DataSet GetDataFromExcel(string PathExcelFile)

        {
            //DataSet Ds = null;
            //return Ds;
            return null;
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

        
    }
}
