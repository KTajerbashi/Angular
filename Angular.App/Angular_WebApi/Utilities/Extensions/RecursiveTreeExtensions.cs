namespace Angular_WebApi.Utilities.Extensions;

public static class RecursiveTreeExtensions
{
    public static List<TTree> RecursiveTree<TTree>(List<TTree> list)
        where TTree : class, ITreeViewModel<TTree>
    {
        list.ForEach(r => r.Children = list.Where(ch => ch.ParentId == r.Id).ToList());//Cast<ITreeViewModel<TTree>>()

        return list.Where(i => i.ParentId == null).ToList();
    }
}

public interface ITreeViewModel<T>
    where T : class
{
    long Id { get; set; }
    long? ParentId { get; set; }
    List<T> Children { get; set; }
}
