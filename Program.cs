using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите математическое выражение");
        string ifade = Console.ReadLine(); 
        double sonuc = Hesapla(ifade); 
        Console.WriteLine("Заключение: " + sonuc);
    }

    static double Hesapla(string ifade)
    {
        string[] parcalar = ifade.Split(' '); 
        double[] sayilar = new double[parcalar.Length / 2 + 1]; 
        char[] islemler = new char[parcalar.Length / 2]; 

        int sIndex = 0, iIndex = 0;

        
        for (int i = 0; i < parcalar.Length; i++)

        {
            if (i % 2 == 0)

                sayilar[sIndex++] = Convert.ToDouble(parcalar[i]);

            else

                islemler[iIndex++] = parcalar[i][0];
        }

        
        for (int i = 0; i < islemler.Length; i++)

        {
            if (islemler[i] == '*' || islemler[i] == '/')

            {
                if (islemler[i] == '*')

                    sayilar[i] *= sayilar[i + 1];

                else

                    sayilar[i] = sayilar[i + 1] == 0 ? 0 : sayilar[i] / sayilar[i + 1];

                
                for (int j = i + 1; j < sayilar.Length - 1; j++)

                    sayilar[j] = sayilar[j + 1];

                for (int j = i; j < islemler.Length - 1; j++)
                
                    islemler[j] = islemler[j + 1];

                i--; 
            }
        }

        
        double sonuc = sayilar[0];
        int index = 0;

        while (index < islemler.Length)
        {
            if (islemler[index] == '+')
                sonuc += sayilar[index + 1];
            else
                sonuc -= sayilar[index + 1];

            index++;
        }

        return sonuc;
    }
}