namespace MVCPractice.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    [MetadataType(typeof(客戶聯絡人MetaData))]
    public partial class 客戶聯絡人 : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            using (var db = new 客戶資料Entities())
            {
                var all = db.客戶聯絡人.AsQueryable();

                int intCount = 0;
                if (this.Id == 0)
                {
                    var result = from c in all
                                 where c.是否已刪除 == false
                                    & c.Email.ToLower() == this.Email.ToLower()
                                    & c.客戶Id == this.客戶Id
                                 select c;
                    intCount = result.Count();
                }
                else
                {
                    //修改比對要排除目前編輯的這筆資料
                    var result = from c in all
                                 where c.是否已刪除 == false
                                    & c.Email.ToLower() == this.Email.ToLower()
                                    & c.客戶Id == this.客戶Id
                                    & c.Id != this.Id
                                 select c;
                    intCount = result.Count();
                }
                if (intCount > 0)
                {
                    yield return new ValidationResult("同一客戶的客戶聯絡人Email不可重複",
                    new string[] { "Email" });
                }
            }
            yield return ValidationResult.Success;
        }
    }
    
    public partial class 客戶聯絡人MetaData
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int 客戶Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 職稱 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 姓名 { get; set; }
        
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [RegularExpression(@"\d{4}-\d{6}", ErrorMessage = "手機格式錯誤，請輸入以下格式(09XX-XXXXXX)")]
        public string 手機 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 電話 { get; set; }
        [Required]
        public bool 是否已刪除 { get; set; }
    
        public virtual 客戶資料 客戶資料 { get; set; }
    }
}
