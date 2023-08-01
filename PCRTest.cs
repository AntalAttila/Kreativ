using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

class Ugyfel{ 
      public Ugyfel(string sor){
          var adatok = sor.Trim().Split(';');
          this.nev      = adatok[0];
          this.elso     = int.Parse(adatok[1].Substring(0,4));
          this.utolso   = int.Parse(adatok[2].Substring(0,4));
          this.tomeg    = int.Parse(adatok[3]);
          this.magassag = int.Parse(adatok[4]);
          this.ev_ho    = adatok[2].Substring(0,7);
      }

      public string nev      { get; set; }
      public int    elso     { get; set; }
      public int    utolso   { get; set; }
      public int    tomeg     { get; set; }
      public double magassag { get; set; }
      public string ev_ho { get; set; }
}

class Program {
  public static void Main (string[] args) {
 // 2.
    var f = new StreamReader("PCRTest.csv", Encoding.Default);
    var lista = new List<Ugyfel>();
    var elsosor = f.ReadLine();

    while (!f.EndOfStream){
        lista.Add(  new Ugyfel(f.ReadLine())  );
    }
    f.Close();

// 3. adatsorok száma
    Console.WriteLine($"3. feladat: {lista.Count} db");

// 4. Akiket idén januárban teszteltek
    Console.WriteLine( $"4. feladat:");

    foreach(var sor in lista){
        if (sor.ev_ho == "2022.01"){
            Console.WriteLine($"        {sor.nev}, {sor.magassag:0.#} cm");
        }
    }
//5.
    Console.WriteLine( $"5. feladat:");
    int ev;
    while(true){
        Console.Write("Kérek egy 2020 és 2022 közötti évszámot!:");
        int.TryParse(Console.ReadLine(), out ev);
        if ((2020 <= ev) & (ev <= 2022)){
            break;
        }
        else{
            Console.Write("Nem megfelelő adat, az értéknek 2020…2022 közé kell esni.");
        }
    }
// 6. a megadott időszakban tesztelt emberek átlagtömege 
    var atlagtomeg = (
        from sor in lista
        where sor.elso <= ev
        where ev <= sor.utolso
        select sor.tomeg
        ).Average();
    Console.WriteLine( $"6. feladat: A 2021. évben oltott páciensek átlag testtömege: {atlagtomeg:0.##} kg");
  }
}
