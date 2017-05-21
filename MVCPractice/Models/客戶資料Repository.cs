using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVCPractice.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public override void Delete(客戶資料 entity)
        {
            entity.是否已刪除 = true;
        }

        public 客戶資料 Find(int id)
        {
            return this.All().FirstOrDefault(c => c.Id == id);
        }

        public IQueryable<客戶資料> Get客戶資料(string txtKeyword, string type)
        {
            var result = this.Where(c => c.是否已刪除 == false).OrderByDescending(c => c.Id).AsQueryable();

            if (!String.IsNullOrEmpty(txtKeyword))
            {
                result = result.Where(c => c.客戶名稱.Contains(txtKeyword));
            }
            if (!String.IsNullOrEmpty(type))
            {
                result = result.Where(c => c.客戶分類 == type);
            }
            return result;
        }

    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}