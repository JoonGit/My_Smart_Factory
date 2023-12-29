using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using My_Smart_Factory.Data.Base;
using My_Smart_Factory.Data.Service.Interface;
using My_Smart_Factory.Models;

namespace My_Smart_Factory.Data.Service
{
    public class PiService : EntityBaseRepository<PiModel>, IPiInterface
    {
        public PiService(MyDbContext context) : base(context)
        {
        }
    }
}
