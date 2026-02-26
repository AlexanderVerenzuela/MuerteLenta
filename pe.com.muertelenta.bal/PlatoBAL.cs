using pe.com.muertelenta.bo;
using pe.com.muertelenta.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.muertelenta.bal
{
    public class PlatoBAL
    {
        PlatoDAL dal = new PlatoDAL();

        public List<PlatoBO> findAll()
        {
            return dal.findAll();
        }

        public List<PlatoBO> findAllCustom()
        {
            return dal.findAllCustom();
        }

        public bool add(PlatoBO obj)
        {
            return dal.add(obj);
        }
        public PlatoBO findById(int id)
        {
            return dal.findById(id);
        }
        public bool update(PlatoBO obj, int id)
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
