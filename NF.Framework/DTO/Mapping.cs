using AutoMapper;
using NF.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NF.Framework.DTO
{
    public class MAPPING
    {
        public MAPPING()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TS_USER, TS_USERDTO>().ReverseMap();
                cfg.CreateMap<TS_MENU, TS_MENUDTO>().ReverseMap();
                cfg.CreateMap<TS_DIC, TS_DICDTO>().ReverseMap();
                cfg.CreateMap<TMB_AREAPLAN, TMB_AREAPLANDTO>().ReverseMap();
                cfg.CreateMap<TMB_COMDIFF, TMB_COMDIFFDTO>().ReverseMap();
                cfg.CreateMap<TMB_FLOWINFO, TMB_FLOWINFODTO>().ReverseMap();
                cfg.CreateMap<TS_DEPT, TS_DEPTDTO>().ReverseMap();
                cfg.CreateMap<TS_CUSTFILE, TS_CUSTFILEDTO>().ReverseMap();
                cfg.CreateMap<TS_CUSTADDR, TS_CUSTADDRDTO>().ReverseMap();
                cfg.CreateMap<TMO_ORDER, TMO_CONDETAILSDTO>().ReverseMap();
                cfg.CreateMap<TMP_PLAN, TMP_PLANDTO>().ReverseMap();
                cfg.CreateMap<TMD_DISPATCH, TMD_DISPATCHDTO>().ReverseMap();
                cfg.CreateMap<TMD_DISPATCH_MAIN_LOG, TMD_DISPATCHDTO>().ReverseMap();
                cfg.CreateMap<TMD_DISPATCHDETAILS, TMD_DISPATCHDETAILSDTO>().ReverseMap();
                cfg.CreateMap<TMD_DISPATCHDETAILS_MAIN_LOG, TMD_DISPATCHDETAILSDTO>().ReverseMap();
                cfg.CreateMap<TMQ_QUALITY_MAIN, TMQ_QUALITY_MAINDTO>().ReverseMap();
                cfg.CreateMap<TMQ_QUALITY_STL_GRD, TMQ_QUALITY_STL_GRDDTO>().ReverseMap();
                cfg.CreateMap<TMQ_QUALITY_MAIN_LOG, TMQ_QUALITY_MAIN_LOGDTO>().ReverseMap();
                cfg.CreateMap<TMC_CUST_REPORT, TMC_CUST_REPORTDTO>().ReverseMap();
                cfg.CreateMap<TMC_EVAL_ITEM, TMC_EVAL_ITEMDTO>().ReverseMap();
                cfg.CreateMap<TMC_CUST_EVAL_SUB, TMC_CUST_EVAL_SUBDTO>().ReverseMap();
                cfg.CreateMap<TMC_CUST_EVAL, TMC_CUST_EVALDTO>().ReverseMap();
                cfg.CreateMap<TS_FUNCTION, TS_FUNCTIONDTO>().ReverseMap();
                cfg.CreateMap<TS_CUSTOTCOMPANY, TS_CUSTOTCOMPANYDTO>().ReverseMap();
                cfg.CreateMap<TS_ROLE, TS_ROLEDTO>().ReverseMap();
                cfg.CreateMap<TRC_ROLL_PRODCUT, TRC_ROLL_PRODCUTDTO>().ReverseMap();
                cfg.CreateMap<TMD_DISPATCH_LOG, TMD_DISPATCH_LOGDTO>().ReverseMap();
                cfg.CreateMap<TSC_SLAB_MAIN, TSC_SLAB_MAINDTO>().ReverseMap();
                cfg.CreateMap<TMQ_QUALITY_FILE, TMQ_QUALITY_FILEDTO>().ReverseMap();
                cfg.CreateMap<TS_BUTTON, TS_BUTTONDTO>().ReverseMap();
                cfg.CreateMap<AppTmcCustEval, TMC_CUST_EVALDTO>().ReverseMap();
                cfg.CreateMap<AppTmcCustEvalSub, TMC_CUST_EVAL_SUBDTO>().ReverseMap();
                cfg.CreateMap<AppEvalItem, TMC_EVAL_ITEMDTO>().ReverseMap();
                cfg.CreateMap<AppTmcCustEval, TMC_CUST_EVAL>().ReverseMap();
                cfg.CreateMap<AppTmcCustEvalSub, TMC_CUST_EVAL_SUB>().ReverseMap();
                cfg.CreateMap<AppEvalItem, TMC_EVAL_ITEM>().ReverseMap();
                cfg.CreateMap<TMQ_QUALITY_MAIN, AppQuality>().ReverseMap();
            });
        }

        /// <summary>
        /// 转换Entity到Dto集合
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TDTO"></typeparam>
        /// <returns></returns>
        public static List<TDdo> ConvertEntityToDtoList<TEntity, TDdo>(List<TEntity> entitys) where TEntity : class
        {
            List<TDdo> dtos = new List<TDdo>();
            int count = entitys.Count;
            for (int i = 0; i < count; i++)
            {
                dtos.Add(Mapper.Map<TDdo>(entitys[i]));
            }
            return dtos;
        }

        /// <summary>
        /// 转换Dto到Entity
        /// </summary>
        /// <typeparam name="TDTO"></typeparam>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public static List<TEntity> ConvertDtoToEntityList<TDdo, TEntity>(List<TDdo> entitys) where TDdo : class
        {
            List<TEntity> dtos = new List<TEntity>();
            int count = entitys.Count;
            for (int i = 0; i < count; i++)
            {
                dtos.Add(Mapper.Map<TEntity>(entitys[i]));
            }
            return dtos;
        }

        /// <summary>
        /// 前台菜单格式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="t"></param>
        /// <param name="tt"></param>
        /// <returns></returns>
        public static List<MENUDTO> ConvertMenu(List<TS_MENUDTO> old)
        {
            List<MENUDTO> newDtos = new List<MENUDTO>();
            if (old.Count > 0)
            {
                foreach (var o in old)
                {
                    MENUDTO newDto = new MENUDTO();
                    newDto.id = o.C_ID;
                    newDto.text = o.C_NAME;
                    newDto.url = o.C_URL;
                    newDto.icon = o.C_ICON;
                    newDtos.Add(newDto);
                    if (o.Menus.Count > 0)
                    {
                        Factorial(o.Menus, newDto.menus);
                    }
                }
            }
            return newDtos;
        }

        public static void Factorial(List<TS_MENUDTO> dtos, List<MENUDTO> newDtos)
        {
            foreach (var o in dtos)
            {
                MENUDTO newDto = new MENUDTO();
                newDto.id = o.C_ID;
                newDto.text = o.C_NAME;
                newDto.url = o.C_URL;
                newDto.icon = o.C_ICON;
                newDtos.Add(newDto);
                if (o.Menus.Count > 0)
                {
                    Factorial(o.Menus, newDto.menus);
                }
            }
        }



        /// <summary>
        /// 部门列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="t"></param>
        /// <param name="tt"></param>
        /// <returns></returns>
        public static List<DEPTDTO> ConvertDept(List<TS_DEPTDTO> old)
        {
            List<DEPTDTO> newDtos = new List<DEPTDTO>();
            if (old.Count > 0)
            {
                foreach (var o in old)
                {
                    DEPTDTO newDto = new DEPTDTO();
                    newDto.id = o.C_ID;
                    newDto.text = o.C_NAME;
                    newDtos.Add(newDto);
                    if (o.Depts.Count > 0)
                    {
                        Factorial(o.Depts, newDto.nodes);
                    }
                }
            }
            return newDtos;
        }


        public static void Factorial(List<TS_DEPTDTO> dtos, List<DEPTDTO> newDtos)
        {
            foreach (var o in dtos)
            {
                DEPTDTO newDto = new DEPTDTO();
                newDto.id = o.C_ID;
                newDto.text = o.C_NAME;
                newDtos.Add(newDto);
                if (o.Depts.Count > 0)
                {
                    Factorial(o.Depts, newDto.nodes);
                }
            }
        }


    }
}
