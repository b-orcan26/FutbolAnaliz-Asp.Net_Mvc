using FutbolAnalizWeb.Entity;
using FutbolAnalizWeb.Models;
using FutbolAnalizWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FutbolAnalizWeb.Controllers
{
    public class AnasayfaController : Controller
    {

        FutbolDb veritabani = new FutbolDb();

        [HttpGet]
        public ActionResult Index(int lig_id=1)
        {
            List<PuanDurumu> liste = new List<PuanDurumu>();
            PuanDurumuHesapla(lig_id, liste);
            Lig mLig = veritabani.Lig.Where(x => x.lig_id == lig_id).FirstOrDefault();
            ViewBag.lig = mLig;
            return View(liste);
        }
    
        public ActionResult LigDetay(int lig_id=1)
        {
           
            LigDetay mLigDetay = new LigDetay(lig_id);
            return View(mLigDetay);
        }

        public PartialViewResult TakimDetay(int takim_id = 1)
        {
            TakimDetay tDetay = new TakimDetay(takim_id);            
            

            return PartialView(tDetay);
        }




        // Veritabanı işlemleri

         public void PuanDurumuHesapla(int lig_id,List<PuanDurumu> liste)
        {
            List<PuanDurumu> listeTmp = new List<PuanDurumu>();
            foreach (var tk in veritabani.Takim.Where(x => x.lig_id == lig_id).Select(x => x))
            {
                int takim_id = tk.takim_id;
                int macSayisi = (from mac in veritabani.Mac where mac.evTk_id == tk.takim_id || mac.depTk_id == tk.takim_id select mac).ToList().Count();
                int galibiyetSayisi = (from mac in veritabani.Mac where mac.evTk_id == tk.takim_id && mac.evms_Sk > mac.depms_Sk select mac).ToList().Count();
                galibiyetSayisi += (from mac in veritabani.Mac where mac.depTk_id == tk.takim_id && mac.evms_Sk < mac.depms_Sk select mac).ToList().Count();
                int beraberlikSayisi = (from mac in veritabani.Mac where mac.evTk_id == tk.takim_id && mac.evms_Sk == mac.depms_Sk select mac).ToList().Count();
                beraberlikSayisi += (from mac in veritabani.Mac where mac.depTk_id == tk.takim_id && mac.evms_Sk == mac.depms_Sk select mac).ToList().Count();
                int maglubiyetSayisi = (from mac in veritabani.Mac where mac.evTk_id == tk.takim_id && mac.evms_Sk < mac.depms_Sk select mac).ToList().Count();
                maglubiyetSayisi += (from mac in veritabani.Mac where mac.depTk_id == tk.takim_id && mac.evms_Sk > mac.depms_Sk select mac).ToList().Count();
                int attigiGol = (from mac in veritabani.Mac where mac.evTk_id == tk.takim_id select mac).Sum(s => s.evms_Sk);
                attigiGol += (from mac in veritabani.Mac where mac.depTk_id == tk.takim_id select mac).Sum(s => s.depms_Sk);
                int yedigiGol = (from mac in veritabani.Mac where mac.evTk_id == tk.takim_id select mac).Sum(s => s.depms_Sk);
                yedigiGol += (from mac in veritabani.Mac where mac.depTk_id == tk.takim_id select mac).Sum(s => s.evms_Sk);
                int averaj = attigiGol - yedigiGol;
                int puan = (galibiyetSayisi * 3) + (beraberlikSayisi);
                PuanDurumu puanDurumuSatir = new PuanDurumu();
                puanDurumuSatir.takim_id = takim_id;
                puanDurumuSatir.takim_ad = tk.takim_ad;
                puanDurumuSatir.Galibiyet = galibiyetSayisi;
                puanDurumuSatir.Beraberlik = beraberlikSayisi;
                puanDurumuSatir.Maglubiyet = maglubiyetSayisi;
                puanDurumuSatir.Attigi = attigiGol;
                puanDurumuSatir.Yedigi = yedigiGol;
                puanDurumuSatir.Averaj = averaj;
                puanDurumuSatir.Puan = puan;
                puanDurumuSatir.Oynadigi = macSayisi;
                listeTmp.Add(puanDurumuSatir);
            }
            listeTmp = listeTmp.OrderByDescending(item => item.Puan).ToList();
            foreach (var item in listeTmp)
            {
                liste.Add(item);
            }
            
        }

       



    }

}