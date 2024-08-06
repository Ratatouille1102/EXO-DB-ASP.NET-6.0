using BLL_DBSlide.Entities;
using System.Text.Json;

namespace ASP_DBSlide.Handlers
{
    public class SessionManager
    {
        private ISession _session;
        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }

        public StudentGroup? CurrentGroup
        {
            get {
                return JsonSerializer.Deserialize<StudentGroup?>(_session.GetString(nameof(CurrentGroup)) ?? "null");
            }
            set {
                if (value is null) return;
                _session.SetString(nameof(CurrentGroup), JsonSerializer.Serialize<StudentGroup>(value));
            }
        }
    }
}
