using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FutbolAnalizWeb.Models
{
    public class IcDisPerformansSatir
    {
        private int _oynadigiMacSayisi;
        private int _galibiyetSayisi;
        private int _beraberlikSayisi;
        private int _maglubiyetSayisi;
        private int _attigiGol;
        private int _yedigiGol;

        public int OynadigiMacSayisi
        {
            get
            {
                return _oynadigiMacSayisi;
            }
            set
            {
                _oynadigiMacSayisi = value;
            }
        }
        public int GalibiyetSayisi
        {
            get
            {
                return _galibiyetSayisi;
            }
            set
            {
                _galibiyetSayisi = value;
            }
        }
        public int BeraberlikSayisi
        {
            get
            {
                return _beraberlikSayisi;
            }
            set
            {
                _beraberlikSayisi = value;
            }
        }
        public int MaglubiyetSayisi
        {
            get
            {
                return _maglubiyetSayisi;
            }
            set
            {
                _maglubiyetSayisi = value;
            }
        }
        public int AttigiGol
        {
            get
            {
                return _attigiGol;
            }
            set
            {
                _attigiGol = value;
            }
        }
        public int YedigiGol
        {
            get
            {
                return _yedigiGol;
            }
            set
            {
                _yedigiGol = value;
            }
        }
    }
}