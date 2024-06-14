using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace pc2_202401.insurance.domain.model.aggregates;

public partial class Policy : IEntityWithCreatedUpdatedDate
{
    [Column("createdAt")]
    public DateTimeOffset? CreatedDate { get; set; }
    
    [Column("UpdatedAt")]
    public DateTimeOffset? UpdatedDate { get; set; }
}