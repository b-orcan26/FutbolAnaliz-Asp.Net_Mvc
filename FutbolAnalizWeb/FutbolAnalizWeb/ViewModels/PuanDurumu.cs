using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FutbolAnalizWeb.ViewModels
{
    public class PuanDurumu
    {
        public int takim_id { get; set; }
        public String takim_ad { get; set; }
        public int Oynadigi { get; set; }

        public int Galibiyet { get; set; }

        public int Beraberlik { get; set; }

        public int Maglubiyet { get; set; }

        public int Attigi { get; set; }

        public int Yedigi { get; set; }

        public int Averaj { get; set; }

        public int Puan { get; set; }
    }
}