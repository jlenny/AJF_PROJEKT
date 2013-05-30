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
        DAS das;
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
                label1.Text = "Ścieżka: " + openFileDialog1.FileName;
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
            stany.Sort();
            return stany;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            utworz_stany(wyszukaj_stany_NDAS(Q));
            listBox2.Items.Clear();
            das = new DAS(stany);
            
            foreach (String s in das.zwroc_zbior_potegowy(wyszukaj_stany_NDAS(Q)))
                listBox2.Items.Add(s);
            
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

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            foreach (NDAS_Stan st in das.algorytm(stany))
            {
                listBox2.Items.Add(st.getEtykieta());
            }
        }
    }
}
