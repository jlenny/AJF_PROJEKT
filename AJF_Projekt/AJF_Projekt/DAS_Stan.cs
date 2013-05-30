using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AJF_Projekt
{
    class DAS_Stan
    {
        String etykieta = "";
        String[] cel_przejscia = new String[10];
        Boolean poczatkowy = false;
        Boolean koncowy = false;

        public String[] zwroc_tablice_przejsc()
        { return this.cel_przejscia; }

        public String zwroc_etykiete()
        { return this.etykieta; }

        public bool getPoczatkowy()
        { return this.poczatkowy; }

        public bool getKoncowy()
        { return this.koncowy; }

        public void setPoczatkowy(Boolean Poczatkowy_bool)
        { this.poczatkowy = Poczatkowy_bool; }

        public void setKoncowy(Boolean Koncowy_bool)
        { this.koncowy = Koncowy_bool; }
    }
}
