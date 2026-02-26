using pe.com.muertelenta.bo;
using pe.com.muertelenta.dal;
using System.Collections.Generic;
using System.Diagnostics;

namespace pe.com.muertelenta.ui.test
{
    public class TipoDocumentoDALTest
    {
        public static void findAllTest()
        {
            TipoDocumentoDAL dal = new TipoDocumentoDAL();
            List<TipoDocumentoBO> lista = dal.findAll();

            if (lista != null && lista.Count > 0)
            {
                Debug.WriteLine("Lista Completa de Tipo Documento");
                foreach (var item in lista)
                    Debug.WriteLine($"Codigo: {item.codigo} - Nombre: {item.nombre} - Estado: {item.estado}");
            }
            else
                Debug.WriteLine("No hay datos");
        }

        public static void addTest()
        {
            TipoDocumentoDAL dal = new TipoDocumentoDAL();
            TipoDocumentoBO obj = new TipoDocumentoBO
            {
                nombre = "DNI Final Test",
                estado = true
            };

            Debug.WriteLine(dal.add(obj) ? "Registro Exitoso" : "Error");
        }

        public static void updateTest()
        {
            TipoDocumentoDAL dal = new TipoDocumentoDAL();
            TipoDocumentoBO obj = new TipoDocumentoBO
            {
                nombre = "DNI Actualizado Final",
                estado = true
            };

            Debug.WriteLine(dal.update(obj, 1) ? "Actualizado" : "Error");
        }

        public static void deleteTest()
        {
            TipoDocumentoDAL dal = new TipoDocumentoDAL();
            Debug.WriteLine(dal.delete(1) ? "Eliminado" : "Error");
        }
    }
}
