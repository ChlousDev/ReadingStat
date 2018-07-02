using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingStat.Logic.Model
{
    public class ReadingStatistics
    {
        public int NumberOfBooks { get; set; }

        public int TotalReadingDays { get; set; }

        public int TotalPages { get; set; }

        public double? AvaragePages
        {
            get
            {
                double? averagePages = null;
                if (this.NumberOfBooks > 0)
                {
                    averagePages = Math.Round(this.TotalPages / (double)this.NumberOfBooks, 2, MidpointRounding.AwayFromZero);
                }
                return averagePages;
            }
        }

        public double? AvarageReadingDays
        {
            get
            {
                double? averageReadingDays = null;
                if (this.NumberOfBooks > 0)
                {
                    averageReadingDays = Math.Round(this.TotalReadingDays / (double)this.NumberOfBooks, 2, MidpointRounding.AwayFromZero);
                }
                return averageReadingDays;
            }
        }

        public double? PagesReadPerDay
        {
            get
            {
                double? pagesReadPerDay = null;
                if (this.TotalReadingDays > 0)
                {
                    pagesReadPerDay = Math.Round(this.TotalPages / (double)this.TotalReadingDays, 2, MidpointRounding.AwayFromZero);
                }
                return pagesReadPerDay;
            }
        }
    }
}
