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
       private int _empID;
       private string _empName;
       private double _empSalary;

       public EmployeeEntity() { }

       public EmployeeEntity(int empID, string empName, double empSalary)
       {
           _empID = empID;
           _empName = empName;
           _empSalary = empSalary;
           PartitionKey = empID.ToString();
           RowKey = empName;
       }


    }
}
