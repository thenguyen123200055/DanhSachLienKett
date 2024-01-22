using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhSachLienKet
{
    class Node
    {
        private int info;
        private Node next;

        public Node(int x)
        {
            info = x;
            next = null;
        }
        public int Info
        {
            set { this.info = value; }
            get { return info; }
        }
        public Node Next
        {
            set { this.next = value; }
            get { return next; }
        }
        class SingleLinkList
        {
            private Node Head;
            public SingleLinkList()
            {
                Head = null;
            }
            public void AddHead(int x)
            {
                Node p = new Node(x);
                if (Head == null)
                {
                    Head = p;
                }
                else
                {
                    Node q = Head;
                    while (q.Next != null)
                    {
                        q = q.Next;
                    }
                    q.Next = p;
                }
            }
            public void DeleteHead()
            {
                if (Head != null)
                {
                    Node p = Head;
                    Head = Head.Next;
                    p.Next = null;
                }
            }
            public void DeleteLast()
            {
                if (Head != null)
                {
                    Node p = Head;
                    Node q = null;
                    while (p.Next != null)
                    {
                        q = p;
                        p = p.Next;
                    }
                    q.next = null;
                }
            }
            // phuong thuc xoa co gia x
            public void DeleteNode(int x)
            {
                if (Head != null)
                {
                    Node p = Head;
                    Node q = null; //nut tam de xac dinh nut truov p
                    //duyet danh sach de tim nut co gia tri can xoa
                    while (p != null && p.Info != x)
                    {
                        q = p;
                        p = p.Next;
                    }
                    // xoa nut p
                    if (p != null)
                    {
                        if (p != null)
                        {
                            if (p == Head)
                                DeleteHead();
                            else
                            {
                                q.next = p.Next;
                                p.Next = null;
                            }
                        }
                    }
                }
            }


            public void ProcessList()
            {
                Node p = Head;
                while (p != null)
                {
                    Console.WriteLine($"{p.Info} ");
                    p = p.Next;
                }
            }
            public Node FindMax()
            {
                Node max = Head;
                Node p = Head.Next;
                while (p != null)
                {
                    if (p.Info > max.Info)
                    {
                        max = p;
                    }
                    p = p.Next;
                }
                return max;
            }
            public float Avg()
            {
                float sum = 0;
                int count = 0;
                Node p = Head;
                while (p != null)
                {
                    sum += p.Info;
                    count++;

                    p = p.Next;
                }
                return sum / count;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                SingleLinkList l = new SingleLinkList();
                NhapDanhSach(l);
                Console.WriteLine("Danh sach lien ket");
                l.ProcessList();

                l.DeleteHead();
                Console.WriteLine("\nDanh sach lien ket sau khi xoa nut dau:");
                l.ProcessList();

                l.DeleteLast();
                Console.WriteLine("\nDanh sach lien ket sau khi xoa nut cuoi:");
                l.ProcessList();

                Console.Write("\nNhap gia tri x can xoa:");
                int x = int.Parse(Console.ReadLine());
                l.DeleteNode(x);
                Console.WriteLine("\nDanh sach lien ket sau khi xoa nut co gia tri x:");
                l.ProcessList();

                Console.WriteLine($"Nut co gia tri lon nhat:{l.FindMax().Info}");
                Console.WriteLine($"Nut co gia tri trung binh bang:{l.Avg()}");
                Console.ReadLine();
            }
            static void NhapDanhSach(SingleLinkList l)
            {
                string chon = "y";
                int x;
                while (chon != "n")
                {
                    Console.WriteLine("Nhap gia tri nut:");
                    x = int.Parse(Console.ReadLine());
                    l.AddHead(x);
                    Console.Write("Tiep tuc(Y or N)?");
                    chon = Console.ReadLine();
                }
            }


        }
    }
}
