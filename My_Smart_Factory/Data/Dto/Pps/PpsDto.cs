﻿using My_Smart_Factory.Models;

namespace My_Smart_Factory.Data.Dto.Pps
{
    public class PpsDto
    {
        public int id { get; set; }
        public virtual string? controlNumber { get; set; }  // 관리번호
        public DateTime? date { get; set; }                 // 작업 날짜
        public int quantity { get; set; }                   // 수량
        public string? operatorName { get; set; }           // 작업자
        public int defectiveQuantity { get; set; }          // 불량수량
    }
}
