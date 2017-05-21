using System;
using System.Linq;
using System.Collections.Generic;
using MVCPractice.Models.ViewModels;

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

        public IQueryable<客戶資料> Get客戶資料(客戶資料篩選條件ViewModel filte)
        {
            var result = this.Where(c => c.是否已刪除 == false).OrderByDescending(c => c.Id).AsQueryable();

            if (!String.IsNullOrEmpty(filte.keyword))
            {
                result = result.Where(c => c.客戶名稱.Contains(filte.keyword));
            }
            if (!String.IsNullOrEmpty(filte.type))
            {
                result = result.Where(c => c.客戶分類 == filte.type);
            }
            return result;
        }

    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}