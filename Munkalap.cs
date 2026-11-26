using System;
using System.Collections.Generic;
using System.Text;

namespace Autoszervizkezelo
{
    public class Munkalap
    {
        public string UgyfelNev { get; set; }
        public string Kategoria { get; set; }
        public int Munkaora { get; set; }
        public int AlkatreszAr { get; set; }
        public bool Garancialis { get; set; }


        public Munkalap(string sor)
        {
            string[] adatok = sor.Split(';');

            UgyfelNev = adatok[0];
            Kategoria = adatok[1];
            Munkaora = int.Parse(adatok[2]);
            AlkatreszAr = int.Parse(adatok[3]);
            Garancialis = bool.Parse(adatok[4]);
        }
        public int FizetendoDij()
        {
            if (Garancialis == true)
            {
                return 0;
            }
            else
            {
                int oradij;

                if (Kategoria == "MOTOR")
                {
                    oradij = 15000;
                }
                else
                {
                    oradij = 12000;
                }

                return Munkaora * oradij + AlkatreszAr;
            }
        }
        public override string ToString()
        {
            return $"{UgyfelNev} ({Kategoria}):  {Munkaora} óra, alkatrész: {AlkatreszAr}, [{Garancialis}] - Fizetendő: {FizetendoDij()} Ft";
        }
    }
    }
