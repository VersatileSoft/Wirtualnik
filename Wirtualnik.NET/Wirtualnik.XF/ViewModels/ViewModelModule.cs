﻿using DryIoc;
using Wirtualnik.XF.Services;

namespace Wirtualnik.XF.ViewModels
{
    public class ViewModelModule : IDryIocModule
    {
        public void Load(IRegistrator builder)
        {
            builder.Register<ProductListPageViewModel>();
        }
    }
}
