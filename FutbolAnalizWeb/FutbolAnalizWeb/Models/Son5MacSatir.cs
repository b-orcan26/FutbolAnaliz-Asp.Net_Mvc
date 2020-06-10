using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FutbolAnalizWeb.Models
{
    public class Son5MacSatir
    {
        private String _evSahibi;
        private String _deplasman;
        public String evSahibi
        {
            get
            {
                if (_evSahibi.Length > 16)
                {
                    string[] evList = _evSahibi.Split(' ');
                    _evSahibi = evList[0];
                    return _evSahibi;
                }
                return _evSahibi;
            }
            set
            {
                _evSahibi = value;
            }
        }
        public String deplasman
        {
            get
            {
                if (_deplasman.Length > 16)
                {
                    string[] depList = _deplasman.Split(' ');
                    _deplasman = depList[0];
                    return _deplasman;
                }
                return _deplasman;
            }
            set
            {
                _deplasman = value;
            }
        }
        public int eviy_sk { get; set; }
        public int depiy_sk { get; set; }
        public int evms_sk { get; set; }
        public int depms_sk { get; set; }
    }
}