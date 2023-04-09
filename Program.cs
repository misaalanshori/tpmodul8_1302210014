namespace tpmodul8_1302210014
{
    internal class Program
    {
        static void cekSuhu(AppConfig conf)
        {
            Console.WriteLine("Berapa suhu badan anda saat ini? Dalam nilai " + conf.config.satuan_suhu);
            float suhu;
            try
            {
                suhu = float.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                suhu = 0;
            }
            Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam?");
            int hari;
            try
            {
                hari = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                hari = 0;
            }

            if (conf.config.satuan_suhu.Equals("celcius"))
            {
                if (suhu >= 36.5 && suhu <= 37.5 && hari < conf.config.batas_hari_demam)
                {
                    Console.WriteLine(conf.config.pesan_diterima);
                }
                else
                {
                    Console.WriteLine(conf.config.pesan_ditolak);
                }
            }
            else if (conf.config.satuan_suhu.Equals("fahrenheit"))
            {
                if (suhu >= 97.7 && suhu <= 99.5 && hari < conf.config.batas_hari_demam)
                {
                    Console.WriteLine(conf.config.pesan_diterima);
                }
                else
                {
                    Console.WriteLine(conf.config.pesan_ditolak);
                }
            }
        }
        static void Main(string[] args)
        {
            AppConfig conf = new AppConfig();
            cekSuhu(conf);
            conf.UbahSatuan();
            cekSuhu(conf);
        }
    }
}