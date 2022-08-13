using System;

namespace WeatherBookConsole
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ReportItemAttribute : Attribute
    {
        private int columnorder;
        public string Heading { get; set; }
        public string Units { get; set; }
        public string Format { get; set; }
        public int ColumnOrder
        {
            get
            {
                return columnorder;
            }
            set
            {
                columnorder = value;
            }
        }

        public ReportItemAttribute(int columnOrder)
        {
            ColumnOrder = columnOrder;
        }
    }
}
