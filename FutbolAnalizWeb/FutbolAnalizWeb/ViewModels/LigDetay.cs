using FutbolAnalizWeb.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FutbolAnalizWeb.ViewModels
{
    public class LigDetay
    {
        FutbolDb veritabani = new FutbolDb();
        public int AtilanGolSayisi { get; set; }
        public double MacBasinaGol { get; set; }

        public Takim EnCokGolAtanTakim { get; set; }

        public Takim EnAzGolYiyenTakim { get; set; }

        public Takim IcSahaBasariliTakim { get; set; }

        public Takim DisSahaBasariliTakim { get; set; }

        public int ToplamGol { get; set; }

        public double OrtalamaGol { get; set; }

        public LigDetay(int lig_id)
        {
            init(lig_id);
        }

        public void init(int lig_id)
        {
            enGolcuTakimBul(lig_id);
            enAzYiyenTakimBul(lig_id);
            icSahaEnBasariliTakimBul(lig_id);
            disSahaEnBasariliTakimBul(lig_id);
            toplamGolBul(lig_id);
            ortalamaGolHesapla(lig_id,ToplamGol);
        }

        public void enGolcuTakimBul(int lig_id)
        {
            List<Takim> takimList = veritabani.Takim.Where(x => x.lig_id == lig_id).Select(x => x).ToList();
            int gol = 0;
            Takim engolcuTakim = null;

            for (int i = 0; i < takimList.Count; i++)
            {
                Takim tk = takimList[i];
                int evGol = veritabani.Mac.Where(z => z.evTk_id == tk.takim_id).Sum(z => z.evms_Sk);
                int depGol = veritabani.Mac.Where(x => x.depTk_id == tk.takim_id).Sum(x => x.depms_Sk);
                int toplamGol = evGol + depGol;
                if (gol < toplamGol)
                {
                    gol = toplamGol;
                    engolcuTakim = takimList[i];
                }
            }

            EnCokGolAtanTakim = engolcuTakim;
        }

        public void enAzYiyenTakimBul(int lig_id)
        {
            List<Takim> takimList = veritabani.Takim.Where(x => x.lig_id == lig_id).Select(x => x).ToList();
            int gol = 1000;
            Takim enAzYiyen = null;

            for (int i = 0; i < takimList.Count; i++)
            {
                Takim tk = takimList[i];
                int evdeYedigiGol = veritabani.Mac.Where(x => x.evTk_id == tk.takim_id).Sum(x => x.depms_Sk);
                int depYedigiGol = veritabani.Mac.Where(x => x.depTk_id == tk.takim_id).Sum(x => x.evms_Sk);
                int yedigiToplamGol = evdeYedigiGol + depYedigiGol;
                if (yedigiToplamGol < gol)
                {
                    gol = yedigiToplamGol;
                    enAzYiyen = takimList[i];
                }
            }
            EnAzGolYiyenTakim = enAzYiyen;
        }

        public void icSahaEnBasariliTakimBul(int lig_id)
        {
            int puan = 0;
            Takim icEnBasTakim = null;
            List<Takim> takimList = veritabani.Takim.Where(x => x.lig_id == lig_id).Select(x => x).ToList();

            for (int i = 0; i < takimList.Count; i++)
            {
                int toplamPuan = 0;
                Takim tk = takimList[i];
                List<Mac> macList = veritabani.Mac.Where(x => x.evTk_id == tk.takim_id).Select(x => x).ToList();
                for (int j = 0; j < macList.Count; j++)
                {
                    if (macList[j].evms_Sk > macList[j].depms_Sk)
                    {
                        toplamPuan += 3;
                    }
                    else if (macList[j].evms_Sk == macList[j].depms_Sk)
                    {
                        toplamPuan += 1;
                    }
                }

                if (toplamPuan > puan)
                {
                    puan = toplamPuan;
                    icEnBasTakim = takimList[i];
                }
            }

            IcSahaBasariliTakim = icEnBasTakim;
        }

        public void disSahaEnBasariliTakimBul(int lig_id)
        {
            int puan = 0;
            Takim disEnBasTakim = null;
            List<Takim> takimList = veritabani.Takim.Where(x => x.lig_id == lig_id).Select(x => x).ToList();

            for (int i = 0; i < takimList.Count; i++)
            {
                int toplamPuan = 0;
                Takim tk = takimList[i];
                List<Mac> macList = veritabani.Mac.Where(x => x.evTk_id == tk.takim_id).Select(x => x).ToList();
                for (int j = 0; j < macList.Count; j++)
                {
                    if (macList[j].evms_Sk < macList[j].depms_Sk)
                    {
                        toplamPuan += 3;
                    }
                    else if (macList[j].evms_Sk == macList[j].depms_Sk)
                    {
                        toplamPuan += 1;
                    }
                }

                if (toplamPuan > puan)
                {
                    puan = toplamPuan;
                    disEnBasTakim = takimList[i];
                }
            }

            DisSahaBasariliTakim = disEnBasTakim;
        }

        public void toplamGolBul(int lig_id)
        {
            int toplam = 0;
            List<Takim> takimList = veritabani.Takim.Where(x => x.lig_id == lig_id).Select(x => x).ToList();


            for (int i = 0; i < takimList.Count; i++)
            {
                Takim tk = takimList[i];
                List<Mac> evdekimacList = (from mac in veritabani.Mac where mac.evTk_id == tk.takim_id select mac).ToList();
                List<Mac> depmacList = (from mac in veritabani.Mac where mac.depTk_id == tk.takim_id select mac).ToList();
                int evGol = evdekimacList.Sum(x => x.evms_Sk);
                int depGol = depmacList.Sum(x => x.depms_Sk);
                int attigiGol = evGol + depGol;
                toplam += attigiGol;
            }
            ToplamGol = toplam;
        }

        public void ortalamaGolHesapla(int lig_id, int toplamGol)
        {
            List<Takim> takimList = veritabani.Takim.Where(x => x.lig_id == lig_id).Select(x => x).ToList();
            int macSayisi = 0;
            for (int i = 0; i < takimList.Count; i++)
            {
                Takim tk = takimList[i];
                macSayisi += (from mac in veritabani.Mac where mac.evTk_id == tk.takim_id || mac.depTk_id == tk.takim_id select mac).ToList().Count();
            }

            double _ortalamaGol = Convert.ToDouble(toplamGol) / Convert.ToDouble(macSayisi);
            _ortalamaGol = Math.Round(_ortalamaGol, 2);
            OrtalamaGol = _ortalamaGol;
        }





    }
}