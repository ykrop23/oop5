using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Documents;
using TimeTable.Annotations;
using TimeTable.Model;

namespace TimeTable.ViewModel
{
    public class AddCoupleViewModel : INotifyPropertyChanged
    {
        private List<Couple> _couples = new List<Couple>();

        public List<Couple> Couples
        {
            get => _couples;
            set
            {
                _couples = value;
                OnPropertyChanged();
            }
        }

        public Couple AddingCouple { get; set; }


        private RelayCommand _addCouple;

        //Database update
        public RelayCommand AddCommand
        {
            get
            {
                return _addCouple = new RelayCommand(obj =>
                {
                    if(AddingCouple.Name != null & AddingCouple.Faculty != null & AddingCouple.GroupNumber != null & AddingCouple.TypeWork != null)
                    { Couples.Add(AddingCouple);
                        
                    }
                    else
                    {
                        MessageBox.Show("Вказані не всі параметри");
                    }
                    
                });
            }
        }

        public AddCoupleViewModel()
        {
            AddingCouple = new Couple();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}