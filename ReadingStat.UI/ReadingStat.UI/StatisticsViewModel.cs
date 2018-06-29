using ReadingStat.Logic.DataAccess;
using ReadingStat.Logic.Logic;
using ReadingStat.Logic.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingStat.UI
{
    public class StatisticsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<StatisticsItemViewModel> statistics;
        public ObservableCollection<StatisticsItemViewModel> Statistics
        {
            get
            {
                return this.statistics;
            }
        }

        public StatisticsViewModel()
        {
            this.statistics = new ObservableCollection<StatisticsItemViewModel>();
            this.Load();
        }

        private void Load()
        {
            this.Statistics.Clear();
            ReadingStatDataAccess dataAccess = new ReadingStatDataAccess();

            ReadingAnalizer readingAnalizer = new ReadingAnalizer(dataAccess);
            this.Statistics.Add(new StatisticsItemViewModel("Alle Bücher", readingAnalizer.Analize()));

            LanguageReadingAnalizer germanReadingAnalizer = new LanguageReadingAnalizer(dataAccess, ELanguage.German);
            this.Statistics.Add(new StatisticsItemViewModel("Deutsche Bücher", germanReadingAnalizer.Analize()));

            LanguageReadingAnalizer englishReadingAnalizer = new LanguageReadingAnalizer(dataAccess, ELanguage.English);
            this.Statistics.Add(new StatisticsItemViewModel("Englische Bücher", englishReadingAnalizer.Analize()));
        }

        #region Property Changed

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion Property Changed
    }
}
