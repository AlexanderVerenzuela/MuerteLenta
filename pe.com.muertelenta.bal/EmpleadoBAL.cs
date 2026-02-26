using pe.com.muertelenta.bo;
using pe.com.muertelenta.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.muertelenta.bal
{
    public class EmpleadoBAL
    {
        EmpleadoDAL dal = new EmpleadoDAL();
        public EmpleadoBO login(EmpleadoBO obj)
        {
            return dal.login(obj);
        }

    }
}

