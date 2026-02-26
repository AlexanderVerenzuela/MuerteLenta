using pe.com.muertelenta.bo;
using pe.com.muertelenta.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.muertelenta.bal
{
    public class RefrigerablePlatoBAL
    {
        //creamos un objeto de TipoPlatoDAL
        RefregirablePlatoDAL dal = new RefregirablePlatoDAL();

        //creamos funciones para las operaciones
        public List<RefrigerablePlatoBO> findAll()
        {
            return dal.findAll();
        }

        public List<RefrigerablePlatoBO> findAllCustom()
        {
            return dal.findAllCustom();
        }

        public bool add(RefrigerablePlatoBO obj)
        {
            return dal.add(obj);
        }
        public RefrigerablePlatoBO findById(int id)
        {
            return dal.findById(id);
        }
        public bool update(RefrigerablePlatoBO obj, int id)
        {
            return dal.update(obj, id);
        }

        public bool delete(int id)
        {
            return dal.delete(id);
        }

        public bool enable(int id)
        {
            return dal.enable(id);
        }

        public int setCode()
        {
            return dal.setCode();
        }
    }
}
