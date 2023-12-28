namespace My_Smart_Factory.Data.Vo
{
    public class OqcVo
    {
        public int oqcId { get; set; }
        public string? controlnumber { get; set; }       // 관리번호   
        public string? processName { get; set; }         // 공정명 
        public string? inspectionTime { get; set; }    // 검사일시
        public int inspectionResult { get; set; }     // 검사수량
        public string? inspector { get; set; }           // 작업자
        public string? confirmor { get; set; }           // 불량처리 확인자

        public int capacityDefect { get; set; }        // 용량 불량 수량
        public int lossDefect { get; set; }            // 손실 불량 수량
        public int bubbleDefect { get; set; }          // 기포 불량 수량
        public int centerDefect { get; set; }           // 센터 불량 수량
        public int innerDiameterDefect { get; set; }  // 내경 불량 수량
        public int markDefect { get; set; }             // 마크 불량 수량
        public int caseDefect { get; set; }           // 케이스 불량 수량
        public int epoxyDefect { get; set; }            // 에폭시 불량 수량
        public int etcDefect { get; set; }             // 기타 불량 수량
        public string? etcInfo { get; set; }             // 기타 정보
    }
}
