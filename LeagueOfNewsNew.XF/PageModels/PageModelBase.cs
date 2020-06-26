﻿using System.Threading.Tasks;

namespace LeagueOfNewsNew.XF.PageModels
{
    public abstract class PageModelBase //: ObservableObject
    {
        /// <summary>
        /// Task called when page is appearing
        /// </summary>
        /// <returns></returns>
        public virtual Task OnLoad() => Task.CompletedTask;
    }

    public abstract class PageModelBase<T> : PageModelBase
    {
        /// <summary>
        /// Returns parameter of given type
        /// </summary>
        public T Param { get; set; }
    }
}