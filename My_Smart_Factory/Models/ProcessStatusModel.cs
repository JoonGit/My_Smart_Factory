using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Models.Prod;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Smart_Factory.Models
{
    // 관리번호로 제품의 정보를 알아낸 후
    // 제품의 불량율을 계산하기 위한 클래스
    public class ProcessStatusModel : IEntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime? Date { get; set; }                         // 작업 날짜
        public int Quantity { get; set; }                           // 수량
        public UserIdentity Operator { get; set; }                  // 작업자
        public int DefectiveQuantity { get; set; }                  // 불량수량
        public virtual ProdInfoModel ProdInfoModel { get; set; }          // 관리번호
    }
}
