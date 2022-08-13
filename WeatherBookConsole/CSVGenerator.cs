using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WeatherBookConsole
{
    public class CSVGenerator<T>
    {
        private IEnumerable<T> _data;
        private Type _type;
        private DataTable tableBook;
        private DataTable tableWeather;

        public CSVGenerator(IEnumerable<T> data)
        {
            _data = data;
            _type = typeof(T);
        }

        public void Generate()
        {
            tableBook = new DataTable("Book");
            tableWeather = new DataTable("Weather");
            CreateHeader();

            foreach (var item in _data)
                CreateRow(item);

            if (_type == typeof(Book))
            {
                foreach (DataRow row in tableBook.Rows)
                    foreach (DataColumn column in tableBook.Columns)
                        if (row[column] != null)
                            Console.WriteLine(row[column]);
            }
            else if (_type == typeof(Weather))
            {
                foreach (DataRow row in tableWeather.Rows)
                    foreach (DataColumn column in tableWeather.Columns)
                        if (row[column] != null)
                            Console.WriteLine(row[column]);
            }

            
        }
        
        private void CreateHeader()
        {
            var properties = _type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var orderedProps = properties.OrderBy(p => p.GetCustomAttribute<ReportItemAttribute>().ColumnOrder);

            
            if (_type == typeof(Book))
            {
                foreach (var prop in orderedProps)
                {
                    var attr = prop.GetCustomAttribute<ReportItemAttribute>();
                    string column = attr.Heading ?? prop.Name;
                    tableBook.Columns.Add(column, typeof(string));
                }
                tableBook.AcceptChanges();
            }

            if (_type == typeof(Weather))
            {
                foreach (var prop in orderedProps)
                {
                    var attr = prop.GetCustomAttribute<ReportItemAttribute>();
                    string column = attr.Heading ?? prop.Name;
                    tableWeather.Columns.Add(column, typeof(string));
                }
                tableWeather.AcceptChanges();
            }            
        }
        
        private void CreateRow(T item)
        {
            var properties = _type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var orderedProps = properties.OrderBy(p => p.GetCustomAttribute<ReportItemAttribute>().ColumnOrder);


            if (_type == typeof(Book))
            {
                int i = 0;
                foreach (var prop in orderedProps)
                {
                    DataRow row = tableBook.NewRow();
                    row[i] = CreateItem(prop, item);
                    tableBook.Rows.Add(row);
                    i++;
                }
                tableBook.AcceptChanges();
            }

            if (_type == typeof(Weather))
            {
                int i = 0;
                foreach (var prop in orderedProps)
                {
                    DataRow row = tableWeather.NewRow();
                    row[i] = CreateItem(prop, item);
                    tableWeather.Rows.Add(row);
                    i++;
                }
                tableWeather.AcceptChanges();
            }


        }

        private string CreateItem(PropertyInfo prop, T item)
        {
            var attr = prop.GetCustomAttribute<ReportItemAttribute>();

            return string.Format($"{{0:{attr.Format}}}{attr.Units}", prop.GetValue(item));            
        }
    }

}
