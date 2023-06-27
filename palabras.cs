using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ahorkadoPremium
{
    public class palabras
    {
        private int _id;
        private String _palabra;
        private int _nivel;
        public palabras()
        {
            _palabra = "";
            Nivel = 0;
        }
        public palabras(String palabra, int nivel)
        {
            this._palabra = palabra;
            this._nivel = nivel;
        }
        public palabras(int id, String palabra, int nivel)
        {
            this._id = id;
            this._palabra = palabra;
            this._nivel = nivel;
        }

        public string Palabra { get => _palabra; set => _palabra = value; }
        public int Id { get => this._id; set => this._id = value; }
        public int Nivel { get => _nivel; set => _nivel = value; }

        public int longitud(String palabra)
        {
            return palabra.Length;
        }
  
    }

}

