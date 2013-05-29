using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AJF_Projekt
{
    class DAS
    {
        public DAS(NDAS_Stan[] Ndas_stany)
        {
            this.stany_ndas=new NDAS_Stan[Ndas_stany.Length];
            Ndas_stany.CopyTo(stany_ndas, 0);
        }
        NDAS_Stan[] stany_ndas;
        List<String> stany_das = new List<string>();

        public NDAS_Stan[] zwroc_stany_ndas()
        { return stany_ndas; }

        NDAS_Stan zwroc_poczatkowy_ndas(NDAS_Stan[] st_ndas)
        {
            foreach(NDAS_Stan st in st_ndas)
                if(st.getPoczatkowy()) return st;
            return st_ndas[0];
        }

        void algorytm(NDAS_Stan[] st_ndas)
        {
            var poczatkowy = zwroc_poczatkowy_ndas(st_ndas);
            

        }

//================================ZBOIR POTEGOWY==================================
        public List<String> zwroc_zbior_potegowy(List<String> sStanyAutomatu)
        {
            List<String> powerset = new List<String>();
            String tmp="";
            int lng = sStanyAutomatu.Count;
            for (int i = 0; i < (Math.Pow(2,lng)); i++)
            {
                tmp = Convert.ToString(i, 2);
                tmp = dodaj_zera(tmp, lng);
                        powerset.Add(zwroc_podzbior(tmp, sStanyAutomatu));
            }
            powerset.Sort();
            return powerset;
        }

        String zwroc_podzbior(String a, List<String> b)
        {
            String s = "{";
            bool przecinek = true;
            for (int i = 0; i <a.Length; i++)
            {
                if ((a[i] == '1') && (przecinek)) { s += b[i]; przecinek = false; }
            else if ((a[i] == '1') && (!przecinek)) { s += ","+b[i]; }
            }

            s += "}";
            return s;
        }
        String dodaj_zera(String s, int length)
        {
            String tmp="";
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
