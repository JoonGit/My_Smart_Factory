namespace My_Smart_Factory.Data.Dto.Pi
{
    public class PiDto
    {
        public int id { get; set; }
        public string? controlNumber { get; set; }       // 관리번호
        public string? specification { get; set; }      // 스펙
        public string? lotNumber { get; set; }          // 로트번호
    }
}
