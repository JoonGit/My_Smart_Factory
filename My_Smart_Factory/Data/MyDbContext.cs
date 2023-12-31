using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using My_Smart_Factory.Models;

namespace My_Smart_Factory.Data
{
    public class MyDbContext : IdentityDbContext<IdentityUser>
    {
        public MyDbContext(DbContextOptions<MyDbContext> option) : base(option)
        {
        }
        public DbSet<UserIdentity> UserIdentitys { get; set; }
        public DbSet<OutgoingInspModel> OutgoingInspModels { get; set; }
        public DbSet<ProdInfoModel> ProdInfoModels { get; set; }
        public DbSet<ProcessStatusModel> ProcessStatusModels { get; set; }

        public DbSet<InspEquipModel> InspEquipModels { get; set; }      // 검사장비
        public DbSet<ProdCtrlNoModel> ProdCtrlNoModels { get; set;}     // 관리번호
        public DbSet<CaseLotModel> CaseLotModels { get; set;}           // 케이스 로트
        public DbSet<SpecModel> SpecModels { get; set;}         // 스펙
        public DbSet<InspEquipRecordModel> InspEquipRecordModels { get; set; }           // 검사장비 기록
        public DbSet<ProdInspectionRecordModel> ProdInspectionRecords { get; set;}           // 상품장비 기록
        public DbSet<FullInspectionModel> FullInspectionRecords { get; set; }           // 전수검사
        public DbSet<WorkOrderModel> WorkOrderModels { get; set; }           // 작업지시

    }
}
