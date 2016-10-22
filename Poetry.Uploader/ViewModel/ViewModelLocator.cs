using Autofac;
using Microsoft.Practices.ServiceLocation;
using Poetry.Uploader.PoetryGeneration;
using Poetry.Uploader.Services.Api;
using Poetry.Uploader.Services.Api.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poetry.Uploader.ViewModel
{
    public class ViewModelLocator
    {
        public MainViewModel  Main
        {
            get
            {
                return _container.Resolve<MainViewModel>();
            }
        }

        public CreatePoetViewModel CreatePoet
        {
            get
            {
                return _container.Resolve<CreatePoetViewModel>();
            }
        }

        public PoemUploadViewModel  PoemUpload
        {
            get
            {
                return _container.Resolve<PoemUploadViewModel>();
            }
        }

        private IContainer _container;

        public ViewModelLocator()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<PoetryParser>().As<IPoetryParser>();
            builder.RegisterType<PoetService>().As<IPoetService>();
            builder.RegisterType<ApiService>().As<IApiService>();

            // ViewModels
            builder.RegisterType<CreatePoetViewModel>()
                .InstancePerDependency();
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<PoemUploadViewModel>();

            _container = builder.Build();
        }
    }
}
