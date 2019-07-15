using Xamarin.Forms.Internals;

namespace DHJ.FileManagement.Behaviors
{
    [Preserve(AllMembers = true)]
    public interface IAction
    {
        bool Execute(object sender, object parameter);
    }
}