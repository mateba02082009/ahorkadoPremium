
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ahorkadoPremium
{
   public class tPalabras
    {
        private palabras[] _palabrass;
        private int _limite;
        private Random _rnd;    //Lo ponemos sólo porque es el juego del ahorkado y tenemos que "acertar"
        private int _numpalabrass;

        public tPalabras(int limite)
        {
            this._palabrass = new palabras[limite];
            _limite = limite;
            _numpalabrass = 0;
            _rnd = new Random();

        }
        public void leerBD()
        {
            int index = 0;
            string ruta = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Administrador\source\repos\ahorkado.mdb";
            string consulta = "SELECT * FROM palabras";
            // Create a connection    
            using (OleDbConnection conexion = new OleDbConnection(ruta))
            {
                // Create a command and set its connection    
                OleDbCommand comando = new OleDbCommand(consulta, conexion);
                // Open the connection and execute the select command.    
                try
                {
                    // Open connecton    
                    conexion.Open();
                    // Execute command    
                    using (OleDbDataReader miTabla = comando.ExecuteReader())
                    {
                        
                        while (miTabla.Read())
                        {
                            palabras p=new palabras();
                            p.Id = miTabla.GetInt32(0);//id de la BD
                            p.Palabra=miTabla.GetString(1);//Palabra de la BD
                            p.Nivel = miTabla.GetInt32(2);//Nivel de la BD
                           
                            _palabrass[index] = p;
                            
                            index++;
                        }
                    }
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Problemicas txato!!" + ex.Message);
                }

            }
            System.Console.ReadKey();


        }
        public void leerBDNivel()
        {
            int index = 0;
            int nivel;
            string ruta = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Administrador\source\repos\ahorkado.mdb";
            string consulta = "SELECT * FROM palabras WHERE nivel=";

            System.Console.WriteLine("¿Qué nivel quieres? (1)Básico 2)Medio 3)Avanzado");
            nivel = int.Parse(System.Console.ReadLine());//Leemos el nivel de la palabra
            consulta = consulta + nivel;
            // Create a connection    
            using (OleDbConnection conexion = new OleDbConnection(ruta))
            {
                // Create a command and set its connection    
                OleDbCommand comando = new OleDbCommand(consulta, conexion);
                // Open the connection and execute the select command.    
                try
                {
                    // Open connecton    
                    conexion.Open();
                    // Execute command    
                    using (OleDbDataReader miTabla = comando.ExecuteReader())
                    {

                        while (miTabla.Read())
                        {
                            palabras p = new palabras();
                            p.Id = miTabla.GetInt32(0);//id de la BD
                            p.Palabra = miTabla.GetString(1);//Palabra de la BD
                            p.Nivel = miTabla.GetInt32(2);//Nivel de la BD

                            _palabrass[index] = p;
                           
                            index++;
                            _numpalabrass = index;

                        }
                    }
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Problemicas txato!!" + ex.Message);
                }

            }
            System.Console.ReadKey();


        }
        public palabras sortearpalabras() {
           
            return(_palabrass[_rnd.Next(_numpalabrass)]);

        }
        public void dibujarPalabra(palabras p)
        {
            String guiones = "";

            for (int i = 0; i < p.longitud(p.Palabra); i++)
            {
                guiones = guiones + "_ ";

            }
            System.Console.Write(guiones);


        }
        public void mostrarpalabras()
        {
            palabras p = sortearpalabras();
            System.Console.WriteLine(p.ToString());
            
        }

        public void aniadirpalabras(palabras p)
    {
        if (p != null && _numpalabrass < _palabrass.Length)
        {
            _palabrass[_numpalabrass] = p;
            _numpalabrass++;
        }
    }

    public void mostrarpalabrass()
    {
        for (int i = 0; i < _numpalabrass; i++)
        {
            Console.WriteLine(_palabrass[i].ToString());
        }
    }

    public void vaciarpalabrass()
    {
        this._palabrass = new palabras[_limite];
        _numpalabrass = 0;
    }

    public void eliminarpalabras(palabras p)
    {
        if (p != null && _numpalabrass != 0)
        {

            int posicion = -1;
            for (int i = 0; i < _numpalabrass; i++)
            {
                if (p.Id == _palabrass[i].Id)
                {
                    posicion = i;
                }
            }

            if (posicion == -1)
            {
                Console.WriteLine("No existe el palabras");
            }
            else
            {
                _palabrass[posicion] = null;

                for (int i = posicion; i < _numpalabrass; i++)
                {
                    _palabrass[i] = _palabrass[i + 1];

                }
                _palabrass[_numpalabrass]=null;
                _numpalabrass--;

            }

        }
    }
    public palabras buscarpalabras(int id)
    {
        if (_numpalabrass != 0)
        {

            int posicion = -1;
            for (int i = 0; i < _numpalabrass; i++)
            {
                if (id == _palabrass[i].Id)
                {
                    posicion = i;
                }
            }

            if (posicion == -1)
            {
                Console.WriteLine("No existe el palabras");
                return null;
            }
            else
            {
                return (_palabrass[posicion]);


            }

        }
        else {//No hay palabrass en el tPalabras

            return null;
            
        }
    }

}

}

