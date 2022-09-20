using Swift.BBS.Model.RootTKey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swift.BBS.Model.Models
{
    public class Images: RootEntityTkey<int>
    {   
        
        /// <summary>
        /// 图片地址
        /// </summary>
        public String ScanUrl { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime OverdueTime{ get; set; }

        /// <summary>
        /// 删除标志位
        /// </summary>
        public int DeleteFlag { get; set; }

        /// <summary>
        /// 图片名字
        /// </summary>
        public String ScanName { get; set; }

        /// <summary>
        /// 图片类型
        /// </summary>
        public String ScanType { get; set; }

        /// <summary>
        /// 图片类型
        /// </summary>
        public String ScanPic { get; set; }
    }
}
