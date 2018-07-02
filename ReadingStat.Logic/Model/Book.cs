using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingStat.Logic.Model
{
    public class Book
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string LanguageString { get; set; }

        public ELanguage Language
        {
            get
            {
                return (ELanguage)Enum.Parse(typeof(ELanguage), this.LanguageString);
            }
            set
            {
                this.LanguageString = value.ToString();
            }
        }

        public string TypeString { get; set; }

        public EType Type
        {
            get
            {
                return (EType)Enum.Parse(typeof(EType), this.TypeString);
            }
            set
            {
                this.TypeString = value.ToString();
            }
        }

        public int NumberOfPages { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int? ReadingDays
        {
            get
            {
                int? readingDays = null;
                if ((this.StartDate != DateTime.MinValue) && (this.EndDate != DateTime.MinValue) && (this.EndDate > this.StartDate))
                {
                    readingDays = (int)Math.Ceiling((this.EndDate - this.StartDate).TotalDays);
                }
                return readingDays;
            }
        }

        public double? PagesReadPerDay
        {
            get
            {
                double? pagesReadPerDay = null;
                if (this.ReadingDays.HasValue)
                {
                    pagesReadPerDay = Math.Round(this.NumberOfPages / (double)this.ReadingDays.Value, 2, MidpointRounding.AwayFromZero);
                }
                return pagesReadPerDay;
            }
        }

    }
}
