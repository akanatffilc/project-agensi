using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Threading.Tasks
{
    public static class AgensiTaskEx
    {
        /// <summary>
        /// Taskを投げっぱなしにする場合は、これを呼ぶことでメインスレッドへの合流抑制と
        /// コンパイラの警告の抑制と、例外発生時のロギングを行う
        /// </summary>
        public static void FireAndForget(this Task task)
        {
            task.ConfigureAwait(false);
            task.ContinueWith(x =>
                Console.WriteLine("Error")
                , TaskContinuationOptions.OnlyOnFaulted);
        }
    }
}
