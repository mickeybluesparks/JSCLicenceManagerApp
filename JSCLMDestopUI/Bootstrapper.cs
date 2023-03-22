using Caliburn.Micro;
using JSCLMDestopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlTypes;
using JSCLMDestopUI.Library.Api;
using System.Globalization;
using System.Windows.Markup;
using AutoMapper;
using JSCLMDestopUI.Models;
using JSCLMDestopUI.Library.Models;

namespace JSCLMDestopUI;

public class Bootstrapper : BootstrapperBase
{
    private SimpleContainer _container = new SimpleContainer();

    public Bootstrapper()
    {
        Initialize();

        FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement),
            new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(
                CultureInfo.CurrentCulture.IetfLanguageTag)));

    }

    private IMapper ConfigureAutomapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CustomerModel, CustomerDisplayModel>();
        });

        return config.CreateMapper();

    }

    protected override void OnStartup(object sender, StartupEventArgs e)
    {
        DisplayRootViewForAsync<MainViewModel>();
    }

    protected override void Configure()
    {
        _container.Instance(ConfigureAutomapper());

        _container.Instance(_container)
            .PerRequest<ICustomerEndpoint, CustomerEndpoint>();

        _container
            .Singleton<IWindowManager, WindowManager>()
            .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<IApiHelper, ApiHelper>();


        GetType().Assembly.GetTypes()
            .Where(type => type.IsClass)
            .Where(type => type.Name.EndsWith("ViewModel"))
            .ToList()
            .ForEach(viewModelType => _container.RegisterPerRequest(
                viewModelType, viewModelType.ToString(), viewModelType));

    }

    protected override object GetInstance(Type service, string key)
    {
        return _container.GetInstance(service, key);
    }

    protected override IEnumerable<object> GetAllInstances(Type service)
    {
        return _container.GetAllInstances(service);
    }

    protected override void BuildUp(object instance)
    {
        _container.BuildUp(instance);
    }

}
