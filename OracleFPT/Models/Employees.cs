using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OracleFPT.Models
{
    public class Employees
    {
            [Display(Name ="Mã nhân viên")]
            public int NHANVIEN_ID { get; set; }
            [Display(Name ="Tên nhân viên")]
            public string NAME { get; set; }
            [Display(Name ="Địa chỉ")]
            public string ADDRESS { get; set; }
            [Display(Name ="Số điện thoại")]
            public string PHONE { get; set; }
            [Display(Name ="Phòng ban")]
            public Nullable<int> PHONGBAN_ID { get; set; }
            [Display(Name ="Ngày tham gia")]
            public Nullable<System.DateTime> CREATE_DATE { get; set; }        
    }
}