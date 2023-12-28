
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Dto.Oqc;
using My_Smart_Factory.Data.Service.Interface;
using My_Smart_Factory.Data.Vo;
using My_Smart_Factory.Models;

namespace My_Smart_Factory.Data.Service
{
    public class OqcService : EntityBaseRepository<OqcModel>, IOqcService
    {
        private readonly UserManager<UserIdentity> _userManager;
        public OqcService(MyDbContext context,
            UserManager<UserIdentity> userManager) : base(context)
        {
            _userManager = userManager;
        }

        private async Task<OqcModel?> Create(OqcDto requestDto, UserIdentity inspector, UserIdentity confirmor)
        {
            try
            {
                OqcModel model = new OqcModel();
                model = InputData(model, requestDto, inspector, confirmor);
                return model;
            }
            catch (System.Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return null;
            }
            
        }

        private async Task<OqcModel?> Update(OqcDto requestDto, OqcModel oqc, UserIdentity inspector, UserIdentity confirmor)
        {
            try
            {
                oqc = InputData(oqc, requestDto, inspector, confirmor);
                return oqc;
            }
            catch (System.Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                return null;
            }
            

        }
        public OqcModel InputData(OqcModel model, OqcDto requestDto, UserIdentity inspector, UserIdentity confirmor)
        {
            model.Inspector = inspector;
            model.Confirmor = confirmor;
            model.Controlnumber = requestDto.controlnumber;
            model.ProcessName = requestDto.processName;
            model.InspectionTime = requestDto.inspectionTime;
            model.InspectionResult = requestDto.inspectionResult;
            model.CapacityDefect = requestDto.capacityDefect;
            model.LossDefect = requestDto.lossDefect;
            model.BubbleDefect = requestDto.bubbleDefect;
            model.CenterDefect = requestDto.centerDefect;
            model.InnerDiameterDefect = requestDto.innerDiameterDefect;
            model.MarkDefect = requestDto.markDefect;
            model.CaseDefect = requestDto.caseDefect;
            model.EpoxyDefect = requestDto.epoxyDefect;
            model.EtcDefect = requestDto.etcDefect;
            model.EtcInfo = requestDto.etcInfo;
            return model;
        }


        private async Task<List<OqcVo>?> Read(List<OqcModel> oqcList, UserIdentity inspector, UserIdentity confirmor)
        {
            try
            {
                // dbcontext에서 해당 관리번호의 데이터와 Inspector, Confirmor 가져오는데 InspectionTime기준으로 내림차순정렬해서 모두 가져온다
                List<OqcVo> oqcVos = new List<OqcVo>();
                foreach (var oqc in oqcList)
                {
                    oqcVos.Add(CreateOqcVo(oqc));
                }
                return oqcVos;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }                
        }
        
        private async Task<OqcModel?> CreateDefultModel(string controlnumber, UserIdentity inspector, UserIdentity confirmor)
        {
            try
            {
                // 신규데이터 입력
                OqcModel model = new OqcModel();
                model.Controlnumber = controlnumber;
                model.Inspector = inspector;
                model.Confirmor = confirmor;
                model.InspectionTime = DateTime.Now;
                return model;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }


        private OqcVo CreateOqcVo(OqcModel oqc)
        {
            OqcVo oqcVo = new OqcVo();
            oqcVo.oqcId = oqc.Id;
            oqcVo.inspector = oqc.Inspector.UserName;
            oqcVo.confirmor = oqc.Confirmor.UserName;
            oqcVo.controlnumber = oqc.Controlnumber;
            oqcVo.processName = oqc.ProcessName;
            oqcVo.inspectionTime = oqc.InspectionTime.ToString("yyyy-MM-dd");
            oqcVo.inspectionResult = oqc.InspectionResult;
            oqcVo.capacityDefect = oqc.CapacityDefect;
            oqcVo.lossDefect = oqc.LossDefect;
            oqcVo.bubbleDefect = oqc.BubbleDefect;
            oqcVo.centerDefect = oqc.CenterDefect;
            oqcVo.innerDiameterDefect = oqc.InnerDiameterDefect;
            oqcVo.markDefect = oqc.MarkDefect;
            oqcVo.caseDefect = oqc.CaseDefect;
            oqcVo.epoxyDefect = oqc.EpoxyDefect;
            oqcVo.etcDefect = oqc.EtcDefect;
            oqcVo.etcInfo = oqc.EtcInfo;
            return oqcVo;
        }
        Task<OqcModel?> IOqcService.Create(OqcDto requestDto, UserIdentity inspector, UserIdentity confirmor)
        {
            return Create(requestDto, inspector, confirmor);
        }

        Task<OqcModel?> IOqcService.Update(OqcDto requestDto, OqcModel oqc, UserIdentity inspector, UserIdentity confirmor)
        {
            return Update(requestDto, oqc, inspector, confirmor);
        }

        Task<OqcModel?> IOqcService.CreateDefultModel(string controlnumber, UserIdentity inspector, UserIdentity confirmor)
        {
            return CreateDefultModel(controlnumber, inspector, confirmor);
        }

        Task<List<OqcVo>?> IOqcService.Read(List<OqcModel> oqcList, UserIdentity inspector, UserIdentity confirmor)
        {
            return Read(oqcList, inspector, confirmor);
        }

        OqcVo IOqcService.CreateOqcVo(OqcModel oqc)
        {
            return CreateOqcVo(oqc);
        }
    }
}
