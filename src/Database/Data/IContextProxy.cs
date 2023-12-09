namespace Database.Data;

public interface IContextProxy
{
    IRepo<T> GetRepo<T>()
        where T : class;
}
