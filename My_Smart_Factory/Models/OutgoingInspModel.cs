using My_Smart_Factory.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Smart_Factory.Models
{
    public class OutgoingInspModel : IEntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
        [Required]
        public string? Controlnumber { get; set; }       // 관리번호   
        public string? ProcessName { get; set; }      // 공정명 
        public DateTime InspectionTime { get; set; }    // 검사일시
        public int InspectionResult { get; set; } = 0;     // 검사수량

        public string? InspectorId { get; set; }           // 작업자
        public string? ConfirmorId { get; set; }           // 불량처리 확인자

        public int CapacityDefect { get; set; } = 0;        // 용량 불량 수량
        public int LossDefect { get; set; } = 0;           // 손실 불량 수량
        public int BubbleDefect { get; set; } = 0;         // 기포 불량 수량
        public int CenterDefect { get; set; } = 0;          // 센터 불량 수량
        public int InnerDiameterDefect { get; set; } = 0;   // 내경 불량 수량
        public int MarkDefect { get; set; } = 0;            // 마크 불량 수량
        public int CaseDefect { get; set; } = 0;           // 케이스 불량 수량
        public int EpoxyDefect { get; set; } = 0;           // 에폭시 불량 수량
        public int EtcDefect { get; set; } = 0;             // 기타 불량 수량
        public string? EtcInfo { get; set; }             // 기타 정보


        public virtual UserIdentity Inspector { get; set; }           // 작업자
        public virtual UserIdentity Confirmor { get; set; }           // 불량처리 확인자
    }
}
