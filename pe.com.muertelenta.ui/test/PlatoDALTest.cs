using pe.com.muertelenta.bo;
using pe.com.muertelenta.dal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace pe.com.muertelenta.ui.test
{
    public class PlatoDALTest
    {
        //prueba para el mostrar todo
        public static void findAllTest()
        {
            PlatoDAL dal = new PlatoDAL();
            List<PlatoBO> lista = dal.findAll();

            if (lista != null && lista.Count > 0)
            {
                Debug.WriteLine("Lista Completo de Platos");
                foreach (var item in lista)
                {
                    Debug.WriteLine($"Codigo: {item.codigo} - Nombre: {item.nombre} - Descripcion: {item.nombre} - Precio: {item.precio} - Cantidad: {item.cantidad} - Fecha Ingreso: {item.fechaingreso} - Fecha Caducidad: {item.fechacaducidad} - Refrigerable: {item.refrigerableplato.nombre} - Tipo de Plato: {item.tipoplato.nombre}  - Estado: {item.estado}");
                }
            }
            else
            {
                Debug.WriteLine("No se encontraron datos o hubo un error");
            }

        }

        //prueba para mostrar los habilitados
        public static void findAllCustomTest()
        {
            PlatoDAL dal = new PlatoDAL();
            List<PlatoBO> lista = dal.findAllCustom();

            if (lista != null && lista.Count > 0)
            {
                Debug.WriteLine("Lista Completo de Platos Habilitados");
                foreach (var item in lista)
                {
                    Debug.WriteLine($"Codigo: {item.codigo} - Nombre: {item.nombre} - Descripcion: {item.nombre} - Precio: {item.precio} - Cantidad: {item.cantidad} - Fecha Ingreso: {item.fechaingreso} - Fecha Caducidad: {item.fechacaducidad} - Refrigerable: {item.refrigerableplato.nombre} - Tipo de Plato: {item.tipoplato.nombre}  - Estado: {item.estado}");
                }
            }
            else
            {
                Debug.WriteLine("No se encontraron datos o hubo un error");
            }

        }

        //prueba para registrar tipo de plato
        public static void addTest()
        {
            PlatoDAL dal = new PlatoDAL();
            PlatoBO obj = new PlatoBO
            {
                nombre = "Prueba de Registro de Plato",
                descripcion = "Descripcion de una Prueba de Registro de Plato",
                precio = 28.80,
                cantidad = 10,
                fechaingreso = DateTime.Now,
                fechacaducidad = DateTime.Now.AddDays(5),
                tipoplato = new TipoPlatoBO { codigo = 2 },
                refrigerableplato = new RefrigerablePlatoBO { codigo = 2 },
                estado = true
            };
            bool resultado = dal.add(obj);
            Debug.WriteLine(resultado ? "Prueba de Registro Exitoso" : "Error al registrar");
        }

        //prueba para buscar
        public static void findByIdTest()
        {
            int id = 3;
            PlatoDAL dal = new PlatoDAL();
            PlatoBO obj = dal.findById(id);
            if (obj != null && obj.codigo > 0)
            {
                Debug.WriteLine("Busqueda de Tipos de Plato");
                Debug.WriteLine($"Codigo: {obj.codigo} - Nombre: {obj.nombre} - Descripcion: {obj.nombre} - Precio: {obj.precio} - Cantidad: {obj.cantidad} - Fecha Ingreso: {obj.fechaingreso} - Fecha Caducidad: {obj.fechacaducidad} - Refrigerable: {obj.refrigerableplato.nombre} - Tipo de Plato: {obj.tipoplato.nombre}  - Estado: {obj.estado}");
            }
            else
            {
                Debug.WriteLine("No se encontraron datos o hubo un error");
            }
        }

        //prueba actualizar
        public static void updateTest()
        {
            PlatoDAL dal = new PlatoDAL();
            int id = 3;
            PlatoBO obj = new PlatoBO
            {
                nombre = "Prueba de Actualizacion de Plato",
                descripcion = "Descripcion de una Prueba de Actualizacion de Plato",
                precio = 28.80,
                cantidad = 10,
                fechaingreso = DateTime.Now,
                fechacaducidad = DateTime.Now.AddDays(5),
                tipoplato = new TipoPlatoBO { codigo = 2 },
                refrigerableplato = new RefrigerablePlatoBO { codigo = 2 },
                estado = true
            };
            bool resultado = dal.update(obj, id);
            Debug.WriteLine(resultado ? "Prueba de Actualizacion Exitoso" : "Error al actualizar");
        }

        //prueba eliminar
        public static void deleteTest()
        {
            PlatoDAL dal = new PlatoDAL();
            int id = 3;
            bool resultado = dal.delete(id);
            Debug.WriteLine(resultado ? "Prueba de Eliminacion Exitoso" : "Error al eliminar");
        }

        //prueba habilitar
        public static void enableTest()
        {
            PlatoDAL dal = new PlatoDAL();
            int id = 3;
            bool resultado = dal.enable(id);
            Debug.WriteLine(resultado ? "Prueba de Habilitacion Exitoso" : "Error al habilitar");
        }
    }
}