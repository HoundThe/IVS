using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUICalculator.ViewModel
{
    public class RootVM : ViewModelBase
    {
        private int _itemsControlHeight;

        public RootVM()
        {
        }

        public int ItemsControlHeight
        {
            get => _itemsControlHeight;
            set
            {
                _itemsControlHeight = value;
                OnPropertyChanged(nameof(ItemsControlHeight));
            }
        }

    }
}
