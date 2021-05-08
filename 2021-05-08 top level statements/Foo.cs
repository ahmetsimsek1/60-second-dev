using System.Threading.Tasks;

namespace MyApplication
{
    public class Foo
    {
        public async Task GoAsync() => await Task.CompletedTask;
    }
}