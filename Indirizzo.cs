using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_lista_indirizzi
{
    public class NotIntValueException : Exception
    {
    }

    internal class Indirizzo
    {
        //attributi
        private string name;
        private string surname;
        private string street;
        private string city;
        private string province;
        private int zip;

        //metodi

        //Costruttore
        public Indirizzo(string name, string surname, string street, string city, string province, int zip)
        {

            Name = name;
            Surname = surname;
            City = city;
            Street = street;
            Province = province;

           
            if(zip is string)
            {
                throw new NotIntValueException();
            }else ZIP = zip;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Street
        {
            get { return street; }
            set { street = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public string Province
        {
            get { return province; }
            set { province = value; }
        }
        public int ZIP
        {
            get { return zip; }
            set { zip = value; }
        }

        //modifico funzione per la riscrittura dei dati dalla mia lista al file csv
        public override string ToString()
        {
            return $"{Name}, {Surname} , {Street} , {City}, {Province}, (CAP:{ZIP})";
        }
    }
}
