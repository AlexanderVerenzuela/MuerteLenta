using pe.com.muertelenta.bo;
using pe.com.muertelenta.dal;
using System.Collections.Generic;
using System.Diagnostics;

namespace pe.com.muertelenta.ui.test
{
    public class SexoDALTest
    {
        public static void findAllTest()
        {
            SexoDAL dal = new SexoDAL();
            List<SexoBO> lista = dal.findAll();

            if (lista != null && lista.Count > 0)
            {
                Debug.WriteLine("Lista Completa de Sexo");
                foreach (var item in lista)
                    Debug.WriteLine($"Codigo: {item.codigo} - Nombre: {item.nombre} - Estado: {item.estado}");
            }
            else
                Debug.WriteLine("No hay datos");
        }

        public static void addTest()
        {
            SexoDAL dal = new SexoDAL();
            SexoBO obj = new SexoBO
            {
                nombre = "Masculino Final",
                estado = true
            };

            Debug.WriteLine(dal.add(obj) ? "Registro OK" : "Error");
        }
    }
}
