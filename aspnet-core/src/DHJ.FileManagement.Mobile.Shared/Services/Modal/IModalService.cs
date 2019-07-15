using System.Threading.Tasks;
using DHJ.FileManagement.Views;
using Xamarin.Forms;

namespace DHJ.FileManagement.Services.Modal
{
    public interface IModalService
    {
        Task ShowModalAsync(Page page);

        Task ShowModalAsync<TView>(object navigationParameter) where TView : IXamarinView;

        Task<Page> CloseModalAsync();
    }
}
