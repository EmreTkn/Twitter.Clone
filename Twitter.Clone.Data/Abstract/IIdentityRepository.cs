using Twitter.Clone.Models.Concrete;

namespace Twitter.Clone.Data.Abstract;
public interface IIdentityRepository : IRepository<IdentityUser, string> { }