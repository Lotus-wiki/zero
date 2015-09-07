//=====================================================================================
// All Rights Reserved , Copyright @ Learun 2014
// Software Developers @ Learun 2014
//=====================================================================================

using Zero.DataAccess;
using Zero.Entity;
using Zero.Repository;
using Zero.Utility;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Zero.Business
{
    /// <summary>
    /// ʡ����
    /// <author>
    ///		<name>she</name>
    ///		<date>2014.08.06 15:51</date>
    /// </author>
    /// </summary>
    public class Base_ProvinceCityBll : RepositoryFactory<Base_ProvinceCity>
    {
        /// <summary>
        /// ��ȡʡ���С��� �б�
        /// </summary>
        /// <param name="ParentId"></param>
        /// <returns></returns>
        public List<Base_ProvinceCity> GetList(string ParentId)
        {
            StringBuilder WhereSql = new StringBuilder();
            WhereSql.Append(" AND ParentId = @ParentId Order By SortCode ASC");
            List<DbParameter> parameter = new List<DbParameter>();
            parameter.Add(DbFactory.CreateDbParameter("@ParentId", ParentId));
            return this.Repository().FindList(WhereSql.ToString(), parameter.ToArray());
        }
    }
}