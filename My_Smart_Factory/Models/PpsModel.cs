﻿using My_Smart_Factory.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Smart_Factory.Models
{
    public class PpsModel : IEntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime? Date { get; set; }                 // 작업 날짜
        public int Quantity { get; set; }                   // 수량
        public string? OperatorName { get; set; }           // 작업자
        public int DefectiveQuantity { get; set; }          // 불량수량

        public virtual PiModel ControlNumber { get; set; }  // 관리번호






    }
}
