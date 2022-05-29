using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NET_ININ4_PR1._2_z4
{
    class Osoba : INotifyPropertyChanged
    {
        static private readonly Dictionary<string, string[]> powiązaneWłaściwości
            = new Dictionary<string, string[]>()
            {
                ["Imię"] = new string[] { "ImięNazwisko"/*, "Format"*/},
                ["Nazwisko"] = new string[] { "ImięNazwisko"/*, "Format"*/},
                ["DataUrodzenia"] = new string[] { "Wiek"/*, "Format"*/},
                ["DataŚmierci"] = new string[] { "Wiek"/*, "Format"*/},
                ["ImięNazwisko"] = new string[] { "Format" },
                ["Wiek"] = new string[] { "Format" }
            };
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(
            [CallerMemberName] string właściwość = null,
            HashSet<string> załatwioneWłaściwości = null
            )
        {
            if (załatwioneWłaściwości == null)
                załatwioneWłaściwości = new HashSet<string>();

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(właściwość));
            załatwioneWłaściwości.Add(właściwość);
            if(powiązaneWłaściwości.ContainsKey(właściwość))
                foreach (string powiązanaWłaściwość in powiązaneWłaściwości[właściwość])
                    if (!załatwioneWłaściwości.Contains(powiązanaWłaściwość))
                        OnPropertyChanged(powiązanaWłaściwość, załatwioneWłaściwości);
        }

        string
            imię,
            nazwisko
            ;
        DateTime?
            dataUrodzenia,
            dataŚmierci
            ;

        public string Imię {
            get => imię;
            set
            {
                imię = value;
                OnPropertyChanged();
            }
        }
        public string Nazwisko {
            get => nazwisko;
            set
            {
                nazwisko = value;
                OnPropertyChanged();
            }
        }
        public DateTime? DataUrodzenia {
            get => dataUrodzenia;
            set
            {
                dataUrodzenia = value;
                OnPropertyChanged();
            }
        }
        public DateTime? DataŚmierci {
            get => dataŚmierci;
            set
            {
                dataŚmierci = value;
                OnPropertyChanged();
            }
        }
        public string ImięNazwisko
        {
            get => $"{Imię} {Nazwisko}";
        }
        public string Wiek
        {
            get
            {
                if (dataUrodzenia == null)
                    return "BD";

                DateTime koniec;
                if (dataŚmierci == null)
                    koniec = DateTime.Now;
                else
                    koniec = (DateTime)dataŚmierci;

                TimeSpan czasŻycia = koniec - (DateTime)dataUrodzenia;
                return Math.Ceiling(czasŻycia.Days / 365.25).ToString();
            }
        }
        public override string ToString()
        {
            return $"{ImięNazwisko}, {Wiek} lat";
        }
        public string Format
        {
            get => $"{ImięNazwisko}, {Wiek} lat";
        }
    }
}
