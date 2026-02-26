using pe.com.muertelenta.bo;
using pe.com.muertelenta.dal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace pe.com.muertelenta.ui.test
{
    public class TipoPlatoDALTest
    {
        //prueba para el mostrar todo
        public static void findAllTest()
        {
            TipoPlatoDAL dal = new TipoPlatoDAL();
            List<TipoPlatoBO> lista = dal.findAll();

            if (lista != null && lista.Count > 0)
            {
                Debug.WriteLine("Lista Completo de Tipos de Plato");
                foreach (var item in lista)
                {
                    Debug.WriteLine($"Codigo: {item.codigo} - Nombre: {item.nombre} - Estado: {item.estado}");
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
            TipoPlatoDAL dal = new TipoPlatoDAL();
            List<TipoPlatoBO> lista = dal.findAllCustom();

            if (lista != null && lista.Count > 0)
            {
                Debug.WriteLine("Lista de Tipos de Plato Habilitados");
                foreach (var item in lista)
                {
                    Debug.WriteLine($"Codigo: {item.codigo} - Nombre: {item.nombre} - Estado: {item.estado}");
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
            TipoPlatoDAL dal = new TipoPlatoDAL();
            TipoPlatoBO obj = new TipoPlatoBO
            {
                nombre = "Prueba de Registro de Tipo de Plato",
                estado = true
            };
            bool resultado = dal.add(obj);
            Debug.WriteLine(resultado ? "Prueba de Registro Exitoso" : "Error al registrar");
        }

        //prueba para buscar
        public static void findByIdTest()
        {
            int id = 3;
            TipoPlatoDAL dal = new TipoPlatoDAL();
            TipoPlatoBO obj = dal.findById(id);
            if (obj != null && obj.codigo > 0)
            {
                Debug.WriteLine("Busqueda de Tipos de Plato");
                Debug.WriteLine($"Codigo: {obj.codigo} - Nombre: {obj.nombre} - Estado: {obj.estado}");
            }
            else
            {
                Debug.WriteLine("No se encontraron datos o hubo un error");
            }
        }

        //prueba actualizar
        public static void updateTest()
        {
            TipoPlatoDAL dal = new TipoPlatoDAL();
            int id = 3;
            TipoPlatoBO obj = new TipoPlatoBO
            {
                codigo = 3,
                nombre = "Prueba de Actualizacion de Tipo de Plato",
                estado = true
            };
            bool resultado = dal.update(obj, id);
            Debug.WriteLine(resultado ? "Prueba de Actualizacion Exitoso" : "Error al actualizar");
        }

        //prueba eliminar
        public static void deleteTest()
        {
            TipoPlatoDAL dal = new TipoPlatoDAL();
            int id = 3;
            bool resultado = dal.delete(id);
            Debug.WriteLine(resultado ? "Prueba de Eliminacion Exitoso" : "Error al eliminar");
        }

        //prueba habilitar
        public static void enableTest()
        {
            TipoPlatoDAL dal = new TipoPlatoDAL();
            int id = 3;
            bool resultado = dal.enable(id);
            Debug.WriteLine(resultado ? "Prueba de Habilitacion Exitoso" : "Error al habilitar");
        }
    }
}