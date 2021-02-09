using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(crud_students.Startup))]
namespace crud_students
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
