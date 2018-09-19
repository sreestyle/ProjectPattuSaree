using PattuSaree.Data.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PattuSaree.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private PattuSareeContext _dbContext;

        public PattuSareeContext Init()
        {
            return _dbContext ?? (_dbContext = new PattuSareeContext());
            //var tt = new RockRiverContext();
            // return tt;
        }
        protected override void DisposeCore()
        {
            _dbContext?.Dispose();
        }
    }
}
