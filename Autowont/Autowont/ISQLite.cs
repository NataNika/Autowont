using System;
using SQLite;

namespace Autowont
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
