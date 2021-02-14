using System;
using System.IO;

namespace FileSystems
{

    public static class FileCheck
    {

    /// <summary>
    /// Проверка строки-пути к файлу.
    /// <see href="https://ru.stackoverflow.com/questions/630154/%D0%9F%D1%80%D0%BE%D0%B2%D0%B5%D1%80%D0%BA%D0%B0-%D1%8F%D0%B2%D0%BB%D1%8F%D0%B5%D1%82%D1%81%D1%8F-%D0%BB%D0%B8-%D0%B8%D1%81%D1%85%D0%BE%D0%B4%D0%BD%D0%B0%D1%8F-%D1%81%D1%82%D1%80%D0%BE%D0%BA%D0%B0-%D0%BF%D1%83%D1%82%D1%91%D0%BC-%D0%BA-%D1%84%D0%B0%D0%B9%D0%BB%D1%83"/>
    /// </summary>
        public static bool IsFileNameValid(string fileName)
        {
            //
            if (fileName == null) return false;

            // путь к файлу  сод. нед. символы - возращаем FALSE
            // IndexOfAny см. тут:
            // https://docs.microsoft.com/en-us/dotnet/api/system.string.indexofany?f1url=%3FappId%3DDev16IDEF1%26l%3DEN-US%26k%3Dk(System.String.IndexOfAny);k(DevLang-csharp)%26rd%3Dtrue&view=net-5.0
            //
            if  (fileName.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return false;

            try
            {
                // если удается создать FileInfo при таком пути к файлу
                var tempFileInfo = new FileInfo(fileName);
                // тогда  возращаем TRUE, т.е. и имя файла тоже правильное.
                return true; 

            }
            catch (NotSupportedException)
            {
                // при любой ошибке - FALSE.
                return false;
            }

            #region ПРОВЕРКА РАБОТЫ МЕТОДА.
            /*
            string path1 = "c:\\ds|df2\\text.txt"; // ошибка в пути к файлу
            string path2 = "c:\\dsdf2\\te|<xt.txt"; // ошибка в имени файла
            string path3 = "c:\\dsdf2\\text.txt"; // нет ошибок

            Console.WriteLine($"\nПроверим путь {path1}");
            Console.WriteLine(FilePathCheck.isFileNameValid(path1));

            Console.WriteLine($"\nПроверим путь {path2}");
            Console.WriteLine(FilePathCheck.isFileNameValid(path2));

            Console.WriteLine($"\nПроверим путь {path3}");
            Console.WriteLine(FilePathCheck.isFileNameValid(path3));
            */
            #endregion
        }
    }
}
