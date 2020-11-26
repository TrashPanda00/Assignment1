using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace WebAPI.Model {
public class Adult : Person {
    [MaxLength(50)]
    public string JobTitle { get; set; }

    public override string ToString() {
        return JsonSerializer.Serialize(this);
    }

    public void Update(Adult toUpdate) {
        JobTitle = toUpdate.JobTitle;
        base.Update(toUpdate);
    }

}
}