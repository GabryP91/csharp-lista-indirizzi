/*
 
Oggi esercitazione sui file, ossia vi chiedo di prendere dimestichezza con quanto appena visto sui file in classe, in particolare nel live-coding di oggi.
In questo esercizio dovrete leggere un file CSV, che cambia poco da quanto appena visto nel live-coding in classe, e salvare tutti gli indirizzi in esso contenuti 
all’interno di una lista di oggetti istanziati a partire dalla classe Indirizzo.

**Attenzione:** gli ultimi 3 indirizzi presentano dei possibili “casi particolari” che possono accadere a questo genere di file: vi chiedo di pensarci e di gestire come meglio crediate queste casistiche.
 
**Bonus**: iterare la lista di indirizzi e risalvarli in un file.

*/

using System.Collections.Generic;
using System.IO;

namespace csharp_lista_indirizzi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "D:\\dati utente\\Desktop\\Progetti Boolean\\Esercizi\\CORSO.net\\csharp-lista-indirizzi\\addresses.csv"; // Percorso del file CSV
            string filePath2 = "D:\\dati utente\\Desktop\\Progetti Boolean\\Esercizi\\CORSO.net\\csharp-lista-indirizzi\\addresses2.csv";

            //istanzio la mia lista di indirizzi
            List<Indirizzo> listaIndirizzi = new List<Indirizzo>();

            using var stream = File.OpenText(filePath); //tramite uso parola chiave using chiamo automaticamente a fine esecuzione il metodo Dispose() 

            int i = 0;

            while (stream.EndOfStream == false) // fino a quando tutto il dato stream non è stato scansionato
            {

                var linea = stream.ReadLine(); //leggi una linea e restituisce una stringa

                i++;

                if (i <= 1) // Ignoro la prima riga del testo
                    continue;


                    // Converto ogni linea in un indirizzo
                    var dati = linea.Split(','); // Supponendo che il separatore sia dato dalla virgola

                    //se la lunghezza della singola riga del file è minore di 6
                    if (dati.Length < 6)
                    {

                        Console.WriteLine("\nStringa non valida: " + linea + "\n");
                    }
                    else
                    {

                        try
                        {
                            //acquisisco ogni dato dalle dovute posizioni
                            string name = dati[0];
                            string surname = dati[1];
                            string street = dati[2];
                            string city = dati[3];
                            string province = dati[4];


                            int zip;
                            if (!int.TryParse(dati[5], out zip))
                            {
                                throw new NotImplementedException();

                            }

                            if (string.IsNullOrEmpty(street))
                            {
                                street = "Valore assente";
                            }

                            if (string.IsNullOrEmpty(name))
                            {
                                name = "Valore assente";
                            }

                            if (string.IsNullOrEmpty(province))
                            {
                                province = "Valore assente";
                            }

                            //creo un oggetto indirizzo passando le informazioni acquisite precedentemente
                            Indirizzo adres = new Indirizzo(name, surname, street, city, province, zip);

                            //inserisco all'interno della mia lista di indirizzi il nuovo indirizzo
                            listaIndirizzi.Add(adres);
                        }

                        
                        catch (NotImplementedException e)
                        {
                        Console.WriteLine("\nIl codice ZIP deve essere un numero intero.\n");
                        }
                
                }
                
            }

            // Stampa degli indirizzi
            foreach (var indirizzo in listaIndirizzi)
            {
                Console.WriteLine(indirizzo.ToString());


            }
            //chiamo funzione per la scrittura in un nuovo file
            ScriviInTesto(listaIndirizzi, filePath2);
        }

        public static void ScriviInTesto(List<Indirizzo> listaIndirizzi, string filePath)
        {
            using StreamWriter stream = File.CreateText(filePath); // using può essere usato solo quando si hanno delle classi che implementano IDisposable
            foreach (var indirizzo in listaIndirizzi)
                stream.WriteLine(indirizzo.ToString());
        }
    }
}