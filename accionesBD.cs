using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace ahorkadoPremium
{
    class accionesBD
    {
        //Las de BD
        public void leerBD()
        {
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
                        Console.WriteLine("------------Tabla Palabras----------------");
                        while (miTabla.Read())
                        {
                            /////EVOLUCIONAR!!!!
                            Console.WriteLine("{0} {1} {2} ", miTabla["Id"], miTabla["palabra"].ToString(), miTabla["nivel"]);
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
        public void eliminarDeDB()
        {
            string ruta = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Administrador\source\repos\ahorkado.mdb";
            string consulta = "DELETE FROM palabras WHERE id=";
            int id;

            System.Console.WriteLine("¿Qué id quieres eliminar?");
            id = int.Parse(System.Console.ReadLine());
            consulta = consulta + id;

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

                    OleDbDataReader miTabla = comando.ExecuteReader();

                    Console.WriteLine("Eliminado!");
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Problemicas txato!!" + ex.Message);
                }

            }
            System.Console.ReadKey();


        }
        public void insertarEnBD()
        {
            //La ruta de la BD
            string ruta = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Administrador\source\repos\ahorkado.mdb";
            //Leemos lo que vamos a insertar
            System.Console.WriteLine("Inserta una palabra, por favor:");
            String palabra = System.Console.ReadLine();
            System.Console.WriteLine("Inserta un nivel, por favor:");
            int nivel = int.Parse(System.Console.ReadLine());


            //Preparamos la query(consulta)
            string consulta = "INSERT INTO palabras(palabra, nivel) VALUES ('" + palabra + "'," + nivel + ")";
            System.Console.WriteLine(consulta);
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
                    OleDbDataReader miTabla = comando.ExecuteReader();
                    Console.WriteLine("Insertado correctamente");
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Problemicas txato!!" + ex.Message);
                }

            }
            System.Console.ReadKey();

        }
        public void actualizarEnBD()
        {
            //La ruta de la BD
            string ruta = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Administrador\source\repos\ahorkado.mdb";
            int opc;
            int id;
            String palabra = "";
            int nivel = 0;
            String consultaBase = "UPDATE palabras SET  ";
            String consultaPal = "";
            String consultaNivel = "";

            System.Console.WriteLine("¿Qué id quieres actualizar?");
            id = int.Parse(System.Console.ReadLine());

            do
            {
                System.Console.WriteLine("¿Qué quieres actualizar?\n 1)Palabra\n 2)Nivel\n 0)Salir");
                opc = int.Parse(System.Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        //Leemos lo que vamos a insertar
                        System.Console.WriteLine("Inserta una palabra, por favor:");
                        palabra = System.Console.ReadLine();
                        consultaPal = consultaBase + " Palabra = '" + palabra + "' WHERE Id = " + id;
                        break;

                    case 2:
                        System.Console.WriteLine("Inserta un nivel, por favor:");
                        nivel = int.Parse(System.Console.ReadLine());
                        consultaNivel = consultaBase + " Nivel = " + nivel + " WHERE Id = " + id;
                        break;
                    default:
                        Console.WriteLine("Una opción de la lista!!");
                        break;
                }

            } while (opc != 0);

            //Ver consulta
            System.Console.WriteLine(consultaPal);
            System.Console.WriteLine(consultaNivel);

            // Create a connection    
            using (OleDbConnection conexion = new OleDbConnection(ruta))
            {
                // Create a command and set its connection    
                OleDbCommand comandoPal = new OleDbCommand(consultaPal, conexion);
                OleDbCommand comandoNivel = new OleDbCommand(consultaNivel, conexion);
                // Open the connection and execute the select command.    
                try
                {
                    // Open connecton    
                    conexion.Open();
                    // Execute command
                    if (consultaPal != "")
                    {
                        OleDbDataReader miTabla = comandoPal.ExecuteReader();
                    }

                    if (consultaNivel != "")
                    {
                        OleDbDataReader miTabla = comandoNivel.ExecuteReader();
                    }

                    Console.WriteLine("Actualizado correctamente");
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Problemicas txato!!" + ex.Message);
                }

            }
            System.Console.ReadKey();

        }








    






}
}
