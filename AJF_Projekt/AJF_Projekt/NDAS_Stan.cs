using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

namespace AJF_Projekt
{
    class NDAS_Stan
    {
        public NDAS_Stan(String sEtykieta, String sAutomat)
        {
            this.etykieta = sEtykieta;
            ustaw_przejscia(zwroc_przejscia_stanu(sEtykieta, sAutomat));
            
        }
        String etykieta = "";   
        Boolean poczatkowy = false;
        Boolean koncowy = false;  
        List<NDAS_Przejscie> konfiguracja = new List<NDAS_Przejscie>();
    
       public bool dodaj_konfiguracje(String sEtykieta_cel, String sLitera)
       {
           this.konfiguracja.Add(new NDAS_Przejscie(sEtykieta_cel,sLitera));          
           return true;
       }

       public string zwroc_konfiguracje(int i)
       {
           string str = "";
           if (this.getPoczatkowy())
               str += "> ( ";
           else if (this.getKoncowy())
               str += "* ( ";
           else
               str += "( ";
           str += this.etykieta+" , ";
           str += this.konfiguracja[i].getLitera()+" ) -> ";
           str += this.konfiguracja[i].getCel()+" ;";
           return str;
       }

       public int zwroc_ilosc_konfiguracji()
       { return this.konfiguracja.Count; }

       public String getEtykieta()
       { return this.etykieta; }

       public bool getPoczatkowy()
       { return this.poczatkowy; }

       public bool getKoncowy()
       { return this.koncowy; }

       public void setPoczatkowy(Boolean Poczatkowy_bool)
       { this.poczatkowy = Poczatkowy_bool; }

       public void setKoncowy(Boolean Koncowy_bool)
       { this.koncowy = Koncowy_bool; }

       MatchCollection zwroc_przejscia_stanu(String sEtykietaStanu, String a)
       {
           MatchCollection m = Regex.Matches(a, "(>|\\*)?\\("+sEtykietaStanu+",[a-j]\\)->\\d+;");
           if (m[0].Value[0] == '>') this.poczatkowy = true;
           else if (m[0].Value[0] == '*') this.koncowy = true;
           return m;
       }

       void ustaw_przejscia(MatchCollection m)
       {
           
           foreach (Match match in m)
           {
               String[] str = Regex.Split(match.ToString(), "\\(|,|\\)|[->]|;");
               char pk = match.ToString()[0];
               switch (pk)
               {
                   case '*': dodaj_konfiguracje(str[5], str[2]);
                       break;
                   case '>': dodaj_konfiguracje(str[6], str[3]); 
                       break;
                   default: dodaj_konfiguracje(str[5], str[2]);
                       break;
               }
           }
       }
    }
}