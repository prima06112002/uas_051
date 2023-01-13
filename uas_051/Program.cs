using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UAS_051
{
    class Node
    {
        //deklarasi variabel
        public int nim;
        public string namamahasiswa;
        public string jeniskelamin;
        public string kelas;
        public string kotaasal;
        public Node next;
    }
    class LinkedList
    {
        Node LAST;
        public LinkedList()
        {
            LAST = null;
        }
        //Method Menambahkan Data
        public void addnode()
        {
            int number;
            string nm;
            string dss;
            string hrg;
            

            Console.WriteLine("Masukkan nim mahasiswa : ");
            number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Masukkan Nama mahasiswa : ");
            nm = Console.ReadLine();
            Console.WriteLine("Masukkan jenis kelamin : ");
            dss = Console.ReadLine();
            Console.WriteLine("Masukkan kelas : ");
            hrg = Console.ReadLine();
            Console.WriteLine("Masukkan asal kota : ");
            dss = Console.ReadLine();

            Node newnode = new Node();

            newnode.nim = number;
            newnode.namamahasiswa = nm;
            newnode.jeniskelamin = dss;
            newnode.kelas = hrg;
            newnode.kotaasal = dss;

            if (listempty())
            {
                newnode.next = newnode;
                LAST = newnode;
            }
            else if (number < LAST.next.nim)
            {
                newnode.next = LAST.next;
                LAST.next = newnode;
            }
            else if (number > LAST.nim)
            {
                newnode.next = LAST.next;
                LAST.next = newnode;
                LAST = newnode;
            }
            else
            {
                Node current, previous;
                current = previous = LAST.next;

                int i = 0;
                while (i < number - 1)
                {
                    previous = current;
                    current = current.next;
                    i++;
                }
                newnode.next = current;
                previous.next = newnode;
            }
        }
        //Method Mencari Data
        public bool Search(string dss, ref Node previous, ref Node current)
        {
            for (previous = current = LAST.next; current != LAST; previous = current, current = current.next)
            {
                if (dss == current.jeniskelamin)
                    return true;//return true if the node is found
            }
            if (dss == LAST.jeniskelamin)
                return true;
            else
                return (false);
        }
        //Method Menghapus Data
        public bool delNode(string namaobat)
        {
            Node previous, current;
            previous = current = LAST.next;

            //mengecek spesifikasi isi nod sekarang masih ada didalam list atau tidak
            if (Search(namaobat, ref previous, ref current) == false)
                return false;
            previous.next = current.next;

            //proses mendelete data
            if (LAST.next.nim == LAST.nim)
            {
                LAST.next = null;
                LAST = null;
            }
            else if (namaobat == LAST.namamahasiswa)
            {
                LAST.next = current.next;
            }
            else
            {
                LAST = LAST.next;
            }
            return true;
        }
        public void display()
        {
            if (listempty())
                Console.WriteLine("\nList Kosong : ");
            else
            {
                Console.WriteLine("\nPencarian yang terkait adalah : ");
                Node currentNode;

                currentNode = LAST.next;
                while (currentNode != LAST)
                {
                    Console.Write(currentNode.nim + " " + currentNode.namamahasiswa + " " + currentNode.jeniskelamin + " " + currentNode.kelas + " " + currentNode.kotaasal);
                    currentNode = currentNode.next;
                }
                Console.Write(LAST.nim + " " + LAST.namamahasiswa + " " + LAST.jeniskelamin + " " + currentNode.kelas + " " + currentNode.kotaasal);
            }
        }
        public void firstnode()
        {
            if (listempty())
                Console.WriteLine("\nList kosong");
            else
                Console.WriteLine("\nUrutan pertama adalah :\n\n " + LAST.next.nim + "   " + LAST.next.namamahasiswa);
        }
        public bool listempty()
        {

            if (LAST == null)
                return true;
            else
                return false;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Program menu = new Program();
            LinkedList data = new LinkedList();
            Node a = new Node();

            while (true)
            {
                try
                {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("------- PILIH MENU -------");
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("1. Cari Data Yang Diperlukan");
                    Console.WriteLine("2. Hapus Data  ");
                    Console.WriteLine("3. Tambah Data ");
                    Console.WriteLine("4. Exit\n");
                    Console.WriteLine("Masukan Pilihan Anda ");
                    char ch = Convert.ToChar(Console.ReadLine());

                    switch (ch)
                    {
                        case '1':
                            {
                                data.addnode();
                            }
                            break;
                        case '2':
                            {
                                if (data.listempty())
                                {
                                    Console.WriteLine("\nList Kosong");
                                    break;
                                }
                                //pencarian node list yang akan didelete
                                Console.Write("\nMasukkan Data yang akan dihapus : ");
                                string value = Convert.ToString(Console.ReadLine());
                                Console.WriteLine();

                                //output data yang didelete node
                                if (data.delNode(value) == false)
                                    Console.WriteLine("\nData tidak ditemukan");
                                else
                                    Console.WriteLine("Data dengan No" + " " + value + " " + "dihapus dari list");
                            }
                            break;
                        case '3':
                            {
                                data.display();
                            }
                            break;
                        case '4':
                            {
                                data.firstnode();
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("\nPilihan Salah");
                                Console.ReadKey();
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
/* 2. Menggunakan Algoritma LinkedList
      Dikarenakan algoritma ini dapat menggunakan method pencarian, mengurutkan dan menampilkan dan juga tidak ada batasannya seperti array.
   3. add Front , delete Front (CircularQueues)
   4. Perbedaan dari Array dan LinkedList adalah 
      Array dan linked list adalah dua jenis struktur data yang digunakan untuk menyimpan dan mengakses data secara efisien. Perbedaannya terletak pada cara data disimpan dan diakses.
      jika array ada pengulangan jika LinkedList tidak dikarenakan array dapat mengurutkan data dari yg terbesar dan terkecil
      jika LinkedList terdapat method search display yang dapat menginput data, menampilkan , dan menghapus data data yg kita inginkan berbeda dengan array
      Kapan kita harus menggunakan tipe data tersebut:
      Array lebih cocok digunakan saat data yang akan disimpan memiliki ukuran yang tetap dan akses data yang sering dilakukan.
      Linked list lebih cocok digunakan saat data yang akan disimpan memiliki ukuran yang tidak tetap dan operasi insert dan delete yang sering dilakukan.
   5.  a. 10,30  5,15 10,15  20,32 20,28
       b. Menggunakan metode Inorder 5,10,10,12,15,16,18,15,20,20,20,25,28,20,30,32
*/