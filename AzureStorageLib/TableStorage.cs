using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureStorageLib
{
    public class TableStorage
    {
        
        public TableStorage()
        {}

        /// <summary>
        /// returns the cloud storage account if project config is in Release mode else will return development storage account details.
        /// </summary>
        /// <returns></returns>
        protected CloudStorageAccount StorageAccount()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(IsDebug() ? RoleEnvironment.GetConfigurationSettingValue("LocalStorage") :
                RoleEnvironment.GetConfigurationSettingValue("AzureStorageAccount"));
            return storageAccount;
        }

        protected bool IsDebug()
        {
            bool isDebug=false;
            #if DEBUG
                        isDebug=true;
            #endif
            return isDebug;
        }

        public void AzureTableQuery()
        {
            EmployeeEntity empEntity = new EmployeeEntity(1,"Name  1",54321.456);
            TableOperation storageTblQuery = TableOperation.Insert(empEntity);
            CloudTableClient tableClient = StorageAccount().CreateCloudTableClient();
            CloudTable storageTable = tableClient.GetTableReference("DevTest");
            storageTable.CreateIfNotExists();
            storageTable.Execute(storageTblQuery);                        
        }

        public void AzureTableRetriveQuery()
        {
            CloudTableClient tableClient = StorageAccount().CreateCloudTableClient();
            CloudTable storageTable = tableClient.GetTableReference("DevTest");
            EmployeeEntity empEntity = new EmployeeEntity();
            TableOperation tableOperation = TableOperation.Retrieve<EmployeeEntity>("1", "Name 1");

            TableResult tableResult = storageTable.Execute(tableOperation);
            empEntity=tableResult.Result as EmployeeEntity; 
        }
    }
}
