using Superheroes.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superheroes.VistasModelo
{
    class MainWindowVM : INotifyPropertyChanged
    {
        private Superheroe heroeActual;
        public Superheroe HeroeActual
        {
            get { return heroeActual; }
            set
            {
                heroeActual = value;
                this.NotifyPropertyChanged("HeroeActual");
            }
        }

        private int posicion;

        public int Posicion
        {
            get { return posicion; }
            set
            {
                posicion = value;
                this.NotifyPropertyChanged("Posicion");
            }
        }

        private int totalHeroes;
        public int TotalHeroes
        {
            get { return totalHeroes; }
            set
            {
                totalHeroes = value;
                this.NotifyPropertyChanged("TotalHeroes");
            }
        }

        private List<Superheroe> lista = Superheroe.GetSamples();

        public MainWindowVM()
        {
            this.Posicion = 1;
            this.HeroeActual = lista[Posicion-1];
            this.TotalHeroes = lista.Count;
        }

        public void Avanzar()
        {
            if(Posicion < TotalHeroes)
            {
                Posicion++;
                HeroeActual = lista[Posicion - 1];
            }
            
        }

        public void Retroceder()
        {
            if(Posicion > 1)
            {
                Posicion--;
                HeroeActual = lista[Posicion - 1];
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
