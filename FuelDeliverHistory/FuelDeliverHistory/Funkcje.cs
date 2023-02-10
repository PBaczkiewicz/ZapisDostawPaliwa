using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuelDeliverHistory
{
    internal static class Funkcje
    {

        //aktualizuje listę w programie w oparciu o List<dostawy> od najnowszego do najstarszego
        static public void AktualizacjaListy(List<Dostawy> listaDostaw, ref CheckedListBox checkedListBox1)
        {
            string napis;
            checkedListBox1.Items.Clear();
            listaDostaw = listaDostaw.OrderBy(DateTime => DateTime.data).ToList();
            for (int i = listaDostaw.Count; i > 0; i--)
            {
                napis = listaDostaw[i - 1].data.ToString();
                napis = napis.Substring(0, napis.Length - 3);
                napis += "  |  " + listaDostaw[i - 1].iloscPaliwa.ToString();
                napis += "  |  " + listaDostaw[i - 1].nettoLitr.ToString();
                napis += "  |  " + listaDostaw[i - 1].bruttoLitr.ToString();
                napis += "  |  ";
                if (listaDostaw[i - 1].cenaNetto < 10000)
                {
                    napis += "  ";
                }
                napis += listaDostaw[i - 1].cenaNetto.ToString();
                napis += "  |  ";
                if (listaDostaw[i - 1].cenaNetto < 10000)
                {
                    napis += "  ";
                }
                napis += listaDostaw[i - 1].cenaBrutto.ToString();
                napis += "  ||  " + listaDostaw[i - 1].dostawca;
                napis += "  ||  " + listaDostaw[i - 1].uwagi;
                checkedListBox1.Items.Add(napis);
            }
            ZapisDanych(listaDostaw);
        }

        //zapisuje listę do JSON'a
        static public void ZapisDanych(List<Dostawy> listaDostaw)
        {
            string jsonString = JsonConvert.SerializeObject(listaDostaw);
            System.IO.File.WriteAllText("data.json", jsonString);
        }

        //wczytuje dane z JSON'a
        static public void OdczytDanych(ref List<Dostawy> listaDostaw)
        {

            string jsonString = System.IO.File.ReadAllText("data.json");
            listaDostaw = JsonConvert.DeserializeObject<List<Dostawy>>(jsonString);

        }

    }

}
