using pe.com.muertelenta.bo;
using pe.com.muertelenta.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.muertelenta.bal
{
    public class OrdenBAL
    {
        OrdenDAL dal = new OrdenDAL();
        public List<OrdenBO> findAll()
        {
            return dal.findAll();
        }
    }
}
