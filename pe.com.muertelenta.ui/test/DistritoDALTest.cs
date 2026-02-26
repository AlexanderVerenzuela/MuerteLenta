using pe.com.muertelenta.bo;
using pe.com.muertelenta.dal;
using System.Collections.Generic;
using System.Diagnostics;

namespace pe.com.muertelenta.ui.test
{
    public class DistritoDALTest
    {
        public static void findAllTest()
        {
            DistritoDAL dal = new DistritoDAL();
            List<DistritoBO> lista = dal.findAll();

            if (lista != null && lista.Count > 0)
            {
                Debug.WriteLine("Lista Completa de Distritos");
                foreach (var item in lista)
                    Debug.WriteLine($"Codigo: {item.codigo} - Nombre: {item.nombre} - Estado: {item.estado}");
            }
            else
                Debug.WriteLine("No se encontraron datos");
        }

        public static void findAllCustomTest()
        {
            DistritoDAL dal = new DistritoDAL();
            List<DistritoBO> lista = dal.findAllCustom();

            if (lista != null && lista.Count > 0)
            {
                Debug.WriteLine("Distritos Habilitados");
                foreach (var item in lista)
                    Debug.WriteLine($"Codigo: {item.codigo} - Nombre: {item.nombre}");
            }
            else
                Debug.WriteLine("No hay datos habilitados");
        }

        public static void addTest()
        {
            DistritoDAL dal = new DistritoDAL();
            DistritoBO obj = new DistritoBO
            {
                nombre = "Distrito Test Final",
                estado = true
            };

            bool resultado = dal.add(obj);
            Debug.WriteLine(resultado ? "Registro Exitoso" : "Error al registrar");
        }

        public static void findByIdTest()
        {
            int id = 1;
            DistritoDAL dal = new DistritoDAL();
            DistritoBO obj = dal.findById(id);

            if (obj != null && obj.codigo > 0)
                Debug.WriteLine($"Codigo: {obj.codigo} - Nombre: {obj.nombre} - Estado: {obj.estado}");
            else
                Debug.WriteLine("No encontrado");
        }

        public static void updateTest()
        {
            DistritoDAL dal = new DistritoDAL();
            DistritoBO obj = new DistritoBO
            {
                nombre = "Distrito Actualizado Final",
                estado = true
            };

            bool resultado = dal.update(obj, 1);
            Debug.WriteLine(resultado ? "Actualizacion Exitosa" : "Error al actualizar");
        }

        public static void deleteTest()
        {
            DistritoDAL dal = new DistritoDAL();
            bool resultado = dal.delete(1);
            Debug.WriteLine(resultado ? "Eliminacion Exitosa" : "Error al eliminar");
        }

        public static void enableTest()
        {
            DistritoDAL dal = new DistritoDAL();
            bool resultado = dal.enable(1);
            Debug.WriteLine(resultado ? "Habilitacion Exitosa" : "Error al habilitar");
        }
    }
}
