using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AJF_Projekt
{
    class NDAS_Przejscie
    {
       public NDAS_Przejscie(String sEtykieta_cel, String sLitera)
        {
            for (int i = 0; i < 10; i++) this.konfiguracja_litera[i] = false;
                this.etykieta_cel = sEtykieta_cel;
                this.konfiguracja_litera[zwroc_numer_litery(sLitera)] = true;
        }
//===============================ATRYBUTY==================================
        
        Boolean[] konfiguracja_litera = new Boolean[10];

        String etykieta_cel = "";
        static String[] konfiguracja_stan = {"a","b","c","d","e","f","g","h","i","j"};
        
//=============================!ATRYBUTY!==================================

//==============================METODY=====================================
        public String getCel()
        { return this.etykieta_cel; }

        public String getLitera()
        {
            for (int i = 0; i < konfiguracja_litera.Length; i++)
            {
                if (konfiguracja_litera[i] == true)
                    return konfiguracja_stan[i];
            }
            return "#####";
        }



        private int zwroc_numer_litery(String s)
        {
            switch (s) 
            {
                case "a": return 0;
                case "b": return 1;
                case "c": return 2;
                case "d": return 3;
                case "e": return 4;
                case "f": return 5;
                case "g": return 6;
                case "h": return 7;
                case "i": return 8;
                case "j": return 9;
                default: return 10;
            }
        }
//===========================!METODY!======================================
    }
}
