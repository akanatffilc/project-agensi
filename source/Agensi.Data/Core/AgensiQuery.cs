//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはテンプレートから生成されました。
//
//     このファイルを手動で変更すると、アプリケーションで予期しない動作が発生する可能性があります。
//     このファイルに対する手動の変更は、コードが再生成されると上書きされます。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Agensi.Data.Core
{
    using System;
    using System.Collections.Generic;
    
    public partial class AgensiQuery
    {
        public int QueryId { get; set; }
        public string OwnerUid { get; set; }
        public string Title { get; set; }
        public int TopicCategory { get; set; }
        public int MediaCategory { get; set; }
        public int LanguageId { get; set; }
        public string Text { get; set; }
        public System.DateTime QueryDate { get; set; }
        public string UpdateTime { get; set; }
    }
}
