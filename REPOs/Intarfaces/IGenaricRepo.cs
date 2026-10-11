namespace School_WepApi.REPOs.Intarfaces
{
    public interface IGenaricRepo<T> where T : class 
    {
       Task <ICollection<T>> GetAll();

        Task <T> GetById (int id);

        Task Add (T Entity);

        void Update (T Entity);

        Task Delete (int id );

    }
}
