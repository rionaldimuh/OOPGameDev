using System;

namespace gamedev1
{
    //Guide cara baca : setelah comment ada angka kayak (0), (0.5), (1), dll
    //Tiap comment yang berhubungan punya nomor yang sama
    //Itu juga Urutan bacanya biar lebih paham, dimulai dari (0)

    class Program                                                           //Ini kelas utama (0)
    {
        static void Main(string[] args)                                     //Untuk yang di dalem ini baca yang dibawah dulu baru ke sini
        {
            //Bikin objek biasa                                             //Bukan bawah ini, tapi bawah lagi diluar ini di class Test tepatnya
            Test baru = new Test();                                         //Bikin objek dengan 'NamaKelas' 'NamaObjek' = new 'NamaKelas()" (0)
            baru.warnaApa();                                                //Bisa manggil method yang ada di kelas (0)
            baru.bentuk = "Lingkaran";                                      //Kasih field bentuk variabel lingkaran (0.5)

            //Bikin objek banyak
            Test subaru = new Test();
            baru.bentuk = "Segitiga";                                       //repot kan kalo harus dikasih value bentuknya pake line baru terus (0.5)
            Test sobaru = new Test();                                       //kalo field yang harus dikasih valuenya banyak, linenya juga bisa banyak banget (0.5)
            baru.bentuk = "Belah ketupat";                                  //Solusinya biar cuma 1 line yaitu pake constructor yang bisa diliat di nomor selanjutnya

            Console.WriteLine();
            //Bikin Objek dengan konstruktor (1)
            Contoh karakter = new Contoh("Budi", "Jalan 123");              //Kalo pake constructor tadi jadi cuma 1 baris buat kasih valuenya (1)
            Console.WriteLine("Nama: "+karakter.nama +"\t Alamat: "+ karakter.getAlamat());
            karakter.metodTes();

            Console.WriteLine();
            //Tanpa Konstruktor (cara lebih repot karena ngulang ngulang) kayak yang nomor 0.5 (2)
            Contoh karakter2 = new Contoh();                                //Ga perlu kasih parameter kalo kita mau ngeset sendiri satu satu (2)
            karakter2.nama = "Andi";
            //karakter2.alamat = "Jalan 321";                               //error karena protection level private (3)
            karakter2.setAlamat("Jalan 321");                               //pake properties tadi biar bisa dimodif (3)
            Console.WriteLine("Nama: "+ karakter2.nama+"\t Alamat "+karakter2.getAlamat());
            karakter2.metodTes();

            Console.WriteLine();
            Slime s = new Slime();                                          //Contoh buat inheritance (5)
            s.Ngomong();                                                    //Di class slime tidak punya method Ngomong, adanya di Enemy (5)
                                                                            //Jadi inheritance class child bisa pake method class parent    (5)
        }
    }

    //Untuk nomor (0) dan (0.5)
    class Test{                                     //Contoh kelas  bikin pake class 'namaKelas' (0)
        string warna = "Merah";                     //Field(variabel) biasa (0)
        public string bentuk;                       //field kosong (0.5) (baca yang 0 dulu baru 0.5)
        public void warnaApa(){                     //Method/function biasa (0) selesai baca ini balik lagi ke atas yang nomor 0 buat implementasinya
            Console.WriteLine("Warna : "+warna);
        }                          
    }

    //Untuk nomor (1),(2),(3)
    class Contoh{                                   
        public string nama;                         
        private string alamat;                      //protection level/akses modifier private (3)
                                                    //Protection level ada Public & Private yang umum       (3)
                                                    //Public artinya method/field tersebut bisa dipake di kelas lain    (3)
                                                    //Private hanya kelasnya sendiri (dalem kasus ini cuma untuk kelas "Contoh") (3)

        //Constructor
        public Contoh(string nama, string alamat){  //Namanya konstruktor       (1)
            this.nama = nama;                       //This.nama itu merujuk ke public string nama, "nama" itu merujuk ke parameter method (1)
            this.alamat = alamat;                   //Jadi nama dari kelas ini bakalan berubah jadi inputan parameter (1)
        }
        public Contoh(){                            //Konstruktor juga bisa kosong, jadi konstruktornya nanti bisa dua pilihan (2)
        }
        //Properties
        public string getAlamat(){                  //Properties (method get&set) untuk make field yang private untuk digunain di kelas lain (3)
            return alamat;
        }
        public void setAlamat(string Alamat){       //Method set mirip konstruktor tapi lebih rinci (cuma alamat) (3)
            this.alamat = Alamat;
        }
        public void metodTes(){
            Console.WriteLine("Saya adalah "+nama);
        }
    }

    //Kelas Abstrak (4)
    abstract class Enemy{                       
        public int hp = 100;                    //Kelas abstrak masih Bisa mengassign Field(variabel) (4)
        public string suara = "Meow";
        public void contohh(){
            Console.WriteLine(suara);           //Masih bisa pake method yang gak abstrak (udah didefinisi isinya) (4)
        }
        public abstract void Ngomong();        //Punya method/function abstract (Kosong dan harus didefinisi di class child) (5)
    }

    //Inheritance (5)
    class Slime : Enemy {                       //Slime inherit Enemy, Slime = child, Enemy = Parent (5)
        //Polymorph                             //Karena inherit enemy, slime juga punya hp = 100 dan suara meow
        public override void Ngomong(){         //Polymorph pake override method, kelas yang parentnya abstract atau interface, (5)
            Console.WriteLine("Blub");          //harus punya method abstract di parentnya yang udah didefinisiin seperti ini (5)
        }                                       //kalau ga punya method Ngomong() bakalan error
    }

    class Goblin : Enemy {
        //Polymorph
        public override void Ngomong(){
            Console.WriteLine("Gyahh");
        }
    }

    //Interface (6)
    interface entity{                           //Interface untuk kelas abstrak yang lebih abstrak, isinya cuma method abstrak (6)
        //int darah = 100;                      //Kalo bikin field(variabel) bakalan error karena interface ga boleh punya field   (6)
        void move();                            //seluruh method di interface defaultnya(harus) public dan abstract (6)
                                                // Implementasinya bisa diliat di file satunya
    }
}
