using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;

namespace AJF_Projekt
{
    public partial class Form1 : Form
    {
        String Q = "";
        NDAS_Stan[] stany;
        DAS_Alg das;
        public Form1()
        {
            InitializeComponent();
        }

        private void bOtworz_Click(object sender, EventArgs e)
        {
            otworzPlik();
        }

        private void otworzPlik()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                l_Sciezka_NDAS.Text = "Ścieżka: " + openFileDialog1.FileName;
                StreamReader objReader = new StreamReader(openFileDialog1.FileName);
                string sLine = "";

                ArrayList arrText = new ArrayList();
                while (sLine != null)
                {
                    sLine = objReader.ReadLine();
                    if (sLine != null)
                        arrText.Add(sLine);
                }
                objReader.Close();

                Regex rgx = new Regex("(>|\\*)?\\([1-9][0-9]?,[a-j]\\)->\\d+;$");

                foreach (string sOutput in arrText)
                {
                    Q += sOutput + "\n";
                    if (rgx.IsMatch(sOutput))
                        listBox1.Items.Add(sOutput);
                }
            }
        }

        List<String> wyszukaj_stany_NDAS(String s)
        {
            List<String> stany = new List<string>();
            MatchCollection m = Regex.Matches(s, "\\([1-9][0-9]?,");
            foreach (Match match in m)
            {
                if (match.Length == 3)
                    stany.Add(match.ToString().Substring(1, 1));
                else
                    stany.Add(match.ToString().Substring(1, 2));
            }
            stany = stany.Distinct().ToList();
            stany=odrzuc_stany_nieosiagalne(stany, s);
            stany.Sort();
            return stany;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            utworz_stany(wyszukaj_stany_NDAS(Q));
            listBox2.Items.Clear();
            das = new DAS_Alg(stany);
            das.setIlosc_stanow_das(stany.Length);

            foreach (String s in das.zwroc_zbior_potegowy(wyszukaj_stany_NDAS(Q)))
            {
                listBox2.Items.Add(s);
                
            }

            /*
              foreach (NDAS_Stan st in das.zwroc_stany_ndas())
                 for (int i = 0; i < st.zwroc_ilosc_konfiguracji(); i++)
                     listBox2.Items.Add(st.zwroc_konfiguracje(i));
             */
        }

        void utworz_stany(List<String> s)
        {
            s.Sort();
            stany = new NDAS_Stan[s.Count];
            for (int i = 0; i < s.Count; i++)
                stany[i] = new NDAS_Stan(s[i], Q);

        }

        List<String> odrzuc_stany_nieosiagalne(List<String> str, String sQ)
        {
            List<String> tmp = str;
            for (int i = str.Count - 1; i >= 0;i--)
            {

                MatchCollection m = Regex.Matches(sQ, "(>|\\*)?\\([1-9][0-9]?,[a-j]\\)->[" + str[i] + "];");
                if (m.Count == 0)
                { tmp.RemoveAt(i); }

            }

            return tmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            var pk = das.algorytm(stany);
            l_Stan_poczatkowy_NDAS.Text = "Stan początkowy: {" + pk[0] + "}";
            listBox2.Items.Add("> {" + pk[0] + "}");
            l_Stan_koncowy.Text = "Stan(y) końcowy: ";
            for (int i = 1; i < pk.Count; i++)
            {
                l_Stan_koncowy.Text += "{" + pk[i] + "} ";
                listBox2.Items.Add("* {" + pk[i] + "} ");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            l_Stan_poczatkowy_DAS.Text = "Początkowy: " + das.zwroc_stan_das(0)+"\n";
            for(int i=0;i<stany.Length;i++)
            { listBox3.Items.Add(das.zwroc_stan_das(i)); }
        }
    }
}
