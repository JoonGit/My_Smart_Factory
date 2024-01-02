using My_Smart_Factory.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_Smart_Factory.Models.Prod
{
    // 관리번호
    // 제품별로 관리번호를 부여하여 관리
    // Product Control Number
    public class ProdCtrlNoModel : IEntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? ProdCtrlNo { get; set; }                         // 관리번호
        public virtual ProdInfoModel? ProdInfo { get; set; }        // 제품정보
    }
}
