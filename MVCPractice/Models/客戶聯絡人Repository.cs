using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVCPractice.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{
        public override void Delete(客戶聯絡人 entity)
        {
            entity.是否已刪除 = true;
        }

        public 客戶聯絡人 Find(int id)
        {
            return this.All().FirstOrDefault(c => c.Id == id);
        }
    }

	public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}