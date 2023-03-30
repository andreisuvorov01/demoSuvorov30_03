using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StroyMaterial.DB
{
    public static class DbSingleTone
    {
        public static StroyEntities Db_S = new StroyEntities(); //сохранение статического экземпляра бд
    }
}
