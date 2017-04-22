using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_de_inventario
{
    class Inventario
    {        
        Producto inicio, ultimo;

        public void agregar(Producto producto)
        {
            if (inicio == null)
                inicio = producto;
            else
                ultimo.siguiente = producto;
            ultimo = producto;
        }

        public Producto buscar(int codigo)
        {    
            Producto actual = inicio;
            while (actual != null)
            {
                if (actual.codigo == codigo)
                    return actual;
                actual = actual.siguiente;
            }
            return null;
        }

        public void borrar(int codigo)
        {
            if (inicio != null)
            {
                Producto actual, anterior;
                anterior = buscarAnteriorPadre(codigo);

                if (anterior == null)
                {
                    actual = inicio;
                    inicio = inicio.siguiente;
                    anterior = inicio;
                }
                else
                {
                    actual = anterior.siguiente;
                    anterior.siguiente = actual.siguiente;
                }
                actual = null;

                if (anterior == null || anterior.siguiente == null)
                    ultimo = anterior;
            }        
        }

        private Producto buscarAnteriorPadre(int codigo)
        {
            Producto anteriorPadre, actual;
            actual = inicio;
            anteriorPadre = null;

            while (actual != null)
            {
                if (actual.codigo == codigo)
                    break;
                anteriorPadre = actual;
                actual = actual.siguiente;
            }
            return anteriorPadre;
        }

        public string reporte()
        {
            string cad = "";

            if (inicio != null)
            {
                Producto actual = inicio;
                while (actual != null)
                {
                    cad += actual.ToString()+ Environment.NewLine;
                    actual = actual.siguiente;
                }
            }
            return cad;
        }

        public void insertar(Producto producto, int posicion)
        {
            Producto anteriorPadre, actual;
            actual = inicio;
            anteriorPadre = null;
            int contador = 1;

            do
            {
                if (contador == posicion)
                {
                    anteriorPadre.siguiente = producto;
                    producto.siguiente = actual;
                }                  
                anteriorPadre = actual;
                actual = actual.siguiente;
                contador++;
            }
            while (actual != null);
        }

        public void AgregarEnInicio(Producto producto)
        {
            if (inicio == null)
                inicio = producto;
            else
            {
                producto.siguiente = inicio;
                inicio = producto;                  
            }

        }
    }
}
