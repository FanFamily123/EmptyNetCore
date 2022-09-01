using System;

namespace Swift.BBS.Model.RootTKey
{
    public class RootEntityTkey<Tkey> where Tkey : IEquatable<Tkey>
    {
        /// <summary>
        /// ID
        /// 泛型主键Tkey
        /// </summary>
        public Tkey Id { get; set; }


    }
}