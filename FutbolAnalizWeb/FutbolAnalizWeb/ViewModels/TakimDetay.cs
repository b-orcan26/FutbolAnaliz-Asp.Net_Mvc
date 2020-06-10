using FutbolAnalizWeb.Entity;
using FutbolAnalizWeb.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace FutbolAnalizWeb.ViewModels
{
    public class TakimDetay
    {

        private IcDisPerformansSatir _icSahaPerformansi;
        private IcDisPerformansSatir _disSahaPerformansi;
        private List<Son5MacSatir> _son5MacListesi;
        private Takim _myTakim;
        private FutbolDb veritabani = new FutbolDb();
        private List<DataPoint> _attigiSeries;
        private List<DataPoint> _maclarindakiToplamGol;
        private List<DataPoint> _maclarindakiAttigiIyGol;
        private List<DataPoint> _maclarindakiYedigiIyGol;
        private List<DataPoint> _yedigiSeries;
        private List<DataPoint> _ucBucuk;
        private List<DataPoint> _ikiBucuk;
        private List<DataPoint> _birBucuk;



        // ALT UST SAYILARI ATAMA
        public String UcBucuk
        {
            get
            {
                return JsonConvert.SerializeObject(_ucBucuk);
            }
            set
            {
                
            }
        }
        public String IkiBucuk
        {
            get
            {
                return JsonConvert.SerializeObject(_ikiBucuk);
            }
            set
            {
                
            }
        }
        public String BirBucuk
        {
            get
            {
                return JsonConvert.SerializeObject(_birBucuk);
            }
            set
            {

            }
        }


        public List<Son5MacSatir> Son5MacListesi {
            get
            {
                return _son5MacListesi;
            }
            set
            {
                _son5MacListesi = value;
            }
        }
        public IcDisPerformansSatir IcSahaPerformansi {
            get
            {
                return _icSahaPerformansi;
            }
            set
            {
                _icSahaPerformansi = value;
            }
        }
        public IcDisPerformansSatir DisSahaPerformansi {
            get
            {
                return _disSahaPerformansi;
            }
            set
            {
                _disSahaPerformansi = value;
            }
        }

        //
        public String AttigiSeries {
            get
            {
                return JsonConvert.SerializeObject(_attigiSeries);
            }
            set
            {
               
            }
        }
        public String YedigiSeries {
            get
            {
                return JsonConvert.SerializeObject(_yedigiSeries);
            }
            set
            {
                
            }
        }

        public String MaclarindakiToplamGol {
            get
            {
                return JsonConvert.SerializeObject(_maclarindakiToplamGol);
            }
            set
            {
                
            }
        }

        public String MaclarindakiAttigiIyGol {
            get
            {
                return JsonConvert.SerializeObject(_maclarindakiAttigiIyGol);
            }
            set
            {

            }
        }

        public String MaclarindakiYedigiIyGol {
            get
            {
                return JsonConvert.SerializeObject(_maclarindakiYedigiIyGol);
            }
            set
            {
                
            }
        }
        //
        public Takim MyTakim {
            get
            {
                return _myTakim;
            }
            set
            {
                _myTakim = value;
            }
        }

        // CONSTRUCTOR
        public TakimDetay(int takim_id)
        {
            init(takim_id);
        }


        private void init(int takim_id)
        {

            TakimAta(takim_id);

            _attigiSeries = new List<DataPoint>();
            _yedigiSeries = new List<DataPoint>();
            _birBucuk = new List<DataPoint>();
            _ikiBucuk = new List<DataPoint>();
            _ucBucuk = new List<DataPoint>();
            _maclarindakiAttigiIyGol = new List<DataPoint>();
            _maclarindakiYedigiIyGol = new List<DataPoint>();
            _icSahaPerformansi = new IcDisPerformansSatir();
            _disSahaPerformansi = new IcDisPerformansSatir();
            _maclarindakiToplamGol = new List<DataPoint>();
            _maclarindakiAttigiIyGol = new List<DataPoint>();


            _son5MacListesi = new List<Son5MacSatir>();

            Son5MacListesi = Son5MacListesiGetir(takim_id, Son5MacListesi);

            AttigiYedigiGolAta(takim_id);


            IcSahaPerformansiAta(takim_id);
            DisSahaPerformansiAta(takim_id);

            MaclarindakiToplamGolAta(takim_id);

            AttigiYedigiGolAtaIy(takim_id);
            UstAta15();
            UstAta25();
            UstAta35();

        }

        private void UstAta15()
        {
            int ustSayisi = 0;
            for (int i = 0; i < _maclarindakiToplamGol.Count; i++)
            {
                if (_maclarindakiToplamGol[i].Y > 1)
                {
                    ustSayisi += 1;
                }
            }
            int altSayisi = 0;
            for (int i = 0; i < _maclarindakiToplamGol.Count; i++)
            {
                if (_maclarindakiToplamGol[i].Y <= 1)
                {
                    altSayisi += 1;
                }
            }
            _birBucuk.Add(new DataPoint("UstSayisi", ustSayisi));
            _birBucuk.Add(new DataPoint("AltSayisi", altSayisi));
        }

        private void UstAta25()
        {
            int ustSayisi = 0;
            for (int i = 0; i < _maclarindakiToplamGol.Count; i++)
            {
                if (_maclarindakiToplamGol[i].Y > 2)
                {
                    ustSayisi += 1;
                }
            }
            int altSayisi = 0;
            for (int i = 0; i < _maclarindakiToplamGol.Count; i++)
            {
                if (_maclarindakiToplamGol[i].Y <= 2)
                {
                    altSayisi += 1;
                }
            }
            _ikiBucuk.Add(new DataPoint("UstSayisi", ustSayisi));
            _ikiBucuk.Add(new DataPoint("AltSayisi", altSayisi));
        }

        private void UstAta35()
        {
            int ustSayisi = 0;
            for (int i = 0; i < _maclarindakiToplamGol.Count; i++)
            {
                if (_maclarindakiToplamGol[i].Y > 3)
                {
                    ustSayisi += 1;
                }
            }
            int altSayisi = 0;
            for (int i = 0; i < _maclarindakiToplamGol.Count; i++)
            {
                if (_maclarindakiToplamGol[i].Y <= 3)
                {
                    altSayisi += 1;
                }
            }
            _ucBucuk.Add(new DataPoint("UstSayisi", ustSayisi));
            _ucBucuk.Add(new DataPoint("AltSayisi", altSayisi));
        }

        private void AttigiYedigiGolAtaIy(int takim_id)
        {
            Takim tk = (Takim)veritabani.Takim.Where(x => x.takim_id == takim_id).Select(x => x).FirstOrDefault();

            List<Mac> maclist = veritabani.Mac.Where(x => x.evTk_id == takim_id || x.depTk_id == takim_id).Select(x => x).OrderBy(x => x.mac_tarih).ToList();

            for (int i = 0; i < maclist.Count; i++)
            {
                int attigiGol = 0;
                int yedigiGol = 0;

                if (maclist[i].evTk_id == takim_id)
                {
                    attigiGol = maclist[i].eviy_Sk;
                    yedigiGol = maclist[i].depiy_Sk;
                }
                else if (maclist[i].depTk_id == takim_id)
                {
                    attigiGol = maclist[i].depiy_Sk;
                    yedigiGol = maclist[i].eviy_Sk;
                }
                _maclarindakiAttigiIyGol.Add(new DataPoint(i.ToString(), attigiGol));
                _maclarindakiYedigiIyGol.Add(new DataPoint(i.ToString(), yedigiGol));
            }
        }

        private void MaclarindakiToplamGolAta(int takim_id)
        {
            List<Mac> macList = veritabani.Mac.Where(x => x.evTk_id == takim_id || x.depTk_id == takim_id).Select(x => x).ToList();
            for (int i = 0; i < macList.Count; i++)
            {
                int toplamGol = macList[i].evms_Sk + macList[i].depms_Sk;
                _maclarindakiToplamGol.Add(new DataPoint(i.ToString(), toplamGol));
            }
        }

        private void AttigiYedigiGolAta(int takim_id)
        {
            Takim tk = (Takim)veritabani.Takim.Where(x => x.takim_id == takim_id).Select(x => x).FirstOrDefault();

            List<Mac> maclist = veritabani.Mac.Where(x => x.evTk_id == takim_id || x.depTk_id == takim_id).Select(x => x).OrderBy(x => x.mac_tarih).ToList();

            for (int i = 0; i < maclist.Count; i++)
            {
                int attigiGol = 0;
                int yedigiGol = 0;

                if (maclist[i].evTk_id == takim_id)
                {
                    attigiGol = maclist[i].evms_Sk;
                    yedigiGol = maclist[i].depms_Sk;
                }
                else if (maclist[i].depTk_id == takim_id)
                {
                    attigiGol = maclist[i].depms_Sk;
                    yedigiGol = maclist[i].evms_Sk;
                }
                _attigiSeries.Add(new DataPoint(i.ToString(), attigiGol));
                _yedigiSeries.Add(new DataPoint(i.ToString(), yedigiGol));
            }
        }

        private void TakimAta(int takim_id)
        {
            MyTakim = (Takim)veritabani.Takim.Where(x => x.takim_id == takim_id).Select(x => x).FirstOrDefault();
        }

        private List<Son5MacSatir> Son5MacListesiGetir(int takim_id, List<Son5MacSatir> liste)
        {
            List<Mac> maclistesi = new List<Mac>();
            maclistesi = (from mac in veritabani.Mac where mac.evTk_id == takim_id || mac.depTk_id == takim_id select mac).OrderByDescending(x => x.mac_tarih).Take(5).ToList();
            for (int i = 0; i < maclistesi.Count; i++)
            {
                Son5MacSatir satir = new Son5MacSatir();
                int takim_id1 = maclistesi[i].evTk_id;
                int takim_id2 = maclistesi[i].depTk_id;
                int eviy_sk = maclistesi[i].eviy_Sk;
                int depiy_sk = maclistesi[i].depiy_Sk;
                int evms_sk = maclistesi[i].evms_Sk;
                int depms_sk = maclistesi[i].depms_Sk;
                string takim_adi1 = (from tk in veritabani.Takim where tk.takim_id == takim_id1 select tk.takim_ad).First();
                string takim_adi2 = (from tk in veritabani.Takim where tk.takim_id == takim_id2 select tk.takim_ad).First();

                satir.evSahibi = takim_adi1;
                satir.deplasman = takim_adi2;
                satir.eviy_sk = eviy_sk;
                satir.depiy_sk = depiy_sk;
                satir.evms_sk = evms_sk;
                satir.depms_sk = depms_sk;
                liste.Add(satir);
            }
            return liste;
        }

        private void IcSahaPerformansiAta(int takim_id)
        {
            int galibiyetSayisi = 0;
            int beraberlikSayisi = 0;
            int maglubiyetSayisi = 0;
            int attigiGolSayisi = 0;
            int yedigiGolSayisi = 0;

            List<Mac> maclar = veritabani.Mac.Where(x => x.evTk_id == takim_id).Select(x => x).ToList();

            int oynadigiMacSayisi = maclar.Count();

            for (int i = 0; i < maclar.Count; i++)
            {

                if (maclar[i].evms_Sk > maclar[i].depms_Sk)
                {
                    galibiyetSayisi += 1;
                }
                else if (maclar[i].evms_Sk < maclar[i].depms_Sk)
                {
                    maglubiyetSayisi += 1;
                }
                else
                {
                    beraberlikSayisi += 1;
                }
                attigiGolSayisi += maclar[i].evms_Sk;
                yedigiGolSayisi += maclar[i].depms_Sk;
            }
            IcDisPerformansSatir satir = new IcDisPerformansSatir();
            satir.AttigiGol = attigiGolSayisi;
            satir.YedigiGol = yedigiGolSayisi;
            satir.OynadigiMacSayisi = oynadigiMacSayisi;
            satir.BeraberlikSayisi = beraberlikSayisi;
            satir.MaglubiyetSayisi = maglubiyetSayisi;
            satir.GalibiyetSayisi = galibiyetSayisi;
            IcSahaPerformansi = satir;
        }

        private void DisSahaPerformansiAta(int takim_id)
        {
            int galibiyetSayisi = 0;
            int beraberlikSayisi = 0;
            int maglubiyetSayisi = 0;
            int attigiGolSayisi = 0;
            int yedigiGolSayisi = 0;

            List<Mac> maclar = veritabani.Mac.Where(x => x.depTk_id == takim_id).Select(x => x).ToList();

            int oynadigiMacSayisi = maclar.Count();

            for (int i = 0; i < maclar.Count; i++)
            {

                if (maclar[i].evms_Sk < maclar[i].depms_Sk)
                {
                    galibiyetSayisi += 1;
                }
                else if (maclar[i].evms_Sk > maclar[i].depms_Sk)
                {
                    maglubiyetSayisi += 1;
                }
                else
                {
                    beraberlikSayisi += 1;
                }
                attigiGolSayisi += maclar[i].depms_Sk;
                yedigiGolSayisi += maclar[i].evms_Sk;
            }
            IcDisPerformansSatir satir = new IcDisPerformansSatir();
            satir.AttigiGol = attigiGolSayisi;
            satir.YedigiGol = yedigiGolSayisi;
            satir.OynadigiMacSayisi = oynadigiMacSayisi;
            satir.BeraberlikSayisi = beraberlikSayisi;
            satir.MaglubiyetSayisi = maglubiyetSayisi;
            satir.GalibiyetSayisi = galibiyetSayisi;
            DisSahaPerformansi = satir;
        }

        }
}