using System;
using System.Collections.Generic;

namespace PatronObserver_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            EstacionMeteorologica estacionMeteorologica = new EstacionMeteorologica();

            AgenciaDeNoticias Agencia1 = new AgenciaDeNoticias("Telesistema");
            estacionMeteorologica.Adjuntar(Agencia1);

            AgenciaDeNoticias Agencia2 = new AgenciaDeNoticias("CDN 37");
            estacionMeteorologica.Adjuntar(Agencia2);

            estacionMeteorologica.Temperatura = 46.8f;
            estacionMeteorologica.Temperatura = 31.2f;
            estacionMeteorologica.Temperatura = 28f;
            estacionMeteorologica.Temperatura = 16.3f;

            Console.ReadLine();
        }

        interface ITema
        {
            void Adjuntar(IObserver observer);
            void Notificar();
        }

        class EstacionMeteorologica : ITema
        {
            private List<IObserver> _observers;

            public float Temperatura
            {
                get { return _temperatura; }
                set
                {
                    _temperatura = value;
                    Notificar();
                }
            }

            private float _temperatura;
            public EstacionMeteorologica()
            {
                _observers = new List<IObserver>();
            }

            public void Adjuntar(IObserver observer)
            {
                _observers.Add(observer);
            }

            public void Notificar()
            {
                _observers.ForEach(o =>
                {
                    o.Actualizar(this);
                });
            }
        }

        interface IObserver
        {
            void Actualizar(ITema Tema);
        }

        class AgenciaDeNoticias : IObserver
        {
            public String NombreDeAgencia { get; set; }
            public AgenciaDeNoticias(string nombre)
            {
                NombreDeAgencia = nombre;
            }

            public void Actualizar(ITema Tema)
            {
                if (Tema is EstacionMeteorologica estacionMeteorologica)
                {
                    Console.WriteLine(string.Format("{0} reportando temperatura de {1} grados Celcius", 
                        NombreDeAgencia, 
                        estacionMeteorologica.Temperatura));
                    Console.WriteLine();
                }
            }   
        }
    }
}
