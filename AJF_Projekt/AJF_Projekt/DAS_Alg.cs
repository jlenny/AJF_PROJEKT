using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AJF_Projekt
{
    class DAS_Alg
    {
        public DAS_Alg(NDAS_Stan[] Ndas_stany)
        {
            this.stany_ndas = new NDAS_Stan[Ndas_stany.Length];

            Ndas_stany.CopyTo(stany_ndas, 0);
        }
        NDAS_Stan[] stany_ndas;
        List<String> stany_das = new List<string>();

        public NDAS_Stan[] zwroc_stany_ndas()
        { return stany_ndas; }

        NDAS_Stan zwroc_poczatkowy_ndas(NDAS_Stan[] st_ndas)
        {
            foreach (NDAS_Stan st in st_ndas)
                if (st.getPoczatkowy()) return st;
            return st_ndas[0];
        }

        NDAS_Stan[] zwroc_koncowe_ndas(NDAS_Stan[] st_ndas)
        {
            int i = 0;
            foreach (NDAS_Stan st in st_ndas)
                if (st.getKoncowy()) i++;
            NDAS_Stan[] tmp_ndas = new NDAS_Stan[i];
            i = 0;
            foreach (NDAS_Stan st in st_ndas)
            {
                if (st.getKoncowy())
                {
                    tmp_ndas[i] = st;
                    i++;
                }
            }
            return tmp_ndas;
        }

        public List<String> algorytm(NDAS_Stan[] st_ndas)
        {

            var poczatkowy = zwroc_poczatkowy_ndas(st_ndas);
            var koncowe = zwroc_koncowe_ndas(st_ndas);
            List<String> result = new List<string>();
            result.Add(poczatkowy.getEtykieta());
            for (int i = 0; i < koncowe.Length; i++)
            { result.Add(koncowe[i].getEtykieta()); }
            return result;
        }

        Boolean scout(NDAS_Stan[] st_ndas)
        {

            return true;
        }

        //================================ZBOIR POTEGOWY==================================
        public List<String> zwroc_zbior_potegowy(List<String> sStanyAutomatu)
        {
            List<String> powerset = new List<String>();
            String tmp = "";
            int lng = sStanyAutomatu.Count;
            for (int i = 0; i < (Math.Pow(2, lng)); i++)
            {
                tmp = Convert.ToString(i, 2);
                tmp = dodaj_zera(tmp, lng);
                powerset.Add(zwroc_podzbior(tmp, sStanyAutomatu));
            }
            powerset.Sort();
            return powerset;
        }

        String zwroc_podzbior(String aBinReprezentacja, List<String> bStany)
        {
            String s = "{";
            bool przecinek = true;
            for (int i = 0; i < aBinReprezentacja.Length; i++)
            {
                if ((aBinReprezentacja[i] == '1') && (przecinek)) { s += bStany[i]; przecinek = false; }
                else if ((aBinReprezentacja[i] == '1') && (!przecinek)) { s += "," + bStany[i]; }
            }

            s += "}";
            return s;
        }

        String dodaj_zera(String s, int length)
        {
            String tmp = "";
            if (s.Length < length)
            {
                for (int i = s.Length; i < length; i++)
                {
                    tmp += "0";
                }
                tmp += s;
                return tmp;
            }
            return s;
        }
        //================================ZBOIR POTEGOWY==================================
    }
}
