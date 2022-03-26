using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAEmployeeManager
{
    public class DBManager : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public bool AddDepartment(string name, string description)
        {
            try
            {
                using (var dbMgr = new DBManager())
                {                    
                    dbMgr.Add(new Department()
                    {
                        Name = name,
                        Description = description
                    });

                    dbMgr.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                //TODO log exception
                throw;
            }
        }
    }
}
