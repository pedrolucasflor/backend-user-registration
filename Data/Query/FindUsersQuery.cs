using System.ComponentModel.DataAnnotations;

namespace backend_user_registration.Data.Query
{
    public class FindUsersQuery
    {
        public int? page { get; set; }
        public int? size { get; set; }
        public string? name { get; set; }
    }
}