using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Ninject.Web;
using Ninject.Web.Common;
using bizapps_test.BLL.Services;
using bizapps_test.BLL.Interfaces;
using Ninject.Infrastructure.Disposal;
using System.Web.UI;

namespace bizapps_test.WEB.Tests.App_Start
{
    public class InjectPageModule : DisposableObject, IHttpModule
    {
       public InjectPageModule(Func<IKernel> lazyKernel)
    {
        this.lazyKernel = lazyKernel;
    }

    public void Init(HttpApplication context)
    {
        this.lazyKernel().Inject(context);
        context.PreRequestHandlerExecute += OnPreRequestHandlerExecute;
    }

    private void OnPreRequestHandlerExecute(object sender, EventArgs e)
    {
        var currentPage = HttpContext.Current.Handler as Page;
        if (currentPage != null)
        {
            currentPage.InitComplete += OnPageInitComplete;
        }
    }

    private void OnPageInitComplete(object sender, EventArgs e)
    {
        var currentPage = (Page)sender;
        this.lazyKernel().Inject(currentPage);
        this.lazyKernel().Inject(currentPage.Master);
        foreach (Control c in GetControlTree(currentPage))
        {
            this.lazyKernel().Inject(c);
        }

    }

    private IEnumerable<Control> GetControlTree(Control root)
    {
        foreach (Control child in root.Controls)
        {
            yield return child;
            foreach (Control c in GetControlTree(child))
            {
                yield return c;
            }
        }
    }

    private readonly Func<IKernel> lazyKernel;

    }
}