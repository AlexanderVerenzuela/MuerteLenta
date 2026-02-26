using pe.com.muertelenta.bo;
using pe.com.muertelenta.dal;
using System.Collections.Generic;
using System.Diagnostics;

namespace pe.com.muertelenta.ui.test
{
    public class RefrigerablePlatoDALTest
    {
        public static void findAllTest()
        {
            RefrigerablePlatoDAL dal = new RefrigerablePlatoDAL();
            List<RefrigerablePlatoBO> lista = dal.findAll();

            foreach (var item in lista)
                Debug.WriteLine($"Codigo: {item.codigo} - Nombre: {item.nombre}");
        }

        public static void addTest()
        {
            RefrigerablePlatoDAL dal = new RefrigerablePlatoDAL();
            RefrigerablePlatoBO obj = new RefrigerablePlatoBO
            {
                nombre = "Congelado",
                estado = true
            };
            Debug.WriteLine(dal.add(obj) ? "Registro OK" : "Error");
        }
    }
}
