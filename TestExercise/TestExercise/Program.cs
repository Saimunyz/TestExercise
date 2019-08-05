using System;
using System.IO;
using System.Net;
using System.Xml.Serialization;



//Задание:
//Разработать консольное приложение которое выполняет функции: 
//1.	Запрашивает у пользователя название города 
//2.	Запрашивает информацию о погоде с сайта https://openweathermap.org/current 
//3.	Выводит в консоль значение температуры, влажности, заката, восхода в понятной для человека форме
//4.	Сохраняет в текстовый файл полученные значения с текущей датой в названии файла


namespace TestExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            const string api = "&appid=0d60d2ec0d69fa7fa47d14634e67e751";
            const string celsus = "&units=metric";
            const string format = "&mode=xml";
            Console.WriteLine("Для того чтобы данная программа смогла сохранить файл, запустите данное приложение от имени администратора\n");
            Console.WriteLine("Введите название города: ");
            string cityName = Console.ReadLine();
            string url = "http://api.openweathermap.org/data/2.5/weather?q=" + 
                cityName + format + celsus + api;
            try
            {
                //Послание и получение ответа
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();


                //Десериализация ответа
                XmlSerializer formatter = new XmlSerializer(typeof(Current));
                Current weather = (Current)formatter.Deserialize((response.GetResponseStream()));
                //Вывод значения в консоль
                string result = $"\nТемпература в {weather.city.Name}: {weather.temperature.Value}°С, " +
                    $"влажность {weather.humidity.Value}%\nЗаход солнца в {weather.city.Sun.Set.AddHours(3).ToString("HH:mm")}\nВосход солнца в {weather.city.Sun.Rise.AddHours(3).ToString("HH:mm")} ";
                Console.WriteLine(result);
                //Запись в файл
                WriteToFile writer = new WriteToFile(weather.Lastupdate.Value);
                writer.write(result);
                Console.WriteLine("\nФайл с данной информацией сохранен по пути С:\\сегодняшняя_дата.txt");
            }
            catch(Exception e)
            {
                Console.WriteLine("\nОшибка: " + e.Message);
            }
            Console.ReadKey();
        }
    }
}
