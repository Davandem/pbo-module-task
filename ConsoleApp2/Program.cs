using System;
using System.Collections.Generic;

namespace SistemKaryawan
{
    class Karyawan
    {
        public string nama;
        public double gaji;

        public Karyawan(string nama, double gaji)
        {
            this.nama = nama;
            this.gaji = gaji;
        }

        public virtual void Kerja()
        {
            Console.WriteLine($"{nama} sedang bekerja.");
        }

        public virtual void InfoKaryawan()
        {
            Console.WriteLine($"Nama  : {nama}");
            Console.WriteLine($"Gaji  : Rp {gaji:N0}");
        }
    }

    class Tetap : Karyawan
    {
        public double tunjangan;

        public Tetap(string nama, double gaji, double tunjangan)
            : base(nama, gaji)
        {
            this.tunjangan = tunjangan;
        }

        public double HitungGajiTotal()
        {
            return gaji + tunjangan;
        }

        public override void Kerja()
        {
            Console.WriteLine($"{nama} bekerja sebagai karyawan tetap.");
        }

        public override void InfoKaryawan()
        {
            base.InfoKaryawan();
            Console.WriteLine($"Tunjangan : Rp {tunjangan:N0}");
            Console.WriteLine($"Total Gaji: Rp {HitungGajiTotal():N0}");
        }
    }

    class Kontrak : Karyawan
    {
        public int durasi;

        public Kontrak(string nama, double gaji, int durasi)
            : base(nama, gaji)
        {
            this.durasi = durasi;
        }

        public void CekKontrak()
        {
            Console.WriteLine($"{nama} memiliki kontrak selama {durasi} bulan.");
        }

        public override void Kerja()
        {
            Console.WriteLine($"{nama} bekerja sebagai karyawan kontrak.");
        }

        public override void InfoKaryawan()
        {
            base.InfoKaryawan();
            Console.WriteLine($"Durasi Kontrak: {durasi} bulan");
        }
    }

    class Manager : Tetap
    {
        public Manager(string nama, double gaji, double tunjangan)
            : base(nama, gaji, tunjangan)
        {
        }

        public void Memimpin()
        {
            Console.WriteLine($"{nama} sedang memimpin rapat dan mengarahkan tim.");
        }

        public override void Kerja()
        {
            Console.WriteLine($"{nama} bekerja sebagai Manager, mengawasi dan mengelola tim.");
        }

        public override void InfoKaryawan()
        {
            Console.WriteLine("[Manager]");
            base.InfoKaryawan();
        }
    }

    class Staff : Tetap
    {
        public Staff(string nama, double gaji, double tunjangan)
            : base(nama, gaji, tunjangan)
        {
        }

        public void KerjakanTugas()
        {
            Console.WriteLine($"{nama} sedang mengerjakan tugas harian yang diberikan.");
        }

        public override void Kerja()
        {
            Console.WriteLine($"{nama} bekerja sebagai Staff, menyelesaikan tugas operasional.");
        }

        public override void InfoKaryawan()
        {
            Console.WriteLine("[Staff]");
            base.InfoKaryawan();
        }
    }

    class Magang : Kontrak
    {
        public Magang(string nama, double gaji, int durasi)
            : base(nama, gaji, durasi)
        {
        }

        public void Belajar()
        {
            Console.WriteLine($"{nama} sedang belajar dan mengembangkan kemampuan di perusahaan.");
        }

        public override void Kerja()
        {
            Console.WriteLine($"{nama} bekerja sebagai Magang, belajar sambil membantu tim.");
        }

        public override void InfoKaryawan()
        {
            Console.WriteLine("[Magang]");
            base.InfoKaryawan();
        }
    }

    class Freelancer : Kontrak
    {
        public Freelancer(string nama, double gaji, int durasi)
            : base(nama, gaji, durasi)
        {
        }

        public void AmbilProyek()
        {
            Console.WriteLine($"{nama} sedang mengambil dan mengerjakan proyek baru.");
        }

        public override void Kerja()
        {
            Console.WriteLine($"{nama} bekerja sebagai Freelancer, menyelesaikan proyek secara mandiri.");
        }

        public override void InfoKaryawan()
        {
            Console.WriteLine("[Freelancer]");
            base.InfoKaryawan();
        }
    }

    class Perusahaan
    {
        private List<Karyawan> daftarKaryawan = new List<Karyawan>();

        public void TambahKaryawan(Karyawan karyawan)
        {
            daftarKaryawan.Add(karyawan);
            Console.WriteLine($"Karyawan '{karyawan.nama}' berhasil ditambahkan.");
        }

        public void DaftarKaryawan()
        {
            Console.WriteLine("\n===== DAFTAR SEMUA KARYAWAN =====");
            if (daftarKaryawan.Count == 0)
            {
                Console.WriteLine("Belum ada karyawan terdaftar.");
                return;
            }

            int nomor = 1;
            foreach (Karyawan k in daftarKaryawan)
            {
                Console.WriteLine($"\n--- Karyawan #{nomor} ---");
                k.InfoKaryawan();
                nomor++;
            }
            Console.WriteLine("=================================\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========== SISTEM KARYAWAN ==========\n");

            Perusahaan pt = new Perusahaan();

            Manager salim = new Manager("Salim", 15000000, 5000000);
            Staff jay = new Staff("Jay", 8000000, 1500000);
            Magang faisal = new Magang("Faisal", 1500000, 6);
            Freelancer ilham = new Freelancer("Ilham", 5000000, 3);

            Console.WriteLine("--- Menambahkan Karyawan ---");
            pt.TambahKaryawan(salim);
            pt.TambahKaryawan(jay);
            pt.TambahKaryawan(faisal);
            pt.TambahKaryawan(ilham);

            pt.DaftarKaryawan();

            Console.WriteLine("===== SOAL 1: method Kerja() =====");
            salim.Kerja();
            ilham.Kerja();
            Console.WriteLine();

            Console.WriteLine("===== SOAL 2: method Memimpin() =====");
            salim.Memimpin();
            Console.WriteLine();

            Console.WriteLine("===== SOAL 3: Info Lengkap Manager =====");
            salim.InfoKaryawan();
            Console.WriteLine($"Akses langsung - Tunjangan: Rp {salim.tunjangan:N0}");
            Console.WriteLine($"Total Gaji: Rp {salim.HitungGajiTotal():N0}");
            Console.WriteLine();

            Console.WriteLine("===== SOAL 4: method Belajar() =====");
            faisal.Belajar();
            Console.WriteLine();

            Console.WriteLine("===== SOAL 5: Polymorphism =====");
            Karyawan karyawanPolymorphism = new Staff("Sari Dewi", 7000000, 1200000);
            karyawanPolymorphism.Kerja();
            Console.WriteLine();

            Console.WriteLine("===== DEMONSTRASI POLYMORPHISM (loop) =====");
            List<Karyawan> semuaKaryawan = new List<Karyawan>
            {
                new Manager("Hendra", 12000000, 4000000),
                new Staff("Lestari", 6000000, 1000000),
                new Magang("Fajar", 1200000, 3),
                new Freelancer("Nina", 4500000, 2)
            };

            foreach (Karyawan k in semuaKaryawan)
            {
                k.Kerja();
            }
            Console.WriteLine();

            Console.WriteLine("===== METHOD KHUSUS TIAP SUBCLASS =====");
            salim.Memimpin();
            jay.KerjakanTugas();
            faisal.Belajar();
            ilham.AmbilProyek();
            faisal.CekKontrak();
            ilham.CekKontrak();
            Console.WriteLine();

            Console.WriteLine("===== SOAL 6: KESIMPULAN =====");
            Console.WriteLine("1. Inheritance memungkinkan subclass mewarisi properti dan method");
            Console.WriteLine("   dari superclass, menghindari penulisan kode berulang.");
            Console.WriteLine("2. Override memungkinkan subclass mendefinisikan ulang method");
            Console.WriteLine("   superclass agar berperilaku sesuai kebutuhannya sendiri.");
            Console.WriteLine("3. Polymorphism memungkinkan satu variabel bertipe induk dapat");
            Console.WriteLine("   menampung objek dari subclass mana pun, dan method yang");
            Console.WriteLine("   dipanggil akan menyesuaikan dengan tipe objek sebenarnya.");
            Console.WriteLine("4. Setiap subclass boleh memiliki method khusus yang hanya");
            Console.WriteLine("   bisa diakses melalui tipe yang sesuai.");
            Console.WriteLine("5. Konsep-konsep ini merupakan inti dari OOP yang membuat");
            Console.WriteLine("   kode lebih terstruktur, fleksibel, dan mudah dikembangkan.");

            Console.WriteLine("\n========== SELESAI ==========");
            Console.ReadLine();
        }
    }
}