using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureStorageLib
{
   public class EmployeeEntity:TableEntity
    {
       
       public EmployeeEntity() { }

       public EmployeeEntity(int empID, string empName)
       {
           this.PartitionKey = empID.ToString();
           this.RowKey = empName;
       }

       public int empID { get; set; }
       public string empName { get; set; }
       public double empSalary { get; set; }
       
    }
}
