using Microsoft.EntityFrameworkCore;

namespace CineClub.Data;

public class CineClubContext(DbContextOptions<CineClubContext> options) : DbContext(options)
{
}
