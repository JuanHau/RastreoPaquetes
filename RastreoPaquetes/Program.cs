using RastreoPaquetes.Entidades.Pedido.Interfaces;
using RastreoPaquetes.Operaciones.Servicios;
using RastreoPaquetes.Utilerias;
using System;
using System.Collections.Generic;
using System.IO;

namespace RastreoPaquetes
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            LectorArchivo lectorArchivo = new LectorArchivo();
            SeparadorColumnas separadorColumnas = new SeparadorColumnas();
            ValidadorLinea validadorLinea = new ValidadorLinea();

            ValidadorFecha validadorFecha = new ValidadorFecha();
            ValidadorTransporte validadorTransporte = new ValidadorTransporte();
            Calculador calculador = new Calculador();
            ObtenedorEscala obtenedorEscala = new ObtenedorEscala();
            ObtenedorDuracion obtenedorDuracion = new ObtenedorDuracion();
            ObtenedorTipoEvento obtenedorTipoEvento = new ObtenedorTipoEvento();

            FormateadorFuturoMensajeSingular formateadorFuturoMensajeSingular = new FormateadorFuturoMensajeSingular();
            FormateadorFuturoMensajePlural formateadorFuturoMensajePlural = new FormateadorFuturoMensajePlural();
            FormateadorPasadoMensajeSingular formateadorPasadoMensajeSingular = new FormateadorPasadoMensajeSingular();
            FormateadorPasadoMensajePlural formateadorPasadoMensajePlural = new FormateadorPasadoMensajePlural();

            formateadorFuturoMensajeSingular.SiguienteFormateador(formateadorFuturoMensajePlural);
            formateadorFuturoMensajePlural.SiguienteFormateador(formateadorPasadoMensajeSingular);
            formateadorPasadoMensajeSingular.SiguienteFormateador(formateadorPasadoMensajePlural);

            PobladorPedido pobladorPedido = new PobladorPedido(
                validadorFecha,
                validadorTransporte,
                calculador,
                obtenedorEscala,
                obtenedorDuracion,
                obtenedorTipoEvento);

            ImprimidorPantalla imprimidorPantalla = new ImprimidorPantalla();

            FactoryEjecutor servicioEjecutor = new FactoryEjecutor(validadorTransporte, pobladorPedido);

            List<string> lineas = lectorArchivo.LeerArchivo(Path.GetFullPath("paquetes.txt"));

            foreach (string linea in lineas)
            {
                string[] columnas = separadorColumnas.SepararPorCaracter(linea, ',');
                if (validadorLinea.ValidarFormato(columnas, 6))
                {
                    IPedido pedido = pobladorPedido.PoblarPedido(columnas);

                    servicioEjecutor.RealizarEnvios(pedido, new DateTime(2020, 01, 01));

                    string resultado = formateadorFuturoMensajeSingular.FormatearMensaje(pedido);

                    imprimidorPantalla.ImprimirConsola(resultado);
                }
            }

            Console.ReadLine();
        }
    }
}
