﻿using Surrender_20.Core.Interface;
using Surrender_20.Core.ViewModels;
using Surrender_20.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Surrender_20.Forms.ViewModels
{
    public class NewsfeedItemViewModel : NewsfeedItemRootViewModel
    {

        public string Content { get; set; }

        public override void Prepare(Newsfeed newsfeed)
        {

            base.Prepare(newsfeed);

            Content = ParseHtml();

            IsLoading = false;
        }

        private string ParseHtml()
        {
            //Parse html
            
            return _doc.DocumentNode.InnerHtml;
        }
    }
}
