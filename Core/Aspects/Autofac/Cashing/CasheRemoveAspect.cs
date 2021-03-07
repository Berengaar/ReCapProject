using Core.CrossCuttingConcerns.Cashing;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;

namespace Core.Aspects.Autofac.Cashing
{
    public class CasheRemoveAspect:MethodInterception
    {
        private string _pattern;
        private ICasheManager _casheManager;

        public CasheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _casheManager = ServiceTool.ServiceProvider.GetService<ICasheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _casheManager.RemoveByPattern(_pattern);
        }

       
    }
}
