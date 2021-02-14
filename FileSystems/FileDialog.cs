using System;
using System.Collections.Generic;
using System.Text;
using Ookii.Dialogs.Wpf;


namespace FileSystems
{
    public static class FileDialog
    {
        //
        /// <summary>
        /// <see href="https://csharp.hotexamples.com/ru/examples/-/Ookii.Dialogs.Wpf.VistaOpenFileDialog/-/php-ookii.dialogs.wpf.vistaopenfiledialog-class-examples.html"/>
        /// </summary>
        /// <returns></returns>
        public static string GetFullPathFile()
        {
            var dlg = new Ookii.Dialogs.Wpf.VistaOpenFileDialog();
            var result = dlg.ShowDialog();

            try
            {
                if (result == true)
                {
                    string fileName = dlg.FileName;

                    if (FileCheck.IsFileNameValid(fileName))
                        return dlg.FileName;
                    else
                        return null;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw; 
            }

        }
    }
}
