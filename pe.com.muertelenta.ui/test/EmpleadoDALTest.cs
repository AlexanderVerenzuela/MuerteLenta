using pe.com.muertelenta.bo;
using pe.com.muertelenta.dal;
using System.Diagnostics;

namespace pe.com.muertelenta.ui.test
{
    public class EmpleadoDALTest
    {
        public static void addTest()
        {
            EmpleadoDAL dal = new EmpleadoDAL();
            EmpleadoBO obj = new EmpleadoBO
            {
                NomEmp = "Juan",
                ApeEmp = "Perez",
                NumDocEmp = "12345678",
                CodRol = 1,
                CodTipDoc = 1,
                CodSex = 1,
                CodDis = 1,
                EstEmp = true
            };
            Debug.WriteLine(dal.add(obj) ? "Empleado Registrado" : "Error");
        }
    }
}
