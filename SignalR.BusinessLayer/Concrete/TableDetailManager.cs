using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class TableDetailManager : ITableDetailService
    {
        private readonly ITableDetailDal _tableDetailDal;

        public TableDetailManager(ITableDetailDal tableDetailDal)
        {
            _tableDetailDal = tableDetailDal;
        }

        public void TAdd(TableDetail entity)
        {
            _tableDetailDal.Add(entity);
        }

        public void TDelete(TableDetail entity)
        {
            _tableDetailDal.Delete(entity);
        }

        public TableDetail TGetByID(int id)
        {
            return _tableDetailDal.GetByID(id);
        }

        public List<TableDetail> TGetListAll()
        {
            return _tableDetailDal.GetListAll();
        }

        public int TTableCount()
        {
            return _tableDetailDal.TableCount();
        }

        public void TUpdate(TableDetail entity)
        {
            _tableDetailDal.Update(entity);
        }
    }
}
