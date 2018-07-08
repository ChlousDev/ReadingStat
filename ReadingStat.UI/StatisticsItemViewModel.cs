using ReadingStat.Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingStat.UI
{
    public class StatisticsItemViewModel
    {
        public string Title { get; private set; }

        public ReadingStatistics ReadingStatistics { get; private set; }

        public StatisticsItemViewModel(string title, ReadingStatistics readingStatistics)
        {
            this.Title = title;
            this.ReadingStatistics = readingStatistics;
        }
    }
}
