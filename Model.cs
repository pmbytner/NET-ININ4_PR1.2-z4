using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_ININ4_PR1._2_z4
{
    class Model
    {
        public ObservableCollection<Osoba> ListaOsób { get; } = new ObservableCollection<Osoba>() { 
            new Osoba() {Imię="Jan", Nazwisko="Wiśniewski"},
            new Osoba() {Imię="Wojciech", Nazwisko="Jabłoński"},
        };

        internal Osoba NowaOsoba()
        {
            Osoba nowa = new Osoba();
            ListaOsób.Add(nowa);
            return nowa;
        }
    }
}
