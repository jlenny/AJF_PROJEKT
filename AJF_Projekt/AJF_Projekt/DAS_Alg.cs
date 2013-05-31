using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        DAS_Stan[] tmp_das;
        List<DAS_Stan> stan_das = new List<DAS_Stan>();
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
            List<String> ls = new List<String>();
            ls.Add("1"); ls.Add("2"); ls.Add("3"); ls.Add("4");
 
            stan_das.Add(new DAS_Stan(poczatkowy.getEtykieta(), st_ndas.Length));

            stan_das[0].setPoczatkowy(true);
            stan_das[0].setIstnieje(true);
            stan_das[0] = znajdz_przejscia(stan_das[0]);

            var alfa=zwroc_zbior_potegowy(ls);
            for (int i = 1; i < (2 ^ ls.Count); i++)
            {
                stan_das.Add(new DAS_Stan(alfa[i], st_ndas.Length));
                stan_das[i] = znajdz_przejscia(stan_das[i]);
            }

            result.Add(poczatkowy.getEtykieta());
            for (int i = 0; i < koncowe.Length; i++)
            { result.Add(koncowe[i].getEtykieta()); }

            return result;
        }

        DAS_Stan znajdz_przejscia(DAS_Stan das)
        {
            List<String> str = das.getEtykieta().Split(new Char[] { '{', ',', '}' }).ToList<String>();
            while(str.Remove(""));
            NDAS_Stan[] tmp_ndas = new NDAS_Stan[str.Count];
            int l = 0;
            String x = "";
            foreach (String st in str)
                for (int i = 0; i < stany_ndas.Length; i++)
                    if (st == stany_ndas[i].getEtykieta())
                    {
                        tmp_ndas[l] = stany_ndas[i];
                        x += tmp_ndas[l].getEtykieta() + " | " + tmp_ndas[l].zwroc_ilosc_konfiguracji() + "\n";
                       // MessageBox.Show(generuj_stan_das(tmp_ndas, 0));
                        l++;
                    }
           // MessageBox.Show(x);
            for (int i = 0; i < 10;i++ )
            { das.ustaw_przejscia(tmp_ndas[0].zwroc_konkretne_stany(generuj_stan_das(tmp_ndas, i)),i); }
            return das;
        }

        String generuj_stan_das(NDAS_Stan[] ndas, int iLitera)
        {
            List<String> result = new List<String>();
            String str = "";
            foreach (NDAS_Stan st in ndas)
            {
                foreach (NDAS_Przejscie p in st.zwroc_przejscia_stanu())
                {
                    if (p.getLitera() == p.zwroc_litere(iLitera))
                    {
                        result.Add(p.getCel());
                    }
                }
            }
            
            result.Sort();
            if (result.Count > 0)
            {
                Boolean przecinek = false;
                foreach (String p in result)
                {
                    if (!przecinek)
                    {
                        str += "{" + p;
                        przecinek = true;
                    }
                    else
                    {
                        str += "," + p;
                    }
                }
                str += "}";
            }
            else str = "{0}";
            return str;
        }

        public void setIlosc_stanow_das(int rozmiar)
        { this.tmp_das = new DAS_Stan[rozmiar]; }

        public String zwroc_stan_das(int n)
        { return this.stan_das[n].zwroc_stan(); }

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
            if (przecinek)
                s += "0}";
            else
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
