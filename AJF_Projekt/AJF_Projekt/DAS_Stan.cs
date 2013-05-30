using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AJF_Projekt
{
    class DAS_Stan
    {
        public DAS_Stan(String sEtykieta, int intIlosc_stanow_Ndas)
        {
            this.etykieta = sEtykieta;
            ilosc_stanow_ndas = intIlosc_stanow_Ndas;
            this.cel_przejscia = new NDAS_Stan[10, intIlosc_stanow_Ndas];
        }
        String etykieta = "";
        int ilosc_stanow_ndas = 0;
        NDAS_Stan[,] cel_przejscia;
        Boolean istnieje = false;
        Boolean poczatkowy = false;
        Boolean koncowy = false;

        public NDAS_Stan[,] getCel_przejscia()
        { return this.cel_przejscia; }

        public String getEtykieta()
        { return this.etykieta; }

        public void ustaw_przejscia(NDAS_Stan[] str, int i)
        {
            for (int l = 0; l < ilosc_stanow_ndas-1; l++)
            {
                this.cel_przejscia[i,l] = str[l];
                
            }
        }

        public void ustaw_etykiete(String str)
        { this.etykieta = str; }

        public bool getPoczatkowy()
        { return this.poczatkowy; }

        public bool getKoncowy()
        { return this.koncowy; }

        public bool getIstnieje()
        { return this.istnieje; }

        public void setIstnieje(Boolean Istnieje_bool)
        { this.istnieje = Istnieje_bool; }

        public void setPoczatkowy(Boolean Poczatkowy_bool)
        { this.poczatkowy = Poczatkowy_bool; }

        public void setKoncowy(Boolean Koncowy_bool)
        { this.koncowy = Koncowy_bool; }

        public String zwroc_stan()
        {
            String str;
            if(this.getPoczatkowy())
            str=">["+this.etykieta+"]";
            else if(this.getKoncowy())
                str = "*[" + this.etykieta + "]";
            else str = "[" + this.etykieta + "]";

            for (int i = 0; i < 10;i++ )
            {
                if (sprawdz_czy_null(i))
                {
                    str += " - {";
                    Boolean przecinek = false;
                    for (int l = 0; l < ilosc_stanow_ndas; l++)
                    {
                        if ((this.cel_przejscia[i, l] != null) && !przecinek)
                        {
                            str += this.cel_przejscia[i, l].getEtykieta(); przecinek = true;
                        }
                        else if ((this.cel_przejscia[i, l] != null) && przecinek)
                        { str += "," + this.cel_przejscia[i, l].getEtykieta(); }
                    }
                    str += "} ";
                }
                else { str += " - {0}"; }
            }
            return str;
        }

        Boolean sprawdz_czy_null(int i)
        {
            int b = 0;
            for (int l = 0; l < ilosc_stanow_ndas; l++)
            {
                if (this.cel_przejscia[i, l] == null) b++;
            }
            if (b < this.ilosc_stanow_ndas)
                return true;
            else return false;
        }
    }
}
