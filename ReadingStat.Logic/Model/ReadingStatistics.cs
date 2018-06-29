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

        public double? PagesReadPerDay
        {
            get
            {
                double? pagesReadPerDay = null;
                if (this.TotalReadingDays > 0)
                {
                    pagesReadPerDay = Math.Round(this.TotalPages / (double)this.TotalReadingDays);
                }
                return pagesReadPerDay;
            }
        }
    }
}
