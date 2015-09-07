using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero.Utility;

namespace Zero.Web.Controllers
{
    public class LoginController : Controller
    {

        /// <summary>
        /// 调试日志
        /// </summary>
        public static Zero.Utility.LogHelper log = Zero.Utility.LogFactory.GetLogger("LoginController");


        public ActionResult Default()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="Account">账户</param>
        /// <param name="Password">密码</param>
        /// <returns></returns>
        public ActionResult CheckLogin(string Account, string Password, string Token)
        {
            string Msg = "";
            try
            {
                IPScanerHelper objScan = new IPScanerHelper();
                string IPAddress = NetHelper.GetIPAddress();
                objScan.IP = IPAddress;
                objScan.DataPath = Server.MapPath("~/Resource/IPScaner/QQWry.Dat");
                string IPAddressName = objScan.IPLocation();
                string outmsg = "";
                //VerifyIPAddress(Account, IPAddress, IPAddressName, Token);
                //系统管理
                if (Account == ConfigHelper.AppSettings("CurrentUserName"))
                {
                    if (ConfigHelper.AppSettings("CurrentPassword") == Password)
                    {
                        IManageUser imanageuser = new IManageUser();
                        imanageuser.UserId = "System";
                        imanageuser.Account = "System";
                        imanageuser.UserName = "超级管理员";
                        imanageuser.Gender = "男";
                        imanageuser.Code = "System";
                        imanageuser.LogTime = DateTime.Now;
                        imanageuser.CompanyId = "系统";
                        imanageuser.DepartmentId = "系统";
                        imanageuser.IPAddress = IPAddress;
                        imanageuser.IPAddressName = IPAddressName;
                        imanageuser.IsSystem = true;
                        ManageProvider.Provider.AddCurrent(imanageuser);
                        //对在线人数全局变量进行加1处理
                        HttpContext rq = System.Web.HttpContext.Current;
                        rq.Application["OnLineCount"] = (int)rq.Application["OnLineCount"] + 1;
                        Msg = "3";//验证成功
                        //Base_SysLogBll.Instance.WriteLog(Account, OperationType.Login, "1", "登陆成功、IP所在城市：" + IPAddressName);
                    }
                    else
                    {
                        return Content("4");
                    }
                }
                else
                {
                    //Base_User base_user = base_userbll.UserLogin(Account, Password, out outmsg);
                    //switch (outmsg)
                    //{
                    //    case "-1":      //账户不存在
                    //        Msg = "-1";
                    //        Base_SysLogBll.Instance.WriteLog(Account, OperationType.Login, "-1", "账户不存在、IP所在城市：" + IPAddressName);
                    //        break;
                    //    case "lock":    //账户锁定
                    //        Msg = "2";
                    //        Base_SysLogBll.Instance.WriteLog(Account, OperationType.Login, "-1", "账户锁定、IP所在城市：" + IPAddressName);
                    //        break;
                    //    case "error":   //密码错误
                    //        Msg = "4";
                    //        Base_SysLogBll.Instance.WriteLog(Account, OperationType.Login, "-1", "密码错误、IP所在城市：" + IPAddressName);
                    //        break;
                    //    case "succeed": //验证成功
                    //        IManageUser imanageuser = new IManageUser();
                    //        imanageuser.UserId = base_user.UserId;
                    //        imanageuser.Account = base_user.Account;
                    //        imanageuser.UserName = base_user.RealName;
                    //        imanageuser.Gender = base_user.Gender;
                    //        imanageuser.Password = base_user.Password;
                    //        imanageuser.Code = base_user.Code;
                    //        imanageuser.Secretkey = base_user.Secretkey;
                    //        imanageuser.LogTime = DateTime.Now;
                    //        imanageuser.CompanyId = base_user.CompanyId;
                    //        imanageuser.DepartmentId = base_user.DepartmentId;
                    //        imanageuser.ObjectId = base_objectuserrelationbll.GetObjectId(imanageuser.UserId);
                    //        imanageuser.IPAddress = IPAddress;
                    //        imanageuser.IPAddressName = IPAddressName;
                    //        imanageuser.IsSystem = false;
                    //        ManageProvider.Provider.AddCurrent(imanageuser);
                    //        //对在线人数全局变量进行加1处理
                    //        HttpContext rq = System.Web.HttpContext.Current;
                    //        rq.Application["OnLineCount"] = (int)rq.Application["OnLineCount"] + 1;
                    //        Msg = "3";//验证成功
                    //        Base_SysLogBll.Instance.WriteLog(Account, OperationType.Login, "1", "登陆成功、IP所在城市：" + IPAddressName);
                    //        break;
                    //    default:
                    //        break;
                    //}
                }
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
            }
            return Content(Msg);
        }
    }
}
