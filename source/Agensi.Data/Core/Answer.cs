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
    
    public partial class Answer
    {
        public long AnswerId { get; set; }
        public long QueryId { get; set; }
        public string AnswerUserId { get; set; }
        public long LanguageId { get; set; }
        public string Text { get; set; }
        public System.DateTime AnswerDate { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public Nullable<long> ParentAnswerId { get; set; }
    }
}
