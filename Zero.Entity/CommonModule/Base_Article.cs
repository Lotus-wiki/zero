//=====================================================================================
// All Rights Reserved , Copyright @ ABC 2015
// Software Developers @ ABC 2015
//=====================================================================================

using Zero.DataAccess.Attributes;
using Zero.Utility;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Zero.Entity
{
    /// <summary>
    /// 文章表
    /// <author>
    ///		<name>abc</name>
    ///		<date>2015.09.09 14:50</date>
    /// </author>
    /// </summary>
    [Description("文章表")]
    [PrimaryKey("ArticleId")]
    public class Base_Article : BaseEntity
    {
        #region 获取/设置 字段值
        /// <summary>
        /// 自增ID
        /// </summary>
        /// <returns></returns>
        [DisplayName("自增ID")]
        public int? ArticleId { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        /// <returns></returns>
        [DisplayName("标题")]
        public string Title { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        /// <returns></returns>
        [DisplayName("作者")]
        public string Author { get; set; }
        /// <summary>
        /// 详细内容
        /// </summary>
        /// <returns></returns>
        [DisplayName("详细内容")]
        public string Content { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        /// <returns></returns>
        [DisplayName("添加时间")]
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 创建人ID
        /// </summary>
        /// <returns></returns>
        [DisplayName("创建人ID")]
        public string CreateUserId { get; set; }
        /// <summary>
        /// 创建人名称
        /// </summary>
        /// <returns></returns>
        [DisplayName("创建人名称")]
        public string CreateUserName { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            //this.ArticleId = CommonHelper.GetGuid;
            this.CreateDate = DateTime.Now;
            this.CreateUserId = ManageProvider.Provider.Current().UserId;
            this.CreateUserName = ManageProvider.Provider.Current().UserName;
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="KeyValue"></param>
        public override void Modify(string KeyValue)
        {
            this.ArticleId = int.Parse(KeyValue);
        }
        #endregion
    }
}