using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVCPractice.Models
{   
	public  class VW_客戶摘要資訊Repository : EFRepository<VW_客戶摘要資訊>, IVW_客戶摘要資訊Repository
	{

	}

	public  interface IVW_客戶摘要資訊Repository : IRepository<VW_客戶摘要資訊>
	{

	}
}