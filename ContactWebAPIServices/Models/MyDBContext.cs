using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ContactWebAPIServices.Models
{
    /// <summary>
    /// Context - This class interact with databse and has table entities to access table data.
    /// </summary>
    public class MyDBContext:DbContext
    {
        public MyDBContext(): base(WebConfigManager.GetConnectionString("MyDBContext"))//("MyDBContext")
        {
        }
        public DbSet<ContactTableModel> idtbContactTableModel { get; set; }
        public DbSet<SYSCodeTableModel> idtbStatusTableModel { get; set; }

    }

}
