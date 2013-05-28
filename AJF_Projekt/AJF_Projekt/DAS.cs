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
            for (int i = 0; i < st_ndas.Length; i++)
            {
                
            }
        }
    }
}
