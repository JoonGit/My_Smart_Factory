﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using My_Smart_Factory.Models;
using My_Smart_Factory.Models.Insp;
using My_Smart_Factory.Models.Prod;
using My_Smart_Factory.Data.Vo.Insp;
using My_Smart_Factory.Data.Dto.Insp;

namespace My_Smart_Factory.Data
{
    public class MyDbContext : IdentityDbContext<UserIdentity>
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
        public DbSet<InspSpecModel> InspSpecModels { get; set;}         // 스펙
        public DbSet<InspEquipSettingRecordModel> InspEquipSettingRecordModels { get; set; }           // 검사장비 기록
        public DbSet<InspProdRecordModel> InspProdRecordModels { get; set;}           // 상품장비 기록
        public DbSet<FullInspRecordModel> FullInspRecordModels { get; set; }           // 전수검사
        public DbSet<WorkOrderModel> WorkOrderModels { get; set; }           // 작업지시
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<WorkOrderModel>()
                .HasOne(w => w.FullInspection)
                .WithOne(f => f.WorkOrder)
                .HasForeignKey<FullInspRecordModel>(f => f.Id);

            builder.Entity<IdentityUserLogin<string>>().HasKey(x => new { x.ProviderKey, x.LoginProvider });
        }
        //public DbSet<My_Smart_Factory.Data.Vo.Insp.InspProdRecordVo>? InspProdRecordVo { get; set; }
        //public DbSet<My_Smart_Factory.Data.Dto.Insp.InspProdRecordDto>? InspProdRecordDto { get; set; }
        //public DbSet<My_Smart_Factory.Models.QRCodeModel>? QRCodeModel { get; set; }
        //public DbSet<My_Smart_Factory.Data.Vo.Insp.InspEquipVo>? InspEquipVo { get; set; }
        //public DbSet<My_Smart_Factory.Data.Dto.Insp.InspEquipDto>? InspEquipDto { get; set; }
        //public DbSet<My_Smart_Factory.Data.Vo.Insp.InspEquipSettingRecordVo>? InspEquipSettingRecordVo { get; set; }
        //public DbSet<My_Smart_Factory.Data.Dto.Insp.InspEquipSettingRecordDto>? InspEquipSettingRecordDto { get; set; }
        //public DbSet<My_Smart_Factory.Data.Dto.Insp.InspSpecDto>? InspSpecDto { get; set; }
        //public DbSet<My_Smart_Factory.Data.Vo.Insp.InspSpecVo>? InspSpecVo { get; set; }
    }
}
