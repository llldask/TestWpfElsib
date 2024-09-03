using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TestWpfElsib.Model;

namespace TestWpfElsib.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        private Material selectedMaterial;

        private Material newMaterial;
        public ObservableCollection <Material> Materials { get; set; }


        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Material material = new Material();
                      Materials.Insert(0, material);
                      SelectedMaterial = material;
                  }));
            }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                    (removeCommand = new RelayCommand(obj =>
                    {
                        Material material = obj as Material;
                        if (material != null)
                        {
                            Materials.Remove(material);
                        }
                    },
                    (obj) => Materials.Count > 0));
            }
        }

        public Material SelectedMaterial
        {
            get { return selectedMaterial; }
            set
            {
                selectedMaterial = value;
                OnPropertyChanged("SelectedMaterial");
            }
        }

        public Material NewMaterial
        {
            get { return newMaterial; }
            set
            {
                newMaterial = value;
                OnPropertyChanged("NewMaterial");
            }
        }


        public ViewModel ()
        {
            Materials = new ObservableCollection<Material>()
            {
                new Material{Code="0000",Name="Краска",Price=400.25 }
            };
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


    }
}
