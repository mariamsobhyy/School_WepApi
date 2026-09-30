namespace School_WepApi.REPOs.Intarfaces
{
    public interface IGenaricRepo<T> where T : class 
    {
       ICollection<T> GetAll();

        T GetById (int id);

        void Add (T Entity);

        void Update (T Entity);

        void Delete (T Entity);

    }
}
