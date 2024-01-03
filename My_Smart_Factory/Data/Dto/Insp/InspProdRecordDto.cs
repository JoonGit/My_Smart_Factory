﻿using My_Smart_Factory.Data.Vo.Insp;
using My_Smart_Factory.Migrations;
using My_Smart_Factory.Models.Insp;
using My_Smart_Factory.Models.Prod;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Smart_Factory.Data.Dto.Insp
{
    public class InspProdRecordDto
    {
        public int Id { get; set; }
        public string? InspSpecName { get; set; }                      // 장비명
        public string? ProdCtrlNo { get; set; }                         // 관리번호
        public DateTime? InspectionDateTime { get; set; }               // 검사 일시
        public decimal? MeasuredValue { get; set; }                      // 측정값

        //public virtual InspEquipModel? InspEquip { get; set; }      // 검사 장비
        //public virtual ProdCtrlNoModel? ProdCtrlNo { get; set; }    // 관리번호

        public InspProdRecordModel ToModel(InspSpecModel InspSpec, ProdCtrlNoModel ProdCtrlNo, decimal? Accuracy, bool IsPassed)
        {
            return new InspProdRecordModel
            {
                InspSpecModel = InspSpec,
                ProdCtrlNo = ProdCtrlNo,
                InspectionDateTime = InspectionDateTime,
                MeasuredValue = MeasuredValue,
                Accuracy = Accuracy,
                IsPassed = IsPassed
            };
        }
        
        public InspProdRecordVo ToVo(InspProdRecordModel InspProdRecord)
        {
            return new InspProdRecordVo
            {
                Id = InspProdRecord.Id,
                InspEquipName = InspProdRecord.InspSpecModel.InspEquip.InspEquipName,
                ProdCtrlNo = InspProdRecord.ProdCtrlNo.ProdCtrlNo,
                ProdName = InspProdRecord.ProdCtrlNo.ProdInfo.ProdName,
                InspectionDateTime = InspProdRecord.InspectionDateTime,
                MeasuredValue = InspProdRecord.MeasuredValue,
                Accuracy = InspProdRecord.Accuracy,
                Unit = InspProdRecord.InspSpecModel.InspEquip.Unit,
                IsPassed = InspProdRecord.IsPassed
            };
        }


    }
}
