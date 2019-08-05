using System;
using System.IO;

namespace TestExercise
{ /// <summary>
  /// Запись в файл с текущей датой в названии
  /// </summary>
    class WriteToFile
    {
        DateTime today;
        string filePath;

        public WriteToFile(DateTime today)
        {
            this.today = today;
            filePath= @"C:\" + today.ToString("yyyy_MM_dd") + ".txt";
        }

        public void write(string value)
        {
            using (StreamWriter stream = new StreamWriter(filePath, false, System.Text.Encoding.Default))
            {
                stream.WriteLine(value);
            }
        }
       
    }
}



