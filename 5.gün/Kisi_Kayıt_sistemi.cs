
using System.Text.RegularExpressions;

namespace _5.gün
{
    public class Kisi_Kayıt_sistemi
    {
       
        public Kisi_Kayıt_sistemi()
        {

        }
        public Kisi_Kayıt_sistemi(string ad, string soyad)
        {
            if (ad.Contains("0"))
            {

                throw new Exception("Ad alanında sadece harf bulunmalıdır");
            }

            if (soyad.Contains("0"))
            {
                throw new Exception("Soyad alanında sadece harf bulunmalıdır");
            }

            _ad = ad;
            _soyad = soyad;
        }

        private string _ad;
        private string _soyad;
        private DateTime _dogumTarihi;
        private string _tckn;
        private string _telefon;
        private string _email;



        public void SetAd(string ad)
        {
            foreach (var harf in ad)
            {
                if (char.IsDigit(harf) || char.IsNumber(harf))
                    throw new Exception("Ad alanında sadece harf bulunmalıdır");
            }
            _ad = ad;
        }
        
        public string GetAd()
        {
            return _ad.Substring(0, 1).ToUpper() + _ad.Substring(1).ToLower();// Girilen ismin 0 dan başla ve 1. harfini büyüt ve 1 den başlayarak diğer tüm harflari küçült
        }
        public string Ad 
        {
            get
            {
                return _ad.Substring(0, 1).ToUpper() + _ad.Substring(1).ToLower();
            }
            set
            {
                foreach (var harf in value)
                {
                    if (char.IsDigit(harf) || char.IsNumber(harf)||char.IsSymbol(harf))
                        throw new Exception("Ad alanında sadece harf bulunmalıdır");
                }
                _ad = value;
            }
           
        }
        public string Soyad
        {
            set
            {
                foreach (var harf in value)
                {
                    if (char.IsDigit(harf) || char.IsNumber(harf))
                        throw new Exception("Soyad alanında sadece harf bulunmalıdır");
                }

                _soyad = value;
            }
            get
            {
                string soyad = _soyad.Substring(0, 19);
                return soyad;
            }
        }
        public DateTime DogumTarihi
        {
            get { return _dogumTarihi; }
            set
            {
                TimeSpan fark = DateTime.Now - value;
                double yas = fark.TotalDays / 365;
                if (yas < 18)
                    throw new Exception("18 yaşından küçükleri sisteme kayıt edemezsiniz");

                _dogumTarihi = value;
            }
        }

        public string Telefon 
        {
            get => Telefon;
            set
            {
                if (value.Length == 10)

                    throw new Exception("kure kere 10 rakema bı ke");

                foreach (char harf in value)
                {
                    if (!char.IsDigit(harf))

                        throw new Exception("telefon number should be numbers ");
                }
                _telefon = value;
            }

        }   

        public string Email 
        {
            get => _email;
            set
            {
                string emailRegex = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
                if (!Regex.IsMatch(value, emailRegex, RegexOptions.IgnoreCase))
                    throw new Exception("Doğru bir email girmediniz");
                _email = value;
            }
        }


        public string Tckn
        {
            get { return _tckn; }
            set
            {
                if (value.Length == 11)

                    throw new Exception("kure kere 11 rakema bı ke");

                foreach(char harf in value)
                {
                    if (!char.IsDigit(harf))
                        throw new Exception("Tc should be numbers ");
                }
                    _tckn = value; 
            }
          
        }
        
        public int Yas 
        {
            get
            {
                int yas = DateTime.Now.Year - _dogumTarihi.Year;
                return yas;
            }
        }
       

        public override string ToString()
        {
            return $"{Ad} {Soyad} - {Yas}";
        }
    }


}
