
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
        /// 类别标签
        /// </summary>
        /// <returns></returns>
        [DisplayName("类别标签")]
        public string CategoryTags { get; set; }
        /// <summary>
        /// 关键字标签
        /// </summary>
        /// <returns></returns>
        [DisplayName("关键字标签")]
        public string KeywordTags { get; set; }
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
        /// 封面图
        /// </summary>
        /// <returns></returns>
        [DisplayName("封面图")]
        public string ImgUrl { get; set; }
        /// <summary>
        /// 星级
        /// </summary>
        /// <returns></returns>
        [DisplayName("星级")]
        public int? Star { get; set; }
        /// <summary>
        /// 1-正常,0-待审核,-1-已删除
        /// </summary>
        /// <returns></returns>
        [DisplayName("1-正常,0-待审核,-1-已删除")]
        public int? Status { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        /// <returns></returns>
        [DisplayName("排序")]
        public int? Sort { get; set; }
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
        /// <summary>
        /// 评语
        /// </summary>
        /// <returns></returns>
        [DisplayName("评语")]
        public string Comment { get; set; }
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